using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class Consumption
    {
        public long Id { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public double FinalRecord { get; set; }
        public virtual Branch Branch { get; set; }

        public void CalculateConsumptionReport(double transIn)
        {
            throw new System.NotImplementedException();
        }

        public void SaveReport(double transIn)
        {
            throw new System.NotImplementedException();
        }
    }
}
