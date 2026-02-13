# Checklist / To Do List (Estado del Proyecto)

## Lectura rápida del estado

- **Documentación:** muy completa (MVP1/MVP2, API, QA, manual, presupuesto).
- **Implementación:** base sólida de modelos + EF Core + migración inicial; API aún parcial.

---

## Cómo generar/actualizar la Base de Datos

- **Opción A (recomendada):** ejecutar el script `Init-Database.ps1` desde la raíz del repo.
- **Opción B:** ejecutar el comando `dotnet ef database update` manualmente.

### Requisitos

- .NET SDK instalado.
- EF Core CLI disponible.
- SQL Server Express **LocalDB** instalado (necesario si usás la cadena por defecto `(localdb)\\mssqllocaldb`).

Para verificar que LocalDB está instalado, en PowerShell:

```powershell
sqllocaldb info
```

### Opción A: Script

En PowerShell:

```powershell
./Init-Database.ps1
```

El script corre:

- `dotnet restore`
- `dotnet ef database update --project ProyectoCronoVianda.Web --startup-project ProyectoCronoVianda.Web --context ApplicationDbContext`

### Opción B: Manual

```bash
dotnet restore
dotnet ef database update --project ProyectoCronoVianda.Web --startup-project ProyectoCronoVianda.Web --context ApplicationDbContext
```

### Qué crea

La migración inicial (`ProyectoCronoVianda.Web/Migrations/20251114190730_InitialCreate.cs`) incluye creación de tablas como:

- `Servicios`, `Empleados`, `Turnos`
- `Cronogramas`, `CronogramaItems`
- `TiposVianda`, `TiposDieta`, `Menus`, `AsignacionesVianda`
- `VentanasCambio`, `SolicitudesCambioTurno`, `Inasistencias`
- `Usuarios`, `Roles`, `UsuarioRoles`, `AuditLogs`

---

## Checklist (priorizado)

### 1) Alineación documentación vs implementación (Alta)

- **[ ]** Confirmar si el objetivo del repo es:
  - completar **MVP1** (según docs), o
  - preparar demo parcial, o
  - avanzar directo a **MVP2**.
- **[ ]** Revisar divergencias entre `API_Documentation.md` y controllers reales.
- **[ ]** Definir qué parte es **MVC (Razor)** y qué parte es **API** consumible por app móvil.

### 2) Backend/API (Alta)

- **[ ]** Implementar Autenticación y Autorización real:
  - JWT (según documentación),
  - roles/claims,
  - endpoints `/auth/login` y refresh.
- **[ ]** Completar controladores/endpoints MVP1 (mínimo):
  - Empleados
  - Turnos
  - Cronogramas + items + reemplazos
  - Viandas (generación + aprobación/rechazo)
  - Menús + TiposDieta + TiposVianda
  - Solicitudes de cambio
  - Inasistencias
  - Configuración (ventanas/horarios)
  - Reportes
- **[ ]** Mover reglas de negocio a una capa de servicios (actualmente `Core/Services` está vacía).
- **[ ]** Definir contratos (`Core/Interfaces`) y usar DI para desacoplar de EF directo en controllers.
- **[ ]** Manejo consistente de errores (problem details / formato estándar) acorde a lo documentado.

### 3) Datos / EF Core (Alta)

- **[ ]** Validar modelo vs requerimientos MVP1:
  - índices únicos (ej. `Empleado.DNI`, `Empleado.CodigoBarras`),
  - cardinalidades y `DeleteBehavior`.
- **[ ]** Revisar que la migración inicial refleje el modelo esperado de MVP1.
- **[ ]** Agregar **seed data** (la propia documentación lo marca como pendiente):
  - roles, usuarios, servicios base, turnos, tipos de vianda/dieta.

### 4) Frontend Web MVC (Media)

- **[ ]** Definir alcance de pantallas MVC:
  - Admin (ABMs),
  - Jefe de Servicio (cronogramas + solicitudes),
  - Jefe de Cocina (aprobación viandas/menús),
  - reportes.
- **[ ]** Completar navegación/layout y permisos por rol.

### 5) Notificaciones (Media)

- **[ ]** Integrar SignalR (documentación lo asume) para:
  - publicación de cronograma,
  - solicitudes,
  - inasistencias,
  - viandas pendientes.

### 6) QA / Testing (Media)

- **[ ]** Crear proyecto de tests (xUnit) y cubrir lo planteado en `Gantt_QA.md`:
  - ventanas de entrega,
  - ventanas de cambio,
  - estados de viandas,
  - casos límite.
- **[ ]** Pruebas de integración (WebApplicationFactory + BD de pruebas).

### 7) Configuración / Seguridad / DevOps (Media-Baja)

- **[ ]** Revisar CORS (actualmente `AllowAll`): ajustar para entornos reales.
- **[ ]** Configurar secretos/connection strings por entorno.
- **[ ]** Documentar CI/CD (marcado como pendiente en docs).
- **[ ]** Preparar Docker (si sigue en alcance).

---

## Pendientes detectados en la propia documentación

(De `README_Documentacion.md`)

- **[ ]** Actualizar presentación con imágenes (placeholders/rutas).
- **[ ]** Crear datos de prueba (seed data).
- **[ ]** Documentar CI/CD.
