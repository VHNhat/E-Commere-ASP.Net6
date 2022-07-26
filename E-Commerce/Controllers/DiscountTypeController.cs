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
    public class DiscountTypeController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DiscountTypeService _service;
        private readonly Context _ctx;

        public DiscountTypeController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new DiscountTypeService(_config, ctx);
        }

        [Route("discount-type")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllDiscountType()
        {
            List<DiscountType> discountTypes = _service.GetAll();
            if (discountTypes.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", discountTypes));
            }
            return Ok(new ResponseEntity("Get all discount types successfully", discountTypes));
        }

        [Route("discount-type/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetDiscountTypeById(long id)
        {
            DiscountType discountType = _service.Get(id);
            if (discountType == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get discount type by id = {id} successfully", discountType));
        }

        [Route("discount-type/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteDiscountTypeById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete discount type by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete discount type failed"));

        }
    }
}
