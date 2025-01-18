using Calendario.Core.DTO.Calendarios;
using Calendario.Core.Services;
using MediatR;

namespace Calendario.Core.Commands.Calendarios;

public class CadastrarCalendarioCommandHandler : IRequestHandler<CadastrarCalendarioCommand, CalendarioDto?>
{
    private readonly IOAuthService _oAuthService;

    public CadastrarCalendarioCommandHandler(IOAuthService oAuthService)
    {
        _oAuthService = oAuthService;
    }

    public async Task<CalendarioDto?> Handle(CadastrarCalendarioCommand request, CancellationToken cancellationToken)
    {
        var services = await _oAuthService.Autenticar([ "https://www.googleapis.com/calendar/v3/calendars" ]);
        var calendario = await services.Calendars.Insert(request.ToCalendar()).ExecuteAsync(cancellationToken);
        
        if (calendario is null)
        {
            return null;
        }
        
        return CalendarioDto.From(calendario);
    }
}