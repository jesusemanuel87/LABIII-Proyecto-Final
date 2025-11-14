namespace ProyectoCronoVianda.Core.Models;

public class SolicitudCambioTurno
{
    public int IdSolicitud { get; set; }
    public int IdEmpleado { get; set; }
    public int IdServicio { get; set; }
    public DateTime FechaSolicitada { get; set; }
    public string TurnoOrigen { get; set; } = string.Empty;
    public string TurnoDestino { get; set; } = string.Empty;
    public int? IdEmpleadoSugerido { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public string Estado { get; set; } = "PENDIENTE"; // PENDIENTE, APROBADA, RECHAZADA
    public DateTime FechaSolicitud { get; set; } = DateTime.UtcNow;
    public int? ResueltoPor { get; set; }
    public DateTime? FechaResolucion { get; set; }
    public string? ObservacionResolucion { get; set; }

    // Relaciones
    public virtual Empleado Empleado { get; set; } = null!;
}
