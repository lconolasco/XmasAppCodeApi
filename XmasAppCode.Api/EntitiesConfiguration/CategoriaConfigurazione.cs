using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XmasAppCode.Api.Entities;

namespace XmasAppCode.Api.EntitiesConfiguration
{
    public class CategoriaConfigurazione : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(250);

            builder.HasData(
                 new Categoria
                 {
                     Id = 1,
                     Nome = "Panetone e afine"
                 },
                 new Categoria 
                 { 
                     Id = 2,
                     Nome="Vini Spumanti"
                 },
                 new Categoria
                 {
                     Id=3,
                     Nome="Champagne"
                 },
                 new Categoria
                 {
                     Id=4,
                     Nome="Dolci"
                 }
                 );
        }
    }
}
