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
    public class OptionRoleController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly OptionRoleService _service;
        private readonly Context _ctx;

        public OptionRoleController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new OptionRoleService(_config, ctx);
        }

        [Route("option-role")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllOptionRole()
        {
            List<OptionRole> options = _service.GetAll();
            if (options.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", options));
            }
            return Ok(new ResponseEntity("Get all option roles successfully", options));
        }

        [Route("option-role/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetOptionRoleById(long id)
        {
            OptionRole option = _service.Get(id);
            if (option == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get option role by id = {id} successfully", option));
        }

        [Route("option-role/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteOptionRoleById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete option role by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete option role failed"));

        }
    }
}
