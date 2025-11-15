# Proyecto: Sistema de Cronograma y Viandas — Hospital
## MVP2 - Segunda Entrega

**Versión:** 2.0  
**Fecha:** Noviembre 2025  
**Estado:** Planificación

---

## 1. Introducción

Este documento describe el alcance de la **Segunda Entrega (MVP2)** del Sistema de Cronograma y Viandas para Hospital. 

El MVP2 se enfoca en:
- Expansión de la **Interfaz Web completa** (Web Service) para todos los roles
- Implementación de **notificaciones en tiempo real** con SignalR
- Funcionalidades avanzadas no contempladas en MVP1
- Mejoras de experiencia de usuario y reportes avanzados

**Prerequisito:** MVP1 completamente funcional y desplegado.

---

## 2. Objetivos de la Segunda Entrega

### 2.1 Objetivo General

Expandir el sistema desarrollado en MVP1 con una **Interfaz Web completa** accesible desde navegadores de escritorio y móviles, implementando funcionalidades avanzadas y notificaciones en tiempo real mediante SignalR.

### 2.2 Objetivos Específicos

1. Desarrollar **Interfaz Web (Web Service)** completa para todos los roles:
   - Panel de Administrador
   - Panel de Jefe de Servicio
   - Panel de Jefe de Cocina
   - Panel de Empleado
   - Panel de Bachero

2. Implementar **SignalR** para:
   - Notificaciones push en tiempo real
   - Actualización dinámica de datos sin refrescar página
   - Comunicación bidireccional servidor-cliente

3. Ampliar funcionalidades de la **App Android del Jefe de Cocina**:
   - Gestión completa de menús y dietas desde la app
   - Aprobación/rechazo de viandas desde dispositivo móvil
   - Gestión de entregas excepcionales

4. Implementar **módulo completo del Bachero**:
   - App móvil para confirmación de entregas
   - Gestión de entregas excepcionales
   - Vista de viandas del día con estados

5. Desarrollar **reportes avanzados y tableros de BI**:
   - Dashboards interactivos
   - Análisis de consumo por servicio/período
   - Indicadores de gestión (KPIs)

6. Agregar funcionalidades avanzadas:
   - Gestión de entregas excepcionales para personal de visita
   - Sistema de permisos especiales
   - Exportación de datos avanzada

---

## 3. Actores / Roles (MVP2)

Los roles se mantienen del MVP1, pero con funcionalidades expandidas:

- **Administrador**: 
  - Gestión completa vía web
  - Configuración avanzada del sistema
  - Acceso a todos los reportes y tableros de BI
  
- **Jefe de Servicio**: 
  - Interfaz web completa (alternativa a la app móvil)
  - Dashboards de gestión de su servicio
  - Notificaciones en tiempo real de solicitudes y cambios
  
- **Jefe de Cocina**: 
  - **App móvil completa** con todas las funcionalidades del panel web
  - Gestión de menús, dietas y viandas desde dispositivo móvil
  - Aprobación de viandas en tiempo real desde cualquier lugar
  - Gestión de entregas excepcionales
  
- **Empleado**: 
  - **Panel web** para consultar cronograma y solicitudes (alternativa a app)
  - Notificaciones en tiempo real de cambios en cronograma
  
- **Bachero**: 
  - **App móvil** para confirmación de entregas
  - Vista de lista de viandas del día
  - Marcado de entregas realizadas/pendientes
  - Gestión de entregas excepcionales

---

## 4. Nuevos Requerimientos Funcionales (MVP2)

### 4.1 Interfaz Web (Web Service) - NUEVO

1. **Panel Web del Administrador**
   - Dashboard con métricas globales del sistema
   - Gestión completa de entidades (empleados, servicios, turnos, etc.)
   - Configuración avanzada del sistema
   - Reportes y exportaciones

2. **Panel Web del Jefe de Servicio**
   - Dashboard de su servicio con métricas en tiempo real
   - Gestión de cronogramas mensuales (crear/editar/visualizar)
   - Aprobación de solicitudes de cambio de turno
   - Gestión de inasistencias de empleados
   - Notificaciones en tiempo real con SignalR

3. **Panel Web del Jefe de Cocina**
   - Dashboard de viandas pendientes/aprobadas/rechazadas
   - Gestión de menús y tipos de dieta
   - Aprobación/rechazo de viandas generadas
   - Gestión de entregas excepcionales
   - Vista de calendario de viandas por día/semana/mes

