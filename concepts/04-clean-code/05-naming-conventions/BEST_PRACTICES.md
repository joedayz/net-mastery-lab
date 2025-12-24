# Mejores Prácticas: Use the Proper Naming Convention

## ✅ Reglas de Oro

### 1. Sigue las Convenciones Estándar de C#

```csharp
// ✅ BIEN: Sigue las convenciones
public class UserService
{
    private int _userId;
    public int UserId { get; set; }
    
    public void ProcessOrder(int orderId) { }
}

// ❌ MAL: No sigue las convenciones
public class userService
{
    private int userId;
    public int userId { get; set; }
    
    public void processOrder(int OrderId) { }
}
```

### 2. Usa Nombres Descriptivos

```csharp
// ✅ BIEN: Descriptivo y claro
var userAccountBalance = 1000m;
var orderProcessingService = new OrderService();

// ❌ MAL: No descriptivo
var uab = 1000m;
var ops = new OrderService();
```

### 3. Evita Abreviaciones Innecesarias

```csharp
// ✅ BIEN: Nombres completos
var customerAccount = GetAccount();
var configurationManager = new ConfigurationManager();

// ❌ MAL: Abreviaciones confusas
var custAcct = GetAccount();
var cfgMgr = new ConfigurationManager();
```

## 📊 Tabla de Referencia Rápida

| Tipo | Notación | Plural | Ejemplo |
|------|----------|--------|---------|
| Namespace | `PascalCase` | ✅ | `MyCompany.Services` |
| Class | `PascalCase` | ❌ | `UserService` |
| Method | `PascalCase` | ✅ | `GetUsers()` |
| Arguments | `camelCase` | ✅ | `userId`, `orderItems` |
| Local Variables | `camelCase` | ✅ | `userCount`, `totalAmount` |
| Constants | `PascalCase` | ❌ | `MaxRetries` |
| Public Field | `PascalCase` | ✅ | `UserId` |
| Private Field | `_camelCase` | ✅ | `_userId` |
| Property | `PascalCase` | ✅ | `UserId` |
| Interface | `IPascalCase` | ❌ | `IUserService` |
| Enum | `PascalCase` | ✅ | `OrderStatus` |

## ⚠️ Errores Comunes a Evitar

### 1. Mezclar Convenciones

```csharp
// ❌ MAL: Mezcla PascalCase y camelCase incorrectamente
public class userService // Debería ser UserService
{
    private int UserId; // Debería ser _userId
    public int userId { get; set; } // Debería ser UserId
}
```

### 2. Usar Prefijos Incorrectos

```csharp
// ❌ MAL: Prefijos incorrectos
public interface UserService { } // Falta 'I'
private int m_userId; // Prefijo 'm_' es estilo C++
private int userId; // Falta prefijo '_'

// ✅ BIEN: Prefijos correctos
public interface IUserService { }
private int _userId;
```

### 3. Nombres No Descriptivos

```csharp
// ❌ MAL: Nombres poco claros
var x = 10;
var temp = GetData();
var obj = new User();

// ✅ BIEN: Nombres descriptivos
var userCount = 10;
var userData = GetData();
var newUser = new User();
```

### 4. Booleanos sin Prefijos Apropiados

```csharp
// ❌ MAL: Booleanos sin prefijos claros
public bool Active { get; set; }
public bool Permission { get; set; }

// ✅ BIEN: Booleanos con prefijos Is, Has, Can
public bool IsActive { get; set; }
public bool HasPermission { get; set; }
public bool CanEdit { get; set; }
```

## 🎯 Casos de Uso Específicos

### 1. Nombres de Métodos

```csharp
// ✅ BIEN: Verbos que describen la acción
public void ProcessOrder() { }
public User GetUserById(int id) { }
public bool ValidateEmail(string email) { }
public void SaveChanges() { }

// ❌ MAL: Sustantivos o nombres poco claros
public void Order() { } // ¿Qué hace?
public User User(int id) { } // Confuso
```

### 2. Nombres de Variables Locales

```csharp
// ✅ BIEN: camelCase descriptivo
var userCount = 10;
var totalAmount = CalculateTotal();
var orderItems = GetOrderItems();

// ❌ MAL: PascalCase o abreviaciones
var UserCount = 10;
var totAmt = CalculateTotal();
```

### 3. Nombres de Propiedades

```csharp
// ✅ BIEN: PascalCase descriptivo
public int UserId { get; set; }
public string FullName { get; set; }
public List<Order> Orders { get; set; }

// ❌ MAL: camelCase o abreviaciones
public int userId { get; set; }
public string fn { get; set; }
```

### 4. Nombres de Interfaces

```csharp
// ✅ BIEN: IPascalCase, singular
public interface IUserService { }
public interface IRepository<T> { }
public interface IOrderProcessor { }

// ❌ MAL: Sin 'I', plural, o 'i' minúscula
public interface UserService { }
public interface IUserServices { }
public interface iUserService { }
```

## 🚀 Tips Avanzados

### 1. Nombres de Métodos Asíncronos

```csharp
// ✅ BIEN: Sufijo 'Async' para métodos asíncronos
public async Task<User> GetUserByIdAsync(int userId) { }
public async Task<List<Order>> GetOrdersAsync() { }
```

### 2. Nombres de Eventos

```csharp
// ✅ BIEN: Verbos en tiempo presente o pasado
public event EventHandler OrderProcessed;
public event EventHandler<UserEventArgs> UserCreated;
```

### 3. Nombres de Tipos Genéricos

```csharp
// ✅ BIEN: T, TKey, TValue, o nombres descriptivos
public interface IRepository<T> { }
public class Dictionary<TKey, TValue> { }
public class Service<TEntity> where TEntity : class { }
```

### 4. Nombres de Extension Methods

```csharp
// ✅ BIEN: Métodos de extensión siguen las mismas reglas
public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string value) { }
    public static string ToTitleCase(this string value) { }
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - C# Coding Conventions](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Microsoft Docs - Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines)
- [Clean Code by Robert C. Martin](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)

