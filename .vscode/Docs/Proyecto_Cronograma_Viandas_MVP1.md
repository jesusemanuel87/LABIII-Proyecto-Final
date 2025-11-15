Proyecto: Sistema de Cronograma y Viandas — Hospital
Resumen: Aplicación web (ASP.NET Core) + aplicación móvil Android para gestionar cronogramas laborales mensuales por jefe de servicio, asignación automática de viandas según turnos, aprobación por jefe de cocina y control de entregas. Incluye CRUD, reglas por horario, control de dietas, registros de auditoría y notificaciones.

---

1. Objetivos (actualizados para la Primer Entrega)
   • Permitir al jefe del servicio programar y gestionar el cronograma mensual de sus empleados (turnos mañana/tarde/noche) vía app móvil o web.
   • Asignar automáticamente el tipo de vianda (desayuno, almuerzo, merienda, cena) según el turno y horarios configurados por servicio (parametrizables).
   • Gestionar tipos de dieta y menús; que el jefe de cocina apruebe o rechace las viandas generadas (módulo web y app para segunda entrega).
   • Controlar permisos y roles (Administrador, Jefe de Servicio, Jefe de Cocina, Bachero, Empleado).
   • Reportes (resumen por día/servicio/tipo de dieta), auditoría y trazabilidad.
   Nota: Para la Primer Entrega (MVP1) se quita la confirmación de entrega por parte del bachero vía app (la entrega se registra inicialmente por lista/operativa interna y se documenta para reportes). La confirmación por app pasa a considerarse en una entrega posterior.

---

2. Actores / Roles (actualizados)
   • Administrador: configura servicios, horarios, roles, usuarios.
   • Jefe de Servicio: crea/edita cronogramas mensuales para su servicio desde la app o web; gestiona reemplazos y cambios (respetando ventanas de tiempo límites configurables).
   • Jefe de Cocina: revisa viandas generadas y aprueba/rechaza menús; gestiona menús y dietas (en la Primer Entrega: interfaz web; en la Segunda Entrega: app móvil con permisos completos).
   • Bachero: recibe lista de viandas por entregar (operativa); en entregas posteriores tendrá módulo para confirmar entregas y ver excepciones.
   • Empleado: accede vía app (DNI + contraseña) para ver su cronograma, solicitar cambios de turno, informar inasistencias y gestionar su perfil.

---

3. Requerimientos funcionales (Primer Entrega - alto nivel, cambios aplicados)
1. CRUD completo para: Empleados, Usuarios, Roles, Servicios, Turnos, Tipos de Vianda, Tipos de Dieta, Menús/Viandas.
1. Configuración por servicio de horarios de entrada y salida para cada turno.
1. Generador automático de viandas basado en cronograma y reglas de horario.
1. Flujo de aprobación de viandas por jefe de cocina (aprobar/rechazar con observaciones).
1. Se elimina la confirmación de entrega por bachero vía app en la Primer Entrega.
1. Habilitación/deshabilitación de tipos de vianda según horario (parametrizable por servicio).
1. Gestión de horarios de entrega parametrizables: (ejemplo por defecto) Desayuno 07:00–10:00; Almuerzo 12:00–14:00; Merienda 16:00–18:00; Cena 20:00–22:00. Estos rangos deben poder configurarse por servicio y por tipo de vianda.
1. Ventanas límite para cambios/reemplazos el mismo día: por ejemplo: Desayuno — hasta 07:00; Almuerzo — hasta 11:00; Merienda — hasta 15:00; Cena — hasta 19:00. Estas reglas son parametrizables por servicio y por tipo de vianda.
1. El Jefe de Servicio puede realizar cambios/reemplazos de la persona asignada en el cronograma (respetando la regla de ventanas límite para el día actual).
1. Acceso de Empleados vía app: login con DNI y contraseña para ver cronograma personal.
1. Solicitud de cambio de turno por empleado (vía app): el empleado puede solicitar cambio indicando día, turno deseado, motivo y opcionalmente con cuál empleado desea cambiar. La solicitud genera notificación al Jefe de Servicio y estado de la solicitud (pendiente/aprobada/rechazada).
1. Informe de inasistencia por empleado (vía app): el empleado puede informar inasistencia indicando desde/hasta, motivo y anexar certificado (archivo). Se notifica al Jefe de Servicio.
1. Perfil de empleado en app: ver datos del perfil, cambiar avatar (imagen) y cambiar contraseña.
1. Notificaciones push (FCM) para avisos: creación/actualización de cronograma, solicitudes de cambio, inasistencias, viandas pendientes de aprobación, rechazos.
1. Reportes exportables (PDF/Excel): por día, por servicio, por tipo de dieta, lista de asignaciones y ausencias.
1. Auditoría de cambios: quién hizo qué y cuándo (logs de cambios en cronogramas, aprobaciones, solicitudes y modificaciones).