4. **Panel Web del Empleado**
   - Vista de cronograma personal (calendario mensual)
   - Solicitar cambios de turno
   - Informar inasistencias con adjunto de certificado
   - Gestión de perfil (avatar, contraseña)
   - Historial de solicitudes y estados

5. **Panel Web del Bachero**
   - Lista de viandas del día por tipo (desayuno, almuerzo, merienda, cena)
   - Filtros por servicio, turno, tipo de dieta
   - Vista de entregas excepcionales
   - Impresión de listas operativas

### 4.2 SignalR - Notificaciones en Tiempo Real - NUEVO

1. **Hub de Notificaciones SignalR**
   - Conexión persistente con clientes (web y móvil)
   - Notificaciones push sin necesidad de refrescar
   - Grupos por roles y servicios

2. **Eventos en Tiempo Real**
   - Creación/modificación de cronograma → notifica a empleados afectados
   - Nueva solicitud de cambio → notifica a Jefe de Servicio
   - Aprobación/rechazo de solicitud → notifica a empleado solicitante
   - Nueva vianda pendiente → notifica a Jefe de Cocina
   - Inasistencia reportada → notifica a Jefe de Servicio
   - Cambio de turno de emergencia → notifica a todos los afectados

3. **Actualización Dinámica de Datos**
   - Actualización automática de listas y calendarios
   - Estados de viandas en tiempo real
   - Indicadores de usuarios conectados

### 4.3 App Móvil del Jefe de Cocina - NUEVO

1. **Funcionalidad Completa en App Android**
   - Todas las funciones disponibles en el panel web
   - Gestión de menús y tipos de dieta
   - Aprobación/rechazo de viandas desde dispositivo móvil
   - Vista de viandas pendientes con notificaciones push
   - Gestión de entregas excepcionales
   - Reportes básicos exportables

### 4.4 App Móvil del Bachero - NUEVO

1. **Confirmación de Entregas**
   - Vista de lista de viandas del día
   - Marcar como entregada (con timestamp)
   - Escaneo de código de barras del empleado (opcional)
   - Foto de evidencia de entrega (opcional)

2. **Gestión de Entregas Excepcionales**
   - Vista de entregas especiales/visitas
   - Tag/badge con cantidad a entregar
   - Marcado de entregas procesadas
   - Notificación al Jefe de Cocina cuando se completan

3. **Estados de Entregas**
   - PENDIENTE: vianda asignada pero no entregada
   - ENTREGADA: confirmada por bachero
   - NO_RETIRADA: pasó el horario sin retiro
   - CANCELADA: por inasistencia o cambio

### 4.5 Entregas Excepcionales y Personal de Visita - NUEVO

1. **Alta de Entrega Excepcional (Jefe de Cocina)**
   - Definir fecha/hora desde-hasta
   - Tipo de vianda y tipo de dieta
   - Seleccionar empleado existente O
   - Ingresar datos de personal de visita (nombre completo, DNI, institución)
   - Cantidad de viandas
   - Motivo/observaciones

2. **Gestión de Personal de Visita**
   - Tabla temporal `PersonalVisita` (no son usuarios del sistema)
   - Campos: Nombre, DNI, Institución, FechaVisita
   - Asociación con `AsignacionVianda` para entregas excepcionales

3. **Control de Entregas Excepcionales**
   - Vista especial para Bachero con tag distintivo
   - Listado separado de entregas regulares vs excepcionales
   - Historial de entregas a personal de visita

### 4.6 Reportes Avanzados y Tableros de BI - NUEVO

1. **Reportes Avanzados**
   - Reporte de consumo mensual por servicio (gráfico)
   - Reporte comparativo de tipos de dieta (gráficos de torta/barra)
   - Reporte de inasistencias y ausentismo por servicio
   - Reporte de eficiencia de aprobaciones (tiempos)
   - Análisis de solicitudes de cambio (más solicitadas, más aprobadas)

2. **Dashboards Interactivos**
   - Dashboard del Administrador: métricas globales
   - Dashboard del Jefe de Servicio: su servicio en tiempo real
   - Dashboard del Jefe de Cocina: viandas del día/semana
   - Filtros dinámicos por fecha, servicio, turno

