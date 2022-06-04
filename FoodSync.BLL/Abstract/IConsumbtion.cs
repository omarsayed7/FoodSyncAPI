using FoodSync.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.Abstract
{
    public interface IConsumbtion
    {
        List<ConsumbtionDTO> CalculateConsumbtion(string month, long branchId);
    }
}
