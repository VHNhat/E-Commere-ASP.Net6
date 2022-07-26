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
    public class BannerController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly BannerService _service;
        private readonly Context _ctx;

        public BannerController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new BannerService(_config, ctx);
        }

        [Route("banner")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllBanner()
        {
            List<Banner> banners = _service.GetAll();
            if (banners.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity("Get all banners successfully", banners));
        }

        [Route("banner/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetBannerById(long id)
        {
            Banner banner = _service.Get(id);
            if (banner == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get banner by id = {id} successfully", banner));
        }

        [Route("banner/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteBannerById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete banner by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete banner failed"));

        }
    }
}
