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
    public class SizeController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SizeService _service;
        private readonly Context _ctx;

        public SizeController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new SizeService(_config, ctx);
        }

        [Route("size")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllSize()
        {
            List<Size> sizes = _service.GetAll();
            if (sizes.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", sizes));
            }
            return Ok(new ResponseEntity("Get all sizes successfully", sizes));
        }

        [Route("size/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetSizeById(long id)
        {
            Size size = _service.Get(id);
            if (size == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get size by id = {id} successfully", size));
        }

        [Route("size/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteSizeById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete size by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete size failed"));

        }
    }
}
