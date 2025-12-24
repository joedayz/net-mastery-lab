# Object-Oriented Programming: Key Class Concepts 🎯

## Introducción

Comprender los conceptos clave de clases es fundamental para dominar la Programación Orientada a Objetos (OOP). Este concepto cubre tres aspectos esenciales: instancias de clases, referencias de clases y variables de clases.

## 📖 Instance of a Class (Instancia de una Clase)

Una instancia de una clase es un **objeto** creado a partir de esa **clase**. Se inicializa usando la palabra clave "**new**" y tiene su propia asignación de memoria. Cada instancia tiene su propio conjunto de variables de instancia, que no se comparten con otras instancias de la misma **clase**.

### Características de una Instancia

- **Creación**: Se crea usando la palabra clave `new`
- **Memoria**: Cada instancia tiene su propia asignación de memoria
- **Variables**: Cada instancia tiene su propio conjunto de variables de instancia
- **Independencia**: Las instancias son independientes entre sí

### Ejemplo

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// Crear instancias de la clase Person
Person person1 = new Person { Name = "Alice", Age = 30 };
Person person2 = new Person { Name = "Bob", Age = 25 };

// Cada instancia tiene su propia memoria y variables
Console.WriteLine(person1.Name); // "Alice"
Console.WriteLine(person2.Name); // "Bob"

// Cambiar person1 no afecta a person2
person1.Age = 31;
Console.WriteLine(person2.Age); // Sigue siendo 25
```

## 🔗 Reference of a Class (Referencia de una Clase)

Una referencia a una instancia de clase **no es una "copia"** de la clase. Es una variable que contiene la dirección de memoria de una instancia existente. Las referencias no crean nuevas instancias ni asignan nueva memoria para el objeto mismo. En su lugar, proporcionan formas adicionales de acceder y manipular el mismo objeto en memoria. Cualquier cambio realizado a través de una referencia se reflejará al acceder al objeto a través de otras referencias a la misma instancia.

### Características de una Referencia

- **No es una copia**: Una referencia apunta a la misma instancia en memoria
- **Misma memoria**: Todas las referencias apuntan al mismo objeto
- **Cambios compartidos**: Los cambios a través de una referencia se ven en todas las referencias
- **No crea nueva instancia**: Solo crea una nueva variable que apunta al mismo objeto

### Ejemplo

```csharp
// Crear una instancia
Person person1 = new Person { Name = "Alice", Age = 30 };

// Crear una referencia (no una copia)
Person person2 = person1;

// Ambas referencias apuntan al mismo objeto en memoria
Console.WriteLine(person1.Name); // "Alice"
Console.WriteLine(person2.Name); // "Alice"

// Cambiar a través de una referencia afecta a todas las referencias
person2.Name = "Bob";
Console.WriteLine(person1.Name); // "Bob" (¡cambió!)
Console.WriteLine(person2.Name); // "Bob"

// Verificar que son la misma instancia
Console.WriteLine(ReferenceEquals(person1, person2)); // True
```

### Comparación: Instancia vs Referencia

```csharp
// INSTANCIA: Crea un nuevo objeto en memoria
Person person1 = new Person { Name = "Alice", Age = 30 };
Person person2 = new Person { Name = "Bob", Age = 25 };
// person1 y person2 son objetos diferentes en memoria

// REFERENCIA: Apunta al mismo objeto
Person person3 = person1;
// person3 y person1 apuntan al mismo objeto en memoria
```

## 📊 Variable of a Class (Variable de una Clase)

Hay típicamente dos tipos de variables asociadas con una clase:

### a. Instance Variables (Variables de Instancia)

Estas son variables declaradas dentro de la clase y pertenecen a cada instancia de la clase. Cada objeto creado a partir de la clase tiene su propia copia de las variables de instancia.

#### Características

- **Pertenecen a la instancia**: Cada objeto tiene su propia copia
- **No compartidas**: Los cambios en una instancia no afectan a otras
- **Acceso**: Se accede a través de una instancia del objeto

#### Ejemplo

```csharp
public class BankAccount
{
    // Instance variables - cada instancia tiene su propia copia
    private decimal _balance;
    private string _accountNumber;
    
    public BankAccount(string accountNumber, decimal initialBalance)
    {
        _accountNumber = accountNumber;
        _balance = initialBalance;
    }
    
    public decimal Balance => _balance;
    public string AccountNumber => _accountNumber;
}

// Cada instancia tiene sus propias variables
BankAccount account1 = new BankAccount("ACC-001", 1000m);
BankAccount account2 = new BankAccount("ACC-002", 2000m);

Console.WriteLine(account1.Balance); // 1000
Console.WriteLine(account2.Balance); // 2000

