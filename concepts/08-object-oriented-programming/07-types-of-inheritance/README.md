# Types of Inheritance in .NET Core: Building Smarter and Cleaner Code 🔷

## Introducción

La herencia es uno de los pilares fundamentales de la Programación Orientada a Objetos (OOP) en .NET Core. Comprender los diferentes tipos de herencia te permite construir código más inteligente, más limpio y más mantenible. Este tema cubre los cinco tipos principales de herencia y cómo aplicarlos en proyectos .NET Core.

## 🎯 Tipos de Herencia en .NET Core

### 1️⃣ Single Inheritance (Herencia Simple)

Una clase hereda de una clase base única.

🧠 Esta es la forma más simple y común de herencia. Permite que la clase derivada reutilice las propiedades y métodos de la clase base, haciendo el código más modular.

#### Ejemplo Básico

```csharp
// Base class
public class Vehicle
{
    public int Speed { get; set; }
    public string Color { get; set; }
    
    public virtual void Start() => Console.WriteLine("Vehicle started");
}

// Derived class - Single Inheritance
public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    
    public override void Start() => Console.WriteLine("Car started");
}
```

#### ✅ Caso de Uso en .NET Core

Cuando tienes funcionalidad común (como logging o validación) que quieres heredar en múltiples clases de servicio.

```csharp
// Base service class con funcionalidad común
public class BaseService
{
    protected readonly ILogger _logger;
    
    public BaseService(ILogger logger)
    {
        _logger = logger;
    }
    
    protected void LogInfo(string message) => _logger.LogInformation(message);
    protected void LogError(string message) => _logger.LogError(message);
}

// Service class con Single Inheritance
public class OrderService : BaseService
{
    public OrderService(ILogger<OrderService> logger) : base(logger) { }
    
    public void ProcessOrder(Order order)
    {
        LogInfo($"Processing order {order.Id}");
        // Lógica específica de OrderService
    }
}
```

**Características:**
- ✅ Una clase puede heredar de solo una clase base
- ✅ Permite reutilización de código común
- ✅ Facilita el mantenimiento
- ✅ Soporta polimorfismo

---

### 2️⃣ Multiple Inheritance (Herencia Múltiple vía Interfaces)

Una clase implementa múltiples interfaces.

🚫 C# y .NET Core no soportan herencia múltiple de clases para evitar ambigüedad (por ejemplo, el Diamond Problem), pero puedes implementar múltiples interfaces.

#### Ejemplo Básico

```csharp
// Interface 1
public interface ILogger
{
    void Log(string message);
}

// Interface 2
public interface IDisposable
{
    void Dispose();
}

// Class implementing multiple interfaces
public class FileLogger : ILogger, IDisposable
{
    public void Log(string message) => Console.WriteLine($"Log: {message}");
    public void Dispose() => Console.WriteLine("Disposing resources");
}
```

#### ✅ Caso de Uso en .NET Core

Usado extensivamente en Dependency Injection, donde los servicios implementan interfaces como `IService`, `IRepository`, `IValidator`, etc.

```csharp
// Interfaces para Dependency Injection
public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id);
}

public interface IOrderValidator
{
    bool Validate(Order order);
}

public interface IOrderNotifier
{
    Task NotifyAsync(Order order);
}

// Service implementing multiple interfaces
public class OrderService : IOrderRepository, IOrderValidator, IOrderNotifier
{
    public async Task<Order> GetByIdAsync(int id)
    {
        // Implementación de IOrderRepository
        return await Task.FromResult(new Order { Id = id });
    }
    
    public bool Validate(Order order)
    {
        // Implementación de IOrderValidator
        return order != null && order.Id > 0;
    }
    
    public async Task NotifyAsync(Order order)
    {
        // Implementación de IOrderNotifier
        await Task.CompletedTask;
    }
}

// Registro en DI Container
builder.Services.AddScoped<IOrderRepository, OrderService>();
builder.Services.AddScoped<IOrderValidator, OrderService>();
builder.Services.AddScoped<IOrderNotifier, OrderService>();
```

