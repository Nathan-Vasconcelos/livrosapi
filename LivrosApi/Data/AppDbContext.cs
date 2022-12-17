using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Livro>()
                .HasOne(livro => livro.Autor)
                .WithMany(autor => autor.Livros)
                .HasForeignKey(livro => livro.AutorId);
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }
}
