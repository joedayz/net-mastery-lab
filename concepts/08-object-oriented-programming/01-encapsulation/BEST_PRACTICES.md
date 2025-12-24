# Mejores Prácticas: Encapsulation (Encapsulación)

## ✅ Reglas de Oro

### 1. Usa Propiedades en lugar de Campos Públicos

```csharp
// ❌ MAL: Campos públicos sin encapsulación
public class Person
{
    public string Name;
    public int Age;
}

// ✅ BIEN: Propiedades con encapsulación
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

### 2. Protege Campos con Modificadores de Acceso Privados

```csharp
// ✅ BIEN: Campos privados protegidos
public class Person
{
    private string _name;
    private int _age;
    
    public string Name
    {
        get => _name;
        set => _name = value;
    }
}
```

### 3. Valida Datos en Setters

```csharp
// ✅ BIEN: Validación en setters
public class Person
{
    private int _age;
    
    public int Age
    {
        get => _age;
        set
        {
            if (value < 0 || value > 150)
                throw new ArgumentException("Age must be between 0 and 150");
            _age = value;
        }
    }
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Exponer Campos Públicos

```csharp
// ❌ MAL: Campos públicos sin control
public class Person
{
    public string Name; // Puede ser modificado sin validación
    public int Age; // Puede ser negativo
}

// ✅ BIEN: Propiedades con validación
public class Person
{
    private string _name;
    private int _age;
    
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be null or empty");
            _name = value;
        }
    }
}
```

### 2. Exponer Colecciones Internas Directamente

```csharp
// ❌ MAL: Exponer lista directamente
public class Order
{
    public List<OrderItem> Items { get; set; } // Puede ser modificada desde fuera
}

// ✅ BIEN: Encapsular la colección
public class Order
{
    private readonly List<OrderItem> _items = new();
    
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
    
    public void AddItem(OrderItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));
        _items.Add(item);
    }
    
    public bool RemoveItem(OrderItem item)
    {
        return _items.Remove(item);
    }
}
```

### 3. No Validar Datos de Entrada

```csharp
// ❌ MAL: Sin validación
public class BankAccount
{
    private decimal _balance;
    
    public void Deposit(decimal amount)
    {
        _balance += amount; // ¿Qué pasa si amount es negativo?
    }
}

// ✅ BIEN: Con validación
public class BankAccount
{
    private decimal _balance;
    
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");
        _balance += amount;
    }
}
```

## 🎯 Casos de Uso Específicos

### 1. Auto-Properties con Valores por Defecto

```csharp
// ✅ BIEN: Auto-property con valor por defecto
public class Person
{
    public string Name { get; set; } = "Default Name";
    public int Age { get; set; } = 0;
}
```

### 2. Propiedades de Solo Lectura

```csharp
// ✅ BIEN: Propiedades de solo lectura
public class Order
{
    private readonly int _orderId;
    
    public Order(int orderId)
    {
        _orderId = orderId;
    }
    
    public int OrderId => _orderId; // Solo lectura
}
```

### 3. Propiedades Calculadas

```csharp
// ✅ BIEN: Propiedades calculadas sin campo de respaldo
public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public double Area => Width * Height;
    public double Perimeter => 2 * (Width + Height);
}
```

### 4. Encapsulación de Lógica Compleja

```csharp
// ✅ BIEN: Lógica compleja encapsulada
public class EmailService
{
    private string _smtpServer;
    private int _port;
    
    public void SendEmail(string to, string subject, string body)
    {
        // Detalles de implementación ocultos
        ValidateEmail(to);
        ConnectToServer();
        Authenticate();
        SendMessage(to, subject, body);
        Disconnect();
    }
    
    private void ValidateEmail(string email) { /* ... */ }
    private void ConnectToServer() { /* ... */ }
    private void Authenticate() { /* ... */ }
    private void SendMessage(string to, string subject, string body) { /* ... */ }
    private void Disconnect() { /* ... */ }
}
```

## 📊 Modificadores de Acceso

| Modificador | Accesibilidad | Uso Recomendado |
|-------------|---------------|-----------------|
| **private** | Solo dentro de la clase | Campos internos, métodos auxiliares |
| **protected** | Clase y clases derivadas | Miembros para herencia |
| **internal** | Mismo ensamblado | Helpers internos del proyecto |
| **public** | Cualquier lugar | Interfaz pública de la clase |

## 🚀 Tips Avanzados

### 1. Usar Expression-Bodied Members

```csharp
// ✅ BIEN: Expression-bodied properties
public class Person
{
    private string _name;
    
    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }
}
```

### 2. Propiedades Init-Only

```csharp
// ✅ BIEN: Init-only properties (C# 9.0+)
public class Person
{
    public string Name { get; init; } = "Default Name";
    public int Age { get; init; }
}

// Uso:
var person = new Person { Name = "Alice", Age = 30 };
// person.Name = "Bob"; // Error - solo puede ser inicializado
```

### 3. Propiedades con Lazy Initialization

```csharp
// ✅ BIEN: Lazy initialization
public class DataService
{
    private List<string> _cache;
    
    public List<string> Cache
    {
        get
        {
            if (_cache == null)
                _cache = LoadCache();
            return _cache;
        }
    }
    
    private List<string> LoadCache() { /* ... */ }
}
```

### 4. Encapsulación de Dependencias

```csharp
// ✅ BIEN: Dependencias encapsuladas
public class OrderService
{
    private readonly IOrderRepository _repository;
    private readonly IEmailService _emailService;
    
    public OrderService(IOrderRepository repository, IEmailService emailService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
    }
    
    public void ProcessOrder(Order order)
    {
        _repository.Save(order);
        _emailService.SendConfirmation(order);
    }
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Encapsulation](https://docs.microsoft.com/dotnet/csharp/fundamentals/object-oriented/)
- [Microsoft Docs - Properties](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/properties)
- [Microsoft Docs - Access Modifiers](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)

