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
    public class VoucherController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly VoucherService _service;
        private readonly Context _ctx;

        public VoucherController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new VoucherService(_config, ctx);
        }

        [Route("voucher")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllVoucher()
        {
            List<Voucher> vouchers = _service.GetAll();
            if (vouchers.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", vouchers));
            }
            return Ok(new ResponseEntity("Get all vouchers successfully", vouchers));
        }

        [Route("voucher/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetVoucherById(long id)
        {
            Voucher voucher = _service.Get(id);
            if (voucher == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get voucher by id = {id} successfully", voucher));
        }

        [Route("voucher/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteVoucherById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete voucher by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete voucher failed"));
        }
    }
}
