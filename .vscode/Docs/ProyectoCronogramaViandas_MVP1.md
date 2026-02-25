# Proyecto: Sistema de Cronograma y Viandas — Hospital
## MVP1 - Primera Entrega

**Versión:** 1.0  
**Fecha:** Noviembre 2025  
**Estado:** Planificación

---

## 1. Introducción

Este documento describe el alcance de la **Primera Entrega (MVP1)** del Sistema de Cronograma y Viandas para Hospital.

Aplicación web (ASP.NET Core) + aplicación móvil Android para gestionar cronogramas laborales mensuales por jefe de servicio, asignación automática de viandas según turnos, aprobación por jefe de cocina y control de entregas. Incluye CRUD, reglas por horario, control de dietas, registros de auditoría y notificaciones.

**Nota importante:** Para la Primera Entrega se excluye la confirmación de entrega por parte del bachero vía app (se implementará en MVP2).

---

## 2. Objetivos de la Primera Entrega

### 2.1 Objetivo General

Desarrollar un sistema funcional que permita gestionar cronogramas laborales mensuales y asignación automática de viandas según turnos y horarios configurables.

### 2.2 Objetivos Específicos

1. Permitir al jefe del servicio **programar y gestionar el cronograma mensual** de sus empleados (turnos mañana/tarde/noche) vía app móvil o web

2. Asignar automáticamente el **tipo de vianda** (desayuno, almuerzo, merienda, cena) según el turno y horarios configurados por servicio (parametrizables)

3. Gestionar **tipos de dieta y menús**; que el jefe de cocina apruebe o rechace las viandas generadas (módulo web en MVP1; app móvil en MVP2)

4. Controlar **permisos y roles** (Administrador, Jefe de Servicio, Jefe de Cocina, Bachero, Empleado)

5. Generar **reportes** (resumen por día/servicio/tipo de dieta), auditoría y trazabilidad

6. Implementar **notificaciones en tiempo real** (SignalR) para avisos de cronograma, solicitudes y aprobaciones

---

## 3. Actores / Roles (MVP1)

- **Administrador**: 
  - Configura servicios, horarios, roles y usuarios
  - Acceso completo a todas las funcionalidades del sistema
  - Gestión de parámetros globales

- **Jefe de Servicio**: 
  - Crea/edita cronogramas mensuales para su servicio desde la app o web
  - Gestiona reemplazos y cambios (respetando ventanas de tiempo límites configurables)
  - Aprueba o rechaza solicitudes de cambio de turno de empleados
  - Revisa informes de inasistencias

- **Jefe de Cocina**: 
  - Revisa viandas generadas y aprueba/rechaza menús
  - Gestiona menús y dietas
  - **MVP1**: interfaz web
  - **MVP2**: app móvil con permisos completos

- **Bachero**: 
  - Recibe lista de viandas por entregar (operativa)
  - **MVP1**: sin módulo de confirmación
  - **MVP2**: módulo para confirmar entregas y gestionar excepciones

- **Empleado**: 
  - Accede vía app (DNI + contraseña)
  - Ve su cronograma personal
  - Solicita cambios de turno
  - Informa inasistencias con adjunto de certificado
  - Gestiona su perfil (avatar, contraseña)

---

## 4. Requerimientos Funcionales (MVP1)

### 4.1 Gestión de Entidades Básicas

1. **CRUD Completo** para:
   - Empleados
   - Usuarios
   - Roles
   - Servicios
   - Turnos
   - Tipos de Vianda
   - Tipos de Dieta
   - Menús/Viandas

2. **Configuración por servicio** de horarios de entrada y salida para cada turno

3. **Habilitación/deshabilitación de tipos de vianda** según horario (parametrizable por servicio)

### 4.2 Gestión de Cronogramas

1. **Creación de cronograma mensual** por Jefe de Servicio (app móvil o web)
   - Asignación de turnos a empleados
   - Vista de calendario interactivo
   - Validaciones de disponibilidad

