using Calendario.Core.Commands.Calendarios;
using Calendario.Core.DTO.Calendarios;
using Calendario.Core.Queries.Calendarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalendariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public CalendariosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CalendarioDto>> Obter([FromRoute] string id, CancellationToken cancellationToken)
    {
        var calendarioDto = await _mediator.Send(new ObterCalendarioPorIdQuery { Id = id }, cancellationToken);
        if (calendarioDto is null)
        {
            return NotFound();
        }
        
        return calendarioDto;
    }
    
    [HttpPost]
    public async Task<ActionResult<CalendarioDto>> Cadastrar([FromBody] CadastrarCalendarioCommand command, CancellationToken cancellationToken)
    {
        var calendarioDto = await _mediator.Send(command, cancellationToken);
        if (calendarioDto is null)
        {
            return BadRequest();
        }

        return calendarioDto;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CalendarioDto>> Atualizar([FromRoute] string id, [FromBody] AtualizarCalendarioCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        
        var calendarioDto = await _mediator.Send(command, cancellationToken);
        if (calendarioDto is null)
        {
            return NotFound();
        }
        
        return calendarioDto;
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(string id, CancellationToken cancellationToken)
    {
        if (!await _mediator.Send(new RemoverCalendarioCommand { Id = id }, cancellationToken))
        {
            return NotFound();
        }

        return Ok();
    }
}