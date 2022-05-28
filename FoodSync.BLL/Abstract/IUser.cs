using FoodSync.BLL.DTOs;
using FoodSync.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.Abstract
{
    public interface IUser
    {
        UserDTO Login(UserModel user);
    }
}
