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
        public virtual ICollection<RawMaterial> RawMaterials { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }


        public void AddNewProduct(double transIn)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteExistingProduct(double transIn)
        {
            throw new System.NotImplementedException();
        }
        public void AddProductRawMaterials(double transIn)
        {
            throw new System.NotImplementedException();
        }
        public void EditProductInfo(double transIn)
        {
            throw new System.NotImplementedException();
        }
       
    }
}