2. **Cambios y reemplazos de personal**
   - Respeta ventanas límite configurables
   - Validación automática de restricciones
   - Registro de auditoría

3. **Ventanas límite para cambios/reemplazos** el mismo día (parametrizables):
   - Desayuno: hasta 07:00
   - Almuerzo: hasta 11:00
   - Merienda: hasta 15:00
   - Cena: hasta 19:00

### 4.3 Gestión de Viandas

1. **Generador automático de viandas**
   - Basado en cronograma y reglas de horario
   - Asignación según tipo de dieta del empleado
   - Estado inicial: PENDIENTE

2. **Horarios de entrega parametrizables** (por defecto):
   - Desayuno: 07:00 – 10:00
   - Almuerzo: 12:00 – 14:00
   - Merienda: 16:00 – 18:00
   - Cena: 20:00 – 22:00
   - *Estos rangos son configurables por servicio y tipo de vianda*

3. **Flujo de aprobación por Jefe de Cocina**
   - Revisar viandas generadas
   - Aprobar/rechazar con observaciones
   - Notificación automática a Jefe de Servicio

### 4.4 Funcionalidades del Empleado (App Móvil)

1. **Acceso y autenticación**
   - Login con DNI + contraseña
   - Ver cronograma personal (día/semana/mes)

2. **Solicitud de cambio de turno**
   - Indicar día y turno deseado
   - Motivo de la solicitud
   - Opción de proponer compañero para el cambio
   - Estados: pendiente/aprobada/rechazada
   - Notificación automática al Jefe de Servicio

3. **Informe de inasistencia**
   - Indicar desde/hasta
   - Motivo
   - Anexar certificado médico (archivo)
   - Notificación al Jefe de Servicio

4. **Gestión de perfil**
   - Ver datos personales
   - Cambiar avatar (imagen)
   - Cambiar contraseña

### 4.5 Notificaciones en Tiempo Real (SignalR)

1. **Eventos notificables**:
   - Creación/actualización de cronograma
   - Solicitudes de cambio de turno
   - Aprobación/rechazo de solicitudes
   - Inasistencias reportadas
   - Viandas pendientes de aprobación
   - Aprobación/rechazo de viandas

### 4.6 Reportes y Auditoría

1. **Reportes exportables** (PDF/Excel):
   - Reporte por día
   - Reporte por servicio
   - Reporte por tipo de dieta
   - Lista de asignaciones de viandas
   - Reporte de ausencias e inasistencias

2. **Auditoría de cambios**:
   - Registro de quién hizo qué y cuándo
   - Logs de cambios en cronogramas
   - Logs de aprobaciones
   - Logs de solicitudes y modificaciones

### 4.7 Exclusiones del MVP1

- ❌ Confirmación de entrega por bachero vía app (se implementa en MVP2)
- ❌ App móvil completa para Jefe de Cocina (se implementa en MVP2)
- ❌ Entregas excepcionales y personal de visita (se implementa en MVP2)

---

## 5. Requerimientos No Funcionales (MVP1)

### 5.1 Seguridad

- **Autenticación y autorización robusta** (JWT + roles/claims)
- **HTTPS obligatorio** en todas las comunicaciones
- Encriptación de contraseñas con hashing seguro (bcrypt/PBKDF2)
- Validación de entrada de datos (sanitización)
- Protección contra ataques comunes (SQL Injection, XSS, CSRF)

### 5.2 Escalabilidad

- Diseño modular y desacoplado
- APIs REST bien definidas y documentadas
- Arquitectura preparada para escalar horizontalmente
- Uso de caché para consultas frecuentes

### 5.3 Rendimiento

- Consultas de calendario optimizadas con índices adecuados
- Paginación en todos los listados
- Lazy loading de datos en app móvil
- Respuesta de API < 500ms para operaciones comunes

### 5.4 Disponibilidad

- Backups automáticos de base de datos
- Despliegue en contenedores (Docker)
- Logs centralizados para debugging
- Monitoreo de errores y excepciones

