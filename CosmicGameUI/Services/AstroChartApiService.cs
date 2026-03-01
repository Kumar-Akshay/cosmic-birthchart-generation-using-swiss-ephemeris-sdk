using CosmicGame.Shared.Models.Response;
using CosmicGame.Shared.Models.ViewModel;
using System.Net.Http.Json;
using System.Text.Json;

namespace CosmicGameUI.Services
{
    public class AstroChartApiService : IAstroChartApiService
    {
        private readonly HttpClient _http;
        private static readonly JsonSerializerOptions _jsonOpts =
            new() { PropertyNameCaseInsensitive = true };

        public AstroChartApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TraditionalChartCell>> GetTraditionalChartAsync(int chartHolderId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse>(
                $"api/astrocharts/GetTraditionalChart?chartHolderId={chartHolderId}");
            return DeserializeList<TraditionalChartCell>(result);
        }

        public async Task<List<BaskiChartRow>> GetBaskiChartAsync(int chartHolderId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse>(
                $"api/astrocharts/GetBaskiChart?chartHolderId={chartHolderId}");
            return DeserializeList<BaskiChartRow>(result);
        }

        public async Task<List<VimsoChartCell>> GetVimsoDissaiAsync(int chartHolderId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse>(
                $"api/astrocharts/GetVimsoDissaiChart?chartHolderId={chartHolderId}");
            return DeserializeList<VimsoChartCell>(result);
        }

        public async Task<List<VimsoChartCell>> GetVimsoPuthiAsync(int chartHolderId, int dissaiGp)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse>(
                $"api/astrocharts/GetVimsoPuthiChart?chartHolderId={chartHolderId}&dissaiGp={dissaiGp}");
            return DeserializeList<VimsoChartCell>(result);
        }

        public async Task<List<VimsoChartCell>> GetVimsoAntraAsync(int chartHolderId, int dissaiGp, int puthiGp)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse>(
                $"api/astrocharts/GetVimsoAntraSoksumaChart?chartHolderId={chartHolderId}&dissaiGp={dissaiGp}&puthiGp={puthiGp}");
            return DeserializeList<VimsoChartCell>(result);
        }

        public async Task<List<VimsoChartCell>> GetVimsoPranaAsync(int chartHolderId, int dissaiGp, int puthiGp, int antraGp)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse>(
                $"api/astrocharts/GetVimsoPranaChart?chartHolderId={chartHolderId}&dissaiGp={dissaiGp}&puthiGp={puthiGp}&antraGp={antraGp}");
            return DeserializeList<VimsoChartCell>(result);
        }

        private static List<T> DeserializeList<T>(ServiceResponse result)
        {
            if (result?.success != true || result.result is null)
                return new List<T>();
            var json = JsonSerializer.Serialize(result.result);
            return JsonSerializer.Deserialize<List<T>>(json, _jsonOpts) ?? new List<T>();
        }
    }
}
