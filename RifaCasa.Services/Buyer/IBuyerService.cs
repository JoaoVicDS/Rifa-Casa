using RifaCasa.Shared.ViewModels;

namespace RifaCasa.Services.Buyer
{
    public interface IBuyerService
    {
        bool CheckExistingBuyer(string phone);
        Task<bool> AddBuyerAsync(RafflePurchaseViewModel buyer);
    }
}