### 5.5 Usabilidad

- Interfaz intuitiva y responsiva
- Mensajes de error claros y descriptivos
- Feedback visual de operaciones en progreso
- Soporte para modo offline básico en app móvil

---

## 6. Arquitectura Propuesta (MVP1)

### 6.1 Backend

- **Framework**: ASP.NET Core Web API
- **ORM**: Entity Framework Core
- **Base de datos**: SQL Server / PostgreSQL con migraciones EF Core
- **Autenticación**: ASP.NET Core Identity + JWT
  - Empleados con credenciales: DNI + contraseña
- **Notificaciones**: SignalR para notificaciones en tiempo real

### 6.2 Frontend Web

- **Tecnología**: React o Blazor para administración
- **Roles con acceso web**:
  - Administrador: panel completo de gestión
  - Jefe de Servicio: gestión de cronogramas (alternativa a app móvil)
  - Jefe de Cocina: aprobación de viandas y gestión de menús

### 6.3 App Móvil Android

- **Lenguaje**: Kotlin
- **Arquitectura**: MVVM (Model-View-ViewModel)
- **Librerías principales**:
  - Retrofit: consumo de API REST
  - Room: base de datos local
  - WorkManager: tareas en segundo plano
  - SignalR: notificaciones en tiempo real
  - Glide/Coil: carga de imágenes
- **Roles con acceso móvil**:
  - Jefe de Servicio: gestión completa de cronogramas
  - Empleado: consulta de cronograma y solicitudes

### 6.4 Base de Datos

- **Motor**: SQL Server o PostgreSQL
- **Migraciones**: Entity Framework Core Migrations
- **Estrategia**: Code-First con Fluent API
- **Backup**: Automático diario

---

## 7. Modelo de Datos (MVP1)

### 7.1 Entidades Principales

Se mantienen las tablas principales del modelo original, con adiciones y campos nuevos:

#### Usuario y Rol

- **Usuario**: usuarios del sistema (sin cambios mayores)
- **Rol**: roles y permisos (sin cambios)

#### Empleado (ampliado)

```csharp
public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string DNI { get; set; }
    public string CodigoBarras { get; set; } // NUEVO
    public string AvatarUrl { get; set; } // NUEVO
    public int ServicioId { get; set; }
    public int TipoDietaId { get; set; }
    public bool Activo { get; set; }
    
    // Relaciones
    public Servicio Servicio { get; set; }
    public TipoDieta TipoDieta { get; set; }
}
```

#### Servicio y Turno

- **Servicio**: departamentos/servicios del hospital (sin cambios)
- **Turno**: mañana, tarde, noche (sin cambios)
- **ConfiguracionServicioTurno**: horarios ajustables por servicio

### 7.2 Cronograma

#### Cronograma y CronogramaItem

```csharp
public class CronogramaItem
{
    public int Id { get; set; }
    public int CronogramaId { get; set; }
    public int EmpleadoId { get; set; }
    public DateTime Fecha { get; set; }
    public int TurnoId { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public EstadoCronograma Estado { get; set; }
    
    // Relaciones
    public Cronograma Cronograma { get; set; }
    public Empleado Empleado { get; set; }
    public Turno Turno { get; set; }
}
```

### 7.3 Viandas

#### TipoVianda (ampliado)

```csharp
public class TipoVianda
{
    public int Id { get; set; }
    public string Nombre { get; set; } // Desayuno, Almuerzo, Merienda, Cena
    public TimeSpan HoraInicio { get; set; } // NUEVO - parametrizable
    public TimeSpan HoraFin { get; set; } // NUEVO - parametrizable
    public bool Activo { get; set; }
}
```

#### Menu, TipoDieta, AsignacionVianda

- **Menu**: menús disponibles (sin cambios funcionales importantes)
- **TipoDieta**: dietas especiales (sin cambios funcionales importantes)
- **AsignacionVianda**: asignación de viandas a empleados (sin cambios funcionales importantes)

