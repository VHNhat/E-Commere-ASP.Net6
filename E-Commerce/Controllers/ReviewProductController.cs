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
    public class ReviewProductController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ReviewProductService _service;
        private readonly Context _ctx;

        public ReviewProductController(IConfiguration config, Context ctx)
        {
            _config = config;
            _ctx = ctx;
            _service = new ReviewProductService(_config, ctx);
        }

        [Route("review-product")]
        [HttpGet]
        [Authorize]
        public ActionResult GetAllReviewProduct()
        {
            List<ReviewProduct> reviews = _service.GetAll();
            if (reviews.Count == 0)
            {
                return Ok(new ResponseEntity("There is no data", reviews));
            }
            return Ok(new ResponseEntity("Get all reviews successfully", reviews));
        }

        [Route("review-product/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult GetReviewProductById(long id)
        {
            ReviewProduct review = _service.Get(id);
            if (review == null)
            {
                return BadRequest(new ResponseEntity("There is no data"));
            }
            return Ok(new ResponseEntity($"Get review by id = {id} successfully", review));
        }

        [Route("review-product/delete/{id}")]
        [HttpDelete]
        [Authorize]
        public ActionResult DeleteReviewProductById(long id)
        {
            int res = _service.Delete(id);
            if (res > 0)
            {
                return Ok(new ResponseEntity($"Delete review by id = {id} successfully"));
            }
            return BadRequest(new ResponseEntity("Delete review failed"));

        }
    }
}
