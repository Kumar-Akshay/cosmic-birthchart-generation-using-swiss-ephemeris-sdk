using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CosmicGameUI.Auth
{
    public class CosmicAuthStateProvider : AuthenticationStateProvider
    {
        private const string TokenKey = "cosmic_jwt";
        private readonly ILocalStorageService _localStorage;
        private static readonly AuthenticationState Anonymous =
            new(new ClaimsPrincipal(new ClaimsIdentity()));

        public CosmicAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await _localStorage.GetItemAsStringAsync(TokenKey);
                if (string.IsNullOrWhiteSpace(token))
                    return Anonymous;

                var handler = new JwtSecurityTokenHandler();
                if (!handler.CanReadToken(token))
                    return Anonymous;

                var jwt = handler.ReadJwtToken(token);
                if (jwt.ValidTo < DateTime.UtcNow)
                {
                    await _localStorage.RemoveItemAsync(TokenKey);
                    return Anonymous;
                }

                var identity = new ClaimsIdentity(jwt.Claims, "jwt");
                var user = new ClaimsPrincipal(identity);
                return new AuthenticationState(user);
            }
            catch
            {
                return Anonymous;
            }
        }

        public async Task MarkUserAsAuthenticated(string token)
        {
            await _localStorage.SetItemAsStringAsync(TokenKey, token);
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwt.Claims, "jwt");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            await _localStorage.RemoveItemAsync(TokenKey);
            NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        }

        public async Task<string> GetTokenAsync()
        {
            return await _localStorage.GetItemAsStringAsync(TokenKey) ?? string.Empty;
        }

        public async Task<int> GetUserIdAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrEmpty(token)) return 0;
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var idClaim = jwt.Claims.FirstOrDefault(c => c.Type == "userId" || c.Type == "sub");
            return int.TryParse(idClaim?.Value, out var id) ? id : 0;
        }
    }
}
