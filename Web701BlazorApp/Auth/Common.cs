using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web701BlazorApp.Auth
{
    public static class Common
    {
        public static async Task<int> GetCurrentUserId(AuthenticationStateProvider ap) //using this to get user id from context.
        {
            var authState = await ap.GetAuthenticationStateAsync();
            var user = authState.User;
            return int.Parse(user.FindFirst(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
        }
    }
}
