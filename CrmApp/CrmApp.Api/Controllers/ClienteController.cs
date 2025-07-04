using CrmApp.Application.DTOs;
using CrmApp.Application.UseCase;
using CrmApp.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrmApp.Api.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClienteController : ControllerBase
{
    private readonly CriarClienteUseCase _useCase;
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(
        CriarClienteUseCase useCase,
        IClienteRepository clienteRepository)
    {
        _useCase = useCase;
        _clienteRepository = clienteRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriarClienteDTO dto)
    {
        var id = await _useCase.ExecutarAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var cliente = await _clienteRepository.ObterPorIdAsync(id);

        if (cliente == null)
            return NotFound();

        var dto = new ClienteDTO
        {
            Id = cliente.Id,
            Nome = cliente.Nome.ToString(),
            Email = cliente.Email.ToString(),
            Cpf = cliente.Cpf.ToString()
        };

        return Ok(dto);
    }
}
