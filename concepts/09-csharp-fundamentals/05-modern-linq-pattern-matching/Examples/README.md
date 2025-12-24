# Ejemplos Prácticos - Modern LINQ with Pattern Matching

Esta carpeta contiene ejemplos ejecutables que demuestran Modern LINQ con Pattern Matching en C#.

## Archivos

### `ModernLinqPatternMatchingExamples.cs`
Demostraciones prácticas de Modern LINQ con Pattern Matching:
- `DemonstrateSimplifiedFiltering()` - Filtrado simplificado con pattern matching
- `DemonstrateImprovedReadability()` - Legibilidad mejorada
- `DemonstrateExtensionMethods()` - Extension methods con pattern matching
- `DemonstrateSwitchExpressions()` - Switch expressions con pattern matching
- `DemonstrateBetterMaintainability()` - Mejor mantenibilidad del código
- `DemonstrateLinqAndAsync()` - Combinación de LINQ y async
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Modern LINQ
```

## Conceptos Clave

- **Pattern Matching**: Especificar condiciones directamente sobre propiedades
- **Simplified Filtering**: Eliminar verificaciones verbosas y múltiples if statements
- **Improved Readability**: Reducir complejidad del código
- **LINQ + Async**: Consultas no bloqueantes con ToListAsync()
- **Better Maintainability**: Menos código = menos errores potenciales

## Ejemplo Básico

```csharp
// ❌ TRADICIONAL: Verboso
var activeProducts = products.Where(p => 
{
    if (p.IsActive && p.Stock > 0)
        return true;
    return false;
});

// ✅ MODERNO: Pattern matching limpio
var activeProducts = products.Where(p => p is { IsActive: true, Stock: > 0 });
```

## Ejemplos Incluidos

### 1. Filtrado Simplificado
```csharp
var activeProducts = products.Where(p => p is { IsActive: true, Stock: > 0 });
```

### 2. Pattern Matching Anidado
```csharp
var validOrders = orders.Where(o => 
    o is { 
        Customer: { IsActive: true }, 
        Total: > 0, 
        Items.Count: > 0 
    });
```

### 3. Extension Methods
```csharp
public static IEnumerable<Product> GetActiveProducts(
    this IEnumerable<Product> products)
{
    return products.Where(p => p is { IsActive: true, Stock: > 0 });
}
```

### 4. Switch Expressions
```csharp
var status = product switch
{
    { IsActive: true, Stock: > 0 } => "Available",
    { IsActive: true, Stock: 0 } => "Out of Stock",
    { IsActive: false } => "Inactive",
    _ => "Unknown"
};
```

### 5. LINQ + Async
```csharp
public static async Task<List<Product>> GetProductsByCategoryAsync(
    this IQueryable<Product> products, 
    string category)
{
    return await products
        .Where(p => p.Category == category)
        .OrderByDescending(p => p.LastUpdated)
        .ToListAsync();
}
```

## Notas

- Los ejemplos muestran comparaciones lado a lado entre código tradicional y moderno
- Se demuestra cómo pattern matching simplifica el código
- Se incluyen ejemplos de extension methods reutilizables
- Se explica la combinación de LINQ con async para mejor performance

