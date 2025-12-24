# Mejores Prácticas: Abstraction (Abstracción)

## ✅ Reglas de Oro

### 1. Usa Abstracción para Ocultar Complejidad

```csharp
// ✅ BIEN: Abstracción oculta detalles complejos
public abstract class PaymentProcessor
{
    public abstract bool ProcessPayment(decimal amount);
    // Detalles de cómo se procesa el pago están ocultos
}

// ❌ MAL: Expone todos los detalles
public class PaymentProcessor
{
    public void ConnectToBank() { /* ... */ }
    public void ValidateCredentials() { /* ... */ }
    public void ProcessTransaction() { /* ... */ }
    // Demasiados detalles expuestos
}
```

### 2. Define Solo lo Esencial en la Interfaz Abstracta

```csharp
// ✅ BIEN: Solo métodos esenciales
public abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
}

// ❌ MAL: Demasiados detalles en la clase abstracta
public abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
    public abstract void DrawToScreen(); // Detalle de implementación
    public abstract void SaveToFile(); // Detalle de implementación
}
```

### 3. Usa Abstract Classes cuando Necesites Código Compartido

```csharp
// ✅ BIEN: Abstract class con código compartido
public abstract class Animal
{
    public string Name { get; set; }
    
    public void Eat() { /* código compartido */ }
    public abstract void MakeSound();
}

// ✅ BIEN: Interface cuando solo necesitas contrato
public interface IShape
{
    double GetArea();
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Crear Clases Abstractas sin Necesidad

```csharp
// ❌ MAL: Clase abstracta innecesaria
public abstract class SimpleCalculator
{
    public int Add(int a, int b) => a + b; // No necesita ser abstracta
}

// ✅ BIEN: Solo usar abstract cuando sea necesario
public class SimpleCalculator
{
    public int Add(int a, int b) => a + b;
}
```

### 2. No Implementar Métodos Abstractos

```csharp
// ❌ MAL: Clase derivada no implementa método abstracto
public abstract class Shape
{
    public abstract double GetArea();
}

public class Circle : Shape
{
    // Falta implementar GetArea() - error de compilación
}

// ✅ BIEN: Implementar todos los métodos abstractos
public class Circle : Shape
{
    private double _radius;
    
    public override double GetArea() => Math.PI * _radius * _radius;
}
```

### 3. Exponer Detalles de Implementación

```csharp
// ❌ MAL: Expone detalles internos
public abstract class PaymentProcessor
{
    public abstract bool ProcessPayment(decimal amount);
    public abstract void ConnectToBank(); // Detalle interno expuesto
    public abstract void ValidateCredentials(); // Detalle interno expuesto
}

// ✅ BIEN: Oculta detalles internos
public abstract class PaymentProcessor
{
    public abstract bool ProcessPayment(decimal amount);
    // Detalles internos son privados en clases derivadas
}
```

## 🎯 Casos de Uso Específicos

### 1. Abstract Classes para Código Compartido

```csharp
// ✅ BIEN: Abstract class cuando hay código compartido
public abstract class DataProcessor
{
    protected string ConnectionString { get; set; }
    
    public void Connect()
    {
        // Código compartido para todas las clases derivadas
        Console.WriteLine($"Connecting to {ConnectionString}");
    }
    
    public abstract void Process();
}

public class SqlDataProcessor : DataProcessor
{
    public override void Process()
    {
        Connect();
        // Implementación específica para SQL
    }
}
```

### 2. Interfaces para Contratos Puros

```csharp
// ✅ BIEN: Interface para contrato puro
public interface IRepository<T>
{
    T GetById(int id);
    void Save(T entity);
    void Delete(int id);
}

public class UserRepository : IRepository<User>
{
    public User GetById(int id) { /* ... */ }
    public void Save(User entity) { /* ... */ }
    public void Delete(int id) { /* ... */ }
}
```

### 3. Abstract Records para Inmutabilidad

```csharp
// ✅ BIEN: Abstract record para estructuras inmutables
public abstract record Shape
{
    public abstract double GetArea();
}

public record Circle(double Radius) : Shape
{
    public override double GetArea() => Math.PI * Radius * Radius;
}
```

## 📊 Abstract Classes vs Interfaces

| Aspecto | Abstract Classes | Interfaces |
|---------|------------------|------------|
| **Métodos Concretos** | ✅ Puede tener | ⚠️ Solo desde C# 8.0 (default methods) |
| **Campos/Propiedades** | ✅ Puede tener | ❌ No puede tener campos |
| **Herencia Múltiple** | ❌ No soporta | ✅ Soporta |
| **Modificadores de Acceso** | ✅ Puede tener protected, private | ❌ Solo public |
| **Constructor** | ✅ Puede tener | ❌ No puede tener |
| **Uso Recomendado** | Código compartido | Contratos puros |

## 🚀 Tips Avanzados

### 1. Usar Abstract Records (C# 10+)

```csharp
// ✅ BIEN: Abstract record para estructuras inmutables
public abstract record Shape
{
    public abstract double GetArea();
}

public record Circle(double Radius) : Shape
{
    public override double GetArea() => Math.PI * Radius * Radius;
}
```

### 2. Combinar Abstract Classes e Interfaces

```csharp
// ✅ BIEN: Combinar ambos cuando sea apropiado
public interface IShape
{
    double GetArea();
}

public abstract class ShapeBase : IShape
{
    protected string Color { get; set; }
    
    public abstract double GetArea();
    
    public virtual void Draw()
    {
        Console.WriteLine($"Drawing {Color} shape");
    }
}
```

### 3. Template Method Pattern

```csharp
// ✅ BIEN: Template Method Pattern con abstract class
public abstract class DataProcessor
{
    // Template method - define el algoritmo
    public void Process()
    {
        LoadData();
        TransformData();
        SaveData();
    }
    
    protected abstract void LoadData();
    protected abstract void TransformData();
    protected abstract void SaveData();
}
```

### 4. Dependency Injection con Abstracciones

```csharp
// ✅ BIEN: Usar abstracciones para DI
public class OrderService
{
    private readonly IPaymentProcessor _paymentProcessor;
    
    public OrderService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }
    
    public void ProcessOrder(Order order)
    {
        _paymentProcessor.ProcessPayment(order.Total);
    }
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Abstract Classes](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/abstract)
- [Microsoft Docs - Records](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/record)
- [Microsoft Docs - Interfaces](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/interfaces)

