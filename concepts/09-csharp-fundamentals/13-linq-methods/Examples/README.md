# Ejemplos Prácticos - Métodos LINQ

Esta carpeta contiene ejemplos ejecutables que demuestran todos los métodos LINQ organizados por categorías funcionales.

## Archivos

### `LinqMethodsExamples.cs`
Demostraciones prácticas de Métodos LINQ:
- `DemonstrateFiltering()` - Métodos de filtrado (Where, Take, Skip, TakeWhile, SkipWhile)
- `DemonstrateProjection()` - Métodos de proyección (Select, SelectMany)
- `DemonstrateOrdering()` - Métodos de ordenamiento (OrderBy, ThenBy, Reverse)
- `DemonstrateAggregation()` - Métodos de agregación (Sum, Average, Count, Min, Max, Aggregate)
- `DemonstrateQuantifiers()` - Métodos cuantificadores (All, Any, Contains, SequenceEqual)
- `DemonstrateElementOperations()` - Operaciones de elementos (First, Last, Single, ElementAt)
- `DemonstrateSetOperations()` - Operaciones de conjuntos (Union, Intersect, Except, Concat)
- `DemonstrateConversion()` - Operaciones de conversión (ToArray, ToList, ToDictionary, Cast, OfType)
- `DemonstrateWhyUseLinq()` - Por qué usar LINQ
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Métodos LINQ
```

## Conceptos Clave

- **10 Categorías de Métodos LINQ**: Filtering, Projection, Joining, Ordering, Grouping, Aggregation, Quantifiers, Element, Set, Conversion
- **Más de 50 métodos**: Cada categoría contiene múltiples métodos especializados
- **Sintaxis declarativa**: Código más legible y mantenible
- **Deferred Execution**: Consultas se ejecutan cuando se iteran

## Ejemplo Básico: Filtering

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var evens = numbers.Where(n => n % 2 == 0).ToList();
```

## Ejemplo Básico: Projection

```csharp
var users = new List<User> { /* ... */ };
var names = users.Select(u => u.Name).ToList();
```

## Ejemplo Básico: Aggregation

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var sum = numbers.Sum();
var average = numbers.Average();
```

## Notas

- Los ejemplos muestran claramente las diferencias entre métodos similares
- Se incluyen ejemplos prácticos de cuándo usar cada método
- Se explican las mejores prácticas y errores comunes
- Se demuestra por qué LINQ mejora la legibilidad y mantenibilidad

## Requisitos

- .NET 6.0 o superior
- Conocimientos básicos de C# y colecciones

