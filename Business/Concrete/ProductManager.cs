using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Results;
using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.DTOs;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(10);
        IProductDal _productDal;

        public ProductManager(ApplicationDbContext dbContext, IMemoryCache cache, IProductDal productDal)
        {
            _dbContext = dbContext;
            _cache = cache;
            _productDal = productDal;
        }

        public IResult Add(ProductDto productDto)
        {
            var products = _productDal.GetById(productDto.Id);
            Product product = new Product()
            {
                Name = productDto.Name,
                Id = productDto.Id,
                Category = productDto.Category,
                Unit = productDto.Unit,
                UnitPrice = productDto.UnitPrice,  
            };
            _productDal.Add(product);
            return new SuccessResult(Messages.AddedSuccessMessage);
        }

        public async Task<List<ProductDto>> GetProducts(string category)
        {
            var cacheKey = $"Products_{category}";

            if (_cache.TryGetValue(cacheKey, out List<ProductDto> products))
            {
                return products;
            }

            var query = _dbContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            var result = await query.Select(p => new ProductDto
            {
                Id = p.Id,
                Description = p.Description,
                Category = p.Category,
                Unit = p.Unit,
                UnitPrice = p.UnitPrice
            }).ToListAsync();

            _cache.Set(cacheKey, result, _cacheDuration);

            return result;
        }


    }
}
