using FoodSync.BLL.DTOs;
using FoodSync.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.Abstract
{
    public interface ISales
    {
        bool AddSale(SaleModel sale);
        List<SaleDTO> GetSales(GetSaleModel saleModel);
    }
}
