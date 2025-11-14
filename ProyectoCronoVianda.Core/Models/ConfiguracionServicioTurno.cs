namespace ProyectoCronoVianda.Core.Models;

public class ConfiguracionServicioTurno
{
    public int IdConfiguracion { get; set; }
    public int IdServicio { get; set; }
    public int IdTurno { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }

    // Relaciones
    public virtual Servicio Servicio { get; set; } = null!;
    public virtual Turno Turno { get; set; } = null!;
}
