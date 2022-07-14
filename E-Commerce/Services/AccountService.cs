using E_Commerce.DataAccess;
using E_Commerce.Dto;
using E_Commerce.Generic;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public class AccountService : GenericService<Account>
    {
        private readonly IConfiguration _config;
        private readonly string sqlDataSource;
        private readonly Context ctx;

        public AccountService(IConfiguration config, Context context) : base(config, context)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
            ctx = context;
        }

        public int Add(AddAccount dto)
        {
            try
            {
                Account newAcc = new Account();
                newAcc.CreatedAt = DateTime.Now;
                newAcc.LastModifiedAt = DateTime.Now;
                newAcc.UserId = dto.UserId;
                newAcc.RoleId = dto.RoleId;
                newAcc.Email = dto.Email;
                newAcc.Username = dto.Username;
                newAcc.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
                ctx.Accounts.Add(newAcc);
                int res = ctx.SaveChanges();
                return res;
            }
            catch
            {
                return -1;
            }
        }

        public int UpdateById(long id, Account account)
        {
            try
            {
                Account acc = ctx.Accounts.Single(s => s.Id == id);

                acc.Username = account.Username;
                acc.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                acc.RoleId = account.RoleId;
                acc.LastModifiedAt = DateTime.Now;
                acc.UserId = account.UserId;

                return ctx.SaveChanges();

            }
            catch
            {
                return -1;
            }
        }
    }
}
