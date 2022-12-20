using System.ComponentModel.DataAnnotations;

namespace LivrosApi.Data.CategoriaDto
{
    public class CreateCategoriaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
    }
}
