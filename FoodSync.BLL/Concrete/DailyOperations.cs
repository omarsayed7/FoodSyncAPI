using FoodSync.BLL.Abstract;
using FoodSync.BLL.DTOs;
using FoodSync.BLL.Models;
using FoodSync.DAL;
using FoodSync.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodSync.BLL.Concrete
{
    public class DailyOperations : IDailyOperations
    {
        private readonly FoodSyncDbContext _context;
        public DailyOperations(FoodSyncDbContext foodSyncDb)
        {
            _context = foodSyncDb;
        }
        public bool AddDailyOperations(DailyOperationsModel dailyModel)
        {
            if (dailyModel != null)
            {
                var branch = _context.Branches.FirstOrDefault(x => x.Id == dailyModel.BranchId);
                var rawMaterial = _context.RawMaterials.FirstOrDefault(s => s.id == dailyModel.RawMaterialId);

                switch (dailyModel.Type)
                {
                    case "TrsIn":
                        _context.DailyOperations.Add(new DailyOperation()
                        {
                            Branch = branch,
                            RawMaterial = rawMaterial,
                            Date = dailyModel.Date,
                            TrsIn = dailyModel.Qty,
                            FactoryRecivingQty = 0,
                            TrsOut = 0,
                            Waste = 0
                        });
                        break;
                    case "TrsOut":
                        _context.DailyOperations.Add(new DailyOperation()
                        {
                            Branch = branch,
                            RawMaterial = rawMaterial,
                            Date = dailyModel.Date,
                            TrsIn = 0,
                            FactoryRecivingQty = 0,
                            TrsOut = dailyModel.Qty,
                            Waste = 0
                        });
                        break;
                    case "Waste":
                        _context.DailyOperations.Add(new DailyOperation()
                        {
                            Branch = branch,
                            RawMaterial = rawMaterial,
                            Date = dailyModel.Date,
                            TrsIn = 0,
                            FactoryRecivingQty = 0,
                            TrsOut = 0,
                            Waste = dailyModel.Qty
                        });
                        break;
                    case "FactoryRecivingQty":
                        _context.DailyOperations.Add(new DailyOperation()
                        {
                            Branch = branch,
                            RawMaterial = rawMaterial,
                            Date = dailyModel.Date,
                            TrsIn = 0,
                            FactoryRecivingQty = dailyModel.Qty,
                            TrsOut = 0,
                            Waste = 0
                        });
                        break;
                    default:
                        return false;
                }
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<DailyOperationsDTO> GetDailyOperation(DailyOperationsModel dailyModel)
        {
            var dailyDTOs = new List<DailyOperationsDTO>();
            if (dailyModel != null)
            {
                switch (dailyModel.Type)
                {
                    case "TrsIn":
                        dailyDTOs = _context.DailyOperations
                             .Where(x => x.Branch.Id == dailyModel.BranchId && x.Date.Month == dailyModel.Date.Month && x.TrsIn != 0)
                             .Select(s => new DailyOperationsDTO()
                             {
                                 Date = s.Date,
                                 Id = s.Id,
                                 RawMaterial = new RawMaterialDTO()
                                 {
                                     Id = s.RawMaterial.id,
                                     Name = s.RawMaterial.Name,
                                     Unit = s.RawMaterial.Unit
                                 },
                                 Qty = s.TrsIn,
                                 Type = "Transfer In"
                             }).ToList();
                        break;
                    case "TrsOut":
                        dailyDTOs = _context.DailyOperations
                             .Where(x => x.Branch.Id == dailyModel.BranchId && x.Date.Month == dailyModel.Date.Month && x.TrsOut != 0)
                             .Select(s => new DailyOperationsDTO()
                             {
                                 Date = s.Date,
                                 Id = s.Id,
                                 RawMaterial = new RawMaterialDTO()
                                 {
                                     Id = s.RawMaterial.id,
                                     Name = s.RawMaterial.Name,
                                     Unit = s.RawMaterial.Unit
                                 },
                                 Qty = s.TrsOut,
                                 Type = "Transfer Out"
                             })
                             .ToList();
                        break;
                    case "Waste":
                        dailyDTOs = _context.DailyOperations
                             .Where(x => x.Branch.Id == dailyModel.BranchId && x.Date.Month == dailyModel.Date.Month && x.Waste != 0)
                             .Select(s => new DailyOperationsDTO()
                             {
                                 Date = s.Date,
                                 Id = s.Id,
                                 RawMaterial = new RawMaterialDTO()
                                 {
                                     Id = s.RawMaterial.id,
                                     Name = s.RawMaterial.Name,
                                     Unit = s.RawMaterial.Unit
                                 },
                                 Qty = s.Waste,
                                 Type = "Waste"
                             }).ToList();
                        break;
                    case "FactoryRecivingQty":
                        dailyDTOs = _context.DailyOperations
                             .Where(x => x.Branch.Id == dailyModel.BranchId && x.Date.Month == dailyModel.Date.Month && x.FactoryRecivingQty != 0)
                             .Select(s => new DailyOperationsDTO()
                             {
                                 Date = s.Date,
                                 Id = s.Id,
                                 RawMaterial = new RawMaterialDTO()
                                 {
                                     Id = s.RawMaterial.id,
                                     Name = s.RawMaterial.Name,
                                     Unit = s.RawMaterial.Unit
                                 },
                                 Qty = s.FactoryRecivingQty,
                                 Type = "Factory"
                             }).ToList();
                        break;
                    default:
                        return null;

                }
                return dailyDTOs;
            }
            return null;
        }
    }
}
