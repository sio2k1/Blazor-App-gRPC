using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WEB701BalzorApp.infastructure
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
            await _localStorageService.SetItemAsync("login", user.login);
            await _localStorageService.SetItemAsync("role", user.role);
            var identity = GetClaimsIdentity(user);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            await _localStorageService.RemoveItemAsync("login");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var login = await _localStorageService.GetItemAsync<string>("login");
            var role = await _localStorageService.GetItemAsync<string>("role");
            ClaimsIdentity identity;

            if (login != null && login != string.Empty)
            {
                User user = new User { login = login, role = role };
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
                                    new Claim(ClaimTypes.Name, user.login),
                                    new Claim(ClaimTypes.Role, user.role),
                                }, "api");
            return claimsIdentity;
        }
    }
}
