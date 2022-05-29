using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.Models
{
    public class OpenningClosingModel
    {
        public double Qty { get; set; }
        public long BranchId { get; set; }
        public long RawMaterialId { get; set; }
        public string Type { get; set; }
        public string Month { get; set; }

    }
    public enum Months
    {
        Jan = 1,
        Feb = 2,
        Mar = 3,
        Apr = 4,
        May = 5,
        Jun = 6,
        Jul = 7,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12,

    }
}
