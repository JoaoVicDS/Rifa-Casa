using RifaCasa.Data.EFCore;
using RifaCasa.Shared.ViewModels;

namespace RifaCasa.Services.Buyer
{
    public class BuyerService(AppDbContext context) : IBuyerService
    {
        public readonly AppDbContext _context = context;

        public bool CheckExistingBuyer(string phone)
        {
            return _context.Buyers.Any(b => b.Phone == phone);
        }

        public async Task<bool> AddBuyerAsync(RafflePurchaseViewModel buyer)
        {
            if (CheckExistingBuyer(buyer.Phone))
            {
                return false; // O comprador já existe
            }
            var newBuyer = new Data.Models.Buyer // Assumindo que Buyer é uma classe de modelo de dados
            {
                Phone = buyer.Phone,
                Name = buyer.Name,
                Email = buyer.Email,
            };

            _context.Buyers.Add(newBuyer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
