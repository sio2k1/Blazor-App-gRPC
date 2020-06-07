using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WEB701BalzorApp.Auth
{
    public class BasicAuthStateProvider : AuthenticationStateProvider
    {

        public ILocalStorageService _localStorageService { get; }

        public BasicAuthStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;

        }

        public async Task MarkUserAsAuthenticated(User user)
        {
            await _localStorageService.SetItemAsync("login", user.uLogin);
            await _localStorageService.SetItemAsync("name", user.uName);
            await _localStorageService.SetItemAsync("role", user.uRole);
            await _localStorageService.SetItemAsync("id", user.id.ToString());
            var identity = GetClaimsIdentity(user);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            await _localStorageService.RemoveItemAsync("login");
            await _localStorageService.RemoveItemAsync("name");
            await _localStorageService.RemoveItemAsync("role");
            await _localStorageService.RemoveItemAsync("id");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var login = await _localStorageService.GetItemAsync<string>("login");
            var role = await _localStorageService.GetItemAsync<string>("role");
            var uid = await _localStorageService.GetItemAsync<string>("id");
            var name = await _localStorageService.GetItemAsync<string>("name");
            uid = string.IsNullOrEmpty(uid) ? "0" : uid;
            ClaimsIdentity identity;

            if (login != null && login != string.Empty)
            {
                User user = new User { uLogin = login, uRole = role, id=int.Parse(uid), uName=name };
                identity = GetClaimsIdentity(user);
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var claimsPrincipal = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        private ClaimsIdentity GetClaimsIdentity(User user)
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
