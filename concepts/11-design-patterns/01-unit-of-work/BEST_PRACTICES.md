# Mejores Prácticas: Unit of Work Pattern

## ✅ Reglas de Oro

### 1. Siempre Usar Dependency Injection

```csharp
// ✅ BIEN: Registrar como Scoped en DI container
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// ❌ MAL: Crear instancia directamente
public class OrderService
{
    private readonly UnitOfWork _unitOfWork = new UnitOfWork(context);
}
```

### 2. Implementar Patrones de Disposal Correctos

```csharp
// ✅ BIEN: Implementar IDisposable correctamente
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
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

### 3. Una Sola Llamada a Commit

```csharp
// ✅ BIEN: Agrupar todas las operaciones y llamar CommitAsync() una vez
public async Task CreateOrderAsync(Order order)
{
    _unitOfWork.Orders.Add(order);
    _unitOfWork.Customers.Update(order.Customer);
    
    foreach (var item in order.OrderItems)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
        product.Stock -= item.Quantity;
        _unitOfWork.Products.Update(product);
    }
    
    // Una sola llamada al final
    await _unitOfWork.CommitAsync();
}

// ❌ MAL: Múltiples llamadas a SaveChanges
public async Task CreateOrderAsync(Order order)
{
    _unitOfWork.Orders.Add(order);
    await _unitOfWork.CommitAsync(); // Primera llamada
    
    _unitOfWork.Customers.Update(order.Customer);
    await _unitOfWork.CommitAsync(); // Segunda llamada - MAL
}
```

### 4. Usar Scoped Lifetime

```csharp
// ✅ BIEN: Scoped - una instancia por request HTTP
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ❌ MAL: Singleton - compartiría contexto entre requests
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

// ❌ MAL: Transient - nueva instancia cada vez (puede causar problemas)
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
```

## ⚠️ Errores Comunes a Evitar

### 1. Múltiples Llamadas a SaveChanges

```csharp
// ❌ MAL: Múltiples transacciones separadas
_unitOfWork.Orders.Add(order);
await _unitOfWork.CommitAsync();

_unitOfWork.Customers.Update(customer);
await _unitOfWork.CommitAsync();

// ✅ BIEN: Una sola transacción
_unitOfWork.Orders.Add(order);
_unitOfWork.Customers.Update(customer);
await _unitOfWork.CommitAsync(); // Una sola transacción
```

### 2. No Manejar Errores de Transacción

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
    // Log error
    _logger.LogError(ex, "Failed to save changes");
    
    // Re-lanzar o manejar según necesidad
    throw new BusinessException("Failed to save changes", ex);
}
catch (DbUpdateConcurrencyException ex)
{
    // Manejar conflictos de concurrencia
    throw new ConcurrencyException("Data was modified by another user", ex);
}
```

### 3. Compartir Contexto entre Múltiples Unit of Work

```csharp
// ❌ MAL: Compartir contexto entre múltiples Unit of Work
var context = new ApplicationDbContext(options);
var unitOfWork1 = new UnitOfWork(context);
var unitOfWork2 = new UnitOfWork(context); // Mismo contexto - MAL

// ✅ BIEN: Cada Unit of Work tiene su propio contexto (manejado por DI)
// DI crea una nueva instancia por request
```

### 4. No Implementar IDisposable

```csharp
// ❌ MAL: No implementar disposal
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    // Sin Dispose() - puede causar memory leaks
}

// ✅ BIEN: Implementar IDisposable
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    
    public void Dispose()
    {
        _context.Dispose();
    }
}
```

## 🎯 Casos de Uso Específicos

### 1. Operación Transaccional Compleja

```csharp
// ✅ BIEN: Múltiples operaciones como una sola transacción
public async Task ProcessOrderAsync(int orderId)
{
    var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
    order.Status = OrderStatus.Processing;
    
    var customer = await _unitOfWork.Customers.GetByIdAsync(order.CustomerId);
    customer.TotalOrders++;
    
    foreach (var item in order.OrderItems)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
        product.Stock -= item.Quantity;
        _unitOfWork.Products.Update(product);
    }
    
    _unitOfWork.Orders.Update(order);
    _unitOfWork.Customers.Update(customer);
    
    // Una sola transacción guarda todos los cambios
    await _unitOfWork.CommitAsync();
}
```

### 2. Rollback Automático en Caso de Error

