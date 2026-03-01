using CosmicGame.Shared.Models.Request;
using CosmicGame.Shared.Models.Response;
using CosmicGame.Shared.Models.ViewModel;

namespace CosmicGameUI.Services
{
    public interface IChartHolderApiService
    {
        Task<List<ChartHolderResponse>> GetChartHoldersAsync();
        Task<ChartHolderResponse> GetChartHolderByIdAsync(int id);
        Task<ServiceResponse> AddChartHolderAsync(ChartHolderRequest request);
        Task<ServiceResponse> UpdateChartHolderAsync(ChartHolderRequest request);
        Task<ServiceResponse> DeleteChartHolderAsync(int id);
        Task<List<string>> GetCountriesAsync();
        Task<List<TimeZoneModel>> GetTimeZonesAsync(string country);
        Task<List<AddressResponse>> GetAddressesAsync();
        Task<ServiceResponse> AddAddressAsync(AddressRequest request);
        Task<ServiceResponse> DeleteAddressAsync(int id);
    }
}
