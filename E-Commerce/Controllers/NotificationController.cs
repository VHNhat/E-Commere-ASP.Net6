using E_Commerce.DataAccess;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly NotificationService _service;
        private readonly Context context;

        public NotificationController(IConfiguration config, Context ctx)
        {
            _config = config;
            context = ctx;
            _service = new NotificationService(_config, ctx);
        }

        [Route("api/notification")]
        [HttpGet]
        public ActionResult GetAllAccount()
        {
            List<Notification> accounts = _service.GetAll();
            if (accounts.Count == 0)
                return new JsonResult("There is no data");

            return new JsonResult(accounts);
        }
        [Route("api/notification/{id}")]
        [HttpGet]
        public ActionResult GetAccountById(long id)
        {
            Notification notification = _service.Get(id);
            if (notification == null)
                return BadRequest();

            return new JsonResult(notification);
        }

        [Route("api/notification/add")]
        [HttpPost]
        public ActionResult AddAccount(Notification notification)
        {
            /*var newAcc = new Account
            {
                Username = account.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(account.Password),
                Email = account.Email
            };*/
            int result = _service.Add(notification);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [Route("api/notification/edit/{id}")]
        [HttpPut]
        public ActionResult UpdateAccount(long id, Notification notification)
        {
            if (ModelState.IsValid)
            {
                int res = _service.UpdateById(id, notification);
                if (res > 0) return Ok();
                else return BadRequest();
            }
            return BadRequest();
        }

        [Route("api/notification/delete/{id}")]
        [HttpDelete]
        public ActionResult DeleteAccount(long id)
        {
            int res = _service.Delete(id);
            if (res > 0) return Ok();
            else return BadRequest();
        }
    }
}
