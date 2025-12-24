# Mejores Prácticas: C# Enhancements in .NET 9.0

## ✅ Reglas de Oro

### 1. Usar Primary Constructors para Clases de Datos

```csharp
// ✅ BIEN: Primary Constructor para clases de datos
public class Product(int id, string name, decimal price)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public decimal Price { get; } = price;
}

// ❌ MAL: Constructor tradicional verboso
public class Product
{
    private readonly int _id;
    private readonly string _name;
    private readonly decimal _price;
    
    public Product(int id, string name, decimal price)
    {
        _id = id;
        _name = name;
        _price = price;
    }
    
    public int Id { get; } = _id;
    public string Name { get; } = _name;
    public decimal Price { get; } = _price;
}
```

### 2. Aprovechar Auto-Default Structs

```csharp
// ✅ BIEN: Confiar en auto-default para structs
public struct Measurement
{
    public double Value { get; set; }
    public string Unit { get; set; }
}

var measurement = new Measurement();
// No necesitas inicializar manualmente - valores por defecto garantizados

// ❌ MAL: Inicialización manual innecesaria
public struct Measurement
{
    public double Value { get; set; } = 0.0;  // Innecesario en .NET 9.0
    public string Unit { get; set; } = null;  // Innecesario en .NET 9.0
}
```

### 3. Usar Enhanced Pattern Matching para Lógica Compleja

```csharp
// ✅ BIEN: Pattern matching para lógica compleja
var result = data switch
{
    { Type: "order", Status: "pending" } => ProcessPendingOrder(data),
    { Type: "order", Status: "shipped" } => ProcessShippedOrder(data),
    { Type: "product" } => ProcessProduct(data),
    _ => HandleUnknown(data)
};

// ❌ MAL: If-else anidados complejos
string result;
if (data != null)
{
    if (data.Type == "order")
    {
        if (data.Status == "pending")
        {
            result = ProcessPendingOrder(data);
        }
        else if (data.Status == "shipped")
        {
            result = ProcessShippedOrder(data);
        }
        // ...
    }
    // ...
}
```

## ⚠️ Consideraciones Importantes

### 1. Primary Constructors y Validación

```csharp
// ⚠️ IMPORTANTE: Primary constructors no permiten validación directa
public class Person(string name, int age)
{
    // No puedes hacer: if (age < 0) throw new ArgumentException();
    // Necesitas validación en propiedades
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    public int Age { get; } = age >= 0 ? age : throw new ArgumentException("Age must be non-negative");
}
```

### 2. Auto-Default Structs y Valores por Defecto

```csharp
// ⚠️ IMPORTANTE: Los valores por defecto pueden no ser apropiados para todos los casos
public struct Temperature
{
    public double Celsius { get; set; }  // 0.0 por defecto - puede no ser válido
}

// Considera usar nullable o validación
public struct Temperature
{
    public double? Celsius { get; set; }  // null por defecto - más seguro
}
```

### 3. Pattern Matching y Complejidad

```csharp
// ⚠️ IMPORTANTE: Evita patterns demasiado complejos
// ❌ MAL: Pattern demasiado complejo
var result = data switch
{
    { A: { B: { C: { D: > 10 } } } } => "Too nested",
    // ...
};

// ✅ BIEN: Patterns claros y legibles
var result = data switch
{
    { Value: > 10 } => "High value",
    { Value: <= 10 } => "Low value",
    _ => "Unknown"
};
```

## 🎯 Casos de Uso Específicos

### 1. Primary Constructor para Service Class

```csharp
// ✅ BIEN: Service class con Primary Constructor
public class OrderService(IOrderRepository repository, ILogger<OrderService> logger)
{
    public async Task<Order> GetOrderAsync(int id)
    {
        logger.LogInformation("Getting order {OrderId}", id);
        return await repository.GetByIdAsync(id);
    }
}
```

### 2. Auto-Default Struct para Coordenadas

```csharp
// ✅ BIEN: Struct con auto-default
public struct Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }
}

var coord = new Coordinate();
// X, Y automáticamente inicializados a 0
```

### 3. Enhanced Pattern Matching para Lógica de Negocio

```csharp
// ✅ BIEN: Pattern matching para lógica de negocio
var status = order switch
{
    { Status: OrderStatus.Pending, Total: > 1000 } => "High-value pending order",
    { Status: OrderStatus.Shipped, Items.Count: > 10 } => "Large shipped order",
    { Status: OrderStatus.Cancelled } => "Order cancelled",
    _ => "Standard order"
};
```

## 📊 Tabla de Decisión

| Escenario | Recomendación | Razón |
|-----------|---------------|-------|
| Clase con pocos parámetros | Primary Constructor | Reduce boilerplate |
| Service class con DI | Primary Constructor | Ideal para DI |
| Struct simple | Auto-Default Struct | Inicialización automática |
| Lógica condicional compleja | Enhanced Pattern Matching | Más legible |
| Records o clases de datos | Primary Constructor | Perfecto para datos |

## 💡 Pro Tips

### 1. Combinar Primary Constructor con Records

```csharp
// ✅ BIEN: Record con Primary Constructor para máxima inmutabilidad
public record Person(string Name, int Age);

var person = new Person("Alice", 30);
```

### 2. Usar Auto-Default Structs con Validación

```csharp
// ✅ BIEN: Auto-default con validación cuando sea necesario
public struct Measurement
{
    private double _value;
    
    public double Value
    {
        get => _value;
        set => _value = value >= 0 ? value : throw new ArgumentException("Value must be non-negative");
    }
}
```

### 3. Pattern Matching con List Patterns

```csharp
// ✅ BIEN: List patterns mejorados
var result = numbers switch
{
    [1, 2, 3] => "Exact sequence",
    [1, .. var middle, 3] => $"Starts with 1, ends with 3",
    [] => "Empty",
    _ => "Other"
};
```

## 📚 Recursos Adicionales

- [Microsoft Docs - C# What's New](https://learn.microsoft.com/dotnet/csharp/whats-new/)
- [Microsoft Docs - Primary Constructors](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-12#primary-constructors)
- [Microsoft Docs - Pattern Matching](https://learn.microsoft.com/dotnet/csharp/pattern-matching)
- [.NET 9 Performance Improvements](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-9/)

