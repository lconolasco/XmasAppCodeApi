using Microsoft.EntityFrameworkCore;
using XmasAppCode.Api.Entities;
using XmasAppCode.Api.EntitiesConfiguration;

namespace XmasAppCode.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Mappeamento della classe con l'entità del DB. 
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProdottoConfigurazione());
            builder.ApplyConfiguration(new CategoriaConfigurazione());

        }
    }
}
