# .NET Mastery Lab 🚀

Repositorio de aprendizaje para dominar conceptos avanzados de C# y .NET y alcanzar un nivel senior.

## 📚 Conceptos Disponibles

### 1. IEnumerable vs IQueryable
**Ubicación:** `concepts/01-ienumerable-vs-iqueryable/`

Una comparación práctica de estas dos interfaces fundamentales en C# para el manejo de colecciones y consultas de datos.

**Diferencias Clave:**
- **IEnumerable**: Ejecuta consultas en memoria (client-side)
- **IQueryable**: Traduce consultas a SQL y ejecuta en el servidor (server-side)

### 2. Null Argument Checks
**Ubicación:** `concepts/02-null-argument-checks/`

Comparación de métodos para validar argumentos nulos en C#, mostrando las mejoras de rendimiento y sintaxis en .NET 6+.

**Diferencias Clave:**
- **Método Tradicional**: Más lento, sintaxis verbosa
- **ArgumentNullException.ThrowIfNull**: Más rápido (~48x), sintaxis concisa
- **Con nameof**: Mejor rendimiento y mensajes de error claros

### 3. TryGetValue para Evitar Doble Búsqueda
**Ubicación:** `concepts/03-trygetvalue-avoid-double-lookup/`

Demostración de cómo `TryGetValue` es más eficiente que `ContainsKey` + indexador para obtener valores de diccionarios, evitando dobles búsquedas.

**Diferencias Clave:**
- **Doble Búsqueda**: `ContainsKey` + `dictionary[key]` (menos eficiente, 2 operaciones)
- **Una Sola Búsqueda**: `TryGetValue` (más eficiente, 1 operación)
- **Mejor Rendimiento**: Especialmente importante en aplicaciones críticas para el rendimiento

### 4. Clean Code y Buenas Prácticas 💎
**Ubicación:** `concepts/04-clean-code/`

Conjunto de principios y prácticas para escribir código más legible, mantenible y eficiente en C# y .NET.

#### 4.1. Avoid Too Many Arguments In Functions
**Ubicación:** `concepts/04-clean-code/01-avoid-too-many-arguments/`

Guía práctica sobre cómo reducir el número de argumentos en funciones usando objetos para encapsular datos relacionados.

**Principios Clave:**
- **Regla General**: Limitar argumentos a 2-3 máximo
- **Encapsulación**: Usar structs o clases para agrupar parámetros relacionados
- **Ventajas**: Mejor legibilidad, mantenibilidad, testabilidad y flexibilidad

#### 4.2. Prefer IEnumerable<T> Over List<T> for Return Types
**Ubicación:** `concepts/04-clean-code/02-prefer-ienumerable-over-list/`

Guía sobre por qué preferir `IEnumerable<T>` sobre `List<T>` para tipos de retorno.

**Ventajas Clave:**
- **Flexibilidad**: Cambiar implementación sin afectar consumidores
- **Mejor Encapsulación**: Oculta detalles de implementación
- **Ejecución Diferida**: Más eficiente, evita operaciones innecesarias

#### 4.3. Flattening Nested Collections Using SelectMany
**Ubicación:** `concepts/04-clean-code/03-nested-loops-vs-selectmany/`

Guía sobre cómo usar `SelectMany` para aplanar colecciones anidadas.

**Ventajas Clave:**
- **Código Conciso**: Una línea en lugar de bucles anidados
- **Más Legible**: La intención es clara y expresiva
- **Enfoque Funcional**: Declarativo y fácil de entender
- **Composable**: Fácil de combinar con otros operadores LINQ

#### 4.4. Use MinBy or MaxBy Instead of OrderBy + First/Last
**Ubicación:** `concepts/04-clean-code/04-minby-maxby-instead-of-orderby/`

Guía sobre cómo usar `MinBy` y `MaxBy` para encontrar elementos extremos de manera más eficiente.

**Ventajas Clave:**
- **Más Conciso**: Más fácil de leer y escribir
- **Más Eficiente**: O(n) vs O(n log n) - no necesita ordenar toda la secuencia
- **Más Legible**: La intención es clara y expresiva
- **Disponible en .NET 6+**: Introducido en .NET 6

#### 4.5. Use the Proper Naming Convention
**Ubicación:** `concepts/04-clean-code/05-naming-conventions/`

Guía completa sobre las convenciones de nomenclatura en C# con tabla de referencia completa.

**Propósitos:**
- **Consistencia**: Crea una apariencia consistente en el código
- **Comprensión Rápida**: Permite entender el código más rápidamente
- **Mantenibilidad**: Facilita copiar, cambiar y mantener el código
- **Mejores Prácticas**: Demuestra las mejores prácticas de C#

#### 4.6. Applying C# Interpolated Strings for Cleaner Formatting
**Ubicación:** `concepts/04-clean-code/06-interpolated-strings/`

Guía sobre cómo usar interpolated strings en lugar de `string.Format` para código más legible.

