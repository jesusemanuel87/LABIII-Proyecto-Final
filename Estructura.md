# Estructura del Proyecto

## Resumen

Este repositorio contiene una solución .NET (`net9.0`) orientada a un sistema de **gestión de cronogramas laborales y asignación/aprobación de viandas** para un hospital.

- **Solución:** `ProyectoCronoVianda.sln`
- **Proyectos:**
  - `ProyectoCronoVianda.Core` (dominio + EF Core)
  - `ProyectoCronoVianda.Web` (ASP.NET Core MVC + API)
- **Documentación:** `.vscode/Docs/` (documentación funcional, técnica y planificación)

## Árbol de carpetas (alto nivel)

```text
windsurf-project/
├─ ProyectoCronoVianda.sln
├─ README.md
├─ ProyectoCronoVianda.Core/
├─ ProyectoCronoVianda.Web/
└─ .vscode/
   └─ Docs/
```

## Proyecto: `ProyectoCronoVianda.Core`

**Propósito:** capa de dominio y acceso a datos (Entity Framework Core).

- **Archivo de proyecto:** `ProyectoCronoVianda.Core/ProyectoCronoVianda.Core.csproj`
  - Target: `net9.0`
  - Paquetes: `Microsoft.EntityFrameworkCore (9.0.0)`

### Carpetas y archivos

- **`Models/`**: entidades del dominio.
  - Entidades presentes (según estructura actual):
    - `Usuario`, `Rol`, `UsuarioRol`
    - `Servicio`, `Empleado`
    - `Turno`, `ConfiguracionServicioTurno`
    - `Cronograma`, `CronogramaItem`
    - `TipoVianda`, `TipoDieta`, `Menu`, `AsignacionVianda`
    - `VentanaCambio`, `SolicitudCambioTurno`, `Inasistencia`
    - `AuditLog`
- **`Data/ApplicationDbContext.cs`**: `DbContext` con:
  - `DbSet<>` para todas las entidades.
  - Configuraciones en `OnModelCreating` (claves, índices únicos, relaciones, delete behaviors).
- **`DTOs/`**: DTOs básicos.
  - `EmpleadoDto`, `ServicioDto`, `TipoDietaDto`, `TurnoDto`
- **`Interfaces/`**: existe, actualmente vacío.
- **`Services/`**: existe, actualmente vacío.
- **`Class1.cs`**: placeholder.

## Proyecto: `ProyectoCronoVianda.Web`

**Propósito:** aplicación web (MVC/Razor) y endpoints API.

- **Archivo de proyecto:** `ProyectoCronoVianda.Web/ProyectoCronoVianda.Web.csproj`
  - Target: `net9.0`
  - Paquetes EF:
    - `Microsoft.EntityFrameworkCore.SqlServer (9.0.0)`
    - `Microsoft.EntityFrameworkCore.Design (9.0.0)`
    - `Microsoft.EntityFrameworkCore.Tools (10.0.0)`
  - Referencia a: `ProyectoCronoVianda.Core`

### Punto de entrada

- **`Program.cs`**
  - `AddControllersWithViews()`
  - `AddDbContext<ApplicationDbContext>` con SQL Server y `MigrationsAssembly("ProyectoCronoVianda.Web")`
  - CORS: policy `AllowAll`
  - Routing MVC: `{controller=Home}/{action=Index}/{id?}`

### Controllers

- **`Controllers/HomeController.cs`**: controlador MVC base (Index/Privacy/Error).
- **`Controllers/API/ServiciosController.cs`**: API CRUD para `Servicio`.
  - Endpoints:
    - `GET api/Servicios`
    - `GET api/Servicios/{id}`
    - `POST api/Servicios`
    - `PUT api/Servicios/{id}`
    - `DELETE api/Servicios/{id}`
  - Usa `ApplicationDbContext` y DTOs.

### Views

- **`Views/`**: vistas base (`Home`, `Shared`) típicas de MVC.

### Persistencia / Migraciones

- **`Migrations/`**: migración inicial y snapshot del modelo.

### Configuración

- **`appsettings.json`**: connection string `DefaultConnection` (LocalDB).

## Documentación: `.vscode/Docs`

**Nota:** la carpeta `.vscode` está mayormente ignorada por git, pero `.vscode/Docs/` está explícitamente incluida (según `.gitignore`).

Documentos principales:

- `README_Documentacion.md`: índice maestro de documentación.
- `ProyectoCronogramaViandas_Presentacion.md`: presentación/justificación/análisis/diseño.
- `ProyectoCronogramaViandas_MVP1.md`: alcance y especificación técnica de MVP1.
- `ProyectoCronogramaViandas_MVP2.md`: alcance previsto para MVP2.
- `ProyectoCronogramaViandas_Gantt_QA.md`: gantt + plan de pruebas.
- `Manual_Usuario.md`: manual por roles.
- `API_Documentation.md`: especificación de endpoints (nivel documento).
- `ProyectoCronogramaViandas_Presupuesto.md` + `ProyectoCronogramaViandas_Valorizacion_Detallada.md`: costos/estimaciones.
- `img/`: diagramas (PlantUML e imágenes exportadas).

## Estado actual (observación rápida)

- La **documentación está muy avanzada** (MVP1/MVP2, QA, manual, API esperada).
- El **código implementado** visible en la solución está en una etapa inicial:
  - Dominio + `DbContext` y migración inicial: presentes.
  - API implementada: por ahora se observa al menos el módulo `Servicios`.
  - Capas `Interfaces/` y `Services/`: todavía vacías (no se ve lógica de negocio separada).
  - Autenticación/JWT/Identity/SignalR/reportes: no se observa todavía en la configuración/paquetes actuales del proyecto Web.
