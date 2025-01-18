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
        string[] scopes = [$"https://www.googleapis.com/calendar/v3/calendars/{request.CalendarioId}/events"];
        var services = await _oAuthService.Autenticar(scopes, cancellationToken);
        
        var evento = await services.Events.Insert(request.ToEvent(), request.CalendarioId).ExecuteAsync(cancellationToken);
        if (evento is null)
        {
            return null;
        }
        
        return EventoDto.From(evento, request.CalendarioId);
    }
}