using StockManager.Api.Models.Entities;
using StockManager.Api.Models.Interfaces.Repositories;
using StockManager.Api.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api.Infrastructure.Services
{
    // Service layer is the intermediate class between our controller and our repository.
    // This class is important because our controller will know this class, also because the controller doesn't need to understand
    // how our repository works, so the controller class will just call the service methods and the service will call the repository
    // methods.
    public class ProductServiceImpl : ProductService
    {
        private readonly ProductRepository _repository;

        // Injecting the repository object in our service class, for the we don't use the class, just the repository contract.
        public ProductServiceImpl(ProductRepository repository)
        {
            _repository = repository;
        }

        public void Create(Product product)
        {
            _repository.Create(product);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Product> GetList()
        {
            return _repository.GetList();
        }

        public void Update(Product product)
        {
            _repository.Update(product);
        }
    }
}
