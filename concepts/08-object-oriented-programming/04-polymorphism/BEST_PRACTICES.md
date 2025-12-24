# Mejores Prácticas: Polymorphism (Polimorfismo)

## ✅ Reglas de Oro

### 1. Usa Interfaces para Polimorfismo

```csharp
// ✅ BIEN: Dependencia de interfaz (polimorfismo)
public class CheckoutService
{
    private readonly IPaymentProcessor _processor;
    
    public CheckoutService(IPaymentProcessor processor)
    {
        _processor = processor; // Puede ser cualquier implementación
    }
}

// ❌ MAL: Dependencia directa de implementación concreta
public class CheckoutService
{
    private readonly CreditCardPaymentProcessor _processor;
    
    public CheckoutService(CreditCardPaymentProcessor processor)
    {
        _processor = processor; // Acoplado a implementación específica
    }
}
```

### 2. Inyecta Dependencias a través del Constructor

```csharp
// ✅ BIEN: Inyección a través de constructor (DI)
public class CheckoutService
{
    private readonly IPaymentProcessor _processor;
    
    public CheckoutService(IPaymentProcessor processor)
    {
        _processor = processor; // Inyectado via DI
    }
}

// ❌ MAL: Crear instancias directamente
public class CheckoutService
{
    private readonly IPaymentProcessor _processor;
    
    public CheckoutService()
    {
        _processor = new CreditCardPaymentProcessor(); // Acoplamiento
    }
}
```

### 3. Implementa Todos los Métodos de la Interfaz

```csharp
// ✅ BIEN: Implementa todos los métodos
public interface IPaymentProcessor
{
    void ProcessPayment(Order order);
    void RefundPayment(Order order);
}

public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order) { }
    public void RefundPayment(Order order) { }
}

// ❌ MAL: Falta implementar métodos
public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order) { }
    // Falta RefundPayment - error de compilación
}
```

## ⚠️ Errores Comunes a Evitar

### 1. No Usar Interfaces para Polimorfismo

```csharp
// ❌ MAL: Dependencia de clase concreta
public class CheckoutService
{
    private readonly CreditCardPaymentProcessor _processor;
    
    public CheckoutService(CreditCardPaymentProcessor processor)
    {
        _processor = processor; // No es polimórfico
    }
}

// ✅ BIEN: Dependencia de interfaz
public class CheckoutService
{
    private readonly IPaymentProcessor _processor;
    
    public CheckoutService(IPaymentProcessor processor)
    {
        _processor = processor; // Polimórfico
    }
}
```

### 2. Crear Instancias Directamente en lugar de DI

```csharp
// ❌ MAL: Crear instancias directamente
public class CheckoutService
{
    private readonly IPaymentProcessor _processor;
    
    public CheckoutService()
    {
        _processor = new CreditCardPaymentProcessor(); // Acoplamiento
    }
}

// ✅ BIEN: Inyectar a través de constructor
public class CheckoutService
{
    private readonly IPaymentProcessor _processor;
    
    public CheckoutService(IPaymentProcessor processor)
    {
        _processor = processor; // Desacoplado
    }
}
```

### 3. No Registrar Servicios en DI Container

```csharp
// ❌ MAL: Servicio no registrado
var app = builder.Build();
app.MapGet("/", (CheckoutService service) => service.Checkout(order));
// Error: CheckoutService no está registrado

// ✅ BIEN: Registrar servicios en DI container
builder.Services.AddScoped<IPaymentProcessor, CreditCardPaymentProcessor>();
builder.Services.AddScoped<CheckoutService>();
```

## 🎯 Casos de Uso Específicos

### 1. Payment Processing con Múltiples Métodos

```csharp
// ✅ BIEN: Polimorfismo para diferentes métodos de pago
// Interface for payment processors
public interface IPaymentProcessor
{
    void ProcessPayment();
}

// First implementation for credit card payments
public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing credit card payment.");
    }
}

// Second implementation for PayPal payments
public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing PayPal payment.");
    }
}

// Checkout service which depends on IPaymentProcessor
public class CheckoutService
{
    private readonly IPaymentProcessor _paymentProcessor;
    
    // Dependency is injected via constructor
    public CheckoutService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }
    
    public void Checkout()
    {
        _paymentProcessor.ProcessPayment();
    }
}
```

### 2. Logging con Múltiples Destinos

```csharp
// ✅ BIEN: Polimorfismo para diferentes destinos de logging
public interface ILogger
{
    void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        File.AppendAllText("log.txt", $"{DateTime.Now}: {message}\n");
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"{DateTime.Now}: {message}");
    }
}

// Service usando DI
public class UserService
{
    private readonly ILogger _logger;
    
    public UserService(ILogger logger)
    {
        _logger = logger;
    }
    
    public void CreateUser(string name)
    {
        _logger.Log($"Creating user: {name}");
    }
}
```

