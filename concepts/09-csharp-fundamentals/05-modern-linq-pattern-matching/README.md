# Modern LINQ with Pattern Matching en C# 🔍

## Introducción

LINQ moderno con Pattern Matching en C# combina el poder de las consultas LINQ con las capacidades de pattern matching introducidas en C# 8+, resultando en código más limpio, legible y mantenible.

## 📖 ¿Qué es Pattern Matching en LINQ?

Pattern Matching en LINQ permite especificar condiciones directamente sobre propiedades sin necesidad de declaraciones if verbosas o múltiples verificaciones. En lugar de verificar manualmente cada condición, pattern matching nos permite expresar múltiples restricciones en una sola expresión simple y clara.

## 🎯 Beneficios Clave

### 1. Simplified Data Filtering (Filtrado de Datos Simplificado)

Pattern matching en LINQ permite filtrar objetos basándose en sus propiedades de manera más limpia y legible.

```csharp
// ❌ TRADICIONAL: Múltiples verificaciones verbosas
var activeProducts = products.Where(p => 
{
    if (p.IsActive && p.Stock > 0)
        return true;
    return false;
});

// ✅ MODERNO: Pattern matching limpio y directo
var activeProducts = products.Where(p => p is { IsActive: true, Stock: > 0 });
```

### 2. Improved Readability (Legibilidad Mejorada)

El objetivo del pattern matching es reducir la complejidad del código. Al expresar condiciones directamente en la consulta LINQ, eliminamos la necesidad de condiciones if complejas y anidadas.

```csharp
// ❌ TRADICIONAL: Condiciones anidadas complejas
var validOrders = orders.Where(o => 
{
    if (o.Customer != null)
    {
        if (o.Customer.IsActive)
        {
            if (o.Total > 0 && o.Items.Count > 0)
            {
                return true;
            }
        }
    }
    return false;
});

// ✅ MODERNO: Pattern matching expresivo
var validOrders = orders.Where(o => 
    o is { 
        Customer: { IsActive: true }, 
        Total: > 0, 
        Items.Count: > 0 
    });
```

### 3. Combining LINQ and Async for Performance (Combinando LINQ y Async)

Con C# LINQ, es fácil combinar operaciones asíncronas para consultas de datos no bloqueantes. Cuando consultas una base de datos o un servicio externo, LINQ puede combinarse con métodos async como `ToListAsync()`, haciendo la recuperación de datos más eficiente y responsiva.

```csharp
// ✅ MODERNO: LINQ con async para mejor performance
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

### 4. Better Code Maintainability (Mejor Mantenibilidad)

Pattern matching fomenta código más limpio al eliminar la necesidad de múltiples condiciones if-else. Esto no solo hace tu código más eficiente sino también más fácil de depurar y mantener.

## 💡 Ejemplos Prácticos

### Ejemplo 1: Filtrado Simple con Pattern Matching

```csharp
// Modern LINQ with pattern matching
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

### Ejemplo 2: Pattern Matching Complejo

```csharp
public static IEnumerable<Order> GetValidOrders(
    this IEnumerable<Order> orders)
{
    return orders.Where(o => 
        o is { 
            Status: OrderStatus.Pending or OrderStatus.Processing,
            Customer: { IsActive: true, CreditLimit: > 1000 },
            Total: > 0 and < 10000,
            Items.Count: > 0
        });
}
```

### Ejemplo 3: LINQ Async con Entity Framework

```csharp
public static class ProductExtensions
{
    // Modern LINQ with pattern matching
    public static async Task<List<Product>> GetProductsByCategoryAsync(
        this IQueryable<Product> products, 
        string category)
    {
        return await products
            .Where(p => p.Category == category)
            .OrderByDescending(p => p.LastUpdated)
            .ToListAsync();
    }
    
    // Con pattern matching adicional
    public static async Task<List<Product>> GetActiveProductsByCategoryAsync(
        this IQueryable<Product> products, 
        string category)
    {
        return await products
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

### Ejemplo 4: Pattern Matching con Switch Expressions

```csharp
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

## 🔄 Comparación: Tradicional vs Moderno

### Filtrado de Productos Activos

```csharp
// ❌ TRADICIONAL: Verboso y propenso a errores
var activeProducts = products.Where(p => 
{
    if (p == null) return false;
    if (!p.IsActive) return false;
    if (p.Stock <= 0) return false;
    return true;
});

// ✅ MODERNO: Limpio y expresivo
var activeProducts = products.Where(p => p is { IsActive: true, Stock: > 0 });
```

### Validación de Pedidos

