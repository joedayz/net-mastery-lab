# Mejores Prácticas: Primary Constructors

## ✅ Reglas de Oro

### 1. Usar para Clases con Dependencias Claras

```csharp
// ✅ BIEN: Service class con dependencias claras
public class UserService(
    IUserRepository userRepository,
    IEmailService emailService,
    ILogger<UserService> logger)
{
    public async Task<User> CreateUserAsync(CreateUserDto dto)
    {
        logger.LogInformation("Creating user {Email}", dto.Email);
        // ...
    }
}

// ❌ MAL: Demasiadas dependencias hacen el código menos legible
public class ComplexService(
    IRepo1 repo1,
    IRepo2 repo2,
    IRepo3 repo3,
    IService1 service1,
    IService2 service2,
    IService3 service3,
    ILogger logger)
{
    // Demasiados parámetros reducen legibilidad
}
```

### 2. Perfecto para Dependency Injection Pattern

```csharp
// ✅ BIEN: DI con Primary Constructor
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

// Registro en DI container
builder.Services.AddScoped<IPaymentGateway, PaymentGateway>();
builder.Services.AddScoped<PaymentProcessor>();
```

### 3. Combinar con Init-Only Properties para Inmutabilidad

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
// Inmutable después de la inicialización
```

### 4. Ideal para Clases Pequeñas y Enfocadas (SOLID)

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

## ⚠️ Errores Comunes a Evitar

### 1. Intentar Modificar Parámetros

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
    
    public void UpdateName(string newName) => Name = newName;
}
```

### 2. Demasiados Parámetros en Primary Constructor

```csharp
// ❌ MAL: Demasiados parámetros reducen legibilidad
public class ComplexService(
    IRepository1 repo1,
    IRepository2 repo2,
    IRepository3 repo3,
    IService1 service1,
    IService2 service2,
    IService3 service3,
    IConfiguration config,
    ILogger logger)
{
    // Difícil de leer y mantener
}

// ✅ BIEN: Agrupar dependencias relacionadas
public class ServiceDependencies
{
    public IRepository1 Repo1 { get; }
    public IRepository2 Repo2 { get; }
    public IRepository3 Repo3 { get; }
    // ...
}

public class ComplexService(ServiceDependencies dependencies)
{
    // Más legible y mantenible
}
```

### 3. Usar en Clases Muy Complejas

```csharp
// ⚠️ CUIDADO: Para clases muy complejas, puede ser menos legible
public class ComplexBusinessLogic(
    IRepository repo,
    IService service,
    ILogger logger)
{
    // Si la clase tiene mucha lógica compleja,
    // puede ser mejor usar constructor tradicional
    // para mayor claridad
}

// ✅ MEJOR: Considerar si Primary Constructor es apropiado
// para clases con lógica muy compleja
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

### 2. Repository Pattern

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

### 3. Value Objects (DDD)

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
    
    public override bool Equals(object? obj) =>
        obj is Money other && amount == other.amount && currency == other.currency;
    
    public override int GetHashCode() => HashCode.Combine(amount, currency);
}
```

### 4. Configuration Classes

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

### 5. Factory Classes

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

### 6. Validator Classes

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

## 🚀 Tips Avanzados

### 1. Combinar con Record Types

```csharp
// ✅ BIEN: Record con Primary Constructor para máxima inmutabilidad
public record Customer(string Name, string Email)
{
    public string Greeting() => $"Hello {Name}!";
    public void SendEmail() => Console.WriteLine($"Sending to {Email}");
}

// Uso con with expression
var customer = new Customer("John Doe", "john@example.com");
var updated = customer with { Email = "newemail@example.com" };
```

### 2. Usar con Expression Bodies

```csharp
// ✅ BIEN: Primary Constructor + Expression bodies = código muy conciso
public class Point(int x, int y)
{
    public int X => x;
    public int Y => y;
    public double Distance => Math.Sqrt(x * x + y * y);
    public Point Move(int dx, int dy) => new Point(x + dx, y + dy);
}
```

### 3. Primary Constructor con Validation

```csharp
// ✅ BIEN: Validación en Primary Constructor
public class Email(string value)
{
    public string Value => value;
    
    static Email()
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty", nameof(value));
        
        if (!value.Contains("@"))
            throw new ArgumentException("Invalid email format", nameof(value));
    }
}

// ⚠️ NOTA: La validación debe hacerse en métodos estáticos o factory methods
// ya que no puedes poner lógica directamente en el primary constructor
```

### 4. Primary Constructor con Default Parameters

```csharp
// ✅ BIEN: Default parameters en Primary Constructor
public class ApiClient(
    string baseUrl,
    int timeoutSeconds = 30,
    ILogger<ApiClient>? logger = null)
{
    public string BaseUrl => baseUrl;
    public int TimeoutSeconds => timeoutSeconds;
    public ILogger<ApiClient> Logger => logger ?? NullLogger<ApiClient>.Instance;
}
```

## 📊 Tabla de Decisión

| Escenario | Usar Primary Constructor | Razón |
|-----------|--------------------------|-------|
| Service classes con DI | ✅ Sí | Reduce boilerplate significativamente |
| Repository classes | ✅ Sí | Dependencias claras y simples |
| Value Objects (DDD) | ✅ Sí | Objetos inmutables y simples |
| Configuration classes | ✅ Sí | Datos simples y claros |
| Factory classes | ✅ Sí | Dependencias claras |
| Validator classes | ✅ Sí | Clases pequeñas y enfocadas |
| Clases con lógica compleja | ⚠️ Considerar | Puede reducir legibilidad |
| Clases con muchos parámetros (>5) | ❌ No | Mejor agrupar o usar constructor tradicional |
| Clases que necesitan mutabilidad | ⚠️ Considerar | Usar propiedades en lugar de parámetros |

## 💡 Pro Tips

### 1. Siempre Evaluar Legibilidad

```csharp
// Evalúa: ¿El Primary Constructor hace el código más legible?
// Si sí: Úsalo
// Si no: Considera constructor tradicional
```

### 2. Combinar con Otras Características Modernas

```csharp
// ✅ BIEN: Primary Constructor + Record + Init-only properties
public record Product(string Name, decimal Price)
{
    public int Stock { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
```

### 3. Usar para Reducir Boilerplate

```csharp
// El objetivo principal es reducir boilerplate
// Si no reduce significativamente el código, considera alternativas
```

### 4. Considerar Compatibilidad con Versiones Anteriores

```csharp
// Primary Constructors requieren C# 12+
// Asegúrate de que tu proyecto soporte esta versión
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Primary Constructors](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-12#primary-constructors)
- [Microsoft Docs - Classes](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/classes)
- [C# Language Reference](https://docs.microsoft.com/dotnet/csharp/language-reference/)

