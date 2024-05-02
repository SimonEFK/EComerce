namespace HardwareStore.App.Data
{
    using HardwareStore.App.Data.Models;
    using HardwareStore.App.Data.SeedData;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CartProduct>(x => x.HasKey(key => new { key.CartId, key.ProductId }));
            builder.Entity<CartProduct>(x => x.Property(y => y.Amount).HasDefaultValue(1));

            builder.Entity<Specification>(x => x.Property(y => y.Filter).HasDefaultValue(false));

            builder.Entity<ProductReview>(x => x.Property(y => y.IsApproved).HasDefaultValue(false));


            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Specification> Specifications { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<PartNumber> PartNumbers { get; set; }

        public DbSet<SpecificationValue> SpecificationValues { get; set; }

        public DbSet<ProductSpecificationValues> ProductSpecificationValues { get; set; }

        public DbSet<ProductReview> ProductReviews { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartProduct> CartProducts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrdersProducts { get; set; }

    }
}