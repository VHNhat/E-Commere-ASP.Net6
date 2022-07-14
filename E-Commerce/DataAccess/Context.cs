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

        public DbSet<Option_Role> Option_Roles { get; set; }
        public DbSet<Photo> Photos { get; set; }
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
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCart_Product> ShoppingCart_Products { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherType> VoucherTypes { get; set; }
        public DbSet<ReviewProduct> ReviewProducts { get; set; }


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

                entity.HasIndex(e => e.Email)
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
                    .HasMaxLength(100)
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

                entity.HasOne<DiscountValue>(o => o.DiscountValue)
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

                entity.HasIndex(e => e.Phone)
                    .IsUnique();
                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsRequired();

                entity.Property(e => e.AccountId)
                    .IsRequired(false);

                entity.HasOne<Account>(o => o.Account)
                    .WithOne(m => m.User)
                    .HasForeignKey<Account>(fk => fk.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
            #endregion
            #region Banner
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("Banner")
                    .HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Photo)
                    .IsRequired();

            });
            #endregion
            #region Voucher
            modelBuilder.Entity<Voucher>(entity => 
            {
                entity.ToTable("Voucher")
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

                entity.Property(e => e.TypeId)
                    .IsRequired(false);

                entity.HasOne<VoucherType>(o => o.Type)
                    .WithMany(m => m.Vouchers)
                    .HasForeignKey(fk => fk.TypeId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
            #endregion
            #region VoucherType
            modelBuilder.Entity<VoucherType>(entity => 
            {
                entity.ToTable("VoucherType")
                    .HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();
                
                entity.Property(e => e.Photo)
                    .IsRequired();

            });
            #endregion
            #region ReviewProduct
            modelBuilder.Entity<ReviewProduct>(entity => 
            {
                entity.ToTable("ReviewProduct")
                    .HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Like)
                    .HasDefaultValue(0);

                entity.Property(e => e.Dislike)
                    .HasDefaultValue(0);

                entity.HasOne<Product>(o => o.Product)
                    .WithMany(m => m.Reviews)
                    .HasForeignKey(o => o.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion
            #region Notification
            modelBuilder.Entity<Notification>(entity => 
            {
                entity.ToTable("Notification")
                    .HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Content)
                    .IsRequired();

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);
            });
            #endregion
            #region Customer
            modelBuilder.Entity<Customer>(entity => 
            {
                entity.ToTable("Customer")
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
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasIndex(e => e.Phone)
                    .IsUnique();
                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode();

                entity.Property(e => e.Avata)
                    .HasMaxLength(255);

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .IsUnicode();

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode();

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode();

                entity.Property(e => e.Gender)
                    .IsRequired();
            });
            #endregion
            #region Order
            modelBuilder.Entity<Order>(entity => 
            {
                entity.ToTable("Order")
                    .HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.CustomerId)
                    .IsRequired();

                entity.Property(e => e.Validated)
                    .HasDefaultValue(0);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasDefaultValue("Đang chờ thanh toán")
                    .IsUnicode();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .IsUnicode();

                entity.Property(e => e.PayBy)
                    .IsRequired()
                    .IsUnicode();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .IsUnicode();

                entity.Property(e => e.Time)
                    .HasMaxLength(100)
                    .HasDefaultValue("15-20 phút")
                    .IsUnicode();

                entity.Property(e => e.Note)
                    .IsUnicode();

                entity.Property(e => e.CustomerId)
                    .IsRequired(false);

                entity.HasOne<Customer>(o => o.Customer)
                    .WithMany(m => m.Orders)
                    .HasForeignKey(fk => fk.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
            #endregion
            #region ShoppingCart
            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("ShoppingCart").
                    HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired();

                entity.Property(e => e.ProductQuantity)
                    .IsRequired()
                    .HasDefaultValue(0);

                entity.Property(e => e.CustomerId)
                    .IsRequired(false);

                entity.HasOne<Customer>(o => o.Customer)
                    .WithMany(m => m.ShoppingCarts)
                    .HasForeignKey(fk => fk.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
            #endregion
            #region ShoppingCart_Product
            modelBuilder.Entity<ShoppingCart_Product>(entity =>
            {
                entity.ToTable("ShoppingCart_Product")
                    .HasKey(e => new { e.ShoppingCartId, e.ProductId });

                entity.Property(e => e.Count)
                    .HasDefaultValue(0);

                entity.Property(e => e.TilteSize)
                    .HasMaxLength(100)
                    .HasDefaultValue("Nhỏ")
                    .IsUnicode();

                entity.Property(e => e.CreatedDate)
                    .HasDefaultValue(DateTime.Now);

                entity.HasOne<ShoppingCart>(o => o.ShoppingCart)
                    .WithMany(m => m.ShoppingCart_Products)
                    .HasForeignKey(fk => fk.ShoppingCartId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Product>(o => o.Product)
                    .WithMany(m => m.ShoppingCart_Products)
                    .HasForeignKey(fk => fk.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion

            // Seeding data
            modelBuilder.Seed();
        }
    }
}
