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
    public class OpenningClosingBusiness : IOpenningClosing
    {
        private readonly FoodSyncDbContext _context;
        public OpenningClosingBusiness(FoodSyncDbContext foodSyncDb)
        {
            _context = foodSyncDb;
        }
        public bool AddOpenningClosing(OpenningClosingModel openClosModel)
        {
            if (openClosModel != null)
            {
                var branch = _context.Branches.FirstOrDefault(x => x.Id == openClosModel.BranchId);
                var rawMaterial = _context.RawMaterials.FirstOrDefault(x => x.id == openClosModel.RawMaterialId);

                switch (openClosModel.Type)
                {
                    case "OpenningQty":
                        _context.OpenningClosingQties.Add(new OpenningClosingQty()
                        {
                            OpenningQty = openClosModel.Qty,
                            Branch = branch,
                            RawMaterial = rawMaterial,
                            Months = (DAL.Entites.Months)Enum.Parse(typeof(DAL.Entites.Months), openClosModel.Month)
                        });
                        break;
                    case "ClosingQty":
                        _context.OpenningClosingQties.Add(new OpenningClosingQty()
                        {
                            ClosingQty = openClosModel.Qty,
                            Branch = branch,
                            RawMaterial = rawMaterial,
                            Months = (DAL.Entites.Months)Enum.Parse(typeof(DAL.Entites.Months), openClosModel.Month)
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
        public List<OpenningClosingDTO> GetOpenningClosing(OpenningClosingModel openCloseModel)
        {
            if (openCloseModel != null)
            {
                var openningClosingList = new List<OpenningClosingDTO>();
                var branch = _context.Branches.FirstOrDefault(x => x.Id == openCloseModel.BranchId);
                var selectedMonth = (DAL.Entites.Months)Enum.Parse(typeof(DAL.Entites.Months), openCloseModel.Month);
                switch (openCloseModel.Type)
                {
                    case "OpenningQty":
                        openningClosingList = _context.OpenningClosingQties.Where(x => x.Branch == branch && x.Months == selectedMonth && x.OpenningQty != 0).Select(s => new OpenningClosingDTO()
                        {
                            Id = s.Id,
                            RawMaterial = new RawMaterialDTO()
                            {
                                Id = s.RawMaterial.id,
                                Name = s.RawMaterial.Name,
                                Unit = s.RawMaterial.Unit
                            },
                            Qty = s.OpenningQty,
                            Date = selectedMonth.ToString()

                        }).ToList();
                        break;
                    case "ClosingQty":
                        openningClosingList = _context.OpenningClosingQties.Where(x => x.Branch == branch && x.Months == selectedMonth && x.ClosingQty != 0).Select(s => new OpenningClosingDTO()
                        {
                            Id = s.Id,
                            RawMaterial = new RawMaterialDTO()
                            {
                                Id = s.RawMaterial.id,
                                Name = s.RawMaterial.Name,
                                Unit = s.RawMaterial.Unit
                            },
                            Qty = s.ClosingQty,
                            Date = selectedMonth.ToString()
                        }).ToList();
                        break;
                    default:
                        return null;
                }
                return openningClosingList;
            }
            else
            {
                return null;
            }
        }
    }
}
