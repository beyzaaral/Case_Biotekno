using Business.Abstract;
using Business.Constants;
using Core.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        IProductDal _productDal;
        public OrderManager(IProductDal productDal, IOrderDal orderDal)
        {
            _productDal = productDal;
            _orderDal = orderDal;
        }

        public IResult Add(ProductDto productDto)
        {
            var products = _productDal.GetById(productDto.Id);
            Product product = new Product()
            {
                Name = productDto.Name,
                Id = productDto.Id,
                Unit = productDto.Unit,
                UnitPrice = productDto.UnitPrice,
                Category = productDto.Category,
                Description = productDto.Description,
            };
            _productDal.Add(product);
            return new SuccessResult(Messages.AddedSuccessMessage);
        }

        public object Add(CreateOrderRequest createOrderRequest)
        {
            throw new NotImplementedException();
        }
    }
}
