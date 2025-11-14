namespace ProyectoCronoVianda.Core.Models;

public class CronogramaItem
{
    public int IdItem { get; set; }
    public int IdCronograma { get; set; }
    public int IdEmpleado { get; set; }
    public DateTime Fecha { get; set; }
    public int IdTurno { get; set; }
    public string Estado { get; set; } = "ACTIVO"; // ACTIVO, CANCELADO, REEMPLAZADO
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Relaciones
    public virtual Cronograma Cronograma { get; set; } = null!;
    public virtual Empleado Empleado { get; set; } = null!;
    public virtual Turno Turno { get; set; } = null!;
    public virtual ICollection<AsignacionVianda> AsignacionesVianda { get; set; } = new List<AsignacionVianda>();
}
