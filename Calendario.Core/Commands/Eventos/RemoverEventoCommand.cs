using MediatR;

namespace Calendario.Core.Commands.Eventos;

public class RemoverEventoCommand : IRequest<bool>
{
    public string Id { get; set; } = null!;
    public string CalendarioId { get; set; } = null!;
}