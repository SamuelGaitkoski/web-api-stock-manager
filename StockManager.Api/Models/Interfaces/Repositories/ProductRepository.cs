using StockManager.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api.Models.Interfaces.Repositories
{
    // On the interface we don't set the implementation of the methods of the repository, we just set the methods and ther signature,
    // so our repository class will implement the interface/contract and then will be mandatory for the class to implement the methods
    // set in the interface.
    public interface ProductRepository
    {
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
        Product GetById(int id);
        List<Product> GetList();
    }
}