---

4. Requerimientos no funcionales (sin cambios principales)
   • Autenticación y autorización robusta (JWT + roles/claims). HTTPS obligatorio.
   • Escalabilidad: diseño modular, APIs REST bien definidas.
   • Rendimiento: consultas de calendario optimizadas; paginación en listados.
   • Disponibilidad: backups y despliegue en contenedores (Docker).

---

5. Arquitectura propuesta (ajustes)
   • Backend: ASP.NET Core Web API + Entity Framework Core
   • Base de datos: SQL Server / PostgreSQL con migraciones EF Core
   • Autenticación: Identity + JWT (empleados con credenciales DNI + contraseña)
   • Android: Kotlin, MVVM, Retrofit, Room, WorkManager, FCM
   • Frontend Web: React o Blazor para administración; la app móvil del Jefe de Servicio tendrá funciones de edición de cronograma.

---

6. Modelo de datos (resumen de tablas principales — cambios aplicados)
   Se mantienen las tablas principales del modelo original, con adiciones y campos nuevos:
   • Usuario / Rol (sin cambios) — usuarios del sistema
   • Empleado: agrega CodigoBarras, AvatarUrl
   • Servicio (sin cambios)
   • Turno (sin cambios)
   • ConfiguracionServicioTurno: mantiene horarios ajustables por servicio
   • Cronograma / CronogramaItem: CronogramaItem contiene Id, CronogramaId, EmpleadoId, Fecha, TurnoId, CreatedBy, CreatedAt, Estado.
   • TipoVianda: ahora con HoraInicio, HoraFin (parametrizables)
   • VentanaCambio (nueva tabla): define por TipoVianda y/o Turno y Servicio el HoraLimiteCambio para el día actual.
   • SolicitudCambioTurno (nueva tabla): para que el empleado solicite cambio (IdSolicitud, IdEmpleado, FechaSolicitada, TurnoOrigen, TurnoDestino, Motivo, IdEmpleadoSugerido, Estado, FechaSolicitud)
   • Inasistencia (nueva tabla): Id, IdEmpleado, FechaDesde, FechaHasta, Motivo, ArchivoSoporteUrl, Estado, FechaNotificacion
   • Menu, TipoDieta, AsignacionVianda (sin cambios funcionales importantes)
   • AuditLog (sin cambios)

---

7. Reglas de negocio principales (actualizadas)
   • Cada servicio define hora inicio/fin por turno y los rangos válidos de entrega por tipo de vianda.
   • La asignación de vianda respeta TipoDieta del empleado.
   • Generación de viandas crea asignaciones en estado PENDIENTE para aprobación por Jefe de Cocina.
   • Cambio/reemplazo en el día actual: el sistema solo permite que el Jefe de Servicio realice cambios/reemplazos para la fecha actual hasta la HoraLimiteCambio configurada para el TipoVianda correspondiente.
   • Solicitudes de cambio por empleado: crean un flujo de aprobación donde el Jefe de Servicio decide (aprueba/rechaza) y el sistema notifica a las partes.
   • Inasistencias: el empleado puede adjuntar certificado; el Jefe de Servicio recibe la notificación y puede validar/aceptar la justificación.

---

8. API REST (endpoints ajustados — Primer Entrega)
   • Auth
   o POST /api/auth/login — devuelve JWT (empleado puede usar DNI + contraseña)
   • Empleados
   o GET /api/empleados — listado
   o POST /api/empleados — crear
   o PUT /api/empleados/{id} — actualizar
   o GET /api/empleados/{id}/perfil — datos del perfil (para app)
   o PUT /api/empleados/{id}/avatar — subir avatar
   o PUT /api/empleados/{id}/password — cambiar contraseña
   • Cronograma / CronogramaItem
   o POST /api/cronogramas — crear cronograma mensual (payload: servicio, mes, ano, items)
   o PUT /api/cronogramas/{id} — actualizar
   o POST /api/cronogramas/{id}/items/{itemId}/reemplazar — reemplazar empleado (valida ventana límite)
   o GET /api/cronogramas/servicio/{servicioId}?mes=...&ano=... — listado para Jefe de Servicio (app)
   • Solicitudes de cambio (empleados)
   o POST /api/solicitudes/cambio — crea solicitud (empleado)
   o GET /api/solicitudes/servicio/{servicioId} — listado para Jefe de Servicio
   o POST /api/solicitudes/{id}/aprobar — Jefe de Servicio aprueba
   o POST /api/solicitudes/{id}/rechazar — Jefe de Servicio rechaza
   • Inasistencias
   o POST /api/inasistencias — empleado informa inasistencia (adjunta archivo opcional)
   o GET /api/inasistencias/servicio/{servicioId} — Jefe de Servicio revisa
   • Viandas / Menús
   o POST /api/viandas/generar?cronogramaId=...
   o GET /api/viandas/pendientes — Jefe Cocina
   o POST /api/viandas/{id}/aprobar
   o POST /api/viandas/{id}/rechazar (con motivo)
   • Configuración de ventanas / horarios de entrega
   o GET /api/config/tiposvianda — devuelve rangos por defecto y por servicio
   o PUT /api/config/tiposvianda/{id} — actualizar rangos (HoraInicio/HoraFin)
   o PUT /api/config/ventanacambio/{id} — actualizar hora límite para cambios del día

