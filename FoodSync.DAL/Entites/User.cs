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

        public void SignUp(double transIn)
        {
            throw new System.NotImplementedException();
        }

        public void Login(double transIn)
        {
            throw new System.NotImplementedException();
        }
        public void ValidateCredentials(double transIn)
        {
            throw new System.NotImplementedException();
        }
        public void Logout(double transIn)
        {
            throw new System.NotImplementedException();
        }
    }
}
