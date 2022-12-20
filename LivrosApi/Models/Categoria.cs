using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LivrosApi.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual List<Livro> Livros { get; set; }
    }
}