### 7.4 Nuevas Entidades (MVP1)

#### VentanaCambio (NUEVA)

```csharp
public class VentanaCambio
{
    public int Id { get; set; }
    public int? TipoViandaId { get; set; }
    public int? TurnoId { get; set; }
    public int? ServicioId { get; set; }
    public TimeSpan HoraLimiteCambio { get; set; }
    
    // Relaciones
    public TipoVianda TipoVianda { get; set; }
    public Turno Turno { get; set; }
    public Servicio Servicio { get; set; }
}
```

**Propósito**: Define la hora límite para realizar cambios/reemplazos el mismo día.

#### SolicitudCambioTurno (NUEVA)

```csharp
public class SolicitudCambioTurno
{
    public int IdSolicitud { get; set; }
    public int IdEmpleado { get; set; }
    public DateTime FechaSolicitada { get; set; }
    public int TurnoOrigen { get; set; }
    public int TurnoDestino { get; set; }
    public string Motivo { get; set; }
    public int? IdEmpleadoSugerido { get; set; }
    public EstadoSolicitud Estado { get; set; }
    public DateTime FechaSolicitud { get; set; }
    public DateTime? FechaRespuesta { get; set; }
    public int? RespondidoPor { get; set; }
    
    // Relaciones
    public Empleado Empleado { get; set; }
    public Empleado EmpleadoSugerido { get; set; }
}
```

**Propósito**: Gestiona las solicitudes de cambio de turno por parte de empleados.

#### Inasistencia (NUEVA)

```csharp
public class Inasistencia
{
    public int Id { get; set; }
    public int IdEmpleado { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }
    public string Motivo { get; set; }
    public string ArchivoSoporteUrl { get; set; }
    public EstadoInasistencia Estado { get; set; }
    public DateTime FechaNotificacion { get; set; }
    public int? RevisadoPor { get; set; }
    
    // Relaciones
    public Empleado Empleado { get; set; }
}
```

**Propósito**: Registro de inasistencias reportadas por empleados con soporte documental.

### 7.5 Auditoría

#### AuditLog

- **AuditLog**: registro de cambios y acciones en el sistema (sin cambios)

---

## 8. Reglas de Negocio Principales (MVP1)

### 8.1 Configuración de Horarios

- Cada servicio define **hora inicio/fin por turno**
- Rangos válidos de entrega configurables por **tipo de vianda**
- Horarios parametrizables a nivel de servicio

### 8.2 Asignación de Viandas

- La asignación de vianda **respeta TipoDieta** del empleado
- Generación automática basada en cronograma
- Estado inicial: **PENDIENTE** (requiere aprobación del Jefe de Cocina)

### 8.3 Cambios y Reemplazos

- **Cambio/reemplazo en el día actual**: solo permitido hasta la `HoraLimiteCambio` configurada para el `TipoVianda` correspondiente
- Validación automática antes de ejecutar el cambio
- Registro en auditoría de todos los cambios

### 8.4 Solicitudes de Cambio de Turno

- Crean un **flujo de aprobación**
- Jefe de Servicio decide: aprueba o rechaza
- **Notificación automática** a todas las partes involucradas
- Estados: `PENDIENTE`, `APROBADA`, `RECHAZADA`

### 8.5 Inasistencias

- Empleado puede **adjuntar certificado** médico (archivo)
- **Notificación automática** al Jefe de Servicio
- Jefe de Servicio puede validar/aceptar la justificación
- Registro de fechas desde/hasta

---

## 9. API REST - Endpoints (MVP1)

### 9.1 Autenticación

- `POST /api/auth/login` — login y generación de JWT
  - Soporta DNI + contraseña para empleados
  - Retorna: JWT token + datos de usuario

### 9.2 Empleados

