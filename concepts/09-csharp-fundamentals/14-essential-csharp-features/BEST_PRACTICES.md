# Mejores Prácticas: Top 20 Características Esenciales de C#

## ✅ Reglas de Oro

### 1. Usar Genéricos para Reutilización

```csharp
// ✅ BIEN: Genérico reutilizable
public class Repository<T> where T : class
{
    private readonly List<T> _items = new();
    public void Add(T item) => _items.Add(item);
}

// ❌ MAL: Clase específica para cada tipo
public class UserRepository { }
public class OrderRepository { }
```

### 2. Preferir Async/Await sobre Síncrono para I/O

```csharp
// ✅ BIEN: Async para I/O
public async Task<string> GetDataAsync()
{
    using var httpClient = new HttpClient();
    return await httpClient.GetStringAsync("https://api.example.com");
}

// ❌ MAL: Bloqueante
public string GetData()
{
    using var httpClient = new HttpClient();
    return httpClient.GetStringAsync("https://api.example.com").Result; // Bloquea
}
```

### 3. Usar Records para DTOs y Value Objects

```csharp
// ✅ BIEN: Record para DTOs
public record UserDto(string Name, int Age);

// ❌ MAL: Clase mutable para DTOs
public class UserDto
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}
```

### 4. Aprovechar Expression Body Members

```csharp
// ✅ BIEN: Expression body
public string FullName => $"{FirstName} {LastName}";
public int Add(int x, int y) => x + y;

// ❌ MAL: Método tradicional para casos simples
public string FullName
{
    get { return $"{FirstName} {LastName}"; }
}
```

### 5. Usar Tuplas para Múltiples Valores de Retorno

```csharp
// ✅ BIEN: Tupla para múltiples valores
public (bool Success, string Message, int Count) ProcessData()
{
    return (true, "Processed successfully", 42);
}

// ❌ MAL: Crear clase solo para retornar múltiples valores
public class ProcessResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int Count { get; set; }
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Abusar de Dynamic

```csharp
// ❌ MAL: Usar dynamic innecesariamente
dynamic result = CalculateValue();
int value = result; // Pérdida de seguridad de tipos

// ✅ BIEN: Usar tipos específicos cuando sea posible
int result = CalculateValue();
```

### 2. No Manejar Excepciones en Async

```csharp
// ❌ MAL: Ignorar excepciones async
public async Task ProcessAsync()
{
    await SomeAsyncOperation(); // Si falla, excepción no manejada
}

// ✅ BIEN: Manejar excepciones
public async Task ProcessAsync()
{
    try
    {
        await SomeAsyncOperation();
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error processing");
        throw;
    }
}
```

### 3. Usar Records Incorrectamente

```csharp
// ❌ MAL: Usar record para clases con comportamiento mutable
public record BankAccount
{
    public decimal Balance { get; set; } // Mutable - no debería ser record
}

// ✅ BIEN: Usar record para datos inmutables
public record BankAccount(decimal Balance); // Inmutable
```

### 4. No Usar Global Using Correctamente

```csharp
// ❌ MAL: Repetir using en cada archivo
// Archivo1.cs
using System;
using System.Collections.Generic;
using System.Linq;

// Archivo2.cs
using System;
using System.Collections.Generic;
using System.Linq;

// ✅ BIEN: Global using
// GlobalUsings.cs
global using System;
global using System.Collections.Generic;
global using System.Linq;
```

## 🎯 Casos de Uso Específicos

### 1. Genéricos con Constraints

```csharp
// ✅ BIEN: Constraints apropiados
public class Repository<T> where T : class, IEntity, new()
{
    public T Create()
    {
        return new T(); // new() constraint permite esto
    }
}
```

### 2. Async en LINQ

```csharp
// ✅ BIEN: Async en LINQ
var results = await Task.WhenAll(
    urls.Select(url => httpClient.GetStringAsync(url))
);
```

### 3. Extension Methods para Utilidades

```csharp
// ✅ BIEN: Extension methods para utilidades comunes
public static class StringExtensions
{
    public static bool IsValidEmail(this string email)
        => email.Contains("@") && email.Contains(".");
    
    public static string ToTitleCase(this string str)
        => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
}
```

### 4. Records con Métodos

```csharp
// ✅ BIEN: Record con métodos
public record Person(string Name, int Age)
{
    public string DisplayName => $"{Name} ({Age})";
    
    public Person WithAge(int newAge) => this with { Age = newAge };
}
```

### 5. Collection Expressions con Spread

```csharp
// ✅ BIEN: Combinar colecciones con spread
int[] first = [1, 2, 3];
int[] second = [4, 5, 6];
int[] third = [7, 8, 9];
int[] all = [..first, ..second, ..third];
```

## 💡 Pro Tips

### 1. Usar Deconstrucción para Múltiples Asignaciones

```csharp
// ✅ BIEN: Deconstrucción múltiple
var (name, age, email) = GetPersonData();
```

### 2. Combinar Pattern Matching con Switch Expressions

```csharp
// ✅ BIEN: Pattern matching avanzado
var result = obj switch
{
    string s when s.Length > 10 => $"Long string: {s}",
    int i when i > 0 => $"Positive number: {i}",
    null => "Null value",
    _ => "Unknown"
};
```

### 3. Usar required para DTOs Críticos

```csharp
// ✅ BIEN: required para propiedades críticas
public class OrderDto
{
    public required int OrderId { get; set; }
    public required decimal Amount { get; set; }
    public string? Notes { get; set; } // Opcional
}
```

### 4. Extension Methods para Fluent APIs

```csharp
// ✅ BIEN: Extension methods para fluent APIs
public static class QueryExtensions
{
    public static IQueryable<T> WhereActive<T>(this IQueryable<T> query)
        where T : IActive
        => query.Where(x => x.IsActive);
}
```

## 📊 Tabla de Decisión: Qué Característica Usar

| Escenario | Característica Recomendada | Razón |
|-----------|---------------------------|-------|
| Múltiples valores de retorno | Tuplas | Simple, sin crear clase |
| DTOs inmutables | Records | Igualdad por valor, inmutabilidad |
| Operaciones I/O | Async/Await | No bloquea hilo principal |
| Extender tipos existentes | Extension Methods | Sin modificar código fuente |
| Código reutilizable | Genéricos | Type-safe, mejor rendimiento |
| Propiedades obligatorias | required | Seguridad en compilación |
| Métodos simples | Expression Body | Más conciso |
| Inicialización de colecciones | Collection Expressions | Sintaxis moderna |
| APIs dinámicas | dynamic | Flexibilidad necesaria |
| Dividir clases grandes | Partial Classes | Organización |

## 📚 Recursos Adicionales

- [Microsoft Docs - C# Language Reference](https://docs.microsoft.com/dotnet/csharp/language-reference/)
- [Microsoft Docs - C# Guide](https://docs.microsoft.com/dotnet/csharp/)
- [C# Version History](https://docs.microsoft.com/dotnet/csharp/whats-new/)

