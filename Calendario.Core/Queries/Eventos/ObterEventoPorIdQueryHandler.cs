using Calendario.Core.DTO.Eventos;
using Calendario.Core.Services;
using MediatR;

namespace Calendario.Core.Queries.Eventos;

public class ObterEventoPorIdQueryHandler : IRequestHandler<ObterEventoPorIdQuery, EventoDto?>
{
    private readonly IOAuthService _oAuthService;
    
    public ObterEventoPorIdQueryHandler(IOAuthService oAuthService)
    {
        _oAuthService = oAuthService;
    }

    public async Task<EventoDto?> Handle(ObterEventoPorIdQuery request, CancellationToken cancellationToken)
    {
        var services = await _oAuthService.Autenticar(cancellationToken);
        var events = await services.Events.Get(request.CalendarioId, request.Id).ExecuteAsync(cancellationToken);
        
        if (events is null)
        {
            return null;
        }
        
        return EventoDto.From(events, request.CalendarioId);
    }
}