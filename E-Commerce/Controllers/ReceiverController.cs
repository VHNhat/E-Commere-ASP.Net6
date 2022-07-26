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
    public class ReceiverController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ReceiverService _service;
        private readonly Context _ctx;

        public ReceiverController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new ReceiverService(_config, ctx);
        }

        [Route("receiver")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllReceiver()
        {
            List<Receiver> receivers = _service.GetAll();
            if (receivers.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", receivers));
            }
            return Ok(new ResponseEntity("Get all receivers successfully", receivers));
        }

        [Route("receiver/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetReceiverById(long id)
        {
            Receiver receiver = _service.Get(id);
            if (receiver == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get receiver by id = {id} successfully", receiver));
        }

        [Route("receiver/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteReceiverById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete receiver by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete receiver failed"));

        }
    }
}
