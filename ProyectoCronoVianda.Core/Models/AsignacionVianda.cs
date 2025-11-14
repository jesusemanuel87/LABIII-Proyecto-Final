namespace ProyectoCronoVianda.Core.Models;

public class AsignacionVianda
{
    public int IdAsignacion { get; set; }
    public int IdCronogramaItem { get; set; }
    public int IdTipoVianda { get; set; }
    public int IdMenu { get; set; }
    public string Estado { get; set; } = "PENDIENTE"; // PENDIENTE, APROBADA, RECHAZADA
    public string? Observacion { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public int? AprobadoPor { get; set; }
    public DateTime? FechaAprobacion { get; set; }

    // Relaciones
    public virtual CronogramaItem CronogramaItem { get; set; } = null!;
    public virtual TipoVianda TipoVianda { get; set; } = null!;
    public virtual Menu Menu { get; set; } = null!;
}
