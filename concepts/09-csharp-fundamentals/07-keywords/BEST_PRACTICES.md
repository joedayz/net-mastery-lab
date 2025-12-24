# Mejores Prácticas: Keywords en C#

## ✅ Reglas de Oro

### 1. Usar Access Modifiers Apropiados

```csharp
// ✅ BIEN: Usar el nivel de acceso más restrictivo posible
public class OrderService
{
    private readonly IOrderRepository _repository; // private: solo esta clase
    protected int OrderCount { get; set; } // protected: clase y derivadas
    public void ProcessOrder() { } // public: necesario para API pública
}

// ❌ MAL: Exponer demasiado
public class OrderService
{
    public IOrderRepository Repository; // ❌ Campo público
    public int InternalCounter; // ❌ Debería ser private
}
```

### 2. Preferir var para Tipos Obvios

```csharp
// ✅ BIEN: var cuando el tipo es obvio
var name = "John";
var age = 30;
var orders = new List<Order>();

// ❌ MAL: var cuando el tipo no es claro
var result = GetData(); // ¿Qué tipo es result?
var value = Process(); // ¿Qué devuelve Process()?

// ✅ MEJOR: Tipo explícito cuando no es claro
List<Order> orders = GetOrders();
int count = GetCount();
```

### 3. Usar async/await Correctamente

```csharp
// ✅ BIEN: async/await para operaciones asíncronas
public async Task<Order> GetOrderAsync(int id)
{
    return await _repository.GetByIdAsync(id);
}

// ❌ MAL: Blocking async code
public Order GetOrder(int id)
{
    return _repository.GetByIdAsync(id).Result; // ❌ Deadlock potencial
}

// ❌ MAL: async void (excepto event handlers)
public async void ProcessOrder() // ❌ No usar async void
{
    await ProcessAsync();
}
```

### 4. Usar try-catch Específicamente

```csharp
// ✅ BIEN: Capturar excepciones específicas
try
{
    var result = Divide(a, b);
}
catch (DivideByZeroException ex)
{
    // Manejar específicamente
}
catch (OverflowException ex)
{
    // Manejar overflow
}

// ❌ MAL: Capturar Exception genérica
try
{
    var result = Divide(a, b);
}
catch (Exception ex) // ❌ Demasiado genérico
{
    // Perdemos información sobre el tipo específico
}
```

### 5. Usar nameof para Referencias Seguras

```csharp
// ✅ BIEN: nameof para referencias seguras
public void Validate(string name)
{
    if (string.IsNullOrEmpty(name))
        throw new ArgumentNullException(nameof(name));
}

// ❌ MAL: String literal
public void Validate(string name)
{
    if (string.IsNullOrEmpty(name))
        throw new ArgumentNullException("name"); // ❌ Puede romperse al renombrar
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Usar Keywords como Identificadores

```csharp
// ❌ MAL: Usar keywords como nombres
int class = 5; // Error
string @public = "test"; // Funciona pero no recomendado

// ✅ BIEN: Usar nombres descriptivos
int classCount = 5;
string publicName = "test";
```

### 2. Olvidar break en switch

```csharp
// ❌ MAL: Olvidar break (a menos que uses return)
switch (status)
{
    case OrderStatus.Pending:
        Console.WriteLine("Pending");
        // ❌ Falta break - fallthrough
    case OrderStatus.Processing:
        Console.WriteLine("Processing");
        break;
}

// ✅ BIEN: Usar break o return
switch (status)
{
    case OrderStatus.Pending:
        Console.WriteLine("Pending");
        break; // ✅ Correcto
    case OrderStatus.Processing:
        Console.WriteLine("Processing");
        break;
}

// ✅ BIEN: Usar switch expression (C# 8.0+)
var message = status switch
{
    OrderStatus.Pending => "Pending",
    OrderStatus.Processing => "Processing",
    _ => "Unknown"
};
```

### 3. No Usar using para Recursos

```csharp
// ❌ MAL: No usar using
var stream = new FileStream("file.txt", FileMode.Open);
// ... código ...
stream.Dispose(); // ❌ Puede olvidarse o fallar antes

// ✅ BIEN: Usar using statement
using (var stream = new FileStream("file.txt", FileMode.Open))
{
    // ... código ...
} // Se dispone automáticamente

// ✅ MEJOR: using declaration (C# 8.0+)
using var stream = new FileStream("file.txt", FileMode.Open);
// Se dispone al final del scope
```

### 4. Usar is en lugar de as cuando sea Apropiado

```csharp
// ❌ MAL: Usar as y luego verificar null
var str = obj as string;
if (str != null)
{
    Console.WriteLine(str);
}

// ✅ BIEN: Usar is pattern matching
if (obj is string str)
{
    Console.WriteLine(str);
}
```

## 🎯 Casos de Uso Específicos

### 1. Access Modifiers en APIs Públicas

```csharp
// ✅ BIEN: API pública bien diseñada
public class OrderService
{
    // Público: parte de la API
    public async Task<Order> CreateOrderAsync(CreateOrderDto dto)
    {
        ValidateOrder(dto);
        return await SaveOrderAsync(dto);
    }
    
    // Private: implementación interna
    private void ValidateOrder(CreateOrderDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));
    }
    
    // Protected: para clases derivadas
    protected virtual async Task<Order> SaveOrderAsync(CreateOrderDto dto)
    {
        // Implementación base
    }
}
```

### 2. static para Utilidades

```csharp
// ✅ BIEN: Métodos estáticos para utilidades
public static class StringHelper
{
    public static string Capitalize(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
        
        return char.ToUpper(input[0]) + input.Substring(1);
    }
}

