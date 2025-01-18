using Calendario.Core.DTO.Eventos;
using MediatR;

namespace Calendario.Core.Queries.Eventos;

public class ObterEventoPorIdQuery : IRequest<EventoDto?>
{
    public string Id { get; set; } = null!;
    public string CalendarioId { get; set; } = null!;
}