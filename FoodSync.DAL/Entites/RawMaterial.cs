using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class RawMaterial
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public virtual ICollection<ProductRawMaterial> productRawMaterials { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<OpenningClosingQty> OpenningClosingQties { get; set; }
        public virtual ICollection<DailyOperation> DailyOperations { get; set; }
               }

}
