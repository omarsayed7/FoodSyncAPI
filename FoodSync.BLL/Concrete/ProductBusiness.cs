using FoodSync.BLL.Abstract;
using FoodSync.BLL.DTOs;
using FoodSync.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodSync.BLL.Concrete
{
    public class ProductBusiness : IProduct
    {
        private readonly FoodSyncDbContext _context;
        public ProductBusiness(FoodSyncDbContext foodSyncDb)
        {
            _context = foodSyncDb;
        }
        public List<ProductDTO> GetProductsByBrand(long brandId)
        {
                var products = _context.Products.Where(x => x.Brand.Id == brandId).Select(s => new ProductDTO()
                {
                    Name = s.Name,
                    ProductId = s.Id,
                }).ToList();
                if (products == null)
                    return null;
                return products;
            
        }
    }
}
