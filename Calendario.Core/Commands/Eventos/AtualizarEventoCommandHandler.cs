using Calendario.Core.DTO.Eventos;
using Calendario.Core.Services;
using MediatR;

namespace Calendario.Core.Commands.Eventos;

public class AtualizarEventoCommandHandler : IRequestHandler<AtualizarEventoCommand, EventoDto?>
{
    private readonly IOAuthService _oAuthService;

    public AtualizarEventoCommandHandler(IOAuthService oAuthService)
    {
        _oAuthService = oAuthService;
    }

    public async Task<EventoDto?> Handle(AtualizarEventoCommand request, CancellationToken cancellationToken)
    {
        var services =  await _oAuthService.Autenticar([ $"https://www.googleapis.com/calendar/v3/calendars/{request.CalendarioId}/events/{request.Id}" ]);
        var evento = await services.Events.Update(request.ToEvent(), request.CalendarioId, request.Id).ExecuteAsync(cancellationToken);
        return EventoDto.From(evento, request.CalendarioId);
    }
}