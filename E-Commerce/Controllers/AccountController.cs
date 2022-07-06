using E_Commerce.DataAccess;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AccountService _service;
        private readonly Context context;

        public AccountController(IConfiguration config, Context ctx)
        {
            _config = config;
            context = ctx;
            _service = new AccountService(_config, ctx);
        }

        [Route("account")]
        [HttpGet]
        public ActionResult GetAllAccount()
        {
            List<Account> accounts = _service.FindAll();
            if (accounts.Count == 0)
                return new JsonResult("There is no data");

            return new JsonResult(accounts);
        }
    }
}
