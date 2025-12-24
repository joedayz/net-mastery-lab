# Mejores Prácticas: Modern LINQ with Pattern Matching

## ✅ Reglas de Oro

### 1. Usar Pattern Matching para Filtros Simples y Expresivos

```csharp
// ✅ BIEN: Pattern matching para condiciones simples y claras
var activeProducts = products.Where(p => p is { IsActive: true, Stock: > 0 });

// ❌ MAL: Múltiples verificaciones verbosas
var activeProducts = products.Where(p => 
{
    if (p.IsActive && p.Stock > 0)
        return true;
    return false;
});
```

### 2. Combinar LINQ y Async para Performance

```csharp
// ✅ BIEN: Async LINQ para consultas de base de datos
public async Task<List<Product>> GetActiveProductsAsync()
{
    return await _context.Products
        .Where(p => p is { IsActive: true, Stock: > 0 })
        .ToListAsync();
}

// ❌ MAL: Bloquear el hilo con operaciones síncronas
public List<Product> GetActiveProducts()
{
    return _context.Products
        .Where(p => p.IsActive && p.Stock > 0)
        .ToList(); // Bloquea el hilo
}
```

### 3. Usar Extension Methods para Reutilización

```csharp
// ✅ BIEN: Extension methods reutilizables con pattern matching
public static class ProductExtensions
{
    public static IEnumerable<Product> GetActiveProducts(
        this IEnumerable<Product> products)
    {
        return products.Where(p => p is { IsActive: true, Stock: > 0 });
    }
}

// Uso
var activeProducts = products.GetActiveProducts();
```

## ⚠️ Errores Comunes a Evitar

### 1. Patterns Demasiado Complejos

```csharp
// ❌ MAL: Pattern demasiado complejo y difícil de leer
var result = items.Where(x => x is { 
    A: { B: { C: { D: true } } },
    E: { F: > 10 },
    G: { H: { I: { J: < 5 } } }
});

// ✅ BIEN: Simplificar o dividir en múltiples pasos
var filtered = items
    .Where(x => x.A?.B?.C?.D == true)
    .Where(x => x.E?.F > 10)
    .Where(x => x.G?.H?.I?.J < 5);
```

### 2. No Usar Async cuando se Debería

```csharp
// ❌ MAL: Operaciones síncronas bloqueantes
public List<Product> GetProducts()
{
    return _context.Products
        .Where(p => p.IsActive)
        .ToList(); // Bloquea el hilo
}

// ✅ BIEN: Usar async para operaciones de I/O
public async Task<List<Product>> GetProductsAsync()
{
    return await _context.Products
        .Where(p => p.IsActive)
        .ToListAsync(); // No bloquea
}
```

### 3. Mezclar Pattern Matching con Lógica Compleja

```csharp
// ❌ MAL: Mezclar pattern matching con lógica compleja
var result = items.Where(x => 
    x is { IsActive: true } && 
    ComplexCalculation(x) > 100 &&
    AnotherComplexCheck(x));

// ✅ BIEN: Separar pattern matching de lógica compleja
var filtered = items
    .Where(x => x is { IsActive: true })
    .Where(x => ComplexCalculation(x) > 100)
    .Where(x => AnotherComplexCheck(x));
```

## 🎯 Casos de Uso Específicos

### 1. Filtrado de Productos Activos

```csharp
// ✅ BIEN: Pattern matching simple y expresivo
public static IEnumerable<Product> GetActiveProducts(
    this IEnumerable<Product> products)
{
    return products.Where(p => p is { IsActive: true, Stock: > 0 });
}

// Uso
var activeProducts = products.GetActiveProducts();
```

### 2. Validación de Pedidos Complejos

```csharp
// ✅ BIEN: Pattern matching anidado para validación compleja
public static IEnumerable<Order> GetValidOrders(
    this IEnumerable<Order> orders)
{
    return orders.Where(o => 
        o is { 
            Customer: { IsActive: true, CreditLimit: > 1000 },
            Total: > 0 and < 10000,
            Items.Count: > 0
        });
}
```

### 3. Switch Expressions con Pattern Matching

