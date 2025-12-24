# C# Fundamentals 🎯

## Introducción

Los fundamentos de C# son conceptos esenciales que todo desarrollador debe dominar. Este apartado contiene conceptos básicos pero importantes de C# que son fundamentales para escribir código robusto y eficiente.

## 📚 Temas Disponibles

### 1. Understanding int.Parse() vs int.TryParse()
**Ubicación:** `concepts/09-csharp-fundamentals/01-parse-vs-tryparse/`

Guía sobre las diferencias entre `int.Parse()` e `int.TryParse()`, especialmente en el manejo de excepciones y rendimiento.

### 2. Date & Time
**Ubicación:** `concepts/09-csharp-fundamentals/02-date-time/`

Guía completa sobre el manejo de fechas y horas en C#. Cubre DateTime, TimeSpan, inmutabilidad, formateo, y mejores prácticas para trabajar con fechas y horas.

### 3. Data Types
**Ubicación:** `concepts/09-csharp-fundamentals/03-data-types/`

Guía sobre Value Types vs Reference Types en C#. Comprender la diferencia ayuda a gestionar la memoria de manera eficiente y optimizar el rendimiento.

### 4. Attributes & Reflection
**Ubicación:** `concepts/09-csharp-fundamentals/04-attributes-reflection/`

Guía completa sobre Attributes y Reflection en .NET. Herramientas esenciales para escribir código robusto, adaptable y altamente escalable. Usadas por frameworks como ASP.NET Core y Entity Framework.

### 5. Modern LINQ with Pattern Matching
**Ubicación:** `concepts/09-csharp-fundamentals/05-modern-linq-pattern-matching/`

Guía sobre cómo combinar LINQ moderno con Pattern Matching en C# para escribir código más limpio, legible y mantenible. Incluye ejemplos de filtrado simplificado, legibilidad mejorada y combinación con async.

### 6. Primary Constructors
**Ubicación:** `concepts/09-csharp-fundamentals/06-primary-constructors/`

Guía completa sobre Primary Constructors en C# 12+. Reduce el código hasta en un 50% eliminando boilerplate de constructores tradicionales.

**Características Clave:**
- **Reducción de Código**: Reduce boilerplate hasta en 50%
- **Parámetros Automáticos**: Parámetros disponibles en toda la clase
- **Perfecto para DI**: Ideal para service classes con Dependency Injection
- **Inmutabilidad**: Perfecto para objetos inmutables y value objects
- **Records**: Se combina perfectamente con record types

**Ideal Para:**
- Service classes con dependencias claras
- Repository classes
- Value Objects (DDD)
- Configuration classes
- Factory classes
- Clases pequeñas y enfocadas siguiendo SOLID

### 7. Keywords en C#
**Ubicación:** `concepts/09-csharp-fundamentals/07-keywords/`

Guía completa sobre los Keywords esenciales de C#. Los keywords son los bloques fundamentales de la sintaxis de C# y comprenderlos a fondo es esencial para escribir código efectivo.

**Categorías Principales:**
- **Access Modifiers**: public, private, protected, internal, protected internal
- **Declaration Keywords**: class, interface, struct, enum, record
- **Type Keywords**: string, int, bool, double, decimal, var
- **Method Modifiers**: static, virtual, override, abstract, async, await
- **Control Flow**: if, else, switch, for, foreach, while, do, break, continue, return, throw, try, catch, finally
- **Modern Features**: null, default, using, is, as, new, nameof, when
- **Memory Management**: fixed, unsafe, stackalloc, volatile
- **Contextual Keywords**: value, get, set, yield, partial, where

**Importancia:**
- Los keywords son palabras reservadas con significado especial
- No pueden usarse como identificadores (excepto con @)
- Cada keyword tiene un propósito específico
- Comprenderlos a fondo te hace un mejor desarrollador C#

### 8. Modern C# Features
**Ubicación:** `concepts/09-csharp-fundamentals/08-modern-features/`

Guía completa sobre las características modernas de C# que han transformado cómo escribimos código, moviendo la detección de errores de tiempo de ejecución a tiempo de compilación.

**Características Principales:**
- **Null Handling Philosophy**: Operadores `?.` y `??` para manejo seguro de null
- **Pattern Matching**: Type patterns, property patterns, positional patterns, relational patterns, logical patterns
- **Resource Management**: Evolución de `using` statement a `using` declaration
- **Target-Typed 'new'**: Inferencia de tipos para reducir verbosidad
- **Strategic 'nameof'**: Referencias seguras ante refactoring
- **Type Conversion Safety**: Operador `as` para conversión segura de tipos

