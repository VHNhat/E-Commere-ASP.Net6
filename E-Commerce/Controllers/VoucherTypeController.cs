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
    public class VoucherTypeController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly VoucherTypeService _service;
        private readonly Context _ctx;

        public VoucherTypeController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new VoucherTypeService(_config, ctx);
        }

        [Route("voucher-type")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllVoucherType()
        {
            List<VoucherType> types = _service.GetAll();
            if (types.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", types));
            }
            return Ok(new ResponseEntity("Get all voucher types successfully", types));
        }

        [Route("voucher-type/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetVoucherTypeById(long id)
        {
            VoucherType type = _service.Get(id);
            if (type == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get voucher type by id = {id} successfully", type));
        }

        [Route("voucher-type/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteVoucherTypeById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete voucher type by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete voucher type failed"));

        }
    }
}
