using Calendario.Core.DTO.Eventos;
using Google.Apis.Calendar.v3.Data;
using MediatR;

namespace Calendario.Core.Commands.Eventos;

public class AtualizarEventoCommand : IRequest<EventoDto?>
{
    public string Id { get; set; } = null!;
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
            Id = Id,
            Summary = Sumario,
            Description = Descricao,
            Location = Local,
            Start = new EventDateTime { DateTimeDateTimeOffset = Inicio },
            End = new EventDateTime { DateTimeDateTimeOffset = Fim }
        }; 
    }
}