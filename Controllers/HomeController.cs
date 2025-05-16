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

    public IActionResult Index(int page = 1)
    {
        int pageSize = 100;

        var TotalRaffles = _context.Raffles.Count(); // Total de rifas no db usando Count
        var TotalPages = (int)Math.Ceiling((double)TotalRaffles / pageSize); // cálcula o total de páginas

        var raffle = _context.Raffles
            .OrderBy(r => r.Number)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(r => new RaffleViewModel
            {
                Id = r.Id,
                Number = r.Number,
                Available = r.Available
            })
            .ToList();

        var model = new IndexViewModel
        {
            Raffles = raffle,
            PageCurrent = page,
            TotalPages = TotalPages
        };

        return View(model);
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
