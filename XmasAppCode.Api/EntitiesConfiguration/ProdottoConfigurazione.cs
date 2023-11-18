using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XmasAppCode.Api.Entities;

namespace XmasAppCode.Api.EntitiesConfiguration
{
    public class ProdottoConfigurazione : IEntityTypeConfiguration<Prodotto>
    {
        //Sovvrascrive le convenzioni del EF Core
        public void Configure(EntityTypeBuilder<Prodotto> builder)
        {
            
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Descrizione).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Barcode).HasMaxLength(256);
            builder.Property(p => p.ImageUrl).HasMaxLength(1024);
            builder.Property(p => p.Prezzo).IsRequired().HasPrecision(10,2);
            builder.Property(p => p.PesoLordo).IsRequired().HasPrecision(10,2);

            //Inserisce un prodotto se non è presente nella entità del Database
            builder.HasData(
                new Prodotto
                {
                    Id = 1,
                    Nome = "Panetone Tipo Milano 250g",
                    Descrizione = "Panettone Tipo Milano gr 350 Flamigni",
                    Barcode = "8002731039405",
                    Prezzo = 11.90M,
                    PesoLordo = 0.451M,
                    CategoriaId=1
                });
        }

        

    }
}
