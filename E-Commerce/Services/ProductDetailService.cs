using E_Commerce.DataAccess;
using E_Commerce.Generic;
using E_Commerce.Models;

namespace E_Commerce.Services
{
    public class ProductDetailService
    {
        private readonly IConfiguration _config;
        private readonly string sqlDataSource;
        private readonly Context ctx;

        public ProductDetailService(IConfiguration config, Context context)
        {
            _config = config;
            sqlDataSource = _config.GetConnectionString("mysql");
            ctx = context;
        }

        public List<ProductDetail> GetAll()
        {
            return ctx.ProductDetails.ToList();
        }

        public int Delete(long productId, long varianceId, long sizeId)
        {
            try
            {
                ProductDetail productDetail = ctx.ProductDetails.Single(s => s.ProductId == productId && s.ProductVarianceId == varianceId
                                                                        && s.SizeId == sizeId);
                ctx.Remove(productDetail);
                int res = ctx.SaveChanges();
                return res;
            }
            catch
            {
                return -1;
            }

        }

        public ProductDetail Get(long productId, long varianceId, long sizeId)
        {
            try
            {
                return ctx.ProductDetails.SingleOrDefault(s => s.ProductId == productId && s.ProductVarianceId == varianceId
                                                                        && s.SizeId == sizeId);
            }
            catch
            {
                return null;
            }
        }
    }
}
