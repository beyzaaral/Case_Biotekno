using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entities.Entity;
using Microsoft.Extensions.Hosting;
//using Microsoft.Build.Tasks;
//using RabbitMQ.Client.Events;
//using RabbitMQ.Client;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Core.Common
{
    public class MailSenderBackgroundService : BackgroundService
    {
        private readonly IMailSenderService _mailSenderService;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName = "SendMail";

        public MailSenderBackgroundService(IMailSenderService mailSenderService)
        {
            _mailSenderService = mailSenderService;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

       

       
    }

    public interface IMailSenderService
    {
        Task SendMailAsync(string email, string subject, string message);
    }

    public class MailSenderService : IMailSenderService
    {
        public async Task SendMailAsync(string email, string subject, string message)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("your-email@gmail.com", "your-password"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("your-email@gmail.com"),
                To = { new MailAddress(email) },
                Subject = subject,
                Body = message
            };

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}


