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
        [Route("/StartPurchase")]
        public async Task<IActionResult> StartPurchaseAsync(RafflePurchaseViewModel model)
        {
            var rafflesAvailable = await _raffleService.CheckRafflesIsAvailableAsync(model.RifaIds);
            if (rafflesAvailable.Count > 0)
            {
                return BadRequest($"Rifas não disponíveis: {string.Join(", ", rafflesAvailable)}");
            }

            if (_buyerService.CheckExistingBuyer(model.Phone))
            {
                return BadRequest("Telefone já cadastrado");
            }
            var buyer = await _buyerService.AddBuyerAsync(model);
            if (!buyer)
            {
                return BadRequest("Erro no cadastro do comprador");
            }
            await _raffleService.UpdateRafflesAsync(model.RifaIds, model.Phone);

            return RedirectToAction("/API/MercadoPago"); // Redireciona para a API do mercado pago
        }
    }
}
