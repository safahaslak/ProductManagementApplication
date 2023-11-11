using ProductManagementApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApplication.BL
{
    public class ProductManager : Repository<Entities.Product>  // We send the product class to repository. When ProductManager is used all the methods inside repository will be used by product class       
    {
        public List<ProductListDTO> GetProducts()
        {
            var products = context.Products.Include("Category")
            .Select(x => new ProductListDTO
            {
                CategoryName = x.Category.Name,
                Brand = x.Brand,
                Name = x.Name,
                CreateDate = x.CreateDate,
                Id = x.Id,
                IsActive = x.IsActive,
                Price = x.Price,
                Stock = x.Stock
            }).ToList();
            return products;
        }
    }
}
