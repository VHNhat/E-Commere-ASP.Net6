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
    }
}
