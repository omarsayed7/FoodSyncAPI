using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class ProductRawMaterial
    {
        public int Id { get; set; }
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        public long RawMaterialId { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
        public float Quantity { get; set; }
    }
}
