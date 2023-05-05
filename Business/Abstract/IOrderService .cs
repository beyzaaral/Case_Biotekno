using Core.Results;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(ProductDto productDto);
        object Add(CreateOrderRequest createOrderRequest);
    }
}
