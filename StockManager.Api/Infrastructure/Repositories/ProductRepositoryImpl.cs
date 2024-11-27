using StockManager.Api.Infrastructure.Contexts;
using StockManager.Api.Models.Entities;
using StockManager.Api.Models.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api.Infrastructure.Repositories
{
    // Repository in the Infrastructure layer
    // ProductRepositoryImplementation
    // Our repository class will implement the interface/contract ProductRepository.
    // The class gotta implement everything is defined on the interface, class gotta implement the interface.
    public class ProductRepositoryImpl : ProductRepository
    {
        // Database object
        private SimpleDatabase _database;

        // Implementing the Dependency Injection (DI) for this object SimpleDatabase, this way we use the DI configuration for the
        // class on the Startup class.
        public ProductRepositoryImpl(SimpleDatabase database)
        {
            _database = database;
        }

        public void Create(Product product)
        {
            _database.Create(product);
        }

        public void Delete(int id)
        {
            _database.Delete(id);
        }

        public Product GetById(int id)
        {
            return _database.GetById(id);
        }

        public List<Product> GetList()
        {
            return _database.Get();
        }

        public void Update(Product product)
        {
            _database.Update(product);
        }
    }
}