**Ventajas Clave:**
- **Improved Readability**: Mejor legibilidad al insertar expresiones directamente
- **Less Error-Prone**: Menos propenso a errores que placeholders posicionales
- **Dynamic Content**: Fácil incluir valores de variables y expresiones
- **Más Intuitivo**: Código más limpio e intuitivo

### 5. Performance Optimization 🚀
**Ubicación:** `concepts/05-performance-optimization/`

Técnicas y mejores prácticas para optimizar el rendimiento de aplicaciones .NET, especialmente con Entity Framework Core.

#### 5.1. Use AsNoTracking() in Entity Framework Core for Read-Only Queries
**Ubicación:** `concepts/05-performance-optimization/01-asnotracking-ef-core/`

Guía sobre cómo usar `AsNoTracking()` en Entity Framework Core para mejorar el rendimiento en consultas de solo lectura.

**Beneficios Clave:**
- **Performance Boost**: Mejora el rendimiento eliminando el overhead del cambio tracker
- **Reduced Memory Usage**: Menor consumo de memoria al no rastrear entidades
- **Ideal for Reporting**: Perfecto para reportes y operaciones de solo lectura
- **Simple to Implement**: Fácil de implementar, solo agrega `.AsNoTracking()`

#### 5.2. Optimizing ORM: Eager, Lazy & Explicit Loading
**Ubicación:** `concepts/05-performance-optimization/02-loading-strategies/`

Guía completa sobre las estrategias de carga en Entity Framework Core: Eager Loading, Lazy Loading y Explicit Loading.

**Estrategias:**
- **Eager Loading**: Carga datos relacionados inmediatamente con Include()
- **Lazy Loading**: Carga datos cuando se accede a la propiedad
- **Explicit Loading**: Control manual sobre cuándo cargar datos

**Comparación:**
| Estrategia | Cuándo se Carga | Pros | Cons |
|------------|-----------------|------|------|
| **Lazy Loading** | Al acceder propiedad | Ahorra recursos | Problema N+1 |
| **Eager Loading** | Con entidad principal | Eficiente | Consultas grandes |
| **Explicit Loading** | Manualmente activado | Control completo | Más código |

**Recomendación:** Explicit Loading es la estrategia más flexible y eficiente para aplicaciones modernas.

#### 5.3. String vs StringBuilder: Asignación de Memoria
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

### 6. ASP.NET Core 🚀
**Ubicación:** `concepts/06-aspnet-core/`

Conceptos fundamentales y mejores prácticas para desarrollar aplicaciones web con ASP.NET Core.

#### 6.1. Middleware Order in .NET Pipeline
**Ubicación:** `concepts/06-aspnet-core/01-middleware-order/`

Guía completa sobre el orden recomendado de middlewares en el pipeline de ASP.NET Core.

#### 6.2. ASP.NET Core MVC Request Life Cycle
**Ubicación:** `concepts/06-aspnet-core/02-mvc-request-lifecycle/`

Guía completa sobre el ciclo de vida completo de una petición HTTP en ASP.NET Core MVC, desde que entra al sistema hasta que se genera la respuesta.

**Etapas del Ciclo de Vida:**
- **Middleware Pipeline**: Primera parada, filtrado y procesamiento
- **Routing**: Dirección al controlador y acción correctos
- **Controller Initialization**: Instanciación con dependencias
- **Action Method Execution**: Ejecución de lógica de negocio
- **Result Execution**: Procesamiento del resultado
- **View Rendering**: Conversión de datos a HTML (MVC)
- **Response**: Respuesta final al cliente

#### 6.3. APIs Mínimas Mejoradas
**Ubicación:** `concepts/06-aspnet-core/03-minimal-apis/`

Guía completa sobre Minimal APIs en ASP.NET Core, que permiten crear aplicaciones web ligeras y de alto rendimiento con menos código repetitivo.

**Características Principales:**
- **Menos Código Boilerplate**: Sintaxis más concisa que Controllers
- **Mejor Rendimiento**: Menos overhead, inicio más rápido
- **Inyección de Dependencias Optimizada**: DI automática en parámetros
- **Enrutamiento Mejorado**: Constraints y validación integrada
- **Tipos de Resultados Mejorados**: Results helper class

**Cuándo Usar:**
- ✅ Microservicios pequeños
- ✅ Endpoints simples y directos
- ✅ Prioridad en rendimiento y simplicidad
- ⚠️ Considerar Controllers para lógica compleja o múltiples acciones relacionadas

**Por Qué Importa:**
- **Debugging Made Easier**: Rastrear y solucionar problemas eficientemente
- **Optimized Performance**: Afinar middleware y routing para mejor rendimiento
- **Cleaner Code**: Código más limpio y mantenible

#### 6.6. Object Mapping with AutoMapper
**Ubicación:** `concepts/06-aspnet-core/06-automapper-object-mapping/`

