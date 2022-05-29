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
    public class DailyOperaionsController : ControllerBase
    {
        private readonly IDailyOperaions _business;

        public DailyOperaionsController(IDailyOperaions dailyOperation)
        {
            _business = dailyOperation;
        }

    }
}
