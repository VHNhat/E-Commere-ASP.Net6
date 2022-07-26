using E_Commerce.DataAccess;
using E_Commerce.Models;
using E_Commerce.Services;
using E_Commerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/")]
    [ApiController]
    public class WishlistProductController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly WishlistProductService _service;
        private readonly Context _ctx;

        public WishlistProductController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new WishlistProductService(_config, ctx);
        }

        [Route("wishlist-product")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllWishlistProduct()
        {
            List<Wishlist_Product> wishlist_Products = _service.GetAll();
            if (wishlist_Products.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", wishlist_Products));
            }
            return Ok(new ResponseEntity("Get all wishlist products successfully", wishlist_Products));
        }

        [Route("wishlist-product/{wishlistId}/{productId}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetWishlistProductById(long wishlistId, long productId)
        {
            Wishlist_Product wishlist_Product = _service.Get(wishlistId, productId);
            if (wishlist_Product == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get wishlist product by wishlistId = {wishlistId} and productId = {productId} successfully", wishlist_Product));
        }

        [Route("wishlist-product/delete/{wishlistId}/{productId}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteWishlistProductById(long wishlistId, long productId)
        {
            int res = _service.Delete(wishlistId, productId);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete wishlist product by wishlistId = {wishlistId} and productId = {productId} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete wishlist product failed"));

        }
    }
}
