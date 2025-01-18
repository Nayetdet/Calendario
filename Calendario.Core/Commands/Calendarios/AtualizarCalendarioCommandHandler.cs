using Calendario.Core.DTO.Calendarios;
using Calendario.Core.Services;
using MediatR;

namespace Calendario.Core.Commands.Calendarios;

public class AtualizarCalendarioCommandHandler : IRequestHandler<AtualizarCalendarioCommand, CalendarioDto?>
{
    private readonly IOAuthService _oAuthService;

    public AtualizarCalendarioCommandHandler(IOAuthService oAuthService)
    {
        _oAuthService = oAuthService;
    }

    public async Task<CalendarioDto?> Handle(AtualizarCalendarioCommand request, CancellationToken cancellationToken)
    {
        var services = await _oAuthService.Autenticar([ $"https://www.googleapis.com/calendar/v3/calendars/{request.Id}" ]);
        var calendario = await services.Calendars.Update(request.ToCalendar(), request.Id).ExecuteAsync(cancellationToken);
        
        if (calendario is null)
        {
            return null;
        }
        
        return CalendarioDto.From(calendario);
    }
}