- `GET /api/empleados` — listar empleados (con paginación)
- `GET /api/empleados/{id}` — obtener empleado por ID
- `POST /api/empleados` — crear empleado
- `PUT /api/empleados/{id}` — actualizar empleado
- `DELETE /api/empleados/{id}` — eliminar/desactivar empleado
- `GET /api/empleados/{id}/perfil` — obtener perfil (para app móvil)
- `PUT /api/empleados/{id}/avatar` — subir/actualizar avatar
- `PUT /api/empleados/{id}/password` — cambiar contraseña

### 9.3 Cronogramas

- `POST /api/cronogramas` — crear cronograma mensual
  - Payload: servicio, mes, año, items
- `GET /api/cronogramas/{id}` — obtener cronograma por ID
- `PUT /api/cronogramas/{id}` — actualizar cronograma
- `DELETE /api/cronogramas/{id}` — eliminar cronograma
- `GET /api/cronogramas/servicio/{servicioId}?mes={mes}&ano={ano}` — cronograma de un servicio
- `POST /api/cronogramas/{id}/items/{itemId}/reemplazar` — reemplazar empleado
  - Valida ventana límite antes de ejecutar
- `GET /api/cronogramas/empleado/{empleadoId}?mes={mes}&ano={ano}` — cronograma personal (app empleado)

### 9.4 Solicitudes de Cambio de Turno

- `POST /api/solicitudes/cambio` — crear solicitud (empleado)
- `GET /api/solicitudes/empleado/{empleadoId}` — solicitudes del empleado
- `GET /api/solicitudes/servicio/{servicioId}` — solicitudes del servicio (Jefe)
- `GET /api/solicitudes/{id}` — obtener solicitud por ID
- `POST /api/solicitudes/{id}/aprobar` — aprobar solicitud (Jefe de Servicio)
- `POST /api/solicitudes/{id}/rechazar` — rechazar solicitud (Jefe de Servicio)

### 9.5 Inasistencias

- `POST /api/inasistencias` — informar inasistencia (empleado)
  - Soporta adjunto de certificado médico
- `GET /api/inasistencias/empleado/{empleadoId}` — inasistencias del empleado
- `GET /api/inasistencias/servicio/{servicioId}` — inasistencias del servicio (Jefe)
- `GET /api/inasistencias/{id}` — obtener inasistencia por ID
- `POST /api/inasistencias/{id}/validar` — validar inasistencia (Jefe de Servicio)

### 9.6 Viandas y Menús

- `POST /api/viandas/generar?cronogramaId={id}` — generar viandas automáticamente
- `GET /api/viandas/pendientes` — viandas pendientes de aprobación (Jefe Cocina)
- `GET /api/viandas/{id}` — obtener vianda por ID
- `POST /api/viandas/{id}/aprobar` — aprobar vianda (Jefe Cocina)
- `POST /api/viandas/{id}/rechazar` — rechazar vianda con motivo (Jefe Cocina)
- `GET /api/viandas/servicio/{servicioId}?fecha={fecha}` — viandas por servicio y fecha

### 9.7 Configuración

**Tipos de Vianda:**
- `GET /api/config/tiposvianda` — listar tipos de vianda con rangos horarios
- `GET /api/config/tiposvianda/{id}` — obtener tipo de vianda
- `PUT /api/config/tiposvianda/{id}` — actualizar rangos (HoraInicio/HoraFin)

**Ventanas de Cambio:**
- `GET /api/config/ventanacambio` — listar ventanas de cambio
- `GET /api/config/ventanacambio/{id}` — obtener ventana de cambio
- `PUT /api/config/ventanacambio/{id}` — actualizar hora límite para cambios

---

## 10. Interfaz de Usuario - Pantallas Clave (MVP1)

### 10.1 App Jefe de Servicio (Android)

1. **Login**
   - Autenticación con credenciales
   - Recordar usuario

2. **Dashboard del Servicio**
   - Resumen de empleados presentes/ausentes
   - Viandas pendientes
   - Solicitudes pendientes de aprobación
   - Notificaciones recientes

