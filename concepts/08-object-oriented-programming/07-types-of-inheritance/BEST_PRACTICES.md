# Mejores Prácticas: Types of Inheritance in .NET Core

## ✅ Reglas de Oro

### 1. Preferir Composición sobre Herencia cuando sea Apropiado

```csharp
// ❌ MAL: Herencia innecesaria
public class OrderService : EmailService
{
    // OrderService no debería heredar de EmailService
    // OrderService no es un tipo de EmailService
}

// ✅ BIEN: Composición
public class OrderService
{
    private readonly IEmailService _emailService;
    
    public OrderService(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    public void SendOrderConfirmation(Order order)
    {
        _emailService.Send(order.CustomerEmail, "Order Confirmation");
    }
}
```

### 2. Usar Interfaces para Contratos Múltiples

```csharp
// ✅ BIEN: Múltiples interfaces para flexibilidad
public class OrderService : IOrderService, IValidatable<Order>, IDisposable
{
    public void ProcessOrder(Order order) { }
    public bool Validate(Order order) => true;
    public void Dispose() { }
}

// Registro en DI Container
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IValidatable<Order>, OrderService>();
```

### 3. Mantener Jerarquías de Herencia Cortas

```csharp
// ❌ MAL: Jerarquía demasiado profunda
public class A { }
public class B : A { }
public class C : B { }
public class D : C { }
public class E : D { } // Demasiado profundo - difícil de mantener

// ✅ BIEN: Jerarquía razonable (máximo 2-3 niveles)
public class BaseEntity { }
public class Order : BaseEntity { }
public class SpecialOrder : Order { } // Máximo 2-3 niveles
```

### 4. Usar Abstract Classes para Comportamiento Común

```csharp
// ✅ BIEN: Abstract class para comportamiento común
public abstract class BaseService
{
    protected readonly ILogger _logger;
    
    protected BaseService(ILogger logger) => _logger = logger;
    
    protected virtual void LogInfo(string message) => _logger.LogInformation(message);
    protected virtual void LogError(string message) => _logger.LogError(message);
}

public class OrderService : BaseService
{
    public OrderService(ILogger<OrderService> logger) : base(logger) { }
    
    public void ProcessOrder(Order order)
    {
        LogInfo($"Processing order {order.Id}");
    }
}
```

## ⚠️ Consideraciones Importantes

### 1. Evitar el Diamond Problem

```csharp
// ❌ MAL: C# no permite herencia múltiple de clases
public class A { }
public class B : A { }
public class C : A { }
public class D : B, C { } // Error: No se puede heredar de múltiples clases

// ✅ BIEN: Usar interfaces para herencia múltiple
public interface IA { }
public interface IB { }
public class D : IA, IB { } // Correcto
```

### 2. No Abusar de la Herencia

```csharp
// ❌ MAL: Herencia para todo
public class OrderService : LoggingService, ValidationService, EmailService
{
    // Demasiadas responsabilidades heredadas
}

// ✅ BIEN: Composición con interfaces
public class OrderService
{
    private readonly ILogger _logger;
    private readonly IValidator<Order> _validator;
    private readonly IEmailService _emailService;
    
    public OrderService(
        ILogger logger,
        IValidator<Order> validator,
        IEmailService emailService)
    {
        _logger = logger;
        _validator = validator;
        _emailService = emailService;
    }
}
```

### 3. Usar Virtual Methods Correctamente

```csharp
// ✅ BIEN: Métodos virtuales para permitir override
public abstract class BaseService
{
    public virtual void Process()
    {
        // Implementación por defecto
        LogInfo("Processing");
    }
}

public class OrderService : BaseService
{
    public override void Process()
    {
        // Implementación específica
        base.Process(); // Llamar a la implementación base si es necesario
        ProcessOrder();
    }
}
```

## 🎯 Casos de Uso Específicos

### 1. Single Inheritance para Base Controllers

