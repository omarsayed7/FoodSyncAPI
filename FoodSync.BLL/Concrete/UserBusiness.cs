using FoodSync.BLL.Abstract;
using FoodSync.BLL.DTOs;
using FoodSync.BLL.Models;
using FoodSync.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodSync.BLL.Concrete
{
    public class UserBusiness : IUser
    {
        private readonly FoodSyncDbContext _context;
        public UserBusiness(FoodSyncDbContext foodSyncDb)
        {
            _context = foodSyncDb;
        }

        public UserDTO Login(UserModel user)
        {
            var loggedUser = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            var loggedBrand = _context.Brands.FirstOrDefault(x => x.Branches.FirstOrDefault(f => f.Id == loggedUser.BranchId) != null);

            UserDTO userInfo = new UserDTO()
            {
                Id = loggedUser.Id,
                Role = loggedUser.role,
                BranchId = loggedUser.BranchId,
                BranchName = loggedUser.Branch.Name,
                BranchCode = loggedUser.Branch.BranchCode,
                BrandId = loggedBrand.Id,
                BrandName = loggedBrand.Name,
                LogoURL = loggedBrand.LogoUrl,
                Theme = loggedBrand.Theme,
            };
            if (userInfo != null)
                return userInfo;
            return null;

        }
    }
}
