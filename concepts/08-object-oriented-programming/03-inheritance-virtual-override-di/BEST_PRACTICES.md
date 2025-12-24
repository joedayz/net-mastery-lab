# Mejores Prácticas: Inheritance with Virtual/Override and Dependency Injection

## ✅ Reglas de Oro

### 1. Usa Virtual para Métodos que Deben Ser Extendidos

```csharp
// ✅ BIEN: Método virtual permite extensión
public class Animal
{
    public virtual string Speak() => "Animal sound";
}

public class Dog : Animal
{
    public override string Speak() => "Woof!";
}

// ❌ MAL: Método no virtual no puede ser extendido
public class Animal
{
    public string Speak() => "Animal sound"; // Sin virtual
}
```

### 2. Siempre Usa Override para Sobrescribir Métodos Virtuales

```csharp
// ✅ BIEN: Usar override explícitamente
public class Dog : Animal
{
    public override string Speak() => "Woof!";
}

// ❌ MAL: Sin override, crea nuevo método en lugar de sobrescribir
public class Dog : Animal
{
    public string Speak() => "Woof!"; // Nuevo método, no sobrescribe
}
```

### 3. Registra Servicios en el Contenedor DI

```csharp
// ✅ BIEN: Registrar servicios en DI container
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<Animal, Dog>();
builder.Services.AddScoped<AnimalService>();

// ❌ MAL: Servicio no registrado causará error
var app = builder.Build();
app.MapGet("/", (AnimalService service) => service.GetAnimalSound()); 
// Error: AnimalService no está registrado
```

## ⚠️ Errores Comunes a Evitar

### 1. Olvidar el Keyword Virtual

```csharp
// ❌ MAL: Método no virtual no puede ser sobrescrito
public class Animal
{
    public string Speak() => "Animal sound";
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

### 2. No Usar Override Correctamente

```csharp
// ❌ MAL: Sin override, oculta el método en lugar de sobrescribirlo
public class Dog : Animal
{
    public new string Speak() => "Woof!"; // Oculta, no sobrescribe
}

// ✅ BIEN: Usar override
public class Dog : Animal
{
    public override string Speak() => "Woof!";
}
```

### 3. No Registrar Dependencias en DI

```csharp
// ❌ MAL: Dependencias no registradas
var app = builder.Build();
app.MapGet("/", (AnimalService service) => service.GetAnimalSound());
// Error en runtime

// ✅ BIEN: Registrar todas las dependencias
builder.Services.AddScoped<Animal, Dog>();
builder.Services.AddScoped<AnimalService>();
```

## 🎯 Casos de Uso Específicos

### 1. Herencia con Métodos Virtuales

```csharp
// ✅ BIEN: Base class con métodos virtuales
public class PaymentProcessor
{
    public virtual string ProcessPayment(decimal amount)
    {
        return $"Processing payment of ${amount}";
    }
    
    public virtual void LogTransaction(decimal amount)
    {
        Console.WriteLine($"Transaction: ${amount}");
    }
}

public class CreditCardProcessor : PaymentProcessor
{
    public override string ProcessPayment(decimal amount)
    {
        // Implementación específica
        ValidateCard();
        return base.ProcessPayment(amount);
    }
}
```

### 2. Dependency Injection con Interfaces

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

### 3. Scoped Lifetime para Request Scope

```csharp
// ✅ BIEN: Scoped lifetime para una instancia por request
builder.Services.AddScoped<Animal, Dog>();
builder.Services.AddScoped<AnimalService>();

// La misma instancia de Animal se usa en todo el request
```

### 4. Minimal APIs con DI

```csharp
// ✅ BIEN: Minimal API con DI automático
var app = builder.Build();

app.MapGet("/animal", (AnimalService service) => service.GetAnimalSound());
app.MapGet("/payment", (PaymentService service, decimal amount) => 
    service.Process(amount));

app.Run();
```

## 📊 Virtual vs Abstract vs Override

| Concepto | Uso | Características |
|----------|-----|-----------------|
| **virtual** | En clase base | Permite sobrescritura, tiene implementación |
| **abstract** | En clase abstracta | Debe ser implementado, no tiene implementación |
| **override** | En clase derivada | Sobrescribe método virtual/abstract |
| **new** | En clase derivada | Oculta método base (evitar usar) |

## 🚀 Tips Avanzados

### 1. Usar Base para Llamar Implementación Base

```csharp
// ✅ BIEN: Llamar implementación base cuando sea necesario
public class Dog : Animal
{
    public override string Speak()
    {
        var baseSound = base.Speak(); // Llamar método base
        return $"Dog says: {baseSound}";
    }
}
```

### 2. Sealed para Prevenir Más Herencia

```csharp
// ✅ BIEN: Usar sealed para prevenir más herencia
public sealed class Dog : Animal
{
    public override string Speak() => "Woof!";
}

// No se puede heredar de Dog
```

### 3. Template Method Pattern

```csharp
// ✅ BIEN: Template Method Pattern
public abstract class DataProcessor
{
    // Template method
    public void Process()
    {
        LoadData();
        TransformData();
        SaveData();
    }
    
    protected virtual void LoadData() { /* default */ }
    protected abstract void TransformData();
    protected virtual void SaveData() { /* default */ }
}
```

### 4. Factory Pattern con DI

```csharp
// ✅ BIEN: Factory pattern con DI
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

builder.Services.AddScoped<IAnimalFactory, AnimalFactory>();
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Inheritance](https://docs.microsoft.com/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [Microsoft Docs - Virtual Methods](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/virtual)
- [Microsoft Docs - Dependency Injection](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection)
- [Microsoft Docs - Minimal APIs](https://docs.microsoft.com/aspnet/core/fundamentals/minimal-apis)

