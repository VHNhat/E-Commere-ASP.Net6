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
    public class OrderController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly OrderService _service;
        private readonly Context _ctx;

        public OrderController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new OrderService(_config, ctx);
        }

        [Route("order")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllOrder()
        {
            List<Order> orders = _service.GetAll();
            if (orders.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", orders));
            }
            return Ok(new ResponseEntity("Get all orders successfully", orders));
        }

        [Route("order/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetOrderById(long id)
        {
            Order order = _service.Get(id);
            if (order == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get order by id = {id} successfully", order));
        }

        [Route("order/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteOrderById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete order by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete order failed"));

        }
    }
}
