using E_Commerce.DataAccess;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public class WishlistProductService
    {
        private readonly IConfiguration _config;
        private readonly string sqlDataSource;
        private readonly Context ctx;

        public WishlistProductService(IConfiguration config, Context context)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
            ctx = context;
        }

        public List<Wishlist_Product> GetAll()
        {
            return ctx.Wishlist_Products.ToList();
        }

        public int Delete(long wishlistId, long productId)
        {
            try
            {
                Wishlist_Product wishlist_Product = ctx.Wishlist_Products.Single(s => s.WishlistId == wishlistId && s.ProductId == productId);
                ctx.Remove(wishlist_Product);
                int res = ctx.SaveChanges();
                return res;
            }
            catch
            {
                return -1;
            }

        }

        public Wishlist_Product Get(long wishlistId, long productId)
        {
            try
            {
                return ctx.Wishlist_Products.SingleOrDefault(s => s.WishlistId == wishlistId && s.ProductId == productId);
            }
            catch
            {
                return null;
            }
        }
    }
}
