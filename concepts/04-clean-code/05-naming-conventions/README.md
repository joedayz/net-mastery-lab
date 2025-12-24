# Use the Proper Naming Convention 💡

## Introducción

Es importante nombrar apropiadamente tus variables, clases y métodos. Las convenciones de codificación sirven para varios propósitos importantes y son fundamentales para escribir código limpio y mantenible en C#.

## 🎯 Propósitos de las Convenciones de Codificación

### ✔ Crean una Apariencia Consistente

Las convenciones crean una apariencia consistente en el código para que los lectores puedan enfocarse en el contenido, no en el diseño.

### ✔ Permiten Entender el Código Más Rápidamente

Permiten a los lectores entender el código más rápidamente haciendo suposiciones basadas en experiencia previa.

### ✔ Facilitan Copiar, Cambiar y Mantener el Código

Facilitan copiar, cambiar y mantener el código al seguir estándares reconocidos.

### ✔ Demuestran Mejores Prácticas de C#

Demuestran las mejores prácticas de C# y ayudan a escribir código profesional.

## 📊 Tabla de Convenciones de Nomenclatura

La siguiente tabla muestra las convenciones de nomenclatura que debes usar al escribir código C#. Es una forma estandarizada de escribir código.

| Tipo de Objeto | Notación | ¿Puede ser Plural? | Ejemplo |
|----------------|----------|-------------------|---------|
| **Namespace name** | `PascalCase` | ✅ Sí | `MyCompany.MyProject` |
| **Class name** | `PascalCase` | ❌ No | `User`, `OrderService` |
| **Constructor name** | `PascalCase` | ❌ No | `User()`, `OrderService()` |
| **Method name** | `PascalCase` | ✅ Sí | `GetUsers()`, `ProcessOrder()` |
| **Method arguments** | `camelCase` | ✅ Sí | `userId`, `orderItems` |
| **Local variables** | `camelCase` | ✅ Sí | `userCount`, `totalAmount` |
| **Constants name** | `PascalCase` | ❌ No | `MaxRetries`, `DefaultTimeout` |
| **Field name Public** | `PascalCase` | ✅ Sí | `UserId`, `OrderItems` |
| **Field name Private** | `_camelCase` | ✅ Sí | `_userId`, `_orderItems` |
| **Properties name** | `PascalCase` | ✅ Sí | `UserId`, `OrderItems` |
| **Interface** | `IPascalCase` | ❌ No | `IUserService`, `IRepository` |
| **Enum type name** | `PascalCase` | ✅ Sí | `OrderStatus`, `UserRoles` |

## 📖 Convenciones Detalladas

### 1. Namespace Name
**Notación**: `PascalCase`  
**Puede ser Plural**: ✅ Sí

```csharp
// ✅ BIEN
namespace MyCompany.MyProject.Services;
namespace DataAccess.Repositories;

// ❌ MAL
namespace myCompany.myProject; // camelCase
namespace MYCOMPANY.MYPROJECT; // UPPERCASE
```

### 2. Class Name
**Notación**: `PascalCase`  
**Puede ser Plural**: ❌ No

```csharp
// ✅ BIEN
public class User { }
public class OrderService { }
public class ProductRepository { }

// ❌ MAL
public class user { } // camelCase
public class Users { } // Plural (a menos que represente una colección)
public class USER { } // UPPERCASE
```

### 3. Constructor Name
**Notación**: `PascalCase` (igual que la clase)  
**Puede ser Plural**: ❌ No

```csharp
// ✅ BIEN
public class User
{
    public User() { }
    public User(string name) { }
}

// ❌ MAL
public class User
{
    public user() { } // camelCase
}
```

### 4. Method Name
**Notación**: `PascalCase`  
**Puede ser Plural**: ✅ Sí

```csharp
// ✅ BIEN
public void GetUsers() { }
public void ProcessOrders() { }
public int CalculateTotal() { }

// ❌ MAL
public void getUsers() { } // camelCase
public void GET_USERS() { } // UPPERCASE
```

### 5. Method Arguments
**Notación**: `camelCase`  
**Puede ser Plural**: ✅ Sí

```csharp
// ✅ BIEN
public void ProcessOrder(int orderId, List<OrderItem> orderItems) { }
public void CreateUser(string userName, string emailAddress) { }

// ❌ MAL
public void ProcessOrder(int OrderId, List<OrderItem> OrderItems) { } // PascalCase
public void ProcessOrder(int ORDER_ID) { } // UPPERCASE
```

