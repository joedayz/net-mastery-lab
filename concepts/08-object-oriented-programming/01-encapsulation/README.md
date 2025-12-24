# Encapsulation (Encapsulación) 🎯

## Introducción

La encapsulación es uno de los cuatro pilares fundamentales de la Programación Orientada a Objetos (OOP). Es el concepto de agrupar datos (campos) y métodos que operan sobre esos datos (propiedades, métodos) dentro de una sola unidad (clase). Restringe el acceso directo a algunos de los componentes de un objeto, protegiendo el estado interno y exponiendo solo la funcionalidad necesaria a través de interfaces bien definidas como propiedades y métodos.

## 📖 ¿Qué es la Encapsulación?

La encapsulación combina:
- **Datos (Fields)**: Variables que almacenan el estado del objeto
- **Métodos**: Funciones que operan sobre esos datos
- **Propiedades**: Accesores controlados a los datos

Todo esto dentro de una **clase**, que actúa como una unidad cohesiva.

## 🎯 Propósitos de la Encapsulación

### 1. Proteger el Estado Interno

La encapsulación protege el estado interno del objeto de modificaciones no controladas.

```csharp
// ✅ BIEN: Estado protegido
public class Person
{
    private int _age; // Campo privado protegido
    
    public int Age
    {
        get => _age;
        set
        {
            if (value < 0 || value > 150)
                throw new ArgumentException("Age must be between 0 and 150");
            _age = value;
        }
    }
}
```

### 2. Controlar el Acceso

Restringe el acceso directo a los datos, permitiendo solo acceso controlado a través de propiedades y métodos.

```csharp
// ✅ BIEN: Acceso controlado
public class BankAccount
{
    private decimal _balance; // Privado - no accesible desde fuera
    
    public decimal Balance => _balance; // Solo lectura desde fuera
    
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");
        _balance += amount;
    }
}
```

### 3. Ocultar la Implementación

Oculta los detalles de implementación, exponiendo solo una interfaz clara y bien definida.

```csharp
// ✅ BIEN: Implementación oculta
public class EmailService
{
    private string _smtpServer;
    private int _port;
    
    public void SendEmail(string to, string subject, string body)
    {
        // Detalles de implementación ocultos
        ConnectToServer();
        Authenticate();
        SendMessage(to, subject, body);
        Disconnect();
    }
    
    private void ConnectToServer() { /* ... */ }
    private void Authenticate() { /* ... */ }
    private void SendMessage(string to, string subject, string body) { /* ... */ }
    private void Disconnect() { /* ... */ }
}
```

## 💡 Ejemplos Prácticos

### Ejemplo 1: Auto-Property con Valor por Defecto

```csharp
public class Person
{
    public string Name { get; set; } = "Default Name"; // Auto-property with default value
}
```

**Ventajas:**
- Código conciso y legible
- Valor por defecto establecido
- Acceso controlado a través de propiedades

### Ejemplo 2: Propiedad con Validación

```csharp
public class Person
{
    private string _name;
    
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be null or empty");
            _name = value;
        }
    }
    
    private int _age;
    
    public int Age
    {
        get => _age;
        set
        {
            if (value < 0 || value > 150)
                throw new ArgumentException("Age must be between 0 and 150");
            _age = value;
        }
    }
}
```

### Ejemplo 3: Propiedad de Solo Lectura

```csharp
public class Order
{
    private readonly int _orderId;
    private DateTime _orderDate;
    
    public Order(int orderId)
    {
        _orderId = orderId;
        _orderDate = DateTime.Now;
    }
    
    public int OrderId => _orderId; // Solo lectura
    public DateTime OrderDate => _orderDate; // Solo lectura
}
```

### Ejemplo 4: Propiedad Calculada