### 3. Data Access con Múltiples Fuentes

```csharp
// ✅ BIEN: Polimorfismo para diferentes fuentes de datos
public interface IRepository<T>
{
    T GetById(int id);
    void Save(T entity);
}

public class SqlRepository<T> : IRepository<T>
{
    public T GetById(int id) { /* SQL implementation */ }
    public void Save(T entity) { /* SQL implementation */ }
}

public class InMemoryRepository<T> : IRepository<T>
{
    public T GetById(int id) { /* In-memory implementation */ }
    public void Save(T entity) { /* In-memory implementation */ }
}
```

## 📊 Polimorfismo: Compile-Time vs Runtime

| Tipo | Nombre | Ejemplo | Cuándo se Resuelve |
|------|--------|---------|-------------------|
| **Compile-Time** | Method Overloading | `Add(int, int)` vs `Add(double, double)` | Tiempo de compilación |
| **Runtime** | Method Overriding | `Animal.MakeSound()` vs `Dog.MakeSound()` | Tiempo de ejecución |

## 🚀 Tips Avanzados

### 1. Strategy Pattern con Polimorfismo

```csharp
// ✅ BIEN: Strategy Pattern usando polimorfismo
public interface ISortingStrategy
{
    void Sort(int[] array);
}

public class QuickSortStrategy : ISortingStrategy
{
    public void Sort(int[] array) { /* Quick sort */ }
}

public class MergeSortStrategy : ISortingStrategy
{
    public void Sort(int[] array) { /* Merge sort */ }
}

public class Sorter
{
    private readonly ISortingStrategy _strategy;
    
    public Sorter(ISortingStrategy strategy)
    {
        _strategy = strategy;
    }
    
    public void SortArray(int[] array)
    {
        _strategy.Sort(array);
    }
}
```

### 2. Factory Pattern con Polimorfismo

```csharp
// ✅ BIEN: Factory Pattern con polimorfismo
public interface IAnimalFactory
{
    Animal CreateAnimal(string type);
}

public class AnimalFactory : IAnimalFactory
{
    public Animal CreateAnimal(string type) => type switch
    {
        "dog" => new Dog(),
        "cat" => new Cat(),
        _ => new Animal()
    };
}
```

### 3. Testing con Mocks

```csharp
// ✅ BIEN: Fácil crear mocks para testing
public class CheckoutServiceTests
{
    [Test]
    public void Checkout_CallsProcessPayment()
    {
        // Arrange
        var mockProcessor = new Mock<IPaymentProcessor>();
        var service = new CheckoutService(mockProcessor.Object);
        var order = new Order();
        
        // Act
        service.Checkout(order);
        
        // Assert
        mockProcessor.Verify(p => p.ProcessPayment(order), Times.Once);
    }
}
```

### 4. Factory Pattern para Selección Dinámica

```csharp
// ✅ BIEN: Factory Pattern con DI para selección dinámica
public void ConfigureServices(IServiceCollection services)
{
    // Register both payment processors
    services.AddTransient<CreditCardPaymentProcessor>();
    services.AddTransient<PayPalPaymentProcessor>();

    // Register factory function for dynamic selection
    services.AddTransient<Func<string, IPaymentProcessor>>(serviceProvider => key =>
    {
        return key switch
        {
            "CreditCard" => serviceProvider.GetService<CreditCardPaymentProcessor>(),
            "PayPal" => serviceProvider.GetService<PayPalPaymentProcessor>(),
            _ => throw new ArgumentException("Invalid payment method")
        };
    });
}

// Usage in controller
public class OrderController
{
    private readonly Func<string, IPaymentProcessor> _paymentProcessorFactory;

    public OrderController(Func<string, IPaymentProcessor> paymentProcessorFactory)
    {
        _paymentProcessorFactory = paymentProcessorFactory;
    }

    public void Checkout(string paymentMethod)
    {
        // Dynamically selecting payment processor based on user input
        var paymentProcessor = _paymentProcessorFactory(paymentMethod);
        paymentProcessor.ProcessPayment();
    }
}
```

### 5. Conditional Registration en DI

```csharp
// ✅ BIEN: Registrar diferentes implementaciones según configuración
if (configuration["PaymentMethod"] == "CreditCard")
{
    builder.Services.AddScoped<IPaymentProcessor, CreditCardPaymentProcessor>();
}
else
{
    builder.Services.AddScoped<IPaymentProcessor, PayPalPaymentProcessor>();
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Polymorphism](https://docs.microsoft.com/dotnet/csharp/fundamentals/object-oriented/polymorphism)
- [Microsoft Docs - Interfaces](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/interfaces)
- [Microsoft Docs - Dependency Injection](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection)

