using System.ComponentModel.DataAnnotations;

namespace LivrosApi.Data.LivroDto
{
    public class CreateLivroDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo título deve ter no máximo 100 caracteres")]
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public int CategoriaId { get; set; }
    }
}
