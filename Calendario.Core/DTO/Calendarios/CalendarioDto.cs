using Google.Apis.Calendar.v3.Data;

namespace Calendario.Core.DTO.Calendarios;

public class CalendarioDto
{
    public string Id { get; set; } = null!;
    public string Sumario { get; set; } = null!;
    public string Descricao { get; set; } = null!;

    public static CalendarioDto From(Calendar calendario)
    {
        return new CalendarioDto
        {
            Id = calendario.Id,
            Sumario = calendario.Summary,
            Descricao = calendario.Description
        };
    }
}