using E_Commerce.DataAccess;
using E_Commerce.Generic;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public class CartProductService 
    {
        private readonly IConfiguration _config;
        private readonly string sqlDataSource;
        private readonly Context ctx;

        public CartProductService(IConfiguration config, Context context)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
            ctx = context;
        }

        public List<CartProduct> GetAll()
        {
            return ctx.CartProducts.ToList();
        }

        public int Delete(long productId, long cartId)
        {
            try
            {
                CartProduct cartProduct = ctx.CartProducts.Single(s => s.ProductId == productId && s.CartId == cartId);
                ctx.Remove(cartProduct);
                int res = ctx.SaveChanges();
                return res;
            }
            catch
            {
                return -1;
            }
            
        }

        public CartProduct Get(long productId, long cartId)
        {
            try
            {
                return ctx.CartProducts.SingleOrDefault(s => s.ProductId == productId && s.CartId == cartId);
            }
            catch
            {
                return null;
            }
        }
    }
}