3. **Gestión de Cronograma Mensual**
   - Crear cronograma mensual
   - Editar cronograma existente
   - Vista de calendario interactivo
   - Reemplazar personal (con validación de ventana límite)

4. **Solicitudes de Cambio**
   - Listado de solicitudes pendientes
   - Detalle de cada solicitud
   - Aprobar/rechazar con motivo
   - Historial de solicitudes

5. **Notificaciones Push**
   - Nuevas solicitudes de cambio
   - Inasistencias reportadas
   - Cambios en cronograma

### 10.2 App Empleado (Android)

1. **Login**
   - Autenticación con DNI + contraseña
   - Recuperar contraseña

2. **Cronograma Personal**
   - Vista de día/semana/mes
   - Calendario interactivo
   - Detalle de turno y vianda asignada

3. **Solicitar Cambio de Turno**
   - Seleccionar día y turno deseado
   - Ingresar motivo
   - Opción de proponer compañero para intercambio
   - Ver estado de solicitudes

4. **Informar Inasistencia**
   - Ingresar desde/hasta
   - Motivo de la inasistencia
   - Adjuntar certificado médico (foto/archivo)
   - Ver historial de inasistencias

5. **Perfil de Usuario**
   - Ver datos personales
   - Cambiar avatar (foto)
   - Cambiar contraseña
   - Configuración de notificaciones

### 10.3 Panel Web Administrativo (React/Blazor)

1. **Panel de Administrador**
   - Dashboard con estadísticas globales
   - Gestión completa de entidades:
     - Empleados
     - Servicios
     - Turnos
     - Tipos de Vianda
     - Tipos de Dieta
     - Menús
   - Configuración de horarios y ventanas
   - Gestión de usuarios y roles

2. **Panel del Jefe de Cocina**
   - Dashboard de viandas pendientes
   - Revisar viandas generadas
   - Aprobar/rechazar con observaciones
   - Gestión de menús y dietas
   - Vista de calendario de viandas

3. **Reportes y Exportación**
   - Reportes por día/servicio/tipo de dieta
   - Exportación a PDF/Excel
   - Filtros avanzados
   - Gráficos y estadísticas

---

## 11. Flujo de Trabajo - Ejemplo Completo (MVP1)

### 11.1 Flujo: Creación de Cronograma y Generación de Viandas

1. **Jefe de Servicio** crea cronograma mensual (app o web)
   - Asigna turnos a empleados por día
   - Sistema valida disponibilidad y restricciones

2. **Sistema genera automáticamente** `AsignacionVianda` en estado **PENDIENTE**
   - Basado en reglas de horario y tipo de vianda
   - Respeta tipo de dieta de cada empleado
   - Aplica ventanas configuradas

3. **Jefe de Cocina** revisa y aprueba menús/viandas (web)
   - Ve listado de viandas pendientes
   - Aprueba o rechaza con observaciones

4. **Listado operativo de entrega** se genera desde el sistema
   - Para uso interno del Bachero
   - Confirmación por app del bachero: **MVP2**

### 11.2 Flujo: Solicitud de Cambio de Turno por Empleado

1. **Empleado** solicita cambio desde la app
   - Selecciona día y turno deseado
   - Ingresa motivo
   - Opcionalmente propone compañero

2. **Sistema** crea solicitud en estado **PENDIENTE**
   - Notifica al Jefe de Servicio vía SignalR

3. **Jefe de Servicio** revisa solicitud (app o web)
   - Aprueba o rechaza
   - Puede ingresar comentarios

4. **Sistema** notifica al empleado del resultado
   - Actualiza cronograma si fue aprobada
   - Registra en auditoría

### 11.3 Flujo: Informe de Inasistencia

1. **Empleado** informa inasistencia desde la app
   - Indica fechas desde/hasta
   - Motivo
   - Adjunta certificado médico (opcional)

2. **Sistema** notifica al Jefe de Servicio
   - Marca los días afectados en el cronograma
   - Actualiza asignaciones de viandas

