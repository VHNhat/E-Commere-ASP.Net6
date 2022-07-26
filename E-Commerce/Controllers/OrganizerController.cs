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
    public class OrganizerController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly OrganizerService _service;
        private readonly Context _ctx;

        public OrganizerController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new OrganizerService(_config, ctx);
        }

        [Route("organizer")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllOragnizer()
        {
            List<Organizer> organizers = _service.GetAll();
            if (organizers.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", organizers));
            }
            return Ok(new ResponseEntity("Get all organizers successfully", organizers));
        }

        [Route("organizer/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetOragnizerById(long id)
        {
            Organizer organizer = _service.Get(id);
            if (organizer == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get organizer by id = {id} successfully", organizer));
        }

        [Route("organizer/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteOragnizerById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete organizer by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete organizer failed"));

        }
    }
}
