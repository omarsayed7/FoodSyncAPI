﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class Sale
    {
        public long Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual Branch Branch { get; set; }
        public long SaleQty { get; set; }

        public void AddSale(double transIn)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSale(double transIn)
        {
            throw new System.NotImplementedException();
        }
    }
}
