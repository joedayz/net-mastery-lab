# 📖 Guía de Aprendizaje Paso a Paso

Guía estructurada desde conceptos básicos hasta avanzados para dominar C# y .NET.

## 🎯 Cómo Usar Este Repositorio

### Ejecutar el Programa Interactivo
```bash
dotnet run
```
El menú te permitirá explorar y ejecutar ejemplos de cada concepto.

### Estructura de Cada Concepto
Cada concepto incluye:
- **README.md** - Documentación teórica completa
- **BEST_PRACTICES.md** - Mejores prácticas y recomendaciones
- **Examples/** - Código ejecutable con ejemplos prácticos

---

## 🗺️ Ruta de Aprendizaje: De Básico a Avanzado

### 📍 FASE 1: FUNDAMENTOS DE C# (Semanas 1-3)

#### Semana 1: Conceptos Básicos
**Objetivo:** Entender los fundamentos del lenguaje C#

1. **Tipos de Datos** (`concepts/09-csharp-fundamentals/03-data-types/`)
   - Value Types vs Reference Types
   - Stack vs Heap
   - ⏱️ 2 horas

2. **Variables y Conversión de Tipos** (`concepts/09-csharp-fundamentals/10-variables-type-conversion/`)
   - Declaración y asignación
   - Conversión implícita y explícita
   - ⏱️ 1-2 horas

3. **Parse vs TryParse** (`concepts/09-csharp-fundamentals/01-parse-vs-tryparse/`)
   - Manejo seguro de conversiones
   - Manejo de errores
   - ⏱️ 1-2 horas

4. **Date & Time** (`concepts/09-csharp-fundamentals/02-date-time/`)
   - DateTime, TimeSpan
   - Inmutabilidad
   - ⏱️ 2 horas

5. **Manejo de Excepciones** (`concepts/09-csharp-fundamentals/11-exception-handling/`)
   - try-catch-finally
   - Excepciones personalizadas
   - ⏱️ 3 horas

#### Semana 2: Colecciones y LINQ Básico
**Objetivo:** Dominar colecciones y consultas básicas

6. **Arrays vs ArrayList** (`concepts/09-csharp-fundamentals/15-arrays-vs-arraylist/`)
   - Arrays estáticos
   - List<T> como alternativa moderna
   - ⏱️ 1-2 horas

7. **Collections en C#** (`concepts/09-csharp-fundamentals/09-collections/`)
   - Generic Collections (List, Dictionary, Queue, Stack)
   - Concurrent Collections
   - Interfaces: IEnumerable<T>, ICollection<T>, IList<T>
   - ⏱️ 4 horas

8. **List vs HashSet** (`concepts/09-csharp-fundamentals/17-list-vs-hashset/`)
   - Cuándo usar cada uno
   - Diferencias de rendimiento
   - ⏱️ 1-2 horas

9. **IEnumerable vs IQueryable** (`concepts/01-ienumerable-vs-iqueryable/`)
   - Consultas en memoria vs servidor
   - Cuándo usar cada uno
   - ⏱️ 3 horas

10. **LINQ Methods** (`concepts/09-csharp-fundamentals/13-linq-methods/`)
    - Filtrado, Proyección, Ordenamiento
    - Agregación, Cuantificadores
    - ⏱️ 5 horas

#### Semana 3: Clean Code y Buenas Prácticas
**Objetivo:** Escribir código limpio y mantenible

11. **Convenciones de Nomenclatura** (`concepts/04-clean-code/05-naming-conventions/`)
    - PascalCase, camelCase, _camelCase
    - ⏱️ 2 horas

12. **Clear & Descriptive Property Names** (`concepts/04-clean-code/07-clear-descriptive-property-names/`)
    - Nombres claros y descriptivos
    - ⏱️ 1 hora

13. **Interpolated Strings** (`concepts/04-clean-code/06-interpolated-strings/`)
    - Formato de strings moderno
    - ⏱️ 1 hora

14. **Avoid Too Many Arguments** (`concepts/04-clean-code/01-avoid-too-many-arguments/`)
    - Encapsulación de parámetros
    - ⏱️ 1 hora

15. **Prefer IEnumerable<T> Over List<T>** (`concepts/04-clean-code/02-prefer-ienumerable-over-list/`)
    - Flexibilidad y encapsulación
    - ⏱️ 1 hora

16. **SelectMany vs Bucles Anidados** (`concepts/04-clean-code/03-nested-loops-vs-selectmany/`)
    - Aplanar colecciones anidadas
    - ⏱️ 1-2 horas

17. **MinBy/MaxBy** (`concepts/04-clean-code/04-minby-maxby-instead-of-orderby/`)
    - Optimización de búsquedas
    - ⏱️ 1 hora

---

### 📍 FASE 2: PROGRAMACIÓN ORIENTADA A OBJETOS (Semanas 4-5)

#### Semana 4: Los 4 Pilares de OOP
**Objetivo:** Dominar los fundamentos de OOP

18. **Encapsulación** (`concepts/08-object-oriented-programming/01-encapsulation/`)
    - Ocultar detalles de implementación
    - Access modifiers
    - ⏱️ 2-3 horas

19. **Abstracción** (`concepts/08-object-oriented-programming/02-abstraction/`)
    - Interfaces y clases abstractas
    - Ocultar complejidad
    - ⏱️ 2-3 horas

20. **Herencia** (`concepts/08-object-oriented-programming/03-inheritance-virtual-override-di/`)
    - Virtual y Override
    - Dependency Injection
    - ⏱️ 3-4 horas

21. **Polimorfismo** (`concepts/08-object-oriented-programming/04-polymorphism/`)
    - Una interfaz, múltiples implementaciones
    - Runtime vs Compile-time
    - ⏱️ 2-3 horas

22. **Tipos de Herencia** (`concepts/08-object-oriented-programming/07-types-of-inheritance/`)
    - Single, Multiple, Multilevel, Hierarchical, Hybrid
    - ⏱️ 2 horas

23. **Abstract Class vs Interface** (`concepts/08-object-oriented-programming/06-abstract-class-vs-interface/`)
    - Cuándo usar cada uno
    - Diferencias clave
    - ⏱️ 2-3 horas

#### Semana 5: Conceptos Avanzados de Clases
**Objetivo:** Entender conceptos avanzados de clases

24. **Key Class Concepts** (`concepts/08-object-oriented-programming/05-key-class-concepts/`)
    - Instancia, Referencia, Variables
    - Static vs Instance
    - ⏱️ 2 horas

25. **Pass By Reference vs Pass By Value** (`concepts/09-csharp-fundamentals/16-pass-by-reference-vs-value/`)
    - ref, out, in keywords
    - ⏱️ 2 horas

26. **Null Argument Checks** (`concepts/02-null-argument-checks/`)
    - ArgumentNullException.ThrowIfNull()
    - Validación de argumentos
    - ⏱️ 1 hora

27. **TryGetValue para Diccionarios** (`concepts/03-trygetvalue-avoid-double-lookup/`)
    - Optimización de búsquedas
    - ⏱️ 1 hora

---

### 📍 FASE 3: CARACTERÍSTICAS MODERNAS DE C# (Semana 6)

**Objetivo:** Dominar características modernas del lenguaje

28. **Modern C# Features** (`concepts/09-csharp-fundamentals/08-modern-features/`)
    - Null handling (?. ?? ??=)
    - Pattern Matching
    - using statements
    - nameof operator
    - ⏱️ 4-5 horas

29. **Switch Expressions** (`concepts/09-csharp-fundamentals/19-switch-expressions/`)
    - Sintaxis moderna de switch
    - ⏱️ 2 horas

30. **Primary Constructors** (`concepts/09-csharp-fundamentals/06-primary-constructors/`)
    - Reducción de boilerplate
    - ⏱️ 2 horas

31. **C# Enhancements in .NET 9.0** (`concepts/09-csharp-fundamentals/18-csharp-enhancements-net9/`)
    - Nuevas características
    - ⏱️ 2 horas

32. **Essential C# Keywords** (`concepts/09-csharp-fundamentals/07-keywords/`)
    - Palabras clave importantes
    - ⏱️ 3 horas

33. **Top 20 Essential C# Features** (`concepts/09-csharp-fundamentals/14-essential-csharp-features/`)
    - Resumen de características esenciales
    - ⏱️ 4 horas

34. **Modern LINQ with Pattern Matching** (`concepts/09-csharp-fundamentals/05-modern-linq-pattern-matching/`)
    - LINQ moderno
    - ⏱️ 2-3 horas

---

### 📍 FASE 4: ASP.NET CORE (Semanas 7-8)

#### Semana 7: Fundamentos de ASP.NET Core
**Objetivo:** Construir aplicaciones web con ASP.NET Core

35. **Middleware Order** (`concepts/06-aspnet-core/01-middleware-order/`)
    - Orden correcto de middleware
    - ⏱️ 2-3 horas

36. **MVC Request Life Cycle** (`concepts/06-aspnet-core/02-mvc-request-lifecycle/`)
    - Ciclo de vida de un request
    - ⏱️ 3-4 horas

37. **Minimal APIs** (`concepts/06-aspnet-core/03-minimal-apis/`)
    - APIs ligeras y modernas
    - ⏱️ 2 horas

38. **Web API Action Selection** (`concepts/06-aspnet-core/04-web-api-action-selection/`)
    - Cómo ASP.NET Core selecciona acciones
    - ⏱️ 2-3 horas

#### Semana 8: Herramientas y Librerías
**Objetivo:** Usar herramientas comunes del ecosistema

39. **Logging in .NET Core** (`concepts/06-aspnet-core/07-logging/`)
    - ILogger, Serilog, NLog
    - ⏱️ 3-4 horas

40. **Scrutor - Auto-Register Dependencies** (`concepts/06-aspnet-core/05-scrutor-auto-register/`)
    - Auto-registro de dependencias
    - ⏱️ 2 horas

41. **AutoMapper - Object Mapping** (`concepts/06-aspnet-core/06-automapper-object-mapping/`)
    - Mapeo de objetos
    - ⏱️ 2-3 horas

---

### 📍 FASE 5: ENTITY FRAMEWORK CORE (Semana 9)

**Objetivo:** Trabajar con bases de datos usando EF Core

42. **Entity Framework Core** (`concepts/13-entity-framework-core/`)
    - Introducción a EF Core
    - CRUD operations
    - ⏱️ 4-5 horas

43. **EF Core 9.0 Features** (`concepts/13-entity-framework-core/01-ef-core-9-features/`)
    - Bulk Operations
    - Improved Query Translation
    - JSON Column Support
    - ⏱️ 2-3 horas

44. **AsNoTracking** (`concepts/05-performance-optimization/01-asnotracking-ef-core/`)
    - Optimización de consultas de solo lectura
    - ⏱️ 1-2 horas

45. **Loading Strategies** (`concepts/05-performance-optimization/02-loading-strategies/`)
    - Eager, Lazy, Explicit Loading
    - ⏱️ 3-4 horas

46. **LINQ to SQL vs LINQ to Objects** (`concepts/09-csharp-fundamentals/12-linq-to-sql-vs-linq-to-objects/`)
    - Diferencias y cuándo usar cada uno
    - ⏱️ 2 horas

---

### 📍 FASE 6: OPTIMIZACIÓN Y PERFORMANCE (Semana 10)

**Objetivo:** Optimizar aplicaciones para mejor rendimiento

47. **String vs StringBuilder** (`concepts/05-performance-optimization/03-string-vs-stringbuilder/`)
    - Optimización de strings
    - ⏱️ 2 horas

48. **SQL Query Optimization** (`concepts/12-database/01-sql-query-optimization/`)
    - Optimización de consultas SQL
    - ⏱️ 3-4 horas

---

### 📍 FASE 7: TEMAS AVANZADOS (Semana 11)

**Objetivo:** Dominar temas avanzados

49. **Unit of Work Pattern** (`concepts/11-design-patterns/01-unit-of-work/`)
    - Patrón Unit of Work
    - Repository Pattern
    - ⏱️ 4-5 horas

50. **Attributes & Reflection** (`concepts/09-csharp-fundamentals/04-attributes-reflection/`)
    - Metadatos y reflexión
    - ⏱️ 3-4 horas

51. **SecureString** (`concepts/07-security/01-securestring/`)
    - Manejo seguro de datos sensibles
    - ⏱️ 1-2 horas

---

## 📝 Metodología de Estudio

### Para Cada Concepto:

1. **Lee el README.md** (15-20 min)
   - Entiende la teoría
   - Revisa los ejemplos de código

2. **Ejecuta los Ejemplos** (20-30 min)
   ```bash
   dotnet run
   # Selecciona el número del concepto
   ```

3. **Revisa BEST_PRACTICES.md** (10-15 min)
   - Aprende las mejores prácticas
   - Entiende cuándo aplicar cada concepto

4. **Explora y Modifica el Código** (30-60 min)
   - Abre los archivos `.cs` en `Examples/`
   - Modifica y experimenta
   - Prueba variaciones

5. **Practica** (1-2 horas)
   - Crea tus propios ejemplos
   - Aplica en un proyecto personal

---

## 🎯 Objetivos por Fase

### ✅ Fase 1: Fundamentos
- Entender tipos de datos y colecciones
- Dominar LINQ básico
- Escribir código limpio

### ✅ Fase 2: OOP
- Dominar los 4 pilares de OOP
- Entender herencia y polimorfismo
- Usar interfaces correctamente

### ✅ Fase 3: C# Moderno
- Usar características modernas de C#
- Pattern matching y null handling
- Primary constructors y más

### ✅ Fase 4: ASP.NET Core
- Construir APIs
- Entender ciclo de vida de requests
- Usar middleware y logging

### ✅ Fase 5: EF Core
- Trabajar con bases de datos
- Optimizar consultas
- Usar diferentes estrategias de carga

### ✅ Fase 6: Performance
- Optimizar aplicaciones
- Mejorar rendimiento de consultas

### ✅ Fase 7: Avanzado
- Aplicar patrones de diseño
- Usar reflection y atributos

---

## 💡 Consejos de Estudio

1. **Sé consistente**: Dedica tiempo regularmente (1-2 horas diarias)
2. **Practica activamente**: No solo leas, escribe código
3. **Construye proyectos**: Aplica lo aprendido en proyectos reales
4. **Revisa regularmente**: Repasa conceptos anteriores
5. **Haz preguntas**: Si algo no está claro, investiga más

---

## ⏱️ Tiempo Total Estimado

- **Fase 1**: ~40 horas (3 semanas)
- **Fase 2**: ~20 horas (2 semanas)
- **Fase 3**: ~20 horas (1 semana)
- **Fase 4**: ~20 horas (2 semanas)
- **Fase 5**: ~15 horas (1 semana)
- **Fase 6**: ~5 horas (1 semana)
- **Fase 7**: ~10 horas (1 semana)

**Total: ~130 horas** (11 semanas a ritmo moderado)

---

## ✅ Checklist de Progreso

### Fase 1: Fundamentos
- [ ] Tipos de Datos
- [ ] Variables y Conversión
- [ ] Parse vs TryParse
- [ ] Date & Time
- [ ] Manejo de Excepciones
- [ ] Arrays vs ArrayList
- [ ] Collections
- [ ] List vs HashSet
- [ ] IEnumerable vs IQueryable
- [ ] LINQ Methods
- [ ] Convenciones de Nomenclatura
- [ ] Clear Property Names
- [ ] Interpolated Strings
- [ ] Avoid Too Many Arguments
- [ ] Prefer IEnumerable<T>
- [ ] SelectMany
- [ ] MinBy/MaxBy

### Fase 2: OOP
- [ ] Encapsulación
- [ ] Abstracción
- [ ] Herencia
- [ ] Polimorfismo
- [ ] Tipos de Herencia
- [ ] Abstract Class vs Interface
- [ ] Key Class Concepts
- [ ] Pass By Reference vs Value
- [ ] Null Argument Checks
- [ ] TryGetValue

### Fase 3: C# Moderno
- [ ] Modern C# Features
- [ ] Switch Expressions
- [ ] Primary Constructors
- [ ] C# Enhancements .NET 9
- [ ] Essential Keywords
- [ ] Top 20 Features
- [ ] Modern LINQ

### Fase 4: ASP.NET Core
- [ ] Middleware Order
- [ ] MVC Request Life Cycle
- [ ] Minimal APIs
- [ ] Web API Action Selection
- [ ] Logging
- [ ] Scrutor
- [ ] AutoMapper

### Fase 5: EF Core
- [ ] Entity Framework Core
- [ ] EF Core 9 Features
- [ ] AsNoTracking
- [ ] Loading Strategies
- [ ] LINQ to SQL vs Objects

### Fase 6: Performance
- [ ] String vs StringBuilder
- [ ] SQL Query Optimization

### Fase 7: Avanzado
- [ ] Unit of Work Pattern
- [ ] Attributes & Reflection
- [ ] SecureString

---

¡Éxito en tu aprendizaje! 🚀
