using FoodSync.BLL.DTOs;
using FoodSync.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.Abstract
{
    public interface IDailyOperations
    {
        bool AddDailyOperations(DailyOperationsModel dailyModel);
        List<DailyOperationsDTO> GetDailyOperation(DailyOperationsModel dailyModel);
    }
}
