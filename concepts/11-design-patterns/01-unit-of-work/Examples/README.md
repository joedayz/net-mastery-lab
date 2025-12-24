# Ejemplos Prácticos - Unit of Work Pattern

Esta carpeta contiene ejemplos que demuestran el patrón Unit of Work en .NET Core.

## Archivos

### `UnitOfWorkExamples.cs`
Demostraciones prácticas del patrón Unit of Work:
- `DemonstrateBasicStructure()` - Estructura básica del patrón
- `DemonstrateImplementation()` - Implementación completa
- `DemonstrateDependencyInjection()` - Integración con DI
- `DemonstrateTransactionalOperation()` - Operaciones transaccionales complejas
- `DemonstrateWhenToUse()` - Cuándo usar el patrón
- `DemonstrateBestPractices()` - Mejores prácticas
- `DemonstrateCommonMistakes()` - Errores comunes a evitar
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Unit of Work
```

## Conceptos Clave

- **Unit of Work**: Gestiona transacciones de base de datos como una unidad
- **Transaction Control**: Control de transacciones centralizado
- **Data Consistency**: Garantiza operaciones all-or-nothing
- **Repository Pattern**: Se usa junto con Repository Pattern
- **Dependency Injection**: Siempre usar DI para inyectar IUnitOfWork

## Ejemplo Básico

```csharp
// Interface
public interface IUnitOfWork : IDisposable
{
    IOrderRepository Orders { get; }
    ICustomerRepository Customers { get; }
    Task<int> CommitAsync();
}

// Implementación
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public IOrderRepository Orders { get; }
    
    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}

// Uso
public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public async Task CreateOrderAsync(Order order)
    {
        _unitOfWork.Orders.Add(order);
        await _unitOfWork.CommitAsync();
    }
}
```

## Ejemplos Incluidos

### 1. Estructura Básica
```csharp
public interface IUnitOfWork : IDisposable
{
    IOrderRepository Orders { get; }
    ICustomerRepository Customers { get; }
    Task<int> CommitAsync();
}
```

### 2. Implementación Completa
```csharp
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public IOrderRepository Orders { get; }
    
    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
```

### 3. Uso con Dependency Injection
```csharp
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
```

### 4. Operación Transaccional
```csharp
public async Task ProcessOrderAsync(int orderId)
{
    _unitOfWork.Orders.Update(order);
    _unitOfWork.Customers.Update(customer);
    await _unitOfWork.CommitAsync(); // Una sola transacción
}
```

## Notas

- Los ejemplos muestran la estructura completa del patrón
- Se demuestra integración con Entity Framework Core
- Se incluyen ejemplos de uso con Dependency Injection
- Se explican mejores prácticas y errores comunes

