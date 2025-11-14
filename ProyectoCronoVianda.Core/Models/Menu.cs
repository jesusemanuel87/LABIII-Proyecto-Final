namespace ProyectoCronoVianda.Core.Models;

public class Menu
{
    public int IdMenu { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public int IdTipoDieta { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }

    // Relaciones
    public virtual TipoDieta TipoDieta { get; set; } = null!;
    public virtual ICollection<AsignacionVianda> AsignacionesVianda { get; set; } = new List<AsignacionVianda>();
}
