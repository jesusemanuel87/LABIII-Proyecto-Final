namespace ProyectoCronoVianda.Core.Models;

public class TipoDieta
{
    public int IdTipoDieta { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public bool Activo { get; set; } = true;

    // Relaciones
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
