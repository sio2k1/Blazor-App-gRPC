#pragma checksum "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\AucBidLineCard.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e09ea629e216a9ef8460095c41961a1abbb693b9"
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
#line 2 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\AucBidLineCard.razor"
using Web701BlazorApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\AucBidLineCard.razor"
using SQLReflectionMapper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\AucBidLineCard.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\AucBidLineCard.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
    public partial class AucBidLineCard : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 53 "E:\@SkyDrive\SkyDrive\@backup\@nmit\WEB701\WEB701PRJ\Web701BlazorApp\Components\AucBidLineCard.razor"
       
    [Parameter]
    public ItemModel item { get; set; }
    [Parameter]
    public int CurrentUserId { get; set; }

    private string visibility = "";
    private string confVisibility = "hidden";

    private float lastBid = 0;
    private float getBidValue() // auto generate next bid value
    {
        return (item.CurrentBid + 5) > item.BuyOutPrice ? item.BuyOutPrice : (item.CurrentBid + 5);
    }

    async Task HideMsg() // confirmation msg delay b4 hide
    {
        await Task.Delay(8000);
        confVisibility = "hidden";
        this.StateHasChanged();
    }

    public async void PlaceBid(float bid)
    {
        lastBid = bid;
        ParamList p = new ParamList
        {
            ["itemsID"] = item.Id,
            ["clientID"] = CurrentUserId,
            ["bid"] = bid
        };
        try
        {
            DBExecuter.execNonQuerySPAutoFillParams("sp_BidOnItem", p); //place bid
            item.CurrentBid = bid;
            item.ClientUserRecordID = CurrentUserId;
            if (item.CurrentBid == item.BuyOutPrice)
            {
                visibility = "hidden";
            }
            confVisibility = ""; //show confirmation msg
            await HideMsg();
            this.StateHasChanged();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.GetBaseException().Message);
        }
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
