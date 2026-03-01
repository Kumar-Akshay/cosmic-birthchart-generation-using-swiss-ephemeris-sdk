using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace CosmicGameUI.Auth
{
    public class JwtAuthorizationHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;

        public JwtAuthorizationHandler(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var token = await _localStorage.GetItemAsStringAsync("cosmic_jwt");
            if (!string.IsNullOrWhiteSpace(token))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
