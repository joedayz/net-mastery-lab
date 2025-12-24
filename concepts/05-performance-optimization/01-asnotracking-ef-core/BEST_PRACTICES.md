# Mejores Prácticas: Use AsNoTracking() in Entity Framework Core

## ✅ Reglas de Oro

### 1. Siempre usa AsNoTracking() para consultas de solo lectura

```csharp
// ❌ MAL: Tracking innecesario para lectura
var users = context.Users
    .Where(u => u.IsActive)
    .ToList();

// ✅ BIEN: AsNoTracking() para solo lectura
var users = context.Users
    .AsNoTracking()
    .Where(u => u.IsActive)
    .ToList();
```

### 2. Combina AsNoTracking() con Select() para máximo rendimiento

```csharp
// ✅ Máximo rendimiento: AsNoTracking() + Select()
var results = context.Orders
    .AsNoTracking()
    .Where(o => o.Status == "Completed")
    .Select(o => new
    {
        o.OrderId,
        o.OrderDate,
        CustomerName = o.Customer.Name,
        TotalAmount = o.OrderItems.Sum(oi => oi.Price * oi.Quantity)
    })
    .ToList();
```

### 3. Usa AsNoTracking() en métodos de repositorio para lectura

```csharp
public class UserRepository
{
    // ✅ Para operaciones de lectura
    public IEnumerable<User> GetActiveUsers()
    {
        return _context.Users
            .AsNoTracking()
            .Where(u => u.IsActive)
            .ToList();
    }
    
    // ✅ Para operaciones que necesitan modificación
    public User GetUserForUpdate(int id)
    {
        return _context.Users
            .FirstOrDefault(u => u.Id == id); // Sin AsNoTracking()
    }
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Usar AsNoTracking() cuando necesitas modificar entidades

```csharp
// ❌ MAL: Los cambios no serán detectados
var user = context.Users
    .AsNoTracking()
    .FirstOrDefault(u => u.Id == 1);

user.Name = "New Name"; // NO será detectado
context.SaveChanges(); // NO guardará el cambio

// ✅ BIEN: Sin AsNoTracking() para modificaciones
var user = context.Users
    .FirstOrDefault(u => u.Id == 1);

user.Name = "New Name"; // Será detectado
context.SaveChanges(); // Guardará el cambio
```

### 2. Olvidar AsNoTracking() en consultas grandes

```csharp
// ❌ MAL: Puede causar problemas de rendimiento y memoria
var reports = context.Orders
    .Where(o => o.OrderDate >= startDate)
    .ToList(); // Rastrea miles de entidades innecesariamente

// ✅ BIEN: Siempre usa AsNoTracking() para grandes consultas
var reports = context.Orders
    .AsNoTracking()
    .Where(o => o.OrderDate >= startDate)
    .ToList();
```

### 3. Usar AsNoTracking() con relaciones que necesitas modificar después

```csharp
// ⚠️ Cuidado: Si necesitas modificar relaciones después
var order = context.Orders
    .AsNoTracking()
    .Include(o => o.OrderItems)
    .FirstOrDefault(o => o.Id == 1);

// No podrás modificar order.OrderItems y guardar los cambios
```

## 🎯 Casos de Uso Específicos

### 1. Generación de Reportes

```csharp
public class ReportService
{
    public IEnumerable<SalesReport> GetSalesReport(DateTime startDate, DateTime endDate)
    {
        return _context.Orders
            .AsNoTracking()
            .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
            .Select(o => new SalesReport
            {
                OrderId = o.OrderId,
                Date = o.OrderDate,
                Total = o.TotalAmount,
                CustomerName = o.Customer.Name
            })
            .ToList();
    }
}
```

### 2. APIs de Solo Lectura

```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _context.Products
            .AsNoTracking()
            .ToList();
        
        return Ok(products);
    }
}
```

### 3. Visualizaciones y Dashboards

```csharp
public class DashboardService
{
    public DashboardData GetDashboardData()
    {
        return new DashboardData
        {
            TotalUsers = _context.Users
                .AsNoTracking()
                .Count(),
            
            ActiveOrders = _context.Orders
                .AsNoTracking()
                .Where(o => o.Status == "Active")
                .Count(),
            
            RecentSales = _context.Orders
                .AsNoTracking()
                .Where(o => o.OrderDate >= DateTime.Today.AddDays(-7))
                .Sum(o => o.TotalAmount)
        };
    }
}
```

## 📊 Comparación de Rendimiento

| Aspecto | Sin AsNoTracking() | Con AsNoTracking() |
|---------|-------------------|-------------------|
| **Rendimiento** | ❌ Más lento | ✅ Más rápido |
| **Uso de Memoria** | ❌ Mayor | ✅ Menor |
| **Tracking Overhead** | ❌ Sí | ✅ No |
| **Ideal para Lectura** | ❌ No | ✅ Sí |
| **Ideal para Escritura** | ✅ Sí | ❌ No |

## 🚀 Tips Avanzados

### 1. Configuración Global

```csharp
public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configurar NoTracking como comportamiento por defecto
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}

// Luego usa .AsTracking() cuando necesites tracking
var user = context.Users
    .AsTracking()
    .FirstOrDefault(u => u.Id == 1);
```

### 2. Combinar con Proyecciones

```csharp
// ✅ Máximo rendimiento: AsNoTracking() + Select() + proyección anónima
var results = context.Orders
    .AsNoTracking()
    .Where(o => o.Status == "Completed")
    .Select(o => new
    {
        o.Id,
        o.OrderDate,
        Customer = o.Customer.Name,
        Total = o.OrderItems.Sum(oi => oi.Price * oi.Quantity)
    })
    .ToList();
```

### 3. Usar con Include() para Relaciones

```csharp
// ✅ AsNoTracking() también funciona con Include()
var orders = context.Orders
    .AsNoTracking()
    .Include(o => o.Customer)
    .Include(o => o.OrderItems)
    .Where(o => o.OrderDate >= DateTime.Today.AddDays(-30))
    .ToList();
```

## 📚 Recursos Adicionales

- [Microsoft Docs - AsNoTracking](https://docs.microsoft.com/ef/core/querying/tracking)
- [Microsoft Docs - Query Tracking Behavior](https://docs.microsoft.com/ef/core/querying/tracking#no-tracking-queries)
- [Entity Framework Core Performance](https://docs.microsoft.com/ef/core/performance/)
- [Performance Best Practices](https://docs.microsoft.com/ef/core/performance/advanced-performance-topics)

