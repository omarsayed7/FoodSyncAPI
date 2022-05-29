using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.DTOs
{
    public class DailyOperationsDTO
    {
        public DateTime Date { get; set; }
        public long Id { get; set; }
        public RawMaterialDTO RawMaterial { get; set; }
        public double Qty { get; set; }
        public string Type { get; set; }
    }
}
