using Calendario.Core.DTO.Eventos;
using Calendario.Core.Services;
using MediatR;

namespace Calendario.Core.Queries.Eventos;

public class BuscarEventosQueryHandler : IRequestHandler<BuscarEventosQuery, List<EventoDto>>
{
    private readonly IOAuthService _oAuthService;
    
    public BuscarEventosQueryHandler(IOAuthService oAuthService)
    {
        _oAuthService = oAuthService;
    }

    public async Task<List<EventoDto>> Handle(BuscarEventosQuery request, CancellationToken cancellationToken)
    {
        var services = await _oAuthService.Autenticar(cancellationToken);
        var events = await services.Events.List(request.CalendarioId).ExecuteAsync(cancellationToken);
        return events.Items.Select(x => EventoDto.From(x, request.CalendarioId)).ToList();
    }
}