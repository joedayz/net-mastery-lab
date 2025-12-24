# Mejores Prácticas: Key Class Concepts

## ✅ Reglas de Oro

### 1. Entender la Diferencia entre Instancia y Referencia

```csharp
// ✅ BIEN: Crear instancias independientes cuando sea necesario
Person person1 = new Person { Name = "Alice" };
Person person2 = new Person { Name = "Bob" };
// person1 y person2 son objetos diferentes

// ✅ BIEN: Usar referencias cuando quieras apuntar al mismo objeto
Person person3 = person1;
// person3 y person1 apuntan al mismo objeto
```

### 2. Usar Instance Variables para Datos Específicos de Instancia

```csharp
// ✅ BIEN: Instance variables para datos específicos
public class BankAccount
{
    private decimal _balance; // Cada cuenta tiene su propio balance
    private string _accountNumber; // Cada cuenta tiene su propio número
}
```

### 3. Usar Static Variables para Datos Compartidos

```csharp
// ✅ BIEN: Static variables para datos compartidos
public class Employee
{
    public static int TotalEmployees = 0; // Compartido por todos
    
    public Employee()
    {
        TotalEmployees++; // Incrementa el contador compartido
    }
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Confundir Instancia con Referencia

```csharp
// ❌ MAL: Asumir que es una copia
Person person1 = new Person { Name = "Alice" };
Person person2 = person1;
person2.Name = "Bob";
// person1.Name también es "Bob" - ¡es la misma instancia!

// ✅ BIEN: Crear nueva instancia si necesitas copia
Person person1 = new Person { Name = "Alice" };
Person person2 = new Person { Name = "Alice" }; // Nueva instancia
// Ahora son objetos diferentes
```

### 2. Modificar Static Variables sin Precauciones

```csharp
// ⚠️ CUIDADO: Static variables son compartidas
public class Counter
{
    public static int Count = 0; // Compartida por todas las instancias
}

Counter counter1 = new Counter();
Counter.Count = 10; // Afecta a TODAS las instancias
Counter counter2 = new Counter();
Console.WriteLine(Counter.Count); // 10 (compartida)

// ✅ BIEN: Usar thread-safe para static variables en aplicaciones multi-thread
public class Counter
{
    private static int _count = 0;
    private static readonly object _lock = new object();
    
    public static int Count
    {
        get
        {
            lock (_lock)
            {
                return _count;
            }
        }
    }
    
    public static void Increment()
    {
        lock (_lock)
        {
            _count++;
        }
    }
}
```

### 3. Acceder a Instance Variables sin Instancia

```csharp
// ❌ MAL: Intentar acceder a instance variable sin instancia
public class Person
{
    public string Name { get; set; }
}

Console.WriteLine(Person.Name); // Error - Name es instance variable

// ✅ BIEN: Crear instancia primero
Person person = new Person { Name = "Alice" };
Console.WriteLine(person.Name); // OK
```

### 4. Usar Static Variables cuando Instance Variables son Apropiadas

```csharp
// ❌ MAL: Usar static para datos que deberían ser de instancia
public class BankAccount
{
    public static decimal Balance; // MAL - cada cuenta debería tener su propio balance
}

// ✅ BIEN: Usar instance variable
public class BankAccount
{
    private decimal _balance; // Cada cuenta tiene su propio balance
}
```

## 🎯 Casos de Uso Específicos

### 1. Instance Variables para Datos Únicos

```csharp
// ✅ BIEN: Instance variables para datos únicos por instancia
public class Student
{
    private string _name; // Cada estudiante tiene su propio nombre
    private int _grade; // Cada estudiante tiene su propia calificación
    
    public Student(string name, int grade)
    {
        _name = name;
        _grade = grade;
    }
}
```

### 2. Static Variables para Contadores y Configuración

```csharp
// ✅ BIEN: Static variables para contadores compartidos
public class Order
{
    private static int _orderCounter = 0;
    private int _orderId;
    
    public Order()
    {
        _orderCounter++;
        _orderId = _orderCounter;
    }
    
    public int OrderId => _orderId;
    public static int TotalOrders => _orderCounter;
}
```

### 3. Referencias para Compartir Objetos

```csharp
// ✅ BIEN: Usar referencias cuando múltiples partes necesitan el mismo objeto
public class ShoppingCart
{
    private readonly List<OrderItem> _items;
    
    public ShoppingCart()
    {
        _items = new List<OrderItem>();
    }
    
    public void AddItem(OrderItem item)
    {
        _items.Add(item);
    }
}

// Múltiples servicios pueden tener referencia al mismo carrito
var cart = new ShoppingCart();
var checkoutService = new CheckoutService(cart);
var cartService = new CartService(cart);
// Ambos servicios trabajan con el mismo carrito
```

## 📊 Comparación Visual

| Concepto | Memoria | Compartido | Uso |
|----------|---------|------------|-----|
| **Instance** | Nueva memoria | No | Datos únicos por objeto |
| **Reference** | Misma memoria | Sí | Compartir mismo objeto |
| **Instance Variable** | Separada por instancia | No | Datos específicos |
| **Static Variable** | Compartida | Sí | Datos compartidos |

## 🚀 Tips Avanzados

### 1. Clonación Profunda vs Superficial

```csharp
// ✅ BIEN: Clonación profunda para crear copia real
public class Person : ICloneable
{
    public string Name { get; set; }
    
    public object Clone()
    {
        return new Person { Name = this.Name };
    }
}

Person person1 = new Person { Name = "Alice" };
Person person2 = (Person)person1.Clone(); // Nueva instancia con copia de datos
```

### 2. Static Constructors

```csharp
// ✅ BIEN: Static constructor para inicializar static variables
public class Configuration
{
    public static string ConnectionString { get; private set; }
    
    static Configuration()
    {
        ConnectionString = "Default connection string";
    }
}
```

### 3. Thread-Safe Static Variables

```csharp
// ✅ BIEN: Thread-safe para static variables en aplicaciones multi-thread
public class Counter
{
    private static int _count = 0;
    private static readonly object _lock = new object();
    
    public static void Increment()
    {
        lock (_lock)
        {
            _count++;
        }
    }
    
    public static int Count
    {
        get
        {
            lock (_lock)
            {
                return _count;
            }
        }
    }
}
```

### 4. Usar Readonly para Referencias

```csharp
// ✅ BIEN: readonly para referencias que no deben cambiar
public class Service
{
    private readonly IRepository _repository; // Referencia readonly
    
    public Service(IRepository repository)
    {
        _repository = repository; // Solo se puede asignar en constructor
    }
    
    // _repository = new Repository(); // Error - readonly
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Classes](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/classes)
- [Microsoft Docs - Static Members](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members)
- [Microsoft Docs - Reference Types](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/reference-types)

