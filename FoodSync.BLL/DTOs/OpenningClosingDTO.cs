using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.DTOs
{
    public class OpenningClosingDTO
    {
        public long Id { get; set; }
        public RawMaterialDTO RawMaterial { get; set; }
        public double Qty { get; set; }
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
