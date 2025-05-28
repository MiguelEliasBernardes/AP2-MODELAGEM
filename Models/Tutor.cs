using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Models
{
    public class Tutor
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Telefone { get; set; }

        public string Email { get; set; }

        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}