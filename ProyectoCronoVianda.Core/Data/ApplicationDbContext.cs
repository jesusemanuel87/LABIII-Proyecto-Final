using Microsoft.EntityFrameworkCore;
using ProyectoCronoVianda.Core.Models;

namespace ProyectoCronoVianda.Core.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<UsuarioRol> UsuarioRoles { get; set; }
    public DbSet<Servicio> Servicios { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Turno> Turnos { get; set; }
    public DbSet<ConfiguracionServicioTurno> ConfiguracionesServicioTurno { get; set; }
    public DbSet<Cronograma> Cronogramas { get; set; }
    public DbSet<CronogramaItem> CronogramaItems { get; set; }
    public DbSet<TipoVianda> TiposVianda { get; set; }
    public DbSet<TipoDieta> TiposDieta { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<AsignacionVianda> AsignacionesVianda { get; set; }
    public DbSet<VentanaCambio> VentanasCambio { get; set; }
    public DbSet<SolicitudCambioTurno> SolicitudesCambioTurno { get; set; }
    public DbSet<Inasistencia> Inasistencias { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de Usuario
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.Username).IsUnique();
        });

        // Configuración de Rol
        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
        });

        // Configuración de UsuarioRol (tabla de relación muchos a muchos)
        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdRol });

            entity.HasOne(e => e.Usuario)
                .WithMany(u => u.UsuarioRoles)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Rol)
                .WithMany(r => r.UsuarioRoles)
                .HasForeignKey(e => e.IdRol)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuración de Servicio
        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
        });

        // Configuración de Empleado
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
            entity.Property(e => e.DNI).IsRequired().HasMaxLength(20);
            entity.HasIndex(e => e.DNI).IsUnique();
            entity.HasIndex(e => e.CodigoBarras).IsUnique();

            entity.HasOne(e => e.Servicio)
                .WithMany(s => s.Empleados)
                .HasForeignKey(e => e.IdServicio)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de Turno
        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurno);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
        });

        // Configuración de ConfiguracionServicioTurno
        modelBuilder.Entity<ConfiguracionServicioTurno>(entity =>
        {
            entity.HasKey(e => e.IdConfiguracion);

            entity.HasOne(e => e.Servicio)
                .WithMany(s => s.ConfiguracionesTurno)
                .HasForeignKey(e => e.IdServicio)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Turno)
                .WithMany(t => t.ConfiguracionesServicio)
                .HasForeignKey(e => e.IdTurno)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuración de Cronograma
        modelBuilder.Entity<Cronograma>(entity =>
        {
            entity.HasKey(e => e.IdCronograma);

            entity.HasOne(e => e.Servicio)
                .WithMany(s => s.Cronogramas)
                .HasForeignKey(e => e.IdServicio)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => new { e.IdServicio, e.Mes, e.Anio }).IsUnique();
        });

        // Configuración de CronogramaItem
        modelBuilder.Entity<CronogramaItem>(entity =>
        {
            entity.HasKey(e => e.IdItem);
            entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);

            entity.HasOne(e => e.Cronograma)
                .WithMany(c => c.Items)
                .HasForeignKey(e => e.IdCronograma)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Empleado)
                .WithMany(emp => emp.CronogramaItems)
                .HasForeignKey(e => e.IdEmpleado)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Turno)
                .WithMany(t => t.CronogramaItems)
                .HasForeignKey(e => e.IdTurno)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de TipoVianda
        modelBuilder.Entity<TipoVianda>(entity =>
        {
            entity.HasKey(e => e.IdTipoVianda);
            entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(50);
        });

        // Configuración de TipoDieta
        modelBuilder.Entity<TipoDieta>(entity =>
        {
            entity.HasKey(e => e.IdTipoDieta);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
        });

        // Configuración de Menu
        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);

            entity.HasOne(e => e.TipoDieta)
                .WithMany(td => td.Menus)
                .HasForeignKey(e => e.IdTipoDieta)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de AsignacionVianda
        modelBuilder.Entity<AsignacionVianda>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion);
            entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);

            entity.HasOne(e => e.CronogramaItem)
                .WithMany(ci => ci.AsignacionesVianda)
                .HasForeignKey(e => e.IdCronogramaItem)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.TipoVianda)
                .WithMany(tv => tv.AsignacionesVianda)
                .HasForeignKey(e => e.IdTipoVianda)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Menu)
                .WithMany(m => m.AsignacionesVianda)
                .HasForeignKey(e => e.IdMenu)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de VentanaCambio
        modelBuilder.Entity<VentanaCambio>(entity =>
        {
            entity.HasKey(e => e.IdVentana);

            entity.HasOne(e => e.Servicio)
                .WithMany(s => s.VentanasCambio)
                .HasForeignKey(e => e.IdServicio)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Turno)
                .WithMany(t => t.VentanasCambio)
                .HasForeignKey(e => e.IdTurno)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.TipoVianda)
                .WithMany(tv => tv.VentanasCambio)
                .HasForeignKey(e => e.IdTipoVianda)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de SolicitudCambioTurno
        modelBuilder.Entity<SolicitudCambioTurno>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud);
            entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);
            entity.Property(e => e.TurnoOrigen).IsRequired().HasMaxLength(50);
            entity.Property(e => e.TurnoDestino).IsRequired().HasMaxLength(50);

            entity.HasOne(e => e.Empleado)
                .WithMany(emp => emp.SolicitudesCambio)
                .HasForeignKey(e => e.IdEmpleado)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuración de Inasistencia
        modelBuilder.Entity<Inasistencia>(entity =>
        {
            entity.HasKey(e => e.IdInasistencia);
            entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);

            entity.HasOne(e => e.Empleado)
                .WithMany(emp => emp.Inasistencias)
                .HasForeignKey(e => e.IdEmpleado)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuración de AuditLog
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.IdLog);
            entity.Property(e => e.Entidad).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Accion).IsRequired().HasMaxLength(20);

            entity.HasOne(e => e.Usuario)
                .WithMany(u => u.AuditLogs)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
