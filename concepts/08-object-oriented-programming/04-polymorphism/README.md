# Polymorphism (Polimorfismo) 🔄

## Introducción

El polimorfismo es uno de los cuatro principios fundamentales de la Programación Orientada a Objetos (OOP). La palabra polimorfismo proviene de las palabras griegas "poly" (muchos) y "morph" (forma), lo que significa "muchas formas". En programación, se refiere a la capacidad de objetos de diferentes tipos de responder a la misma llamada de método de diferentes maneras.

El polimorfismo te permite definir una sola interfaz o método pero tener múltiples implementaciones. Esto significa que el mismo nombre de método puede comportarse de manera diferente según el objeto que lo está llamando, permitiendo flexibilidad y escalabilidad en tu código.

El polimorfismo es un principio clave que permite flexibilidad, escalabilidad y mantenibilidad del código. Esta guía profundiza en cómo el polimorfismo y la inyección de dependencias (DI) trabajan juntos para seleccionar dinámicamente entre diferentes implementaciones de una interfaz, mejorando la extensibilidad de nuestros sistemas.

## 🔄 "One Interface, Many Implementations"

Con Dependency Injection, el polimorfismo es naturalmente soportado al inyectar diferentes implementaciones de una interfaz, permitiendo un diseño flexible y desacoplado. En este escenario, podemos tener múltiples procesadores de pago (como `CreditCardPaymentProcessor` y `PayPalPaymentProcessor`), ambos implementando la interfaz `IPaymentProcessor`. Usando DI, podemos inyectar la implementación apropiada en nuestro `CheckoutService` basado en condiciones de tiempo de ejecución, haciendo la aplicación adaptable y dinámica.

## 📖 ¿Qué es el Polimorfismo?

El polimorfismo permite que objetos de diferentes clases sean tratados como objetos de una clase base común. Esto se logra a través de:

1. **Interfaces**: Define un contrato común
2. **Herencia**: Permite que clases derivadas sobrescriban métodos
3. **Dependency Injection**: Inyecta diferentes implementaciones en tiempo de ejecución

## 🎯 Tipos de Polimorfismo

### 1. Compile-Time Polymorphism (Polimorfismo en Tiempo de Compilación)

También conocido como **Method Overloading** o **Static Polymorphism**.

```csharp
public class Calculator
{
    public int Add(int a, int b) => a + b;
    public int Add(int a, int b, int c) => a + b + c; // Overload
    public double Add(double a, double b) => a + b; // Overload
}
```

### 2. Runtime Polymorphism (Polimorfismo en Tiempo de Ejecución)

También conocido como **Method Overriding** o **Dynamic Polymorphism**. Este es el tipo más común y poderoso.

```csharp
public interface IPaymentProcessor
{
    void ProcessPayment(Order order);
}

public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("Processing credit card payment ...");
    }
}

public class PaypalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("Processing PayPal payment ...");
    }
}
```

## 💡 Ejemplos Prácticos

### Ejemplo 1: Polimorfismo con Interfaces y DI

```csharp
// Interface que define el contrato
public interface IPaymentProcessor
{
    void ProcessPayment(Order order);
}

// Implementación 1: Credit Card
public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("Processing credit card payment ...");
    }
}

// Implementación 2: PayPal
public class PaypalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("Processing PayPal payment ...");
    }
}

// Client class using DI to inject the payment processor
public class CheckoutService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public CheckoutService(IPaymentProcessor paymentProcessor) // Injected via DI
    {
        _paymentProcessor = paymentProcessor;
    }

    public void Checkout(Order order)
    {
        _paymentProcessor.ProcessPayment(order);
    }
}

// En el DI container (e.g., ASP.NET Core)
services.AddTransient<IPaymentProcessor, CreditCardPaymentProcessor>();
// O
services.AddTransient<IPaymentProcessor, PaypalPaymentProcessor>();
```

### Ejemplo 2: Polimorfismo con Herencia

```csharp
public abstract class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks: Woof! Woof!");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows: Meow!");
    }
}

// Uso polimórfico
Animal[] animals = { new Dog(), new Cat() };
foreach (Animal animal in animals)
{
    animal.MakeSound(); // Cada uno hace su sonido específico
}
```

### Ejemplo 3: Polimorfismo con Interfaces y Múltiples Implementaciones

```csharp
public interface IShape
{
    double GetArea();
    double GetPerimeter();
}

public class Circle : IShape
{
    private double _radius;
    
    public Circle(double radius) => _radius = radius;
    
    public double GetArea() => Math.PI * _radius * _radius;
    public double GetPerimeter() => 2 * Math.PI * _radius;
}

public class Rectangle : IShape
{
    private double _width;
    private double _height;
    
    public Rectangle(double width, double height)
    {
        _width = width;
        _height = height;
    }
    
    public double GetArea() => _width * _height;
    public double GetPerimeter() => 2 * (_width + _height);
}

// Uso polimórfico
IShape[] shapes = { new Circle(5), new Rectangle(4, 6) };
foreach (IShape shape in shapes)
{
    Console.WriteLine($"Area: {shape.GetArea()}, Perimeter: {shape.GetPerimeter()}");
}
```

### Ejemplo 4: Polimorfismo con Dependency Injection en ASP.NET Core

```csharp
// Interface
public interface ILogger
{
    void Log(string message);
}

// Implementaciones
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
        // Lógica de creación
    }
}

// Registro en DI container
builder.Services.AddScoped<ILogger, FileLogger>();
// O cambiar a ConsoleLogger sin modificar UserService
builder.Services.AddScoped<ILogger, ConsoleLogger>();
```

