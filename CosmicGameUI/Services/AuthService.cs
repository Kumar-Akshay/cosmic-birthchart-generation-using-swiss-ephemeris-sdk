using CosmicGame.Shared.Models.Request;
using CosmicGame.Shared.Models.Response;
using CosmicGameUI.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace CosmicGameUI.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly CosmicAuthStateProvider _authProvider;

        public AuthService(HttpClient http, AuthenticationStateProvider authProvider)
        {
            _http = http;
            _authProvider = (CosmicAuthStateProvider)authProvider;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/user/UserLogin", request);
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

            if (result?.success == true && !string.IsNullOrEmpty(result.result?.access_token))
                await _authProvider.MarkUserAsAuthenticated(result.result.access_token);

            return result;
        }

        public async Task<ServiceResponse> RegisterAsync(RegisterRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/user/UserRegister", request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse>();
        }

        public async Task<ServiceResponse> ForgotPasswordAsync(string email)
        {
            var response = await _http.PostAsJsonAsync("api/user/ForgotPassword", new { email });
            return await response.Content.ReadFromJsonAsync<ServiceResponse>();
        }

        public async Task LogoutAsync()
        {
            await _authProvider.MarkUserAsLoggedOut();
        }
    }
}
