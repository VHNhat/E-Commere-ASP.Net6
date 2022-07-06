using E_Commerce.Extension;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace E_Commerce.DataAccess
{
    public class Context : DbContext
    {
        public Context()
        {
        }
      
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;user=root;password=1234;database=ECommerce;port=3306");
            }
        }
        
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountValue> DiscountValues { get; set; }
        public DbSet<OptionRole> OptionRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Size> Product_Sizes { get; set; }
        public DbSet<Product_Store> Product_Stores { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Account
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account")
                    .HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Created_date)
                    .IsRequired();

                entity.Property(e => e.Modified_date)
                    .IsRequired();

                entity.HasIndex(e => e.Username)
                    .IsUnique();
                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode(false);

            });
            #endregion

            // Seeding data
            modelBuilder.Seed();
        }
    }
}
