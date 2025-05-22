using RifaCasa.Shared.ViewModels;

namespace RifaCasa.Services.Raffle
{
    public interface IRaffleService
    {
        Task<IndexModel> GetRafflesAsync(int pageSize, int pageNumber = 1);
        Task<IndexModel> GetRafflesByPhoneAsync(int pageSize, string BuyerPhone);
        Task UpdateRafflesAsync(List<int> rafflesIds, string buyerPhone);
    }
}
