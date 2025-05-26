using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RifaCasa.Data.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Telefone do Comprador é obrigatório")]
        public required string BuyerPhone { get; set; }

        [ForeignKey(nameof(BuyerPhone))]
        public Buyer? Buyer { get; set; }

        public required string PaymentType { get; set; }
        public required int Installments { get; set; } = 1;
        public required decimal TotalValue { get; set; }
        public required decimal FeeAmount { get; set; }
        public required decimal Fee {  get; set; }
        public required decimal NetReceivedAmount { get; set; }
        
        public required DateTime CreateAt { get; set; } = DateTime.Now;
        
        public ICollection<Raffle> Raffles { get; set; } = new List<Raffle>();
    }
}
