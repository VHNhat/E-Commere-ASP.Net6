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
                    Username = "account1",
                    Password = BCrypt.Net.BCrypt.HashPassword("123"),
                    Email = "email1@gmail.com",
                    RoleId = 1,
                    UserId = 1
                },
                new Account()
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Username = "account2",
                    Password = BCrypt.Net.BCrypt.HashPassword("123"),
                    Email = "email2@gmail.com",
                    RoleId = 2,
                    UserId = 2
                },
                new Account()
                {
                    Id = 3,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Username = "account3",
                    Password = BCrypt.Net.BCrypt.HashPassword("123"),
                    Email = "email3@gmail.com",
                    RoleId = 3,
                    UserId = 3
                },
                new Account()
                {
                    Id = 4,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Username = "account4",
                    Password = BCrypt.Net.BCrypt.HashPassword("123"),
                    Email = "email4@gmail.com",
                    RoleId = 4,
                    UserId = 4
                }
                );
            #endregion
            #region Role
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Name = "admin"
                },
                new Role()
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Name = "shop-owner"
                },
                new Role()
                {
                    Id = 3,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Name = "manager"
                },
                new Role()
                {
                    Id = 4,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Name = "staff"
                }
                );
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
                    FullName = "User 1",
                    Phone = "0000000001",
                    Avatar = "photo.png",
                    OrganizerId = 1                 
                },
                new User()
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    AccountId = 2,
                    Gender = 0,
                    FullName = "User 2",
                    Phone = "0000000002",
                    Avatar = "photo.png",
                    OrganizerId = 2
                },
                new User()
                {
                    Id = 3,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    AccountId = 3,
                    Gender = 0,
                    FullName = "User 3",
                    Phone = "0000000003",
                    Avatar = "photo.png",
                    OrganizerId = 3
                },
                new User()
                {
                    Id = 4,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    AccountId = 4,
                    Gender = 1,
                    FullName = "User 4",
                    Phone = "0000000004",
                    Avatar = "photo.png",
                    OrganizerId = 4
                }
                );
            #endregion
            #region Organizer
            modelBuilder.Entity<Organizer>().HasData(
                new Organizer()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Address = "address",
                    Detail = "detail",
                    Email = "email@gmail.com",
                    IsCompany = true,
                    Name = "name",
                    Phone = "0000000001",
                    Photo = "photo",
                    UserId = 1
                }, new Organizer()
                {
                    Id = 2,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Address = "address",
                    Detail = "detail",
                    Email = "email2@gmail.com",
                    IsCompany = false,
                    Name = "name",
                    Phone = "0000000002",
                    Photo = "photo",
                    UserId = 2
                }, new Organizer()
                {
                    Id = 3,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Address = "address",
                    Detail = "detail",
                    Email = "email3@gmail.com",
                    IsCompany = false,
                    Name = "name",
                    Phone = "0000000003",
                    Photo = "photo",
                    UserId = 3
                }, new Organizer()
                {
                    Id = 4,
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Address = "address",
                    Detail = "detail",
                    Email = "email4@gmail.com",
                    IsCompany = true,
                    Name = "name",
                    Phone = "0000000004",
                    Photo = "photo",
                    UserId = 4
                }
                );
            #endregion
            #region OptionRole
            modelBuilder.Entity<OptionRole>().HasData(
                new OptionRole
                {
                    Id = 1,
                    Name = "Get",
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now
                },
                new OptionRole
                {
                    Id = 2,
                    Name = "Post",
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now
                },
                new OptionRole
                {
                    Id = 3,
                    Name = "Put",
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now
                },
                new OptionRole
                {
                    Id = 4,
                    Name = "Delete",
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now
                }
                );
            #endregion
            #region Permission
            modelBuilder.Entity<Permission>().HasData(
                new Permission
                {
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    OptionId = 1,
                    RoleId = 1
                },
                new Permission
                {
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    OptionId = 2,
                    RoleId = 1
                },
                new Permission
                {
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    OptionId = 3,
                    RoleId = 1
                },
                new Permission
                {
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    OptionId = 4,
                    RoleId = 1
                },
                new Permission
                {
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    OptionId = 1,
                    RoleId = 2
                },
                new Permission
                {
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    OptionId = 2,
                    RoleId = 2
                }
                );
            #endregion
        }
    }
}
