# Mejores Prácticas: Loading Strategies

## ✅ Reglas de Oro

### 1. Preferir Explicit Loading para Control Preciso

```csharp
// ✅ BIEN: Explicit Loading con control granular
var order = await _context.Orders
    .FirstOrDefaultAsync(o => o.Id == orderId);

if (order != null && needsCustomerDetails)
{
    await _context.Entry(order)
        .Reference(o => o.Customer)
        .LoadAsync();
}

// ❌ MAL: Lazy Loading sin control (puede causar N+1)
var order = await _context.Orders
    .FirstOrDefaultAsync(o => o.Id == orderId);
var customer = order.Customer; // Consulta inesperada
```

### 2. Usar Eager Loading cuando Sepas que Necesitas los Datos

```csharp
// ✅ BIEN: Eager Loading cuando siempre necesitas los datos relacionados
var orders = await _context.Orders
    .Include(o => o.Customer)
    .Include(o => o.OrderItems)
    .ToListAsync();

// ❌ MAL: Lazy Loading cuando siempre necesitas los datos
var orders = await _context.Orders.ToListAsync();
foreach (var order in orders)
{
    var customer = order.Customer; // N+1 problem
}
```

### 3. Evitar N+1 con Eager o Explicit Loading

```csharp
// ❌ MAL: N+1 con Lazy Loading
var orders = await _context.Orders.ToListAsync(); // 1 consulta
foreach (var order in orders)
{
    var customer = order.Customer; // N consultas
}

// ✅ BIEN: Eager Loading evita N+1
var orders = await _context.Orders
    .Include(o => o.Customer)
    .ToListAsync(); // 1 consulta con JOIN

// ✅ BIEN: Explicit Loading evita N+1
var orders = await _context.Orders.ToListAsync(); // 1 consulta
var customerIds = orders.Select(o => o.CustomerId).Distinct();
var customers = await _context.Customers
    .Where(c => customerIds.Contains(c.Id))
    .ToListAsync(); // 1 consulta adicional
```

## ⚠️ Errores Comunes a Evitar

### 1. N+1 Problem con Lazy Loading

```csharp
// ❌ MAL: Problema N+1
var orders = await _context.Orders.ToListAsync(); // 1 consulta

foreach (var order in orders)
{
    Console.WriteLine(order.Customer.Name); // N consultas
    foreach (var item in order.OrderItems) // Más consultas
    {
        Console.WriteLine(item.Product.Name);
    }
}
// Total: 1 + N + M consultas

// ✅ BIEN: Eager Loading
var orders = await _context.Orders
    .Include(o => o.Customer)
    .Include(o => o.OrderItems)
        .ThenInclude(oi => oi.Product)
    .ToListAsync(); // 1 consulta con JOINs
```

### 2. Eager Loading Excesivo

```csharp
// ❌ MAL: Cargar demasiados datos innecesarios
var orders = await _context.Orders
    .Include(o => o.Customer)
        .ThenInclude(c => c.Address)
            .ThenInclude(a => a.Country)
    .Include(o => o.OrderItems)
        .ThenInclude(oi => oi.Product)
            .ThenInclude(p => p.Category)
                .ThenInclude(c => c.ParentCategory)
    .ToListAsync();
// Consulta SQL muy compleja y lenta

// ✅ BIEN: Cargar solo lo necesario
var orders = await _context.Orders
    .Include(o => o.Customer)
    .Include(o => o.OrderItems)
        .ThenInclude(oi => oi.Product)
    .ToListAsync();
```

### 3. No Considerar el Contexto de Uso

```csharp
// ❌ MAL: Usar la misma estrategia para todo
// Siempre usar Eager Loading sin considerar si se necesitan los datos

// ✅ BIEN: Elegir estrategia según el caso
public async Task<Order> GetOrderForDisplayAsync(int id)
{
    // Eager Loading: Dashboard necesita todos los datos
    return await _context.Orders
        .Include(o => o.Customer)
        .Include(o => o.OrderItems)
        .FirstOrDefaultAsync(o => o.Id == id);
}

public async Task<Order> GetOrderForUpdateAsync(int id)
{
    // Explicit Loading: Solo cargar lo necesario
    var order = await _context.Orders
        .FirstOrDefaultAsync(o => o.Id == id);
    
    if (order != null && order.Status == OrderStatus.Pending)
    {
        await _context.Entry(order)
            .Reference(o => o.Customer)
            .LoadAsync();
    }
    
    return order;
}
```

## 🎯 Casos de Uso Específicos

### 1. Dashboard - Eager Loading

```csharp
// ✅ BIEN: Dashboard necesita todos los datos
public async Task<DashboardViewModel> GetDashboardDataAsync()
{
    var orders = await _context.Orders
        .Include(o => o.Customer)
        .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
        .Where(o => o.OrderDate >= DateTime.UtcNow.AddDays(-30))
        .ToListAsync();
    
    return new DashboardViewModel { Orders = orders };
}
```

### 2. API Endpoint - Explicit Loading Condicional

```csharp
// ✅ BIEN: Cargar solo lo necesario según parámetros
public async Task<OrderDto> GetOrderAsync(int id, bool includeCustomer, bool includeItems)
{
    var order = await _context.Orders
        .FirstOrDefaultAsync(o => o.Id == id);
    
    if (order == null) return null;
    
    if (includeCustomer)
    {
        await _context.Entry(order)
            .Reference(o => o.Customer)
            .LoadAsync();
    }
    
    if (includeItems)
    {
        await _context.Entry(order)
            .Collection(o => o.OrderItems)
            .LoadAsync();
    }
    
    return MapToDto(order);
}
```

