# Mejores Prácticas: Abstract Class vs Interface

## ✅ Reglas de Oro

### 1. Usa Abstract Class para Comportamiento Común

```csharp
// ✅ BIEN: Abstract Class para compartir código común
public abstract class PaymentProcessor
{
    protected decimal Amount { get; set; }
    
    // Método común con implementación
    public virtual void ValidateAmount()
    {
        if (Amount <= 0)
            throw new ArgumentException("Amount must be positive");
    }
    
    // Método abstracto (implementación única requerida)
    public abstract void ProcessPayment();
}

public class CreditCardProcessor : PaymentProcessor
{
    public override void ProcessPayment()
    {
        ValidateAmount(); // Usa método común
        // Lógica específica de tarjeta de crédito
    }
}
```

### 2. Usa Interface para Contratos

```csharp
// ✅ BIEN: Interface para definir contrato
public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
    bool ValidatePayment();
}

// Múltiples clases pueden implementar el mismo contrato
public class CreditCardProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount) { }
    public bool ValidatePayment() => true;
}

public class PayPalProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount) { }
    public bool ValidatePayment() => true;
}
```

### 3. Combina Ambos para Máximo Beneficio

```csharp
// ✅ BIEN: Combinar Abstract Class e Interface
public abstract class PaymentProcessor
{
    protected decimal Amount { get; set; }
    public abstract void ProcessPayment();
}

public interface IPaymentValidator
{
    bool Validate(decimal amount);
}

public interface IPaymentLogger
{
    void LogPayment(decimal amount);
}

public class CreditCardProcessor : PaymentProcessor, IPaymentValidator, IPaymentLogger
{
    public override void ProcessPayment()
    {
        if (Validate(Amount))
        {
            // Procesar pago
            LogPayment(Amount);
        }
    }
    
    public bool Validate(decimal amount) => amount > 0;
    public void LogPayment(decimal amount) => Console.WriteLine($"Payment: {amount}");
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Usar Abstract Class cuando Necesitas Herencia Múltiple

```csharp
// ❌ MAL: No puedes heredar de múltiples clases abstractas
public abstract class Vehicle { }
public abstract class ElectricVehicle { }

// public class HybridCar : Vehicle, ElectricVehicle // Error

// ✅ BIEN: Usa interfaces para herencia múltiple
public interface IVehicle { }
public interface IElectric { }

public class HybridCar : IVehicle, IElectric { } // Correcto
```

### 2. Usar Interface cuando Necesitas Campos o Constructores

```csharp
// ❌ MAL: Interface no puede tener campos o constructores
public interface IAnimal
{
    // string Name; // Error: No puede tener campos
    // public IAnimal(string name) { } // Error: No puede tener constructores
}

// ✅ BIEN: Usa Abstract Class cuando necesitas campos o constructores
public abstract class Animal
{
    protected string Name { get; set; }
    
    public Animal(string name)
    {
        Name = name;
    }
}
```

### 3. Crear Interfaces con Demasiados Métodos

```csharp
// ❌ MAL: Interface con demasiados métodos (viola ISP)
public interface IAnimal
{
    void MakeSound();
    void Eat();
    void Sleep();
    void Run();
    void Fly(); // No todos los animales vuelan
    void Swim(); // No todos los animales nadan
}

// ✅ BIEN: Interfaces pequeñas y enfocadas (Interface Segregation Principle)
public interface IAnimal
{
    void MakeSound();
    void Eat();
}

public interface IFlyable
{
    void Fly();
}

public interface ISwimmable
{
    void Swim();
}
```

## 🎯 Casos de Uso Específicos

### 1. Abstract Class para Jerarquía de Clases

```csharp
// ✅ BIEN: Abstract Class para jerarquía clara
public abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
    
    // Método común
    public virtual void Display()
    {
        Console.WriteLine($"Area: {GetArea()}, Perimeter: {GetPerimeter()}");
    }
}

public class Circle : Shape
{
    private double _radius;
    
    public Circle(double radius) => _radius = radius;
    
    public override double GetArea() => Math.PI * _radius * _radius;
    public override double GetPerimeter() => 2 * Math.PI * _radius;
}

public class Rectangle : Shape
{
    private double _width, _height;
    
    public Rectangle(double width, double height)
    {
        _width = width;
        _height = height;
    }
    
    public override double GetArea() => _width * _height;
    public override double GetPerimeter() => 2 * (_width + _height);
}
```

### 2. Interface para Capacidades Adicionales

```csharp
// ✅ BIEN: Interface para capacidades que no todas las clases tienen
public interface IDrawable
{
    void Draw();
}

