using E_Commerce.DataAccess;
using E_Commerce.Dto;
using E_Commerce.Models;
using E_Commerce.Services;
using E_Commerce.Utility;
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
        private readonly Context _ctx;

        public AccountController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new AccountService(_config, ctx);
        }

        [Route("account")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllAccount()
        {
            List<Account> accounts = _service.GetAll();
            if (accounts.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", accounts));
            }
            return Ok(new ResponseEntity("Get all accounts successfully", accounts));
        }
        [Route("account/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAccountById(long id)
        {
            Account account = _service.Get(id);
            if (account == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get account by id = {id} successfully", account));
        }

        [Route("account/add")]
        [HttpPost]
        [Authorize]
        public ActionResult AddAccount(AddAccount dto)
        {
            int result = _service.Add(dto);
            if (result > 0)
            {
                return Ok(new ResponseEntity("Add account successfully"));
            }
            return BadRequest(new ResponseEntity("Add account failed"));
        }

        [Route("account/edit/{id}")]
        [HttpPut]
        [Authorize]
        public ActionResult UpdateAccount(long id, Account account)
        {
            if (ModelState.IsValid)
            {
                int res = _service.UpdateById(id, account);
                if (res > 0)
                {
                    return Ok(new ResponseEntity($"Update account by id = {id} successfully"));
                }
                else
                {
                    return BadRequest(new ResponseEntity($"Update account by id = {id} failed"));
                }
            }
            return BadRequest();
        }

        [Route("account/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteAccountById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete account by id = {id} successfully"));
            }
            else
            {
                return BadRequest(new ResponseEntity("Delete account failed"));
            }
        }


        [Route("admin/login")]
        [HttpPost]
        public ActionResult Login(AdminLoginDto dto)
        {
            Account result = _service.Login(dto);

            if (result == null || !BCrypt.Net.BCrypt.Verify(dto.Password, result.Password))
            {
                return BadRequest(new ResponseEntity("Your account is invalid"));
            }
            var token = CreateToken(result);

            Response.Cookies.Append("Jwt-EcommercePUNH", token, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok(new ResponseEntity("Login successfully", new { Token = token }));
        }

        [Route("admin/register")]
        [HttpPost]
        public ActionResult Register(AdminSignupDto dto)
        {
            string res = _service.Register(dto);
            if (res == "1")
            {
                return Ok(new ResponseEntity("Register successfully"));
            }
            else return BadRequest(new ResponseEntity("Register failed", res));
        }

        [Route("admin/logout")]
        [HttpPost]
        public ActionResult Logout()
        {
            Response.Cookies.Delete("Jwt-EcommercePUNH");
            return Ok(new ResponseEntity("Logout successfully"));
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
