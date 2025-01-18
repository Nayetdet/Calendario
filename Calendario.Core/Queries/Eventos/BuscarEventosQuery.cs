using Calendario.Core.DTO.Eventos;
using MediatR;

namespace Calendario.Core.Queries.Eventos;

public class BuscarEventosQuery : IRequest<List<EventoDto>>
{
    public string CalendarioId { get; set; } = null!;
}