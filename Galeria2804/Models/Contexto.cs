using Microsoft.EntityFrameworkCore;

namespace Galeria2804.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { }

        public DbSet<Imagem>? Imagens { get; set; }
    }
}
