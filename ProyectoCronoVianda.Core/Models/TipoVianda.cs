namespace ProyectoCronoVianda.Core.Models;

public class TipoVianda
{
    public int IdTipoVianda { get; set; }
    public string Descripcion { get; set; } = string.Empty; // Desayuno, Almuerzo, Merienda, Cena
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
    public bool Activo { get; set; } = true;

    // Relaciones
    public virtual ICollection<AsignacionVianda> AsignacionesVianda { get; set; } = new List<AsignacionVianda>();
    public virtual ICollection<VentanaCambio> VentanasCambio { get; set; } = new List<VentanaCambio>();
}
