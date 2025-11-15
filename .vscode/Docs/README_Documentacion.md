# Índice de Documentación del Proyecto
## Sistema de Cronograma y Viandas - Hospital

**Última actualización:** Noviembre 2025

---

## 📚 Documentos Principales

### 1. Documentación de Presentación y Análisis

#### ProyectoCronogramaViandas_Presentacion.md
**Descripción:** Documento académico formal con toda la información del proyecto.

**Contenido:**
- Introducción y justificación del proyecto
- Objetivos generales y específicos
- Alcance y límites del sistema
- Requerimientos funcionales y no funcionales
- Análisis y diseño detallado
- Tecnologías utilizadas
- Competencia y diferenciadores
- Bibliografía y anexos

**Audiencia:** Cliente, evaluadores académicos, stakeholders

---

#### ProyectoCronogramaViandas_MVP1.md
**Descripción:** Especificación técnica detallada de la primera entrega.

**Contenido:**
- Objetivos del MVP1
- Actores y roles del sistema
- Requerimientos funcionales detallados (17 puntos)
- Requerimientos no funcionales
- Arquitectura propuesta (Backend, Frontend, App móvil)
- Modelo de datos (tablas y relaciones)
- Reglas de negocio principales
- Endpoints de API REST
- Pantallas clave de interfaz
- Alcance finalizado del MVP1

**Audiencia:** Equipo de desarrollo, arquitectos

---

#### ProyectoCronogramaViandas_MVP2.md ✨
**Descripción:** Especificación de la segunda entrega con funcionalidades avanzadas.

**Contenido:**
- Objetivos del MVP2
- Interfaz Web completa (Web Service) para todos los roles
- Implementación de SignalR para notificaciones en tiempo real
- App móvil completa del Jefe de Cocina
- App móvil del Bachero con confirmación de entregas
- Gestión de entregas excepcionales y personal de visita
- Reportes avanzados y tableros de BI
- Nuevas entidades de base de datos
- Endpoints adicionales de API
- Plan de despliegue y cronograma (8-10 semanas)

**Audiencia:** Equipo de desarrollo, stakeholders

---

#### ProyectoCronogramaViandas_Gantt_QA.md
**Descripción:** Planificación temporal del proyecto y plan de pruebas.

**Contenido:**
- Diagrama de Gantt (10 semanas, 7 fases)
- Tareas detalladas del proyecto
- Plan de pruebas unitarias
- Plan de pruebas de integración
- Pruebas end-to-end (E2E)
- Relación con el desarrollo del prototipo

**Audiencia:** Project Manager, equipo de QA

---

### 2. Documentación para Usuarios

#### Manual_Usuario.md ✨
**Descripción:** Guía de uso del sistema para todos los roles.

**Contenido:**
- Introducción y acceso al sistema
- **Manual del Administrador**: Gestión de empleados, servicios, configuración
- **Manual del Jefe de Servicio**: Cronogramas, solicitudes, inasistencias
- **Manual del Jefe de Cocina**: Menús, aprobación de viandas, entregas excepcionales
- **Manual del Empleado**: App móvil, cronograma personal, solicitudes, inasistencias
- **Manual del Bachero (MVP2)**: Confirmación de entregas, código QR, fotos
- FAQ y Soporte Técnico

**Audiencia:** Usuarios finales del sistema

---

### 3. Documentación Técnica

#### API_Documentation.md ✨
**Descripción:** Documentación completa de la API REST.

**Contenido:**
- Autenticación JWT
- Endpoints de Empleados (CRUD, perfil, avatar, password)
- Endpoints de Servicios y Turnos
- Endpoints de Cronogramas (crear, editar, reemplazar, publicar)
- Endpoints de Viandas (aprobar, rechazar, múltiples)
- Endpoints de Menús y Dietas
- Endpoints de Solicitudes de Cambio
- Endpoints de Inasistencias
- Endpoints de Configuración (tipos vianda, ventanas cambio)
- Endpoints de Reportes
- Códigos de estado HTTP y formato de errores

**Audiencia:** Desarrolladores frontend, integradores

---

### 4. Diagramas UML

#### img/DiagramaCasosUsoGeneral.puml ✨
**Descripción:** Diagrama PlantUML de casos de uso del sistema.

