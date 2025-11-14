namespace ProyectoCronoVianda.Core.Models;

public class AuditLog
{
    public int IdLog { get; set; }
    public int UsuarioId { get; set; }
    public string Entidad { get; set; } = string.Empty;
    public int EntidadId { get; set; }
    public string Accion { get; set; } = string.Empty; // CREATE, UPDATE, DELETE
    public DateTime FechaHora { get; set; } = DateTime.UtcNow;
    public string? Detalle { get; set; }

    // Relaciones
    public virtual Usuario Usuario { get; set; } = null!;
}
