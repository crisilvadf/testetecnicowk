using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Prateleira.Models.Mappings
{
    public class ProdutosMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tbproduto");

            builder.HasKey(e => e.IdProduto)
                .HasName("idProduto");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.NomeProduto)
                .HasColumnName("produto")
                .IsRequired();

            builder.Property(e => e.Situacao)
                .HasColumnName("situacao")
                .IsRequired();

            builder.Property(e => e.DataCriacao)
                .HasColumnName("dataCriacao");

        }
    }
}
