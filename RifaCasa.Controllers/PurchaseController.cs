using RifaCasa.Services.Raffle;
using RifaCasa.Services.Buyer;
using Microsoft.AspNetCore.Mvc;

namespace RifaCasa.Controllers
{
    public class PurchaseController(IRaffleService raffleService, IBuyerService buyerService) : Controller
    {
        private readonly IRaffleService _raffleService = raffleService;
        private readonly IBuyerService _buyerService = buyerService;

        [HttpPost]
        public async Task BuyRafflesAsync()
        {

        }
    }
}
