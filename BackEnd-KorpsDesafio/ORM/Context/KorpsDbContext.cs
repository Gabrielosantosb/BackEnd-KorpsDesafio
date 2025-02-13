using BackEnd_KorpsDesafio.ORM.Entity.Category;
using BackEnd_KorpsDesafio.ORM.Entity.Product;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_KorpsDesafio.ORM.Context
{
    public class KorpsDbContext : DbContext
    {
        public KorpsDbContext(DbContextOptions<KorpsDbContext> options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ProductModel>()
                .HasKey(p => p.ProductId); 
        }
    }
}
