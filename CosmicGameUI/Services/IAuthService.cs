using CosmicGame.Shared.Models.Request;
using CosmicGame.Shared.Models.Response;

namespace CosmicGameUI.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<ServiceResponse> RegisterAsync(RegisterRequest request);
        Task<ServiceResponse> ForgotPasswordAsync(string email);
        Task LogoutAsync();
    }
}
