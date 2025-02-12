using BackEnd_KorpsDesafio.ORM.Entity.Product;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_KorpsDesafio.ORM.Context
{
    public class KorpsDbContext : DbContext
    {       
        public KorpsDbContext(DbContextOptions<KorpsDbContext> options) : base(options) { }

        public DbSet<ProductModel> Product { get; set; }
    }
}