## 🔄 Polimorfismo con Dependency Injection

El polimorfismo y Dependency Injection trabajan juntos perfectamente. El polimorfismo es un principio clave que permite flexibilidad, escalabilidad y mantenibilidad del código. Esta sección profundiza en cómo el polimorfismo y la inyección de dependencias (DI) trabajan juntos para seleccionar dinámicamente entre diferentes implementaciones de una interfaz, mejorando la extensibilidad de nuestros sistemas.

### Ventajas de Combinar Polimorfismo y DI

1. **Flexibilidad**: Puedes cambiar implementaciones sin modificar el código cliente
2. **Testabilidad**: Fácil crear mocks para testing
3. **Desacoplamiento**: El código cliente depende de abstracciones, no de implementaciones concretas
4. **Escalabilidad**: Fácil agregar nuevas implementaciones
5. **Selección Dinámica**: Puedes seleccionar implementaciones en tiempo de ejecución basado en condiciones

## 🎯 Selección Dinámica de Implementaciones

En este escenario, tenemos dos procesadores de pago: `CreditCardPaymentProcessor` y `PayPalPaymentProcessor`, ambos implementando la interfaz `IPaymentProcessor`. Usando DI, podemos inyectar la implementación apropiada en nuestro `CheckoutService` basado en condiciones de tiempo de ejecución, haciendo la aplicación adaptable y dinámica.

### Ejemplo: Factory Pattern con DI

```csharp
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

### Configuración del DI Container con Factory Pattern

```csharp
// In the DI container (e.g., ASP.NET Core startup configuration)
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
```

### Uso en Controller o Aplicación

```csharp
// Usage in the controller or application
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

// Example usage:
// Assume user selects "PayPal" as payment method
var controller = new OrderController(paymentProcessorFactory);
controller.Checkout("PayPal"); // Output: Processing PayPal payment.
```

```csharp
// ✅ BIEN: Polimorfismo con DI
public class OrderService
{
    private readonly IPaymentProcessor _paymentProcessor;
    
    public OrderService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor; // Puede ser cualquier implementación
    }
    
    public void ProcessOrder()
    {
        _paymentProcessor.ProcessPayment(); // Comportamiento polimórfico
    }
}

// En diferentes contextos, puedes inyectar diferentes implementaciones
services.AddScoped<IPaymentProcessor, CreditCardPaymentProcessor>();
// O
services.AddScoped<IPaymentProcessor, PayPalPaymentProcessor>();
```

## 🎯 Cuándo Usar Polimorfismo

### Usa polimorfismo cuando:
- ✅ Necesitas múltiples implementaciones del mismo comportamiento
- ✅ Quieres cambiar implementaciones en tiempo de ejecución
- ✅ Necesitas código flexible y extensible
- ✅ Quieres reducir el acoplamiento entre componentes
- ✅ Necesitas facilitar el testing con mocks

### Beneficios:
- **Flexibilidad**: Múltiples implementaciones del mismo contrato
- **Mantenibilidad**: Cambios en una implementación no afectan otras
- **Testabilidad**: Fácil crear mocks y stubs
- **Escalabilidad**: Fácil agregar nuevas implementaciones

## 📊 Polimorfismo vs Otros Conceptos OOP

| Concepto | Relación con Polimorfismo |
|----------|---------------------------|
| **Encapsulation** | Encapsula datos y métodos dentro de clases |
| **Abstraction** | Define interfaces abstractas que permiten polimorfismo |
| **Inheritance** | Permite que clases derivadas sobrescriban métodos (polimorfismo) |
| **Polymorphism** | Usa herencia y abstracción para lograr comportamiento polimórfico |

## ⚠️ Errores Comunes a Evitar

### 1. No Usar Interfaces para Polimorfismo

```csharp
// ❌ MAL: Dependencia directa de implementación concreta
public class CheckoutService
{
    private readonly CreditCardPaymentProcessor _processor;
    
    public CheckoutService(CreditCardPaymentProcessor processor)
    {
        _processor = processor; // Acoplado a implementación específica
    }
}

// ✅ BIEN: Dependencia de interfaz (polimorfismo)
public class CheckoutService
{
    private readonly IPaymentProcessor _processor;
    
    public CheckoutService(IPaymentProcessor processor)
    {
        _processor = processor; // Puede ser cualquier implementación
    }
}
```

### 2. No Implementar Correctamente la Interfaz

```csharp
// ❌ MAL: No implementa todos los métodos de la interfaz
public interface IPaymentProcessor
{
    void ProcessPayment(Order order);
    void RefundPayment(Order order);
}

public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order) { }
    // Falta RefundPayment - error de compilación
}

// ✅ BIEN: Implementa todos los métodos
public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order) { }
    public void RefundPayment(Order order) { }
}
```

### 3. No Usar DI para Inyectar Dependencias Polimórficas

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

// ✅ BIEN: Inyectar a través de constructor (DI)
public class CheckoutService
{
    private readonly IPaymentProcessor _processor;
    
    public CheckoutService(IPaymentProcessor processor)
    {
        _processor = processor; // Desacoplado
    }
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Polymorphism](https://docs.microsoft.com/dotnet/csharp/fundamentals/object-oriented/polymorphism)
- [Microsoft Docs - Interfaces](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/interfaces)
- [Microsoft Docs - Dependency Injection](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection)

