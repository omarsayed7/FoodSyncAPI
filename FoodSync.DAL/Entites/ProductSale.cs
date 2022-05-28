using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class ProductSale
    {
        public long Id { get; set; }
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public virtual Sale Sale { get; set; }
        public long SaleId { get; set; }
        public long Quantity { get; set; }
    }
}
