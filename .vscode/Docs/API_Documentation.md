# API REST - Sistema de Cronograma y Viandas

**Base URL:** `https://api.cronograma-viandas.hospital.gob.ar/api`  
**Autenticación:** JWT Bearer Token  
**Versión:** 1.0 (MVP1)

---

## Autenticación

### POST /auth/login
```json
Request:  { "username": "string", "password": "string" }
Response: { "token": "JWT...", "expiration": "2025-11-15T18:30:00Z", "user": {...} }
```

### POST /auth/refresh
Renovar token JWT. Requiere header `Authorization: Bearer {token}`

---

## Empleados

### GET /empleados
Query: `servicioId`, `activo`, `page`, `pageSize`  
Autorización: Administrador, Jefe de Servicio

### GET /empleados/{id}
Detalle de empleado

### POST /empleados
Crear empleado. Autorización: Administrador

### PUT /empleados/{id}
Actualizar empleado

### GET /empleados/{id}/perfil
Perfil del empleado autenticado

### PUT /empleados/{id}/avatar
Subir avatar (Multipart/form-data)

### PUT /empleados/{id}/password
```json
{ "currentPassword": "...", "newPassword": "...", "confirmPassword": "..." }
```

---

## Servicios

### GET /servicios
Listado de servicios con configuración de turnos

### POST /servicios
Crear servicio. Autorización: Administrador

### PUT /servicios/{id}
Actualizar servicio

---

## Cronogramas

### GET /cronogramas
Query: `servicioId`, `mes`, `ano`

### GET /cronogramas/{id}
Detalle con items del cronograma

### POST /cronogramas
```json
{
  "servicioId": 2, "mes": 12, "ano": 2025,
  "items": [
    { "fecha": "2025-12-01", "empleadoId": 5, "turnoId": 1 }
  ]
}
```

### POST /cronogramas/{id}/generar-viandas
Generar viandas automáticamente

### POST /cronogramas/{id}/publicar
Publicar cronograma (notifica empleados)

### POST /cronogramas/{cronogramaId}/items/{itemId}/reemplazar
```json
{ "nuevoEmpleadoId": 18 }
```
Error 400 si fuera de ventana de cambio

---

## Viandas

### GET /viandas
Query: `fecha`, `servicioId`, `estado`, `page`, `pageSize`

### GET /viandas/pendientes
Viandas PENDIENTES para Jefe de Cocina

### POST /viandas/{id}/aprobar
```json
{ "observaciones": "Aprobado" }
```

### POST /viandas/{id}/rechazar
```json
{ "motivo": "Menú no disponible" }
```

### POST /viandas/aprobar-multiples
```json
{ "viandaIds": [5001, 5002], "observaciones": "Lote aprobado" }
```

---

## Menús y Dietas

### GET /menus
Query: `tipoViandaId`, `tipoDietaId`, `activo`

### POST /menus
Crear menú. Autorización: Jefe de Cocina, Administrador

### GET /tipos-dieta
Listado de tipos de dieta (Normal, Blanda, Diabético, etc.)

---

## Solicitudes de Cambio

### GET /solicitudes/cambio
Query: `servicioId`, `estado`

### POST /solicitudes/cambio
```json
{
  "fechaSolicitada": "2025-11-18",
  "turnoOrigenId": 1, "turnoDestinoId": 2,
  "motivo": "Trámite personal",
  "empleadoSugeridoId": 12
}
```

### POST /solicitudes/{id}/aprobar
```json
{ "observaciones": "Aprobado" }
```

### POST /solicitudes/{id}/rechazar
```json
{ "motivoRechazo": "No hay reemplazo disponible" }
```

---

## Inasistencias

### GET /inasistencias
Query: `servicioId`, `estado`

### POST /inasistencias
Multipart/form-data:
- `fechaDesde`, `fechaHasta`, `motivo`
- `certificado` (file, opcional, max 5MB)

### POST /inasistencias/{id}/marcar-revisada
```json
{ "observaciones": "Certificado verificado" }
```

---

## Configuración

### GET /config/tipos-vianda
Horarios de tipos de vianda (Desayuno, Almuerzo, etc.)

### PUT /config/tipos-vianda/{id}
```json
{ "horaInicio": "07:30:00", "horaFin": "10:30:00" }
```

### GET /config/ventanas-cambio
Query: `servicioId`

### PUT /config/ventanas-cambio/{id}
```json
{ "horaLimiteCambio": "06:30:00" }
```

---

## Reportes

### GET /reportes/viandas-dia
Query: `fecha`, `servicioId`, `formato` (json|pdf|excel)

### GET /reportes/solicitudes
Query: `fechaDesde`, `fechaHasta`, `servicioId`, `formato`

### GET /reportes/inasistencias
Query: `mes`, `ano`, `servicioId`, `formato`

### GET /reportes/ausentismo
Query: `mes`, `ano`

---

## Códigos de Estado HTTP

**Éxito:** 200 OK, 201 Created, 204 No Content  
**Errores Cliente:** 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found, 409 Conflict, 422 Unprocessable Entity  
**Errores Servidor:** 500 Internal Server Error

**Formato de Error:**
```json
{
  "error": "TipoError",
  "message": "Descripción",
  "details": { "campo": "detalle" }
}
```

---

**Documentación completa en Swagger:** `https://api.cronograma-viandas.hospital.gob.ar/swagger`
