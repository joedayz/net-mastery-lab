# Mejores Prácticas: Avoid Too Many Arguments In Functions

## ✅ Reglas de Oro

### 1. Limita el número de argumentos a 2-3 máximo

```csharp
// ❌ MAL: Demasiados argumentos
public void CreateUser(string firstName, string lastName, string email, string phone, 
    string address, string city, string state, string zipCode, DateTime birthDate)
{
    // ...
}

// ✅ BIEN: Encapsular en objeto
public void CreateUser(User user)
{
    // ...
}
```

### 2. Agrupa parámetros relacionados en objetos

Si varios parámetros están relacionados conceptualmente, créales una clase o struct.

```csharp
// ❌ MAL: Parámetros relacionados separados
public void ProcessOrder(string customerName, string customerEmail, 
    string shippingAddress, string billingAddress, decimal total)
{
    // ...
}

// ✅ BIEN: Agrupar en objetos relacionados
public void ProcessOrder(Order order)
{
    // order.Customer.Name, order.Customer.Email
    // order.ShippingAddress, order.BillingAddress
    // order.Total
}
```

### 3. Usa structs para datos pequeños e inmutables

```csharp
// ✅ Buen uso de struct
public struct Point
{
    public int X { get; init; }
    public int Y { get; init; }
}

public void DrawLine(Point start, Point end)
{
    // Solo 2 argumentos, ambos son structs pequeños
}
```

### 4. Usa clases para entidades con comportamiento

```csharp
// ✅ Buen uso de clase
public class Student
{
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Major { get; set; }
    // ... más propiedades
    
    public void EnrollInCourse(Course course) { /* ... */ }
    public decimal CalculateGPA() { /* ... */ }
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Crear objetos "parameter bags" sin sentido

No crees objetos solo para reducir el número de parámetros si no tienen sentido conceptual.

```csharp
// ❌ MAL: Objeto sin sentido conceptual
public class Parameters
{
    public string A { get; set; }
    public int B { get; set; }
    public bool C { get; set; }
}

public void DoSomething(Parameters p) { }

// ✅ BIEN: Si los parámetros no están relacionados, considera dividir la función
public void DoSomething(string a, int b, bool c) { }
// O mejor aún, dividir en funciones más pequeñas
```

### 2. Ignorar el principio de responsabilidad única

Si necesitas muchos parámetros, puede ser que la función esté haciendo demasiado.

```csharp
// ❌ MAL: Función haciendo demasiado
public void ProcessOrder(string customerName, string customerEmail, 
    string productName, int quantity, decimal price, string shippingAddress,
    string paymentMethod, string cardNumber)
{
    // Valida cliente
    // Crea orden
    // Procesa pago
    // Envía confirmación
    // Actualiza inventario
}

// ✅ BIEN: Dividir en funciones más pequeñas
public void ProcessOrder(Order order)
{
    ValidateCustomer(order.Customer);
    CreateOrder(order);
    ProcessPayment(order.Payment);
    SendConfirmation(order);
    UpdateInventory(order.Items);
}
```

### 3. Usar demasiados niveles de anidación

```csharp
// ❌ MAL: Demasiada anidación
public void ProcessOrder(Order order)
{
    if (order.Customer != null)
    {
        if (order.Customer.Address != null)
        {
            if (order.Customer.Address.Street != null)
            {
                // ...
            }
        }
    }
}

// ✅ BIEN: Usar null-conditional operators o validación temprana
public void ProcessOrder(Order order)
{
    ArgumentNullException.ThrowIfNull(order);
    ArgumentNullException.ThrowIfNull(order.Customer);
    
    var address = order.Customer.Address ?? throw new ArgumentException("Address is required");
    // ...
}
```

## 🎯 Casos de Uso Específicos

### 1. Configuración de Servicios

```csharp
// ❌ MAL
public void ConfigureService(string host, int port, string username, 
    string password, bool useSsl, int timeout)
{
    // ...
}

// ✅ BIEN
public class ServiceConfiguration
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool UseSsl { get; set; }
    public int Timeout { get; set; }
}

public void ConfigureService(ServiceConfiguration config)
{
    // ...
}
```

### 2. Creación de Entidades

```csharp
// ❌ MAL
public User CreateUser(string firstName, string lastName, string email,
    string phone, DateTime birthDate, string address, string city)
{
    // ...
}

// ✅ BIEN
public class CreateUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public Address Address { get; set; }
}

public User CreateUser(CreateUserRequest request)
{
    // ...
}
```

### 3. Operaciones con Múltiples Valores

```csharp
// ❌ MAL
public void UpdateProduct(int productId, string name, decimal price,
    int stock, string category, string description)
{
    // ...
}

// ✅ BIEN
public class ProductUpdateRequest
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
}

public void UpdateProduct(ProductUpdateRequest request)
{
    // ...
}
```

## 📊 Comparación de Enfoques

| Aspecto | Muchos Argumentos | Objeto Encapsulado |
|---------|------------------|-------------------|
| **Legibilidad** | ❌ Difícil | ✅ Fácil |
| **Mantenibilidad** | ❌ Difícil | ✅ Fácil |
| **Testabilidad** | ❌ Compleja | ✅ Simple |
| **Flexibilidad** | ❌ Limitada | ✅ Alta |
| **Propenso a errores** | ❌ Alto | ✅ Bajo |

## 🚀 Refactoring Tips

### 1. Identifica parámetros relacionados

```csharp
// Si ves patrones como estos, considera crear un objeto:
// - firstName, lastName → Person o Name
// - street, city, state, zipCode → Address
// - width, height → Size o Dimensions
// - startDate, endDate → DateRange
```

### 2. Usa el patrón Parameter Object

```csharp
// Crear una clase específica para los parámetros
public class SearchCriteria
{
    public string Query { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}

public List<Product> SearchProducts(SearchCriteria criteria)
{
    // ...
}
```

### 3. Considera usar record types (C# 9+)

```csharp
// ✅ Usar record para datos inmutables
public record Student(
    string Name,
    DateOnly BirthDate,
    string Major,
    int Score,
    int TotalCourses);

public Result GraduateStudent(Student student)
{
    // ...
}
```

## 📚 Recursos Adicionales

- [Clean Code by Robert C. Martin](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)
- [Refactoring by Martin Fowler](https://refactoring.com/)
- [Microsoft Docs - C# Coding Conventions](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)

