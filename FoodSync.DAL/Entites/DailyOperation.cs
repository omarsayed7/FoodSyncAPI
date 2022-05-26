using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class DailyOperation
    {
        public long Id { get; set; }
        public double TrsIn { get; set; }
        public double TrsOut { get; set; }
        public double Waste { get; set; }
        public double FactoryRecivingQty { get; set; }
        public DateTime Date { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }

        public void AddTransIn(double transIn)
        {
            throw new System.NotImplementedException();
        }

        public void AddTransOut(double transIn)
        {
            throw new System.NotImplementedException();
        }
        public void AddWaste(double transIn)
        {
            throw new System.NotImplementedException();
        }
        public void AddFactoryReciving(double transIn)
        {
            throw new System.NotImplementedException();
        }
        public void Submit(double transIn)
        {
            throw new System.NotImplementedException();
        }

    }
}
