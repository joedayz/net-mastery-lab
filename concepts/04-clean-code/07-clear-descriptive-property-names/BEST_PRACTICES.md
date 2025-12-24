# Mejores Prácticas: Clear & Descriptive Property Names

## ✅ Reglas de Oro

### 1. Usa Nombres Completos, No Abreviaciones

```csharp
// ✅ BIEN: Nombres completos y claros
public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerEmailAddress { get; set; }
    public DateTime AccountCreationDate { get; set; }
}

// ❌ MAL: Abreviaciones confusas
public class Order
{
    public int OrdId { get; set; }
    public DateTime OrdDt { get; set; }
    public string CustEmail { get; set; }
    public DateTime AcctCrDt { get; set; }
}
```

### 2. Sé Específico, No Genérico

```csharp
// ✅ BIEN: Nombres específicos y claros
public class Product
{
    public decimal ProductPrice { get; set; }
    public string OrderStatus { get; set; }
    public ProductDetails ProductDetails { get; set; }
}

// ❌ MAL: Nombres genéricos y ambiguos
public class Product
{
    public decimal Value { get; set; }
    public string Status { get; set; }
    public object Data { get; set; }
}
```

### 3. Mantén Consistencia

```csharp
// ✅ BIEN: Consistente en toda la clase
public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderAmount { get; set; }
    public string OrderStatus { get; set; }
}

// ❌ MAL: Inconsistente
public class Order
{
    public int OrderId { get; set; }
    public DateTime orderDate { get; set; } // camelCase inconsistente
    public decimal Order_Amount { get; set; } // snake_case inconsistente
    public string STATUS { get; set; } // UPPERCASE inconsistente
}
```

### 4. Usa Términos del Dominio

```csharp
// ✅ BIEN: Términos del dominio del negocio
public class Order
{
    public OrderStatus OrderStatus { get; set; }
    public ShippingMethod ShippingMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}

// ❌ MAL: Términos técnicos genéricos
public class Order
{
    public string Status { get; set; } // Genérico
    public string Method { get; set; } // Genérico
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Nombres Genéricos y Ambiguos

```csharp
// ❌ MAL: Nombres genéricos
public class Product
{
    public object Data { get; set; }
    public string Info { get; set; }
    public decimal Value { get; set; }
}

// ✅ BIEN: Nombres específicos
public class Product
{
    public ProductDetails Details { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
```

### 2. Abreviaciones Confusas

```csharp
// ❌ MAL: Abreviaciones confusas
public class Order
{
    public int OrdId { get; set; }
    public DateTime OrdDt { get; set; }
    public string CustNm { get; set; }
}

// ✅ BIEN: Nombres completos
public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
}
```

### 3. Inconsistencia en Nomenclatura

```csharp
// ❌ MAL: Inconsistente
public class Order
{
    public int OrderId { get; set; }
    public DateTime orderDate { get; set; } // camelCase
    public string Customer_Name { get; set; } // snake_case
}

// ✅ BIEN: Consistente
public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
}
```

### 4. Redundancia Innecesaria

```csharp
// ❌ MAL: Redundancia innecesaria
public class Order
{
    public int OrderOrderId { get; set; } // "Order" repetido
    public DateTime OrderOrderDate { get; set; }
}

// ✅ BIEN: Sin redundancia cuando el contexto es claro
public class Order
{
    public int Id { get; set; } // Contexto claro: Order.Id
    public DateTime Date { get; set; } // Contexto claro: Order.Date
}
```

## 🎯 Casos de Uso Específicos

### 1. Nombres Claros para Propiedades de Entidad

```csharp
// ✅ BIEN: Nombres claros y descriptivos
public class Order
{
    public int OrderId { get; set; } // Unique identifier for the order
    public DateTime OrderDate { get; set; } // Date the order was placed
    public string CustomerName { get; set; } // Name of the customer placing the order
    public decimal OrderAmount { get; set; } // Total amount for the order
    public string OrderStatus { get; set; } // Status of the order
}
```

### 2. Evitar Ambigüedad con Contexto

```csharp
// ✅ BIEN: Contexto claro cuando es necesario
public class OrderService
{
    public int OrderId { get; set; } // Útil: clarifica que es OrderId, no ServiceId
    public DateTime OrderDate { get; set; } // Útil: clarifica que es OrderDate
}

// ✅ BIEN: Sin redundancia cuando el contexto es claro
public class Order
{
    public int Id { get; set; } // Contexto claro: Order.Id
    public DateTime Date { get; set; } // Contexto claro: Order.Date
}
```

### 3. Usar Términos del Dominio

```csharp
// ✅ BIEN: Términos del dominio del negocio
public class Order
{
    public OrderStatus OrderStatus { get; set; }
    public ShippingMethod ShippingMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}
```

## 📊 Tabla de Decisión

| Escenario | Recomendación | Razón |
|-----------|---------------|-------|
| Propiedad dentro de su clase | Sin prefijo redundante | Contexto ya está claro |
| Propiedad en clase genérica | Con prefijo descriptivo | Clarifica el contexto |
| Términos del negocio | Usar términos del dominio | Comunicación clara |
| Abreviaciones | Evitar, usar nombres completos | Claridad y comprensión |
| Consistencia | Mantener mismo patrón | Predecibilidad |

## 💡 Pro Tips

### 1. Pregúntate Antes de Nombrar

```csharp
// ✅ Checklist:
// - ¿Este nombre describe claramente los datos?
// - ¿Es conciso pero específico?
// - ¿Soy consistente en todo el código?
```

### 2. Usa Nombres que Respondan "¿Qué es esto?"

```csharp
// ✅ BIEN: Responde claramente "¿Qué es esto?"
public string CustomerEmailAddress { get; set; } // Es una dirección de email del cliente

// ❌ MAL: No responde claramente
public string Email { get; set; } // ¿Email de qué? ¿Qué tipo?
```

### 3. Equilibrio entre Descriptivo y Conciso

```csharp
// ✅ BIEN: Equilibrio perfecto
public DateTime OrderDate { get; set; }

// ❌ MAL: Demasiado corto
public DateTime Dt { get; set; }

// ❌ MAL: Demasiado largo
public DateTime OrderPlacedDateAndTime { get; set; }
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines)
- [Clean Code by Robert C. Martin](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)
- [C# Coding Conventions](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)

