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
    public class ProductVarianceController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ProductVarianceService _service;
        private readonly Context _ctx;

        public ProductVarianceController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new ProductVarianceService(_config, ctx);
        }

        [Route("product-variance")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllVariance()
        {
            List<ProductVariance> variances = _service.GetAll();
            if (variances.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", variances));
            }
            return Ok(new ResponseEntity("Get all product variances successfully", variances));
        }

        [Route("product-variance/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetVarianceById(long id)
        {
            ProductVariance variance = _service.Get(id);
            if (variance == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get product variance by id = {id} successfully", variance));
        }

        [Route("product-variance/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteVarianceById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete product variance by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete product variance failed"));

        }
    }
}
