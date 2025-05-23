using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RifaCasa.Data.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Phone")]
        [Required(ErrorMessage = "Telefone do Comprador é obrigatório")]
        public required string BuyerPhone { get; set; }
        public Buyer? Buyer { get; set; }
    }
}
