using StockManager.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api.Models.Dtos
{
    // Simpler object
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Enabled { get; set; }

        // Method to convert the DTO object to entity
        public Product ConvertToEntity()
        {
            if (this == null)
                return null;

            Product result = new Product
            {
                ProductId = this.ProductId,
                Name = this.Name,
                RegisterDate = this.RegisterDate,
                Enabled = this.Enabled
            };

            return result;
        }

        public static Product ConvertToEntity(ProductDto product)
        {
            if (product == null)
                return null;

            Product result = new Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                RegisterDate = product.RegisterDate,
                Enabled = product.Enabled
            };

            return result;
        }

        // The method's signature changes, that's why we can use the same method's name for the 3 of them.
        public static List<Product> ConvertToEntity(List<ProductDto> products)
        {
            if (products == null || products.Count == 0)
                return null;

            List<Product> result = new List<Product>();

            foreach (ProductDto product in products)
            {
                Product item = ConvertToEntity(product);
                result.Add(item);
            }

            return result;
        }

    }
}
