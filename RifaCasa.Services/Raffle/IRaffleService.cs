using RifaCasa.ViewModels;

namespace RifaCasa.Services.Raffle
{
    public interface IRaffleService
    {
        IndexModel GetRaffles(int pageSize, int pageNumber = 1);
    }
}
