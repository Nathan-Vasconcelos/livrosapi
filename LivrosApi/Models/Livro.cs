using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LivrosApi.Models
{
    public class Livro
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo título é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo título deve ter no máximo 100 caracteres")]
        public string Titulo { get; set; }
        [JsonIgnore]
        public virtual Autor Autor { get; set; }
        public int AutorId { get; set; }
    }
}
