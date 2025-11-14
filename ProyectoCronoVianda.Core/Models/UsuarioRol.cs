namespace ProyectoCronoVianda.Core.Models;

public class UsuarioRol
{
    public int IdUsuario { get; set; }
    public int IdRol { get; set; }

    // Relaciones
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual Rol Rol { get; set; } = null!;
}
