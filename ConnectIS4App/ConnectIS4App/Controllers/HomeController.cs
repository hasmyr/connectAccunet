using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConnectIS4App.Models;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.WebSockets.Internal;
using IdentityModel.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ConnectIS4App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Log into Accunet through IS4 server
        public async Task<IActionResult> Login()
        {
            var authenticate = await HttpContext.AuthenticateAsync("Cookie");
            var accessToken = authenticate?.Ticket?.Properties?.GetTokenValue("access_token");
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                //Check if token is still active
                var client = new HttpClient();
                //var uri = new Uri($"http://tenant3.asc-accunet-dev.com/External/Login?token={accessToken}");
                var uri = new Uri($"http://localhost:60003/External/Login?token={accessToken}");
                var response = await client.GetAsync(uri);

                //If active redirect with token
                if (response.IsSuccessStatusCode)
                {
                    //return Redirect($"http://tenant3.asc-accunet-dev.com/External/Login?token={accessToken}");
                    return Redirect($"http://localhost:60003/External/Login?token={accessToken}");
                }
                else
                {
                    //refresh access token
                    var disco = new DiscoveryClient("http://localhost:5000");
                    //var disco = new DiscoveryClient("https://auth.asc-accunet-dev.com");
                    disco.Policy.RequireHttps = false;
                    var discoResponse = await disco.GetAsync();
                    if (discoResponse.IsError) throw new Exception(discoResponse.Error);
                    
                    var tokenClient = new TokenClient(discoResponse.TokenEndpoint, "mvc", "secret");
                    var cookie = await HttpContext.AuthenticateAsync("Cookie");
                    var refreshToken = cookie.Ticket.Properties.GetTokenValue(OpenIdConnectParameterNames.RefreshToken);

                    var tokenResult = await tokenClient.RequestRefreshTokenAsync(refreshToken);
                    
                    var idToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
                    var new_access_token = tokenResult.AccessToken;
                    var new_refresh_token = tokenResult.RefreshToken;

                    var tokens = new List<AuthenticationToken>
                    {
                        new AuthenticationToken { Name = OpenIdConnectParameterNames.IdToken, Value = idToken },
                        new AuthenticationToken { Name = OpenIdConnectParameterNames.AccessToken, Value = new_access_token },
                        new AuthenticationToken { Name = OpenIdConnectParameterNames.RefreshToken, Value = new_refresh_token }
                    };

                    AuthenticateResult info = await HttpContext.AuthenticateAsync("Cookie");
                    info.Properties.StoreTokens(tokens);

                    //save new token info to update stored cookie
                    await HttpContext.SignInAsync("Cookie", info.Principal, info.Properties);

                    //login to accunet
                    //return Redirect($"http://tenant3.asc-accunet-dev.com/External/Login?token={accessToken}");
                    return Redirect($"http://localhost:60003/External/Login?token={accessToken}");
                }
            }
            else
            {
                //If no cookie present challenge
                return Challenge(new AuthenticationProperties
                {
                    RedirectUri = "home/accunet"
                }, "challenge");
            }
        }

        //Get cookie and redirect to Accunet
        public async Task<IActionResult> Accunet()
        {
            var authenticate = await HttpContext.AuthenticateAsync("Cookie");
            var accessToken = authenticate.Ticket.Properties.GetTokenValue("access_token");
            //return Redirect($"http://tenant3.asc-accunet-dev.com/External/Login?token={accessToken}");
            return Redirect($"http://localhost:60003/External/Login?token={accessToken}");
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return SignOut(new AuthenticationProperties
            {
                RedirectUri = "/Home/Index"
            }, "Cookie", "challenge");
        }
    }
}
