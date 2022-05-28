using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ProductRawMaterial> ProductRawMaterials { get; set; }
        public virtual ICollection<ProductSale> ProductSales { get; set; }

    }
}
