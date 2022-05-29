using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.Models
{
    public class DailyOperationsModel
    {
        public DateTime Date{ get; set; }
        public string Type { get; set; }
        public long BranchId { get; set; }
        public long RawMaterialId { get; set; }
        public double Qty { get; set; }
    }
}