**Contenido:**
- 5 actores principales
- 6 paquetes de funcionalidad:
  - Gestión de Configuración (8 casos de uso)
  - Gestión de Cronogramas (5 casos de uso)
  - Gestión de Viandas (5 casos de uso)
  - Gestión de Solicitudes (5 casos de uso)
  - Consultas y Reportes (5 casos de uso)
  - Notificaciones (2 casos de uso)
- Relaciones include y extend
- Notas explicativas

**Formato:** PlantUML (.puml) → exportar a PNG/SVG/PDF

---

#### img/DiagramaClasesCronogramaViandas.puml ✨
**Descripción:** Diagrama de clases del dominio completo.

**Contenido:**
- 20+ entidades del sistema
- Relaciones y cardinalidades
- Atributos principales de cada clase
- Enums (EstadoCronograma, EstadoVianda, etc.)
- Entidades MVP1 y MVP2 diferenciadas
- Notas explicativas de lógica de negocio

**Formato:** PlantUML (.puml) → exportar a PNG/SVG/PDF

---

#### img/UIMockupsCronogramaViandas.puml ✨ NUEVO
**Descripción:** Mockups de interfaz de usuario en salt (PlantUML).

**Contenido:**
- Dashboard del Administrador
- Panel del Jefe de Servicio (cronograma mensual)
- Panel del Jefe de Cocina (viandas pendientes)
- App móvil del Empleado (cronograma personal)
- App móvil del Bachero (entregas del día)

**Formato:** PlantUML salt (.puml) → exportar a PNG

---

#### img/DiagramaERD.puml ✨
**Descripción:** Diagrama Entidad-Relación de la base de datos.

**Contenido:**
- 23 tablas del sistema
- Claves primarias y foráneas
- Tipos de datos
- Relaciones (1:1, 1:N, N:M)
- Tablas MVP1 y MVP2
- Constraints y enums

**Formato:** PlantUML (.puml) → exportar a PNG/SVG/PDF

---

### 5. Imágenes Exportadas

#### img/GanttCronogramaViandas.png


#### img/DiagramaCasosUsoGeneral.png


#### img/DiagramaClasesCronogramaViandas.png


#### img/UIMockupsCronogramaViandas.png


#### img/DiagramaERD.png

---

## 🎯 Estado de la Documentación

### 📋 Pendiente

| Tarea | Descripción | Prioridad |
|-------|-------------|-----------|
| Actualizar presentación con imágenes | Reemplazar placeholders con rutas reales | Media |
| Crear datos de prueba (seed data) | Script para poblar BD con datos de ejemplo | Baja |
| Documentar CI/CD | Guía de despliegue automatizado | Baja |

---

## 📖 Cómo Usar Esta Documentación

### Para Desarrolladores

1. Leer **MVP1** y **MVP2** para entender alcance y arquitectura
2. Consultar **API_Documentation.md** para implementar integraciones
3. Revisar **DiagramaClasesCronogramaViandas.puml** para modelo de dominio
4. Seguir **Gantt_QA.md** para plan de desarrollo y pruebas

### Para Usuarios/Capacitación

1. Usar **Manual_Usuario.md** como guía de referencia
2. Imprimir/distribuir secciones relevantes por rol
3. Consultar FAQ para problemas comunes

### Para Cliente/Stakeholders

1. Revisar **Presentacion.md** para visión general
2. Ver **Gantt_QA.md** para cronograma y fechas
3. Consultar **MVP1** y **MVP2** para alcance de entregas

---

## 📞 Información de Contacto

**Proyecto:** Sistema de Cronograma y Viandas - Hospital  
**Institución:** ULP Universidad de la Punta 
**Materia:** Laboratorio III  
**Año:** 2025  
**Alumno:** Jesús Emanuel García

---

## 📝 Historial de Cambios

| Fecha | Versión | Cambios |
|-------|---------|---------|
| 2025-11-15 | 1.0 | Creación inicial de toda la documentación |
| 2025-11-15 | 1.1 | Agregado MVP2, Manual Usuario, API Docs, Diagramas UML/ERD |
| 2025-11-15 | 1.2 | Reemplazo de Firebase por SignalR en todos los documentos |
| 2025-11-15 | 1.3 | Actualización de README.md con referencias correctas |

---

**Fin del Índice de Documentación**
