using Calendario.Core.DTO.Eventos;
using Calendario.Core.Services;
using MediatR;

namespace Calendario.Core.Commands.Eventos;

public class CadastrarEventoCommandHandler : IRequestHandler<CadastrarEventoCommand, EventoDto?>
{
    private readonly IOAuthService _oAuthService;

    public CadastrarEventoCommandHandler(IOAuthService oAuthService)
    {
        _oAuthService = oAuthService;
    }

    public async Task<EventoDto?> Handle(CadastrarEventoCommand request, CancellationToken cancellationToken)
    {
        var services = await _oAuthService.Autenticar(cancellationToken);
        var evento = await services.Events.Insert(request.ToEvent(), request.CalendarioId).ExecuteAsync(cancellationToken);
        
        if (evento is null)
        {
            return null;
        }
        
        return EventoDto.From(evento, request.CalendarioId);
    }
}