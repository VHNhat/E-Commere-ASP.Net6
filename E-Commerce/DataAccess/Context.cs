using E_Commerce.Extension;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account")
                    .HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

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

                entity.Property(e => e.Created_date)
                    .IsRequired();

                entity.Property(e => e.Modified_date)
                    .IsRequired();
            });

            
            // Seeding data
            modelBuilder.Seed();
        }
    }
}
