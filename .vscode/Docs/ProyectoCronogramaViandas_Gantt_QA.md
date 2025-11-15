# Proyecto Cronograma y Viandas – Gantt y Plan de Pruebas

## 1. Gantt de alto nivel del proyecto

> Nota: Este apartado describe las actividades; el diagrama Gantt se puede construir en una herramienta como Excel, Project, Trello/Gantt o similar y exportarse como imagen (`./img/gantt_proyecto.png`).

### 1.1 Fases principales

1. **Relevamiento y análisis inicial** (Semana 1–2)

   - Entrevistas con Jefes de Servicio y Jefe de Cocina.
   - Revisión de procesos actuales (cronogramas, viandas, dietas, inasistencias).
   - Consolidación de requerimientos (documentos MVP1 y v2).

2. **Análisis detallado y diseño** (Semana 3–4)

   - Definición de casos de uso y actores.
   - Modelo de dominio (DER/Clases).
   - Diseño de arquitectura (capas, APIs, módulos).
   - Diseño de interfaces (web + móvil).

3. **Implementación backend (API + lógica de negocio)** (Semana 5–7)

   - Configuración del proyecto ASP.NET Core.
   - Implementación de entidades y contexto EF Core.
   - Implementación de endpoints principales (auth, empleados, servicios, cronograma, viandas, solicitudes, inasistencias).
   - Manejo de roles y autenticación JWT.

4. **Implementación frontend web** (Semana 6–8)

   - Vistas MVC / React/Blazor para administración.
   - Módulos: Empleados, Servicios, Cronograma, Viandas, Reportes.

5. **Implementación app Android (Empleado + Jefe de Servicio)** (Semana 7–9)

   - Pantallas de login, cronograma, solicitudes e inasistencias.
   - Consumo de API con Retrofit.
   - Integración con FCM para notificaciones básicas.

6. **Pruebas unitarias, integración y ajustes** (Semana 9–10)

   - Pruebas sobre lógica de negocio crítica.
   - Pruebas de endpoints clave.
   - Corrección de defectos.

7. **Documentación y preparación de entrega** (Semana 10)
   - Actualización de documentación funcional y técnica.
   - Exportación de diagramas (CU, clases, UI) a imágenes.
   - Generación de PDF finales.

### 1.2 Tareas sugeridas para el Gantt

Se sugiere dividir el Gantt en tareas como:

- Análisis de requerimientos
- Diseño de modelo de datos
- Diseño de APIs
- Implementación de autenticación
- Implementación de módulo Cronograma
- Implementación de módulo Viandas
- Implementación de módulo Solicitudes de cambio
- Implementación de módulo Inasistencias
- Implementación de reportes
- Pruebas unitarias
- Pruebas de integración
- Documentación

El Gantt puede ser representado como una tabla en el documento o como una imagen:

```markdown
![Gantt del Proyecto](./img/gantt_proyecto.png)
```

---

## 2. Plan de Pruebas / QA

### 2.1 Pruebas unitarias sobre lógica de ventanas y generación de viandas

**Objetivo:** Validar que la lógica de negocio que decide qué viandas se generan, en qué horario y bajo qué condiciones, se comporta correctamente.

**Áreas a cubrir:**

1. **Ventanas de entrega (`TipoVianda.HoraInicio/HoraFin`)**

   - Se genera vianda solo si el turno y la fecha/hora del cronograma caen dentro del rango configurado.
   - Pruebas con valores límite (exactamente en `HoraInicio` y `HoraFin`).

2. **Ventanas de cambio (`VentanaCambio.HoraLimiteCambio`)**

   - El Jefe de Servicio puede reemplazar empleados en el día **solo** hasta la hora límite.
   - Casos de prueba:
     - Reemplazo antes de `HoraLimiteCambio` → permitido.
     - Reemplazo después de `HoraLimiteCambio` → rechazado con mensaje adecuado.

