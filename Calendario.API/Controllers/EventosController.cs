using Calendario.Core.Commands.Eventos;
using Calendario.Core.DTO.Eventos;
using Calendario.Core.Queries.Eventos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Calendario.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{calendarioId}")]
    public async Task<ActionResult<List<EventoDto>>> Buscar([FromRoute] string calendarioId, CancellationToken cancellationToken)
    {
        var eventosDto = await _mediator.Send(new BuscarEventosQuery { CalendarioId = calendarioId }, cancellationToken);
        return Ok(eventosDto);
    }
    
    [HttpGet("{calendarioId}/{id}")]
    public async Task<ActionResult<EventoDto?>> Obter([FromRoute] string calendarioId, [FromRoute] string id, CancellationToken cancellationToken)
    {
        var eventoDto = await _mediator.Send(new ObterEventoPorIdQuery { Id = id, CalendarioId = calendarioId }, cancellationToken);
        if (eventoDto is null)
        {
            return NotFound();
        }
        
        return eventoDto;
    }
    
    [HttpPost]
    public async Task<ActionResult<EventoDto?>> Cadastrar([FromBody] CadastrarEventoCommand command, CancellationToken cancellationToken)
    {
        var eventoDto = await _mediator.Send(command, cancellationToken);
        if (eventoDto is null)
        {
            return BadRequest();
        }

        return eventoDto;
    }
    
    [HttpPut]
    public async Task<ActionResult<EventoDto?>> Atualizar([FromBody] AtualizarEventoCommand command, CancellationToken cancellationToken)
    {
        var eventoDto = await _mediator.Send(command, cancellationToken);
        if (eventoDto is null)
        {
            return NotFound();
        }
        
        return eventoDto;
    }
    
    [HttpDelete]
    public async Task<IActionResult> Remover([FromBody] RemoverEventoCommand command, CancellationToken cancellationToken)
    {
        if (!await _mediator.Send(command, cancellationToken))
        {
            return NotFound();
        }
        
        return Ok();
    }
}