💡 Esto soporta polimorfismo y permite diferentes implementaciones con cambios mínimos de código.

**Características:**
- ✅ Una clase puede implementar múltiples interfaces
- ✅ Evita el Diamond Problem
- ✅ Facilita Dependency Injection
- ✅ Permite polimorfismo flexible

---

### 3️⃣ Multilevel Inheritance (Herencia Multinivel)

Una clase se deriva de una clase que también se deriva de otra clase.

🔗 Esto crea una cadena de herencia — permitiendo extensión paso a paso de características y lógica.

#### Ejemplo Básico

```csharp
// Level 1: Base class
public class Vehicle
{
    public int Speed { get; set; }
    public string Color { get; set; }
    
    public virtual void Start() => Console.WriteLine("Vehicle started");
}

// Level 2: Derived from Vehicle
public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    
    public override void Start() => Console.WriteLine("Car started");
}

// Level 3: Derived from Car
public class ElectricCar : Car
{
    public int BatteryCapacity { get; set; }
    
    public override void Start() => Console.WriteLine("Electric car started silently");
    
    public void Charge() => Console.WriteLine("Charging battery");
}
```

#### ✅ Caso de Uso en .NET Core

Crear clases de servicio en capas o modelos de entidad donde cada nivel agrega lógica de negocio adicional o campos de datos.

```csharp
// Level 1: Base service con funcionalidad común
public abstract class BaseService
{
    protected readonly ILogger _logger;
    
    protected BaseService(ILogger logger)
    {
        _logger = logger;
    }
    
    protected virtual void LogInfo(string message) => _logger.LogInformation(message);
}

// Level 2: Service específico con validación
public abstract class CrudService<T> : BaseService where T : class
{
    protected CrudService(ILogger logger) : base(logger) { }
    
    public virtual async Task<T> CreateAsync(T entity)
    {
        LogInfo($"Creating {typeof(T).Name}");
        // Lógica común de creación
        return await Task.FromResult(entity);
    }
    
    public virtual async Task<T> GetByIdAsync(int id)
    {
        LogInfo($"Getting {typeof(T).Name} with id {id}");
        // Lógica común de obtención
        return await Task.FromResult(default(T));
    }
}

// Level 3: Service específico con lógica adicional
public class OrderService : CrudService<Order>
{
    private readonly IOrderRepository _repository;
    
    public OrderService(ILogger<OrderService> logger, IOrderRepository repository) 
        : base(logger)
    {
        _repository = repository;
    }
    
    public override async Task<Order> CreateAsync(Order order)
    {
        LogInfo($"Creating order {order.Id}");
        // Lógica específica de OrderService
        return await _repository.AddAsync(order);
    }
    
    public async Task ProcessOrderAsync(Order order)
    {
        LogInfo($"Processing order {order.Id}");
        // Lógica adicional específica de OrderService
    }
}
```

**Características:**
- ✅ Crea una jerarquía de clases
- ✅ Permite extensión gradual de funcionalidad
- ✅ Cada nivel agrega características específicas
- ✅ Facilita la organización del código

---

### 4️⃣ Hierarchical Inheritance (Herencia Jerárquica)

Múltiples clases heredan de una sola clase base.

🌐 Un patrón común donde diferentes clases derivadas comparten comportamiento común pero implementan sus propios detalles específicos.

#### Ejemplo Básico

```csharp
// Base class
public class Vehicle
{
    public int Speed { get; set; }
    public string Color { get; set; }
    
    public virtual void Start() => Console.WriteLine("Vehicle started");
    public virtual void Stop() => Console.WriteLine("Vehicle stopped");
}

// Derived class 1
public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    
    public override void Start() => Console.WriteLine("Car started");
}

// Derived class 2
public class Bike : Vehicle
{
    public bool HasBasket { get; set; }
    
    public override void Start() => Console.WriteLine("Bike started");
}

// Derived class 3
public class Truck : Vehicle
{
    public int LoadCapacity { get; set; }
    
    public override void Start() => Console.WriteLine("Truck started");
}
```