### 3. Lista Simple - Sin Cargar Relaciones

```csharp
// ✅ BIEN: Solo datos básicos para lista
public async Task<List<OrderSummaryDto>> GetOrderSummariesAsync()
{
    return await _context.Orders
        .Select(o => new OrderSummaryDto
        {
            Id = o.Id,
            OrderDate = o.OrderDate,
            Total = o.Total,
            CustomerName = o.Customer.Name // Proyección, no carga relación completa
        })
        .ToListAsync();
}
```

### 4. Explicit Loading con Filtros

```csharp
// ✅ BIEN: Cargar con condiciones específicas
public async Task<Order> GetOrderWithActiveItemsAsync(int id)
{
    var order = await _context.Orders
        .FirstOrDefaultAsync(o => o.Id == id);
    
    if (order != null)
    {
        // Solo cargar OrderItems activos
        await _context.Entry(order)
            .Collection(o => o.OrderItems)
            .Query()
            .Where(oi => oi.IsActive)
            .Include(oi => oi.Product)
            .LoadAsync();
    }
    
    return order;
}
```

## 🚀 Tips Avanzados

### 1. Combinar Eager y Explicit Loading

```csharp
// ✅ BIEN: Combinar estrategias según necesidad
var orders = await _context.Orders
    .Include(o => o.Customer) // Eager: siempre necesario
    .ToListAsync();

// Explicit: cargar condicionalmente
foreach (var order in orders)
{
    if (order.Status == OrderStatus.Pending)
    {
        await _context.Entry(order)
            .Collection(o => o.OrderItems)
            .LoadAsync();
    }
}
```

### 2. Usar Proyección en lugar de Cargar Entidades Completas

```csharp
// ❌ MAL: Cargar entidades completas cuando solo necesitas algunos campos
var orders = await _context.Orders
    .Include(o => o.Customer)
    .ToListAsync();

// ✅ BIEN: Proyección - más eficiente
var orderSummaries = await _context.Orders
    .Select(o => new OrderSummaryDto
    {
        Id = o.Id,
        OrderDate = o.OrderDate,
        CustomerName = o.Customer.Name,
        Total = o.Total
    })
    .ToListAsync();
```

### 3. Batch Loading para Múltiples Entidades

```csharp
// ✅ BIEN: Cargar múltiples relaciones en batch
var orders = await _context.Orders.ToListAsync();
var orderIds = orders.Select(o => o.Id).ToList();

// Cargar todos los OrderItems de una vez
var orderItems = await _context.OrderItems
    .Where(oi => orderIds.Contains(oi.OrderId))
    .Include(oi => oi.Product)
    .ToListAsync();

// Asignar manualmente (si es necesario)
foreach (var order in orders)
{
    order.OrderItems = orderItems
        .Where(oi => oi.OrderId == order.Id)
        .ToList();
}
```

### 4. Deshabilitar Lazy Loading cuando No se Necesita

```csharp
// ✅ BIEN: Deshabilitar Lazy Loading explícitamente
var orders = await _context.Orders
    .AsNoTracking() // También deshabilita lazy loading implícito
    .ToListAsync();

// O en configuración
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
           // No usar .UseLazyLoadingProxies() si no lo necesitas
);
```

## 📊 Tabla de Decisión

| Escenario | Estrategia Recomendada | Razón |
|-----------|------------------------|-------|
| Dashboard con todos los datos | Eager Loading | Siempre necesitas los datos |
| API con parámetros opcionales | Explicit Loading | Control sobre qué cargar |
| Lista simple sin relaciones | Sin carga | Solo datos básicos |
| Datos opcionales raramente usados | Lazy Loading | Ahorra recursos iniciales |
| Operaciones críticas de rendimiento | Explicit Loading | Control preciso |
| Relaciones siempre necesarias | Eager Loading | Evita N+1 |

## 💡 Pro Tips

### 1. Siempre Evaluar Compensaciones

```csharp
// Evalúa: ¿Necesito estos datos siempre o solo a veces?
// Si siempre: Eager Loading
// Si a veces: Explicit Loading
// Si raramente: Lazy Loading (con cuidado)
```

### 2. Monitorear Consultas SQL

```csharp
// ✅ BIEN: Habilitar logging para ver consultas SQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
           .LogTo(Console.WriteLine, LogLevel.Information));
```

### 3. Usar AsNoTracking con Eager Loading

```csharp
// ✅ BIEN: Combinar AsNoTracking con Eager Loading para mejor rendimiento
var orders = await _context.Orders
    .AsNoTracking()
    .Include(o => o.Customer)
    .Include(o => o.OrderItems)
    .ToListAsync();
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Loading Related Data](https://docs.microsoft.com/ef/core/querying/related-data/)
- [Microsoft Docs - Eager Loading](https://docs.microsoft.com/ef/core/querying/related-data/eager)
- [Microsoft Docs - Lazy Loading](https://docs.microsoft.com/ef/core/querying/related-data/lazy)
- [Microsoft Docs - Explicit Loading](https://docs.microsoft.com/ef/core/querying/related-data/explicit)

