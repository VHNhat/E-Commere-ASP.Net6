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
    public class ProductDetailController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ProductDetailService _service;
        private readonly Context _ctx;

        public ProductDetailController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new ProductDetailService(_config, ctx);
        }

        [Route("detail")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllDetail()
        {
            List<ProductDetail> details = _service.GetAll();
            if (details.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", details));
            }
            return Ok(new ResponseEntity("Get all product details successfully", details));
        }

        [Route("detail/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetDetailById(long productId, long varianceId, long sizeId)
        {
            ProductDetail detail = _service.Get(productId, varianceId, sizeId);
            if (detail == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get detail by productId = {productId} && varianceId = {varianceId} && sizeId = {sizeId} successfully", detail));
        }

        [Route("detail/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteDetailById(long productId, long varianceId, long sizeId)
        {
            int res = _service.Delete(productId, varianceId, sizeId);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete detail by productId = {productId} && varianceId = {varianceId} && sizeId = {sizeId} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete detail failed"));

        }
    }
}
