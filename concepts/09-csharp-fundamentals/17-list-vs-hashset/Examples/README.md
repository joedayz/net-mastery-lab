# Ejemplos Prácticos - List vs HashSet

Esta carpeta contiene ejemplos ejecutables que demuestran las diferencias entre List<T> y HashSet<T> en C#.

## Archivos

### `ListVsHashSetExamples.cs`
Demostraciones prácticas de List vs HashSet:
- `DemonstrateList()` - List<T>: Permite duplicados y mantiene orden
- `DemonstrateHashSet()` - HashSet<T>: Elimina duplicados automáticamente
- `DemonstrateVisualComparison()` - Comparación visual con código exacto
- `DemonstrateKeyDifferences()` - Diferencias clave en tabla
- `DemonstratePracticalExamples()` - Ejemplos prácticos
- `DemonstratePerformanceOptimization()` - Optimización de rendimiento
- `DemonstrateCommonMistakes()` - Errores comunes a evitar
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de List vs HashSet
```

## Conceptos Clave

- **List<T>**: Orden y duplicados permitidos
- **HashSet<T>**: Unicidad y rendimiento
- **Duplicados**: List permite, HashSet elimina
- **Orden**: List mantiene, HashSet no garantiza
- **Rendimiento**: List O(n) para búsquedas, HashSet O(1)

## Ejemplo Básico: List

```csharp
var list = new List<string> { "a", "b", "a" };  // Permite duplicados
Console.WriteLine(string.Join(", ", list));  // Output: "a, b, a"
```

## Ejemplo Básico: HashSet

```csharp
var set = new HashSet<string> { "a", "b", "a" };  // Elimina duplicados
Console.WriteLine(string.Join(", ", set));  // Output: "a, b"
```

## Notas

- Los ejemplos muestran claramente las diferencias entre List y HashSet
- Se incluyen errores comunes y cómo evitarlos
- Se explica cuándo usar cada uno según el escenario
- Se demuestra la optimización de rendimiento

## Requisitos

- Conocimientos básicos de C#
- Comprensión de colecciones en C#
- Conocimientos básicos de complejidad algorítmica (O(n), O(1))

