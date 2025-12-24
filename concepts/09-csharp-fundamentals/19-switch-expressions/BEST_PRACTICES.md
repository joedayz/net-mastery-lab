# Mejores Prácticas: Switch Expressions en C# 8

## ✅ Reglas de Oro

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

// ❌ MAL: Switch statement para mapeo simple
string GetPlanName(string planCode)
{
    switch (planCode)
    {
        case "F":
            return "Free";
        case "P":
            return "Pro";
        case "E":
            return "Enterprise";
        default:
            return "Unknown";
    }
}
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

// ❌ MAL: Switch expression sin aprovechar pattern matching
bool IsValidOrder(Order order)
{
    if (order == null) return false;
    if (order.Total <= 0) return false;
    if (order.Items.Count == 0) return false;
    return order.Customer != null;
}
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

// ❌ MAL: Método tradicional con switch statement
public class OrderService
{
    public string GetStatusMessage(OrderStatus status)
    {
        switch (status)
        {
            case OrderStatus.Pending:
                return "Your order is pending";
            case OrderStatus.Processing:
                return "Your order is being processed";
            case OrderStatus.Shipped:
                return "Your order has been shipped";
            default:
                return "Unknown status";
        }
    }
}
```

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

### 3. Mantener Legibilidad

No hagas switch expressions demasiado complejas. Si es difícil de leer, considera usar switch statement.

```csharp
// ✅ BIEN: Switch expression legible
string GetCategory(int age) => age switch
{
    < 13 => "Child",
    < 18 => "Teen",
    < 65 => "Adult",
    _ => "Senior"
};

// ⚠️ ADVERTENCIA: Demasiado complejo - considerar switch statement
string ProcessComplexLogic(ComplexObject obj) => obj switch
{
    { A: > 0, B: { C: > 10, D: not null }, E: [.., var last] } when last > 5 => "Complex Case 1",
    { A: < 0, B: { C: < 10 }, E: [] } => "Complex Case 2",
    // ... muchos más casos complejos
    _ => "Default"
};
```

## 🎯 Casos de Uso Específicos

### 1. Subscription Plans

```csharp
// ✅ BIEN: Mapeo de planes de suscripción
public class SubscriptionService
{
    public string GetFeatures(string plan) => plan switch
    {
        "Free" => "Basic Access",
        "Pro" => "Premium Access + Analytics",
        "Enterprise" => "All Features + Priority Support",
        _ => "Unknown Plan"
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

### 2. Status Codes

```csharp
// ✅ BIEN: Mapeo de códigos de estado HTTP
public class ApiResponseFormatter
{
    public string GetStatusMessage(int statusCode) => statusCode switch
    {
        200 => "OK",
        201 => "Created",
        400 => "Bad Request",
        401 => "Unauthorized",
        404 => "Not Found",
        500 => "Internal Server Error",
        _ => "Unknown Status"
    };
}
```

### 3. Enum Mapping

```csharp
// ✅ BIEN: Mapeo de enums
public enum UserRole
{
    Admin,
    Editor,
    Viewer,
    Guest
}

public class AuthorizationService
{
    public string GetPermissions(UserRole role) => role switch
    {
        UserRole.Admin => "Full Access",
        UserRole.Editor => "Create, Edit, Delete",
        UserRole.Viewer => "Read Only",
        UserRole.Guest => "Limited Access",
        _ => "No Access"
    };
}
```

### 4. Con Tuples

```csharp
// ✅ BIEN: Múltiples valores con tuples
public class AccessControlService
{
    public string GetAccessLevel(string role, bool isPremium) => (role, isPremium) switch
    {
        ("Admin", _) => "Full Access",
        ("Editor", true) => "Premium Editor Access",
        ("Editor", false) => "Standard Editor Access",
        ("Viewer", true) => "Premium Viewer Access",
        ("Viewer", false) => "Standard Viewer Access",
        _ => "No Access"
    };
}
```

## 📊 Tabla de Decisión

| Escenario | Usar Switch Expression | Usar Switch Statement | Razón |
|-----------|------------------------|----------------------|-------|
| Mapeo simple | ✅ | ❌ | Más conciso |
| Retorna valor | ✅ | ❌ | Expresión vs statement |
| Side effects | ❌ | ✅ | Expressions deben ser puras |
| Lógica compleja | ❌ | ✅ | Legibilidad |
| Pattern matching | ✅ | ⚠️ | Mejor soporte |
| Expression-bodied | ✅ | ❌ | Compatible |

## 💡 Pro Tips

### 1. Combinar con Pattern Matching

```csharp
// ✅ BIEN: Switch expression con pattern matching completo
string ProcessData(object data) => data switch
{
    int i when i > 0 => $"Positive integer: {i}",
    int i when i < 0 => $"Negative integer: {i}",
    string s when s.Length > 10 => $"Long string: {s.Substring(0, 10)}...",
    string s => $"Short string: {s}",
    null => "Null value",
    _ => "Unknown type"
};
```

### 2. Usar con Records

```csharp
// ✅ BIEN: Switch expression con records y positional patterns
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

### 3. Documentar Casos Complejos

```csharp
// ✅ BIEN: Documentar casos complejos
/// <summary>
/// Determina el nivel de acceso basado en rol y estado premium
/// </summary>
string GetAccessLevel(string role, bool isPremium) => (role, isPremium) switch
{
    // Admins siempre tienen acceso completo
    ("Admin", _) => "Full Access",
    
    // Editores premium tienen acceso extendido
    ("Editor", true) => "Premium Editor Access",
    ("Editor", false) => "Standard Editor Access",
    
    // Viewers premium pueden ver contenido premium
    ("Viewer", true) => "Premium Viewer Access",
    ("Viewer", false) => "Standard Viewer Access",
    
    // Cualquier otro caso
    _ => "No Access"
};
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Switch Expressions](https://learn.microsoft.com/dotnet/csharp/language-reference/operators/switch-expression)
- [Microsoft Docs - Pattern Matching](https://learn.microsoft.com/dotnet/csharp/pattern-matching)
- [C# 8.0 Features](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-8)

