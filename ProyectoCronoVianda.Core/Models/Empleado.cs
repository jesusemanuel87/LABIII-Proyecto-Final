namespace ProyectoCronoVianda.Core.Models;

public class Empleado
{
    public int IdEmpleado { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public string? CodigoBarras { get; set; }
    public string? AvatarUrl { get; set; }
    public int IdServicio { get; set; }
    public int? IdUsuario { get; set; }
    public int? TipoDietaId { get; set; }
    public bool Activo { get; set; } = true;

    // Relaciones
    public virtual Servicio Servicio { get; set; } = null!;
    public virtual Usuario? Usuario { get; set; }
    public virtual TipoDieta? TipoDieta { get; set; }
    public virtual ICollection<CronogramaItem> CronogramaItems { get; set; } = new List<CronogramaItem>();
    public virtual ICollection<Inasistencia> Inasistencias { get; set; } = new List<Inasistencia>();
    public virtual ICollection<SolicitudCambioTurno> SolicitudesCambio { get; set; } = new List<SolicitudCambioTurno>();
}
