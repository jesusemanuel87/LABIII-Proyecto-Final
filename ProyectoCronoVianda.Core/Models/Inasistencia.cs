namespace ProyectoCronoVianda.Core.Models;

public class Inasistencia
{
    public int IdInasistencia { get; set; }
    public int IdEmpleado { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string? ArchivoSoporteUrl { get; set; }
    public string Estado { get; set; } = "PENDIENTE"; // PENDIENTE, APROBADA, RECHAZADA
    public DateTime FechaNotificacion { get; set; } = DateTime.UtcNow;
    public int? RevisadoPor { get; set; }
    public DateTime? FechaRevision { get; set; }

    // Relaciones
    public virtual Empleado Empleado { get; set; } = null!;
}
