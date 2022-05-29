using FoodSync.BLL.DTOs;
using FoodSync.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.BLL.Abstract
{
    public interface IOpenningClosing
    {
        public bool AddOpenningClosing(OpenningClosingModel openCloseModel);
        public List<OpenningClosingDTO> GetOpenningClosing(OpenningClosingModel openCloseModel);
    }
}
