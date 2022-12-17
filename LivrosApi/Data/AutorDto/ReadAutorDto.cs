using LivrosApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LivrosApi.Data.AutorDto
{
    public class ReadAutorDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
