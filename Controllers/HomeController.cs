using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rifa_Casa.Data;
using Rifa_Casa.Models;

namespace Rifa_Casa.Controllers;

// Utilizando o construtor primário
public class HomeController(ILogger<HomeController> logger, AppDbContext context) : Controller 
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly AppDbContext _context = context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index(int page = 1)
    {
        int pageSize = 100;

        var TotalRaffles = _context.Raffles.Count();
        var TotalPages = (int)Math.Ceiling((double)TotalRaffles / pageSize);

        var raffle = _context.Raffles
            .Where(r => r.Available) // Filtra as rifas disponíveis
            .OrderBy(r => r.Number) // Ordena as rifas pelo número
            .Select(r => new RaffleViewModel // Seleciona os dados necessários para a view
            {
                Id = r.Id,
                Number = r.Number,
                Available = r.Available
            })
            .ToList(); // Converte para lista

        var model = new IndexModel // Cria o modelo para a view
        {
            Raffles = raffle,
            PageCurrent = 1,
            PageSize = pageSize,
            TotalPages = TotalPages
        };

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
