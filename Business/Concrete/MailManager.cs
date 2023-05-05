using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MailManager : IMailService
    {
        public Task<bool> SendMailAsync(string toEmail, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
