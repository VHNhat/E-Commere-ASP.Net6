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
    public class ProductBrandController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ProductBrandService _service;
        private readonly Context _ctx;

        public ProductBrandController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new ProductBrandService(_config, ctx);
        }

        [Route("brand")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllBrand()
        {
            List<ProductBrand> brands = _service.GetAll();
            if (brands.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", brands));
            }
            return Ok(new ResponseEntity("Get all brands successfully", brands));
        }

        [Route("brand/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetBrandById(long id)
        {
            ProductBrand brand = _service.Get(id);
            if (brand == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get brand by id = {id} successfully", brand));
        }

        [Route("brand/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteBrandById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete brand by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete brand failed"));

        }
    }
}