public interface IResizable
{
    void Resize(double factor);
}

public class Circle : Shape, IDrawable, IResizable
{
    private double _radius;
    
    public void Draw()
    {
        Console.WriteLine($"Drawing circle with radius {_radius}");
    }
    
    public void Resize(double factor)
    {
        _radius *= factor;
    }
}
```

### 3. Dependency Injection con Interfaces

```csharp
// ✅ BIEN: Usar interfaces para DI
public interface IRepository<T>
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
}

public class OrderRepository : IRepository<Order>
{
    public Task<Order?> GetByIdAsync(int id) { }
    public Task<IEnumerable<Order>> GetAllAsync() { }
    public Task AddAsync(Order entity) { }
}

// Registro en DI
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
```

## 🚀 Tips Avanzados

### 1. Default Interface Methods (C# 8.0+)

```csharp
// ✅ BIEN: Default interface methods para compatibilidad hacia atrás
public interface ILogger
{
    void Log(string message);
    
    // Método por defecto (no rompe implementaciones existentes)
    void LogError(string message)
    {
        Log($"ERROR: {message}");
    }
}
```

### 2. Abstract Class con Template Method Pattern

```csharp
// ✅ BIEN: Template Method Pattern con Abstract Class
public abstract class DataProcessor
{
    // Template method (define el algoritmo)
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

public class CsvProcessor : DataProcessor
{
    protected override void LoadData() { }
    protected override void TransformData() { }
    protected override void SaveData() { }
}
```

### 3. Interface Segregation Principle

```csharp
// ✅ BIEN: Interfaces pequeñas y enfocadas
public interface IReadable
{
    string Read();
}

public interface IWritable
{
    void Write(string content);
}

// Clase puede implementar solo lo que necesita
public class ReadOnlyFile : IReadable
{
    public string Read() => "Content";
}

public class ReadWriteFile : IReadable, IWritable
{
    public string Read() => "Content";
    public void Write(string content) { }
}
```

## 📊 Tabla de Decisión: Cuándo Usar Cada Uno

| Escenario | Usar Abstract Class | Usar Interface | Razón |
|-----------|---------------------|----------------|-------|
| Compartir código común | ✅ Sí | ❌ No | Abstract Class permite implementación común |
| Herencia múltiple | ❌ No | ✅ Sí | Solo interfaces soportan múltiple herencia |
| Campos/Constructors | ✅ Sí | ❌ No | Interfaces no pueden tener campos/constructors |
| Contrato para clases no relacionadas | ❌ No | ✅ Sí | Interfaces son mejores para contratos |
| Relación "is-a" | ✅ Sí | ⚠️ Considerar | Abstract Class para jerarquías claras |
| Relación "can-do" | ⚠️ Considerar | ✅ Sí | Interfaces para capacidades |
| DI y Testing | ⚠️ Considerar | ✅ Sí | Interfaces son mejores para mocking |

## 💡 Pro Tips

### 1. Preferir Interfaces para Dependency Injection

```csharp
// ✅ BIEN: Interfaces para DI (mejor para testing)
public interface IOrderService
{
    Task<Order> CreateOrderAsync(OrderDto dto);
}

public class OrderService : IOrderService
{
    public async Task<Order> CreateOrderAsync(OrderDto dto) { }
}

// Fácil de mockear en tests
var mockService = new Mock<IOrderService>();
```

### 2. Usar Abstract Class para Código Reutilizable

```csharp
// ✅ BIEN: Abstract Class cuando hay código común significativo
public abstract class BaseRepository<T>
{
    protected readonly DbContext _context;
    
    public BaseRepository(DbContext context)
    {
        _context = context;
    }
    
    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    
    public virtual async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}
```

### 3. Combinar Ambos Estrategicamente

```csharp
// ✅ BIEN: Combinación estratégica
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public interface IAuditable
{
    void Audit();
}

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    void SoftDelete();
}

public class Order : BaseEntity, IAuditable, ISoftDeletable
{
    public bool IsDeleted { get; set; }
    
    public void Audit()
    {
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SoftDelete()
    {
        IsDeleted = true;
        Audit();
    }
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Abstract Classes](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/abstract)
- [Microsoft Docs - Interfaces](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/interface)
- [Microsoft Docs - Default Interface Methods](https://docs.microsoft.com/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods)
- [SOLID Principles](https://docs.microsoft.com/dotnet/architecture/modern-web-apps-azure/architectural-principles#solid)

