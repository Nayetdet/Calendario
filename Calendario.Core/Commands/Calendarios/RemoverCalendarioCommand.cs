using MediatR;

namespace Calendario.Core.Commands.Calendarios;

public class RemoverCalendarioCommand : IRequest<bool>
{
    public string Id { get; set; } = null!;
}