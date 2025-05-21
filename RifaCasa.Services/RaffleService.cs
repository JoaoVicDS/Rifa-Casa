

namespace RifaCasa.Services
{
    public class RaffleService
    {
        private readonly AppContext _context;

        public RaffleService(AppContext context)
        {
            _context = context;
        }
        public Array GetRaffles()
            {
            return context.Raffles
                .orderBy(r => r.Number)
                .Select(r => r.Id, r => r.Number, r => r.Available, r => r.BuyerPhone) // Caso BuyerPhone seja diferente de null, pegar os dados do Buyer também.
                .ToList();
            }
    }
}
