using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Case_BioTekno.Core.DTOs;
using Case_BioTekno.API.Controllers;
using AutoMapper;
using Entities.Entity;
using Business.Abstract;
using Entities.DTOs;
using Business.Concrete;
using Microsoft.EntityFrameworkCore;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.Caching.Memory;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        ProductManager _productManager;
        

        public ProductsController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<ProductDto>>> GetProducts(string category)
        {
            //var cacheKey = "products_" + category;
            //var cachedProducts = MemoryCache.Get<List<ProductDto>>(cacheKey);
            //if (cachedProducts != null)
            //{
            //    return Ok(cachedProducts);
            //}

            using var context = new Context();
            var products = await context.Products.Where(p => category == null || p.Category == category).ToListAsync();
            if (products == null)
            {
                return NotFound("Could not retrieve products from the database.");
            }

            //_memoryCache.Set(cacheKey, products);

            return Ok(products);
        }
    }
}
