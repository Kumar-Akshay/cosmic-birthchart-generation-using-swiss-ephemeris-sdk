using CosmicGame.Shared.Models.Request;
using CosmicGame.Shared.Models.Response;
using CosmicGame.Shared.Models.ViewModel;
using System.Net.Http.Json;

namespace CosmicGameUI.Services
{
    public class ChartHolderApiService : IChartHolderApiService
    {
        private readonly HttpClient _http;

        public ChartHolderApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ChartHolderResponse>> GetChartHoldersAsync()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse>("api/chartholder/ChartHolderList");
            if (result?.success == true && result.result is not null)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(result.result);
                return System.Text.Json.JsonSerializer.Deserialize<List<ChartHolderResponse>>(json,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    ?? new List<ChartHolderResponse>();
            }
            return new List<ChartHolderResponse>();
        }

        public async Task<ChartHolderResponse> GetChartHolderByIdAsync(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse>($"api/chartholder/ChartHolderById?id={id}");
            if (result?.success == true && result.result is not null)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(result.result);
                return System.Text.Json.JsonSerializer.Deserialize<ChartHolderResponse>(json,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return null;
        }

        public async Task<ServiceResponse> AddChartHolderAsync(ChartHolderRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/chartholder/AddChartHolder", request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse>();
        }

        public async Task<ServiceResponse> UpdateChartHolderAsync(ChartHolderRequest request)
        {
            var response = await _http.PutAsJsonAsync("api/chartholder/UpdateChartHolder", request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse>();
        }

        public async Task<ServiceResponse> DeleteChartHolderAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/chartholder/RemoveChartHolder?id={id}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse>();
        }

        public async Task<List<string>> GetCountriesAsync()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse>("api/chartholder/Countries");
            if (result?.success == true && result.result is not null)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(result.result);
                return System.Text.Json.JsonSerializer.Deserialize<List<string>>(json,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    ?? new List<string>();
            }
            return new List<string>();
        }

        public async Task<List<TimeZoneModel>> GetTimeZonesAsync(string country)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse>($"api/chartholder/TimeZone?country={Uri.EscapeDataString(country)}");
            if (result?.success == true && result.result is not null)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(result.result);
                return System.Text.Json.JsonSerializer.Deserialize<List<TimeZoneModel>>(json,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    ?? new List<TimeZoneModel>();
            }
            return new List<TimeZoneModel>();
        }

        public async Task<List<AddressResponse>> GetAddressesAsync()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse>("api/chartholder/GetAllCurrentAddress");
            if (result?.success == true && result.result is not null)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(result.result);
                return System.Text.Json.JsonSerializer.Deserialize<List<AddressResponse>>(json,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    ?? new List<AddressResponse>();
            }
            return new List<AddressResponse>();
        }

        public async Task<ServiceResponse> AddAddressAsync(AddressRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/chartholder/AddCurrentAddress", request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse>();
        }

        public async Task<ServiceResponse> DeleteAddressAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/chartholder/RemoveCurrentAddress?id={id}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse>();
        }
    }
}
