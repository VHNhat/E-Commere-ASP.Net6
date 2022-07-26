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
    public class CartController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly CartService _service;
        private readonly Context _ctx;

        public CartController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new CartService(_config, ctx);
        }

        [Route("cart")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllCart()
        {
            List<Cart> carts = _service.GetAll();
            if (carts.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", carts));
            }
            return Ok(new ResponseEntity("Get all carts successfully", carts));
        }

        [Route("cart/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetCartById(long id)
        {
            Cart cart = _service.Get(id);
            if (cart == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get cart by id = {id} successfully", cart));
        }

        [Route("cart/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteCartById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete cart by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete cart failed"));

        }
    }
}
