#pragma checksum "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\Pages\VisualElement.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c8f9bd93add1df3d91b1dfe9b1746af98a49f8b"
// <auto-generated/>
#pragma warning disable 1591
namespace tests.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\_Imports.razor"
using tests;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\_Imports.razor"
using tests.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\_Imports.razor"
using BlazorStyled;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/visual")]
    public partial class VisualElement : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<BlazorStyled.Styled>(0);
            __builder.AddAttribute(1, "Classname", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 2 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\Pages\VisualElement.razor"
                          vefclass

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "ClassnameChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => vefclass = __value, vefclass))));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(4, "\r\n    #elem {\r\n    width: 100px;\r\n    height: 100px;\r\n    background: #4d4c70;\r\n    transition: width 3s, height 5s;\r\n    }\r\n\r\n    #elem:hover {\r\n    width: 400px;\r\n    height: 400px;\r\n    }\r\n");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.AddMarkupContent(6, "<h1>CSS transition interactive element</h1>\r\n");
            __builder.AddMarkupContent(7, "<p>Hover over the element:</p>\r\n<div id=\"elem\"></div>");
        }
        #pragma warning restore 1998
#nullable restore
#line 20 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\tests\Pages\VisualElement.razor"
       
    private string vefclass;

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591