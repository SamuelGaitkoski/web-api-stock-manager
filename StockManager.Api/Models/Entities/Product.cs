using StockManager.Api.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api.Models.Entities
{
    // Entity class, will represent our table in the future.
    public class Product
    {
        // Properties
        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Enabled { get; set; }

        // Methods to convert the entity object to DTO.
        // Converting the own object from entity to DTO.
        public ProductDto ConvertToDto()
        {
            if (this == null)
                return null;

            ProductDto result = new ProductDto
            {
                ProductId = this.ProductId,
                Name = this.Name,
                RegisterDate = this.RegisterDate,
                Enabled = this.Enabled
            };

            return result;
        }

        public static ProductDto ConvertToDto(Product product)
        {
            if (product == null)
                return null;

            ProductDto result = new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                RegisterDate = product.RegisterDate,
                Enabled = product.Enabled
            };

            return result;
        }

        public static List<ProductDto> ConvertToDto(List<Product> products)
        {
            if (products == null || products.Count == 0)
                return null;

            List<ProductDto> result = new List<ProductDto>();

            // loop using foreach
            foreach(Product product in products)
            {
                ProductDto item = ConvertToDto(product);
                result.Add(item);
            }      

            return result;
        }

        // Business rules
        public void Create()
        {
            RegisterDate = DateTime.Now;
            Enabled = true;
        }

        // Logical deletion, keeping the history
        public void Delete()
        {
            Enabled = false;
        }
    }
}
