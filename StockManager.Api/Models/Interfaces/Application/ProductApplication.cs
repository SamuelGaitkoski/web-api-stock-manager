using StockManager.Api.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api.Models.Interfaces.Application
{
    public interface ProductApplication
    {
        void Create(ProductDto product);
        void Update(ProductDto product);
        void Delete(int id);
        ProductDto GetById(int id);
        List<ProductDto> GetList();
    }
}
