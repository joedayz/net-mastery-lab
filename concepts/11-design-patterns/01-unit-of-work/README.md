# Unit of Work Pattern en .NET Core 🔄

## Introducción

El patrón **Unit of Work** es un patrón de diseño poderoso que gestiona transacciones de base de datos y asegura consistencia de datos en aplicaciones .NET. Piensa en él como un gestor de transacciones que coordina todas tus operaciones de base de datos.

## 🎯 ¿Qué es el Unit of Work Pattern?

El patrón Unit of Work mantiene una lista de objetos afectados por una transacción de negocio y coordina la escritura de cambios y la resolución de problemas de concurrencia. En lugar de hacer múltiples llamadas a `SaveChanges()` en Entity Framework, agrupas todas las operaciones y las ejecutas como una sola unidad transaccional.

## 🌟 Beneficios Clave

### 1. Transaction Control (Control de Transacciones)
Gestiona múltiples cambios de base de datos como una sola unidad.

### 2. Code Organization (Organización del Código)
Centraliza la lógica de gestión de transacciones.

### 3. Data Consistency (Consistencia de Datos)
Asegura operaciones de todo-o-nada (all-or-nothing).

### 4. Performance (Rendimiento)
Reduce los viajes de ida y vuelta a la base de datos.

### 5. Maintainability (Mantenibilidad)
Hace el código más limpio y mantenible.

## 🛠️ Componentes Principales

### 1. Unit of Work Interface

```csharp
public interface IUnitOfWork : IDisposable
{
    IOrderRepository Orders { get; }
    ICustomerRepository Customers { get; }
    IProductRepository Products { get; }
    
    Task<int> CommitAsync();
    int Commit();
}
```

### 2. Repositories (Repositorios)
Manejan operaciones de datos específicas de entidades.

```csharp
public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(int id);
    Task<IEnumerable<Order>> GetAllAsync();
    void Add(Order order);
    void Update(Order order);
    void Remove(Order order);
}
```

### 3. Database Context
La implementación real en Entity Framework.

```csharp
public class ApplicationDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
```

### 4. Transaction Scope
Gestiona el límite de las operaciones de base de datos.

## 💡 Implementación Práctica

### Implementación Completa del Unit of Work

```csharp
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IOrderRepository? _orders;
    private ICustomerRepository? _customers;
    private IProductRepository? _products;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IOrderRepository Orders
    {
        get
        {
            _orders ??= new OrderRepository(_context);
            return _orders;
        }
    }

    public ICustomerRepository Customers
    {
        get
        {
            _customers ??= new CustomerRepository(_context);
            return _customers;
        }
    }

    public IProductRepository Products
    {
        get
        {
            _products ??= new ProductRepository(_context);
            return _products;
        }
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public int Commit()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
```

### Repository Implementation

```csharp
public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }

    public void Remove(Order order)
    {
        _context.Orders.Remove(order);
    }
}
```

### Uso con Dependency Injection

```csharp
// Program.cs o Startup.cs
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
```

### Uso en Servicios

```csharp
public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Order> CreateOrderAsync(int customerId, List<int> productIds)
    {
        // Obtener cliente
        var customer = await _unitOfWork.Customers.GetByIdAsync(customerId);
        if (customer == null)
        {
            throw new NotFoundException("Customer not found");
        }

        // Crear orden
        var order = new Order
        {
            CustomerId = customerId,
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.Pending
        };

        // Agregar productos a la orden
        foreach (var productId in productIds)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
            {
                throw new NotFoundException($"Product {productId} not found");
            }

            order.OrderItems.Add(new OrderItem
            {
                ProductId = productId,
                Quantity = 1,
                Price = product.Price
            });
        }

        // Agregar orden
        _unitOfWork.Orders.Add(order);

        // Guardar todos los cambios como una sola transacción
        await _unitOfWork.CommitAsync();

        return order;
    }
}
```

## 🎯 Cuándo Usar Unit of Work

