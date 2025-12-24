# Ejemplos Prácticos - Loading Strategies

Esta carpeta contiene ejemplos ejecutables que demuestran Eager, Lazy y Explicit Loading en Entity Framework Core.

## Archivos

### `LoadingStrategiesExamples.cs`
Demostraciones prácticas de Loading Strategies:
- `DemonstrateEagerLoading()` - Eager Loading con Include()
- `DemonstrateLazyLoading()` - Lazy Loading y problema N+1
- `DemonstrateExplicitLoading()` - Explicit Loading con Load()
- `DemonstrateComparison()` - Comparación de las tres estrategias
- `DemonstrateNPlusOneProblem()` - Problema N+1 y cómo evitarlo
- `DemonstrateWhenToUse()` - Cuándo usar cada estrategia
- `DemonstrateWhyExplicitIsPreferred()` - Por qué Explicit Loading es preferido
- `DemonstratePracticalExamples()` - Ejemplos prácticos reales
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Loading Strategies
```

## Conceptos Clave

- **Eager Loading**: Carga datos relacionados inmediatamente con Include()
- **Lazy Loading**: Carga datos cuando se accede a la propiedad
- **Explicit Loading**: Control manual sobre cuándo cargar datos
- **N+1 Problem**: Problema común con Lazy Loading
- **Performance**: Elegir la estrategia correcta mejora significativamente el rendimiento

## Ejemplo Básico: Eager Loading

```csharp
// Eager Loading: Carga todo de una vez
var orders = await _context.Orders
    .Include(o => o.Customer)
    .Include(o => o.OrderItems)
    .ToListAsync();
// 1 consulta SQL con JOINs
```

## Ejemplo Básico: Lazy Loading

```csharp
// Lazy Loading: Carga cuando se accede
var orders = await _context.Orders.ToListAsync(); // 1 consulta
var customer = orders[0].Customer; // Consulta adicional
// Puede causar problema N+1
```

## Ejemplo Básico: Explicit Loading

```csharp
// Explicit Loading: Control manual
var order = await _context.Orders.FirstOrDefaultAsync();
await _context.Entry(order)
    .Reference(o => o.Customer)
    .LoadAsync();
// Consulta adicional solo cuando la necesitas
```

## Comparación

| Estrategia | Cuándo se Carga | Pros | Cons |
|------------|-----------------|------|------|
| **Lazy Loading** | Al acceder propiedad | Ahorra recursos | Problema N+1 |
| **Eager Loading** | Con entidad principal | Eficiente | Consultas grandes |
| **Explicit Loading** | Manualmente activado | Control completo | Más código |

## Notas

- Los ejemplos muestran claramente las diferencias entre estrategias
- Se demuestra el problema N+1 y cómo evitarlo
- Se incluyen ejemplos prácticos de cuándo usar cada estrategia
- Se explica por qué Explicit Loading es preferido para aplicaciones modernas