3. **Jefe de Servicio** valida la justificación
   - Puede gestionar reemplazos si es necesario

---

## 12. MVP1 - Alcance Finalizado

**Funcionalidades Implementadas:**

- ✅ **Autenticación y roles básicos**
  - Login empleado con DNI + contraseña
  - JWT para seguridad de API
  - Roles: Administrador, Jefe de Servicio, Jefe de Cocina, Empleado

- ✅ **CRUD Completo**
  - Empleados (con CodigoBarras y AvatarUrl)
  - Servicios
  - Turnos
  - Tipos de Vianda
  - Tipos de Dieta
  - Menús/Viandas

- ✅ **Gestión de Cronogramas**
  - Editor de cronograma mensual (app + web)
  - Ventanas de cambio/reemplazo (parametrizables)
  - Lógica de bloqueo por hora límite
  - App Jefe de Servicio: crear/editar/reemplazar

- ✅ **Funcionalidades del Empleado (App)**
  - Ver cronograma personal
  - Solicitar cambio de turno
  - Informar inasistencia con certificado
  - Editar perfil (avatar, contraseña)

- ✅ **Gestión de Viandas**
  - Generación automática de viandas
  - Flujo de aprobación por Jefe de Cocina (web)
  - Ventanas de entrega por TipoVianda (parametrizables)

- ✅ **Notificaciones en Tiempo Real**
  - SignalR para notificaciones push
  - Eventos: cronograma, solicitudes, inasistencias, viandas

- ✅ **Reportes y Auditoría**
  - Reportes básicos exportables (PDF/Excel)
  - Auditoría de cambios y acciones

---

## 13. Funcionalidades para la Segunda Entrega (MVP2)

### 13.1 App Móvil del Jefe de Cocina

- App Android completa con todas las funcionalidades del panel web:
  - Aprobar/rechazar viandas desde dispositivo móvil
  - Gestionar menús y tipos de dieta
  - Ver asignaciones y calendario
  - Notificaciones push en tiempo real

### 13.2 Módulo del Bachero

- **App móvil para confirmación de entregas**:
  - Listado de viandas del día
  - Marcar como entregada (con timestamp)
  - Foto de evidencia (opcional)
  - Escaneo de código de barras (opcional)

- **Entregas especiales/excepciones**:
  - Vista con tag/badge de cantidad
  - Marcar como procesado
  - Notificación al Jefe de Cocina

### 13.3 Entregas Excepcionales

- **Gestión por Jefe de Cocina**:
  - Agregar entregas excepcionales (desde/hasta)
  - Tipo de vianda y tipo de dieta
  - Seleccionar personal existente O
  - Ingresar datos de personal de visita (nombre, DNI, institución)

### 13.4 Interfaz Web Completa

- Panel web para todos los roles (alternativa a apps móviles)
- Dashboards interactivos con KPIs
- Reportes avanzados con gráficos
- Exportaciones avanzadas

---

## 14. Pruebas y QA (MVP1)

### 14.1 Pruebas Unitarias

- Tests de lógica de ventanas de cambio
- Tests de validaciones de reemplazo
- Tests de generación automática de viandas
- Tests de reglas de negocio

### 14.2 Pruebas de Integración

- Tests de endpoints de solicitudes
- Tests de notificaciones SignalR
- Tests de flujo completo de aprobación
- Tests de autenticación y autorización

### 14.3 Pruebas End-to-End

- Flujo completo: cronograma → generación → aprobación
- Flujo de solicitudes de cambio → aprobación → notificación
- Flujo de inasistencias → validación
- Generación de reportes

### 14.4 Despliegue

- **Contenedorización**: Docker y Docker Compose
- **CI/CD**: Pipeline automatizado
- **Ambiente de staging**: para pruebas pre-producción
- **Monitoreo**: Logs y alertas

---

## 15. Cronograma Estimado (MVP1)

**Duración estimada:** 6-8 semanas

