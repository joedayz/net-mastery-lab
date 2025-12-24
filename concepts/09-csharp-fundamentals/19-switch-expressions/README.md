# Switch Expression in C# 8: Clean, Fast, Elegant 🔄

## Introducción

Las **Switch Expressions** en C# 8 introducen una sintaxis más limpia y expresiva para reemplazar los tradicionales `switch` statements. Esta característica permite escribir código más conciso, legible y funcional, eliminando boilerplate y mejorando la calidad del código.

## 🚀 ¿Por Qué Importa?

### Beneficios Clave

- 🔹 **Say Goodbye to Boilerplate**: Elimina `break`, `case`, y llaves innecesarias
- 🔹 **One-liner Logic**: Lógica más concisa con mejor legibilidad
- 🔹 **Easier to Test**: Más fácil de testear, depurar y refactorizar
- 🔹 **Great for Mapping**: Perfecto para mapear planes, roles, enums y más
- 🔹 **Expression-bodied Members**: Se combina perfectamente con expression-bodied members

## 📖 ¿Qué son las Switch Expressions?

Las Switch Expressions son una forma más concisa de escribir lógica condicional que retorna valores. A diferencia de los `switch` statements tradicionales, las switch expressions son expresiones que producen un valor.

### Sintaxis Básica

```csharp
// Switch Expression
var result = value switch
{
    pattern1 => expression1,
    pattern2 => expression2,
    _ => defaultExpression  // Discard pattern para default
};
```

## 🔄 Comparación: Switch Statement vs Switch Expression

### Ejemplo: Subscription Plans

```csharp
// ❌ ANTES: Switch Statement tradicional (verboso)
string GetSubscriptionFeatures(string plan)
{
    switch (plan)
    {
        case "Free":
            return "Basic Access";
        case "Pro":
            return "Premium Access";
        case "Enterprise":
            return "All Features + Priority Support";
        default:
            return "Unknown Plan";
    }
}

// ✅ DESPUÉS: Switch Expression (limpio y conciso)
string GetSubscriptionFeatures(string plan) => plan switch
{
    "Free" => "Basic Access",
    "Pro" => "Premium Access",
    "Enterprise" => "All Features + Priority Support",
    _ => "Unknown Plan"
};
```

**Diferencias Clave:**
- ✅ **Sin `break`**: No necesitas `break` statements
- ✅ **Sin `case`**: Usa `=>` directamente
- ✅ **Expression-bodied**: Puede usarse con `=>` en métodos
- ✅ **Discard Pattern**: `_` reemplaza `default`
- ✅ **Más Conciso**: Menos líneas de código

## ✅ Perfect Use Cases

### 1. Subscription Plans 🔁

```csharp
string GetPlanFeatures(string plan) => plan switch
{
    "Free" => "Basic Access",
    "Pro" => "Premium Access + Analytics",
    "Enterprise" => "All Features + Priority Support + Custom Integration",
    _ => "Unknown Plan"
};

// Uso
var features = GetPlanFeatures("Pro");
Console.WriteLine(features); // "Premium Access + Analytics"
```

### 2. Status Codes 🔁

```csharp
string GetStatusMessage(int statusCode) => statusCode switch
{
    200 => "OK",
    201 => "Created",
    400 => "Bad Request",
    401 => "Unauthorized",
    404 => "Not Found",
    500 => "Internal Server Error",
    _ => "Unknown Status"
};

// Uso
var message = GetStatusMessage(404);
Console.WriteLine(message); // "Not Found"
```

### 3. User Roles 🔁

```csharp
string GetRolePermissions(string role) => role switch
{
    "Admin" => "Full Access",
    "Editor" => "Create, Edit, Delete",
    "Viewer" => "Read Only",
    "Guest" => "Limited Access",
    _ => "No Access"
};

// Uso
var permissions = GetRolePermissions("Editor");
Console.WriteLine(permissions); // "Create, Edit, Delete"
```

### 4. Enum Mapping 🔁

```csharp
public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

string GetStatusDescription(OrderStatus status) => status switch
{
    OrderStatus.Pending => "Order is pending review",
    OrderStatus.Processing => "Order is being processed",
    OrderStatus.Shipped => "Order has been shipped",
    OrderStatus.Delivered => "Order has been delivered",
    OrderStatus.Cancelled => "Order has been cancelled",
    _ => "Unknown status"
};

// Uso
var description = GetStatusDescription(OrderStatus.Shipped);
Console.WriteLine(description); // "Order has been shipped"
```

### 5. API Responses 🔁

