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
    public class ProductCategoryController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ProductCategoryService _service;
        private readonly Context _ctx;

        public ProductCategoryController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new ProductCategoryService(_config, ctx);
        }

        [Route("product-category")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllCategory()
        {
            List<ProductCategory> categories = _service.GetAll();
            if (categories.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", categories));
            }
            return Ok(new ResponseEntity("Get all categories successfully", categories));
        }

        [Route("product-category/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetCategoryById(long id)
        {
            ProductCategory category = _service.Get(id);
            if (category == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get category by id = {id} successfully", category));
        }

        [Route("product-category/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteCategoryById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete category by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete category failed"));

        }
    }
}
