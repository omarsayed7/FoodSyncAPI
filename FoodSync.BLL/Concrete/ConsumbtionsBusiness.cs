using FoodSync.DAL;
using FoodSync.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FoodSync.BLL.DTOs;
using FoodSync.BLL.Abstract;

namespace FoodSync.BLL.Concrete
{
    public class ConsumbtionsBusiness : IConsumbtion
    {
        private readonly FoodSyncDbContext _context;
        public ConsumbtionsBusiness(FoodSyncDbContext foodSyncDb)
        {
            _context = foodSyncDb;
        }
        public List<ConsumbtionDTO> CalculateConsumbtion(string month, long branchId)
        {
            var selectedMonth = Enum.Parse<Months>(month);

            List<ConsumbtionDTO> consumbtions = new List<ConsumbtionDTO>();

            var quantities = (from s in _context.DailyOperations
                              join sa in _context.RawMaterials
                              on s.RawMaterial.id equals sa.id
                              join e in _context.OpenningClosingQties
                              on sa.id equals e.RawMaterial.id
                              where (s.Date.Month.ToString() == ((int)selectedMonth).ToString() && e.Months == selectedMonth && s.Branch.Id == branchId && e.Branch.Id == branchId)
                              select new ConsumbtionDTO()
                              {
                                  RawMaterialId = sa.id,
                                  RawMaterialName = sa.Name,
                                  TransferIn = s.TrsIn,
                                  TransferOut = s.TrsOut,
                                  Waste = s.Waste,
                                  FactoryRecieving = s.FactoryRecivingQty,
                                  Month = month,
                                  OpeningQuantity = e.OpenningQty,
                                  ClosingQuantity = e.ClosingQty
                              }).ToList();
            foreach (var quantity in quantities)
            {
                var dublicate = consumbtions.Where(x => x.RawMaterialId == quantity.RawMaterialId).FirstOrDefault();
                if (dublicate == null)
                    consumbtions.Add(quantity);
                else
                {
                    dublicate.TransferIn += quantity.TransferIn;
                    dublicate.TransferOut += quantity.TransferOut;
                    dublicate.Waste += quantity.Waste;
                    dublicate.ClosingQuantity += quantity.ClosingQuantity;
                    dublicate.FactoryRecieving += quantity.FactoryRecieving;
                }
            }
            return consumbtions;
        }
    }
}
