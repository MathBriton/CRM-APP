using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrmApp.Application.DTOs;
using CrmApp.Domain.Entities;
using CrmApp.Domain.Repository;
using CrmApp.Domain.ValueObjects;

namespace CrmApp.Application.UseCase
{
    public class CriarClienteUseCase
    {
        private readonly IClienteRepository _repo;

        public CriarClienteUseCase (IClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> ExecutarAsync(CriarClienteDTO dto)
        {
            var cliente = new Cliente(
                new Nome(dto.Nome),
                new Email(dto.Email),
                new Cpf(dto.Cpf));

            await _repo.AdicionarAsync(cliente);
            return cliente.Id;
        }
    }
}
