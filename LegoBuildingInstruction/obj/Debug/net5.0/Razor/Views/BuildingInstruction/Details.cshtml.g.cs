#pragma checksum "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2405ed30cb0886685beaf69bb77917cbb86fa29"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BuildingInstruction_Details), @"mvc.1.0.view", @"/Views/BuildingInstruction/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2405ed30cb0886685beaf69bb77917cbb86fa29", @"/Views/BuildingInstruction/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05a21b49ae1dda36b9ebf0b3e777eb918381b5fa", @"/Views/_ViewImports.cshtml")]
    public class Views_BuildingInstruction_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BuildingInstruction>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Rating", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Comment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<div class=\"container-fluid p-5\">\r\n\r\n\r\n\r\n    <div class=\"row\">\r\n\r\n\r\n        <div class=\"col-lg-7\">\r\n\r\n            <div class=\"embed-responsive embed-responsive-16by9\">\r\n                <iframe class=\"embed-responsive-item\"");
            BeginWriteAttribute("src", " src=\"", 256, "\"", 277, 1);
#nullable restore
#line 15 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
WriteAttributeValue("", 262, Model.VideoUrl, 262, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" title=""YouTube video player"" frameborder=""0"" allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen></iframe>

            </div>

        </div>


        <div class=""col-lg-5"">

            <h4>");
#nullable restore
#line 24 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-sm\">\r\n                    <p class=\"text-secondary\"> Pages: ");
#nullable restore
#line 28 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
                                                 Write(Model.Pages);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                </div>\r\n                <div class=\"col-sm\">\r\n                    <p class=\"text-secondary\"> Set: ");
#nullable restore
#line 31 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
                                               Write(Model.Set);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                </div>\r\n\r\n\r\n                <div class=\"col-sm\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f2405ed30cb0886685beaf69bb77917cbb86fa296471", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 36 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n\r\n            </div>\r\n            <hr />\r\n\r\n            <p class=\"text-secondary\">");
#nullable restore
#line 42 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
                                 Write(Model.LongDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n\r\n\r\n\r\n            <button class=\" btn btn-secondary btn-block\">Get Building Instruction</button>\r\n            <button class=\" btn btn-secondary btn-block\">Get Program</button>\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f2405ed30cb0886685beaf69bb77917cbb86fa298741", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n<!--<div class=\"thumbnail\">-->\r\n");
            WriteLiteral("<!--<div class=\"iframe-container\">\r\n            <iframe width=\"850\" height=\"415\" src=\"");
#nullable restore
#line 62 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
                                             Write(Model.VideoUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" title=""YouTube video player"" frameborder=""0"" allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen></iframe>

        </div>
        <div class=""caption-full"">
            <h3 class=""pull-right""><span class=""glyphicon glyphicon-list-alt""></span>Pages: ");
#nullable restore
#line 66 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
                                                                                       Write(Model.Pages);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <h3>\r\n                <a href=\"#\">");
#nullable restore
#line 68 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
                       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n            </h3>\r\n            <h4>");
#nullable restore
#line 70 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
           Write(Model.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <p>");
#nullable restore
#line 71 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
          Write(Model.LongDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"addToCart\">\r\n                <p class=\"button\">\r\n                    <a class=\"btn btn-primary\" asp-controller=\"ShoppingCart\" asp-action=\"AddToShoppingCart\"\r\n                       asp-route-pieId=\"");
#nullable restore
#line 75 "C:\Users\Marzena\Desktop\LegoBuildingInstruction\LegoBuildingInstruction\Views\BuildingInstruction\Details.cshtml"
                                   Write(Model.Pages);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Add to cart</a>\r\n                </p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>-->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BuildingInstruction> Html { get; private set; }
    }
}
#pragma warning restore 1591
