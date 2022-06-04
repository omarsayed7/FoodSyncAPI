using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.DTOs
{
    public class ConsumbtionDTO
    {
        public long RawMaterialId { get; set; }
        public string RawMaterialName { get; set; }
        public string Month { get; set; }
        public double TransferIn { get; set; }
        public double TransferOut { get; set; }

        public double Waste { get; set; }

        public double FactoryRecieving { get; set; }

        public double OpeningQuantity { get; set; }

        public double ClosingQuantity { get; set; }



    }
}
