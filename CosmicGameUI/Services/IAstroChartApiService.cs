using CosmicGame.Shared.Models.ViewModel;

namespace CosmicGameUI.Services
{
    public interface IAstroChartApiService
    {
        Task<List<TraditionalChartCell>> GetTraditionalChartAsync(int chartHolderId);
        Task<List<BaskiChartRow>> GetBaskiChartAsync(int chartHolderId);
        Task<List<VimsoChartCell>> GetVimsoDissaiAsync(int chartHolderId);
        Task<List<VimsoChartCell>> GetVimsoPuthiAsync(int chartHolderId, int dissaiGp);
        Task<List<VimsoChartCell>> GetVimsoAntraAsync(int chartHolderId, int dissaiGp, int puthiGp);
        Task<List<VimsoChartCell>> GetVimsoPranaAsync(int chartHolderId, int dissaiGp, int puthiGp, int antraGp);
    }
}
