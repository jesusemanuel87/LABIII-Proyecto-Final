namespace ProyectoCronoVianda.Core.Models;

public class Turno
{
    public int IdTurno { get; set; }
    public string Nombre { get; set; } = string.Empty; // Mañana, Tarde, Noche
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }

    // Relaciones
    public virtual ICollection<ConfiguracionServicioTurno> ConfiguracionesServicio { get; set; } = new List<ConfiguracionServicioTurno>();
    public virtual ICollection<CronogramaItem> CronogramaItems { get; set; } = new List<CronogramaItem>();
    public virtual ICollection<VentanaCambio> VentanasCambio { get; set; } = new List<VentanaCambio>();
}