```csharp
// ✅ BIEN: Base controller con funcionalidad común
public abstract class BaseController : ControllerBase
{
    protected readonly ILogger _logger;
    
    protected BaseController(ILogger logger)
    {
        _logger = logger;
    }
    
    protected IActionResult HandleError(Exception ex)
    {
        _logger.LogError(ex, "An error occurred");
        return StatusCode(500, new { error = "An error occurred" });
    }
}

[ApiController]
[Route("api/[controller]")]
public class OrdersController : BaseController
{
    public OrdersController(ILogger<OrdersController> logger) : base(logger) { }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        try
        {
            // Lógica específica
            return Ok(new { id });
        }
        catch (Exception ex)
        {
            return HandleError(ex); // Método heredado
        }
    }
}
```

### 2. Multiple Interfaces para Dependency Injection

```csharp
// ✅ BIEN: Múltiples interfaces para DI
public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id);
}

public interface IOrderValidator
{
    bool Validate(Order order);
}

public class OrderService : IOrderRepository, IOrderValidator
{
    public async Task<Order> GetByIdAsync(int id) => await Task.FromResult(new Order());
    public bool Validate(Order order) => order != null;
}

// Registro en DI
builder.Services.AddScoped<IOrderRepository, OrderService>();
builder.Services.AddScoped<IOrderValidator, OrderService>();
```

### 3. Multilevel Inheritance para Servicios en Capas

```csharp
// ✅ BIEN: Servicios en capas con multilevel inheritance
public abstract class BaseService
{
    protected readonly ILogger _logger;
    protected BaseService(ILogger logger) => _logger = logger;
}

public abstract class CrudService<T> : BaseService where T : class
{
    protected CrudService(ILogger logger) : base(logger) { }
    
    public virtual async Task<T> CreateAsync(T entity)
    {
        _logger.LogInformation($"Creating {typeof(T).Name}");
        return await Task.FromResult(entity);
    }
}

public class OrderService : CrudService<Order>
{
    public OrderService(ILogger<OrderService> logger) : base(logger) { }
    
    public override async Task<Order> CreateAsync(Order order)
    {
        // Lógica específica de OrderService
        return await base.CreateAsync(order);
    }
}
```

### 4. Hybrid Inheritance para Entidades

```csharp
// ✅ BIEN: Hybrid inheritance para entidades
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
}

public interface IAuditable
{
    string CreatedBy { get; set; }
    string UpdatedBy { get; set; }
}

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
}

public class Order : BaseEntity, IAuditable, ISoftDeletable
{
    public string OrderNumber { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
```

## 📊 Tabla de Decisión

| Escenario | Tipo de Herencia Recomendado | Razón |
|-----------|------------------------------|-------|
| Funcionalidad común simple | Single Inheritance | Más simple y directo |
| Múltiples contratos | Multiple Interfaces | Flexibilidad y DI |
| Extensión gradual | Multilevel Inheritance | Organización por capas |
| Múltiples clases similares | Hierarchical Inheritance | Compartir comportamiento común |
| Arquitectura compleja | Hybrid Inheritance | Máxima flexibilidad |

## 💡 Pro Tips

### 1. Usar Sealed para Prevenir Herencia No Deseada

```csharp
// ✅ BIEN: Sealed para prevenir herencia
public sealed class OrderService : BaseService
{
    // No se puede heredar de OrderService
}
```

### 2. Usar Protected para Miembros Heredables

```csharp
// ✅ BIEN: Protected para miembros heredables
public abstract class BaseService
{
    protected readonly ILogger _logger; // Accesible en clases derivadas
    
    private readonly string _secret; // Solo accesible en esta clase
}
```

### 3. Documentar Contratos de Herencia

```csharp
// ✅ BIEN: Documentar contratos
/// <summary>
/// Base service class that provides common logging functionality.
/// Derived classes should override Process() to provide specific implementation.
/// </summary>
public abstract class BaseService
{
    /// <summary>
    /// Processes the entity. Must be overridden in derived classes.
    /// </summary>
    public abstract void Process();
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Inheritance](https://docs.microsoft.com/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [Microsoft Docs - Interfaces](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/interfaces)
- [Microsoft Docs - Abstract Classes](https://docs.microsoft.com/dotnet/csharp/fundamentals/object-oriented/inheritance#abstract-classes)
- [SOLID Principles](https://docs.microsoft.com/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#the-dependency-inversion-principle)

