using E_Commerce.DataAccess;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public class AccountService
    {
        private readonly IConfiguration _config;
        private readonly string sqlDataSource;
        private readonly Context ctx;

        public AccountService()
        {
        }

        public AccountService(IConfiguration config)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
        }

        public AccountService(IConfiguration config, Context context)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
            ctx = context;
        }

        public List<Account> FindAll()
        {
            try
            {
                return ctx.Accounts.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