Guía completa sobre cómo usar AutoMapper para mapeo objeto-a-objeto en .NET, eliminando código boilerplate y reduciendo errores.

**Características Principales:**
- **Mapeo Automático**: Mapea propiedades automáticamente por nombre
- **Configuración Flexible**: Permite configuración personalizada para casos complejos
- **Reducción de Código**: Elimina código boilerplate de mapeo
- **Type-Safe**: Verificación de tipos en tiempo de compilación
- **Integración ASP.NET Core**: Funciona perfectamente con Dependency Injection

**Comparación:**
- ❌ **Antes**: Mapeo manual verboso (muchas líneas de código repetitivas)
- ✅ **Después**: AutoMapper (una línea mapea múltiples propiedades)

**Ventajas:**
- ✅ Elimina código repetitivo de mapeo
- ✅ Reduce errores humanos
- ✅ Mantiene código limpio y mantenible
- ✅ Ideal para mapear Entities ↔ DTOs

**Instalación:**
```bash
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

**Uso Básico:**
```csharp
// Configuración
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserProfile>();
    }
}

// Registro
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Uso
var userProfile = _mapper.Map<UserProfile>(user);
```

#### 6.7. Logging in .NET Core
**Ubicación:** `concepts/06-aspnet-core/07-logging/`

Guía completa sobre Logging en .NET Core: el backbone de toda aplicación confiable. Si depurar es como trabajo de detective, entonces el logging es tu evidencia.

**Tres Enfoques Principales:**
- **Built-in ILogger**: Ligero, flexible, funciona out-of-the-box
- **Serilog**: Structured logging completo con múltiples sinks
- **NLog**: Simple, rápido y flexible

**Mejores Prácticas:**
- ✅ Preferir logs estructurados sobre texto plano
- ✅ Mantener formatos de log consistentes
- ✅ Nunca registrar información sensible (passwords, tokens, personal data)
- ✅ Centralizar logs usando Seq, Kibana, o Azure Monitor
- ✅ Usar niveles de log sabiamente (Information, Warning, Error, Critical)

**Cuándo Usar:**
- ✅ **Built-in ILogger**: Apps pequeñas, herramientas internas
- ✅ **Serilog**: Sistemas de producción complejos, necesita búsqueda avanzada
- ✅ **NLog**: Background services, prioridad en rendimiento

**Instalación:**

**Serilog:**
```bash
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
dotnet add package Serilog.Sinks.Seq
```

**NLog:**
```bash
dotnet add package NLog.Web.AspNetCore
```

### 7. Security 🔒
**Ubicación:** `concepts/07-security/`

Conceptos y mejores prácticas para proteger datos sensibles y mantener aplicaciones seguras en C# y .NET.

#### 7.1. Keep Your Data Safe with SecureString
**Ubicación:** `concepts/07-security/01-securestring/`

Guía sobre cómo usar `SecureString` para proteger información sensible como contraseñas en memoria.

**Ventajas Clave:**
- **Encrypts Sensitive Data**: Encripta datos sensibles en memoria, reduciendo riesgo de exposición
- **Automatically Clears**: Limpia automáticamente el valor cuando ya no se necesita
- **Prevents Memory Dumps**: Previene que datos sensibles sean fácilmente recuperados mediante memory dumps

### 8. Object-Oriented Programming (OOP) 🎯
**Ubicación:** `concepts/08-object-oriented-programming/`

Conceptos y principios esenciales de Programación Orientada a Objetos en C# y .NET.

#### 8.1. Encapsulation (Encapsulación)
**Ubicación:** `concepts/08-object-oriented-programming/01-encapsulation/`

Guía sobre el concepto de encapsulación: agrupar datos y métodos dentro de una clase, restringiendo el acceso directo y protegiendo el estado interno.

**Conceptos Clave:**
- **Bundling Data and Methods**: Agrupa datos (campos) y métodos dentro de una clase
- **Restrict Direct Access**: Restringe acceso directo a componentes internos
- **Protect Internal State**: Protege el estado interno del objeto
- **Well-Defined Interfaces**: Expone solo funcionalidad necesaria a través de propiedades y métodos

#### 8.2. Abstraction (Abstracción)
**Ubicación:** `concepts/08-object-oriented-programming/02-abstraction/`

Guía sobre el concepto de abstracción: ocultar detalles complejos y mostrar solo las características esenciales mediante clases abstractas y records.

**Características Clave:**
- **Essential Features Only**: Solo expone características esenciales del objeto
- **Interface Design**: Define QUÉ hacer, no CÓMO hacerlo
- **Flexibility and Extensibility**: Permite múltiples implementaciones del mismo concepto
- **Separation of Concerns**: Separa el qué del cómo para código modular y mantenible

#### 8.3. Inheritance with Virtual/Override and Dependency Injection
**Ubicación:** `concepts/08-object-oriented-programming/03-inheritance-virtual-override-di/`

Guía sobre cómo combinar herencia con métodos virtual/override y Dependency Injection en ASP.NET Core.

**Conceptos Clave:**
- **Virtual Methods**: Permiten sobrescritura en clases derivadas, promoviendo flexibilidad
- **Override**: Proporciona implementación específica de métodos virtuales
- **Dependency Injection**: Inyección de dependencias en runtime para componentes desacoplados
- **Minimal APIs**: Endpoints concisos con DI automático en ASP.NET Core

#### 8.4. Polymorphism (Polimorfismo)
**Ubicación:** `concepts/08-object-oriented-programming/04-polymorphism/`

Guía sobre el concepto de polimorfismo: "One Interface, Many Implementations" con Dependency Injection.

**Conceptos Clave:**
- **One Interface, Many Implementations**: Una interfaz, múltiples implementaciones
- **Runtime Polymorphism**: Comportamiento polimórfico en tiempo de ejecución
- **Dependency Injection**: Inyectar diferentes implementaciones para diseño flexible
- **Flexibility and Scalability**: Permite código flexible y escalable

#### 8.5. Key Class Concepts
**Ubicación:** `concepts/08-object-oriented-programming/05-key-class-concepts/`

Guía sobre los conceptos clave de clases en OOP: instancias, referencias y variables.

**Conceptos Clave:**
- **Instance of a Class**: Objeto creado con 'new', tiene su propia memoria
- **Reference of a Class**: Variable que apunta a instancia existente (no es copia)
- **Instance Variables**: Variables que pertenecen a cada instancia (no compartidas)
- **Static Variables**: Variables que pertenecen a la clase (compartidas por todas las instancias)

#### 8.6. Abstract Class vs Interface
**Ubicación:** `concepts/08-object-oriented-programming/06-abstract-class-vs-interface/`

Guía completa sobre las diferencias entre Abstract Class e Interface, cuándo usar cada uno y cómo combinarlos estratégicamente.

**Diferencias Clave:**
- **Implementation**: Abstract Class tiene métodos abstractos y concretos, Interface principalmente declaraciones
- **Inheritance**: Abstract Class = herencia simple, Interface = herencia múltiple
- **Access Modifiers**: Abstract Class = todos los modificadores, Interface = principalmente public
- **Purpose**: Abstract Class = comportamiento común, Interface = contrato

**Cuándo Usar:**
- **Abstract Class**: Relación "is-a", código común, campos, constructores
- **Interface**: Contrato, herencia múltiple, relación "can-do"

#### 8.7. Types of Inheritance in .NET Core
**Ubicación:** `concepts/08-object-oriented-programming/07-types-of-inheritance/`

Guía completa sobre los diferentes tipos de herencia en .NET Core: Single, Multiple (via Interfaces), Multilevel, Hierarchical y Hybrid Inheritance.

**Tipos de Herencia:**
- **Single Inheritance**: Una clase hereda de una clase base única
- **Multiple Inheritance**: Una clase implementa múltiples interfaces
- **Multilevel Inheritance**: Cadena de herencia (A → B → C)
- **Hierarchical Inheritance**: Múltiples clases de una base común
- **Hybrid Inheritance**: Combinación de clase base + interfaces

**Beneficios:**
- ✅ **Code Reusability**: Reutilización de código sin duplicación
- ✅ **Maintainability**: Cambios centralizados se propagan automáticamente
- ✅ **Scalability**: Fácil agregar nuevas funcionalidades
- ✅ **Polymorphism**: Tratamiento uniforme de objetos diferentes

### 9. C# Fundamentals 🎯
**Ubicación:** `concepts/09-csharp-fundamentals/`

Conceptos fundamentales de C# que todo desarrollador debe dominar para escribir código robusto y eficiente.

#### 9.1. Understanding int.Parse() vs int.TryParse()
**Ubicación:** `concepts/09-csharp-fundamentals/01-parse-vs-tryparse/`

Guía sobre las diferencias entre `int.Parse()` e `int.TryParse()`, especialmente en manejo de excepciones y rendimiento.

#### 9.2. Date & Time
**Ubicación:** `concepts/09-csharp-fundamentals/02-date-time/`

Guía completa sobre el manejo de fechas y horas en C#. Cubre DateTime, TimeSpan, inmutabilidad, formateo, y mejores prácticas.

**Conceptos Clave:**
- **DateTime es Inmutable**: Los métodos devuelven nuevas instancias, no modifican el original
- **DateTime.Now vs DateTime.UtcNow**: Usar UTC para almacenar en base de datos
- **Operaciones Comunes**: AddDays(), AddMonths(), AddYears(), etc.
- **TimeSpan**: Para representar duraciones e intervalos de tiempo
- **Formateo**: Métodos predefinidos y formato personalizado

#### 9.3. Data Types
**Ubicación:** `concepts/09-csharp-fundamentals/03-data-types/`

Guía sobre Value Types vs Reference Types en C#. Comprender la diferencia ayuda a gestionar la memoria de manera eficiente y optimizar el rendimiento.

**Conceptos Clave:**
- **Value Types**: Almacenan datos directamente, se copian por valor, se almacenan en la stack
- **Reference Types**: Almacenan dirección de memoria, se copian por referencia, se almacenan en la heap
- **Pre-Defined Types**: Tipos incorporados (int, string, object)
- **User-Defined Types**: Tipos definidos por usuario (struct, class, enum, interface)

#### 9.4. Attributes & Reflection
**Ubicación:** `concepts/09-csharp-fundamentals/04-attributes-reflection/`

Guía completa sobre Attributes y Reflection en .NET. Herramientas esenciales para escribir código robusto, adaptable y altamente escalable.

**Conceptos Clave:**
- **Attributes**: Agregan metadatos a elementos de código (clases, métodos, propiedades)
- **Reflection**: Inspecciona metadatos en tiempo de ejecución
- **Custom Attributes**: Crear attributes personalizados para necesidades específicas
- **Dynamic Invocation**: Ejecutar métodos dinámicamente sin conocer el tipo en tiempo de compilación
- **Uso en Frameworks**: Usados por ASP.NET Core y Entity Framework para routing, validación y mapeo

#### 9.5. Modern LINQ with Pattern Matching
**Ubicación:** `concepts/09-csharp-fundamentals/05-modern-linq-pattern-matching/`

Guía sobre cómo combinar LINQ moderno con Pattern Matching en C# para escribir código más limpio, legible y mantenible.

**Conceptos Clave:**
- **Simplified Data Filtering**: Pattern matching permite condiciones directas sobre propiedades
- **Improved Readability**: Reduce complejidad del código eliminando múltiples if-else
- **LINQ + Async**: Consultas no bloqueantes con ToListAsync() para mejor performance
- **Better Maintainability**: Menos código = menos errores potenciales
- **Extension Methods**: Crear métodos reutilizables con pattern matching

#### 9.6. Primary Constructors
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

#### 9.7. Keywords en C#
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

**Ejemplo Clave:**
```csharp
// Tradicional: Verboso
var activeProducts = products.Where(p => p.IsActive && p.Stock > 0);

