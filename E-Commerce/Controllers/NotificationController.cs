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
    public class NotificationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly NotificationService _service;
        private readonly Context _ctx;

        public NotificationController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new NotificationService(_config, ctx);
        }

        [Route("notification")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllRole()
        {
            List<Notification> notifications = _service.GetAll();
            if (notifications.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", notifications));
            }
            return Ok(new ResponseEntity("Get all notifications successfully", notifications));
        }

        [Route("notification/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetNotificationById(long id)
        {
            Notification notification = _service.Get(id);
            if (notification == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get notification by id = {id} successfully", notification));
        }

        [Route("notification/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteNotificationById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete notification by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete notification failed"));

        }
    }
}
