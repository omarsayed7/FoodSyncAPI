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
    public class SalesController : ControllerBase
    {
        private readonly ISales _business;
        public SalesController(ISales sales)
        {
            _business = sales;
        }
        [HttpPost("AddSale")]
        public ActionResult AddSale(SaleModel sale)
        {
            try
            {
                var res = _business.AddSale(sale);
                if (res)
                    return Ok("Sale Added Successfully");
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost("GetSales")]
        public ActionResult GetSales(GetSaleModel getSaleModel)
        {
            try
            {
                var res = _business.GetSales(getSaleModel);
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
