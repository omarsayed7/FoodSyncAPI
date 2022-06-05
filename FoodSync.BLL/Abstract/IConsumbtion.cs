using FoodSync.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.Abstract
{
    public interface IConsumbtion
    {
        List<RawMaterialConsumbtionDto> CalculateConsumbtion(string month, long branchId);
    }
}
