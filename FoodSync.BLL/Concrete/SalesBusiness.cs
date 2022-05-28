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
    public class SalesBusiness : ISales
    {
        private readonly FoodSyncDbContext _context;
        public SalesBusiness(FoodSyncDbContext foodSyncDb)
        {
            _context = foodSyncDb;
        }
        public bool AddSale(SaleModel sale)
        {
            if (sale.products.Count == 0 )
                return false;
            var branch = _context.Branches.FirstOrDefault(x => x.Id == sale.BranchId);
            List<ProductSale> selectedProducts = new List<ProductSale>();
            foreach (var product in sale.products)
            {
                selectedProducts.Add(new ProductSale()
                {
                    ProductId = product.Id,
                    Quantity = product.Qty,
                });
            }
            _context.Sales.Add(new Sale()
            {
                Branch = branch,
                SaleDate = sale.SaleDate,
                ProductSales = selectedProducts,
            });
            _context.SaveChanges();
            return true;
        }

        public List<SaleDTO> GetSales(GetSaleModel saleModel)
        {
            List<SaleDTO> saleDTOs = new List<SaleDTO>();
            var sales = _context.Sales
                    .Where(x => x.Branch.Id == saleModel.BranchId && x.SaleDate.Month == saleModel.SalesDate.Month)
                    .ToList();
            foreach (var sale in sales)
            {
                var selectedProducts = sale.ProductSales.Select(s => s.Product).ToList();
                    //_context.Products.Where(x => x.ProductSales.Where(x => x.SaleId == sale.Id).Any()).ToList();
                var saleProducts =sale.ProductSales
                    .Select(s => new ProductDTO()
                    {
                        Id =s.ProductId,
                        Qty = s.Quantity,
                        Name = selectedProducts.FirstOrDefault(x => x.Id == s.ProductId).Name
                    })
                    .ToList();
                saleDTOs.Add(new SaleDTO()
                {
                    Id = sale.Id,
                    SaleTime = sale.SaleDate,
                    products = saleProducts
                });
            }
            return saleDTOs;
        }
    }
}
