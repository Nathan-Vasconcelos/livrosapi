using LivrosApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LivrosApi.Data.CategoriaDto
{
    public class ReadCategoriaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
