using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RifaCasa.Services.Raffle;
using RifaCasa.Shared.ViewModels;

namespace RifaCasa.App.Controllers
{

    // Utilizando o construtor primário
    public class HomeController(ILogger<HomeController> logger, IRaffleService raffleService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IRaffleService _raffleService = raffleService;

        public IActionResult Index()
        {
            int pageSize = 20; // Quantidade de Rifas Por Página
            var model = _raffleService.GetRafflesAsync(pageSize); // Chama o serviço para obter as rifas
            return View(model); // Retorna a view com o modelo
        }

        public IActionResult Winners()
        {
            return View();
        }

        public IActionResult MyRaffles()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}