```csharp
// ❌ TRADICIONAL: Múltiples verificaciones
var validOrders = orders.Where(o => 
    o != null && 
    o.Customer != null && 
    o.Customer.IsActive && 
    o.Total > 0 && 
    o.Items != null && 
    o.Items.Count > 0);

// ✅ MODERNO: Pattern matching anidado
var validOrders = orders.Where(o => 
    o is { 
        Customer: { IsActive: true }, 
        Total: > 0, 
        Items.Count: > 0 
    });
```

## 🚀 Combinando LINQ y Async

### Consultas a Base de Datos

```csharp
// ✅ BIEN: Async LINQ para consultas no bloqueantes
public class ProductService
{
    private readonly DbContext _context;
    
    public ProductService(DbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Product>> GetActiveProductsAsync()
    {
        return await _context.Products
            .Where(p => p is { IsActive: true, Stock: > 0 })
            .OrderByDescending(p => p.LastUpdated)
            .ToListAsync();
    }
    
    public async Task<List<Product>> GetProductsByCategoryAsync(string category)
    {
        return await _context.Products
            .Where(p => p.Category == category)
            .OrderByDescending(p => p.LastUpdated)
            .ToListAsync();
    }
}
```

### Extension Methods con Async

```csharp
public static class ProductQueryExtensions
{
    public static async Task<List<Product>> GetActiveProductsAsync(
        this IQueryable<Product> products)
    {
        return await products
            .Where(p => p is { IsActive: true, Stock: > 0 })
            .ToListAsync();
    }
    
    public static async Task<List<Product>> GetProductsByCategoryAsync(
        this IQueryable<Product> products, 
        string category)
    {
        return await products
            .Where(p => p.Category == category)
            .OrderByDescending(p => p.LastUpdated)
            .ToListAsync();
    }
}

// Uso
var activeProducts = await _context.Products.GetActiveProductsAsync();
var categoryProducts = await _context.Products.GetProductsByCategoryAsync("Electronics");
```

## ⚠️ Consideraciones Importantes

### 1. Performance con IQueryable

```csharp
// ✅ BIEN: Pattern matching con IQueryable (se traduce a SQL)
var products = await _context.Products
    .Where(p => p is { IsActive: true, Stock: > 0 })
    .ToListAsync();

// ⚠️ CUIDADO: Pattern matching complejo puede no traducirse bien
// Algunos patterns complejos pueden requerir evaluación en memoria
var complexProducts = await _context.Products
    .AsEnumerable() // Forzar evaluación en memoria si es necesario
    .Where(p => p is { 
        Category: var cat, 
        IsActive: true 
    } && cat.StartsWith("E"))
    .ToList();
```

### 2. Null Safety

```csharp
// ✅ BIEN: Pattern matching maneja nulls automáticamente
var validProducts = products.Where(p => p is { IsActive: true });

// Equivalente a:
var validProducts = products.Where(p => p != null && p.IsActive == true);
```

## 📊 Tabla Comparativa

| Aspecto | Tradicional | Moderno con Pattern Matching |
|---------|-------------|------------------------------|
| **Legibilidad** | Verboso | Conciso y expresivo |
| **Mantenibilidad** | Múltiples if-else | Expresión única |
| **Null Safety** | Manual | Automático |
| **Performance** | Similar | Similar o mejor |
| **Complejidad** | Alta | Baja |

## 💡 Mejores Prácticas

### 1. Usar Pattern Matching para Filtros Simples

```csharp
// ✅ BIEN: Pattern matching para condiciones simples
var activeProducts = products.Where(p => p is { IsActive: true, Stock: > 0 });
```

### 2. Combinar con Async para Performance

```csharp
// ✅ BIEN: Async LINQ para consultas de base de datos
var products = await _context.Products
    .Where(p => p is { IsActive: true })
    .ToListAsync();
```

### 3. Evitar Patterns Demasiado Complejos

```csharp
// ⚠️ CUIDADO: Patterns muy complejos pueden ser difíciles de leer
var result = items.Where(x => x is { 
    A: { B: { C: { D: true } } },
    E: { F: > 10 }
});

// ✅ MEJOR: Simplificar o dividir en múltiples pasos
var filtered = items
    .Where(x => x.A?.B?.C?.D == true)
    .Where(x => x.E?.F > 10);
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Pattern Matching](https://docs.microsoft.com/dotnet/csharp/pattern-matching)
- [Microsoft Docs - LINQ](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq/)
- [Microsoft Docs - Async LINQ](https://docs.microsoft.com/ef/core/querying/async)

