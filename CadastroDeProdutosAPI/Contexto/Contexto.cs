using CadastroDeProdutosAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace CadastroDeProdutosAPI.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options) => Database.EnsureCreated();
        
        public DbSet<Categoria> Categoria { get; set; }
    }
} 
