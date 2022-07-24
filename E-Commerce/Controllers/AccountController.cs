using E_Commerce.DataAccess;
using E_Commerce.Dto;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    [Route("api/")]
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
        [Authorize]
        public ActionResult GetAllAccount()
        {
            List<Account> accounts = _service.GetAll();
            if (accounts.Count == 0)
                return new JsonResult("There is no data");

            return new JsonResult(accounts);
        }
        [Route("account/{id}")]
        [HttpGet]
        public ActionResult GetAccountById(long id)
        {
            Account account = _service.Get(id);
            if (account == null)
                return BadRequest();

            return new JsonResult(account);
        }

        [Route("account/add")]
        [HttpPost]
        public ActionResult AddAccount(AddAccount dto)
        {
            int result = _service.Add(dto);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [Route("account/edit/{id}")]
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

        [Route("account/delete/{id}")]
        [HttpDelete]
        public ActionResult DeleteAccount(long id)
        {
            int res = _service.Delete(id);
            if (res > 0) return Ok();
            else return BadRequest();
        }


        [Route("admin/login")]
        [HttpPost]
        public ActionResult Login(AdminLoginDto dto)
        {
            Account result = _service.Login(dto);

            if (result == null)
            {
                return new JsonResult("Username or Password is invalid.");
            }
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, result.Password))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var token = CreateToken(result);

            Response.Cookies.Append("Jwt-EcommercePUNH", token, new CookieOptions
            {
                HttpOnly = true
            });
            return new JsonResult(new { Token = token });
        }

        [Route("admin/register")]
        [HttpPost]
        public ActionResult Register(AdminSignupDto dto)
        {
            string res = _service.Register(dto);
            if (res == "1") return Ok();
            else return new JsonResult(res);
        }

        [Route("admin/logout")]
        [HttpPost]
        public ActionResult Logout()
        {
            Response.Cookies.Delete("Jwt-EcommercePUNH");
            return Ok(new { message = "Đã đăng xuất" });
        }

        private string CreateToken(Account account)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Username),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
