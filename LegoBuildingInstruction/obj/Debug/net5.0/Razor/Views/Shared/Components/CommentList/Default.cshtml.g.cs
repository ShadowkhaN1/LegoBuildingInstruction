#pragma checksum "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\Shared\Components\CommentList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af833e5dd4244cfab044e572c7b913e4f4730916"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CommentList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CommentList/Default.cshtml")]
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
#line 2 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\_ViewImports.cshtml"
using LegoBuildingInstruction.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\_ViewImports.cshtml"
using LegoBuildingInstruction.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\_ViewImports.cshtml"
using LegoBuildingInstruction.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af833e5dd4244cfab044e572c7b913e4f4730916", @"/Views/Shared/Components/CommentList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05a21b49ae1dda36b9ebf0b3e777eb918381b5fa", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CommentList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Comment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<h3>");
#nullable restore
#line 4 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\Shared\Components\CommentList\Default.cshtml"
Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(" Comments</h3>\r\n\r\n\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\Shared\Components\CommentList\Default.cshtml"
 foreach (var comment in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"media\">\r\n        <a class=\"pull-left\" href=\"#\"><img class=\"rounded-circle\" src=\"https://bootdey.com/img/Content/avatar/avatar1.png\"");
            BeginWriteAttribute("alt", " alt=\"", 256, "\"", 262, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n        <div class=\"media-body\">\r\n            <h4 class=\"media-heading\">");
#nullable restore
#line 13 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\Shared\Components\CommentList\Default.cshtml"
                                 Write(comment.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <p>");
#nullable restore
#line 14 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\Shared\Components\CommentList\Default.cshtml"
          Write(comment.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"row\">\r\n                <div class=\"col-md-6\"><i class=\"far fa-calendar-alt fa-fw\"></i>27/02/2014  ");
#nullable restore
#line 16 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\Shared\Components\CommentList\Default.cshtml"
                                                                                      Write(comment.CreatedAt.ToString("dd/MM/yyyy h:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
            WriteLiteral("\r\n            </div>\r\n");
            WriteLiteral("        </div>\r\n    </div>\r\n");
#nullable restore
#line 26 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\Shared\Components\CommentList\Default.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Comment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
