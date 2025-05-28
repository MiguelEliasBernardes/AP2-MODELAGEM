using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VeterinariaAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Especie { get; set; }

        public string Raca { get; set; }

        [Required]
        public int TutorId { get; set; }

        [JsonIgnore]
        public Tutor? Tutor { get; set; }
    }
}