using StockManager.Api.Models.Dtos;
using StockManager.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api.Infrastructure.Contexts
{
    // SimpleDatabase layer
    public class SimpleDatabase
    {
        // Collection
        private List<Product> products = null;

        public SimpleDatabase()
        {
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            Product product1 = new Product
            {
                ProductId = 1,
                Name = "Mouse",
                RegisterDate = DateTime.Now,
                Enabled = true
            };

            Product product2 = new Product
            {
                ProductId = 2,
                Name = "Book of Dev C# .Net Core",
                RegisterDate = DateTime.Now,
                Enabled = true
            };

            Product product3 = new Product
            {
                ProductId = 3,
                Name = "Wireless Keyboard",
                RegisterDate = DateTime.Now,
                Enabled = true
            };

            Product product4 = new Product
            {
                ProductId = 4,
                Name = "Gamer Controller For PC",
                RegisterDate = DateTime.Now,
                Enabled = true
            };

            Product product5 = new Product
            {
                ProductId = 5,
                Name = "Notebook 15' 8 GB Ram, i5 processor",
                RegisterDate = DateTime.Now,
                Enabled = true
            };

            if (products == null || products.Count.Equals(0))
            {
                products = new List<Product>();

                products.AddRange(new List<Product>
                {
                    product1,
                    product2,
                    product3,
                    product4,
                    product5
                });
            }        
        }

        public List<Product> Get()
        {
            // Sorting the Products List
            return products
                .OrderBy(p => p.ProductId)
                .ToList();
        }

        public Product GetById(int id)
        {
            return products
                .FirstOrDefault(p => p.ProductId.Equals(id));
        }

        public void Create(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            Product search = GetById(product.ProductId);
            bool deleted = Delete(product.ProductId);
            if (deleted)
            {
                // Keeping the values on these properties.
                product.RegisterDate = search.RegisterDate;
                product.Enabled = search.Enabled;

                Create(product);
            }               
        }

        public bool Delete(int id)
        {
            Product product = GetById(id);
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }
    }
}
