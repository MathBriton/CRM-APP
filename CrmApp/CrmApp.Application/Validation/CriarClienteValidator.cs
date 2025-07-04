using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmApp.Application.DTOs;
using FluentValidation;

namespace CrmApp.Application.Validation
{
    public class CriarClienteValidator : AbstractValidator<CriarClienteDTO>
    {
        public CriarClienteValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().MinimumLength(3);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Cpf).NotEmpty().Length(11);
        }
    }
}
