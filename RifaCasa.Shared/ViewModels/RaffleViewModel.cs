namespace RifaCasa.ViewModels
{
    public class RaffleViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool Available { get; set; }
        public bool Selected { get; set; }
        public string? BuyerPhone { get; set; }
        public string? BuyerName { get; set; }
    }
}
