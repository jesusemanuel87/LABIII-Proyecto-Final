namespace ProyectoCronoVianda.Core.DTOs;

public class ServicioDto
{
    public int IdServicio { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public bool EntregaViandaHabilitada { get; set; }
    public int CantidadEmpleados { get; set; }
}

public class CreateServicioDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public bool EntregaViandaHabilitada { get; set; } = true;
}

public class UpdateServicioDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public bool EntregaViandaHabilitada { get; set; }
}
