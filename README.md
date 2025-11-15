# LABIII - Proyecto Final: Sistema de Cronograma y Viandas – Hospital

## 📋 Descripción del Proyecto

Sistema de información para la **gestión automatizada de cronogramas laborales y asignación de viandas** al personal hospitalario. Desarrollado como proyecto final para Laboratorio III.

El sistema abarca:

- Gestión de turnos y cronogramas mensuales por servicio
- Asignación automática de viandas según turnos y tipos de dieta
- Control de inasistencias y solicitudes de cambio de turno
- Aprobación de viandas por Jefe de Cocina
- Reportes y auditoría de operaciones

---

## 🏗️ Arquitectura

### Stack Tecnológico

**Backend:**

- ASP.NET Core 9.0 Web API + MVC
- Entity Framework Core
- Identity + JWT para autenticación

**Frontend Web:**

- ASP.NET Core MVC (Razor)
- Bootstrap 5

**App Móvil (previsto):**

- Android (Kotlin, MVVM)
- Retrofit, Room, SignalR

**Base de Datos:**

- SQL Server / PostgreSQL

---

## 📂 Estructura del Proyecto

```
LABIII-Proyecto-Final/
│
├── ProyectoCronoVianda.sln              # Solución principal
│
├── ProyectoCronoVianda.Web/             # Aplicación web MVC + API
│   ├── Controllers/                     # Controladores MVC y API
│   ├── Views/                           # Vistas Razor
│   ├── wwwroot/                         # Assets estáticos
│   └── Program.cs                       # Punto de entrada
│
├── ProyectoCronoVianda.Core/            # Capa de dominio
│   ├── Models/                          # Modelos de dominio
│   ├── Interfaces/                      # Contratos de servicio
│   ├── Services/                        # Lógica de negocio
│   ├── DTOs/                            # Data Transfer Objects
│   └── ...
│
└── .vscode/Docs/                        # Documentación del proyecto
    ├── ProyectoCronogramaViandas_Presentacion.md
    ├── ProyectoCronogramaViandas_Gantt_QA.md
    ├── Proyecto_Cronograma_Viandas_MVP1.md
    └── img/                             # Diagramas UML (PlantUML)
        ├── diagrama_casos_uso_general.puml
        ├── diagrama_clases_cronograma_viandas.puml
        ├── ui_mockups_cronograma_viandas.puml
        └── gantt_proyecto.puml
```

---

## 📖 Documentación

La documentación completa del proyecto se encuentra en `.vscode/Docs/`:

- **[ProyectoCronogramaViandas_Presentacion.md](.vscode/Docs/ProyectoCronogramaViandas_Presentacion.md)**  
  Documento de presentación formal con estructura académica: introducción, justificación, objetivos, alcance, requerimientos, análisis y diseño.

- **[ProyectoCronogramaViandas_MVP1.md](.vscode/Docs/ProyectoCronogramaViandas_MVP1.md)**  
  Especificación detallada del MVP1 (primera entrega).

- **[ProyectoCronogramaViandas_MVP2.md](.vscode/Docs/ProyectoCronogramaViandas_MVP2.md)**  
  Especificación de la segunda entrega: Interfaz Web completa, SignalR, reportes avanzados, entregas excepcionales.

- **[ProyectoCronogramaViandas_Gantt_QA.md](.vscode/Docs/ProyectoCronogramaViandas_Gantt_QA.md)**  
  Planificación temporal (Gantt) y plan de pruebas (QA).

- **[Manual_Usuario.md](.vscode/Docs/Manual_Usuario.md)**  
  Guía de uso del sistema para todos los roles (Administrador, Jefe Servicio, Jefe Cocina, Empleado, Bachero).

- **[API_Documentation.md](.vscode/Docs/API_Documentation.md)**  
  Documentación completa de la API REST con todos los endpoints.

- **[README_Documentacion.md](.vscode/Docs/README_Documentacion.md)**  
  Índice maestro de toda la documentación del proyecto.

### Diagramas UML

Los diagramas están en formato PlantUML (`.puml`) y (`.png`) en `.vscode/Docs/img/`:

