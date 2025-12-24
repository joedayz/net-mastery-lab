# Abstraction (Abstracción) 🎯

## Introducción

La abstracción es uno de los principios fundamentales de la Programación Orientada a Objetos (OOP), enfocado en simplificar sistemas complejos resaltando solo los detalles relevantes y ocultando las complejidades de implementación innecesarias. Permite a los desarrolladores trabajar con conceptos de alto nivel mientras dejan ocultos los funcionamientos intrincados de un objeto o sistema.

## 📖 ¿Qué es la Abstracción?

La abstracción oculta detalles complejos y muestra solo las características esenciales. Las clases abstractas y records proporcionan formas modernas y concisas de definir estructuras donde solo se expone la información necesaria, y las implementaciones detalladas se dejan para las clases derivadas.

## 🎯 Características Clave de la Abstracción

### 1. Essential Features Only (Solo Características Esenciales)

La abstracción te permite definir una estructura donde solo las características esenciales de un objeto o concepto se exponen al mundo exterior. Esto hace que trabajar con objetos sea más simple e intuitivo para los usuarios, sin necesidad de conocer los detalles subyacentes de cómo funcionan.

```csharp
// ✅ BIEN: Solo expone lo esencial
public abstract class Shape
{
    public abstract double GetArea(); // Solo la interfaz, no la implementación
    public abstract double GetPerimeter();
}

// Los detalles de cómo calcular el área se ocultan
```

### 2. Interface Design (Diseño de Interfaz)

En la abstracción, las clases definen qué acciones puede realizar un objeto (a través de métodos), pero no cómo se implementan esas acciones. Esto se puede lograr mediante clases abstractas e interfaces.

```csharp
// ✅ BIEN: Define QUÉ hacer, no CÓMO hacerlo
public abstract class Shape
{
    public abstract double GetArea(); // Firma del método, sin implementación
}

// La implementación específica se deja para las clases concretas
public class Circle : Shape
{
    private double _radius;
    
    public override double GetArea() => Math.PI * _radius * _radius; // Implementación específica
}
```

### 3. Flexibility and Extensibility (Flexibilidad y Extensibilidad)

La abstracción proporciona flexibilidad al permitir que diferentes objetos proporcionen sus propias implementaciones de los métodos abstractos. Como resultado, los desarrolladores pueden crear múltiples clases concretas que se adhieren al mismo diseño abstracto, permitiendo que el código se reutilice y extienda sin modificar la interfaz abstracta o la clase base.

```csharp
// ✅ BIEN: Múltiples implementaciones del mismo concepto abstracto
public abstract class Shape
{
    public abstract double GetArea();
}

public class Circle : Shape
{
    public override double GetArea() => Math.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    public override double GetArea() => Width * Height;
}

public class Triangle : Shape
{
    public override double GetArea() => 0.5 * Base * Height;
}
```

### 4. Separation of Concerns (Separación de Responsabilidades)

La abstracción fomenta una separación clara entre el qué (qué hace el objeto) y el cómo (cómo lo logra). Esto lleva a código modular y mantenible, donde los cambios en una implementación interna no afectan las interfaces externas o los componentes que interactúan.

```csharp
// ✅ BIEN: Separación clara entre interfaz e implementación
public abstract class PaymentProcessor
{
    public abstract bool ProcessPayment(decimal amount); // QUÉ hace
}

public class CreditCardProcessor : PaymentProcessor
{
    public override bool ProcessPayment(decimal amount)
    {
        // CÓMO lo hace - detalles ocultos
        ValidateCard();
        ChargeCard(amount);
        SendConfirmation();
        return true;
    }
    
    private void ValidateCard() { /* ... */ }
    private void ChargeCard(decimal amount) { /* ... */ }
    private void SendConfirmation() { /* ... */ }
}
```

## 💡 Ejemplos Prácticos

### Ejemplo 1: Abstract Class con Métodos Abstractos

```csharp
public abstract class Shape
{
    public abstract double GetArea(); // Abstract method to be implemented by derived classes
    public abstract double GetPerimeter();
}

public class Circle : Shape
{
    private double _radius;
    
    public Circle(double radius)
    {
        _radius = radius;
    }
    
    public override double GetArea() => Math.PI * _radius * _radius;
    public override double GetPerimeter() => 2 * Math.PI * _radius;
}
```

