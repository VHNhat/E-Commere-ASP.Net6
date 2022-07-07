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

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
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

                entity.HasIndex(e => e.Email)
                    .IsUnique();
                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired(false);

                entity.HasOne<Role>(o => o.Role)
                    .WithMany(m => m.Accounts)
                    .HasForeignKey(fk => fk.RoleId)
                    .OnDelete(DeleteBehavior.SetNull);
                    
            });
            #endregion
            #region Discount
            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Code)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Quantity)
                    .IsRequired();

                entity.Property(e => e.ExpiredAt)
                    .IsRequired();

                entity.HasOne<DiscountValue>(o => o.Value)
                    .WithMany(m => m.Discounts)
                    .HasForeignKey(fk => fk.ValueId)
                    .OnDelete(DeleteBehavior.Cascade);

            });
            #endregion
            #region DiscountValue
            modelBuilder.Entity<DiscountValue>(entity =>
            {
                entity.ToTable("DiscountValue")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Type)
                    .IsRequired();


            });
            #endregion
            #region OptionRole
            modelBuilder.Entity<OptionRole>(entity => 
            {
                entity.ToTable("OptionRole")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

            });
            #endregion
            #region Option_Role
            modelBuilder.Entity<Option_Role>(entity => 
            {
                entity.ToTable("Option_Role")
                    .HasKey(e => new { e.RoleId, e.OptionId});

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.HasOne<OptionRole>(o => o.Option)
                    .WithMany(m => m.Option_roles)
                    .HasForeignKey(fk => fk.OptionId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Role>(o => o.Role)
                    .WithMany(m => m.Option_roles)
                    .HasForeignKey(fk => fk.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);

            });
            #endregion
            #region Role
            modelBuilder.Entity<Role>(entity => 
            {
                entity.ToTable("Role")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();
            });
            #endregion
            #region Photo
            modelBuilder.Entity<Photo>(entity => 
            {
                entity.ToTable("Photo")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Url)
                    .IsRequired();
            });
            #endregion
            #region Product
            modelBuilder.Entity<Product>(entity => 
            {
                entity.ToTable("Product")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Decription)
                    .IsRequired();

                entity.Property(e => e.Price)
                    .IsRequired();

                entity.Property(e => e.Quantity)
                    .IsRequired();

                entity.Property(e => e.BrandId)
                    .IsRequired(false);

                entity.Property(e => e.TypeId)
                    .IsRequired(false);

                entity.HasOne<ProductBrand>(o => o.Brand)
                    .WithMany(m => m.Products)
                    .HasForeignKey(fk => fk.BrandId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne<ProductType>(o => o.Type)
                    .WithMany(m => m.Products)
                    .HasForeignKey(fk => fk.TypeId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
            #endregion
            #region ProductType
            modelBuilder.Entity<ProductType>(entity => 
            {
                entity.ToTable("ProductType")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .IsRequired();
            });
            #endregion
            #region ProductSize
            modelBuilder.Entity<ProductSize>(entity => 
            {
                entity.ToTable("ProductSize")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Value)
                    .IsRequired();
            });
            #endregion
            #region Product_Size
            modelBuilder.Entity<Product_Size>(entity => 
            {
                entity.ToTable("Product_Size")
                    .HasKey(e => new { e.SizeId, e.ProductId });

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.HasOne<Product>(o => o.Product)
                    .WithMany(m => m.Product_sizes)
                    .HasForeignKey(fk => fk.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<ProductSize>(o => o.Size)
                    .WithMany(m => m.Product_sizes)
                    .HasForeignKey(fk => fk.SizeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion
            #region Store
            modelBuilder.Entity<Store>(entity => 
            {
                entity.ToTable("Store")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Address)
                    .IsRequired();

                entity.Property(e => e.Map)
                    .IsRequired();

                entity.Property(e => e.Detail)
                    .IsRequired();
            });
            #endregion
            #region Product_Store
            modelBuilder.Entity<Product_Store>(entity => 
            {
                entity.ToTable("Product_Store")
                    .HasKey(e => new { e.StoreId, e.ProductId });

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.HasOne<Store>(o => o.Store)
                    .WithMany(m => m.Product_stores)
                    .HasForeignKey(fk => fk.StoreId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Product>(o => o.Product)
                    .WithMany(m => m.Product_stores)
                    .HasForeignKey(fk => fk.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion
            #region ProductBrand
            modelBuilder.Entity<ProductBrand>(entity => 
            {
                entity.ToTable("ProductBrand")
                    .HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .IsRequired();
            });
            #endregion
            #region User
            modelBuilder.Entity<User>(entity => 
            {
                entity.ToTable("User")
                    .HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Gender)
                    .IsRequired();

                entity.Property(e => e.Phone)
                    .IsRequired();

                entity.Property(e => e.AccountId)
                    .IsRequired(false);

                entity.HasOne<Account>(o => o.Account)
                    .WithOne(m => m.User)
                    .HasForeignKey<Account>(fk => fk.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
            #endregion


            // Seeding data
            /*modelBuilder.Seed();*/
        }
    }
}
