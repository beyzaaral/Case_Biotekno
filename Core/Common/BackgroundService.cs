using Entities.Entity;
using Infrastructure.Abstract;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Web.Http;

namespace Core.Common
{
    public class BackgroundService:IHostedService
    {
        private object _backgroundTaskQueue;
        

        // GetProducts metodu
        [HttpGet]
        public IActionResult GetProducts()
        {
            // Ürünleri veritabanından çekme veya başka bir kaynaktan alma işlemleri

            var products = _productRepository.GetAllProducts();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        private IActionResult Ok(object products)
        {
            throw new NotImplementedException();
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }




        // CreateOrder metodu
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            // Yeni siparişi veritabanına kaydetme işlemleri

            //_orderRepository.AddOrder(order);

            // SendMail kuyruğuna asenkron bir şekilde mail gönderim isteği yazma işlemleri
            //_backgroundTaskQueue.QueueBackgroundWorkItem(async token =>
            //{
            //    await _mailSender.SendMailAsync(order.CustomerEmail, "Siparişiniz alındı", "Siparişiniz alındı, teşekkür ederiz.");
            //});

            return CreatedAtRoute("GetOrder", new { id = order.Id }, order);
        }

        private IActionResult BadRequest()
        {
            throw new NotImplementedException();
        }

        private IActionResult CreatedAtRoute(string v, object value, Order order)
        {
            throw new NotImplementedException();
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

       

        public void ExecutAsync()
        {
            throw new NotImplementedException();
        }
    }

    internal class _productRepository
    {
        internal static object GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}