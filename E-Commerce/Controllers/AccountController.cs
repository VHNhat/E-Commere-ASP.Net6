using E_Commerce.DataAccess;
using E_Commerce.Dto;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    /*[Route("api/[controller]")]*/
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

        [Route("api/account")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllAccount()
        {
            List<Account> accounts = _service.GetAll();
            if (accounts.Count == 0)
                return new JsonResult("There is no data");

            return new JsonResult(accounts);
        }
        [Route("api/account/{id}")]
        [HttpGet]
        public ActionResult GetAccountById(long id)
        {
            Account account = _service.Get(id);
            if (account == null)
                return BadRequest();

            return new JsonResult(account);
        }

        [Route("api/account/add")]
        [HttpPost]
        public ActionResult AddAccount(AddAccount dto)
        {
            int result = _service.Add(dto);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [Route("api/account/edit/{id}")]
        [HttpPut]
        public ActionResult UpdateAccount(long id, Account account)
        {
            if (ModelState.IsValid)
            {
                int res = _service.UpdateById(id, account);
                if (res > 0) return Ok();
                else return BadRequest();
            }
            return BadRequest();
        }

        [Route("api/account/delete/{id}")]
        [HttpDelete]
        public ActionResult DeleteAccount(long id)
        {
            int res = _service.Delete(id);
            if (res > 0) return Ok();
            else return BadRequest();
        }
    }
}
