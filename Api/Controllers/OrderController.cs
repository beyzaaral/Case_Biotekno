using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Case_BioTekno.Core.DTOs;
using Case_BioTekno.API.Controllers;
using AutoMapper;
using Entities.Entity;
using Business.Abstract;
using Entities.DTOs;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("add")]
        public IActionResult Add(CreateOrderRequest createOrderRequest)
        {
            var result = _orderService.Add(createOrderRequest);
            //if (result.Success)
            //{
            //    return Ok(result);
            //}
            return BadRequest(result);
        }
    }
}
