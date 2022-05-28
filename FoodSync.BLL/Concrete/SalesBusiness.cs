using FoodSync.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.Concrete
{
    public class SalesBusiness
    {
        private readonly FoodSyncDbContext _context;
        public SalesBusiness(FoodSyncDbContext foodSyncDb)
        {
            _context = foodSyncDb;
        }
        //public string AddSale(SaleModel sale)
        //{

        //}
    }
}
