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
    public class ConsumbtionController : ControllerBase
    {
        private readonly IConsumbtion _business;
        public ConsumbtionController(IConsumbtion consumbtion)
        {
            _business = consumbtion;
        }
        [HttpPost("CalculateConsumbtion")]
        public ActionResult CalculateConsummbtion(string month, long branchId)
        {
            try
            {
                var res = _business.CalculateConsumbtion(month, branchId);
                if (res.Count == 0)
                    return NotFound();
            return Ok(res);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
