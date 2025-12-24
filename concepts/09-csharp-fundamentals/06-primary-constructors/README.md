# Primary Constructors en C# ✨

## Introducción

¡Di adiós al boilerplate de constructores! Los **Primary Constructors** en C# 12+ permiten reducir el código hasta en un 50% mientras mantienes la funcionalidad. Los parámetros están automáticamente disponibles en toda la clase, haciendo el código más limpio y expresivo.

## 🎯 ¿Qué son los Primary Constructors?

Los Primary Constructors permiten definir parámetros directamente en la declaración de la clase, eliminando la necesidad de campos privados explícitos y cuerpos de constructor verbosos. Los parámetros se convierten automáticamente en campos disponibles en toda la clase.

## ✨ Por Qué es un Cambio de Juego

### 1. Reduce el Código en un 50%

```csharp
// ❌ ANTES: Código verboso con constructor tradicional
public class Customer
{
    private readonly string _name;
    private readonly string _email;
    
    public Customer(string name, string email)
    {
        _name = name;
        _email = email;
    }
    
    public string Greeting() => $"Hello {_name}!";
    public void SendEmail() => Console.WriteLine($"Sending to {_email}");
}

// ✅ DESPUÉS: Primary Constructor - mucho más conciso
public class Customer(string name, string email)
{
    public string Greeting() => $"Hello {name}!";
    public void SendEmail() => Console.WriteLine($"Sending to {email}");
}
```

### 2. Parámetros Automáticamente Disponibles

Los parámetros del primary constructor están disponibles en toda la clase sin necesidad de declararlos como campos.

```csharp
public class Customer(string name, string email)
{
    // name y email están disponibles directamente
    public string DisplayName => name.ToUpper();
    public bool IsValid => !string.IsNullOrEmpty(email);
    
    public string Greeting() => $"Hello {name}!";
}
```

### 3. Perfecto para Domain-Driven Design (DDD)

```csharp
// ✅ BIEN: Primary Constructor para entidades DDD
public class Order(int orderId, int customerId, decimal total)
{
    public int OrderId => orderId;
    public int CustomerId => customerId;
    public decimal Total => total;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    
    public bool CanBeCancelled() => Total > 0;
}
```

### 4. Ideal para Clases Centradas en Datos y Objetos Inmutables

```csharp
// ✅ BIEN: Objetos inmutables con Primary Constructor
public class Product(string name, decimal price, int stock)
{
    public string Name => name;
    public decimal Price => price;
    public int Stock => stock;
    
    public Product WithPrice(decimal newPrice) => 
        new Product(name, newPrice, stock);
}
```

### 5. Se Combina Perfectamente con Record Types

```csharp
// ✅ BIEN: Primary Constructor con record para máxima inmutabilidad
public record Customer(string Name, string Email)
{
    public string Greeting() => $"Hello {Name}!";
    public void SendEmail() => Console.WriteLine($"Sending to {Email}");
}

// Uso
var customer = new Customer("John Doe", "john@example.com");
var updated = customer with { Email = "newemail@example.com" };
```

## 🔥 Pro Tip: Primary Constructors para Service Classes

Los Primary Constructors brillan especialmente cuando creas clases de servicio:

```csharp
// ✅ BIEN: Service class con Primary Constructor
public class OrderService(
    IOrderRepository orderRepository,
    IEmailService emailService,
    ILogger<OrderService> logger)
{
    public async Task<Order> CreateOrderAsync(CreateOrderDto dto)
    {
        logger.LogInformation("Creating order for customer {CustomerId}", dto.CustomerId);
        
        var order = new Order(dto.CustomerId, dto.Total);
        await orderRepository.AddAsync(order);
        
        await emailService.SendOrderConfirmationAsync(order);
        
        return order;
    }
}
```

### Comparación: Tradicional vs Primary Constructor

