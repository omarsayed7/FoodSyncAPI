using FoodSync.BLL.Abstract;
using FoodSync.BLL.DTOs;
using FoodSync.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodSync.BLL.Concrete
{
    public class RawMaterialBusiness : IRawMaterial
    {
        private readonly FoodSyncDbContext _context;
        public RawMaterialBusiness(FoodSyncDbContext foodSyncDb)
        {
            _context = foodSyncDb;
        }
        public List<RawMaterialDTO> GetRMByBrandId(long brandId)
        {
            var rawMaterials = _context.RawMaterials.Where(x => x.Brands.FirstOrDefault(u => u.Id == brandId) != null).Select(s => new RawMaterialDTO()
            {
                Id = s.id,
                Name = s.Name,
                Unit = s.Unit,
            }).ToList();
            if (rawMaterials != null)
                return rawMaterials;
            return null;
        }
    }
}
