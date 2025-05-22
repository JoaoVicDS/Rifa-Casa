using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RifaCasa.Models
{
    public class Raffle
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número da Rifa é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O número da rifa deve ser maior que zero.")]
        public required int Number { get; set; }
        public bool Available { get; set; } = true;

        [Phone(ErrorMessage = "Telefone do comprador inválido.")]
        public string? BuyerPhone { get; set; }
        [ForeignKey("BuyerPhone")]
        public Buyer? Buyer { get; set; }
    }
}
