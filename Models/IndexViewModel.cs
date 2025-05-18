namespace Rifa_Casa.Models
{
    public class IndexViewModel
    {
        public required List<RaffleViewModel> Raffles { get; set; }
        public int PageCurrent { get; set; }
        public int TotalPages { get; set; }
    }
}
