using CrmApp.Data.Context;
using CrmApp.Domain.Entities;
using CrmApp.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CrmApp.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CrmDbContext _context;

        public ClienteRepository(CrmDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Cliente cliente)
            => await _context.Clientes.AddAsync(cliente);

        public async Task AtualizarAsync(Cliente cliente)
            => _context.Clientes.Update(cliente);

        public async Task RemoverAsync(Cliente cliente)
            => _context.Clientes.Remove(cliente);

        public async Task<Cliente?> ObterPorIdAsync(Guid id)
             => await _context.Clientes.FindAsync(id);

        public async Task<List<Cliente>> ListarTodosAsync()
            => await _context.Clientes.AsNoTracking()
            .ToListAsync();
    }
}
