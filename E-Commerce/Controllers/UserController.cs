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
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserService _service;
        private readonly Context _ctx;

        public UserController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new UserService(_config, ctx);
        }

        [Route("user")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllUser()
        {
            List<User> users = _service.GetAll();
            if (users.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", users));
            }
            return Ok(new ResponseEntity("Get all users successfully", users));
        }

        [Route("user/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetUserById(long id)
        {
            User user = _service.Get(id);
            if (user == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get user by id = {id} successfully", user));
        }

        [Route("user/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteUserById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete user by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete user failed"));

        }
    }
}
