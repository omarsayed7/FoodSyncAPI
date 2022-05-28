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
    public class RawMaterialController : ControllerBase
    {
        private readonly IRawMaterial _business;
        public RawMaterialController(IRawMaterial rawMaterial)
        {
            _business = rawMaterial;
        }

        [HttpGet("GetRMsByBrandId/{brandId}")]
        public ActionResult GetRMsByBrandId(long brandId)
        {
            try
            {
                var res = _business.GetRMByBrandId(brandId);
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