1. **Semanas 1-2**: Diseño y setup del proyecto
   - Modelo de base de datos
   - Estructura del backend
   - Setup de infraestructura

2. **Semanas 3-4**: Implementación del backend
   - APIs REST
   - Lógica de negocio
   - SignalR

3. **Semanas 5-6**: Desarrollo de apps móviles
   - App Jefe de Servicio
   - App Empleado

4. **Semana 7**: Panel web administrativo
   - Panel de administrador
   - Panel de Jefe de Cocina

5. **Semana 8**: Pruebas, ajustes y despliegue
   - Testing completo
   - Corrección de bugs
   - Despliegue a producción

---

## 16. Riesgos y Mitigaciones

| Riesgo | Impacto | Probabilidad | Mitigación |
|--------|---------|--------------|------------|
| Complejidad de validación de ventanas | Alto | Media | Implementar lógica centralizada y bien documentada |
| Integración SignalR con apps móviles | Medio | Media | Pruebas tempranas, librería oficial |
| Rendimiento con cronogramas grandes | Medio | Baja | Optimización de consultas, índices en BD |
| Adopción por parte de usuarios | Alto | Media | Capacitación, interfaz intuitiva |
| Problemas de sincronización | Medio | Media | Manejo de conflictos, validaciones robustas |

---

## 17. Dependencias y Tecnologías

### 17.1 Backend (NuGet Packages)

- `Microsoft.AspNetCore.Authentication.JwtBearer` — autenticación JWT
- `Microsoft.EntityFrameworkCore` — ORM
- `Microsoft.EntityFrameworkCore.SqlServer` — proveedor SQL Server
- `Microsoft.AspNetCore.SignalR` — notificaciones en tiempo real
- `AutoMapper` — mapeo de objetos
- `FluentValidation` — validaciones
- `EPPlus` — generación de Excel
- `iTextSharp` o `QuestPDF` — generación de PDF

### 17.2 Frontend Web (NPM Packages)

- `react` / `@microsoft/signalr` (si React)
- `axios` — cliente HTTP
- `bootstrap` o `tailwindcss` — UI framework
- `react-router-dom` — enrutamiento
- `chart.js` — gráficos (para reportes)

### 17.3 Android (Gradle Dependencies)

- `com.squareup.retrofit2:retrofit` — cliente HTTP
- `com.microsoft.signalr:signalr` — notificaciones
- `androidx.room:room-runtime` — base de datos local
- `org.jetbrains.kotlinx:kotlinx-coroutines-android` — corrutinas
- `io.coil-kt:coil` — carga de imágenes
- `androidx.work:work-runtime-ktx` — tareas en segundo plano

---

## 18. Siguientes Pasos Inmediatos

1. **Revisar y aprobar** este documento con stakeholders

2. **Confirmar y parametrizar ventanas**:
   - Horarios de entrega por servicio
   - Límites de cambio por tipo de vianda
   - Validar con usuarios finales

3. **Actualizar modelo físico de base de datos**:
   - Crear DDL con nuevas tablas:
     - `VentanaCambio`
     - `SolicitudCambioTurno`
     - `Inasistencia`
   - Actualizar `Empleado` con campos nuevos
   - Ejecutar migraciones

4. **Implementar esqueleto del backend**:
   - Estructura de proyecto ASP.NET Core
   - Configuración de Entity Framework
   - Setup de autenticación JWT
   - Configuración de SignalR

5. **Diseñar wireframes de apps móviles**:
   - App Jefe de Servicio: pantallas de gestión de cronogramas
   - App Empleado: pantallas de consulta y solicitudes
   - Validar diseños con usuarios

6. **Setup de infraestructura**:
   - Configurar repositorio Git
   - Setup de CI/CD pipeline
   - Preparar ambientes (dev, staging, prod)

---

**Fin del documento — MVP1 (Primera Entrega)**

**Versión:** 1.0  
**Última actualización:** Noviembre 2025
