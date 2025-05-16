using System.ComponentModel.DataAnnotations;

namespace Rifa_Casa.Models
{
    public class Raffle
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número da Rifa é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O número da rifa deve ser maior que zero.")]
        public int Number { get; set; }
        public bool Available { get; set; } = true;

        [Phone(ErrorMessage = "Telefone do comprador inválido.")]
        public string? buyerPhone { get; set; }
        public Buyer? buyer { get; set; }
    }
}