### 6. Local Variables
**Notación**: `camelCase`  
**Puede ser Plural**: ✅ Sí

```csharp
// ✅ BIEN
var userCount = 10;
var totalAmount = 100.50m;
var orderItems = new List<OrderItem>();

// ❌ MAL
var UserCount = 10; // PascalCase
var TOTAL_AMOUNT = 100.50m; // UPPERCASE
```

### 7. Constants Name
**Notación**: `PascalCase`  
**Puede ser Plural**: ❌ No

```csharp
// ✅ BIEN
public const int MaxRetries = 3;
public const string DefaultConnectionString = "...";
public const double Pi = 3.14159;

// ❌ MAL
public const int MAX_RETRIES = 3; // UPPERCASE (aunque algunos equipos lo usan)
public const int maxRetries = 3; // camelCase
```

### 8. Field Name Public
**Notación**: `PascalCase`  
**Puede ser Plural**: ✅ Sí

```csharp
// ✅ BIEN
public class User
{
    public int UserId;
    public List<Order> Orders;
}

// ❌ MAL
public class User
{
    public int userId; // camelCase
    public int USER_ID; // UPPERCASE
}
```

### 9. Field Name Private
**Notación**: `_camelCase` (prefijo con guion bajo)  
**Puede ser Plural**: ✅ Sí

```csharp
// ✅ BIEN
public class User
{
    private int _userId;
    private List<Order> _orders;
    private string _name;
}

// ❌ MAL
public class User
{
    private int userId; // Sin prefijo
    private int m_userId; // Prefijo 'm_' (estilo C++)
}
```

### 10. Properties Name
**Notación**: `PascalCase`  
**Puede ser Plural**: ✅ Sí

```csharp
// ✅ BIEN
public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
}

// ❌ MAL
public class User
{
    public int userId { get; set; } // camelCase
    public int USER_ID { get; set; } // UPPERCASE
}
```

### 11. Interface
**Notación**: `IPascalCase` (prefijo con 'I')  
**Puede ser Plural**: ❌ No

```csharp
// ✅ BIEN
public interface IUserService { }
public interface IRepository<T> { }
public interface IOrderProcessor { }

// ❌ MAL
public interface UserService { } // Sin prefijo 'I'
public interface IUserServices { } // Plural
public interface iUserService { } // 'i' minúscula
```

### 12. Enum Type Name
**Notación**: `PascalCase`  
**Puede ser Plural**: ✅ Sí

```csharp
// ✅ BIEN
public enum OrderStatus { Pending, Completed, Cancelled }
public enum UserRoles { Admin, User, Guest }
public enum Colors { Red, Green, Blue }

// ❌ MAL
public enum orderStatus { } // camelCase
public enum ORDER_STATUS { } // UPPERCASE
```

## 💡 Reglas Adicionales Importantes

### 1. Nombres Descriptivos

```csharp
// ✅ BIEN: Descriptivo y claro
var userAccountBalance = 1000m;
var orderProcessingService = new OrderService();

// ❌ MAL: No descriptivo
var uab = 1000m;
var ops = new OrderService();
```

### 2. Evitar Abreviaciones

```csharp
// ✅ BIEN
var customerAccount = GetAccount();
var configurationManager = new ConfigurationManager();

// ❌ MAL
var custAcct = GetAccount();
var cfgMgr = new ConfigurationManager();
```

### 3. Nombres de Booleanos

```csharp
// ✅ BIEN: Prefijos como Is, Has, Can
public bool IsActive { get; set; }
public bool HasPermission { get; set; }
public bool CanEdit { get; set; }

// ❌ MAL
public bool Active { get; set; } // Menos claro
```

### 4. Nombres de Métodos

```csharp
// ✅ BIEN: Verbos que describen la acción
public void ProcessOrder() { }
public User GetUserById(int id) { }
public bool ValidateEmail(string email) { }

// ❌ MAL: Sustantivos o nombres poco claros
public void Order() { } // ¿Qué hace?
public User User(int id) { } // ¿Es un método o propiedad?
```

## 📚 Recursos Adicionales

- [Microsoft Docs - C# Coding Conventions](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Microsoft Docs - Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines)
- [Clean Code by Robert C. Martin](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)

