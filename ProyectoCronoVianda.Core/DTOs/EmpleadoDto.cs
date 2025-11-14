namespace ProyectoCronoVianda.Core.DTOs;

public class EmpleadoDto
{
    public int IdEmpleado { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public string? CodigoBarras { get; set; }
    public string? AvatarUrl { get; set; }
    public int IdServicio { get; set; }
    public string NombreServicio { get; set; } = string.Empty;
    public int? TipoDietaId { get; set; }
    public string? TipoDietaNombre { get; set; }
    public bool Activo { get; set; }
}

public class CreateEmpleadoDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public string? CodigoBarras { get; set; }
    public int IdServicio { get; set; }
    public int? TipoDietaId { get; set; }
}

public class UpdateEmpleadoDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string? CodigoBarras { get; set; }
    public string? AvatarUrl { get; set; }
    public int IdServicio { get; set; }
    public int? TipoDietaId { get; set; }
    public bool Activo { get; set; }
}
