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
    public class DiscountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DiscountService _service;
        private readonly Context _ctx;

        public DiscountController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new DiscountService(_config, ctx);
        }

        [Route("discount")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllDiscount()
        {
            List<Discount> discounts = _service.GetAll();
            if (discounts.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", discounts));
            }
            return Ok(new ResponseEntity("Get all discounts successfully", discounts));
        }

        [Route("discount/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetDiscountById(long id)
        {
            Discount discount = _service.Get(id);
            if (discount == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get discount by id = {id} successfully", discount));
        }

        [Route("discount/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteDiscountById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete discount by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete discount failed"));

        }
    }
}
