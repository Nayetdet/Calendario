using Calendario.Core.DTO.Calendarios;
using Google.Apis.Calendar.v3.Data;
using MediatR;

namespace Calendario.Core.Commands.Calendarios;

public class CadastrarCalendarioCommand : IRequest<CalendarioDto?>
{
    public string Sumario { get; set; } = null!;
    public string Descricao { get; set; } = null!;

    public Calendar ToCalendar()
    {
        return new Calendar
        {
            Summary = Sumario,
            Description = Descricao
        };
    }
}