3. **KPIs (Indicadores Clave)**
   - Tasa de aprobación de solicitudes de cambio
   - Porcentaje de viandas no retiradas por servicio
   - Tasa de ausentismo por servicio/mes
   - Tiempo promedio de aprobación de viandas
   - Consumo per cápita por tipo de vianda

4. **Exportaciones Avanzadas**
   - Exportar a Excel con múltiples hojas y gráficos
   - Exportar a PDF con formato profesional
   - Exportar datos crudos para análisis externo (CSV)
   - Programación de reportes automáticos por email (opcional)

---

## 5. Requerimientos No Funcionales (MVP2)

### 5.1 Performance

- Notificaciones SignalR con latencia < 500ms
- Dashboards interactivos con carga < 2 segundos
- Soporte de 100+ conexiones concurrentes de SignalR

### 5.2 Usabilidad

- Interfaz web responsive (mobile-first)
- Diseño consistente entre web y app móvil
- Accesibilidad WCAG 2.1 nivel AA (mínimo)

### 5.3 Escalabilidad

- SignalR con Redis backplane para múltiples instancias
- Caching de dashboards y reportes frecuentes
- Paginación y lazy loading en todas las listas

### 5.4 Seguridad

- Autenticación SignalR con JWT
- Rate limiting en APIs y conexiones SignalR
- Sanitización de datos en reportes exportados

### 5.5 Confiabilidad

- Reconexión automática de SignalR ante pérdida de conexión
- Fallback a polling si WebSockets no está disponible
- Logs de eventos SignalR para debugging

---

## 6. Arquitectura Propuesta (Cambios en MVP2)

### 6.1 Backend

- **ASP.NET Core Web API + MVC** (sin cambios)
- **SignalR Hubs**: 
  - `NotificationsHub`: notificaciones push
  - `CronogramaHub`: actualizaciones de cronogramas
  - `ViandasHub`: actualizaciones de viandas
- **Redis** (opcional): backplane para SignalR en entorno distribuido

### 6.2 Frontend Web

- **Tecnología**: ASP.NET Core MVC con Razor + JavaScript/jQuery
  - O alternativamente: **React/Vue.js** para SPA (Single Page Application)
- **SignalR Client Library**: `@microsoft/signalr` (JavaScript)
- **Charts**: Chart.js o ApexCharts para dashboards
- **UI Framework**: Bootstrap 5 o Tailwind CSS

### 6.3 App Móvil

- **Android** (Kotlin, MVVM)
- **SignalR Android Client**: `com.microsoft.signalr:signalr`
- **Retrofit**: consumo de API REST
- **Room**: caché local
- **CameraX**: captura de fotos para confirmación de entregas (Bachero)
- **ZXing**: escaneo de código de barras (opcional)

### 6.4 Base de Datos

- **Nuevas Tablas**:
  - `PersonalVisita`: datos de personal de visita
  - `EntregaExcepcional`: entregas especiales
  - `ConfirmacionEntrega`: confirmaciones del bachero
  - `SignalRConnection`: tracking de conexiones activas

---

## 7. Modelo de Datos - Nuevas Entidades (MVP2)

### 7.1 PersonalVisita

```csharp
public class PersonalVisita
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; }
    public string DNI { get; set; }
    public string Institucion { get; set; }
    public DateTime FechaVisita { get; set; }
    public string Motivo { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
}
```

### 7.2 EntregaExcepcional

```csharp
public class EntregaExcepcional
{
    public int Id { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }
    public int TipoViandaId { get; set; }
    public int TipoDietaId { get; set; }
    public int? EmpleadoId { get; set; } // null si es personal de visita
    public int? PersonalVisitaId { get; set; }
    public int Cantidad { get; set; }
    public string Observaciones { get; set; }
    public EstadoEntrega Estado { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
}
```

### 7.3 ConfirmacionEntrega

```csharp
public class ConfirmacionEntrega
{
    public int Id { get; set; }
    public int AsignacionViandaId { get; set; }
    public DateTime FechaHoraConfirmacion { get; set; }
    public int ConfirmadoPorUserId { get; set; } // Bachero
    public string FotoEvidenciaUrl { get; set; }
    public string Observaciones { get; set; }
    
    // Relaciones
    public AsignacionVianda AsignacionVianda { get; set; }
    public Usuario ConfirmadoPor { get; set; }
}
```

