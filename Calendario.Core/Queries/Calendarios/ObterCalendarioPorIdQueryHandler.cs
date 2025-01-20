using Calendario.Core.DTO.Calendarios;
using Calendario.Core.Services;
using MediatR;

namespace Calendario.Core.Queries.Calendarios;

public class ObterCalendarioPorIdQueryHandler : IRequestHandler<ObterCalendarioPorIdQuery, CalendarioDto?>
{
    private readonly IOAuthService _oAuthService;

    public ObterCalendarioPorIdQueryHandler(IOAuthService oAuthService)
    {
        _oAuthService = oAuthService;
    }

    public async Task<CalendarioDto?> Handle(ObterCalendarioPorIdQuery request, CancellationToken cancellationToken)
    {
        var services = await _oAuthService.Autenticar(cancellationToken);
        var calendario = await services.Calendars.Get(request.Id).ExecuteAsync(cancellationToken);
        
        if (calendario is null)
        {
            return null;
        }

        return CalendarioDto.From(calendario);
    }
}