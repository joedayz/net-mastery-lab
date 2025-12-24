# Clear & Descriptive Property Names 📝✨

## Introducción

Cuando se trata de escribir código limpio, mantenible y legible, elegir los nombres correctos para las propiedades es una de las prácticas más esenciales que puedes adoptar. Pero, ¿por qué es tan importante?

## 🤔 ¿Por Qué es Tan Importante?

Los nombres claros y descriptivos de propiedades son fundamentales para:
- ✅ **Legibilidad**: Hacer el código fácilmente comprensible
- ✅ **Mantenibilidad**: Hacer el código autoexplicativo
- ✅ **Colaboración**: Facilitar el trabajo en equipo
- ✅ **Reducción de bugs**: Evitar malentendidos y errores

## 📖 1. Readability: La Base del Código Comprensible

Elegir nombres descriptivos de propiedades es clave para hacer tu código fácilmente legible. Un buen nombre de propiedad debe decirle a un desarrollador qué representa la propiedad, sin necesidad de profundizar en la implementación.

### Ejemplo: Nombres Claros y Descriptivos

```csharp
// ✅ BIEN: Nombres claros y descriptivos
public class Order
{
    // Clear and descriptive property names
    public int OrderId { get; set; } // Unique identifier for the order
    public DateTime OrderDate { get; set; } // Date the order was placed
    public string CustomerName { get; set; } // Name of the customer placing the order
    public decimal OrderAmount { get; set; } // Total amount for the order
    public string OrderStatus { get; set; } // Status of the order (e.g., Pending, Shipped, Delivered)
}

// ❌ MAL: Nombres genéricos y ambiguos
public class Order
{
    public int Id { get; set; } // ¿Qué tipo de ID?
    public DateTime Date { get; set; } // ¿Qué fecha?
    public string Name { get; set; } // ¿Nombre de qué?
    public decimal Amount { get; set; } // ¿Qué cantidad?
    public string Status { get; set; } // ¿Estado de qué?
}
```

**Beneficios:**
- ✅ El código se lee como un libro
- ✅ No necesitas comentarios extensos
- ✅ Otros desarrolladores entienden inmediatamente

## 🔧 2. Maintenance: Hacer Tu Código a Prueba de Futuro

En proyectos que evolucionan con el tiempo, quieres que tu código sea lo más autoexplicativo posible. Los nombres claros de propiedades reducen la necesidad de comentarios excesivos o documentación.

### Ejemplo: Código Autoexplicativo

```csharp
// ✅ BIEN: Código autoexplicativo
public class UserAccount
{
    public string EmailAddress { get; set; } // Claro: es una dirección de email
    public DateTime AccountCreationDate { get; set; } // Claro: fecha de creación
    public bool IsEmailVerified { get; set; } // Claro: indica si el email está verificado
    public int FailedLoginAttempts { get; set; } // Claro: número de intentos fallidos
}

// ❌ MAL: Requiere investigación adicional
public class UserAccount
{
    public string Email { get; set; } // ¿Es solo el email o incluye validación?
    public DateTime Created { get; set; } // ¿Creado qué? ¿Cuándo?
    public bool Verified { get; set; } // ¿Qué está verificado?
    public int Attempts { get; set; } // ¿Intentos de qué?
}
```

**Beneficios:**
- ✅ Menos tiempo investigando código antiguo
- ✅ Cambios más rápidos y seguros
- ✅ Menos errores al modificar código

## 🧐 3. Context is Key: Evitar Ambigüedad

Los nombres genéricos como `Data`, `Info`, o `Value` carecen de claridad. En su lugar, usa nombres que transmitan qué representa realmente el dato. Un nombre de propiedad siempre debe responder: "¿Qué es esto exactamente?"

### Ejemplo: Evitar Ambigüedad

```csharp
// ❌ MAL: Nombres genéricos y ambiguos
public class Product
{
    public object Data { get; set; } // ¿Qué tipo de datos?
    public string Info { get; set; } // ¿Qué información?
    public decimal Value { get; set; } // ¿Qué valor?
}

// ✅ BIEN: Nombres específicos y claros
public class Product
{
    public ProductDetails ProductDetails { get; set; } // Claro: detalles del producto
    public string ProductDescription { get; set; } // Claro: descripción del producto
    public decimal ProductPrice { get; set; } // Claro: precio del producto
}
```

### Ejemplo: Contexto Claro

```csharp
// ✅ BIEN: Contexto claro en el nombre
public class Order
{
    public int OrderId { get; set; } // Claro: ID de la orden
    public DateTime OrderDate { get; set; } // Claro: fecha de la orden
    public decimal OrderTotal { get; set; } // Claro: total de la orden
}

// ⚠️ MEJORABLE: Redundancia cuando el contexto ya está claro
public class Order
{
    public int OrderId { get; set; } // Redundante: ya estamos en Order
    public DateTime OrderDate { get; set; } // Redundante: ya estamos en Order
    public decimal OrderTotal { get; set; } // Redundante: ya estamos en Order
}

// ✅ MEJOR: Sin redundancia cuando el contexto es claro
public class Order
{
    public int Id { get; set; } // Contexto claro: es Order.Id
    public DateTime Date { get; set; } // Contexto claro: es Order.Date
    public decimal Total { get; set; } // Contexto claro: es Order.Total
}
```

