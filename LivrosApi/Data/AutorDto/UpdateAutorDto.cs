using System.ComponentModel.DataAnnotations;

namespace LivrosApi.Data.AutorDto
{
    public class UpdateAutorDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
    }
}