**Impacto:**
- **From Runtime to Compile-Time Safety**: Moviendo detección de errores más temprano
- **Reducing Production Issues**: Reduciendo problemas en producción
- **Improving Code Reliability**: Mejorando confiabilidad del código

### 9. Collections in C#
**Ubicación:** `concepts/09-csharp-fundamentals/09-collections/`

Guía completa sobre las colecciones en C#, organizadas en tres categorías principales para diferentes escenarios y necesidades.

**Categorías Principales:**
- **System.Collections.Generic**: Dictionary, List, Queue, Stack, SortedList (type-safe, más utilizadas)
- **System.Collections.Concurrent**: ConcurrentDictionary, ConcurrentQueue, ConcurrentStack, BlockingCollection, ConcurrentBag (thread-safe)
- **System.Collections**: ArrayList, Hashtable, Queue, Stack (legacy, no recomendadas)

**Por Qué Importan:**
- **Simplifican Gestión de Datos**: Estructuran y organizan datos eficientemente
- **Habilitan Programación Thread-Safe**: Operaciones seguras sin locks explícitos
- **Perfectas para Escenarios Diversos**: Desde algoritmos hasta aplicaciones del mundo real

### 10. LINQ to SQL vs LINQ to Objects
**Ubicación:** `concepts/09-csharp-fundamentals/12-linq-to-sql-vs-linq-to-objects/`

Guía completa sobre las diferencias entre LINQ to SQL y LINQ to Objects, dos enfoques fundamentales para consultar datos en C#.

**Diferencias Clave:**
- **LINQ to SQL**: Para bases de datos relacionales, retorna `IQueryable<T>`, traduce LINQ → SQL
- **LINQ to Objects**: Para colecciones en memoria, retorna `IEnumerable<T>`, ejecuta directamente
- **Fuente de Datos**: Bases de datos vs memoria
- **Ejecución**: Server-side vs client-side
- **Rendimiento**: Optimizado para grandes datasets vs rápido para pequeños datasets

**Cuándo Usar:**
- **LINQ to SQL**: Bases de datos, grandes datasets, operaciones CRUD
- **LINQ to Objects**: Datos en memoria, pequeños datasets, métodos C# personalizados

### 11. Métodos LINQ: Guía Completa
**Ubicación:** `concepts/09-csharp-fundamentals/13-linq-methods/`

Guía completa sobre todos los métodos LINQ organizados por categorías funcionales. LINQ permite consultar colecciones de forma declarativa, similar a SQL.

**Categorías Principales:**
- **Filtering**: Where, Take, Skip, TakeWhile, SkipWhile
- **Projection**: Select, SelectMany
- **Joining**: Join, GroupJoin, Zip
- **Ordering**: OrderBy, ThenBy, Reverse
- **Grouping**: GroupBy
- **Aggregation**: Sum, Average, Count, Min, Max, Aggregate
- **Quantifiers**: All, Any, Contains, SequenceEqual
- **Element**: First, Last, Single, ElementAt
- **Set**: Union, Intersect, Except, Concat
- **Conversion**: ToArray, ToList, ToDictionary, Cast, OfType

**Por Qué Usar LINQ:**
- **Mejora Legibilidad**: Código declarativo vs imperativo
- **Reduce Loops**: Menos código boilerplate
- **Capacidades Poderosas**: Filtrado, ordenamiento, agrupación, agregaciones
- **Múltiples Fuentes**: Funciona con colecciones, bases de datos, XML, JSON

### 13. Arrays vs ArrayList
**Ubicación:** `concepts/09-csharp-fundamentals/15-arrays-vs-arraylist/`

Guía completa sobre las diferencias entre Arrays y ArrayList (List<T>) en C#, cuándo usar cada uno y por qué.

**Diferencias Clave:**
- **Tamaño**: Arrays son fijos, List<T> son dinámicos
- **Rendimiento**: Arrays ganan en velocidad, List<T> brilla en flexibilidad
- **Type Safety**: Arrays son strictly typed, ArrayList requiere generics (List<T>) para type-safety

**Cuándo Usar:**
- **Arrays**: Tamaño conocido, rendimiento crítico, operaciones matemáticas, buffers fijos
- **List<T>**: Tamaño desconocido, modificaciones frecuentes, datos dinámicos

**Nota Importante:** ArrayList es legacy y no se recomienda en código nuevo. Usar List<T> en su lugar para type-safety y mejor rendimiento.

### 14. Pass By Reference vs Pass By Value
**Ubicación:** `concepts/09-csharp-fundamentals/16-pass-by-reference-vs-value/`