#### ✅ Caso de Uso en .NET Core

Clases base de controladores en ASP.NET Core MVC/Web API donde métodos comunes como logging, manejo de excepciones y formateo de respuestas API son heredados.

```csharp
// Base controller con funcionalidad común
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
    
    protected IActionResult OkResponse<T>(T data)
    {
        return Ok(new { success = true, data });
    }
}

// Controller 1: Orders
[ApiController]
[Route("api/[controller]")]
public class OrdersController : BaseController
{
    private readonly IOrderService _orderService;
    
    public OrdersController(ILogger<OrdersController> logger, IOrderService orderService) 
        : base(logger)
    {
        _orderService = orderService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        try
        {
            var order = await _orderService.GetByIdAsync(id);
            return OkResponse(order);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}

// Controller 2: Products
[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IProductService _productService;
    
    public ProductsController(ILogger<ProductsController> logger, IProductService productService) 
        : base(logger)
    {
        _productService = productService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        try
        {
            var product = await _productService.GetByIdAsync(id);
            return OkResponse(product);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}

// Controller 3: Customers
[ApiController]
[Route("api/[controller]")]
public class CustomersController : BaseController
{
    private readonly ICustomerService _customerService;
    
    public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService) 
        : base(logger)
    {
        _customerService = customerService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        try
        {
            var customer = await _customerService.GetByIdAsync(id);
            return OkResponse(customer);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}
```

**Características:**
- ✅ Múltiples clases comparten una clase base común
- ✅ Cada clase derivada puede tener su propia implementación
- ✅ Reduce duplicación de código
- ✅ Facilita el mantenimiento

---

### 5️⃣ Hybrid Inheritance (Herencia Híbrida)

Una combinación de múltiples tipos de herencia, a menudo usando tanto herencia de clases como interfaces.

🔀 Este es un escenario del mundo real en proyectos .NET Core donde una clase hereda de una clase base e implementa múltiples interfaces.

#### Ejemplo Básico

```csharp
// Base class
public class Vehicle
{
    public int Speed { get; set; }
    public string Color { get; set; }
}

// Interface 1
public interface ILogger
{
    void Log(string message);
}

// Interface 2
public interface IDisposable
{
    void Dispose();
}

// Hybrid Inheritance: Class + Multiple Interfaces
public class Car : Vehicle, ILogger, IDisposable
{
    public int NumberOfDoors { get; set; }
    
    public void Log(string message) => Console.WriteLine($"Log: {message}");
    public void Dispose() => Console.WriteLine("Disposing car");
}
```

#### ✅ Caso de Uso en .NET Core

Domain-Driven Design y estructuras de Clean Architecture a menudo usan herencia híbrida en las capas de Application, Infrastructure y Domain.

```csharp
// Base class para entidades
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

// Interface 1: Auditable
public interface IAuditable
{
    string CreatedBy { get; set; }
    string UpdatedBy { get; set; }
}

// Interface 2: Soft Deletable
public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
}

// Interface 3: Repository pattern
public interface IRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}

// Entity con Hybrid Inheritance
public class Order : BaseEntity, IAuditable, ISoftDeletable
{
    public string OrderNumber { get; set; }
    public decimal Total { get; set; }
    
    // IAuditable
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    
    // ISoftDeletable
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}

// Repository con Hybrid Inheritance
public class OrderRepository : BaseRepository<Order>, IRepository<Order>, IDisposable
{
    private readonly DbContext _context;
    
    public OrderRepository(DbContext context) : base(context)
    {
        _context = context;
    }
    
    // Implementación específica de IRepository<Order>
    public async Task<Order> GetByIdAsync(int id)
    {
        return await _context.Set<Order>()
            .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);
    }
    
    // IDisposable
    public void Dispose()
    {
        _context?.Dispose();
    }
}

// Base Repository
public abstract class BaseRepository<T> where T : BaseEntity
{
    protected readonly DbContext _context;
    
    protected BaseRepository(DbContext context)
    {
        _context = context;
    }
    
    public virtual async Task<T> AddAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
```

