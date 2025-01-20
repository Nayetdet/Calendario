using Google.Apis.Calendar.v3;

namespace Calendario.Core.Services;

public interface IOAuthService
{
    Task<CalendarService> Autenticar(CancellationToken cancellationToken);
}