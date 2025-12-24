# Performance Optimization 🚀

## Introducción

Esta sección contiene técnicas y mejores prácticas para optimizar el rendimiento de aplicaciones .NET, especialmente cuando trabajas con Entity Framework Core y operaciones de base de datos.

## 📚 Temas Disponibles

### 1. Use AsNoTracking in Entity Framework Core for Read-Only Queries
**Ubicación:** `concepts/05-performance-optimization/01-asnotracking-ef-core/`

Guía sobre cómo usar `AsNoTracking()` en Entity Framework Core para mejorar el rendimiento en consultas de solo lectura.

### 2. Optimizing ORM: Eager, Lazy & Explicit Loading
**Ubicación:** `concepts/05-performance-optimization/02-loading-strategies/`

Guía completa sobre las estrategias de carga en Entity Framework Core: Eager Loading, Lazy Loading y Explicit Loading. Comprender cuándo usar cada una es fundamental para optimizar el rendimiento.

### 3. String vs StringBuilder: Asignación de Memoria
**Ubicación:** `concepts/05-performance-optimization/03-string-vs-stringbuilder/`

Guía completa sobre las diferencias entre `String` y `StringBuilder` en cuanto a asignación de memoria y rendimiento en .NET.

**Diferencias Clave:**
- **String**: Inmutable, cada modificación crea nuevo objeto, O(n²) para múltiples concatenaciones
- **StringBuilder**: Mutable, modifica el mismo objeto, O(n) para múltiples concatenaciones
- **Asignación de Memoria**: String crea múltiples objetos, StringBuilder modifica uno
- **Rendimiento**: String para pocas operaciones, StringBuilder para muchas

**Cuándo Usar:**
- **String**: 1-2 concatenaciones, strings literales, interpolación simple
- **StringBuilder**: 3+ concatenaciones, loops, construcción dinámica de texto

---

## 🎯 Objetivo

Este apartado está diseñado para ayudarte a:
- Optimizar el rendimiento de aplicaciones .NET
- Reducir el uso de memoria
- Mejorar la eficiencia de consultas a base de datos
- Aplicar técnicas probadas de optimización