```csharp
// ✅ BIEN: Switch expressions para mapeo basado en patterns
public static string GetProductStatus(Product product)
{
    return product switch
    {
        { IsActive: true, Stock: > 0 } => "Available",
        { IsActive: true, Stock: 0 } => "Out of Stock",
        { IsActive: false } => "Inactive",
        _ => "Unknown"
    };
}

// En LINQ
var productsWithStatus = products.Select(p => new
{
    Product = p,
    Status = p switch
    {
        { IsActive: true, Stock: > 0 } => "Available",
        { IsActive: true, Stock: 0 } => "Out of Stock",
        { IsActive: false } => "Inactive",
        _ => "Unknown"
    }
});
```

### 4. Async LINQ con Entity Framework

```csharp
// ✅ BIEN: Async LINQ para consultas de base de datos
public class ProductService
{
    private readonly DbContext _context;
    
    public async Task<List<Product>> GetActiveProductsByCategoryAsync(string category)
    {
        return await _context.Products
            .Where(p => p is { 
                Category: var cat, 
                IsActive: true, 
                Stock: > 0 
            } && cat == category)
            .OrderByDescending(p => p.LastUpdated)
            .ToListAsync();
    }
}
```

## 🚀 Tips Avanzados

### 1. Pattern Matching con Variables

```csharp
// ✅ BIEN: Capturar valores en pattern matching
var products = items.Where(p => 
    p is { 
        Category: var category, 
        IsActive: true 
    } && category.StartsWith("E"))
    .ToList();
```

### 2. Combinar Pattern Matching con Otros Operadores LINQ

```csharp
// ✅ BIEN: Combinar pattern matching con otros operadores
var result = products
    .Where(p => p is { IsActive: true, Stock: > 0 })
    .OrderByDescending(p => p.Price)
    .Take(10)
    .Select(p => new { p.Name, p.Price })
    .ToList();
```

### 3. Performance con IQueryable

```csharp
// ✅ BIEN: Pattern matching simple se traduce bien a SQL
var products = await _context.Products
    .Where(p => p is { IsActive: true, Stock: > 0 })
    .ToListAsync();

// ⚠️ CUIDADO: Patterns complejos pueden requerir evaluación en memoria
var complexProducts = await _context.Products
    .AsEnumerable() // Forzar evaluación en memoria si es necesario
    .Where(p => p is { 
        Category: var cat, 
        IsActive: true 
    } && cat.Contains("Electronics"))
    .ToList();
```

### 4. Null Safety Automático

```csharp
// ✅ BIEN: Pattern matching maneja nulls automáticamente
var validItems = items.Where(i => i is { IsActive: true });

// Equivalente a:
var validItems = items.Where(i => i != null && i.IsActive == true);
```

## 📊 Comparación: Tradicional vs Moderno

| Aspecto | Tradicional | Moderno con Pattern Matching |
|---------|-------------|------------------------------|
| **Legibilidad** | Verboso | Conciso y expresivo |
| **Mantenibilidad** | Múltiples if-else | Expresión única |
| **Null Safety** | Manual | Automático |
| **Performance** | Similar | Similar o mejor |
| **Complejidad** | Alta | Baja |
| **Líneas de Código** | Más | Menos |

## 💡 Cuándo Usar Pattern Matching

### Usa Pattern Matching cuando:
- ✅ Necesitas filtrar objetos basándote en múltiples propiedades
- ✅ Quieres código más legible y expresivo
- ✅ Necesitas null safety automático
- ✅ Quieres reducir complejidad de código

### Evita Pattern Matching cuando:
- ❌ El pattern es demasiado complejo (más de 3-4 niveles de anidación)
- ❌ Necesitas lógica compleja dentro del filtro
- ❌ El código tradicional es más claro para el caso específico

## 📚 Recursos Adicionales

- [Microsoft Docs - Pattern Matching](https://docs.microsoft.com/dotnet/csharp/pattern-matching)
- [Microsoft Docs - LINQ](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq/)
- [Microsoft Docs - Async LINQ](https://docs.microsoft.com/ef/core/querying/async)