// Cambiar account1 no afecta a account2
account1.Deposit(500m);
Console.WriteLine(account1.Balance); // 1500
Console.WriteLine(account2.Balance); // Sigue siendo 2000
```

### b. Class Variables / Static Variables (Variables de Clase / Estáticas)

Estas son variables que pertenecen a la clase misma, no a ninguna instancia específica. Se comparten entre todas las instancias de la clase y pueden ser accedidas sin crear un objeto de la clase.

#### Características

- **Pertenecen a la clase**: No a instancias individuales
- **Compartidas**: Todas las instancias comparten la misma variable
- **Acceso**: Se accede a través del nombre de la clase
- **Palabra clave**: Se declaran con `static`

#### Ejemplo

```csharp
public class Counter
{
    // Instance variable - cada instancia tiene su propia copia
    private int _instanceCount;
    
    // Static variable - compartida por todas las instancias
    public static int TotalCount = 0;
    
    public Counter()
    {
        _instanceCount = 0;
        TotalCount++; // Incrementa la variable compartida
    }
    
    public int InstanceCount => _instanceCount;
    
    public void Increment()
    {
        _instanceCount++;
        TotalCount++; // Incrementa la variable compartida
    }
}

// Acceder a variable estática sin crear instancia
Console.WriteLine(Counter.TotalCount); // 0

// Crear instancias
Counter counter1 = new Counter();
Counter counter2 = new Counter();

Console.WriteLine(Counter.TotalCount); // 2 (compartida por ambas instancias)
Console.WriteLine(counter1.InstanceCount); // 0 (propia de counter1)
Console.WriteLine(counter2.InstanceCount); // 0 (propia de counter2)

counter1.Increment();
Console.WriteLine(Counter.TotalCount); // 3 (compartida)
Console.WriteLine(counter1.InstanceCount); // 1 (propia)
Console.WriteLine(counter2.InstanceCount); // 0 (propia)
```

## 💡 Ejemplos Prácticos

### Ejemplo 1: Instancias Independientes

```csharp
public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
}

// Crear instancias independientes
Student student1 = new Student { Name = "Alice", Grade = 95 };
Student student2 = new Student { Name = "Bob", Grade = 87 };

// Cada instancia es independiente
student1.Grade = 100; // Solo afecta a student1
Console.WriteLine(student2.Grade); // Sigue siendo 87
```

### Ejemplo 2: Referencias al Mismo Objeto

```csharp
Student student1 = new Student { Name = "Alice", Grade = 95 };
Student student2 = student1; // Referencia, no copia

// Ambas referencias apuntan al mismo objeto
student2.Grade = 100;
Console.WriteLine(student1.Grade); // 100 (cambió porque es el mismo objeto)
```

### Ejemplo 3: Instance Variables vs Static Variables

```csharp
public class Employee
{
    // Instance variable - cada empleado tiene su propio ID
    public int EmployeeId { get; set; }
    
    // Static variable - compartida por todos los empleados
    public static int TotalEmployees = 0;
    
    public Employee(int id)
    {
        EmployeeId = id;
        TotalEmployees++; // Incrementa el contador compartido
    }
}

// Acceder a variable estática sin instancia
Console.WriteLine(Employee.TotalEmployees); // 0

// Crear empleados
Employee emp1 = new Employee(1);
Employee emp2 = new Employee(2);
Employee emp3 = new Employee(3);

Console.WriteLine(Employee.TotalEmployees); // 3 (compartida)
Console.WriteLine(emp1.EmployeeId); // 1 (propia)
Console.WriteLine(emp2.EmployeeId); // 2 (propia)
Console.WriteLine(emp3.EmployeeId); // 3 (propia)
```

## 🎯 Comparación Visual

| Concepto | Descripción | Memoria | Compartido |
|----------|-------------|---------|------------|
| **Instance** | Objeto creado con `new` | Nueva memoria | No |
| **Reference** | Variable que apunta a instancia existente | Misma memoria | Sí |
| **Instance Variable** | Variable de cada instancia | Separada por instancia | No |
| **Static Variable** | Variable de la clase | Compartida | Sí |

## ⚠️ Errores Comunes a Evitar

### 1. Confundir Instancia con Referencia

```csharp
// ❌ MAL: Asumir que es una copia
Person person1 = new Person { Name = "Alice" };
Person person2 = person1;
person2.Name = "Bob";
// person1.Name también es "Bob" - ¡es la misma instancia!

// ✅ BIEN: Entender que es una referencia
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

## 📚 Recursos Adicionales

- [Microsoft Docs - Classes](https://docs.microsoft.com/dotnet/csharp/fundamentals/types/classes)
- [Microsoft Docs - Static Members](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members)
- [Microsoft Docs - Reference Types](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/reference-types)

