using RifaCasa.Services.Raffle;
using RifaCasa.Services.Buyer;
using Microsoft.AspNetCore.Mvc;
using RifaCasa.Shared.ViewModels;

namespace RifaCasa.Controllers
{
    public class PurchaseController(IRaffleService raffleService, IBuyerService buyerService) : Controller
    {
        private readonly IRaffleService _raffleService = raffleService;
        private readonly IBuyerService _buyerService = buyerService;

        [HttpPost]
        [Route("/BuyRaffles")]
        public async Task<IActionResult> StartPurchase(RafflePurchaseViewModel model)
        {
            var rafflesAvailable = await _raffleService.CheckRafflesIsAvailableAsync(model.RifaIds);
            if(rafflesAvailable.Count > 0)
            {
                return BadRequest($"Rifas não disponíveis: {rafflesAvailable.Id}");
            }
            var buyer = await _buyerService.AddBuyerAsync(model);
            if(!buyer)
            {
                return BadRequest("Erro no cadastro do Comprador");
            }

            await _raffleService.UpdateRafflesAsync(model.RifaIds, model.Phone);

            return RedirectToAction("/Home/Index?success=true"); // Redireciona para a página inicial após a compra
        }
    }
}
