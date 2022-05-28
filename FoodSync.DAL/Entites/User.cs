using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string role { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
