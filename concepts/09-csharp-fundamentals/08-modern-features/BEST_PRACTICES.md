# Mejores Prácticas: Modern C# Features

## ✅ Reglas de Oro

### 1. Usar Null-Conditional Operator para Acceso Seguro

```csharp
// ✅ BIEN: Null-conditional operator
var city = order?.Customer?.Address?.City ?? "Unknown";

// ❌ MAL: Verificaciones anidadas verbosas
string? city = null;
if (order != null && order.Customer != null && order.Customer.Address != null)
{
    city = order.Customer.Address.City ?? "Unknown";
}
```

### 2. Preferir Pattern Matching sobre Type Checking Tradicional

```csharp
// ✅ BIEN: Pattern matching
if (obj is string str)
{
    Console.WriteLine(str.ToUpper());
}

// ❌ MAL: Type checking tradicional
if (obj is string)
{
    string str = (string)obj;
    Console.WriteLine(str.ToUpper());
}
```

### 3. Siempre Usar 'using' para Recursos Desechables

```csharp
// ✅ BIEN: using declaration
using var stream = new FileStream("file.txt", FileMode.Open);
var content = await stream.ReadToEndAsync();

// ❌ MAL: Sin using
var stream = new FileStream("file.txt", FileMode.Open);
var content = await stream.ReadToEndAsync();
// Recurso no se dispone si hay excepción
```

### 4. Usar Target-Typed 'new' para Reducir Verbosidad

```csharp
// ✅ BIEN: Target-typed new
Dictionary<string, List<int>> dict = new();
List<string> items = new();

// ❌ MAL: Tipo repetido
Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
List<string> items = new List<string>();
```

### 5. Siempre Usar 'nameof' en Lugar de String Literals

```csharp
// ✅ BIEN: nameof (seguro ante refactoring)
public void Process(string name)
{
    ArgumentNullException.ThrowIfNull(name, nameof(name));
}

// ❌ MAL: String literal (frágil ante refactoring)
public void Process(string name)
{
    if (name == null)
        throw new ArgumentNullException("name");
}
```

### 6. Preferir 'as' sobre Casting cuando sea Apropiado

```csharp
// ✅ BIEN: Operador 'as' para conversión segura
var str = obj as string;
if (str != null)
{
    Console.WriteLine(str);
}

// ⚠️ CUIDADO: Casting puede lanzar excepción
try
{
    var str = (string)obj;
    Console.WriteLine(str);
}
catch (InvalidCastException)
{
    // Manejo de error
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Abusar del Null-Conditional Operator

```csharp
// ⚠️ CUIDADO: Demasiados null-conditional pueden hacer código difícil de leer
var result = obj?.Property?.SubProperty?.Value?.ToString()?.ToUpper();

// ✅ MEJOR: Considerar extraer a variable o método
var value = obj?.Property?.SubProperty?.Value;
var result = value?.ToString()?.ToUpper();
```

### 2. Olvidar Null-Coalescing cuando sea Necesario

```csharp
// ❌ MAL: Puede retornar null
var name = person?.Name;

// ✅ BIEN: Proporcionar valor por defecto
var name = person?.Name ?? "Unknown";
```

### 3. No Usar Pattern Matching en Switch Expressions

```csharp
// ❌ MAL: Switch tradicional verboso
string GetMessage(int value)
{
    switch (value)
    {
        case 0:
            return "Zero";
        case 1:
            return "One";
        default:
            return "Other";
    }
}

// ✅ BIEN: Switch expression con pattern matching
string GetMessage(int value) => value switch
{
    0 => "Zero",
    1 => "One",
    _ => "Other"
};
```

### 4. Usar 'as' sin Verificar Null

```csharp
// ❌ MAL: No verificar null después de 'as'
var str = obj as string;
Console.WriteLine(str.Length); // Puede lanzar NullReferenceException

// ✅ BIEN: Verificar null
var str = obj as string;
if (str != null)
{
    Console.WriteLine(str.Length);
}

