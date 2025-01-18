using Calendario.Core.DTO.Calendarios;
using MediatR;

namespace Calendario.Core.Queries.Calendarios;

public class ObterCalendarioPorIdQuery : IRequest<CalendarioDto?>
{
    public string Id { get; set; } = null!;
}