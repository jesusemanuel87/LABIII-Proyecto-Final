namespace ProyectoCronoVianda.Core.Models;

public class Servicio
{
    public int IdServicio { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public bool EntregaViandaHabilitada { get; set; } = true;

    // Relaciones
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    public virtual ICollection<Cronograma> Cronogramas { get; set; } = new List<Cronograma>();
    public virtual ICollection<ConfiguracionServicioTurno> ConfiguracionesTurno { get; set; } = new List<ConfiguracionServicioTurno>();
    public virtual ICollection<VentanaCambio> VentanasCambio { get; set; } = new List<VentanaCambio>();
}
