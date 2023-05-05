using Core.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Results.IResult;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts(string category);
        IResult Add(ProductDto productDto);
    }
}
