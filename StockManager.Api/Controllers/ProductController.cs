// References
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManager.Api.Infrastructure.Contexts;
using StockManager.Api.Models.Dtos;
using StockManager.Api.Models.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api.Controllers
{
    // API -> API Controller - Empty
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Creating of an object for the database
        // private readonly SimpleDatabase database;
        private readonly ProductApplication _application;

        // Passing the object in the construtor's parameters/signature, for Dependency Injection, that way our configuration for the
        // SimpleDatabase class on Startup class will work. This way our configuration for the object will work and the object will be
        // instanciated and initialized just once time till we stop running our application and not on every request we do while running the
        // application.
        public ProductController(ProductApplication application)
        {
            // Instance of a new SimpleDatabase's object
            // database = new SimpleDatabase();
            // Dependency Injection on the object
            // this.database = database;
            _application = application;
        }

        // Named the method using the standard API Restful definitions.
        // Verb HttpGet.
        [HttpGet]
        public List<ProductDto> Get()
        {
            // SimpleDatabase database = new SimpleDatabase();
            // List<ProductDto> result = database.products;
            List<ProductDto> result = _application.GetList();
            return result;
        }

        // GET request with URL parameters
        [HttpGet]
        [Route("{id}")]
        public ProductDto Get(int id)
        {
            // SimpleDatabase database = new SimpleDatabase();
            // ProductDto result = database.products.FirstOrDefault(p => p.ProductId.Equals(id));
            ProductDto result = _application.GetById(id);
            return result;
        }

        // Using of Postman for POST request.
        // Changing the HTTP verb annotation the parameters are expected to be on the request's body, not on the url anymore, as its when
        // We use the HTTP verb HttpPost.
        // With the Bind configuration we set just the properties ProductId and Name will be received in the ProcuctDto's object as
        // productid and name, and they will be the only parameters sent to the objecy of the parameters of the method.
        // That's how the JSON will be sent in the request's body: { "productid": 7, "name": "Smartphone" }
        // If everything goes fine, we'll receive a status code 200 (Ok) after sending the request.
        [HttpPost]
        public string Post([Bind("productid, name")]ProductDto product)
        {
            // Setting values for the rest of the object's properties here.
            // product.RegisterDate = DateTime.Now;
            // product.Active = true;
            // Add product on the collection.
            // database.products.Add(product);
            _application.Create(product);
            return "Product is created successfully";
        }

        [HttpPut]
        public string Put([Bind("productid, name")] ProductDto product)
        {
            _application.Update(product);
            return "Product is updated successfully";
        }

        [HttpDelete]
        [Route("{id}")]
        public string Delete(int id)
        {
            _application.Delete(id);
            return "Product is deleted successfully";
        }
    }
}
