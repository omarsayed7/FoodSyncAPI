using System;
using System.Collections.Generic;
using System.Text;

namespace FoodSync.DAL.Entites
{
    public class OpenningClosingQty
    {
        public long Id { get; set; }
        public Months Months { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
        public double OpenningQty { get; set; }
        public double ClosingQty { get; set; }
    }

    public enum Months
    {
        Jan = 1,
        Feb = 2,
        Mar = 3,
        Apr = 4,
        May = 5,
        Jun = 6,
        Jul = 7,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12,

    }
}
