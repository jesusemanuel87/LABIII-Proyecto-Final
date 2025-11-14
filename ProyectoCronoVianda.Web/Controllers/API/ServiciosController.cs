using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoCronoVianda.Core.Data;
using ProyectoCronoVianda.Core.DTOs;
using ProyectoCronoVianda.Core.Models;

namespace ProyectoCronoVianda.Web.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class ServiciosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ServiciosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Servicios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServicioDto>>> GetServicios()
    {
        var servicios = await _context.Servicios
            .Include(s => s.Empleados)
            .Select(s => new ServicioDto
            {
                IdServicio = s.IdServicio,
                Nombre = s.Nombre,
                Descripcion = s.Descripcion,
                EntregaViandaHabilitada = s.EntregaViandaHabilitada,
                CantidadEmpleados = s.Empleados.Count
            })
            .ToListAsync();

        return Ok(servicios);
    }

    // GET: api/Servicios/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ServicioDto>> GetServicio(int id)
    {
        var servicio = await _context.Servicios
            .Include(s => s.Empleados)
            .Where(s => s.IdServicio == id)
            .Select(s => new ServicioDto
            {
                IdServicio = s.IdServicio,
                Nombre = s.Nombre,
                Descripcion = s.Descripcion,
                EntregaViandaHabilitada = s.EntregaViandaHabilitada,
                CantidadEmpleados = s.Empleados.Count
            })
            .FirstOrDefaultAsync();

        if (servicio == null)
        {
            return NotFound();
        }

        return Ok(servicio);
    }

    // POST: api/Servicios
    [HttpPost]
    public async Task<ActionResult<ServicioDto>> CreateServicio(CreateServicioDto createDto)
    {
        var servicio = new Servicio
        {
            Nombre = createDto.Nombre,
            Descripcion = createDto.Descripcion,
            EntregaViandaHabilitada = createDto.EntregaViandaHabilitada
        };

        _context.Servicios.Add(servicio);
        await _context.SaveChangesAsync();

        var servicioDto = new ServicioDto
        {
            IdServicio = servicio.IdServicio,
            Nombre = servicio.Nombre,
            Descripcion = servicio.Descripcion,
            EntregaViandaHabilitada = servicio.EntregaViandaHabilitada,
            CantidadEmpleados = 0
        };

        return CreatedAtAction(nameof(GetServicio), new { id = servicio.IdServicio }, servicioDto);
    }

    // PUT: api/Servicios/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateServicio(int id, UpdateServicioDto updateDto)
    {
        var servicio = await _context.Servicios.FindAsync(id);

        if (servicio == null)
        {
            return NotFound();
        }

        servicio.Nombre = updateDto.Nombre;
        servicio.Descripcion = updateDto.Descripcion;
        servicio.EntregaViandaHabilitada = updateDto.EntregaViandaHabilitada;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServicioExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Servicios/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServicio(int id)
    {
        var servicio = await _context.Servicios.FindAsync(id);
        if (servicio == null)
        {
            return NotFound();
        }

        _context.Servicios.Remove(servicio);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ServicioExists(int id)
    {
        return _context.Servicios.Any(e => e.IdServicio == id);
    }
}
