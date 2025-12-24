# Unit of Work & Repository Pattern en .NET Core 🔄

## Introducción

Los patrones **Unit of Work** y **Repository** son dos patrones de diseño fundamentales que trabajan juntos para crear una arquitectura limpia, mantenible y escalable en aplicaciones .NET Core. Estos patrones proporcionan una abstracción sobre el acceso a datos y gestionan transacciones de manera eficiente.

## 📌 ¿Qué es el Repository Pattern? 🏗️

El **Repository Pattern** es un patrón de diseño que actúa como un puente entre la base de datos y la lógica de negocio. En lugar de escribir consultas a lo largo de toda la aplicación, los repositorios proporcionan una forma centralizada de interactuar con la base de datos.

### ✅ Beneficios del Repository Pattern

- **Separación de Responsabilidades**: Mantiene la lógica de base de datos separada de la lógica de negocio
- **Reutilización**: Un solo repositorio puede ser reutilizado en diferentes partes de la aplicación
- **Mantenibilidad**: Reduce la dependencia en frameworks ORM y permite migración fácil
- **Testabilidad**: Facilita la creación de mocks y pruebas unitarias

## 🔄 ¿Qué es el Unit of Work Pattern?

El patrón **Unit of Work (UoW)** asegura que múltiples operaciones relacionadas con diferentes entidades se ejecuten como una sola transacción. Esto significa que todas las operaciones tienen éxito o ninguna se confirma en la base de datos.

### ✅ Beneficios del Unit of Work Pattern

- **Asegura Consistencia de Datos**: Previene actualizaciones parciales o corrupción de datos
- **Mejora el Rendimiento**: Reduce llamadas innecesarias a la base de datos agrupando consultas
- **Gestiona Múltiples Repositorios**: Funciona como un wrapper sobre repositorios para coordinar sus acciones
- **Control Transaccional**: Gestiona múltiples cambios de base de datos como una sola unidad


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

## 🎯 ¿Por Qué Usar Unit of Work & Repository Pattern en .NET Core?

### ✅ Mejora la Organización del Código

Separa responsabilidades, haciendo el código más limpio y mantenible.

```csharp
// ✅ BIEN: Separación clara de responsabilidades
public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task ProcessOrderAsync(int orderId)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
        // Lógica de negocio aquí
        await _unitOfWork.CommitAsync();
    }
}
```

### ✅ Mejora la Testabilidad

Facilita escribir pruebas unitarias para la lógica de negocio.

```csharp
// ✅ BIEN: Fácil de mockear para pruebas
[Fact]
public async Task ProcessOrder_ShouldSucceed()
{
    // Arrange
    var mockUnitOfWork = new Mock<IUnitOfWork>();
    var mockOrderRepo = new Mock<IOrderRepository>();
    
    mockUnitOfWork.Setup(u => u.Orders).Returns(mockOrderRepo.Object);
    mockOrderRepo.Setup(r => r.GetByIdAsync(1))
        .ReturnsAsync(new Order { Id = 1 });
    
    var service = new OrderService(mockUnitOfWork.Object);
    
    // Act
    await service.ProcessOrderAsync(1);
    
    // Assert
    mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
}
```

### ✅ Simplifica las Interacciones con la Base de Datos

Reduce código boilerplate y mejora la mantenibilidad.

```csharp
// ❌ MAL: Acceso directo a DbContext en múltiples lugares
public class OrderController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync(); // Múltiples SaveChanges
        return Ok(order);
    }
}

// ✅ BIEN: Usar Unit of Work & Repository
public class OrderController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        _unitOfWork.Orders.Add(order);
        await _unitOfWork.CommitAsync(); // Una sola transacción
        return Ok(order);
    }
}
```

### ✅ Asegura Consistencia de Datos

Previene transacciones incompletas o datos corruptos.

```csharp
// ✅ BIEN: Transacción atómica con Unit of Work
public async Task TransferFundsAsync(int fromAccountId, int toAccountId, decimal amount)
{
    var fromAccount = await _unitOfWork.Accounts.GetByIdAsync(fromAccountId);
    var toAccount = await _unitOfWork.Accounts.GetByIdAsync(toAccountId);

    fromAccount.Balance -= amount;
    toAccount.Balance += amount;

    _unitOfWork.Accounts.Update(fromAccount);
    _unitOfWork.Accounts.Update(toAccount);

    // Todo o nada - si falla, nada se guarda
    await _unitOfWork.CommitAsync();
}
```

## 💡 Comparación de Patrones

### 1️⃣ Acceso Directo a ORM

```
Controller → ORM → Database
```

**Ventajas:**
- Simple y directo
- Menos abstracción

**Desventajas:**
- Lógica de base de datos dispersa
- Difícil de testear
- Múltiples llamadas SaveChanges()

### 2️⃣ Repository Pattern

```
Controller → Repository → ORM → Database
```

**Ventajas:**
- Abstracción sobre acceso a datos
- Más fácil de testear
- Centraliza lógica de base de datos

**Desventajas:**
- Múltiples SaveChanges() si hay varios repositorios
- No garantiza transacciones atómicas entre repositorios

### 3️⃣ Repository + Unit of Work Pattern ⭐

```
Controller → Unit of Work → Repository → ORM → Database
```

**Ventajas:**
- Abstracción completa
- Transacciones atómicas
- Fácil de testear
- Mejor rendimiento (una sola transacción)
- Consistencia de datos garantizada

**Desventajas:**
- Más complejidad inicial
- Más código para mantener

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

