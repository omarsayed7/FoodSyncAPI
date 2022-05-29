using FoodSync.BLL.Abstract;
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
    public class DailyOperationsController : ControllerBase
    {
        private readonly IDailyOperations _business;
        public DailyOperationsController(IDailyOperations DailyOperations)
        {
            _business = DailyOperations;
        }
        [HttpPost("AddDailyOperations")]
        public IActionResult AddDailyOperations(DailyOperationsModel dailyModel)
        {
            try
            {
                var res = _business.AddDailyOperations(dailyModel);
                if (res)
                    return Ok("DailyOperation Added Successfully");
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost("GetDailyOperation")]
        public ActionResult GetDailyOperation(DailyOperationsModel dailyOperation)
        {
            try
            {
                var res = _business.GetDailyOperation(dailyOperation);
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