3. **Tipos de dieta**

   - Asignación de viandas respeta `TipoDieta` del empleado.
   - Casos: dieta normal, blanda, diabético, etc.

4. **Estados de Asignación de vianda**
   - Generación inicial en estado `PENDIENTE`.
   - Cambio de estado a `APROBADA` o `RECHAZADA` por parte del Jefe de Cocina.

**Ejemplos de casos de prueba unitarios (pseudo):**

- `GenerarViandas_DeberiaCrearAsignacionPendiente_ParaCronogramaDentroDeRango()`
- `GenerarViandas_NoDebeCrearAsignacion_FueraDeHorarioDeTipoVianda()`
- `ReemplazarEmpleado_DeberiaPermitirAntesDeHoraLimite()`
- `ReemplazarEmpleado_NoDebePermitirDespuesDeHoraLimite()`

Se recomienda usar **xUnit/NUnit** para las pruebas unitarias del backend.

---

### 2.2 Pruebas de integración de endpoints clave

**Objetivo:** Verificar que los endpoints REST funcionan correctamente, incluyendo base de datos, autenticación y reglas de negocio básicas.

**Endpoints clave a probar:**

1. **Auth**

   - `POST /api/auth/login` → devuelve JWT válido para credenciales correctas.
   - Rechaza credenciales incorrectas.

2. **Empleados**

   - `GET /api/empleados` → listado con paginación.
   - `POST /api/empleados` → creación con validación de datos.
   - `PUT /api/empleados/{id}` → actualización.

3. **Cronogramas**

   - `POST /api/cronogramas` → creación de cronograma mensual.
   - `GET /api/cronogramas/servicio/{servicioId}?mes=&anio=` → obtención para Jefe de Servicio.
   - `POST /api/cronogramas/{id}/items/{itemId}/reemplazar` → reemplazo de empleado respetando ventanas.

4. **Viandas**

   - `POST /api/viandas/generar?cronogramaId=` → genera asignaciones según reglas.
   - `GET /api/viandas/pendientes` → listado de viandas en estado `PENDIENTE`.
   - `POST /api/viandas/{id}/aprobar` / `rechazar`.

5. **Solicitudes de cambio de turno**

   - `POST /api/solicitudes/cambio` → creación por empleado autenticado.
   - `GET /api/solicitudes/servicio/{servicioId}` → vista del Jefe de Servicio.
   - `POST /api/solicitudes/{id}/aprobar` / `rechazar`.

6. **Inasistencias**
   - `POST /api/inasistencias` → creación con archivo adjunto opcional.
   - `GET /api/inasistencias/servicio/{servicioId}` → revisión por Jefe de Servicio.

**Estrategia:**

- Usar **pruebas de integración con un entorno de base de datos de pruebas** (por ejemplo, SQLite in-memory o una instancia de SQL local).
- Levantar el WebApplicationFactory (en ASP.NET Core) para probar endpoints reales.
- Preparar datos semilla (servicios, empleados, tipos de vianda, dietas) para escenarios de prueba.

---

### 2.3 Pruebas end-to-end (E2E) básicas

Opcionalmente, se pueden definir pruebas E2E que cubran el flujo completo:

1. Jefe de Servicio crea cronograma mensual.
2. Sistema genera viandas.
3. Jefe de Cocina aprueba viandas.
4. Empleado consulta su cronograma.
5. Empleado solicita cambio de turno.
6. Jefe de Servicio aprueba/rechaza la solicitud.

Estas pruebas pueden realizarse manualmente en la primera instancia y luego automatizarse con herramientas de testing de UI si el alcance lo permite.

---

## 3. Relación con el Desarrollo del Prototipo

Las actividades de Gantt y el plan de pruebas descritos en este documento complementan la sección **"Desarrollo del Prototipo"** del documento principal, aportando:

- Una visión temporal (cronograma de tareas).
- Un enfoque sistemático de **QA** para asegurar la calidad del prototipo.