### Ejemplo 2: Abstract Record (C# 10+)

```csharp
// ✅ BIEN: Abstract record - forma moderna y concisa
public abstract record Shape
{
    public abstract double GetArea(); // Abstract method to be implemented by derived classes
}

public record Circle(double Radius) : Shape
{
    public override double GetArea() => Math.PI * Radius * Radius;
    // Circle-specific implementation
}

public record Rectangle(double Width, double Height) : Shape
{
    public override double GetArea() => Width * Height;
}
```

### Ejemplo 3: Abstract Class con Métodos Concretos y Abstractos

```csharp
public abstract class Animal
{
    // Propiedad concreta compartida
    public string Name { get; set; }
    
    // Método concreto compartido
    public void Eat()
    {
        Console.WriteLine($"{Name} is eating.");
    }
    
    // Método abstracto - debe ser implementado por clases derivadas
    public abstract void MakeSound();
    
    // Método virtual - puede ser sobrescrito
    public virtual void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping.");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} barks: Woof! Woof!");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} meows: Meow!");
    }
    
    public override void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping peacefully.");
    }
}
```

### Ejemplo 4: Abstracción con Interfaces

```csharp
// ✅ BIEN: Interface para abstracción
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
```

### Ejemplo 5: Abstracción en Sistemas Reales

```csharp
public abstract class PaymentProcessor
{
    public abstract bool ProcessPayment(decimal amount);
    public abstract string GetPaymentMethod();
    
    // Método concreto compartido
    public void LogTransaction(decimal amount)
    {
        Console.WriteLine($"Processing {GetPaymentMethod()} payment of ${amount}");
    }
}

public class CreditCardProcessor : PaymentProcessor
{
    public override bool ProcessPayment(decimal amount)
    {
        LogTransaction(amount);
        // Implementación específica para tarjeta de crédito
        ValidateCard();
        ChargeCard(amount);
        return true;
    }
    
    public override string GetPaymentMethod() => "Credit Card";
    
    private void ValidateCard() { /* ... */ }
    private void ChargeCard(decimal amount) { /* ... */ }
}

public class PayPalProcessor : PaymentProcessor
{
    public override bool ProcessPayment(decimal amount)
    {
        LogTransaction(amount);
        // Implementación específica para PayPal
        AuthenticatePayPal();
        ProcessPayPalPayment(amount);
        return true;
    }
    
    public override string GetPaymentMethod() => "PayPal";
    
    private void AuthenticatePayPal() { /* ... */ }
    private void ProcessPayPalPayment(decimal amount) { /* ... */ }
}
```

## 🔄 Abstract Classes vs Interfaces

### Abstract Classes
- Pueden tener métodos concretos y abstractos
- Pueden tener campos y propiedades
- Soporta herencia simple
- Útil cuando hay código compartido

```csharp
public abstract class Shape
{
    protected string Color { get; set; } // Campo compartido
    
    public abstract double GetArea(); // Método abstracto
    
    public virtual void Draw() // Método concreto con implementación por defecto
    {
        Console.WriteLine($"Drawing {Color} shape");
    }
}
```

### Interfaces
- Solo definen contratos (firmas de métodos)
- No pueden tener implementación (antes de C# 8.0)
- Soporta herencia múltiple
- Útil para definir contratos

```csharp
public interface IShape
{
    double GetArea(); // Solo firma, sin implementación
    double GetPerimeter();
}
```

## 🎯 Cuándo Usar Abstracción

### Usa abstracción cuando:
- ✅ Necesitas definir un contrato común para múltiples clases
- ✅ Quieres ocultar detalles de implementación complejos
- ✅ Necesitas flexibilidad para diferentes implementaciones
- ✅ Quieres separar el qué del cómo
- ✅ Necesitas código reutilizable y extensible

### Beneficios:
- **Simplicidad**: Trabajar con conceptos de alto nivel
- **Mantenibilidad**: Cambios internos no afectan código externo
- **Flexibilidad**: Múltiples implementaciones del mismo concepto
- **Testabilidad**: Fácil crear mocks y stubs para testing

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

## 📚 Recursos Adicionales

- [Microsoft Docs - Abstract Classes](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/abstract)
- [Microsoft Docs - Records](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/record)
- [Microsoft Docs - Interfaces](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/interfaces)

