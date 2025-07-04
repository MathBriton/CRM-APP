using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmApp.Application.Services.Interface
{
    public interface IEmailService
    {
        Task EnviarAsync(string para, string assunto, string corpo);
    }
}
