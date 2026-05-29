using Microsoft.EntityFrameworkCore;

namespace GraphQLProductApp.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext()
    {
    }

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<Manufacturers> Manufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the foreign key relationship
        modelBuilder.Entity<Manufacturers>()
            .HasOne(m => m.Components)
            .WithMany(c => c.Manufacturers)
            .HasForeignKey(m => m.ComponentsId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}