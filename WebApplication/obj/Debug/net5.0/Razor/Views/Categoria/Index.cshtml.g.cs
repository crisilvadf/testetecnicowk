#pragma checksum "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28cc5316cbdeeb36a3575010d092ec74a355d25d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categoria_Index), @"mvc.1.0.view", @"/Views/Categoria/Index.cshtml")]
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
#line 1 "C:\teste-tecnico\WebApplication\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\teste-tecnico\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28cc5316cbdeeb36a3575010d092ec74a355d25d", @"/Views/Categoria/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa0ef8da47a84ffb33e8bc853509aa4fa5703a26", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Categoria_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication.Models.Categoria>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container mt-5\">\r\n    <div class=\"row\">\r\n        <h2>Lista de Categorias Ativas</h2>\r\n        <hr />\r\n        <p>\r\n            <button");
            BeginWriteAttribute("onclick", " onclick=\"", 244, "\"", 318, 4);
            WriteAttributeValue("", 254, "location.href=\'", 254, 15, true);
#nullable restore
#line 12 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
WriteAttributeValue("", 269, Url.Action("Create", "Categoria"), 269, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 303, "\';return", 303, 8, true);
            WriteAttributeValue(" ", 311, "false;", 312, 7, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Nova Categoria</button>\r\n        </p>\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 18 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.NomeCategoria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 21 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.IdCategoria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 24 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.DataCriacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 30 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 34 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NomeCategoria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 37 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.IdCategoria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 40 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DataCriacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td class=\"btn-group\" role=\"group\">\r\n                            <button");
            BeginWriteAttribute("onclick", " onclick=\"", 1540, "\"", 1650, 4);
            WriteAttributeValue("", 1550, "location.href=\'", 1550, 15, true);
#nullable restore
#line 43 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
WriteAttributeValue("", 1565, Url.Action("Details", "Categoria", new { guidId = item.IdCategoria }), 1565, 70, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1635, "\';return", 1635, 8, true);
            WriteAttributeValue(" ", 1643, "false;", 1644, 7, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-secondary\">Detalhar</button>\r\n                            <button");
            BeginWriteAttribute("onclick", " onclick=\"", 1732, "\"", 1839, 4);
            WriteAttributeValue("", 1742, "location.href=\'", 1742, 15, true);
#nullable restore
#line 44 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
WriteAttributeValue("", 1757, Url.Action("Edit", "Categoria", new { guidId = item.IdCategoria }), 1757, 67, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1824, "\';return", 1824, 8, true);
            WriteAttributeValue(" ", 1832, "false;", 1833, 7, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">Editar</button>\r\n                            <button");
            BeginWriteAttribute("onclick", " onclick=\"", 1917, "\"", 2026, 4);
            WriteAttributeValue("", 1927, "location.href=\'", 1927, 15, true);
#nullable restore
#line 45 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
WriteAttributeValue("", 1942, Url.Action("Delete", "Categoria", new { guidId = item.IdCategoria }), 1942, 69, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2011, "\';return", 2011, 8, true);
            WriteAttributeValue(" ", 2019, "false;", 2020, 7, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Deletar</button>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 48 "C:\teste-tecnico\WebApplication\Views\Categoria\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication.Models.Categoria>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
