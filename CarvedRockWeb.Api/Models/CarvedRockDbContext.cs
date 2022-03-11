using Microsoft.EntityFrameworkCore;

namespace CarvedRockWeb.Api.Models
{
    public class CarvedRockDbContext : DbContext
    {
        public CarvedRockDbContext(DbContextOptions<CarvedRockDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new Seeder(modelBuilder).Seed();
        }

        public DbSet<Product> Products { get; set; }
    }
}
