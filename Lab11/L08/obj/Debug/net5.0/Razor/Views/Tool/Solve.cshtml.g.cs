#pragma checksum "C:\Users\ms200\source\repos\L08\Views\Tool\Solve.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4b496cead63514f5d8a0be833642bc49d91bafe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tool_Solve), @"mvc.1.0.view", @"/Views/Tool/Solve.cshtml")]
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
#line 1 "C:\Users\ms200\source\repos\L08\Views\_ViewImports.cshtml"
using L08;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ms200\source\repos\L08\Views\_ViewImports.cshtml"
using L08.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4b496cead63514f5d8a0be833642bc49d91bafe", @"/Views/Tool/Solve.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb7fd76c42bf442fd55c54c67ad12904a6b8a6e5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Tool_Solve : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\ms200\source\repos\L08\Views\Tool\Solve.cshtml"
  
    ViewData["Title"] = "Zadanie 1";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Oblicz równanie kwadratowe</h1>\r\n\r\n\r\n\r\n<h2");
            BeginWriteAttribute("class", " class=\"", 95, "\"", 117, 1);
#nullable restore
#line 10 "C:\Users\ms200\source\repos\L08\Views\Tool\Solve.cshtml"
WriteAttributeValue("", 103, ViewBag.label, 103, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 10 "C:\Users\ms200\source\repos\L08\Views\Tool\Solve.cshtml"
                      Write(ViewBag.info);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h3");
            BeginWriteAttribute("class", " class=\"", 142, "\"", 167, 1);
#nullable restore
#line 11 "C:\Users\ms200\source\repos\L08\Views\Tool\Solve.cshtml"
WriteAttributeValue("", 150, ViewBag.labelVal, 150, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 11 "C:\Users\ms200\source\repos\L08\Views\Tool\Solve.cshtml"
                         Write(ViewBag.x1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3");
            BeginWriteAttribute("class", " class=\"", 190, "\"", 215, 1);
#nullable restore
#line 12 "C:\Users\ms200\source\repos\L08\Views\Tool\Solve.cshtml"
WriteAttributeValue("", 198, ViewBag.labelVal, 198, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 12 "C:\Users\ms200\source\repos\L08\Views\Tool\Solve.cshtml"
                         Write(ViewBag.x2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591