### 7.4 SignalRConnection

```csharp
public class SignalRConnection
{
    public int Id { get; set; }
    public string ConnectionId { get; set; }
    public int UserId { get; set; }
    public DateTime ConnectedAt { get; set; }
    public DateTime? DisconnectedAt { get; set; }
    public string DeviceInfo { get; set; }
    public bool IsActive { get; set; }
}
```

---

## 8. API REST - Nuevos Endpoints (MVP2)

### 8.1 Entregas Excepcionales

- `POST /api/entregas-excepcionales` — crear entrega excepcional
- `GET /api/entregas-excepcionales` — listar
- `GET /api/entregas-excepcionales/{id}` — obtener detalle
- `PUT /api/entregas-excepcionales/{id}` — actualizar
- `DELETE /api/entregas-excepcionales/{id}` — cancelar

### 8.2 Personal de Visita

- `POST /api/personal-visita` — registrar personal de visita
- `GET /api/personal-visita` — listar
- `GET /api/personal-visita/{id}` — obtener
- `GET /api/personal-visita/buscar?dni=...` — buscar por DNI

### 8.3 Confirmación de Entregas (Bachero)

- `POST /api/entregas/confirmar` — confirmar entrega
- `GET /api/entregas/pendientes` — viandas pendientes del día
- `GET /api/entregas/confirmadas?fecha=...` — entregas confirmadas
- `POST /api/entregas/{id}/foto` — subir foto de evidencia

### 8.4 Reportes Avanzados

- `GET /api/reportes/consumo-mensual?servicio=&mes=&ano=` — gráfico de consumo
- `GET /api/reportes/dietas?mes=&ano=` — distribución de tipos de dieta
- `GET /api/reportes/ausentismo?servicio=&mes=&ano=` — reporte de ausentismo
- `GET /api/reportes/kpis?fecha_desde=&fecha_hasta=` — indicadores clave
- `GET /api/reportes/exportar?tipo=excel&reporte=...` — exportar reporte

### 8.5 Dashboards

- `GET /api/dashboard/admin` — métricas globales
- `GET /api/dashboard/servicio/{servicioId}` — métricas del servicio
- `GET /api/dashboard/cocina` — métricas de cocina

---

## 9. SignalR Hubs

### 9.1 NotificationsHub

**Métodos del servidor:**

```csharp
public async Task SendNotification(int userId, Notification notification)
public async Task SendNotificationToRole(string role, Notification notification)
public async Task SendNotificationToGroup(string groupName, Notification notification)
```

**Eventos del cliente:**

- `ReceiveNotification(notification)` — recibir notificación
- `UpdateBadgeCount(count)` — actualizar contador de notificaciones

### 9.2 CronogramaHub

**Eventos del servidor:**

- `CronogramaCreated(cronogramaId, servicioId)`
- `CronogramaUpdated(cronogramaId, servicioId)`
- `CronogramaItemChanged(itemId, cronogramaId)`
- `SolicitudCambioCreated(solicitudId, servicioId)`
- `SolicitudCambioApproved(solicitudId, empleadoId)`

### 9.3 ViandasHub

**Eventos del servidor:**

- `ViandaGenerada(viandaId, servicioId)`
- `ViandaAprobada(viandaId, servicioId)`
- `ViandaRechazada(viandaId, servicioId, motivo)`
- `EntregaConfirmada(viandaId, bacheroId)`

---

## 10. Interfaz de Usuario - Pantallas Clave (MVP2)

### 10.1 Panel Web Administrador

- Dashboard con KPIs globales
- Gestión de empleados (CRUD completo)
- Gestión de servicios y turnos
- Configuración de tipos de vianda y dietas
- Gestión de usuarios y roles
- Reportes avanzados con gráficos interactivos
- Auditoría de sistema

### 10.2 Panel Web Jefe de Servicio

- Dashboard del servicio (presentes, ausentes, solicitudes pendientes)
- Calendario de cronograma mensual (interactivo)
- Gestión de solicitudes de cambio (aprobar/rechazar)
- Gestión de inasistencias
- Vista de viandas asignadas a su servicio
- Notificaciones en tiempo real

### 10.3 Panel Web Jefe de Cocina

- Dashboard de viandas (pendientes, aprobadas, rechazadas)
- Calendario de viandas por día/semana
- Gestión de menús y dietas
- Aprobación/rechazo de viandas con observaciones
- Gestión de entregas excepcionales
- Vista de confirmaciones de entregas del día

