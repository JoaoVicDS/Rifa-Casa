using Microsoft.EntityFrameworkCore;
using RifaCasa.Data.EFCore;
using RifaCasa.Shared.ViewModels;

namespace RifaCasa.Services.Raffle
{
    public class RaffleService(AppDbContext context) : IRaffleService
    {
        private readonly AppDbContext _context = context;

        public async Task<IndexModel> GetRafflesAsync(int pageSize, int pageNumber = 1)
        {
            var totalRaffles = await _context.Raffles.CountAsync(); // Total de Rifas na tabela
            var totalPages = (int)Math.Ceiling((double)totalRaffles / pageSize); // Total de páginas

            var raffles = await _context.Raffles
                .OrderBy(r => r.Number)
                .Include(r => r.Buyer) // Inclui o comprador na consulta
                .Select(r => new RaffleViewModel // Cria uma nova instância de RaffleViewModel para cada rifa
                {
                    Id = r.Id,
                    Number = r.Number,
                    Available = r.Available,
                    BuyerPhone = r.BuyerPhone,
                    BuyerName = r.Buyer == null ? null : r.Buyer.Name // Verifica se o comprador é nulo
                })
                .ToListAsync(); // Obtém todas as rifas da tabela

            return new IndexModel
            {
                Raffles = raffles,
                PageCurrent = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public async Task<IndexModel> GetRafflesByPhoneAsync(int pageSize, string buyerPhone)
        {
            var totalRaffles = await _context.Raffles
                .CountAsync(r => r.BuyerPhone == buyerPhone); // Total de Rifas do Comprador

            var totalPages = (int)Math.Ceiling((double)totalRaffles / pageSize); // Total de páginas

            var buyersRaffles = await _context.Raffles // Obtém todas as rifas do comprador
                .Where(r => r.BuyerPhone == buyerPhone)
                .OrderBy(r => r.Number)
                .Include(r => r.Buyer)
                .Select(r => new RaffleViewModel
                {
                    Id = r.Id,
                    Number = r.Number,
                    Available = r.Available,
                    BuyerPhone = r.BuyerPhone,
                    BuyerName = r.Buyer != null ? r.Buyer.Name : null // Verifica se o comprador é nulo
                })
                .ToListAsync();

            return new IndexModel
            {
                Raffles = buyersRaffles,
                PageCurrent = 1,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public async Task UpdateRafflesAsync(List<int> rafflesIds, string buyerPhone)
        {
            foreach (var id in rafflesIds)
            {
                var raffle = await _context.Raffles.FindAsync(id); // Obtém a rifa pelo ID
                if (raffle != null) // Verifica se a rifa existe
                {
                    if(raffle.Available == true) // Verifica se a rifa está disponível
                    {
                        // Atualiza os dados da rifa
                        raffle.BuyerPhone = buyerPhone;
                        raffle.Available = false;
                    }
                }
            }
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
        }

        public async Task<List<int>> CheckRafflesIsAvailableAsync(List<int> rafflesIds)
        {
            var rafflesNotAvailable = new List<int> { id = 1 }; // Inicializa a lista de rifas não disponíveis
            foreach (var id in rafflesIds)
            {
                var raffle = await _context.Raffles.FindAsync(id); // Obtém a rifa pelo ID
                if(raffle == null || !raffle.Available)
                {
                    rafflesNotAvailable.Add(id); // Rifa não encontrada ou não disponível
                }
            }
            return rafflesNotAvailable; // Retorna a lista de rifas não disponíveis
        }
    }
}
