using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.Models
{
    public class SaleModel
    {
        public long BranchId { get; set; }
        public List<ProductModel> products { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