## 📏 4. Consistency: Mantener las Convenciones

Ser consistente en la nomenclatura (por ejemplo, siempre usar PascalCase para propiedades) hace que tu código sea predecible y más fácil de trabajar.

### Ejemplo: Consistencia en Nomenclatura

```csharp
// ✅ BIEN: Consistente en toda la clase
public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
    public decimal OrderAmount { get; set; }
    public string OrderStatus { get; set; }
}

// ❌ MAL: Inconsistente
public class Order
{
    public int OrderId { get; set; }
    public DateTime orderDate { get; set; } // camelCase inconsistente
    public string Customer_Name { get; set; } // snake_case inconsistente
    public decimal OrderAmount { get; set; }
    public string STATUS { get; set; } // UPPERCASE inconsistente
}
```

**Reglas de Consistencia:**
- ✅ Usa PascalCase para todas las propiedades
- ✅ Mantén el mismo patrón de prefijos/sufijos
- ✅ Usa la misma estructura de nombres en clases relacionadas

## 🧠 5. Avoid Redundancy: Mantenerlo Simple

Evita repetir contexto innecesario en los nombres. Si la clase ya proporciona un contexto, tus nombres de propiedades no necesitan repetirlo.

### Ejemplo: Evitar Redundancia

```csharp
// ❌ MAL: Redundancia innecesaria
public class Order
{
    public int OrderOrderId { get; set; } // Redundante: "Order" dos veces
    public DateTime OrderOrderDate { get; set; } // Redundante
    public string OrderCustomerName { get; set; } // Redundante
}

// ✅ BIEN: Sin redundancia cuando el contexto es claro
public class Order
{
    public int Id { get; set; } // Contexto claro: Order.Id
    public DateTime Date { get; set; } // Contexto claro: Order.Date
    public string CustomerName { get; set; } // Necesario: no es Order.CustomerName
}

// ✅ BIEN: Redundancia útil cuando el contexto no es claro
public class OrderService
{
    public int OrderId { get; set; } // Útil: clarifica que es OrderId, no ServiceId
    public DateTime OrderDate { get; set; } // Útil: clarifica que es OrderDate
}
```

**Cuándo Usar Redundancia:**
- ✅ Cuando el contexto no es claro (clases genéricas, servicios)
- ✅ Cuando hay ambigüedad potencial
- ❌ Cuando el contexto ya es obvio (propiedades dentro de su clase)

## 🌐 6. Use Domain-Specific Terms: Hablar el Idioma del Negocio

Usa términos que se alineen con el dominio del negocio. Esto ayuda tanto a miembros técnicos como no técnicos del equipo a entender el modelo fácilmente.

### Ejemplo: Términos del Dominio

```csharp
// ✅ BIEN: Términos del dominio del negocio
public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
    public decimal OrderAmount { get; set; }
    public OrderStatus OrderStatus { get; set; } // Término del dominio
    public ShippingMethod ShippingMethod { get; set; } // Término del dominio
    public PaymentStatus PaymentStatus { get; set; } // Término del dominio
}

// ❌ MAL: Términos técnicos genéricos
public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; } // Genérico, no específico del dominio
    public string Method { get; set; } // Genérico, no específico del dominio
}
```

**Beneficios:**
- ✅ Comunicación más clara con stakeholders
- ✅ Código que refleja el lenguaje del negocio
- ✅ Modelos más intuitivos

## 🛠️ 7. Naming Conventions: Ser Descriptivo, Pero No Abrumador

Busca un equilibrio. Sé lo suficientemente descriptivo para transmitir significado pero lo suficientemente corto para evitar desorden y confusión.

### Ejemplo: Equilibrio en Nombres

```csharp
// ❌ MAL: Demasiado corto y ambiguo
public class Order
{
    public int Id { get; set; }
    public DateTime Dt { get; set; } // Abreviación confusa
    public string Nm { get; set; } // Abreviación confusa
    public decimal Amt { get; set; } // Abreviación confusa
}

// ❌ MAL: Demasiado largo y verboso
public class Order
{
    public int OrderIdentifierUniqueId { get; set; } // Demasiado largo
    public DateTime OrderPlacedDateAndTime { get; set; } // Demasiado verboso
    public string CustomerWhoPlacedTheOrderName { get; set; } // Demasiado largo
    public decimal TotalAmountOfTheOrderInDollars { get; set; } // Demasiado verboso
}

// ✅ BIEN: Equilibrio perfecto
public class Order
{
    public int OrderId { get; set; } // Claro y conciso
    public DateTime OrderDate { get; set; } // Claro y conciso
    public string CustomerName { get; set; } // Claro y conciso
    public decimal OrderAmount { get; set; } // Claro y conciso
}
```