```csharp
string FormatApiResponse(string endpoint, bool success) => (endpoint, success) switch
{
    ("/users", true) => "Users retrieved successfully",
    ("/users", false) => "Failed to retrieve users",
    ("/orders", true) => "Orders retrieved successfully",
    ("/orders", false) => "Failed to retrieve orders",
    (_, true) => "Request successful",
    (_, false) => "Request failed"
};

// Uso
var response = FormatApiResponse("/users", true);
Console.WriteLine(response); // "Users retrieved successfully"
```

## 🧠 Developer Tip: Combinar con Pattern Matching

Las Switch Expressions se combinan perfectamente con Pattern Matching y Expression-bodied members para un estilo más funcional y limpio.

### Ejemplo: Pattern Matching Completo

```csharp
// ✅ BIEN: Switch Expression con Pattern Matching
string GetPersonCategory(Person person) => person switch
{
    { Age: >= 18, IsActive: true } => "Active Adult",
    { Age: >= 18, IsActive: false } => "Inactive Adult",
    { Age: < 18, IsActive: true } => "Active Minor",
    { Age: < 18, IsActive: false } => "Inactive Minor",
    null => "Unknown Person",
    _ => "Invalid"
};

// ✅ BIEN: Con Relational Patterns
string GetGrade(int score) => score switch
{
    >= 90 => "A",
    >= 80 => "B",
    >= 70 => "C",
    >= 60 => "D",
    _ => "F"
};

// ✅ BIEN: Con Type Patterns
string ProcessData(object data) => data switch
{
    int i => $"Integer: {i}",
    string s => $"String: {s}",
    bool b => $"Boolean: {b}",
    null => "Null",
    _ => "Unknown type"
};
```

## 💡 Expression-Bodied Members

Las Switch Expressions se combinan perfectamente con expression-bodied members para código ultra-conciso.

```csharp
// ✅ BIEN: Expression-bodied method con switch expression
public class SubscriptionService
{
    public string GetFeatures(string plan) => plan switch
    {
        "Free" => "Basic Access",
        "Pro" => "Premium Access",
        "Enterprise" => "All Features",
        _ => "Unknown"
    };
    
    public decimal GetPrice(string plan) => plan switch
    {
        "Free" => 0m,
        "Pro" => 9.99m,
        "Enterprise" => 49.99m,
        _ => 0m
    };
}
```

## 🎯 Casos de Uso Avanzados

### 1. Múltiples Valores (Tuples)

```csharp
string GetAccessLevel(string role, bool isPremium) => (role, isPremium) switch
{
    ("Admin", _) => "Full Access",
    ("Editor", true) => "Premium Editor Access",
    ("Editor", false) => "Standard Editor Access",
    ("Viewer", true) => "Premium Viewer Access",
    ("Viewer", false) => "Standard Viewer Access",
    _ => "No Access"
};
```

### 2. Con When Clauses

```csharp
string GetDiscount(int quantity, decimal price) => (quantity, price) switch
{
    (>= 100, _) => "Bulk Discount: 20%",
    (>= 50, >= 1000m) => "Volume Discount: 15%",
    (>= 50, _) => "Volume Discount: 10%",
    (_, >= 5000m) => "High Value Discount: 5%",
    _ => "No Discount"
};
```

### 3. Con Records y Positional Patterns

```csharp
public record Point(int X, int Y);

string GetQuadrant(Point point) => point switch
{
    (0, 0) => "Origin",
    (>= 0, >= 0) => "Quadrant I",
    (< 0, >= 0) => "Quadrant II",
    (< 0, < 0) => "Quadrant III",
    (>= 0, < 0) => "Quadrant IV"
};
```

## 📊 Comparación Detallada

| Aspecto | Switch Statement | Switch Expression |
|---------|------------------|-------------------|
| **Sintaxis** | Verbosa con `case` y `break` | Concisa con `=>` |
| **Retorno** | Requiere `return` explícito | Retorna directamente |
| **Default** | `default:` | `_ =>` (discard pattern) |
| **Expression-bodied** | No compatible | Compatible con `=>` |
| **Líneas de Código** | Más líneas | Menos líneas |
| **Legibilidad** | Buena | Excelente |
| **Pattern Matching** | Limitado | Completo |

## ⚠️ Consideraciones Importantes

### 1. Exhaustividad

Las Switch Expressions deben ser exhaustivas (cubrir todos los casos posibles) o usar `_` para el caso por defecto.

