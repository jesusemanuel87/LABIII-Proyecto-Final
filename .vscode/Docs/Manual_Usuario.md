# Manual de Usuario - Sistema de Cronograma y Viandas

**Versión:** 1.0 | **Fecha:** Noviembre 2025

---

## Índice

1. [Introducción](#1-introducción)
2. [Acceso al Sistema](#2-acceso-al-sistema)
3. [Administrador](#3-administrador)
4. [Jefe de Servicio](#4-jefe-de-servicio)
5. [Jefe de Cocina](#5-jefe-de-cocina)
6. [Empleado](#6-empleado)
7. [Bachero (MVP2)](#7-bachero-mvp2)
8. [FAQ y Soporte](#8-faq-y-soporte)

---

## 1. Introducción

Sistema para gestionar cronogramas laborales y asignación de viandas al personal hospitalario.

### Roles y Accesos

| Rol | Acceso | Funciones Principales |
|-----|--------|----------------------|
| Administrador | Web | Configuración del sistema |
| Jefe de Servicio | Web + App | Gestión de cronogramas |
| Jefe de Cocina | Web + App (MVP2) | Aprobación de viandas |
| Empleado | App | Consulta y solicitudes |
| Bachero | App (MVP2) | Confirmación de entregas |

---

## 2. Acceso al Sistema

### Web
- URL: `https://cronograma-viandas.hospital.gob.ar`
- Credenciales: Usuario y Contraseña

### App Móvil
- Google Play: "Cronograma Viandas Hospital"
- Credenciales: DNI (sin puntos) y Contraseña
- **Contraseña inicial = DNI** (cambiar en primer acceso)

---

## 3. Administrador

### Gestión de Empleados

**Crear:**
1. **Empleados** → **+ Nuevo**
2. Completar: Nombre, DNI, Servicio, Tipo de Dieta
3. **Guardar**

**Editar:** Buscar empleado → **Editar** → Modificar → **Guardar**

**Desactivar:** Buscar → **Desactivar** → Confirmar

### Gestión de Servicios

1. **Servicios** → **+ Nuevo**
2. Nombre y descripción
3. **Configurar Horarios** para definir horarios por turno

### Configuración de Tipos de Vianda

**Configuración** → **Tipos de Vianda** → Definir horarios:
- Desayuno: 07:00-10:00
- Almuerzo: 12:00-14:30
- Merienda: 16:00-18:00
- Cena: 20:00-22:00

### Ventanas de Cambio

**Configuración** → **Ventanas de Cambio** → Definir hora límite por servicio/tipo de vianda.

### Reportes

**Reportes** → Seleccionar tipo → Filtros → **Generar** → Exportar (PDF/Excel)

---

## 4. Jefe de Servicio

### Crear Cronograma Mensual

**Web:**
1. **Cronograma** → **+ Crear**
2. Seleccionar mes/año
3. Asignar empleados y turnos por día
4. **Generar Viandas** → **Publicar**

**App:**
1. **Cronograma** → **+**
2. Seleccionar mes/año y asignar turnos
3. **Guardar y Generar Viandas**

### Reemplazar Empleado

1. **Cronograma** → Clic en fecha
2. **Reemplazar** → Seleccionar nuevo empleado
3. **Confirmar**

> ⚠️ Solo hasta la hora límite configurada

### Gestión de Solicitudes

**Ver:** **Solicitudes** → Listado pendientes

**Aprobar:** Clic en solicitud → **Aprobar** → Confirmar

**Rechazar:** Clic → **Rechazar** → Ingresar motivo → Confirmar

### Gestión de Inasistencias

**Inasistencias** → Ver detalle → Descargar certificado → **Marcar como Revisada**

---

## 5. Jefe de Cocina

### Gestión de Menús

1. **Menús** → **+ Nuevo**
2. Completar: Nombre, Tipo vianda, Tipo dieta, Vigencia
3. **Guardar**

### Aprobar/Rechazar Viandas

**Individual:**
- **Viandas Pendientes** → **✓ Aprobar** o **✗ Rechazar**

**Múltiples:**
- Marcar casillas → **Aprobar Seleccionadas**

**Rechazar:**
- **✗ Rechazar** → Ingresar motivo → **Confirmar**

### Entregas Excepcionales (MVP2)

1. **Entregas Excepcionales** → **+ Nueva**
2. Seleccionar:
   - Empleado existente o Personal de visita
   - Fecha, tipo vianda, dieta, cantidad
3. **Guardar**

---

## 6. Empleado

### Ver Cronograma

**App:** Calendario con turnos (M/T/N) → Tocar día para ver detalles

### Solicitar Cambio de Turno

1. **+ Solicitar Cambio**
2. Fecha, turno actual/deseado, motivo
3. Opción: Empleado sugerido
4. **Enviar**

**Ver estado:** **Mis Solicitudes** (Pendiente/Aprobada/Rechazada)

### Informar Inasistencia

1. **Inasistencia**
2. Fecha desde/hasta, motivo
3. **Adjuntar Certificado** (opcional)
4. **Enviar**

### Gestionar Perfil

**Cambiar Contraseña:** **Mi Perfil** → **Cambiar Contraseña**

**Actualizar Avatar:** Tocar imagen → Tomar foto/Elegir de galería

---

## 7. Bachero (MVP2)

### Confirmar Entrega

**Método Básico:**
- Buscar empleado → **Confirmar Entrega**

**Con Código de Barras:**
- **Escanear QR** → Confirma automáticamente

**Con Foto:**
- **Confirmar con Foto** → Tomar foto → **Confirmar**

### Entregas Excepcionales

**Excepcionales** → Ver lista con tag 🏷️ → Confirmar igual que regulares

### Marcar No Retiradas

Al finalizar horario → **Marcar No Retiradas** → Seleccionar → **Confirmar**

---

## 8. FAQ y Soporte

### Preguntas Frecuentes

**¿Olvidé mi contraseña?**  
Contactar al Administrador o área de Sistemas.

**¿Hasta cuándo solicitar cambio?**  
En cualquier momento, pero antes de hora límite para mismo día.

**¿Puedo ver cronograma de compañeros?**  
No, solo el propio. Jefes de Servicio ven su servicio completo.

**¿Sistema funciona offline?**  
No, requiere internet. App cachea datos básicos.

### Soporte Técnico

**Área de Sistemas - Hospital**  
📧 Email: sistemas@hospital.gob.ar  
📞 Teléfono: (interno) 2000  
🕒 Horario: Lunes a Viernes 8:00-16:00

---

**Fin del Manual de Usuario**
