using Calendario.Core.DTO.Eventos;
using Google.Apis.Calendar.v3.Data;
using MediatR;

namespace Calendario.Core.Commands.Eventos;

public class CadastrarEventoCommand : IRequest<EventoDto?>
{
    public string CalendarioId { get; set; } = null!;
    public string Sumario { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string Local { get; set; } = null!;
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }

    public Event ToEvent()
    {
        return new Event
        {
            Summary = Sumario,
            Description = Descricao,
            Location = Local,
            Start = new EventDateTime { DateTimeDateTimeOffset = Inicio },
            End = new EventDateTime { DateTimeDateTimeOffset = Fim }
        };
    }
}