```csharp
// ✅ BIEN: Si algo falla, todo se revierte automáticamente
public async Task CreateOrderWithValidationAsync(Order order)
{
    try
    {
        // Validar stock
        foreach (var item in order.OrderItems)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
            if (product.Stock < item.Quantity)
            {
                throw new InsufficientStockException($"Not enough stock for {product.Name}");
            }
        }
        
        // Agregar orden
        _unitOfWork.Orders.Add(order);
        
        // Reducir stock
        foreach (var item in order.OrderItems)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
            product.Stock -= item.Quantity;
            _unitOfWork.Products.Update(product);
        }
        
        // Si CommitAsync falla, todo se revierte
        await _unitOfWork.CommitAsync();
    }
    catch
    {
        // No necesitas rollback manual - EF Core lo hace automáticamente
        throw;
    }
}
```

### 3. Integración con Repository Pattern

```csharp
// ✅ BIEN: Unit of Work coordina múltiples repositorios
public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Order> CreateOrderAsync(CreateOrderDto dto)
    {
        // Usar repositorios a través de Unit of Work
        var customer = await _unitOfWork.Customers.GetByIdAsync(dto.CustomerId);
        if (customer == null)
        {
            throw new NotFoundException("Customer not found");
        }
        
        var order = new Order
        {
            CustomerId = dto.CustomerId,
            OrderDate = DateTime.UtcNow
        };
        
        _unitOfWork.Orders.Add(order);
        await _unitOfWork.CommitAsync();
        
        return order;
    }
}
```

## 🚀 Tips Avanzados

### 1. Usar con TransactionScope para Operaciones Distribuidas

```csharp
// ✅ BIEN: TransactionScope para operaciones distribuidas
public async Task ProcessDistributedOperationAsync()
{
    using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
    try
    {
        // Operaciones en múltiples bases de datos o servicios
        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.CommitAsync();
        
        await _externalService.ProcessPaymentAsync(payment);
        
        transaction.Complete();
    }
    catch
    {
        // Rollback automático
        throw;
    }
}
```

### 2. Lazy Loading de Repositorios

```csharp
// ✅ BIEN: Lazy loading de repositorios
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IOrderRepository? _orders;
    private ICustomerRepository? _customers;

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
}
```

### 3. Manejo de Concurrencia

```csharp
// ✅ BIEN: Manejar conflictos de concurrencia
public async Task UpdateOrderAsync(int orderId, UpdateOrderDto dto)
{
    var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
    if (order == null)
    {
        throw new NotFoundException("Order not found");
    }
    
    // Verificar versión de concurrencia
    if (order.RowVersion != dto.RowVersion)
    {
        throw new ConcurrencyException("Order was modified by another user");
    }
    
    order.Status = dto.Status;
    _unitOfWork.Orders.Update(order);
    
    try
    {
        await _unitOfWork.CommitAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        throw new ConcurrencyException("Order was modified by another user");
    }
}
```

### 4. Testing con Unit of Work

```csharp
// ✅ BIEN: Mock IUnitOfWork para testing
public class OrderServiceTests
{
    [Fact]
    public async Task CreateOrderAsync_ShouldCreateOrder()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockOrderRepo = new Mock<IOrderRepository>();
        
        mockUnitOfWork.Setup(u => u.Orders).Returns(mockOrderRepo.Object);
        mockUnitOfWork.Setup(u => u.CommitAsync()).ReturnsAsync(1);
        
        var service = new OrderService(mockUnitOfWork.Object);
        
        // Act
        var order = await service.CreateOrderAsync(new CreateOrderDto());
        
        // Assert
        mockOrderRepo.Verify(r => r.Add(It.IsAny<Order>()), Times.Once);
        mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
    }
}
```

## 📊 Comparación: Con vs Sin Unit of Work

| Aspecto | Sin Unit of Work | Con Unit of Work |
|---------|------------------|------------------|
| **Transacciones** | Múltiples SaveChanges() | Una sola CommitAsync() |
| **Consistencia** | Difícil de garantizar | Garantizada |
| **Código** | Disperso | Centralizado |
| **Testing** | Difícil | Fácil (mock IUnitOfWork) |
| **Mantenibilidad** | Baja | Alta |

## 📚 Recursos Adicionales

- [Microsoft Docs - DbContext](https://docs.microsoft.com/ef/core/dbcontext/)
- [Microsoft Docs - Transactions](https://docs.microsoft.com/ef/core/saving/transactions)
- [Martin Fowler - Unit of Work](https://martinfowler.com/eaaCatalog/unitOfWork.html)
- [Microsoft Docs - Dependency Injection](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection)

