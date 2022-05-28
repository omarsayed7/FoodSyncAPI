using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.DTOs
{
    public class SaleDTO
    {
        public List<ProductDTO> products { get; set; }
        public long Id { get; set; }
        public DateTime SaleTime { get; set; }
    }
}
