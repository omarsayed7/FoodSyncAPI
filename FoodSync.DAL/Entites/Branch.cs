using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class Branch
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<OpenningClosingQty> OpenningClosingQties { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<DailyOperation> DailyOperations { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Consumption> Consumptions { get; set; }
        public string BranchCode { get; set; }

        public void AddNewBranch(double transIn)
        {
            throw new System.NotImplementedException();
        }

        public void EditExistingBranch(double transIn)
        {
            throw new System.NotImplementedException();
        }
        public void DeleteBranch(double transIn)
        {
            throw new System.NotImplementedException();
        }
       
    }
}
