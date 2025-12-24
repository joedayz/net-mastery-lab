# Inheritance with Virtual/Override and Dependency Injection in ASP.NET Core 🎯

## Introducción

La herencia es un concepto fundamental de la Programación Orientada a Objetos (OOP) que facilita la reutilización de código y permite una jerarquía de clases natural. En ASP.NET Core, combinar métodos virtual/override con inyección de dependencias (DI) proporciona un framework poderoso para construir aplicaciones escalables, flexibles y mantenibles.

Este enfoque permite que la clase base defina comportamiento común mientras permite que las clases derivadas lo extiendan o modifiquen para satisfacer necesidades específicas.

## 📖 ¿Qué es la Herencia?

La herencia es un mecanismo mediante el cual una clase puede heredar propiedades y métodos de otra clase. La clase que hereda se llama clase derivada o subclase, y la clase de la que hereda se llama clase base o superclase.

## 🎯 Conceptos Clave

### 1. Virtual Methods (Métodos Virtuales)

La palabra clave `virtual` permite que los métodos en la clase base sean sobrescritos en las clases derivadas, promoviendo flexibilidad.

```csharp
// Base class with a virtual method
public class Animal
{
    public virtual string Speak() => "Animal sound";
}
```

**Características:**
- Permite que las clases derivadas proporcionen su propia implementación
- La clase base puede proporcionar una implementación por defecto
- Facilita el polimorfismo

### 2. Override (Sobrescritura)

Las clases derivadas usan la palabra clave `override` para proporcionar una implementación específica de un método virtual, adaptando el comportamiento de la clase base sin modificar la clase base misma.

```csharp
// Derived class overriding the virtual method
public class Dog : Animal
{
    public override string Speak() => "Woof!";
}

public class Cat : Animal
{
    public override string Speak() => "Meow!";
}
```

**Características:**
- Proporciona implementación específica para cada clase derivada
- Mantiene la firma del método de la clase base
- Permite polimorfismo en tiempo de ejecución

### 3. Dependency Injection (Inyección de Dependencias)

El framework de DI integrado de ASP.NET Core permite a los desarrolladores inyectar dependencias en tiempo de ejecución, asegurando que los componentes estén débilmente acoplados y sean más fáciles de mantener, probar y escalar.

```csharp
// AnimalService using dependency injection
public class AnimalService
{
    private readonly Animal _animal;
    
    public AnimalService(Animal animal) => _animal = animal;
    
    public string GetAnimalSound() => _animal.Speak(); 
    // Calls the correct Speak() based on the injected animal
}
```

## 🚀 Características Clave en ASP.NET Core

### 1. Minimal APIs

El soporte de ASP.NET Core para Minimal APIs hace que definir rutas y endpoints sea más conciso y legible. `MapGet` permite manejar fácilmente solicitudes HTTP con menos código boilerplate.

```csharp
// Program.cs (ASP.NET Core)
var builder = WebApplication.CreateBuilder(args);

// Register Dog or Cat class as Animal in the DI container
builder.Services.AddScoped<Animal, Dog>();

var app = builder.Build();

app.MapGet("/", (AnimalService animalService) => animalService.GetAnimalSound());

app.Run();
```

### 2. Efficient Dependency Injection

El framework de DI de ASP.NET Core simplifica el registro de servicios, permitiendo que servicios como `AddScoped<Animal, Dog>()` sean fácilmente inyectados, haciendo las aplicaciones más modulares y flexibles.

```csharp
// Registro de servicios en el contenedor DI
builder.Services.AddScoped<Animal, Dog>(); // Dog como implementación de Animal
builder.Services.AddScoped<Animal, Cat>(); // O Cat como implementación de Animal
builder.Services.AddScoped<AnimalService>();
```

### 3. Scoped Lifetimes

Usar servicios con alcance (scoped) asegura que la misma instancia de `Animal` se use dentro de una sola solicitud, optimizando tanto el rendimiento como la consistencia en las llamadas a servicios.

**Tipos de Lifetime:**
- **Singleton**: Una instancia para toda la aplicación
- **Scoped**: Una instancia por solicitud HTTP
- **Transient**: Nueva instancia cada vez que se solicita

## 💡 Ejemplos Prácticos

### Ejemplo 1: Estructura Básica

```csharp
// Base class with a virtual method
public class Animal
{
    public virtual string Speak() => "Animal sound";
}

// Derived class overriding the virtual method
public class Dog : Animal
{
    public override string Speak() => "Woof!";
}

public class Cat : Animal
{
    public override string Speak() => "Meow!";
}

// AnimalService using dependency injection
public class AnimalService
{
    private readonly Animal _animal;
    
    public AnimalService(Animal animal) => _animal = animal;
    
    public string GetAnimalSound() => _animal.Speak();
}
```

### Ejemplo 2: Configuración en ASP.NET Core

```csharp
// Program.cs (ASP.NET Core)
var builder = WebApplication.CreateBuilder(args);

// Register Dog or Cat class as Animal in the DI container
builder.Services.AddScoped<Animal, Dog>();

var app = builder.Build();

app.MapGet("/", (AnimalService animalService) => animalService.GetAnimalSound());

app.Run();
```

### Ejemplo 3: Múltiples Implementaciones