### 10.4 Panel Web Empleado

- Vista de cronograma personal (calendario)
- Formulario de solicitud de cambio de turno
- Formulario de informe de inasistencia (con upload de certificado)
- Historial de solicitudes y estados
- Perfil de usuario (avatar, contraseña)

### 10.5 Panel Web Bachero

- Lista de viandas del día (por tipo: desayuno, almuerzo, merienda, cena)
- Filtros por servicio, turno, tipo de dieta
- Vista de entregas excepcionales (con tag distintivo)
- Impresión de listas operativas
- Estadísticas del día

### 10.6 App Jefe de Cocina (Android)

- Login
- Dashboard móvil
- Lista de viandas pendientes (pull to refresh)
- Detalle de vianda con opción de aprobar/rechazar
- Gestión de menús y dietas
- Gestión de entregas excepcionales
- Notificaciones push en tiempo real

### 10.7 App Bachero (Android)

- Login
- Lista de viandas del día
- Botón de confirmar entrega (con timestamp automático)
- Opción de tomar foto de evidencia
- Opción de escanear código de barras del empleado
- Vista de entregas excepcionales
- Estados visuales (entregada/pendiente/no retirada)

---

## 11. Flujo de Trabajo - Ejemplos (MVP2)

### 11.1 Flujo: Entrega Excepcional para Personal de Visita

1. Jefe de Cocina accede al panel web o app móvil
2. Crea una entrega excepcional:
   - Ingresa datos del personal de visita (nombre, DNI, institución)
   - Define tipo de vianda y dieta
   - Define cantidad y horario
3. Sistema crea `PersonalVisita` y `EntregaExcepcional`
4. Notificación SignalR al Bachero sobre nueva entrega excepcional
5. Bachero ve la entrega en su lista con tag distintivo
6. Al momento de la entrega, Bachero confirma con foto opcional
7. Sistema registra `ConfirmacionEntrega`
8. Notificación SignalR al Jefe de Cocina de confirmación

### 11.2 Flujo: Notificación en Tiempo Real de Cronograma

1. Jefe de Servicio crea cronograma mensual vía panel web
2. Backend procesa y guarda el cronograma
3. SignalR `CronogramaHub` notifica a todos los empleados del servicio
4. Empleados conectados (web o app) reciben notificación instantánea
5. Panel/app del empleado actualiza automáticamente el calendario
6. Empleados desconectados verán notificación al conectarse

### 11.3 Flujo: Dashboard Interactivo del Jefe de Servicio

1. Jefe de Servicio accede al panel web
2. Dashboard carga con KPIs en tiempo real:
   - Empleados presentes hoy
   - Solicitudes pendientes
   - Inasistencias del mes
   - Viandas asignadas hoy
3. SignalR actualiza métricas automáticamente:
   - Nueva solicitud → contador aumenta
   - Inasistencia reportada → contador se actualiza
   - Sin necesidad de refrescar la página

---

## 12. MVP2 - Alcance Finalizado

**Funcionalidades Implementadas:**

- ✅ Interfaz Web completa para todos los roles (responsive)
- ✅ SignalR para notificaciones en tiempo real
- ✅ App móvil completa del Jefe de Cocina
- ✅ App móvil del Bachero con confirmación de entregas
- ✅ Gestión de entregas excepcionales y personal de visita
- ✅ Reportes avanzados con gráficos interactivos
- ✅ Dashboards con KPIs en tiempo real
- ✅ Exportaciones avanzadas (Excel, PDF, CSV)
- ✅ Estados de entregas (ENTREGADA, NO_RETIRADA, CANCELADA)
- ✅ Foto de evidencia de entregas (opcional)
- ✅ Escaneo de código de barras (opcional)

---

## 13. Funcionalidades para Entregas Futuras (Post-MVP2)

- Integración con sistema de RRHH del hospital
- Integración con sistema de stock de cocina
- Módulo de planificación de menús con recetas
- Notificaciones por email y SMS (además de push)
- App iOS (además de Android)
- Sistema de encuestas de satisfacción de viandas
- Machine Learning para predicción de consumo
- API pública para integraciones externas

---

## 14. Pruebas y QA (MVP2)

### 14.1 Pruebas Unitarias

