using System.ComponentModel.DataAnnotations;

namespace Rifa_Casa.Models
{
    public class Buyer
    {
        [Key]
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "Telefone inválido.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        public ICollection<Raffle> Raffles { get; set; } = new List<Raffle>();
    }
}
