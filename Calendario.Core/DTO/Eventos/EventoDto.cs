using Google.Apis.Calendar.v3.Data;

namespace Calendario.Core.DTO.Eventos;

public class EventoDto
{
    public string Id { get; set; } = null!;
    public string CalendarioId { get; set; } = null!;
    public string Sumario { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string Local { get; set; } = null!;
    public DateTime? Inicio { get; set; }
    public DateTime? Fim { get; set; }

    public static EventoDto From(Event evento, string calendarioId)
    {
        return new EventoDto
        {
            Id = evento.Id,
            CalendarioId = calendarioId,
            Sumario = evento.Summary,
            Descricao = evento.Description,
            Local = evento.Location,
            Inicio = evento.Start.DateTimeDateTimeOffset?.UtcDateTime,
            Fim = evento.End.DateTimeDateTimeOffset?.UtcDateTime
        };
    }
}