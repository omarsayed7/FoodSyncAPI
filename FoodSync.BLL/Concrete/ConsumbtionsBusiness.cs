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
        public List<RawMaterialConsumbtionDto> CalculateConsumbtion(string month, long branchId)
        {
            var selectedMonth = Enum.Parse<DAL.Entites.Months>(month);

            List<ConsumbtionDTO> consumbtions = new List<ConsumbtionDTO>();
            List<RawMaterialConsumbtionDto> rawMaterialConsumbtions = new List<RawMaterialConsumbtionDto>();

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
                var salesQty = SaleToRawMaterial(selectedMonth, quantity.RawMaterialId, branchId);

                var dublicate = consumbtions.Where(x => x.RawMaterialId == quantity.RawMaterialId).FirstOrDefault();
                quantity.SaleQuantity = salesQty;
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
            foreach (var consumbtion in consumbtions)
            {
                var consumbtionQty = (consumbtion.FactoryRecieving + consumbtion.TransferIn + consumbtion.OpeningQuantity) - (consumbtion.SaleQuantity + consumbtion.TransferOut + consumbtion.Waste);
                rawMaterialConsumbtions.Add(new RawMaterialConsumbtionDto()
                {
                    RawMaterialId = consumbtion.RawMaterialId,
                    RawMaterialName = consumbtion.RawMaterialName,
                    FinalConsumbtion = consumbtion.ClosingQuantity - consumbtionQty
                });
            }
            return rawMaterialConsumbtions;
        }


        public double SaleToRawMaterial (DAL.Entites.Months month, long rawMaterialId, long branchId)
        {
            double saleQuantity = 0;
            var quantities = (from s in _context.ProductSales
                              join sa in _context.Sales
                              on s.SaleId equals sa.Id
                              join e in _context.Products
                              on s.ProductId equals e.Id
                              where (sa.SaleDate.Month.ToString() == ((int)month).ToString() && e.ProductRawMaterials.FirstOrDefault(x => x.RawMaterialId == rawMaterialId) != null && sa.Branch.Id == branchId)
                              select new
                              {
                                  ProductRawMaterial = e.ProductRawMaterials.FirstOrDefault(x => x.RawMaterialId == rawMaterialId),
                                  SaleId = sa.Id

                              }).ToList();

            foreach (var quantity in quantities)
            {
                saleQuantity += quantity.ProductRawMaterial.Quantity;
            }
            return saleQuantity;
        }
    }
}
