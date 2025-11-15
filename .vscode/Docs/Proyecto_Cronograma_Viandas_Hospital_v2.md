# Proyecto Cronograma Viandas Hospital

## 1. Descripción general
El proyecto **Cronograma Viandas Hospital** tiene como objetivo digitalizar y automatizar la gestión de entrega de viandas al personal hospitalario, asegurando control, trazabilidad y eficiencia operativa.  
Actualmente, el proceso se realiza de forma manual, lo que genera errores, demoras y dificultades para el control de consumo y costos.

---

## 2. Objetivo del sistema
Diseñar e implementar una aplicación web que permita:
- Gestionar los cronogramas del personal (turnos, horarios y servicios).  
- Registrar la entrega de viandas según los turnos de trabajo.  
- Controlar qué empleados tienen derecho a recibir vianda.  
- Emitir reportes de consumo, entregas y ausencias.

---

## 3. Usuarios del sistema
- **Administradores del sistema:** gestionan parámetros generales, usuarios y reportes.  
- **Jefes de servicio:** definen el cronograma y los turnos de los empleados.  
- **Jefe de Cocina:** define los tipos de vianda, los horarios de entrega válidos y supervisa el registro diario.  
- **Personal de cocina/comedor:** realiza la entrega efectiva de viandas escaneando credenciales o buscando por empleado.  
- **Empleados:** pueden consultar sus registros de entrega y horarios asignados.

---

## 4. Módulos principales
1. **Módulo de Servicios:** gestión de los distintos servicios hospitalarios (Ej. Enfermería, Guardia, Laboratorio, etc.).  
2. **Módulo de Empleados:** registro y administración del personal, con su servicio, turno y si tiene habilitada o no la entrega de vianda.  
3. **Módulo de Tipos de Vianda:** define las categorías (Desayuno, Almuerzo, Merienda, Cena) y los rangos válidos de entrega (definidos por el Jefe de Cocina).  
4. **Módulo de Cronograma:** gestión de turnos y horarios por servicio y empleado.  
5. **Módulo de Entregas:** registro de viandas entregadas, validadas por fecha, tipo y turno.  
6. **Módulo de Reportes:** estadísticas de consumo, ausencias, entregas por servicio, etc.  

---

## 5. Tablas principales (modelo lógico)

### SERVICIO
- **id_servicio** (PK)
- **nombre_servicio**
- **descripcion**
- **entrega_vianda_habilitada** (BOOLEAN) → Indica si el servicio tiene habilitada la entrega de viandas.

### EMPLEADO
- **id_empleado** (PK)
- **nombre**
- **apellido**
- **dni**
- **id_servicio** (FK)
- **turno_asignado**
- **vianda_habilitada** (BOOLEAN) → Indica si el empleado puede recibir vianda.
- **activo**

### TIPO_VIANDA
- **id_vianda** (PK)
- **descripcion**
- **horario_inicio_entrega**
- **horario_fin_entrega**
- **definido_por** (FK → USUARIO que la define, generalmente el Jefe de Cocina)

### CRONOGRAMA
- **id_cronograma** (PK)
- **id_servicio** (FK)
- **fecha**
- **turno**
- **hora_inicio**
- **hora_fin**

### ENTREGA_VIANDA
- **id_entrega** (PK)
- **id_empleado** (FK)
- **id_vianda** (FK)
- **fecha_entrega**
- **hora_entrega**
- **registrado_por** (FK → usuario que realiza la entrega)
- **observaciones**

---

## 6. Relaciones principales
- Un **servicio** puede tener **muchos empleados**.  
- Un **empleado** pertenece a un único **servicio**.  
- Un **tipo de vianda** puede tener **muchas entregas**.  
- Cada **entrega** está asociada a un **empleado** y a un **tipo de vianda**.  
- Un **cronograma** pertenece a un **servicio** y define los turnos diarios.

---

## 7. Reglas de negocio principales (actualizadas)
1. Cada **servicio** define los turnos (hora inicio y fin) y los empleados asignados a cada turno.  
2. Los **rangos válidos de entrega por tipo de vianda** son definidos **exclusivamente por el Jefe de Cocina**.  
3. Los jefes de servicio solo gestionan el **cronograma** y **turnos** de su personal, no los horarios de entrega.  
4. Solo los **empleados con vianda habilitada** pueden registrar una entrega.  
5. La aplicación validará que la entrega se realice dentro del rango horario establecido para el tipo de vianda.  
6. No se puede registrar más de una entrega por tipo de vianda y fecha para un mismo empleado.

---

## 8. Validaciones clave
- Si un servicio no tiene habilitada la entrega de viandas, ningún empleado de ese servicio podrá registrar entregas.  
- Si un empleado no tiene habilitada la vianda, no podrá recibirla.  
- Validar duplicados de entregas (empleado + fecha + tipo_vianda).  
- Controlar que la entrega esté dentro del rango horario definido por el tipo de vianda.

---

## 9. Reportes previstos
- Entregas diarias por servicio y tipo de vianda.  
- Totales de consumo por período (día, semana, mes).  
- Listado de empleados que no retiraron vianda.  
- Comparativo de consumo planificado vs. real.  
- Exportación a Excel o PDF.

---

## 10. Seguridad y accesos
- Autenticación por usuario y contraseña.  
- Roles: Administrador, Jefe de Cocina, Jefe de Servicio, Personal de Cocina.  
- Control de acceso por módulo y acción (lectura, escritura, administración).  
- Registro de auditoría: quién registró o modificó cada entrega.

---
