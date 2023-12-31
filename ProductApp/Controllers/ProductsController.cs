﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /*
         - istekler atıldığında konsolda yapılan işlem hakkında loglama yapmak için
         - readonly olduğu için ya constructorda yada tanımladığın gibi değer vermelisin 
         */
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProducts() {
            var products = new List<Product>() { 
                new Product() { Id = 1, ProductName = "Computer"},
                new Product() { Id = 2, ProductName = "Keyboard"},
                new Product() { Id = 3, ProductName = "Mouse"},
            };
            _logger.LogInformation("GetAllProducts action has been called");
            return Ok(products);
        }

        [HttpPost]
        public IActionResult GetAllProducts([FromBody] Product product)
        {
            _logger.LogInformation("Product has been created");
            return StatusCode(201);
        }

    }
}
