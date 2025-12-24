# Ejemplos Prácticos - Primary Constructors

Esta carpeta contiene ejemplos ejecutables que demuestran Primary Constructors en C# 12+.

## Archivos

### `PrimaryConstructorsExamples.cs`
Demostraciones prácticas de Primary Constructors:
- `DemonstrateCodeReduction()` - Comparación antes/después mostrando reducción de código
- `DemonstrateServiceClasses()` - Primary Constructors para service classes con DI
- `DemonstrateWithRecords()` - Combinación con record types
- `DemonstrateDDDEntities()` - Uso en entidades DDD
- `DemonstrateWithInitProperties()` - Combinación con init-only properties
- `DemonstrateBestPractices()` - Mejores prácticas y recomendaciones
- `DemonstrateUseCases()` - Casos de uso específicos
- `DemonstrateConsiderations()` - Consideraciones y limitaciones
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Primary Constructors
```

## Conceptos Clave

- **Primary Constructors**: Parámetros directamente en la declaración de clase
- **Reducción de Código**: Reduce boilerplate hasta en 50%
- **Dependency Injection**: Perfecto para service classes con DI
- **Inmutabilidad**: Ideal para objetos inmutables y value objects
- **Records**: Se combina perfectamente con record types

## Ejemplo Básico: Antes vs Después

```csharp
// ❌ ANTES: Constructor tradicional
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
}

// ✅ DESPUÉS: Primary Constructor
public class Customer(string name, string email)
{
    public string Greeting() => $"Hello {name}!";
}
```

## Ejemplo: Service Class con DI

```csharp
// ✅ BIEN: Service class con Primary Constructor
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

## Ejemplo: Record con Primary Constructor

```csharp
// ✅ BIEN: Record con Primary Constructor
public record Customer(string Name, string Email)
{
    public string Greeting() => $"Hello {Name}!";
}

// Uso
var customer = new Customer("John Doe", "john@example.com");
var updated = customer with { Email = "newemail@example.com" };
```

## Notas

- Los ejemplos muestran claramente la reducción de código
- Se demuestra el uso con Dependency Injection
- Se incluyen ejemplos prácticos de cuándo usar Primary Constructors
- Se explican las consideraciones y limitaciones
- Se muestran combinaciones con otras características modernas de C#

## Requisitos

- C# 12 o superior
- .NET 8.0 o superior (para Primary Constructors en clases)