---

9. Interfaz de usuario (pantallas clave — Primer Entrega)
   App Jefe de Servicio (Android) - Login - Dashboard servicio: resumen (presentes, ausentes, viandas pendientes) - Gestión de Cronograma Mensual: crear/editar cronograma, reemplazar personal (valida ventana límite del día) - Listado de solicitudes de cambio y aprobación - Notificaciones push para solicitudes/inasistencias
   App Empleado (Android) - Login con DNI y contraseña - Ver cronograma personal (día/semana/mes) - Solicitar cambio de turno (día, turno, motivo, opción de proponer compañero) - Informar inasistencia (adjuntar certificado) - Ver y editar perfil (avatar, contraseña)
   Web / Panel administrativo (React/Blazor) - Gestión completa: Empleados, Servicios, Turnos, TiposVianda, TipoDieta, Menús - Panel Jefe de Cocina: revisar y aprobar menús - Reportes y exportación

---

10. Flujo de trabajo (ejemplo actualizado)
1. Jefe de Servicio crea cronograma mensual y asigna turnos a empleados (puede hacerlo vía app o web).
1. Sistema genera AsignacionVianda en estado PENDIENTE según reglas y ventanas configuradas.
1. Jefe de Cocina revisa y aprueba los menús/viandas.
1. Listado operativo de entrega (para Bachero) se genera desde el sistema; la confirmación por app del bachero queda para una entrega posterior.
1. Empleado puede solicitar cambios, reportar inasistencias y ver su cronograma desde la app.

---

11. MVP1 (Primer Entrega) — Alcance finalizado
    • Autenticación y roles básicos (incluye login empleado con DNI)
    • CRUD Empleados/Servicios/Turnos/TipoVianda/TipoDieta
    • Editor de cronograma mensual básico (app + web)
    • Gestión de ventanas de entrega por TipoVianda (parametrizable)
    • Ventanas de cambio/reemplazo del día (parametrizables) y lógica de bloqueo
    • Jefe de Servicio: gestión de cronogramas desde app (crear/editar/reemplazar)
    • Empleado: login, ver cronograma, solicitar cambio de turno, informar inasistencia, editar perfil
    • Generación automática de viandas y flujo de aprobación por Jefe de Cocina (web)
    • Notificaciones básicas (FCM)
    • Reportes básicos y auditoría

---

12. Funcionalidades para la Segunda Entrega (prioridad baja/mediana)
    • App Jefe de Cocina: que pueda realizar desde la app todas las acciones que realiza en la web (aprobar/rechazar, gestionar menús y dietas, ver asignaciones).
    • Permisos especiales (excepciones) por Jefe de Cocina: agregar entregas excepcionales desde/hasta, tipo de vianda y tipo de dieta; seleccionar personal existente o personal de visita (debe ingresar nombre completo y DNI).
    • Sección especial para Bachero: listados de entregas especiales/excepciones con un bag/tag indicando la cantidad a entregar en el día y posibilidad de marcar como procesado (en esta entrega secundaria se puede agregar la confirmación por app).

---

13. Pruebas, QA y despliegue (sin cambios mayores)
    • Unit tests para lógica de ventanas y validaciones de reemplazo.
    • Integration tests para endpoints de solicitudes y notificaciones.
    • E2E del flujo (cronograma → generación → aprobación → solicitudes de cambio → reportes).
    • Despliegue con Docker y CI/CD.

---

14. Siguientes pasos inmediatos sugeridos
1. Confirmar y parametrizar las ventanas (horarios de entrega y límites de cambio) por servicio con stakeholders.
1. Actualizar el modelo físico (DDL) incluyendo las tablas nuevas: VentanaCambio, SolicitudCambioTurno, Inasistencia y campos nuevos en Empleado.
1. Implementar el esqueleto del backend (tengo ya un documento con el esqueleto — puedo generar el proyecto).
1. Diseñar las pantallas del Jefe de Servicio en la app (wireframes) para la gestión de cronogramas.

---

Fin del documento — versión Primer Entrega (actualizada).
