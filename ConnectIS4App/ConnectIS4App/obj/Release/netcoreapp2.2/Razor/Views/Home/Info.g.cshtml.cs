#pragma checksum "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\Home\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9044e64a30796e654e2fadfe299f8590bd7c18f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Info), @"mvc.1.0.view", @"/Views/Home/Info.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Info.cshtml", typeof(AspNetCore.Views_Home_Info))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\_ViewImports.cshtml"
using ConnectIS4App;

#line default
#line hidden
#line 2 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\_ViewImports.cshtml"
using ConnectIS4App.Models;

#line default
#line hidden
#line 1 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\Home\Info.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9044e64a30796e654e2fadfe299f8590bd7c18f", @"/Views/Home/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73c2af9b22061be02693b3bec644b777c0bce19d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\Home\Info.cshtml"
  
    var claims = User.Claims;
    var authenticate = await ViewContext.HttpContext.AuthenticateAsync("Cookie");
    var at = authenticate.Ticket.Properties.GetTokenValue("access_token");
    var idt = authenticate.Ticket.Properties.GetTokenValue("id_token");
    var rt = authenticate.Ticket.Properties.GetTokenValue("refresh_token");

#line default
#line hidden
            BeginContext(393, 25, true);
            WriteLiteral("\r\n<dt>id_token</dt>\r\n<dd>");
            EndContext();
            BeginContext(419, 3, false);
#line 12 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\Home\Info.cshtml"
Write(idt);

#line default
#line hidden
            EndContext();
            BeginContext(422, 36, true);
            WriteLiteral("</dd>\r\n\r\n<dt>access token</dt>\r\n<dd>");
            EndContext();
            BeginContext(459, 2, false);
#line 15 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\Home\Info.cshtml"
Write(at);

#line default
#line hidden
            EndContext();
            BeginContext(461, 37, true);
            WriteLiteral("</dd>\r\n\r\n<dt>refresh token</dt>\r\n<dd>");
            EndContext();
            BeginContext(499, 2, false);
#line 18 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\Home\Info.cshtml"
Write(rt);

#line default
#line hidden
            EndContext();
            BeginContext(501, 26, true);
            WriteLiteral("</dd>\r\n\r\n<h1>Welcome back ");
            EndContext();
            BeginContext(528, 18, false);
#line 20 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\Home\Info.cshtml"
            Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(546, 35, true);
            WriteLiteral("</h1>\r\n<h2>User Claims</h2>\r\n<dl>\r\n");
            EndContext();
#line 23 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\Home\Info.cshtml"
     foreach (var claim in User.Claims)
    {

#line default
#line hidden
            BeginContext(629, 12, true);
            WriteLiteral("        <dt>");
            EndContext();
            BeginContext(642, 10, false);
#line 25 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\Home\Info.cshtml"
       Write(claim.Type);

#line default
#line hidden
            EndContext();
            BeginContext(652, 19, true);
            WriteLiteral("</dt>\r\n        <dd>");
            EndContext();
            BeginContext(672, 11, false);
#line 26 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\Home\Info.cshtml"
       Write(claim.Value);

#line default
#line hidden
            EndContext();
            BeginContext(683, 7, true);
            WriteLiteral("</dd>\r\n");
            EndContext();
#line 27 "C:\Users\austin.hasemeyer\source\repos\ConnectIS4App\ConnectIS4App\Views\Home\Info.cshtml"
    }

#line default
#line hidden
            BeginContext(697, 5, true);
            WriteLiteral("</dl>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591