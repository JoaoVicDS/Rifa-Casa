namespace RifaCasa.Shared.ViewModels
{
    public class IndexModel
    {
        public required List<RaffleViewModel> Raffles { get; set; }
        public int PageCurrent { get; set; }
        public int PageSize { get; set; } // Quantidade de Rifas Por Página
        public int TotalPages { get; set; }
    }
}
