using Microsoft.EntityFrameworkCore;

namespace SaleRazorPage.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ColorRequest> ColorRequests { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SetHairRequest> HairRequests { get; set; }
        public DbSet<SubTypeHair> SubTypeHairs { get; set; }
        public DbSet<TypeHair> TypeHairs { get; set; }
        public DbSet<SubTypeColor> SubTypeColors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<Color>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<ColorRequest>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<SetHairRequest>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<SubTypeHair>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<TypeHair>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<SubTypeColor>()
                .HasKey(sc => new { sc.SubTypeHairId, sc.ColorId });
            // forign key
            modelBuilder.Entity<SubTypeColor>()
                .HasOne(sc => sc.SubTypeHair)
                .WithMany(s => s.SubTypeColors)
                .HasForeignKey(sc => sc.SubTypeHairId);
            modelBuilder.Entity<SubTypeColor>()
                .HasOne(sc => sc.Color)
                .WithMany(c => c.SubTypeColors)
                .HasForeignKey(sc => sc.ColorId);
        }

    }

}
