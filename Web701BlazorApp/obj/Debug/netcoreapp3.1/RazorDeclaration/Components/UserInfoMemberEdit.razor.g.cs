#pragma checksum "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\UserInfoMemberEdit.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82b3372eff545562c40a59706114a872374781f5"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Web701BlazorApp.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\_Imports.razor"
using Web701BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\_Imports.razor"
using Web701BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\UserInfoMemberEdit.razor"
using Web701BlazorApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\UserInfoMemberEdit.razor"
using Web701BlazorApp.Auth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\UserInfoMemberEdit.razor"
using SQLReflectionMapper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\UserInfoMemberEdit.razor"
using Web701BlazorApp.State;

#line default
#line hidden
#nullable disable
    public partial class UserInfoMemberEdit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 31 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\UserInfoMemberEdit.razor"
       

    int uid = -1;
    protected override async void OnInitialized() //get user data
    {
        uid = await Common.GetCurrentUserId(AuthenticationStateProvider);
        List<GrowerDetails> u = new List<GrowerDetails>();
        try
        {
            u = DBExecuter.SQLRequestSPAutoFillParams("sp_GetUserDetails", new ParamList { ["id"] = uid }).Map<GrowerDetails>();
            user = u.First();
            this.StateHasChanged();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.GetBaseException().Message);
        }
    }

    GrowerDetails user = new GrowerDetails();

    private void OnSubmit() //set user data
    {
        if (uid != -1)
        {
            try
            {
                DBExecuter.execNonQuerySPAutoFillParams("sp_SetUserDetails", new ParamList { ["id"] = uid, ["uName"] = user.uName, ["uDesc"] = user.uDescription });
                (AuthenticationStateProvider as WEB701BalzorApp.Auth.BasicAuthStateProvider).UpdateName(user.uName);
                StateControl.UserNameChange.Changed();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException().Message);
            }
        }
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private StateControl StateControl { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591