using Calendario.Core.Services;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Calendario.Core.Commands.Eventos;

public class RemoverEventoCommandHandler : IRequestHandler<RemoverEventoCommand, bool>
{
    private readonly IOAuthService _oAuthService;
    
    public RemoverEventoCommandHandler(IOAuthService oAuthService, IConfiguration configuration)
    {
        _oAuthService = oAuthService;
    }

    public async Task<bool> Handle(RemoverEventoCommand request, CancellationToken cancellationToken)
    {
        var services = await _oAuthService.Autenticar(cancellationToken);
        var evento = await services.Events.Delete(request.CalendarioId, request.Id).ExecuteAsync(cancellationToken);
        return evento is not null;
    }
}