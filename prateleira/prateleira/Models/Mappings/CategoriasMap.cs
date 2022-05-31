using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Prateleira.Models.Mappings
{
    public class CategoriasMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("tbcategoria");

            builder.HasKey(e => e.IdCategoria)
                .HasName("idCategoria");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.NomeCategoria)
                .HasColumnName("categoria")
                .IsRequired();

            builder.Property(e => e.Situacao)
                .HasColumnName("situacao")
                .IsRequired();

            builder.Property(e => e.DataCriacao)
                .HasColumnName("dataCriacao");

        }
    }
}
