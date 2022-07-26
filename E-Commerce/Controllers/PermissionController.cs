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
    public class PermissionController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly PermissionService _service;
        private readonly Context _ctx;

        public PermissionController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new PermissionService(_config, ctx);
        }

        [Route("permission")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllPermission()
        {
            List<Permission> permissions = _service.GetAll();
            if (permissions.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", permissions));
            }
            return Ok(new ResponseEntity("Get all permissions successfully", permissions));
        }

        [Route("permission/{optionId}/{roleId}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetPermissionById(long optionId, long roleId)
        {
            Permission permission = _service.Get(optionId, roleId);
            if (permission == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get permission by optionId = {optionId} and roleId = {roleId} successfully", permission));
        }

        [Route("permission/delete/{optionId}/{roleId}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeletePermissionById(long optionId, long roleId)
        {
            int res = _service.Delete(optionId, roleId);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete permission by optionId = {optionId} and roleId = {roleId} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete permission failed"));

        }
    }
}
