using FoodSync.BLL.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _business;
        public ProductsController(IProduct product)
        {
            _business = product;
        }

        [HttpGet("GetPrducts/{brandId}")]
        public ActionResult GetProductByBrandId (long brandId)
        {
            try
            {
                var res = _business.GetProductsByBrand(brandId);
                if (res != null)
                    return Ok(res);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
