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
    public class UserController : ControllerBase
    {
        private readonly IUser _business;
        public UserController(IUser user)
        {
            _business = user;
        }

        [HttpPost("Login")]
        public ActionResult Login(UserModel user)
        {
            try
            {
                var res = _business.Login(user);
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
