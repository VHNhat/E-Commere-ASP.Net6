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
    public class WishlistController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly WishlistService _service;
        private readonly Context _ctx;

        public WishlistController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new WishlistService(_config, ctx);
        }

        [Route("wishlist")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllWishlist()
        {
            List<Wishlist> wishlists = _service.GetAll();
            if (wishlists.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", wishlists));
            }
            return Ok(new ResponseEntity("Get all wishlists successfully", wishlists));
        }

        [Route("wishlist/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetWishlistById(long id)
        {
            Wishlist wishlist = _service.Get(id);
            if (wishlist == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get wishlist by id = {id} successfully", wishlist));
        }

        [Route("wishlist/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteWishlistById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete wishlist by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete wishlist failed"));

        }
    }
}