// Uso sin instancia
var result = StringHelper.Capitalize("hello");
```

### 3. virtual/override para Polimorfismo

```csharp
// ✅ BIEN: virtual/override para comportamiento polimórfico
public abstract class PaymentProcessor
{
    public virtual void ProcessPayment(decimal amount)
    {
        ValidateAmount(amount);
        ExecutePayment(amount);
    }
    
    protected abstract void ExecutePayment(decimal amount);
}

public class CreditCardProcessor : PaymentProcessor
{
    protected override void ExecutePayment(decimal amount)
    {
        // Implementación específica
    }
}
```

### 4. yield para Iteradores Eficientes

```csharp
// ✅ BIEN: yield para iteradores eficientes
public IEnumerable<int> GetEvenNumbers(int max)
{
    for (int i = 0; i < max; i++)
    {
        if (i % 2 == 0)
            yield return i; // Eficiente: lazy evaluation
    }
}

// Uso
foreach (var number in GetEvenNumbers(100))
{
    Console.WriteLine(number);
}
```

### 5. where para Restricciones Genéricas

```csharp
// ✅ BIEN: Restricciones genéricas con where
public class Repository<T> where T : class, IEntity, new()
{
    public T Create()
    {
        return new T(); // new() constraint permite instanciación
    }
    
    public void Save(T entity)
    {
        // IEntity constraint permite usar métodos de IEntity
        entity.Id = GenerateId();
    }
}
```

## 🚀 Tips Avanzados

### 1. Combinar Keywords Modernos

```csharp
// ✅ BIEN: Combinar características modernas
public async Task<IEnumerable<string>> GetNamesAsync()
{
    using var client = new HttpClient();
    var response = await client.GetAsync("api/users");
    
    if (response is HttpResponseMessage msg && msg.IsSuccessStatusCode)
    {
        var content = await msg.Content.ReadAsStringAsync();
        return ParseNames(content);
    }
    
    return Enumerable.Empty<string>();
}
```

### 2. Usar switch Expressions

```csharp
// ✅ BIEN: switch expression (C# 8.0+)
var message = status switch
{
    OrderStatus.Pending => "Order is pending",
    OrderStatus.Processing => "Order is processing",
    OrderStatus.Completed => "Order completed",
    OrderStatus.Cancelled => "Order cancelled",
    _ => "Unknown status"
};

// Con when clause
var result = value switch
{
    int i when i > 0 => "Positive",
    int i when i < 0 => "Negative",
    int i => "Zero",
    _ => "Not a number"
};
```

### 3. Usar record para Inmutabilidad

```csharp
// ✅ BIEN: record para datos inmutables
public record Person(string Name, int Age);

// Uso con with expression
var person = new Person("John", 30);
var updated = person with { Age = 31 };
```

### 4. Usar partial para Organización

```csharp
// ✅ BIEN: partial para dividir clases grandes
// Person.cs
public partial class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// Person.Validation.cs
public partial class Person
{
    public bool IsValid() => !string.IsNullOrEmpty(Name) && Age > 0;
}

// Person.Serialization.cs
public partial class Person
{
    public string ToJson() => JsonSerializer.Serialize(this);
}
```

## 📊 Tabla de Decisión: Cuándo Usar Cada Keyword

| Keyword | Cuándo Usar | Ejemplo |
|---------|-------------|---------|
| **public** | API pública, acceso externo | Métodos públicos de servicio |
| **private** | Implementación interna | Campos privados, métodos helper |
| **protected** | Herencia, clases derivadas | Métodos virtuales, propiedades |
| **static** | Utilidades, sin estado | Helpers, extensiones |
| **virtual** | Permite override | Métodos base polimórficos |
| **override** | Implementa virtual | Métodos en clases derivadas |
| **abstract** | Debe implementarse | Clases base, interfaces |
| **async/await** | Operaciones asíncronas | I/O, llamadas API |
| **var** | Tipo obvio | LINQ, tipos complejos |
| **nameof** | Referencias seguras | ArgumentNullException |
| **yield** | Iteradores eficientes | Generadores, lazy evaluation |
| **using** | Recursos desechables | Streams, conexiones |

## 💡 Pro Tips

### 1. Siempre Usar el Nivel de Acceso Más Restrictivo

```csharp
// Empieza con private, luego sube según necesidad
private → protected → internal → public
```

### 2. Preferir async/await sobre Task.Result

```csharp
// ❌ MAL: Blocking
var result = GetDataAsync().Result;

// ✅ BIEN: Async all the way
var result = await GetDataAsync();
```

### 3. Usar nameof para Refactoring Seguro

```csharp
// nameof se actualiza automáticamente al renombrar
throw new ArgumentNullException(nameof(parameter));
```

### 4. Combinar Keywords para Máximo Beneficio

```csharp
// Combinar async, await, using, is, nameof
public async Task<string> ProcessAsync(string input)
{
    ArgumentNullException.ThrowIfNull(input, nameof(input));
    
    using var client = new HttpClient();
    var response = await client.GetAsync(input);
    
    if (response is HttpResponseMessage msg && msg.IsSuccessStatusCode)
    {
        return await msg.Content.ReadAsStringAsync();
    }
    
    throw new HttpRequestException("Request failed");
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - C# Keywords](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/)
- [Microsoft Docs - C# Language Reference](https://docs.microsoft.com/dotnet/csharp/language-reference/)
- [C# Coding Conventions](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)

