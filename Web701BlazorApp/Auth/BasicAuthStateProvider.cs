using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SQLReflectionMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web701BlazorApp.State;

//We need to implement this to use auth features in blazor, to show hide content.
namespace WEB701BalzorApp.Auth
{
    public class BasicAuthStateProvider : AuthenticationStateProvider
    {

        public ILocalStorageService _localStorageService { get; }

        public BasicAuthStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;

        }

        public async Task MarkUserAsAuthenticated(User user) //on successful auth, claa this to set user and save token for session restore.
        {
            await _localStorageService.SetItemAsync("token", user.uToken);
            var identity = GetClaimsIdentity(user);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task MarkUserAsLoggedOut() // call this to logout
        {
            await _localStorageService.RemoveItemAsync("token");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }



        public override async Task<AuthenticationState> GetAuthenticationStateAsync() // automatically called when site is loaded, we can restore session here
        {
            var token = await _localStorageService.GetItemAsync<string>("token");
            var xtra = await _localStorageService.GetItemAsync<string>("xtra");
            ClaimsIdentity identity = new ClaimsIdentity(); ;

            if (!string.IsNullOrEmpty(token))
            {

                try
                {
                    List <User> users = DBExecuter.SQLRequestSPAutoFillParams("sp_VerifyUserByToken", new ParamList { ["token"] = token, ["extrainfo"] = xtra }).Map<User>(); //token auth
                    if (users.Count == 1)
                    {
                        identity = GetClaimsIdentity(users.FirstOrDefault());
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.GetBaseException().Message);
                }
            }

            var claimsPrincipal = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        public async void UpdateName(string name) // username update at pages when we change it from account settings.
        {
            await _localStorageService.SetItemAsync("name", name);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        private ClaimsIdentity GetClaimsIdentity(User user) //create claims based on user object
        {
                       var claimsIdentity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Name, user.uLogin),
                                    new Claim(ClaimTypes.GivenName, user.uName),
                                    new Claim(ClaimTypes.Role, user.uRole),
                                    new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                                }, "api");
            return claimsIdentity;
        }
    }
}
