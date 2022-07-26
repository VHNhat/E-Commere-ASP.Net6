using E_Commerce.DataAccess;
using E_Commerce.Generic;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public class OptionRoleService : GenericService<OptionRole>
    {
        private readonly IConfiguration _config;
        private readonly string sqlDataSource;
        private readonly Context ctx;

        public OptionRoleService(IConfiguration config, Context context) : base(config, context)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
            ctx = context;
        }
    }
}