Guía completa sobre cómo C# pasa parámetros a métodos, explicando Pass By Reference vs Pass By Value y el uso de `ref`, `out`, e `in`.

**Conceptos Clave:**
- **Pass By Value**: Comportamiento por defecto, se pasa una copia de la referencia o del valor
- **Pass By Reference**: Con `ref`, se pasa una referencia directa al original
- **out Parameters**: Similar a `ref` pero sin requerir inicialización, ideal para múltiples valores de retorno
- **in Parameters**: Referencia de solo lectura, evita copiar structs grandes (C# 7.0+)

**Por Qué Importa:**
- 🐛 Elimina bugs difíciles de encontrar en sistemas ASP.NET complejos
- 🚀 Mejora dramáticamente el rendimiento a través de optimización de memoria
- 🛡️ Protege la integridad de datos en operaciones de Entity Framework
- 🧩 Hace tus métodos C# más predecibles y testeables

**Diferencias Clave:**
- **Value Types**: Se pasan por copia del valor (necesitas `ref` para modificar)
- **Reference Types**: Se pasa una copia de la referencia (puedes modificar propiedades, pero no reasignar sin `ref`)

### 15. List vs HashSet
**Ubicación:** `concepts/09-csharp-fundamentals/17-list-vs-hashset/`

Guía completa sobre las diferencias entre List<T> y HashSet<T> en .NET, cuándo usar cada uno y por qué.

**Diferencias Clave:**
- **List<T>**: Mantiene orden, permite duplicados, acceso por índice O(1), búsqueda O(n)
- **HashSet<T>**: Solo elementos únicos, sin orden garantizado, búsqueda O(1), operaciones de conjunto

**Cuándo Usar:**
- **List<T>**: Elementos ordenados, duplicados aceptables, acceso por índice importante
- **HashSet<T>**: Búsquedas rápidas, sin duplicados, unicidad esencial, operaciones de conjunto

**Bonus Tip:** En aplicaciones críticas para el rendimiento, cambiar de List a HashSet puede mejorar significativamente el rendimiento (O(n) vs O(1) para búsquedas).

---

## 🎯 Objetivo

Este apartado está diseñado para ayudarte a:
- Comprender conceptos fundamentales de C#
- Aplicar mejores prácticas en conversión de tipos
- Manejar errores de forma elegante
- Escribir código más robusto y eficiente

## 📖 Principios Fundamentales

- **Robustez**: Manejar casos edge y errores de forma elegante
- **Performance**: Elegir métodos eficientes cuando sea posible
- **Claridad**: Código claro y fácil de entender
- **Mantenibilidad**: Código fácil de mantener y extender

### 16. C# Enhancements in .NET 9.0
**Ubicación:** `concepts/09-csharp-fundamentals/18-csharp-enhancements-net9/`

Guía completa sobre las mejoras de C# en .NET 9.0 que permiten escribir código más limpio, más conciso y expresivo sin comprometer la legibilidad o el rendimiento.

**Mejoras Principales:**
- **Primary Constructors**: Simplifica inicialización de clases y records, reduce código hasta en un 50%
- **Auto-Default Structs**: Inicialización automática de miembros, evita bugs de campos no inicializados
- **Enhanced Pattern Matching**: Capacidades más poderosas y flexibles, reduce cadenas if-else anidadas

**Beneficios:**
- ⚡ **Rendimiento**: Código más eficiente sin sacrificar legibilidad
- 🧩 **Flexibilidad**: Más opciones para expresar lógica
- 💡 **Simplicidad**: Menos código, menos errores, más productividad
- ✨ **Expresividad**: Código más limpio y elegante

### 17. Switch Expressions in C# 8
**Ubicación:** `concepts/09-csharp-fundamentals/19-switch-expressions/`

Guía completa sobre Switch Expressions en C# 8: sintaxis más limpia y expresiva para reemplazar los tradicionales switch statements.

**Características Clave:**
- **Say Goodbye to Boilerplate**: Elimina `break`, `case`, y llaves innecesarias
- **One-liner Logic**: Lógica más concisa con mejor legibilidad
- **Easier to Test**: Más fácil de testear, depurar y refactorizar
- **Great for Mapping**: Perfecto para mapear planes, roles, enums y más
- **Expression-bodied Members**: Se combina perfectamente con expression-bodied members

**Perfect Use Cases:**
- 🔁 Subscription Plans
- 🔁 Status Codes
- 🔁 User Roles
- 🔁 Enum Mapping
- 🔁 API Responses

**Developer Tip:** Combina Switch Expressions con Pattern Matching y Expression-bodied members para un estilo más funcional y limpio.