```csharp
// ❌ TRADICIONAL: Mucho boilerplate
public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEmailService _emailService;
    private readonly ILogger<OrderService> _logger;
    
    public OrderService(
        IOrderRepository orderRepository,
        IEmailService emailService,
        ILogger<OrderService> logger)
    {
        _orderRepository = orderRepository;
        _emailService = emailService;
        _logger = logger;
    }
    
    // métodos...
}

// ✅ PRIMARY CONSTRUCTOR: Código limpio y conciso
public class OrderService(
    IOrderRepository orderRepository,
    IEmailService emailService,
    ILogger<OrderService> logger)
{
    public async Task<Order> CreateOrderAsync(CreateOrderDto dto)
    {
        logger.LogInformation("Creating order...");
        // ...
    }
}
```

## 💡 Mejores Prácticas

### 1. Usar para Clases con Dependencias Claras

```csharp
// ✅ BIEN: Dependencias claras en Primary Constructor
public class PaymentProcessor(
    IPaymentGateway gateway,
    ILogger<PaymentProcessor> logger)
{
    public async Task ProcessPaymentAsync(Payment payment)
    {
        logger.LogInformation("Processing payment {PaymentId}", payment.Id);
        await gateway.ProcessAsync(payment);
    }
}
```

### 2. Perfecto para Dependency Injection Pattern

```csharp
// ✅ BIEN: DI con Primary Constructor
public class UserService(
    IUserRepository userRepository,
    IEmailService emailService)
{
    public async Task<User> CreateUserAsync(CreateUserDto dto)
    {
        var user = new User(dto.Name, dto.Email);
        await userRepository.AddAsync(user);
        await emailService.SendWelcomeEmailAsync(user);
        return user;
    }
}

// Registro en DI
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<UserService>();
```

### 3. Combinar con Init-Only Properties para Objetos Inmutables

```csharp
// ✅ BIEN: Primary Constructor + Init-only properties
public class Product(string name, decimal price)
{
    public string Name => name;
    public decimal Price => price;
    public int Stock { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}

// Uso
var product = new Product("Laptop", 999.99m)
{
    Stock = 10
};
```

### 4. Ideal para Clases Pequeñas y Enfocadas siguiendo SOLID

```csharp
// ✅ BIEN: Clase pequeña y enfocada (Single Responsibility)
public class EmailValidator(string email)
{
    public bool IsValid() => 
        !string.IsNullOrEmpty(email) && 
        email.Contains("@") && 
        email.Contains(".");
    
    public string Normalize() => email.Trim().ToLowerInvariant();
}
```

## 🎯 Casos de Uso Específicos

### 1. Service Classes con DI

```csharp
// ✅ BIEN: Service class con múltiples dependencias
public class OrderProcessingService(
    IOrderRepository orderRepository,
    IPaymentService paymentService,
    IInventoryService inventoryService,
    ILogger<OrderProcessingService> logger)
{
    public async Task ProcessOrderAsync(Order order)
    {
        logger.LogInformation("Processing order {OrderId}", order.Id);
        
        await paymentService.ProcessPaymentAsync(order.Payment);
        await inventoryService.ReserveItemsAsync(order.Items);
        await orderRepository.UpdateStatusAsync(order.Id, OrderStatus.Processing);
    }
}
```

### 2. Value Objects (DDD)

```csharp
// ✅ BIEN: Value Object con Primary Constructor
public class Money(decimal amount, string currency)
{
    public decimal Amount => amount;
    public string Currency => currency;
    
    public Money Add(Money other)
    {
        if (currency != other.currency)
            throw new InvalidOperationException("Cannot add different currencies");
        
        return new Money(amount + other.amount, currency);
    }
}
```

### 3. Configuration Classes

```csharp
// ✅ BIEN: Configuration class con Primary Constructor
public class DatabaseOptions(string connectionString, int timeoutSeconds)
{
    public string ConnectionString => connectionString;
    public int TimeoutSeconds => timeoutSeconds;
    public TimeSpan Timeout => TimeSpan.FromSeconds(timeoutSeconds);
}

// Uso
var options = new DatabaseOptions("Server=localhost;Database=MyDb", 30);
```

### 4. Factory Classes

