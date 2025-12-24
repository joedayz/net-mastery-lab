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

### 6. ASP.NET Core 🚀
**Ubicación:** `concepts/06-aspnet-core/`

Conceptos fundamentales y mejores prácticas para desarrollar aplicaciones web con ASP.NET Core.

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

**Ejemplo Clave:**
```csharp
// Tradicional: Verboso
var activeProducts = products.Where(p => p.IsActive && p.Stock > 0);

// Moderno: Pattern matching
var activeProducts = products.Where(p => p is { IsActive: true, Stock: > 0 });
```

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
│       └── 06-interpolated-strings/
│           ├── README.md          # Explicación detallada
│           ├── Examples/           # Ejemplos prácticos
│           └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 05-performance-optimization/
│   │   ├── README.md          # Introducción a Performance Optimization
│   │   ├── 01-asnotracking-ef-core/
│   │   │   ├── README.md          # Explicación detallada
│   │   │   ├── Examples/           # Ejemplos prácticos
│   │   │   └── BEST_PRACTICES.md  # Mejores prácticas
│   │   └── 02-loading-strategies/
│   │       ├── README.md          # Explicación detallada
│   │       ├── Examples/           # Ejemplos prácticos
│   │       └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 06-aspnet-core/
│   │   ├── README.md          # Introducción a ASP.NET Core
│   │   └── 01-middleware-order/
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
│       └── 05-key-class-concepts/
│           ├── README.md          # Explicación detallada
│           ├── Examples/           # Ejemplos prácticos
│           └── BEST_PRACTICES.md  # Mejores prácticas
│   └── 09-csharp-fundamentals/
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
│       └── 05-modern-linq-pattern-matching/
│           ├── README.md          # Explicación detallada
│           ├── Examples/           # Ejemplos prácticos
│           └── BEST_PRACTICES.md  # Mejores prácticas
│   ├── 10-angular-integration/
│   │   ├── README.md          # Introducción a Angular Integration
│   │   └── 01-template-driven-vs-reactive-forms/
│   │       ├── README.md          # Explicación detallada
│   │       ├── Examples/           # Ejemplos prácticos
│   │       └── BEST_PRACTICES.md  # Mejores prácticas
│   └── 11-design-patterns/
│       ├── README.md          # Introducción a Design Patterns
│       └── 01-unit-of-work/
│           ├── README.md          # Explicación detallada
│           ├── Examples/           # Ejemplos prácticos
│           └── BEST_PRACTICES.md  # Mejores prácticas
│       ├── README.md          # Introducción a Angular Integration
│       └── 01-template-driven-vs-reactive-forms/
│           ├── README.md          # Explicación detallada
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