// ✅ MEJOR: Usar pattern matching
if (obj is string str)
{
    Console.WriteLine(str.Length);
}
```

## 🎯 Casos de Uso Específicos

### 1. Null Handling en APIs

```csharp
// ✅ BIEN: Null handling completo en API
public class OrderService
{
    public async Task<OrderDto?> GetOrderAsync(int id)
    {
        var order = await _repository.GetByIdAsync(id);
        return order != null ? MapToDto(order) : null;
    }
    
    public string GetCustomerCity(Order? order)
    {
        return order?.Customer?.Address?.City ?? "Unknown";
    }
}
```

### 2. Pattern Matching para Validación

```csharp
// ✅ BIEN: Pattern matching para validación compleja
public bool IsValidOrder(Order order) => order switch
{
    { Status: OrderStatus.Pending, Total: > 0 } => true,
    { Status: OrderStatus.Processing } => true,
    { Status: OrderStatus.Completed, PaymentDate: not null } => true,
    _ => false
};
```

### 3. Resource Management en Async Methods

```csharp
// ✅ BIEN: using con async
public async Task<string> ReadFileAsync(string path)
{
    using var reader = new StreamReader(path);
    return await reader.ReadToEndAsync();
}
```

### 4. Target-Typed new en Inicialización

```csharp
// ✅ BIEN: Target-typed new en inicialización
public class Order
{
    public List<OrderItem> Items { get; set; } = new();
    public Dictionary<string, object> Metadata { get; set; } = new();
    public DateTime CreatedAt { get; set; } = new();
}
```

### 5. nameof en Property Change Notifications

```csharp
// ✅ BIEN: nameof en INotifyPropertyChanged
public class ViewModel : INotifyPropertyChanged
{
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
    
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

## 🚀 Tips Avanzados

### 1. Combinar Múltiples Características Modernas

```csharp
// ✅ BIEN: Combinar null-conditional, pattern matching, y nameof
public string ProcessOrder(Order? order)
{
    ArgumentNullException.ThrowIfNull(order, nameof(order));
    
    return order switch
    {
        { Status: OrderStatus.Pending } => "Processing...",
        { Status: OrderStatus.Completed, Customer: { Address: { City: not null } } } 
            => $"Delivered to {order.Customer.Address.City}",
        _ => "Unknown status"
    };
}
```

### 2. Usar Pattern Matching con Relational Patterns

```csharp
// ✅ BIEN: Relational patterns para rangos
public string GetGrade(int score) => score switch
{
    >= 90 => "A",
    >= 80 => "B",
    >= 70 => "C",
    >= 60 => "D",
    _ => "F"
};
```

### 3. Null-Coalescing Assignment para Inicialización Lazy

```csharp
// ✅ BIEN: Null-coalescing assignment
private List<string>? _items;

public List<string> Items
{
    get
    {
        _items ??= new List<string>();
        return _items;
    }
}
```

### 4. Usar 'as' con Null-Coalescing

```csharp
// ✅ BIEN: Combinar 'as' con null-coalescing
var name = obj as string ?? "Unknown";
var count = items?.Count() ?? 0;
```

### 5. Pattern Matching con Logical Patterns

```csharp
// ✅ BIEN: Logical patterns para condiciones complejas
public bool IsValid(int value) => value switch
{
    > 0 and < 100 => true,
    < 0 or > 100 => false,
    _ => false
};
```

## 📊 Tabla de Decisión: Cuándo Usar Cada Característica

| Característica | Cuándo Usar | Ejemplo |
|----------------|-------------|---------|
| **Null-conditional (`?.`)** | Acceso a propiedades que pueden ser null | `person?.Address?.City` |
| **Null-coalescing (`??`)** | Valor por defecto para null | `name ?? "Unknown"` |
| **Pattern Matching** | Lógica condicional compleja | `obj switch { ... }` |
| **using Declaration** | Recursos desechables | `using var stream = ...` |
| **Target-typed new** | Reducir verbosidad de tipos | `List<string> list = new();` |
| **nameof** | Referencias seguras ante refactoring | `nameof(property)` |
| **as operator** | Conversión segura de tipos | `obj as string` |

## 💡 Pro Tips

### 1. Preferir Compile-Time Safety sobre Runtime Checks

```csharp
// ✅ BIEN: Compile-time safety con nullable reference types
public void Process(string? name)
{
    ArgumentNullException.ThrowIfNull(name, nameof(name));
    // name es no-null después de la validación
    Console.WriteLine(name.Length);
}
```

### 2. Usar Pattern Matching para Simplificar Lógica Compleja

```csharp
// ✅ BIEN: Pattern matching simplifica lógica compleja
var result = value switch
{
    int i when i > 0 => $"Positive: {i}",
    int i when i < 0 => $"Negative: {i}",
    string s => $"String: {s}",
    null => "Null",
    _ => "Unknown"
};
```

### 3. Combinar Características para Máximo Beneficio

```csharp
// ✅ BIEN: Combinar múltiples características modernas
public async Task<string> ProcessAsync(Order? order)
{
    var city = order?.Customer?.Address?.City ?? "Unknown";
    var status = order?.Status switch
    {
        OrderStatus.Pending => "Processing",
        OrderStatus.Completed => "Done",
        _ => "Unknown"
    };
    
    return $"{status} - {city}";
}
```

### 4. Usar nameof para Logging Estructurado

```csharp
// ✅ BIEN: nameof en logging estructurado
logger.LogInformation(
    "Processing {OrderId} for {CustomerName}", 
    order.Id, 
    order.Customer?.Name ?? "Unknown"
);
```

### 7. Usar Simplified params en C# 13

```csharp
// ✅ BIEN: Pasar colecciones directamente (C# 13)
var items = new List<string> { "Item1", "Item2", "Item3" };
ProcessItems(items); // Sin conversión necesaria

// ❌ MAL: Conversión explícita innecesaria (C# 13)
var items = new List<string> { "Item1", "Item2", "Item3" };
ProcessItems(items.ToArray()); // Innecesario en C# 13
```

### Compatibilidad con Versiones Anteriores

```csharp
// ⚠️ NOTA: Esta característica requiere C# 13
// Para versiones anteriores, sigue siendo necesario .ToArray()

#if NET8_0_OR_GREATER
    // C# 13: Sin conversión
    ProcessItems(items);
#else
    // Versiones anteriores: Conversión explícita
    ProcessItems(items.ToArray());
#endif
```

### 8. Usar System.Threading.Lock en .NET 9

```csharp
// ✅ BIEN: System.Threading.Lock en .NET 9
public class ThreadSafeService
{
    private System.Threading.Lock _lock = new System.Threading.Lock();
    
    public void DoWork()
    {
        lock (_lock)
        {
            // Código thread-safe
        }
    }
}

// ❌ MAL: object lock tradicional (menos optimizado)
public class ThreadSafeService
{
    private object _lock = new object();
    
    public void DoWork()
    {
        lock (_lock)
        {
            // Funciona pero menos optimizado
        }
    }
}
```

### Consideraciones para System.Threading.Lock

```csharp
// ⚠️ NOTA: System.Threading.Lock requiere .NET 9+
#if NET9_0_OR_GREATER
    private System.Threading.Lock _lock = new System.Threading.Lock();
#else
    private object _lock = new object();
#endif
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Null-conditional operators](https://docs.microsoft.com/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-)
- [Microsoft Docs - Pattern Matching](https://docs.microsoft.com/dotnet/csharp/pattern-matching)
- [Microsoft Docs - using statement](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/using-statement)
- [Microsoft Docs - nameof operator](https://docs.microsoft.com/dotnet/csharp/language-reference/operators/nameof)
- [Microsoft Docs - C# 13 Features](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-13)

