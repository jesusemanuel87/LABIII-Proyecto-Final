namespace ProyectoCronoVianda.Core.DTOs;

public class TurnoDto
{
    public int IdTurno { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
}

public class CreateTurnoDto
{
    public string Nombre { get; set; } = string.Empty;
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
}

public class UpdateTurnoDto
{
    public string Nombre { get; set; } = string.Empty;
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
}
