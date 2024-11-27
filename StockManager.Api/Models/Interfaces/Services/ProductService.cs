using StockManager.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api.Models.Interfaces.Services
{
    public interface ProductService
    {
        // Added the reference for the Product entity here.
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
        Product GetById(int id);
        List<Product> GetList();
    }
}
