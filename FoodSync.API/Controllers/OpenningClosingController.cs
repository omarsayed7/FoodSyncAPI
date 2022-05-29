using FoodSync.BLL.Abstract;
using FoodSync.BLL.Concrete;
using FoodSync.BLL.Models;
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
    public class OpenningClosingController : ControllerBase
    {
        private readonly IOpenningClosing _business;
        public OpenningClosingController(IOpenningClosing OpenClosBusinuss)
        {
            _business = OpenClosBusinuss;
               
        }
        [HttpPost("AddOpenningClosing")]
        public IActionResult AddOpenningClosing(OpenningClosingModel OpenClosModel)
        {
            try
            {
                var res = _business.AddOpenningClosing(OpenClosModel);
                if (res)
                    return Ok("OpenningClosingQties Added Successfully");
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost("GetOpenningClosing")]
        public ActionResult GetOpenningClosing(OpenningClosingModel OpenClosModel)
        {
            try
            {
                var res = _business.GetOpenningClosing(OpenClosModel);
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