### Usa Unit of Work cuando:
- ✅ Transacciones de negocio complejas
- ✅ Múltiples actualizaciones de tablas
- ✅ La consistencia de datos es crucial
- ✅ Múltiples operaciones de repositorio
- ✅ Necesitas garantizar atomicidad

### Ejemplo: Operación Compleja

```csharp
public async Task ProcessOrderAsync(int orderId)
{
    // Todas estas operaciones se ejecutan como una sola transacción
    var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
    order.Status = OrderStatus.Processing;
    
    var customer = await _unitOfWork.Customers.GetByIdAsync(order.CustomerId);
    customer.TotalOrders++;
    
    foreach (var item in order.OrderItems)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
        product.Stock -= item.Quantity;
        product.LastUpdated = DateTime.UtcNow;
        _unitOfWork.Products.Update(product);
    }
    
    _unitOfWork.Orders.Update(order);
    _unitOfWork.Customers.Update(customer);
    
    // Una sola llamada guarda todos los cambios
    await _unitOfWork.CommitAsync();
}
```

## 💡 Mejores Prácticas

### 1. Siempre Usar Dependency Injection

```csharp
// ✅ BIEN: Inyectar IUnitOfWork
public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}

// ❌ MAL: Crear instancia directamente
public class OrderService
{
    private readonly UnitOfWork _unitOfWork = new UnitOfWork(context);
}
```

### 2. Implementar Patrones de Disposal Correctos

```csharp
// ✅ BIEN: Implementar IDisposable
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
```

### 3. Considerar Operaciones Async

```csharp
// ✅ BIEN: Usar métodos async
public async Task<int> CommitAsync()
{
    return await _context.SaveChangesAsync();
}

// ⚠️ CUIDADO: Evitar bloquear async
public int Commit()
{
    return _context.SaveChanges(); // Solo para casos síncronos necesarios
}
```

### 4. Mantener el Scope Enfocado

```csharp
// ✅ BIEN: Scope por request (Scoped)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ❌ MAL: Singleton (compartiría contexto entre requests)
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
```

### 5. Usar con Repository Pattern

```csharp
// ✅ BIEN: Unit of Work coordina múltiples repositorios
public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public async Task CreateOrderAsync(Order order)
    {
        _unitOfWork.Orders.Add(order);
        _unitOfWork.Customers.Update(order.Customer);
        await _unitOfWork.CommitAsync();
    }
}
```

## ⚠️ Errores Comunes a Evitar

### 1. No Usar Dependency Injection

```csharp
// ❌ MAL: Crear instancia directamente
var unitOfWork = new UnitOfWork(context);

// ✅ BIEN: Inyectar a través de constructor
public OrderService(IUnitOfWork unitOfWork) { }
```

### 2. Múltiples Llamadas a SaveChanges

```csharp
// ❌ MAL: Múltiples llamadas a SaveChanges
_unitOfWork.Orders.Add(order);
await _unitOfWork.CommitAsync(); // Primera llamada

_unitOfWork.Customers.Update(customer);
await _unitOfWork.CommitAsync(); // Segunda llamada

// ✅ BIEN: Una sola llamada al final
_unitOfWork.Orders.Add(order);
_unitOfWork.Customers.Update(customer);
await _unitOfWork.CommitAsync(); // Una sola transacción
```

### 3. No Manejar Errores de Transacción

```csharp
// ❌ MAL: No manejar errores
await _unitOfWork.CommitAsync();

// ✅ BIEN: Manejar errores apropiadamente
try
{
    await _unitOfWork.CommitAsync();
}
catch (DbUpdateException ex)
{
    // Manejar errores de base de datos
    throw new BusinessException("Failed to save changes", ex);
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - DbContext](https://docs.microsoft.com/ef/core/dbcontext/)
- [Microsoft Docs - Transactions](https://docs.microsoft.com/ef/core/saving/transactions)
- [Martin Fowler - Unit of Work](https://martinfowler.com/eaaCatalog/unitOfWork.html)