- Tests de SignalR Hubs (mock de conexiones)
- Tests de lógica de entregas excepcionales
- Tests de generación de reportes avanzados
- Tests de cálculo de KPIs

### 14.2 Pruebas de Integración

- Tests de conexión SignalR end-to-end
- Tests de flujo de confirmación de entregas
- Tests de exportación de reportes
- Tests de dashboards con datos reales

### 14.3 Pruebas de Carga

- Simulación de 100+ conexiones concurrentes SignalR
- Carga de dashboards con grandes volúmenes de datos
- Exportación de reportes grandes (>10k filas)

### 14.4 Pruebas de UI/UX

- Tests de responsividad en diferentes dispositivos
- Tests de accesibilidad (WCAG 2.1)
- Tests de usabilidad con usuarios reales
- Tests de compatibilidad de navegadores

---

## 15. Plan de Despliegue (MVP2)

### 15.1 Prerequisitos

- MVP1 desplegado y funcionando
- Redis instalado (para SignalR backplane)
- HTTPS configurado (requerido para WebSockets)

### 15.2 Estrategia de Despliegue

- **Despliegue gradual**: primero web, luego apps móviles
- **Feature flags**: activar SignalR progresivamente
- **Rollback plan**: procedimiento de vuelta a MVP1 si hay issues críticos

### 15.3 Monitoreo

- Logs de SignalR (conexiones, desconexiones, errores)
- Métricas de performance de dashboards
- Alertas de errores en confirmación de entregas

---

## 16. Cronograma Estimado (MVP2)

**Duración estimada:** 8-10 semanas

1. **Semanas 1-2**: Diseño de interfaz web y SignalR
2. **Semanas 3-4**: Implementación de SignalR y notificaciones
3. **Semanas 5-6**: Desarrollo de paneles web para todos los roles
4. **Semana 7**: App móvil Jefe de Cocina y Bachero
5. **Semana 8**: Entregas excepcionales y personal de visita
6. **Semana 9**: Reportes avanzados y dashboards
7. **Semana 10**: Pruebas, ajustes y despliegue

---

## 17. Riesgos y Mitigaciones

| Riesgo | Impacto | Probabilidad | Mitigación |
|--------|---------|--------------|------------|
| Performance de SignalR con muchas conexiones | Alto | Media | Implementar Redis backplane, escalar horizontalmente |
| Compatibilidad de WebSockets en red hospitalaria | Alto | Media | Implementar fallback a long polling |
| Complejidad de reportes avanzados | Medio | Alta | Usar librerías probadas (Chart.js, EPPlus) |
| Adopción de nueva interfaz web por usuarios | Medio | Media | Capacitación y documentación clara |
| Errores en confirmación de entregas | Alto | Baja | Validaciones robustas, modo offline en app |

---

## 18. Dependencias y Tecnologías Adicionales

### 18.1 NuGet Packages

- `Microsoft.AspNetCore.SignalR` — SignalR Server
- `StackExchange.Redis` — Redis client para backplane
- `EPPlus` — generación de Excel avanzado
- `iTextSharp` o `QuestPDF` — generación de PDF
- `CsvHelper` — exportación CSV

### 18.2 NPM Packages (Frontend Web)

- `@microsoft/signalr` — SignalR JavaScript Client
- `chart.js` — gráficos interactivos
- `apexcharts` (alternativa) — gráficos avanzados
- `bootstrap` o `tailwindcss` — UI framework
- `axios` — HTTP client

### 18.3 Android Dependencies

- `com.microsoft.signalr:signalr` — SignalR Android Client
- `com.squareup.retrofit2:retrofit` — HTTP client
- `androidx.room:room-runtime` — base de datos local
- `androidx.camera:camera-camera2` — captura de fotos
- `com.google.zxing:core` — escaneo de códigos de barras

---

## 19. Siguientes Pasos Inmediatos

1. Revisar y aprobar este documento con stakeholders
2. Diseñar mockups de interfaz web (Figma/Balsamiq)
3. Definir esquema de base de datos para nuevas entidades
4. Configurar proyecto SignalR (Hubs y middleware)
5. Implementar infraestructura de Redis para SignalR
6. Comenzar desarrollo de paneles web por rol

---

**Fin del documento — MVP2 (Segunda Entrega)**

**Versión:** 2.0  
**Última actualización:** Noviembre 2025
