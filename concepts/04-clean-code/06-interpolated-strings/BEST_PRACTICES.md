# Mejores Prácticas: Applying C# Interpolated Strings

## ✅ Reglas de Oro

### 1. Usa Interpolated Strings en lugar de string.Format

```csharp
// ❌ MAL: string.Format con placeholders posicionales
string message = string.Format("Name: {0}, Age: {1}", name, age);

// ✅ BIEN: Interpolated string
string message = $"Name: {name}, Age: {age}";
```

### 2. Usa expresiones directamente en la cadena

```csharp
// ✅ BIEN: Expresiones directamente en la cadena
var total = $"Total: ${price * quantity:F2}";
var result = $"Sum: {CalculateSum(a, b)}";

// ❌ MAL: Calcular primero y luego formatear
var calculation = price * quantity;
var total = string.Format("Total: ${0:F2}", calculation);
```

### 3. Usa especificadores de formato cuando sea necesario

```csharp
// ✅ BIEN: Especificadores de formato
var date = $"Today is {DateTime.Now:yyyy-MM-dd}";
var price = $"Price: {amount:C}";
var percentage = $"Progress: {progress:P}";
```

## ⚠️ Errores Comunes a Evitar

### 1. Mezclar string.Format con interpolated strings innecesariamente

```csharp
// ❌ MAL: Mezcla innecesaria
var message = string.Format($"Name: {name}, Age: {age}");

// ✅ BIEN: Solo interpolated string
var message = $"Name: {name}, Age: {age}";
```

### 2. Olvidar el prefijo $ en interpolated strings

```csharp
// ❌ MAL: Sin prefijo $, las llaves son literales
var message = "Name: {name}, Age: {age}"; // No interpola

// ✅ BIEN: Con prefijo $
var message = $"Name: {name}, Age: {age}"; // Interpola correctamente
```

### 3. Usar interpolated strings cuando string.Format es más apropiado

```csharp
// ⚠️ Si necesitas reutilizar el formato desde una fuente externa
var format = GetFormatFromConfig(); // "{0} - {1}"
var message = string.Format(format, name, age); // Más apropiado

// ✅ Para casos normales, usa interpolated strings
var message = $"{name} - {age}";
```

## 🎯 Casos de Uso Específicos

### 1. Mensajes de Logging

```csharp
// ✅ BIEN: Interpolated strings para logging
_logger.LogInformation($"User {userId} processed order {orderId}");

// ❌ MAL: string.Format
_logger.LogInformation(string.Format("User {0} processed order {1}", userId, orderId));
```

### 2. Construcción de URLs

```csharp
// ✅ BIEN: Interpolated strings para URLs
var apiUrl = $"https://api.example.com/users/{userId}/orders/{orderId}";
```

### 3. Mensajes de Error

```csharp
// ✅ BIEN: Interpolated strings para mensajes de error
throw new ArgumentException($"Invalid user ID: {userId}. User not found.");
```

### 4. SQL Queries (con precaución)

```csharp
// ⚠️ CUIDADO: Nunca uses interpolated strings directamente para SQL
// ❌ MAL: Vulnerable a SQL injection
var query = $"SELECT * FROM Users WHERE Id = {userId}";

// ✅ BIEN: Usa parámetros
var query = "SELECT * FROM Users WHERE Id = @userId";
// O usa Entity Framework que maneja esto automáticamente
```

### 5. Construcción de HTML/XML

```csharp
// ✅ BIEN: Interpolated strings para HTML simple
var html = $"<div class=\"user\">{userName}</div>";

// ✅ MEJOR: Para HTML complejo, usa verbatim strings
var html = $@"
<div class=""user"">
    <h1>{userName}</h1>
    <p>Age: {age}</p>
</div>";
```

## 📊 Comparación de Enfoques

| Aspecto | string.Format | Interpolated Strings |
|---------|---------------|---------------------|
| **Legibilidad** | ❌ Menos legible | ✅ Más legible |
| **Propenso a errores** | ❌ Más propenso | ✅ Menos propenso |
| **Mantenibilidad** | ❌ Difícil | ✅ Fácil |
| **Intuitivo** | ❌ Menos intuitivo | ✅ Más intuitivo |
| **Performance** | ✅ Similar | ✅ Similar |

## 🚀 Tips Avanzados

### 1. Combinar con Verbatim Strings

```csharp
// ✅ Interpolated + Verbatim strings para multilínea
var message = $@"
    User: {userName}
    Age: {age}
    Email: {email}
";
```

### 2. Usar con Expresiones Complejas

```csharp
// ✅ Expresiones complejas directamente
var summary = $"Order #{orderId}: {items.Count} items, Total: ${items.Sum(i => i.Price):F2}";
```

### 3. Formato Condicional

```csharp
// ✅ Formato condicional
var status = $"User is {(isActive ? "active" : "inactive")}";
var count = $"You have {unreadCount} {(unreadCount == 1 ? "message" : "messages")}";
```

### 4. Escapado de Llaves

```csharp
// ✅ Para llaves literales
var message = $"Price: {{price}}"; // Resultado: "Price: {price}"
var message = $"Price: {{{price}}}"; // Resultado: "Price: {100}"
```

### 5. Performance Considerations

```csharp
// ⚠️ Para muchas concatenaciones, considera StringBuilder
var sb = new StringBuilder();
for (int i = 0; i < 1000; i++)
{
    sb.AppendLine($"Item {i}: {GetItemName(i)}");
}
var result = sb.ToString();
```

## 🚀 Mejoras en .NET 9

### Enhanced Interpolated Strings

**.NET 9** introduce mejoras significativas en el rendimiento de interpolated strings:

- ✅ **Interpolated String Handlers**: Compilación más eficiente
- ✅ **Lazy Evaluation**: Los valores se evalúan solo cuando es necesario
- ✅ **Zero Memory Allocations**: En ciertos casos, cero asignaciones de memoria
- ✅ **Mejor Rendimiento**: Especialmente en structured logging

**Ejemplo:**
```csharp
// Misma sintaxis, mejor rendimiento en .NET 9
string name = "Shaheen";
int age = 30;
string intro = $"Name: {name}, Age: {age}";
```

**Beneficios:**
- 🚀 Más rápido sin cambiar código
- 💾 Menos memoria
- 📊 Ideal para logging intensivo
- ⚡ Optimización automática del compilador

## 📚 Recursos Adicionales

- [Microsoft Docs - String Interpolation](https://docs.microsoft.com/dotnet/csharp/language-reference/tokens/interpolated)
- [Microsoft Docs - Composite Formatting](https://docs.microsoft.com/dotnet/standard/base-types/composite-formatting)
- [.NET 9 Performance Improvements](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-9/)
- [C# String Interpolation Best Practices](https://docs.microsoft.com/dotnet/csharp/programming-guide/strings/)