**Características:**
- ✅ Combina herencia de clase e interfaces
- ✅ Máxima flexibilidad y reutilización
- ✅ Patrón común en arquitecturas empresariales
- ✅ Facilita Dependency Injection

---

## 🎯 Beneficios de Usar Herencia en .NET Core

### ✅ Code Reusability (Reutilización de Código)

La herencia permite reutilizar código común sin duplicación, reduciendo el tamaño del código y facilitando el mantenimiento.

```csharp
// Sin herencia: Código duplicado
public class OrderService
{
    private readonly ILogger _logger;
    public OrderService(ILogger logger) => _logger = logger;
    public void Log(string msg) => _logger.LogInformation(msg);
}

public class ProductService
{
    private readonly ILogger _logger;
    public ProductService(ILogger logger) => _logger = logger;
    public void Log(string msg) => _logger.LogInformation(msg); // Duplicado
}

// Con herencia: Código reutilizado
public abstract class BaseService
{
    protected readonly ILogger _logger;
    protected BaseService(ILogger logger) => _logger = logger;
    protected void Log(string msg) => _logger.LogInformation(msg);
}

public class OrderService : BaseService
{
    public OrderService(ILogger logger) : base(logger) { }
    // Log() está disponible sin duplicación
}
```

### ✅ Maintainability (Mantenibilidad)

Los cambios en la clase base se propagan automáticamente a todas las clases derivadas, facilitando el mantenimiento.

```csharp
// Cambio en BaseService afecta a todas las clases derivadas
public abstract class BaseService
{
    protected void Log(string message)
    {
        // Cambio único: Agregar timestamp
        _logger.LogInformation($"[{DateTime.UtcNow}] {message}");
    }
}

// Todas las clases derivadas automáticamente obtienen el cambio
public class OrderService : BaseService { }
public class ProductService : BaseService { }
public class CustomerService : BaseService { }
```

### ✅ Scalability (Escalabilidad)

La herencia facilita agregar nuevas funcionalidades sin modificar código existente.

```csharp
// Agregar nueva funcionalidad sin modificar código existente
public abstract class BaseService
{
    // Funcionalidad existente
    protected void Log(string message) => _logger.LogInformation(message);
    
    // Nueva funcionalidad agregada
    protected void LogError(string message) => _logger.LogError(message);
    protected void LogWarning(string message) => _logger.LogWarning(message);
}

// Todas las clases derivadas automáticamente obtienen la nueva funcionalidad
```

### ✅ Polymorphism (Polimorfismo)

La herencia permite que objetos de diferentes clases sean tratados de manera uniforme a través de una interfaz común.

```csharp
// Polimorfismo con herencia
public abstract class PaymentProcessor
{
    public abstract Task<bool> ProcessPayment(decimal amount);
}

public class CreditCardProcessor : PaymentProcessor
{
    public override async Task<bool> ProcessPayment(decimal amount)
    {
        // Lógica específica de tarjeta de crédito
        return await Task.FromResult(true);
    }
}

public class PayPalProcessor : PaymentProcessor
{
    public override async Task<bool> ProcessPayment(decimal amount)
    {
        // Lógica específica de PayPal
        return await Task.FromResult(true);
    }
}

// Uso polimórfico
public class PaymentService
{
    public async Task<bool> ProcessPayment(PaymentProcessor processor, decimal amount)
    {
        // Funciona con cualquier PaymentProcessor
        return await processor.ProcessPayment(amount);
    }
}
```

