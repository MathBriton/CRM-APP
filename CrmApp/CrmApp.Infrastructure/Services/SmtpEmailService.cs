using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmApp.Application.Services.Interface;

namespace CrmApp.Infrastructure.Services
{
    public class SmtpEmailService : IEmailService
    {
        public async Task EnviarAsync(string para, string assunto, string corpo)
        {
            // Implementar envio real com MailKit ou outro
        }
    }
}
