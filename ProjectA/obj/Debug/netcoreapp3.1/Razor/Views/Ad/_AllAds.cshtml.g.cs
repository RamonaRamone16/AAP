#pragma checksum "C:\Repositories\ProjectA\ProjectA\Views\Ad\_AllAds.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9625ac7a0dd2aeec7e5a4171396c1a382d1acf52"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ad__AllAds), @"mvc.1.0.view", @"/Views/Ad/_AllAds.cshtml")]
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
#nullable restore
#line 1 "C:\Repositories\ProjectA\ProjectA\Views\_ViewImports.cshtml"
using ProjectA;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Repositories\ProjectA\ProjectA\Views\_ViewImports.cshtml"
using ProjectA.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Repositories\ProjectA\ProjectA\Views\Ad\_AllAds.cshtml"
using ProjectA.DAL.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9625ac7a0dd2aeec7e5a4171396c1a382d1acf52", @"/Views/Ad/_AllAds.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cb95dcf11b4e08ed4fb589055f09319332a176d", @"/Views/_ViewImports.cshtml")]
    public class Views_Ad__AllAds : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Ad>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Repositories\ProjectA\ProjectA\Views\Ad\_AllAds.cshtml"
  
    ViewData["Title"] = "_AllRecords";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h5>Объявления</h5>\r\n\r\n<hr />\r\n");
#nullable restore
#line 12 "C:\Repositories\ProjectA\ProjectA\Views\Ad\_AllAds.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center mt-3 mb-3\">\r\n        <div class=\"d-flex justify-content-between\">\r\n            <p style=\"font-size: 15px\" class=\"d-inline\">");
#nullable restore
#line 16 "C:\Repositories\ProjectA\ProjectA\Views\Ad\_AllAds.cshtml"
                                                   Write(item.User.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 16 "C:\Repositories\ProjectA\ProjectA\Views\Ad\_AllAds.cshtml"
                                                                   Write(item.User.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <h4>\r\n                ");
#nullable restore
#line 19 "C:\Repositories\ProjectA\ProjectA\Views\Ad\_AllAds.cshtml"
           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </h4>\r\n        <p> ");
#nullable restore
#line 21 "C:\Repositories\ProjectA\ProjectA\Views\Ad\_AllAds.cshtml"
       Write(item.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <hr />\r\n");
#nullable restore
#line 24 "C:\Repositories\ProjectA\ProjectA\Views\Ad\_AllAds.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Ad>> Html { get; private set; }
    }
}
#pragma warning restore 1591
