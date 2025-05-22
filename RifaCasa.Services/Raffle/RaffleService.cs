using Microsoft.EntityFrameworkCore;
using RifaCasa.Data;
using RifaCasa.ViewModels;

namespace RifaCasa.Services.Raffle
{
    public class RaffleService : IRaffleService
    {
        private readonly AppDbContext _context;

        public RaffleService(AppDbContext context) => _context = context;
        public IndexModel GetRaffles(int pageSize, int pageNumber = 1)
        {
            
            var totalRaffles = _context.Raffles.Count(); // Total de rifas no db usando Count
            var totalPages = (int)Math.Ceiling((double)totalRaffles / pageSize); // cálcula o total de páginas

            // Ob
            // tém o total de rifas
            var raffles = _context.Raffles
                .OrderBy(r => r.Number)
                .Include(r => r.Buyer) // Inclui a entidade Buyer para obter os dados do comprador
                .Select(r => new RaffleViewModel // Seleciona os dados necessários para a view
                {
                    Id = r.Id,
                    Number = r.Number,
                    Available = r.Available,
                    BuyerPhone = r.Buyer == null ? null : r.Buyer.Phone,  // Verifica se o comprador é nulo antes de acessar a propriedade Phone
                    BuyerName = r.Buyer == null ? null : r.Buyer.Name // Verifica se o comprador é nulo antes de acessar a propriedade Name
                }) 
                .ToList(); // Converte para lista

            return new IndexModel // Retorna o modelo com as rifas
            {
                Raffles = raffles,
                PageCurrent = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
            
        }
    }
}
