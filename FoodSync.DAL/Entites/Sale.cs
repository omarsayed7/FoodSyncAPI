using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class Sale
    {
        public long Id { get; set; }
        public virtual ICollection<ProductSale> ProductSales { get; set; }
        public virtual Branch Branch { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