```csharp
public abstract class PaymentProcessor
{
    public virtual string ProcessPayment(decimal amount)
    {
        return $"Processing payment of ${amount}";
    }
    
    public abstract string GetPaymentMethod();
}

public class CreditCardProcessor : PaymentProcessor
{
    public override string ProcessPayment(decimal amount)
    {
        return $"Processing credit card payment of ${amount}";
    }
    
    public override string GetPaymentMethod() => "Credit Card";
}

public class PayPalProcessor : PaymentProcessor
{
    public override string ProcessPayment(decimal amount)
    {
        return $"Processing PayPal payment of ${amount}";
    }
    
    public override string GetPaymentMethod() => "PayPal";
}

// Service con DI
public class PaymentService
{
    private readonly PaymentProcessor _processor;
    
    public PaymentService(PaymentProcessor processor) => _processor = processor;
    
    public string Process(decimal amount) => _processor.ProcessPayment(amount);
}
```

### Ejemplo 4: Con Interfaces (Mejor Práctica)

```csharp
// ✅ BIEN: Usar interfaces para mejor desacoplamiento
public interface IAnimal
{
    string Speak();
}

public class Animal : IAnimal
{
    public virtual string Speak() => "Animal sound";
}

public class Dog : Animal
{
    public override string Speak() => "Woof!";
}

public class Cat : Animal
{
    public override string Speak() => "Meow!";
}

// Service usando interface
public class AnimalService
{
    private readonly IAnimal _animal;
    
    public AnimalService(IAnimal animal) => _animal = animal;
    
    public string GetAnimalSound() => _animal.Speak();
}

// Registro en DI
builder.Services.AddScoped<IAnimal, Dog>();
builder.Services.AddScoped<AnimalService>();
```

## 🎯 ¿Por Qué Combinar Herencia y Dependency Injection?

### 1. Decoupled Implementations (Implementaciones Desacopladas)

El servicio depende de abstracciones (`Animal`) en lugar de implementaciones específicas (`Dog`, `Cat`), permitiéndote cambiar o extender funcionalidad sin cambiar el servicio.

```csharp
// ✅ BIEN: Depende de abstracción
public class AnimalService
{
    private readonly Animal _animal; // Abstracción, no implementación específica
    
    public AnimalService(Animal animal) => _animal = animal;
}

// Puedes cambiar la implementación sin modificar AnimalService
builder.Services.AddScoped<Animal, Dog>(); // O Cat, o cualquier otra clase derivada
```

### 2. Customizable Behavior (Comportamiento Personalizable)

Los métodos virtuales proporcionan un mecanismo para que las clases derivadas personalicen el comportamiento mientras aún heredan funcionalidad común de la clase base.

```csharp
public class Animal
{
    public virtual string Speak() => "Animal sound"; // Comportamiento por defecto
    
    public virtual void Eat() // Método virtual con implementación
    {
        Console.WriteLine("Eating...");
    }
}

public class Dog : Animal
{
    public override string Speak() => "Woof!"; // Personalizado
    
    // Puede usar el método Eat() heredado o sobrescribirlo
}
```

### 3. Maintainability (Mantenibilidad)

La inyección de dependencias separa responsabilidades, reduce el acoplamiento estrecho y asegura que los servicios puedan ser fácilmente probados y mantenidos.

```csharp
// ✅ BIEN: Fácil de testear
public class AnimalService
{
    private readonly Animal _animal;
    
    public AnimalService(Animal animal) => _animal = animal;
    
    public string GetAnimalSound() => _animal.Speak();
}

// En tests, puedes inyectar un mock
var mockAnimal = new Mock<Animal>();
mockAnimal.Setup(a => a.Speak()).Returns("Test sound");
var service = new AnimalService(mockAnimal.Object);
```

## 🔄 Virtual vs Abstract vs Override

| Concepto | Uso | Características |
|----------|-----|-----------------|
| **virtual** | En clase base | Permite sobrescritura, tiene implementación por defecto |
| **abstract** | En clase abstracta | Debe ser implementado, no tiene implementación |
| **override** | En clase derivada | Proporciona nueva implementación de método virtual/abstract |

## ⚠️ Errores Comunes a Evitar

### 1. No Usar Virtual en Métodos que Deben Ser Sobrescritos

```csharp
// ❌ MAL: Método no virtual no puede ser sobrescrito
public class Animal
{
    public string Speak() => "Animal sound"; // Sin virtual
}

public class Dog : Animal
{
    public override string Speak() => "Woof!"; // Error de compilación
}

// ✅ BIEN: Usar virtual
public class Animal
{
    public virtual string Speak() => "Animal sound";
}
```

### 2. Olvidar el Override Keyword

```csharp
// ❌ MAL: Sin override, crea un nuevo método en lugar de sobrescribir
public class Dog : Animal
{
    public string Speak() => "Woof!"; // Nuevo método, no sobrescribe
}

// ✅ BIEN: Usar override
public class Dog : Animal
{
    public override string Speak() => "Woof!";
}
```

### 3. No Registrar Servicios en DI Container

```csharp
// ❌ MAL: Servicio no registrado
var app = builder.Build();
app.MapGet("/", (AnimalService service) => service.GetAnimalSound()); 
// Error: AnimalService no está registrado

// ✅ BIEN: Registrar servicios
builder.Services.AddScoped<Animal, Dog>();
builder.Services.AddScoped<AnimalService>();
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Inheritance](https://docs.microsoft.com/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [Microsoft Docs - Virtual Methods](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/virtual)
- [Microsoft Docs - Dependency Injection](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection)
- [Microsoft Docs - Minimal APIs](https://docs.microsoft.com/aspnet/core/fundamentals/minimal-apis)

