using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Extension
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Account
            modelBuilder.Entity<Account>().HasData(
                new Account()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Username = "admin",
                    Password = "123",
                    Email = "nhat@gmail.com",
                    RoleId = 1,
                    UserId = 1
                });
            #endregion
            #region Role
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Name = "admin"
                });
            #endregion
            #region User
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    AccountId = 1,
                    Gender = 1,
                    Name = "Võ Hoàng Nhật",
                    Phone = "0942400722",
                    Photo = "photo.png",
                    StoreId = 1,
                });
            #endregion
            #region Store
            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Address = "Đặng Thùy Trâm",
                    Detail = "cc",
                    Map = "cc",
                    Name = "Unny mini house",
                    Photo = "photo.png",
                });
            #endregion
        }
    }
}
