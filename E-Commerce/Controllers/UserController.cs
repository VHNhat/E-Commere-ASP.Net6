using E_Commerce.DataAccess;
using E_Commerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserService _service;
        private readonly Context context;

        public UserController(IConfiguration config, Context ctx)
        {
            _config = config;
            context = ctx;
            _service = new UserService(_config, ctx);
        }

        [Route("user/delete/{id}")]
        [HttpDelete]
        public ActionResult DeleteAccount(long id)
        {
            int res = _service.Delete(id);
            if (res > 0) return Ok();
            else return BadRequest();
        }
    }
}
