using StockManager.Api.Models.Dtos;
using StockManager.Api.Models.Entities;
using StockManager.Api.Models.Interfaces.Application;
using StockManager.Api.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api.Infrastructure.Application
{
    // The Application layer is the one responsible for receiving the dto object from the controller layer, converting the dto object
    // to entity and passing it to the service layer.
    public class ProductApplicationImpl : ProductApplication
    {
        private readonly ProductService _service;

        // Configuring the service object by Dependency Injection, injecting the object here through our class construtor.
        public ProductApplicationImpl(ProductService service)
        {
            _service = service;
        }

        public void Create(ProductDto product)
        {
            try
            {
                Product entity = product.ConvertToEntity();
                entity.Create();

                _service.Create(entity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDto GetById(int id)
        {
            try
            {
                Product product = _service.GetById(id);
                if (product == null)
                    return null;

                // if the object product is null it's not possible to invoke the method ConvertToDto, so if it happens we'll receive an error,
                // that's why we'll validate it above.
                ProductDto result = product.ConvertToDto();
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductDto> GetList()
        {
            try
            {
                List<Product> products = _service.GetList();
                List<ProductDto> result = Product.ConvertToDto(products);
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(ProductDto product)
        {
            try
            {
                Product entity = product.ConvertToEntity();

                _service.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