// Moderno: Pattern matching
var activeProducts = products.Where(p => p is { IsActive: true, Stock: > 0 });
```

#### 9.8. Modern C# Features
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

#### 9.9. Collections in C#
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

#### 9.10. LINQ to SQL vs LINQ to Objects
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

#### 9.11. Métodos LINQ: Guía Completa
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

#### 9.12. Top 20 Características Esenciales de C#
**Ubicación:** `concepts/09-csharp-fundamentals/14-essential-csharp-features/`

Guía completa sobre las 20 características esenciales de C# que todo desarrollador debe conocer, desde genéricos hasta collection expressions.

**Características Principales:**
1. Genéricos - Código reutilizable y type-safe
2. Tipo Dynamic - Flexibilidad en tiempo de ejecución
3. Tuplas y Deconstrucción - Múltiples valores de retorno
4. Top-Level Statements - Código más simple
5. Clases Parciales - Dividir clases en archivos
6. Async/Await - Programación asíncrona
7. Pattern Matching - Lógica condicional clara (ya cubierto)
8. Global Using - Menos repetición de using
9. LINQ - Consultas declarativas (ya cubierto)
10. Interpolación de Cadenas - Formato limpio (ya cubierto)
11. Nullable Reference Types - Seguridad contra null (ya cubierto)
12. List Patterns - Pattern matching en colecciones
13. Lambda Expressions - Funciones anónimas
14. Expression Body Members - Métodos concisos
15. Default Interface Methods - Extender interfaces
16. required modifier - Propiedades obligatorias
17. Extension Methods - Extender tipos
18. Auto-Property Initializers - Inicialización directa
19. Records - Tipos inmutables
20. Collection Expressions - Inicialización concisa

**Por Qué Importa:**
- **Visión Completa**: Todas las características esenciales en un solo lugar
- **Mejores Prácticas**: Cuándo usar cada característica
- **Referencias Cruzadas**: Enlaces a temas relacionados para profundizar

#### 9.13. Arrays vs ArrayList
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

#### 9.14. Pass By Reference vs Pass By Value
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

#### 9.15. List vs HashSet
**Ubicación:** `concepts/09-csharp-fundamentals/17-list-vs-hashset/`

Guía completa sobre las diferencias entre List<T> y HashSet<T> en .NET, cuándo usar cada uno y por qué.

**Diferencias Clave:**
- **List<T>**: Mantiene orden, permite duplicados, acceso por índice O(1), búsqueda O(n)
- **HashSet<T>**: Solo elementos únicos, sin orden garantizado, búsqueda O(1), operaciones de conjunto

**Cuándo Usar:**
- **List<T>**: Elementos ordenados, duplicados aceptables, acceso por índice importante
- **HashSet<T>**: Búsquedas rápidas, sin duplicados, unicidad esencial, operaciones de conjunto

**Bonus Tip:** En aplicaciones críticas para el rendimiento, cambiar de List a HashSet puede mejorar significativamente el rendimiento (O(n) vs O(1) para búsquedas).

#### 9.16. C# Enhancements in .NET 9.0
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

#### 9.17. Switch Expressions in C# 8
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

### 11. Design Patterns en .NET 🎨
**Ubicación:** `concepts/11-design-patterns/`

Patrones de diseño esenciales para aplicaciones .NET, especialmente útiles para arquitectura empresarial y aplicaciones escalables.

### 12. Database & SQL Optimization 🗄️
**Ubicación:** `concepts/12-database/`

Conceptos fundamentales y mejores prácticas para optimizar consultas SQL y mejorar el rendimiento de bases de datos en aplicaciones .NET.

#### 12.1. Optimizing SQL Queries for Maximum Performance
**Ubicación:** `concepts/12-database/01-sql-query-optimization/`

Guía completa sobre cómo optimizar consultas SQL para obtener el máximo rendimiento, mejorando velocidad, eficiencia y escalabilidad.

**Factores Clave:**
- **Índices**: Mejoran velocidad de búsqueda pero pueden ralentizar escrituras
- **Joins & Subqueries**: Estructura pobre aumenta tiempo de ejecución
- **Query Execution Plan**: Determina la forma más eficiente de ejecutar
- **Data Types**: Tipos apropiados mejoran almacenamiento y velocidad
- **Hardware Resources**: CPU, RAM y velocidad de disco impactan rendimiento

**Mejores Prácticas:**
- ✅ Indexing para búsquedas más rápidas
- ✅ Obtener solo datos requeridos (evitar SELECT *)
- ✅ Optimizar JOINs
- ✅ Usar filtrado eficiente (WHERE vs HAVING)
- ✅ Minimizar ordenamiento y agrupación
- ✅ Elegir tipos de datos correctos
- ✅ Analizar planes de ejecución
- ✅ Mantener y optimizar almacenamiento

**Impacto Típico:**
- **Velocidad**: 10x - 100x más rápido con índices apropiados
- **Memoria**: 50-80% reducción con SELECT específico
- **Escalabilidad**: Manejar 10x más datos con la misma infraestructura
- **Costo**: 30-50% reducción en costos de infraestructura

### 13. Entity Framework Core 🚀
**Ubicación:** `concepts/13-entity-framework-core/`

Guía completa sobre Entity Framework Core (EF Core), un ORM ligero, extensible y multiplataforma para aplicaciones .NET.

**¿Qué es EF Core?**
- **ORM**: Object-Relational Mapper que mapea objetos a tablas
- **Múltiples Proveedores**: SQL Server, MySQL, PostgreSQL, SQLite
- **LINQ a SQL**: Traduce consultas LINQ a SQL automáticamente
- **Migraciones**: Versionado automático de esquema de base de datos

**¿Por Qué Usar EF Core?**
- ✅ **No SQL Crudo**: Consultas type-safe con LINQ
- ✅ **Independiente de BD**: Soporta múltiples proveedores
- ✅ **Migraciones Automáticas**: Versionado de esquema simplificado
- ✅ **Alta Productividad**: Menos código boilerplate
- ✅ **Seguimiento Automático**: Detección de cambios integrada
- ✅ **Carga Flexible**: Eager, Lazy y Explicit loading
- ✅ **Consultas Optimizadas**: Compiled queries para mejor rendimiento
- ✅ **Integración ASP.NET Core**: Funciona perfectamente con el framework

**Características Avanzadas:**
- ✅ **Consultas LINQ**: Consultar bases de datos usando expresiones C#
- ✅ **Filtros Globales**: Aplicar condiciones a todas las consultas
- ✅ **Transacciones**: Consistencia de datos garantizada
- ✅ **Data Seeding**: Insertar registros por defecto automáticamente
- ✅ **Consultas Compiladas**: Optimizar rendimiento con precompilación

**Temas Relacionados:**
Este repositorio cubre temas avanzados de EF Core:
- **AsNoTracking**: Optimización para consultas de solo lectura (Performance Optimization)
- **Eager, Lazy & Explicit Loading**: Estrategias de carga (Performance Optimization)
- **Unit of Work & Repository Pattern**: Patrones de diseño con EF Core (Design Patterns)

### 11. Design Patterns en .NET 🎨
**Ubicación:** `concepts/11-design-patterns/`

Sección dedicada a patrones de diseño esenciales para aplicaciones .NET, especialmente útiles para arquitectura empresarial y aplicaciones escalables.

#### 11.1. Unit of Work Pattern
**Ubicación:** `concepts/11-design-patterns/01-unit-of-work/`

Guía completa sobre el patrón Unit of Work en .NET Core. Un patrón poderoso que gestiona transacciones de base de datos y asegura consistencia de datos.

**Conceptos Clave:**
- **Transaction Control**: Gestiona múltiples cambios de base de datos como una sola unidad
- **Code Organization**: Centraliza la lógica de gestión de transacciones
- **Data Consistency**: Asegura operaciones all-or-nothing
- **Performance**: Reduce round-trips a la base de datos
- **Maintainability**: Hace el código más limpio y mantenible

**Componentes Principales:**
- **IUnitOfWork Interface**: Define el contrato para gestión de transacciones
- **Repositories**: Manejan operaciones específicas de entidades
- **Database Context**: Implementación en Entity Framework Core
- **Transaction Scope**: Gestiona el límite de operaciones

**Ejemplo Clave:**
```csharp
public interface IUnitOfWork : IDisposable
{
    IOrderRepository Orders { get; }
    ICustomerRepository Customers { get; }
    Task<int> CommitAsync();
}
```

### 10. Angular Integration con .NET 🅰️
**Ubicación:** `concepts/10-angular-integration/`

Sección dedicada a la integración de Angular con aplicaciones .NET, mostrando cómo construir aplicaciones full-stack modernas.

#### 10.1. Template-Driven vs. Reactive Forms
**Ubicación:** `concepts/10-angular-integration/01-template-driven-vs-reactive-forms/`

Guía completa sobre las diferencias entre Template-Driven Forms y Reactive Forms en Angular, cuándo usar cada uno, y cómo integrarlos con APIs .NET.

**Conceptos Clave:**
- **Template-Driven Forms**: Simples, fáciles de configurar, ideales para formularios básicos
- **Reactive Forms**: Robustos, escalables, ideales para formularios complejos
- **Integración .NET**: Validación dual (cliente Angular y servidor .NET)
- **Type Safety**: Interfaces TypeScript que coinciden con DTOs de .NET
- **Mejores Prácticas**: Cuándo usar cada enfoque según la complejidad del formulario

**Diferencias Clave:**
- **Template-Driven**: Usa `FormsModule`, `[(ngModel)]`, lógica en template
- **Reactive Forms**: Usa `ReactiveFormsModule`, `FormBuilder`, lógica en componente
- **Escalabilidad**: Template-Driven limitada, Reactive Forms excelente
- **Testing**: Template-Driven más difícil, Reactive Forms más fácil

#### 6.1. Middleware Order in .NET Pipeline
**Ubicación:** `concepts/06-aspnet-core/01-middleware-order/`

Guía completa sobre el orden recomendado de middlewares en el pipeline de ASP.NET Core.

**Orden Recomendado:**
1. UseExceptionHandler - Manejo global de excepciones
2. UseHsts - HTTP Strict Transport Security
3. UseHttpsRedirection - Redirección a HTTPS
4. UseStaticFiles - Servir archivos estáticos
5. UseRouting - Habilitar routing
6. UseCors - Cross-Origin Resource Sharing
7. UseAuthentication - Autenticación
8. UseAuthorization - Autorización
9. UseResponseCompression - Compresión de respuestas
10. UseEndpoints - Mapear endpoints

## 🎯 Objetivo

Este repositorio está diseñado para desarrolladores que buscan:
- Comprender conceptos avanzados de C# y .NET
- Ver ejemplos prácticos y ejecutables
- Entender las diferencias y cuándo usar cada enfoque
- Prepararse para entrevistas técnicas y roles senior

## 🏗️ Estructura

```
net-mastery-lab/
├── concepts/           # Conceptos organizados por tema
│   ├── 01-ienumerable-vs-iqueryable/
│   │   ├── README.md          # Explicación detallada
│   │   ├── Examples/           # Ejemplos prácticos
│   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 02-null-argument-checks/
│   │   ├── README.md          # Explicación detallada
│   │   ├── Examples/           # Ejemplos prácticos y benchmarks
│   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 03-trygetvalue-avoid-double-lookup/
│   │   ├── README.md          # Explicación detallada
│   │   ├── Examples/           # Ejemplos prácticos
│   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   └── 04-clean-code/
│       ├── README.md          # Introducción a Clean Code
│       ├── 01-avoid-too-many-arguments/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 02-prefer-ienumerable-over-list/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 03-nested-loops-vs-selectmany/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 04-minby-maxby-instead-of-orderby/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 05-naming-conventions/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 06-interpolated-strings/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       └── 07-clear-descriptive-property-names/
│           ├── README.md          # Explicación detallada
│           ├── Examples/           # Ejemplos prácticos
│           └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 05-performance-optimization/
│   │   ├── README.md          # Introducción a Performance Optimization
│   │   ├── 01-asnotracking-ef-core/
│   │   │   ├── README.md          # Explicación detallada
│   │   │   ├── Examples/           # Ejemplos prácticos
│   │   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   │   ├── 02-loading-strategies/
│   │   │   ├── README.md          # Explicación detallada
│   │   │   ├── Examples/           # Ejemplos prácticos
│   │   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   │   └── 03-string-vs-stringbuilder/
│   │       ├── README.md          # Explicación detallada
│   │       ├── Examples/           # Ejemplos prácticos
│   │       └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 06-aspnet-core/
│   │   ├── README.md          # Introducción a ASP.NET Core
│   │   ├── 01-middleware-order/
│   │   │   ├── README.md          # Explicación detallada
│   │   │   ├── Examples/           # Ejemplos prácticos
│   │   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   │   ├── 02-mvc-request-lifecycle/
│   │   │   ├── README.md          # Explicación detallada
│   │   │   ├── Examples/           # Ejemplos prácticos
│   │   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   │   ├── 03-minimal-apis/
│   │   │   ├── README.md          # Explicación detallada
│   │   │   ├── Examples/           # Ejemplos prácticos
│   │   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   │   ├── 04-web-api-action-selection/
│   │   │   ├── README.md          # Explicación detallada
│   │   │   ├── Examples/           # Ejemplos prácticos
│   │   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   │   ├── 05-scrutor-auto-register/
│   │   │   ├── README.md          # Explicación detallada
│   │   │   ├── Examples/           # Ejemplos prácticos
│   │   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   │   ├── 06-automapper-object-mapping/
│   │   │   ├── README.md          # Explicación detallada
│   │   │   ├── Examples/           # Ejemplos prácticos
│   │   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   │   └── 07-logging/
│   │       ├── README.md          # Explicación detallada
│   │       ├── Examples/           # Ejemplos prácticos
│   │       └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 07-security/
│   │   ├── README.md          # Introducción a Security
│   │   └── 01-securestring/
│   │       ├── README.md          # Explicación detallada
│   │       ├── Examples/           # Ejemplos prácticos
│   │       └── BEST_PRACTICES.md  # Mejores prácticas
│   └── 08-object-oriented-programming/
│       ├── README.md          # Introducción a OOP
│       ├── 01-encapsulation/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 02-abstraction/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 03-inheritance-virtual-override-di/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 04-polymorphism/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 05-key-class-concepts/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 06-abstract-class-vs-interface/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       └── 07-types-of-inheritance/
│           ├── README.md          # Explicación detallada
│           ├── Examples/           # Ejemplos prácticos
│           └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 09-csharp-fundamentals/
│       ├── README.md          # Introducción a C# Fundamentals
│       ├── 01-parse-vs-tryparse/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 02-date-time/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 03-data-types/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 04-attributes-reflection/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 05-modern-linq-pattern-matching/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 06-primary-constructors/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 07-keywords/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 08-modern-features/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 09-collections/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 10-variables-type-conversion/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 11-exception-handling/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 12-linq-to-sql-vs-linq-to-objects/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 13-linq-methods/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 14-essential-csharp-features/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 15-arrays-vs-arraylist/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 16-pass-by-reference-vs-value/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── 18-csharp-enhancements-net9/
│       │   ├── README.md          # Explicación detallada
│       │   ├── Examples/           # Ejemplos prácticos
│       │   └── BEST_PRACTICES.md  # Mejores prácticas
│       └── 19-switch-expressions/
│           ├── README.md          # Explicación detallada
│           ├── Examples/           # Ejemplos prácticos
│           └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 10-angular-integration/
│   │   ├── README.md          # Introducción a Angular Integration
│   │   └── 01-template-driven-vs-reactive-forms/
│   │       ├── README.md          # Explicación detallada
│   │       ├── Examples/           # Ejemplos prácticos
│   │       └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 11-design-patterns/
│   │   ├── README.md          # Introducción a Design Patterns
│   │   └── 01-unit-of-work/
│   │       ├── README.md          # Explicación detallada
│   │       ├── Examples/           # Ejemplos prácticos
│   │       └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 12-database/
│   │   ├── README.md          # Introducción a Database & SQL Optimization
│   │   └── 01-sql-query-optimization/
│   │       ├── README.md          # Explicación detallada
│   │       ├── Examples/           # Ejemplos prácticos
│   │       └── BEST_PRACTICES.md  # Mejores prácticas
│   └── 13-entity-framework-core/
│       ├── README.md          # Explicación detallada
│       ├── Examples/           # Ejemplos prácticos
│       ├── BEST_PRACTICES.md  # Mejores prácticas
│       └── 01-ef-core-9-features/
│           ├── README.md          # Nuevas características de EF Core 9.0
│           ├── Examples/           # Ejemplos prácticos
│           └── BEST_PRACTICES.md  # Mejores prácticas
├── LICENSE
└── README.md
```

## 🚀 Cómo Usar

Cada concepto incluye:
- Explicación teórica detallada
- Ejemplos de código ejecutables
- Comparaciones prácticas
- Casos de uso recomendados

## 📝 Contribuciones

Este es un repositorio de aprendizaje personal. Siéntete libre de hacer fork y adaptarlo a tus necesidades.

## 📄 Licencia

Apache License 2.0

