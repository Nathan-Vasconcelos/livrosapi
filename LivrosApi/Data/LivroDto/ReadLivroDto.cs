using LivrosApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LivrosApi.Data.LivroDto
{
    public class ReadLivroDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo título é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo título deve ter no máximo 100 caracteres")]
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
        public int AutorId { get; set; }
    }
}
