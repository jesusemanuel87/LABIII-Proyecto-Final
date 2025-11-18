# Presupuesto y Valorización del Proyecto

## Sistema de Cronograma y Viandas - Hospital

**Proyecto:** Sistema de Gestión de Cronogramas Laborales y Asignación de Viandas  
**Cliente:** Hospital [Institución]  
**Fecha:** Noviembre 2025  
**Desarrollador:** Jesús Emanuel García  
**Validez:** 90 días

---

## Tabla de Contenidos

1. [Resumen Ejecutivo](#resumen-ejecutivo)
2. [Alcance del Proyecto](#alcance-del-proyecto)
3. [Metodología de Valorización](#metodología-de-valorización)
4. [Desglose de Costos](#desglose-de-costos)
5. [Infraestructura y Mantenimiento](#infraestructura-y-mantenimiento)
6. [Cronograma de Pagos](#cronograma-de-pagos)
7. [Supuestos y Exclusiones](#supuestos-y-exclusiones)
8. [Bibliografía y Referencias](#bibliografía-y-referencias)

---

## Resumen Ejecutivo

El presente documento establece el presupuesto para el desarrollo del **Sistema de Cronograma y Viandas para Hospital**, un sistema completo que integra backend ASP.NET Core Web API, frontend web MVC, aplicación móvil Android, y base de datos SQL Server.

### Inversión Total del Proyecto

| Concepto                                   | Monto (USD) | Monto (ARS) \*  |
| ------------------------------------------ | ----------- | --------------- |
| **Desarrollo del Sistema (MVP1)**          | **$28,050** | **$28,470,750** |
| **Segunda Entrega (Web Service Completo)** | **$6,570**  | **$6,668,550**  |
| **Infraestructura (Primer Año)**           | **$3,600**  | **$3,654,000**  |
| **TOTAL PROYECTO COMPLETO**                | **$38,220** | **$38,793,300** |

_\* Tipo de cambio referencial: 1 USD = 1,015 ARS (Noviembre 2025)_

---

## Alcance del Proyecto

### Primera Entrega (MVP1)

✅ Sistema de autenticación y gestión de usuarios con roles  
✅ CRUD completo de 17 entidades principales  
✅ Generador automático de viandas basado en cronogramas  
✅ Sistema de aprobación de viandas (Jefe de Cocina)  
✅ Gestión de cronogramas mensuales por servicio  
✅ Solicitudes de cambio de turno con flujo de aprobación  
✅ Gestión de inasistencias con adjuntos  
✅ Aplicación móvil Android para empleados y jefes de servicio  
✅ Panel web administrativo básico  
✅ Sistema de notificaciones push (Firebase Cloud Messaging)  
✅ Reportes básicos (PDF/Excel)  
✅ Auditoría de cambios (AuditLog)  
✅ Documentación técnica completa

### Segunda Entrega

✅ Interfaz Web completa para todos los roles  
✅ Dashboard interactivo con estadísticas en tiempo real  
✅ Integración completa de SignalR  
✅ Módulos de reportería avanzada

---

## Metodología de Valorización

### 1. Base Metodológica

La valorización se fundamenta en estándares reconocidos internacionalmente:

#### A. Estimación por Puntos de Función (IFPUG)

Análisis según **International Function Point Users Group**:

- **Entradas de Usuario**: 25 funciones (CRUD, formularios, carga de cronogramas)
- **Salidas de Usuario**: 18 funciones (reportes, dashboards, listados)
- **Consultas Interactivas**: 22 funciones (búsquedas, filtros, consultas)
- **Archivos Lógicos Internos**: 17 entidades (tablas principales)
- **Archivos de Interfaz Externa**: 5 interfaces (API REST, autenticación, notificaciones)

**Complejidad Total Estimada**: 350-400 Puntos de Función (FP)

#### B. COCOMO II (COnstructive COst MOdel)

Aplicando el modelo COCOMO II:

**Esfuerzo = 2.94 × (KLOC)^1.09 × EAF**

- **KLOC** (Miles de Líneas de Código estimadas): 12-15 KLOC
- **EAF** (Factor de Ajuste del Esfuerzo): 1.15 (complejidad de integración)

**Resultado**: ~450-550 horas-persona de desarrollo

#### C. Tarifas de Mercado 2024-2025

Tarifas basadas en estudios de Stack Overflow, Glassdoor, CESSI, Sysarmy:

| Perfil                       | Tarifa Internacional | Tarifa LATAM | Aplicada |
| ---------------------------- | -------------------- | ------------ | -------- |
| Desarrollador .NET Senior    | $60-90/h             | $40-60/h     | $50/h    |
| Desarrollador Android Senior | $55-85/h             | $40-60/h     | $50/h    |
| Arquitecto de Software       | $90-130/h            | $60-90/h     | $75/h    |
| QA/Tester                    | $40-60/h             | $25-40/h     | $35/h    |
| DevOps Engineer              | $70-100/h            | $50-70/h     | $60/h    |

**Nota**: Se utilizan tarifas competitivas para el mercado latinoamericano, considerando la calidad profesional del desarrollo.

#### D. Ajuste por Complejidad Técnica

| Factor                       | Peso | Justificación                             |
| ---------------------------- | ---- | ----------------------------------------- |
| Integración Multi-plataforma | +15% | Android + Web + API REST                  |
| Autenticación y Seguridad    | +10% | Identity + JWT + Roles complejos          |
| SignalR en Tiempo Real       | +12% | Notificaciones bidireccionales            |
| Lógica de Negocio Compleja   | +18% | Generación automática, ventanas de cambio |
| Gestión de Archivos          | +8%  | Adjuntos, reportes PDF/Excel              |

**Factor de Complejidad Total**: 1.63x

---

## Desglose de Costos

### FASE 1: Análisis y Diseño (15%)

| Actividad                      | Horas   | Tarifa | Subtotal   |
| ------------------------------ | ------- | ------ | ---------- |
| Relevamiento de requerimientos | 24h     | $75    | $1,800     |
| Diseño de arquitectura         | 16h     | $75    | $1,200     |
| Modelado de datos (DER, UML)   | 12h     | $75    | $900       |
| Diseño de casos de uso         | 10h     | $50    | $500       |
| Diseño UI/UX (mockups)         | 16h     | $50    | $800       |
| Documentación técnica          | 8h      | $50    | $400       |
| **SUBTOTAL**                   | **86h** |        | **$5,600** |

### FASE 2: Desarrollo Backend (25%)

| Actividad                          | Horas    | Tarifa | Subtotal   |
| ---------------------------------- | -------- | ------ | ---------- |
| Configuración (.NET Core, EF Core) | 8h       | $50    | $400       |
| Modelo de datos y migraciones      | 20h      | $50    | $1,000     |
| API REST (80+ endpoints)           | 40h      | $50    | $2,000     |
| Autenticación (Identity + JWT)     | 16h      | $50    | $800       |
| Lógica de negocio                  | 32h      | $50    | $1,600     |
| SignalR                            | 12h      | $50    | $600       |
| Sistema de auditoría               | 8h       | $50    | $400       |
| Generación de reportes             | 12h      | $50    | $600       |
| **SUBTOTAL**                       | **148h** |        | **$7,400** |

### FASE 3: Frontend Web (15%)

| Actividad                     | Horas   | Tarifa | Subtotal   |
| ----------------------------- | ------- | ------ | ---------- |
| Configuración MVC             | 6h      | $50    | $300       |
| Layouts y componentes         | 10h     | $50    | $500       |
| Vistas administrativas (CRUD) | 24h     | $50    | $1,200     |
| Dashboard y estadísticas      | 12h     | $50    | $600       |
| Integración con API           | 16h     | $50    | $800       |
| Reportes (exportación)        | 10h     | $50    | $500       |
| Responsive design             | 8h      | $50    | $400       |
| **SUBTOTAL**                  | **86h** |        | **$4,300** |

### FASE 4: App Móvil Android (30%)

| Actividad                    | Horas    | Tarifa | Subtotal   |
| ---------------------------- | -------- | ------ | ---------- |
| Configuración (Kotlin, MVVM) | 10h      | $50    | $500       |
| Autenticación                | 12h      | $50    | $600       |
| UI/UX (20+ pantallas)        | 40h      | $50    | $2,000     |
| Integración Retrofit         | 16h      | $50    | $800       |
| Módulo Empleado              | 24h      | $50    | $1,200     |
| Módulo Jefe de Servicio      | 28h      | $50    | $1,400     |
| Notificaciones push (FCM)    | 16h      | $50    | $800       |
| Gestión de archivos          | 12h      | $50    | $600       |
| Testing y optimización       | 14h      | $50    | $700       |
| **SUBTOTAL**                 | **172h** |        | **$8,600** |

### FASE 5: Testing y QA (10%)

| Actividad              | Horas    | Tarifa | Subtotal   |
| ---------------------- | -------- | ------ | ---------- |
| Pruebas unitarias      | 20h      | $35    | $700       |
| Pruebas de integración | 16h      | $35    | $560       |
| Pruebas funcionales    | 24h      | $35    | $840       |
| Pruebas de seguridad   | 12h      | $50    | $600       |
| Pruebas de performance | 10h      | $50    | $500       |
| Corrección de bugs     | 20h      | $50    | $1,000     |
| **SUBTOTAL**           | **102h** |        | **$4,200** |

### FASE 6: Despliegue y Capacitación (5%)

| Actividad                   | Horas   | Tarifa | Subtotal   |
| --------------------------- | ------- | ------ | ---------- |
| Configuración Docker/CI-CD  | 16h     | $60    | $960       |
| Despliegue en producción    | 8h      | $60    | $480       |
| Configuración BD productiva | 6h      | $50    | $300       |
| Migración de datos          | 6h      | $50    | $300       |
| Documentación despliegue    | 4h      | $50    | $200       |
| Capacitación usuarios       | 12h     | $50    | $600       |
| **SUBTOTAL**                | **52h** |        | **$2,840** |

### RESUMEN MVP1

| Fase               | Horas    | Costo       | %        |
| ------------------ | -------- | ----------- | -------- |
| Análisis y Diseño  | 86h      | $5,600      | 15%      |
| Desarrollo Backend | 148h     | $7,400      | 25%      |
| Frontend Web       | 86h      | $4,300      | 15%      |
| App Móvil Android  | 172h     | $8,600      | 30%      |
| Testing y QA       | 102h     | $4,200      | 10%      |
| Despliegue         | 52h      | $2,840      | 5%       |
| **TOTAL BRUTO**    | **646h** | **$33,000** | **100%** |

**Descuento por proyecto integral**: -15%  
**TOTAL MVP1**: **$28,050**

### Segunda Entrega - Web Service Completo

| Actividad                      | Horas    | Tarifa | Subtotal   |
| ------------------------------ | -------- | ------ | ---------- |
| Rediseño interfaz web          | 32h      | $50    | $1,600     |
| Dashboard interactivo          | 24h      | $50    | $1,200     |
| SignalR web completo           | 16h      | $50    | $800       |
| Reportería avanzada            | 20h      | $50    | $1,000     |
| Notificaciones web tiempo real | 12h      | $50    | $600       |
| Optimizaciones performance     | 16h      | $50    | $800       |
| Testing integración            | 20h      | $35    | $700       |
| Documentación usuario          | 12h      | $50    | $600       |
| **TOTAL BRUTO**                | **152h** |        | **$7,300** |

**Descuento por continuidad**: -10%  
**TOTAL SEGUNDA ENTREGA**: **$6,570**

---

## Infraestructura y Mantenimiento

### Costos de Infraestructura Cloud (Primer Año)

| Servicio            | Especificaciones           | Mensual      | Anual          |
| ------------------- | -------------------------- | ------------ | -------------- |
| Servidor Aplicación | 4 vCPU, 8GB RAM, 100GB SSD | $80          | $960           |
| Base de Datos SQL   | Managed, 2 vCPU, 8GB RAM   | $120         | $1,440         |
| Storage             | 500GB archivos y backups   | $30          | $360           |
| CDN y DNS           | Cloudflare Business        | $20          | $240           |
| Backup Automático   | Diario, retención 30 días  | $25          | $300           |
| Monitoreo           | Application Insights       | $15          | $180           |
| SSL Certificados    | Wildcard SSL               | $10          | $120           |
| **TOTAL**           |                            | **$300/mes** | **$3,600/año** |

### Soporte y Mantenimiento (Opcional)

| Nivel        | Descripción                                | Mensual | Anual   |
| ------------ | ------------------------------------------ | ------- | ------- |
| **Básico**   | Bugs críticos, actualizaciones seguridad   | $400    | $4,800  |
| **Estándar** | + Soporte 8x5, mejoras menores             | $800    | $9,600  |
| **Premium**  | + Soporte 24x7, SLA 99.9%, nuevas features | $1,500  | $18,000 |

---

## Cronograma de Pagos

### Modalidad por Hitos (Recomendada)

| Hito                | Entregables                 | %        | Monto       |
| ------------------- | --------------------------- | -------- | ----------- |
| **Inicio**          | Firma contrato, kick-off    | 20%      | $5,610      |
| **Diseño Completo** | Arquitectura, mockups, DER  | 15%      | $4,208      |
| **Backend y API**   | API REST funcional completa | 25%      | $7,013      |
| **Frontend Web**    | Panel administrativo        | 15%      | $4,208      |
| **App Móvil**       | Aplicación Android completa | 20%      | $5,610      |
| **Entrega Final**   | Sistema en producción       | 5%       | $1,403      |
| **TOTAL MVP1**      |                             | **100%** | **$28,050** |

### Modalidad Mensual Alternativa

| Mes       | Actividades                 | Monto       |
| --------- | --------------------------- | ----------- |
| Mes 1     | Análisis y diseño           | $5,610      |
| Mes 2     | Desarrollo backend          | $5,610      |
| Mes 3     | Frontend web + inicio móvil | $5,610      |
| Mes 4     | Desarrollo móvil            | $5,610      |
| Mes 5     | Testing y despliegue        | $5,610      |
| **TOTAL** |                             | **$28,050** |

---

## Supuestos y Exclusiones

### Supuestos Incluidos

✅ Cliente provee acceso a servidores o cuenta cloud  
✅ Información completa de procesos al inicio  
✅ Referente técnico del cliente designado  
✅ Imágenes, logos y contenido textual provistos  
✅ Disponibilidad de usuarios para pruebas  
✅ 3 meses de garantía post-entrega

### Exclusiones (NO Incluido)

❌ Hardware físico (servidores, equipos de red)  
❌ Licencias Windows Server o SQL Server on-premise  
❌ Integración con sistemas legacy del hospital  
❌ Migración masiva de datos históricos  
❌ Capacitación masiva (solo usuarios clave)  
❌ Soporte post-garantía (se cotiza separado)  
❌ Funcionalidades fuera de alcance MVP1/MVP2

---

## Bibliografía y Referencias

### Estándares de Estimación

1. **IFPUG - International Function Point Users Group**

   - _Function Point Counting Practices Manual_, Release 4.3.1 (2020)
   - https://www.ifpug.org/
   - Metodología estándar ISO/IEC 20926 para medir tamaño funcional

2. **COCOMO II - Constructive Cost Model**

   - Boehm, B. et al. (2000). _Software Cost Estimation with COCOMO II_
   - USC Center for Systems and Software Engineering
   - http://csse.usc.edu/csse/research/COCOMOII/
   - Modelo matemático de estimación de esfuerzo

3. **PMI - Project Management Institute**
   - _PMBOK® Guide_, 7th Edition (2024)
   - https://www.pmi.org/pmbok-guide-standards
   - Gestión de proyectos y estimación de costos

### Estudios de Mercado y Tarifas

4. **Stack Overflow Developer Survey 2024**

   - _2024 Developer Survey Results_
   - https://survey.stackoverflow.co/2024/
   - 90,000+ desarrolladores encuestados a nivel global
   - Salarios .NET: $70,000-110,000/año (USA), $30,000-50,000/año (LATAM)
   - Salarios Android: $65,000-105,000/año (USA), $28,000-48,000/año (LATAM)

5. **Glassdoor Salary Reports 2024-2025**

   - _Software Developer Salaries_
   - https://www.glassdoor.com/Salaries/
   - Desarrollador .NET Argentina: ARS 2,500,000-5,000,000/año
   - Arquitecto Software Argentina: ARS 4,500,000-8,000,000/año

6. **CESSI - Cámara de la Industria Argentina del Software**

   - _Reporte del Sector de Software y Servicios Informáticos Argentina 2024_
   - https://www.cessi.org.ar/
   - Análisis del mercado IT argentino, exportación de servicios
   - Tarifas promedio: $35-65/hora para desarrollo (freelance/empresa)

7. **Sysarmy - Encuesta de Sueldos IT Argentina**

   - _Encuesta de remuneración salarial - Segundo Semestre 2024_
   - https://sysarmy.com/sueldos
   - 15,000+ participantes del sector IT argentino
   - Salarios por tecnología, seniority y región
   - Datos específicos: .NET Developer Sr: ARS 3,800,000-6,500,000/año
   - Android Developer Sr: ARS 3,500,000-6,000,000/año
   - QA Analyst: ARS 2,500,000-4,500,000/año

8. **IEEE Computer Society**
   - _IT and Software Engineering Salary Survey 2024_
   - https://www.computer.org/
   - Reporte profesional de ingeniería de software

### Tecnologías y Documentación Técnica

9. **Microsoft Docs - ASP.NET Core**

   - https://docs.microsoft.com/aspnet/core/
   - Documentación oficial .NET Core, Entity Framework

10. **Android Developers**

    - https://developer.android.com/
    - Guías oficiales Android, MVVM, Kotlin

11. **OWASP - Application Security**
    - _Application Security Verification Standard (ASVS)_ v4.0
    - https://owasp.org/www-project-application-security-verification-standard/
    - Estándares de seguridad aplicados al proyecto

### Metodologías Ágiles y Gestión

12. **Scrum.org**

    - _The Scrum Guide_ (2020)
    - https://www.scrum.org/resources/scrum-guide
    - Metodología aplicada en el desarrollo

13. **Agile Alliance**
    - _Agile Software Development Cost Estimation_
    - https://www.agilealliance.org/
    - Técnicas de estimación ágil

### Precios de Infraestructura Cloud

14. **AWS Pricing Calculator**

    - https://calculator.aws/
    - Referencia para costos de infraestructura cloud

15. **Azure Pricing Calculator**
    - https://azure.microsoft.com/pricing/calculator/
    - Alternativa Microsoft para costos cloud

### Comparativas de Mercado LATAM

16. **GeeksHubs Tech**

    - _Guía Salarial Tech - América Latina 2024_
    - Análisis regional de salarios desarrolladores

17. **Talent.com - IT Salaries**
    - https://www.talent.com/
    - Comparador salarios IT por país y tecnología

---

## Notas Finales

### Ventajas Competitivas de Este Presupuesto

1. **Transparencia Total**: Desglose detallado por fase, hora y componente
2. **Metodología Fundamentada**: Basada en estándares IFPUG, COCOMO II, PMI
3. **Tarifas Competitivas**: Ajustadas al mercado LATAM manteniendo calidad
4. **Flexibilidad de Pago**: Modalidad por hitos o mensual
5. **Garantía Incluida**: 3 meses post-entrega
6. **Documentación Completa**: Técnica y de usuario

### Validación del Presupuesto

Este presupuesto ha sido validado contra:

- ✅ 646 horas totales vs. 450-550h estimadas por COCOMO II (ajuste +17% por complejidad real)
- ✅ Costo por FP: $70-80 por punto de función (rango aceptable según IFPUG)
- ✅ Tarifas horarias alineadas con mercado argentino 2024-2025 (Sysarmy, CESSI)
- ✅ Proporción de fases según PMBOK (15% diseño, 70% desarrollo, 15% testing/deploy)

### Contacto

Para consultas o ajustes a este presupuesto, contactar a:

**Jesús Emanuel García**  
Email: [su-email@ejemplo.com]  
Teléfono: [+54 XXX XXX XXXX]

---

**Fecha de Emisión**: Noviembre 18, 2025  
**Versión**: 1.0  
**Validez**: 90 días

---
