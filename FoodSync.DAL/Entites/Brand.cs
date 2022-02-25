using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public string LogoUrl { get; set; }
        public virtual ICollection<RawMaterial> RawMaterials { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