---

## 📊 Comparación de Tipos de Herencia

| Tipo | Descripción | Cuándo Usar | Ejemplo en .NET Core |
|------|------------|-------------|---------------------|
| **Single** | Una clase hereda de una base | Funcionalidad común simple | BaseService → OrderService |
| **Multiple** | Múltiples interfaces | Contratos múltiples, DI | IRepository, IValidator, IDisposable |
| **Multilevel** | Cadena de herencia | Extensión gradual | Vehicle → Car → ElectricCar |
| **Hierarchical** | Múltiples clases de una base | Controllers, Services comunes | BaseController → OrdersController, ProductsController |
| **Hybrid** | Clase + Interfaces | Arquitecturas complejas | BaseEntity + IAuditable + ISoftDeletable |

---

## 💡 Mejores Prácticas

### 1. Preferir Composición sobre Herencia cuando sea Apropiado

```csharp
// ❌ MAL: Herencia innecesaria
public class OrderService : EmailService
{
    // OrderService no debería heredar de EmailService
}

// ✅ BIEN: Composición
public class OrderService
{
    private readonly IEmailService _emailService;
    
    public OrderService(IEmailService emailService)
    {
        _emailService = emailService;
    }
}
```

### 2. Usar Interfaces para Contratos Múltiples

```csharp
// ✅ BIEN: Múltiples interfaces para flexibilidad
public class OrderService : IOrderService, IValidatable<Order>, IDisposable
{
    // Implementa múltiples contratos
}
```

### 3. Mantener Jerarquías de Herencia Cortas

```csharp
// ❌ MAL: Jerarquía demasiado profunda
public class A { }
public class B : A { }
public class C : B { }
public class D : C { }
public class E : D { } // Demasiado profundo

// ✅ BIEN: Jerarquía razonable
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
}
```

---

## 📚 Relación con Otros Conceptos

Este tema está relacionado con:
- **Inheritance with Virtual/Override and DI**: `concepts/08-object-oriented-programming/03-inheritance-virtual-override-di/` (herencia básica)
- **Abstract Class vs Interface**: `concepts/08-object-oriented-programming/06-abstract-class-vs-interface/` (cuándo usar cada uno)
- **Polymorphism**: `concepts/08-object-oriented-programming/04-polymorphism/` (polimorfismo con herencia)

---

## 🎯 Resumen

### ✅ Tipos de Herencia en .NET Core

1. **Single Inheritance**
   - Una clase hereda de una clase base
   - Más simple y común
   - Ideal para funcionalidad común

2. **Multiple Inheritance (via Interfaces)**
   - Una clase implementa múltiples interfaces
   - Evita el Diamond Problem
   - Ideal para Dependency Injection

3. **Multilevel Inheritance**
   - Cadena de herencia (A → B → C)
   - Extensión gradual de funcionalidad
   - Ideal para servicios en capas

4. **Hierarchical Inheritance**
   - Múltiples clases de una base común
   - Compartir comportamiento común
   - Ideal para controllers y services

5. **Hybrid Inheritance**
   - Combinación de clase base + interfaces
   - Máxima flexibilidad
   - Ideal para arquitecturas complejas

### 🚀 Beneficios Generales

- ✅ **Code Reusability**: Reutilización de código sin duplicación
- ✅ **Maintainability**: Cambios centralizados se propagan automáticamente
- ✅ **Scalability**: Fácil agregar nuevas funcionalidades
- ✅ **Polymorphism**: Tratamiento uniforme de objetos diferentes

---

## 📚 Recursos Adicionales

- [Microsoft Docs - Inheritance](https://docs.microsoft.com/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [Microsoft Docs - Interfaces](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/interfaces)
- [Microsoft Docs - Abstract Classes](https://docs.microsoft.com/dotnet/csharp/fundamentals/object-oriented/inheritance#abstract-classes)

