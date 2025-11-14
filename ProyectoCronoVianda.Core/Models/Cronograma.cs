namespace ProyectoCronoVianda.Core.Models;

public class Cronograma
{
    public int IdCronograma { get; set; }
    public int IdServicio { get; set; }
    public int Mes { get; set; }
    public int Anio { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public int CreadoPor { get; set; }

    // Relaciones
    public virtual Servicio Servicio { get; set; } = null!;
    public virtual ICollection<CronogramaItem> Items { get; set; } = new List<CronogramaItem>();
}
