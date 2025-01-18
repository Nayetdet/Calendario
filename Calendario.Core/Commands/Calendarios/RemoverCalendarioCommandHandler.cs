using Calendario.Core.Services;
using MediatR;

namespace Calendario.Core.Commands.Calendarios;

public class RemoverCalendarioCommandHandler : IRequestHandler<RemoverCalendarioCommand, bool>
{
    private readonly IOAuthService _oAuthService;

    public RemoverCalendarioCommandHandler(IOAuthService oAuthService)
    {
        _oAuthService = oAuthService;
    }

    public async Task<bool> Handle(RemoverCalendarioCommand request, CancellationToken cancellationToken)
    {
        string[] scopes = [$"https://www.googleapis.com/calendar/v3/calendars/{request.Id}"];
        var services = await _oAuthService.Autenticar(scopes, cancellationToken);
        
        var calendario = await services.Calendars.Delete(request.Id).ExecuteAsync(cancellationToken);
        return calendario is not null;
    }
}