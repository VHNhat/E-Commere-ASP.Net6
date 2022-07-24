using E_Commerce.Extension;
using E_Commerce.Models;
using E_Commerce.Utility.Status;
using E_Commerce.Utility.Type;
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
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountType> DiscountTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<OptionRole> OptionRoles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductVariance> ProductVariances { get; set; }
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<ReviewProduct> ReviewProducts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<SizeCategory> SizeCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherType> VoucherTypes { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Wishlist_Product> Wishlist_Products { get; set; }



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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.HasIndex(e => e.Username)
                    .IsUnique(true);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.HasIndex(e => e.Email)
                    .IsUnique(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired(false);

                entity.HasOne<Role>(o => o.Role)
                    .WithMany(m => m.Accounts)
                    .HasForeignKey(fk => fk.RoleId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(e => e.UserId)
                    .IsRequired(false);

                entity.HasOne<User>(o => o.User)
                    .WithOne(o => o.Account)
                    .HasForeignKey<User>(fk => fk.AccountId)
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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Title)
                    .IsRequired(true);

                entity.Property(e => e.Description)
                    .IsRequired(true);

                entity.Property(e => e.Photo)
                    .IsRequired(true);

                entity.Property(e => e.Status)
                    .IsRequired();
                    /*.HasDefaultValue(BannerStatus.ACTIVE.ToString())*/

            });
            #endregion
            #region Cart
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart").
                    HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Quantity)
                    .IsRequired(true);

                entity.Property(e => e.Amount)
                    .IsRequired(true);

                entity.Property(e => e.CustomerId)
                    .IsRequired(false);

                entity.HasOne<Customer>(o => o.Customer)
                    .WithMany(m => m.Carts)
                    .HasForeignKey(fk => fk.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
            #endregion
            #region CartDetail
            modelBuilder.Entity<CartProduct>(entity => 
            {
                entity.ToTable("CartProduct").
                    HasKey(e => new { e.CartId, e.ProductId});

                entity.Property(e => e.CartId)
                    .IsRequired(true);

                entity.HasOne<Cart>(o => o.Cart)
                    .WithMany(m => m.CartDetails)
                    .HasForeignKey(fk => fk.CartId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.ProductId)
                    .IsRequired(true);

                entity.HasOne<Product>(o => o.Product)
                    .WithMany(m => m.CartProducts)
                    .HasForeignKey(fk => fk.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.HasIndex(e => e.Username)
                    .IsUnique(true);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.HasIndex(e => e.Email)
                    .IsUnique(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity.HasIndex(e => e.Phone)
                    .IsUnique(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsRequired(true);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity.Property(e => e.Avatar)
                    .HasMaxLength(255);

                entity.Property(e => e.Address)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(true);

                entity.Property(e => e.Country)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity.Property(e => e.Gender)
                    .IsRequired(true);
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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsRequired(true);

                entity.Property(e => e.Title)
                    .IsRequired(true);

                entity.Property(e => e.Status)
                    .IsRequired();
                    /*.HasDefaultValue(DiscountStatus.ACTIVE);*/

                entity.Property(e => e.Value)
                    .HasDefaultValue(0);

                entity.Property(e => e.Quantity)
                    .IsRequired(true);

                entity.Property(e => e.ExpiredAt)
                    .IsRequired(true);

                entity.Property(e => e.TypeId)
                    .IsRequired(true);

                entity.HasOne<DiscountType>(o => o.DiscountType)
                    .WithMany(m => m.Discounts)
                    .HasForeignKey(fk => fk.TypeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.OrganizerId)
                    .IsRequired(true);

                entity.HasOne<Organizer>(o => o.Organizer)
                    .WithMany(m => m.Discounts)
                    .HasForeignKey(fk => fk.OrganizerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion
            #region DiscountType
            modelBuilder.Entity<DiscountType>(entity =>
            {
                entity.ToTable("DiscountType")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true);

                entity.Property(e => e.Status)
                    .IsRequired();
                    /*.HasDefaultValue(DiscountTypeStatus.ACTIVE);*/

                entity.Property(e => e.Type)
                    .IsRequired();
                    /*.HasDefaultValue(TypeDiscount.NONE);*/

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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Title)
                    .IsRequired(true);

                entity.Property(e => e.Content)
                    .IsRequired(true);

                entity.Property(e => e.Type)
                    .IsRequired();
                    /*.HasDefaultValue(TypeNotification.ACTIVE);*/

                entity.Property(e => e.Status)
                    .IsRequired();
                    /*.HasDefaultValue(NotificationStatus.ACTIVE);*/

                entity.Property(e => e.ReadAt)
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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true);
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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.SubTotal)
                    .IsRequired(true);

                entity.Property(e => e.ShippingCost)
                    .IsRequired(true);

                entity.Property(e => e.PaymentMethod)
                    .IsRequired(true);

                entity.Property(e => e.PaymentStatus)
                    .IsRequired(true);

                entity.Property(e => e.Status)
                    .IsRequired();
                    /*.HasDefaultValue(OrderStatus.PENDING);*/

                entity.Property(e => e.Total)
                    .IsRequired(true);

                entity.Property(e => e.CustomerId)
                    .IsRequired(false);

                entity.HasOne<Customer>(o => o.Customer)
                    .WithMany(m => m.Orders)
                    .HasForeignKey(fk => fk.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(e => e.VoucherId)
                    .IsRequired(false);

                entity.HasOne<Voucher>(o => o.Voucher)
                    .WithMany(m => m.Orders)
                    .HasForeignKey(fk => fk.VoucherId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(e => e.ReceiverId)
                    .IsRequired(false);

                entity.HasOne<Receiver>(o => o.Receiver)
                    .WithMany(m => m.Orders)
                    .HasForeignKey(fk => fk.ReceiverId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
            #endregion
            #region Organizer
            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.ToTable("Organizer")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity.HasIndex(e => e.Phone)
                    .IsUnique(true);

                entity.Property(e => e.Phone)
                    .IsUnicode(false)
                    .HasMaxLength(11)
                    .IsRequired(true);

                entity.HasIndex(e => e.Email)
                    .IsUnique(true);

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .IsRequired(true);

                entity.Property(e => e.Address)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity.Property(e => e.Detail)
                    .IsRequired(false);

                entity.Property(e => e.IsCompany)
                    .HasDefaultValue(false);

                entity.Property(e => e.Photo)
                    .IsRequired(false);
            });
            #endregion
            #region Permission
            modelBuilder.Entity<Permission>(entity => 
            {
                entity.ToTable("Permission")
                    .HasKey(e => new { e.RoleId, e.OptionId});

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

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
            #region Photo
            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Url)
                    .IsRequired(true);
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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true);

                entity.Property(e => e.Decription)
                    .IsRequired(true);

                entity.Property(e => e.Status)
                    .IsRequired();
                    /*.HasDefaultValue(ProductStatus.NORMAL);*/

                entity.Property(e => e.Gender)
                    .HasDefaultValue(-1);

                entity.Property(e => e.BrandId)
                    .IsRequired(false);

                entity.HasOne<ProductBrand>(o => o.Brand)
                    .WithMany(m => m.Products)
                    .HasForeignKey(fk => fk.BrandId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(e => e.CategoryId)
                    .IsRequired(false);

                entity.HasOne<ProductCategory>(o => o.Category)
                    .WithMany(m => m.Products)
                    .HasForeignKey(fk => fk.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);

                /*entity.Property(e => e.SubCategoryId)
                    .IsRequired(false);

                entity.HasOne<ProductCategory>(o => o.SubCategory)
                    .WithMany(m => m.Products)
                    .HasForeignKey(fk => fk.SubCategoryId)
                    .OnDelete(DeleteBehavior.SetNull);*/

                entity.Property(e => e.OrganizerId)
                    .IsRequired(true);

                entity.HasOne<Organizer>(o => o.Organizer)
                    .WithMany(m => m.Products)
                    .HasForeignKey(fk => fk.OrganizerId)
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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true);

                entity.Property(e => e.Description)
                    .IsRequired(true);

                entity.Property(e => e.Status)
                    .IsRequired(true);

                entity.Property(e => e.Photo)
                    .IsRequired(true);
            });
            #endregion
            #region ProductCategory
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true);

                entity.Property(e => e.Photo)
                    .IsRequired(true);

                entity.Property(e => e.Description)
                    .IsRequired(true);

                entity.Property(e => e.Status)
                    .IsRequired(true);

                entity.Property(e => e.AddBy)
                    .IsRequired(true);

                entity.Property(e => e.IsParent)
                    .HasDefaultValue(false);

                entity.Property(e => e.ParentId)
                    .IsRequired(false);

                entity.Property(e => e.OrganizerId)
                    .IsRequired(true);

                entity.HasOne<Organizer>(o => o.Organizer)
                    .WithMany(m => m.ProductCategories)
                    .HasForeignKey(fk => fk.OrganizerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion
            #region ProductDetail
            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.ToTable("ProductDetail")
                    .HasKey(e => new { e.ProductId, e.ProductVarianceId, e.SizeId });

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Quantity)
                    .IsRequired(true);

                entity.Property(e => e.Price)
                    .IsRequired(true);

                entity.Property(e => e.Status)
                    .IsRequired();
                    /*.HasDefaultValue(ProductDetailStatus.NORMAL);*/

                entity.Property(e => e.Photo)
                    .IsRequired(false);

                entity.Property(e => e.DiscountId)
                    .IsRequired(false);

                entity.HasOne<Discount>(o => o.Discount)
                    .WithMany(m => m.ProductDetails)
                    .HasForeignKey(fk => fk.DiscountId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(e => e.ProductId)
                    .IsRequired(true);

                entity.HasOne<Product>(o => o.Product)
                    .WithMany(m => m.ProductDetails)
                    .HasForeignKey(fk => fk.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.ProductVarianceId)
                    .IsRequired(true);

                entity.HasOne<ProductVariance>(o => o.ProductVariance)
                    .WithMany(m => m.Details)
                    .HasForeignKey(fk => fk.ProductVarianceId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.SizeId)
                    .IsRequired(true);

                entity.HasOne<Size>(o => o.ProductSize)
                    .WithMany(m => m.ProductDetails)
                    .HasForeignKey(fk => fk.SizeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion
            #region ProductVariance
            modelBuilder.Entity<ProductVariance>(entity => 
            {
                entity.ToTable("ProductVariance")
                   .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true);

                entity.Property(e => e.Description)
                    .IsRequired(true);

                entity.Property(e => e.Photo)
                    .IsRequired(true);

                entity.Property(e => e.Status)
                    .IsRequired(true);

                entity.Property(e => e.OrganizerId)
                    .IsRequired(true);

                entity.HasOne<Organizer>(o => o.Organizer)
                    .WithMany(m => m.ProductVariances)
                    .HasForeignKey(fk => fk.OrganizerId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.ProductId)
                    .IsRequired(true);

                entity.HasOne<Product>(o => o.Product)
                    .WithMany(m => m.Variances)
                    .HasForeignKey(fk => fk.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion
            #region Receiver
            modelBuilder.Entity<Receiver>(entity =>
            {
                entity.ToTable("Receiver")
                    .HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true);

                entity.Property(e => e.Email)
                    .IsRequired(true);

                entity.Property(e => e.Phone)
                    .IsRequired(true);

                entity.Property(e => e.Address)
                    .IsRequired(true);

                entity.Property(e => e.Number)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true);

                entity.Property(e => e.Street)
                    .IsRequired(true);

                entity.Property(e => e.Ward)
                    .IsRequired(true);

                entity.Property(e => e.District)
                    .IsRequired(true);

                entity.Property(e => e.City)
                    .IsRequired(true);

                entity.Property(e => e.Country)
                    .IsRequired(true);

                entity.Property(e => e.CustomerId)
                    .IsRequired(false);

                entity.HasOne<Customer>(o => o.Customer)
                    .WithMany(m => m.Receivers)
                    .HasForeignKey(fk => fk.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull);
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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Rating)
                    .HasDefaultValue(0);

                entity.Property(e => e.Comment)
                    .IsRequired(false);

                entity.Property(e => e.Photo)
                    .IsRequired(false);

                entity.Property(e => e.ParentId)
                    .IsRequired(false);

                entity.Property(e => e.UserId)
                    .IsRequired(true);

                entity.HasOne<User>(o => o.User)
                    .WithMany(m => m.Reviews)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.ProductId)
                    .IsRequired(true);

                entity.HasOne<Product>(o => o.Product)
                    .WithMany(m => m.Reviews)
                    .HasForeignKey(o => o.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.ProductId)
                    .IsRequired(true);

                entity.HasOne<ProductVariance>(o => o.ProductVariance)
                    .WithMany(m => m.Reviews)
                    .HasForeignKey(o => o.ProductVarianceId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.OrganizerId)
                    .IsRequired(false);

                entity.HasOne<Organizer>(o => o.Organizer)
                    .WithMany(m => m.Reviews)
                    .HasForeignKey(o => o.OrganizerId)
                    .OnDelete(DeleteBehavior.SetNull);
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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true);
            });
            #endregion
            #region Size
            modelBuilder.Entity<Size>(entity => 
            {
                entity.ToTable("Size")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true);

                entity.Property(e => e.Value)
                    .IsRequired(true);

                entity.Property(e => e.Status)
                    .IsRequired();
                    /*.HasDefaultValue(SizeStatus.NONE);*/

                entity.Property(e => e.SizeCategoryId)
                    .IsRequired(false);

                entity.HasOne<SizeCategory>(o => o.SizeCategory)
                    .WithMany(m => m.Sizes)
                    .HasForeignKey(o => o.SizeCategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.FullName)
                    .IsRequired(true);

                entity.Property(e => e.Gender)
                    .IsRequired(true);

                entity.HasIndex(e => e.Phone)
                    .IsUnique(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsRequired(true);

                entity.Property(e => e.Avatar)
                    .IsRequired(false);

                entity.Property(e => e.AccountId)
                    .IsRequired(false);

                entity.HasOne<Account>(o => o.Account)
                    .WithOne(m => m.User)
                    .HasForeignKey<Account>(fk => fk.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(e => e.OrganizerId)
                    .IsRequired(false);

                entity.HasOne<Organizer>(o => o.Organizer)
                    .WithOne(o => o.User)
                    .HasForeignKey<Organizer>(fk => fk.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Code)
                    .IsRequired(true);

                entity.Property(e => e.Title)
                    .IsRequired(true);

                entity.Property(e => e.Value)
                    .HasDefaultValue(0);

                entity.Property(e => e.Quantity)
                    .IsRequired(true);

                entity.Property(e => e.ExpiredAt)
                    .IsRequired(true);

                entity.Property(e => e.Status)
                    .IsRequired();
                    /*.HasDefaultValue(VoucherStatus.ACTIVE);*/

                entity.Property(e => e.OrganizerId)
                    .IsRequired(false);

                entity.HasOne<Organizer>(o => o.Organizer)
                    .WithMany(m => m.Vouchers)
                    .HasForeignKey(fk => fk.OrganizerId)
                    .OnDelete(DeleteBehavior.SetNull);

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
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Name)
                    .IsRequired(true);

                entity.Property(e => e.Type)
                    .IsRequired();
                    /*.HasDefaultValue(TypeVoucher.NONE);*/

                entity.Property(e => e.Status)
                    .IsRequired();
                    /*.HasDefaultValue(VoucherTypeStatus.ACTIVE);*/

            });
            #endregion
            #region Wishlist
            modelBuilder.Entity<Wishlist>(entity => 
            {
                entity.ToTable("Wishlist")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.Property(e => e.Price)
                    .IsRequired(true);

                entity.Property(e => e.UserId)
                    .IsRequired(true);

                entity.HasOne<User>(o => o.User)
                    .WithMany(m => m.Wishlists)
                    .HasForeignKey(fk => fk.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion
            #region Wishlist_Product
            modelBuilder.Entity<Wishlist_Product>(entity => 
            {
                entity.ToTable("Wishlist_Product")
                    .HasKey(e => new { e.WishlistId, e.ProductId});

                entity.Property(e => e.CreatedAt)
                    .IsRequired(true);

                entity.Property(e => e.LastModifiedAt)
                    .IsRequired(true);

                entity.HasOne<Wishlist>(o => o.Wishlist)
                    .WithMany(m => m.Wishlist_Products)
                    .HasForeignKey(fk => fk.WishlistId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Product>(o => o.Product)
                    .WithMany(m => m.Wishlist_Products)
                    .HasForeignKey(fk => fk.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion

            // Seeding data
            modelBuilder.Seed();
        }
    }
}
