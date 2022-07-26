using E_Commerce.DataAccess;
using E_Commerce.Generic;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public class ProductService : GenericService<Product>
    {
        private readonly IConfiguration _config;
        private readonly string sqlDataSource;
        private readonly Context ctx;

        public ProductService(IConfiguration config, Context context) : base(config, context)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
            ctx = context;
        }
    }
}
