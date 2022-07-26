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
    public class RoleController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly RoleService _service;
        private readonly Context _ctx;

        public RoleController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new RoleService(_config, ctx);
        }

        [Route("role")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllRole()
        {
            List<Role> roles = _service.GetAll();
            if (roles.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", roles));
            }
            return Ok(new ResponseEntity("Get all roles successfully", roles));
        }

        [Route("role/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetRoleById(long id)
        {
            Role role = _service.Get(id);
            if(role == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get role by id = {id} successfully", role));
        }

        [Route("role/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteRoleById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete role by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete role failed"));

        }
    }
}
