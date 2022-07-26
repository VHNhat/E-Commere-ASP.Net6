using E_Commerce.DataAccess;
using E_Commerce.Models;
using E_Commerce.Services;
using E_Commerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ProductService _service;
        private readonly Context _ctx;

        public ProductController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new ProductService(_config, ctx);
        }

        [Route("product")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllProduct()
        {
            List<Product> products = _service.GetAll();
            if (products.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", products));
            }
            return Ok(new ResponseEntity("Get all products successfully", products));
        }

        [Route("product/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetProductById(long id)
        {
            Product product = _service.Get(id);
            if (product == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get product by id = {id} successfully", product));
        }

        [Route("product/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteProductById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete product by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete product failed"));

        }
    }
}
