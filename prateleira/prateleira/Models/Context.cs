using Microsoft.EntityFrameworkCore;
using Prateleira.Models.Mappings;

namespace Prateleira.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<Categoria> TbCategorias { get; set; }
        public DbSet<Produto> TbProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriasMap());
            modelBuilder.ApplyConfiguration(new ProdutosMap());
        }
    }
}
