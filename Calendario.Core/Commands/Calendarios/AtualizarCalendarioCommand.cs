using Calendario.Core.DTO.Calendarios;
using Google.Apis.Calendar.v3.Data;
using MediatR;

namespace Calendario.Core.Commands.Calendarios;

public class AtualizarCalendarioCommand : IRequest<CalendarioDto?>
{
    public string Id { get; set; } = null!;
    public string Sumario { get; set; } = null!;
    public string Descricao { get; set; } = null!;

    public Calendar ToCalendar()
    {
        return new Calendar
        {
            Id = Id,
            Summary = Sumario,
            Description = Descricao
        };
    }
}