- **Casos de Uso**: `diagrama_casos_uso_general.puml`
- **Diagrama de Clases**: `diagrama_clases_cronograma_viandas.puml`
- **Mockups de UI**: `ui_mockups_cronograma_viandas.puml`
- **Gantt del Proyecto**: `gantt_proyecto.puml`

---

## 💾 Instalación de la Base de Datos

El proyecto utiliza **Entity Framework Core** con SQL Server LocalDB por defecto. Para configurar la base de datos:

### Opción 1: SQL Server LocalDB (Recomendado para desarrollo)

La cadena de conexión por defecto en `appsettings.json` usa LocalDB:

```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CronogramaViandasDB;Trusted_Connection=true;MultipleActiveResultSets=true"
```

**Crear/actualizar la base de datos:**

```bash
dotnet ef database update --project ProyectoCronoVianda.Web
```

Este comando aplica todas las migraciones y crea la base de datos automáticamente.

### Opción 2: SQL Server completo

Si preferís usar SQL Server completo, modificá la cadena de conexión en `appsettings.json`:

```json
"DefaultConnection": "Server=localhost;Database=CronogramaViandasDB;User Id=tu_usuario;Password=tu_password;TrustServerCertificate=true"
```

Luego ejecutá el comando de migración:

```bash
dotnet ef database update --project ProyectoCronoVianda.Web
```

### Verificar migraciones disponibles

```bash
dotnet ef migrations list --project ProyectoCronoVianda.Web
```

### Crear nuevas migraciones (solo si modificaste los modelos)

```bash
dotnet ef migrations add NombreMigracion --project ProyectoCronoVianda.Web
```

---

## 🚀 Cómo ejecutar el proyecto

### Requisitos previos

- .NET SDK 9.0 o superior
- SQL Server LocalDB (incluido con Visual Studio) o SQL Server completo
- Visual Studio 2022 / VS Code / Rider
- EF Core CLI: `dotnet tool install --global dotnet-ef` (si no está instalado)

### Pasos

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/jesusemanuel87/LABIII-Proyecto-Final.git
   cd LABIII-Proyecto-Final
   ```

2. **Restaurar dependencias:**

   ```bash
   dotnet restore
   ```

3. **Configurar y crear la base de datos:**

   ```bash
   dotnet ef database update --project ProyectoCronoVianda.Web
   ```

4. **Ejecutar el proyecto web:**

   ```bash
   dotnet run --project ProyectoCronoVianda.Web/ProyectoCronoVianda.Web.csproj
   ```

5. **Acceder a la aplicación:**

   Abrí el navegador en:

   - https://localhost:5001 (HTTPS)
   - http://localhost:5000 (HTTP)
   - API REST: https://localhost:5001/api/servicios

---

## 🎯 Alcance del MVP1 (Primera Entrega)

- ✅ Autenticación y roles básicos (Admin, Jefe Servicio, Jefe Cocina, Empleado)
- ✅ CRUD de Empleados, Servicios, Turnos, Tipos de Vianda, Tipos de Dieta
- ✅ Gestión de cronogramas mensuales por servicio
- ✅ Generación automática de viandas según turnos y reglas de horario
- ✅ Flujo de aprobación/rechazo de viandas por Jefe de Cocina
- ✅ Gestión de solicitudes de cambio de turno por empleados
- ✅ Registro de inasistencias con adjunto de certificado
- ✅ Notificaciones en tiempo real (SignalR)
- ✅ Reportes básicos (PDF/Excel) y auditoría

---

## 👥 Actores del Sistema

- **Administrador**: Configura servicios, horarios, roles, usuarios.
- **Jefe de Servicio**: Gestiona cronogramas mensuales, aprueba solicitudes de cambio.
- **Jefe de Cocina**: Gestiona menús/dietas, aprueba viandas generadas.
- **Empleado**: Consulta cronograma, solicita cambios de turno, informa inasistencias.
- **Bachero**: Consulta lista de viandas del día (confirmación por app en segunda entrega).

---

## 📝 Autor

**Laboratorio de Computación III**  
Universidad Tecnológica Nacional - Facultad Regional Resistencia  
Año: 2025

---

## 📄 Licencia

Este proyecto es de uso académico.
