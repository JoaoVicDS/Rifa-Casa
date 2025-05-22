using Microsoft.EntityFrameworkCore;
using RifaCasa.Data;
using RifaCasa.ViewModels;

namespace RifaCasa.Services.Raffle
{
    public class RaffleService(AppDbContext context) : IRaffleService
    {
        private readonly AppDbContext _context = context;

        public IndexModel GetRaffles(int pageSize, int pageNumber = 1)
        {
            var totalRaffles = _context.Raffles.Count(); // Total de rifas no db usando Count
            var totalPages = (int)Math.Ceiling((double)totalRaffles / pageSize); // cálcula o total de páginas

            // Obtém o total de rifas
            var raffles = _context.Raffles
                .OrderBy(r => r.Number)
                .Include(r => r.Buyer) // Inclui a entidade Buyer para obter os dados do comprador
                .Select(r => new RaffleViewModel // Seleciona os dados necessários para a view
                {
                    Id = r.Id,
                    Number = r.Number,
                    Available = r.Available,
                    BuyerPhone = r.BuyerPhone, // Acessa diretamente o telefone do comprador
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

        public IndexModel GetRafflesByPhone(int pageSize, string buyerPhone)
        {
            var totalRaffles = _context.Raffles // Total de rifas do comprador
                .Count(r => r.BuyerPhone == buyerPhone);
                
            var totalPages = (int)Math.Ceiling((double)totalRaffles / pageSize); // cálcula o total de páginas

            var buyersRaffles = _context.Raffles
                .Where(r => r.BuyerPhone == buyerPhone)
                .OrderBy(r => r.Number)
                .Include(r => r.Buyer) // Inclui a entidade Buyer para obter os dados do comprador
                .Select(r => new RaffleViewModel
                {
                    Id = r.Id,
                    Number = r.Number,
                    Available = r.Available,
                    BuyerPhone = r.BuyerPhone, // Acessa diretamente o telefone do comprador
                    BuyerName = r.Buyer != null ? r.Buyer.Name : null // Verifica se o comprador é nulo antes de acessar a propriedade Name
                })
                .ToList(); // Converte para lista

            return new IndexModel // Retorna o modelo com as rifas
            {
                Raffles = buyersRaffles,
                PageCurrent = 1, // Sempre começa na primeira página
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public void UpdateRaffle(int id, string buyerPhone)
        {
            var raffle = _context.Raffles.Find(id); // Busca a rifa pelo id

            if(raffle != null)
            {
                raffle.BuyerPhone = buyerPhone; // Atualiza o telefone do comprador
                raffle.Available = false; // Atualiza a disponibilidade da rifa

                _context.SaveChanges(); // Salva as alterações no banco de dados
            }
        }
    }
}
