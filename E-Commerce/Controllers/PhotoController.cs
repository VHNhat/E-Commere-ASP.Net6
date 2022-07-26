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
    public class PhotoController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly PhotoService _service;
        private readonly Context _ctx;

        public PhotoController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new PhotoService(_config, ctx);
        }

        [Route("photo")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllPhoto()
        {
            List<Photo> photos = _service.GetAll();
            if (photos.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", photos));
            }
            return Ok(new ResponseEntity("Get all photos successfully", photos));
        }

        [Route("photo/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetPhotoById(long id)
        {
            Photo photo = _service.Get(id);
            if (photo == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get photo by id = {id} successfully", photo));
        }

        [Route("photo/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeletePhotoById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete photo by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete photo failed"));

        }
    }
}