```csharp
// ✅ BIEN: Exhaustivo con default
string GetStatus(OrderStatus status) => status switch
{
    OrderStatus.Pending => "Pending",
    OrderStatus.Processing => "Processing",
    OrderStatus.Shipped => "Shipped",
    _ => "Unknown"  // Default case requerido
};

// ⚠️ ADVERTENCIA: Sin default puede causar error si no es exhaustivo
string GetStatus(OrderStatus status) => status switch
{
    OrderStatus.Pending => "Pending",
    OrderStatus.Processing => "Processing",
    OrderStatus.Shipped => "Shipped"
    // Error si OrderStatus tiene más valores
};
```

### 2. No Side Effects

Las Switch Expressions deben ser puras (sin side effects). Para lógica compleja, usa switch statements.

```csharp
// ✅ BIEN: Switch Expression (sin side effects)
string GetMessage(int value) => value switch
{
    > 0 => "Positive",
    < 0 => "Negative",
    _ => "Zero"
};

// ❌ MAL: Switch Expression con side effects
string GetMessage(int value) => value switch
{
    > 0 => LogAndReturn("Positive"),  // Evitar side effects
    < 0 => LogAndReturn("Negative"),
    _ => "Zero"
};

// ✅ BIEN: Switch Statement para side effects
void ProcessValue(int value)
{
    switch (value)
    {
        case > 0:
            Log("Positive");
            ProcessPositive(value);
            break;
        case < 0:
            Log("Negative");
            ProcessNegative(value);
            break;
        default:
            Log("Zero");
            break;
    }
}
```

## 💡 Mejores Prácticas

### 1. Usar para Mapeo Simple

```csharp
// ✅ BIEN: Mapeo simple - perfecto para switch expression
string GetPlanName(string planCode) => planCode switch
{
    "F" => "Free",
    "P" => "Pro",
    "E" => "Enterprise",
    _ => "Unknown"
};
```

### 2. Combinar con Pattern Matching

```csharp
// ✅ BIEN: Pattern matching completo
bool IsValidOrder(Order order) => order switch
{
    { Total: > 0, Items.Count: > 0, Customer: not null } => true,
    { Total: 0 } => false,
    { Items.Count: 0 } => false,
    null => false,
    _ => false
};
```

### 3. Usar Expression-Bodied Members

```csharp
// ✅ BIEN: Expression-bodied con switch expression
public class OrderService
{
    public string GetStatusMessage(OrderStatus status) => status switch
    {
        OrderStatus.Pending => "Your order is pending",
        OrderStatus.Processing => "Your order is being processed",
        OrderStatus.Shipped => "Your order has been shipped",
        _ => "Unknown status"
    };
}
```

## 🎯 Cuándo Usar Switch Expressions

### ✅ Usa Switch Expressions cuando:
- Necesitas mapear valores a otros valores
- La lógica es simple y retorna un valor
- Quieres código más conciso y legible
- Trabajas con enums, strings, o tipos simples
- Combinas con Pattern Matching

### ❌ Evita Switch Expressions cuando:
- Necesitas side effects (logging, mutación de estado)
- La lógica es compleja con múltiples statements
- Necesitas ejecutar múltiples operaciones por caso
- Trabajas con código legacy que requiere switch statements

## 📚 Relación con Otros Conceptos

Este tema está relacionado con:
- **Pattern Matching**: `concepts/09-csharp-fundamentals/05-modern-linq-pattern-matching/` (switch expressions con patterns)
- **Modern C# Features**: `concepts/09-csharp-fundamentals/08-modern-features/` (pattern matching básico)
- **Expression-Bodied Members**: `concepts/09-csharp-fundamentals/14-essential-csharp-features/` (sintaxis `=>`)

## 🎯 Resumen

### ✅ Switch Expressions en C# 8

**Características Clave:**
- ✅ Sintaxis más concisa que switch statements
- ✅ Compatible con expression-bodied members
- ✅ Se combina perfectamente con Pattern Matching
- ✅ Elimina boilerplate (`break`, `case`)
- ✅ Usa discard pattern (`_`) para default

**Perfect Use Cases:**
- 🔁 Subscription Plans
- 🔁 Status Codes
- 🔁 User Roles
- 🔁 Enum Mapping
- 🔁 API Responses

**Developer Tip:**
- 🧠 Combina Switch Expressions con Pattern Matching y Expression-bodied members para un estilo más funcional y limpio

**Small syntax change, big impact on your code quality.**
- ✍️ Write less. Do more. Stay modern.

---

## 📚 Recursos Adicionales

- [Microsoft Docs - Switch Expressions](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/switch-expression)
- [Microsoft Docs - Pattern Matching](https://learn.microsoft.com/dotnet/csharp/pattern-matching)
- [C# 8.0 Features](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-8)

