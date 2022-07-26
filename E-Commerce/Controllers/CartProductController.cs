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
    public class CartProductController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly CartProductService _service;
        private readonly Context _ctx;

        public CartProductController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new CartProductService(_config, ctx);
        }

        [Route("cart-product")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllCartProduct()
        {
            List<CartProduct> cartProducts = _service.GetAll();
            if (cartProducts.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", cartProducts));
            }
            return Ok(new ResponseEntity("Get all cart products successfully", cartProducts));
        }

        [Route("cart-product/{productId}/{cartId}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetCartProductById(long productId, long cartId)
        {
            CartProduct cartProduct = _service.Get(productId, cartId);
            if (cartProduct == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get cart product by productid = {productId} and cartid = {cartId} successfully", cartProduct));
        }

        [Route("cart-product/delete/{productId}/{cartId}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteCartProductById(long productId, long cartId)
        {
            int res = _service.Delete(productId, cartId);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete cart product by productid = {productId} and cartid = {cartId} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete cart product failed"));

        }
    }
}