```csharp
public class Rectangle
{
    private double _width;
    private double _height;
    
    public double Width
    {
        get => _width;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Width must be positive");
            _width = value;
        }
    }
    
    public double Height
    {
        get => _height;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Height must be positive");
            _height = value;
        }
    }
    
    // Propiedad calculada - no tiene campo de respaldo
    public double Area => Width * Height;
    public double Perimeter => 2 * (Width + Height);
}
```

### Ejemplo 5: Encapsulación Completa

```csharp
public class BankAccount
{
    private decimal _balance;
    private string _accountNumber;
    private readonly List<Transaction> _transactions;
    
    public BankAccount(string accountNumber, decimal initialBalance)
    {
        _accountNumber = accountNumber;
        _balance = initialBalance;
        _transactions = new List<Transaction>();
    }
    
    public string AccountNumber => _accountNumber; // Solo lectura
    public decimal Balance => _balance; // Solo lectura
    
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");
        
        _balance += amount;
        _transactions.Add(new Transaction(TransactionType.Deposit, amount, DateTime.Now));
    }
    
    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");
        
        if (_balance < amount)
            return false;
        
        _balance -= amount;
        _transactions.Add(new Transaction(TransactionType.Withdrawal, amount, DateTime.Now));
        return true;
    }
    
    public IEnumerable<Transaction> GetTransactionHistory()
    {
        return _transactions.AsReadOnly();
    }
}
```

## 🔒 Modificadores de Acceso en C#

### Public
Accesible desde cualquier lugar.

```csharp
public class Person
{
    public string Name { get; set; } // Accesible desde cualquier lugar
}
```

### Private
Solo accesible dentro de la misma clase.

```csharp
public class Person
{
    private int _age; // Solo accesible dentro de Person
}
```

### Protected
Accesible dentro de la clase y clases derivadas.

```csharp
public class Person
{
    protected string InternalId { get; set; } // Accesible en Person y clases derivadas
}
```

### Internal
Accesible dentro del mismo ensamblado.

```csharp
internal class Helper
{
    // Solo accesible dentro del mismo proyecto/ensamblado
}
```

## 🎯 Cuándo Usar Encapsulación

### Usa encapsulación cuando:
- ✅ Necesitas proteger el estado interno de un objeto
- ✅ Quieres controlar cómo se accede y modifica los datos
- ✅ Necesitas validar datos antes de asignarlos
- ✅ Quieres ocultar detalles de implementación complejos
- ✅ Necesitas mantener la integridad de los datos

### Beneficios:
- **Seguridad**: Protege datos sensibles
- **Mantenibilidad**: Facilita cambios internos sin afectar código externo
- **Flexibilidad**: Permite cambiar implementación sin cambiar la interfaz
- **Testabilidad**: Facilita pruebas unitarias

## ⚠️ Errores Comunes a Evitar

### 1. Campos Públicos

```csharp
// ❌ MAL: Campo público sin encapsulación
public class Person
{
    public string Name; // Acceso directo sin control
    public int Age; // Puede ser modificado sin validación
}

// ✅ BIEN: Propiedades con encapsulación
public class Person
{
    private string _name;
    private int _age;
    
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be null or empty");
            _name = value;
        }
    }
    
    public int Age
    {
        get => _age;
        set
        {
            if (value < 0 || value > 150)
                throw new ArgumentException("Age must be between 0 and 150");
            _age = value;
        }
    }
}
```

### 2. Exponer Listas Internas Directamente

```csharp
// ❌ MAL: Exponer lista interna directamente
public class Order
{
    public List<OrderItem> Items { get; set; } // Puede ser modificada desde fuera
}

// ✅ BIEN: Encapsular la lista
public class Order
{
    private readonly List<OrderItem> _items = new();
    
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
    
    public void AddItem(OrderItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));
        _items.Add(item);
    }
    
    public bool RemoveItem(OrderItem item)
    {
        return _items.Remove(item);
    }
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Encapsulation](https://docs.microsoft.com/dotnet/csharp/fundamentals/object-oriented/)
- [Microsoft Docs - Properties](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/properties)
- [Microsoft Docs - Access Modifiers](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)

