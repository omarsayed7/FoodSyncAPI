using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.DTOs
{
    public class UserDTO
    {
        public long BrandId { get; set; }
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string BrandName { get; set; }
        public string LogoURL { get; set; }
        public string Theme { get; set; }
        public long Id { get; set; }
        public string Role { get; set; }
        public string BranchCode { get; set; }


    }
}
