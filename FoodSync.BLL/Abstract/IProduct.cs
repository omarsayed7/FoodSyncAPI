using FoodSync.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.Abstract
{
    public interface IProduct
    {
        List<ProductDTO> GetProductsByBrand(long brandId);
    }
}
