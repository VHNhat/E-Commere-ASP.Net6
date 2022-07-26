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
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly CustomerService _service;
        private readonly Context _ctx;

        public CustomerController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new CustomerService(_config, ctx);
        }

        [Route("customer")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllCustomer()
        {
            List<Customer> customers = _service.GetAll();
            if (customers.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", customers));
            }
            return Ok(new ResponseEntity("Get all customers successfully", customers));
        }

        [Route("customer/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetCustomerById(long id)
        {
            Customer customer = _service.Get(id);
            if (customer == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get customer by id = {id} successfully", customer));
        }

        [Route("customer/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteCustomerById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete customer by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete customer failed"));

        }
    }
}