**Reglas de Equilibrio:**
- ✅ Usa nombres completos, no abreviaciones
- ✅ Evita nombres excesivamente largos
- ✅ Busca claridad sin verbosidad

## 💡 Tips: Mejor Código Comienza con Mejores Nombres

Los nombres claros y descriptivos de propiedades ahorran tiempo, reducen bugs y mejoran la colaboración. Pregúntate:

### ✅ Checklist para Nombres de Propiedades

1. **¿Este nombre describe claramente los datos?**
   ```csharp
   // ✅ BIEN
   public string CustomerEmailAddress { get; set; }
   
   // ❌ MAL
   public string Email { get; set; } // ¿Email de qué?
   ```

2. **¿Es conciso pero específico?**
   ```csharp
   // ✅ BIEN
   public DateTime OrderDate { get; set; }
   
   // ❌ MAL
   public DateTime Dt { get; set; } // Demasiado corto
   public DateTime OrderPlacedDateAndTime { get; set; } // Demasiado largo
   ```

3. **¿Soy consistente en todo el código?**
   ```csharp
   // ✅ BIEN: Consistente
   public class Order
   {
       public int OrderId { get; set; }
       public DateTime OrderDate { get; set; }
       public decimal OrderAmount { get; set; }
   }
   
   // ❌ MAL: Inconsistente
   public class Order
   {
       public int OrderId { get; set; }
       public DateTime orderDate { get; set; } // Inconsistente
       public decimal OrderAmount { get; set; }
   }
   ```

## 📊 Comparación: Antes vs Después

### Antes: Nombres Genéricos y Ambiguos

```csharp
// ❌ MAL: Nombres genéricos y ambiguos
public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
}
```

**Problemas:**
- ❌ No está claro qué representa cada propiedad
- ❌ Requiere investigación adicional
- ❌ Propenso a errores y malentendidos

### Después: Nombres Claros y Descriptivos

```csharp
// ✅ BIEN: Nombres claros y descriptivos
public class Order
{
    // Clear and descriptive property names
    public int OrderId { get; set; } // Unique identifier for the order
    public DateTime OrderDate { get; set; } // Date the order was placed
    public string CustomerName { get; set; } // Name of the customer placing the order
    public decimal OrderAmount { get; set; } // Total amount for the order
    public string OrderStatus { get; set; } // Status of the order (e.g., Pending, Shipped, Delivered)
}
```

**Beneficios:**
- ✅ Código autoexplicativo
- ✅ Fácil de entender sin comentarios
- ✅ Menos propenso a errores

## ⚠️ Errores Comunes

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

## 🎯 Mejores Prácticas

### 1. Usa Nombres Completos, No Abreviaciones

```csharp
// ✅ BIEN
public string CustomerEmailAddress { get; set; }
public DateTime AccountCreationDate { get; set; }

// ❌ MAL
public string CustEmail { get; set; }
public DateTime AcctCrDt { get; set; }
```

### 2. Sé Específico, No Genérico

```csharp
// ✅ BIEN
public decimal ProductPrice { get; set; }
public string OrderStatus { get; set; }

// ❌ MAL
public decimal Value { get; set; }
public string Status { get; set; }
```

### 3. Mantén Consistencia

```csharp
// ✅ BIEN: Consistente en toda la clase
public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderAmount { get; set; }
}
```

### 4. Usa Términos del Dominio

```csharp
// ✅ BIEN: Términos del dominio del negocio
public OrderStatus OrderStatus { get; set; }
public ShippingMethod ShippingMethod { get; set; }
public PaymentStatus PaymentStatus { get; set; }
```

## 📚 Relación con Otros Conceptos

Este tema está relacionado con:
- **Naming Conventions**: `concepts/04-clean-code/05-naming-conventions/` (convenciones técnicas)
- **Clean Code**: `concepts/04-clean-code/README.md` (principios generales)

## 🎯 Resumen

### Principios Clave

1. **Readability**: Nombres que se explican por sí mismos
2. **Maintenance**: Código autoexplicativo para el futuro
3. **Context**: Evitar ambigüedad con nombres específicos
4. **Consistency**: Mantener convenciones consistentes
5. **Simplicity**: Evitar redundancia innecesaria
6. **Domain Terms**: Usar lenguaje del negocio
7. **Balance**: Descriptivo pero no abrumador

### Checklist Final

✅ ¿Este nombre describe claramente los datos?  
✅ ¿Es conciso pero específico?  
✅ ¿Soy consistente en todo el código?

**Escribe código por el que tu yo futuro y tu equipo te agradecerán! 🙌**

## 📚 Recursos Adicionales

- [Microsoft Docs - Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines)
- [Clean Code by Robert C. Martin](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)
- [C# Coding Conventions](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)

