namespace ProyectoCronoVianda.Core.Models;

public class VentanaCambio
{
    public int IdVentana { get; set; }
    public int IdServicio { get; set; }
    public int? IdTurno { get; set; }
    public int? IdTipoVianda { get; set; }
    public TimeSpan HoraLimiteCambio { get; set; }

    // Relaciones
    public virtual Servicio Servicio { get; set; } = null!;
    public virtual Turno? Turno { get; set; }
    public virtual TipoVianda? TipoVianda { get; set; }
}
