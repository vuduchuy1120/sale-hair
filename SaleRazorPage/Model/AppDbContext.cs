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
        public DbSet<CategoryThickness> CategoryThickness { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<GridColor> GridColors { get; set; }
        public DbSet<GridSize> GridSizes { get; set; }
        public DbSet<Length> Lengths { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SetHairRequest> HairRequests { get; set; }
        public DbSet<SubTypeHair> SubTypeHairs { get; set; }
        public DbSet<Thickness> Thickness { get; set; }
        public DbSet<Thorne> Thornes { get; set; }
        public DbSet<TypeHair> TypeHairs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<Color>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<CategoryThickness>()
                .HasKey(ct => new { ct.CategoryId, ct.ThicknessId });
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<GridColor>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<GridSize>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<Length>()
                    .HasIndex(c => c.Id);
            modelBuilder.Entity<Order>()
                .HasIndex(c => c.Id);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.SetHairRequestId, od.GridColorId, od.ThorneId, od.LengthId, od.GridSizeId, od.ThicknessId });

            modelBuilder.Entity<SetHairRequest>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<Thickness>()
                .HasIndex(c => c.Id);
            modelBuilder.Entity<Thorne>()
                .HasIndex(c => c.Id);

            modelBuilder.Entity<SubTypeHair>()
                .HasKey(c => new { c.ColorId, c.CategoryId, c.TypeHairId, c.SubTypeName});

            modelBuilder.Entity<TypeHair>()
                .HasIndex(c => c.Id);
            
        }

    }

}
