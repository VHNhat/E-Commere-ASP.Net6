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
            modelBuilder.Entity<Account>().HasData(
                new Account()
                {
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Username = "admin",
                    Password = "123",
                    Email = "nhat@gmail.com"
                    

                });

        }
    }
}
