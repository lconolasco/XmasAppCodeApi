using Microsoft.EntityFrameworkCore;
using XmasAppCodeApi.Models;

namespace XmasAppCodeApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //Mapeamento ORM das classes com as entidades no DB
        //Mapeamento da classe Prodotto com a entidade Prodotti. 
        public DbSet<Prodotto> Prodotti { get; set; }
    }
}