```csharp
// ✅ BIEN: Factory con Primary Constructor
public class OrderFactory(
    IOrderIdGenerator idGenerator,
    IDateTimeProvider dateTimeProvider)
{
    public Order CreateOrder(int customerId, decimal total)
    {
        return new Order(
            idGenerator.Generate(),
            customerId,
            total,
            dateTimeProvider.UtcNow);
    }
}
```

## ⚠️ Consideraciones y Limitaciones

### 1. No Puedes Modificar Parámetros

```csharp
// ❌ MAL: No puedes modificar parámetros del primary constructor
public class Customer(string name, string email)
{
    public void UpdateName(string newName)
    {
        name = newName; // Error: No se puede modificar
    }
}

// ✅ BIEN: Usar propiedades si necesitas mutabilidad
public class Customer(string name, string email)
{
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
}
```

### 2. Parámetros son Capturados, no Campos

```csharp
// ⚠️ CUIDADO: Los parámetros son capturados, no campos reales
public class Customer(string name, string email)
{
    // name y email están disponibles pero no son campos
    // No puedes hacer: private string _name = name;
}
```

### 3. Usar con Cuidado en Clases Complejas

```csharp
// ⚠️ CUIDADO: Para clases muy complejas, puede ser menos legible
public class ComplexService(
    IRepository1 repo1,
    IRepository2 repo2,
    IRepository3 repo3,
    IService1 service1,
    IService2 service2,
    ILogger logger)
{
    // Demasiados parámetros pueden hacer el código menos legible
}

// ✅ MEJOR: Considerar agrupar dependencias relacionadas
public class ComplexService(ServiceDependencies dependencies)
{
    // ...
}
```

## 📊 Comparación: Antes vs Después

| Aspecto | Constructor Tradicional | Primary Constructor |
|---------|------------------------|---------------------|
| **Líneas de Código** | Más (campos + constructor) | Menos (50% reducción) |
| **Legibilidad** | Verboso | Conciso |
| **Boilerplate** | Alto | Mínimo |
| **Disponibilidad** | Campos explícitos | Parámetros automáticos |
| **Ideal Para** | Clases complejas | Clases simples y servicios |

## 💡 Ejemplos Prácticos

### Ejemplo 1: Service Class Completo

```csharp
// ✅ BIEN: Service completo con Primary Constructor
public class UserService(
    IUserRepository userRepository,
    IEmailService emailService,
    IPasswordHasher passwordHasher,
    ILogger<UserService> logger)
{
    public async Task<User> RegisterUserAsync(RegisterUserDto dto)
    {
        logger.LogInformation("Registering user {Email}", dto.Email);
        
        var hashedPassword = passwordHasher.HashPassword(dto.Password);
        var user = new User(dto.Name, dto.Email, hashedPassword);
        
        await userRepository.AddAsync(user);
        await emailService.SendWelcomeEmailAsync(user);
        
        logger.LogInformation("User {UserId} registered successfully", user.Id);
        
        return user;
    }
}
```

### Ejemplo 2: Repository Pattern

```csharp
// ✅ BIEN: Repository con Primary Constructor
public class OrderRepository(
    ApplicationDbContext context,
    ILogger<OrderRepository> logger) : IOrderRepository
{
    public async Task<Order?> GetByIdAsync(int id)
    {
        logger.LogDebug("Fetching order {OrderId}", id);
        return await context.Orders.FindAsync(id);
    }
    
    public async Task AddAsync(Order order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();
        logger.LogInformation("Order {OrderId} added", order.Id);
    }
}
```

### Ejemplo 3: Validator Classes

```csharp
// ✅ BIEN: Validator con Primary Constructor
public class EmailValidator(string email)
{
    public bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        
        return email.Contains("@") && 
               email.Contains(".") && 
               email.Length > 5;
    }
    
    public ValidationResult Validate()
    {
        return IsValid() 
            ? ValidationResult.Success 
            : ValidationResult.Failure("Invalid email format");
    }
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Primary Constructors](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-12#primary-constructors)
- [Microsoft Docs - Classes](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/classes)

