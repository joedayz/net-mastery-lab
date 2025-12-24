# Keywords en C# 🔑

## Introducción

Los **Keywords** (palabras clave) son los bloques fundamentales de la sintaxis de C#. Son palabras reservadas predefinidas para el compilador de C# que tienen significados especiales y no pueden usarse como identificadores. Comprenderlos a fondo te convertirá en un desarrollador C# más efectivo.

## 📖 ¿Qué son los Keywords?

Los keywords son palabras reservadas que tienen un significado especial en C#. No puedes usarlos como nombres de variables, clases, métodos, etc., a menos que uses el prefijo `@` para escaparlos.

```csharp
// ❌ MAL: No puedes usar keywords como identificadores
int class = 5; // Error: 'class' es un keyword

// ✅ BIEN: Usar @ para escapar keywords
int @class = 5; // Correcto, pero no recomendado
```

## 🔑 Access Modifiers (Modificadores de Acceso)

Los modificadores de acceso controlan la visibilidad y accesibilidad de tipos y miembros.

### public 🔓
**Accesible desde cualquier código**

```csharp
public class PublicClass
{
    public int PublicProperty { get; set; }
    public void PublicMethod() { }
}

// Accesible desde cualquier parte del código
var instance = new PublicClass();
instance.PublicProperty = 10;
```

### private 🔒
**Solo accesible dentro de la misma clase/struct**

```csharp
public class MyClass
{
    private int _privateField;
    
    private void PrivateMethod()
    {
        _privateField = 10; // Accesible aquí
    }
}

// ❌ No accesible desde fuera de la clase
// var value = instance._privateField; // Error
```

### protected 🛡️
**Accesible en la misma clase y clases derivadas**

```csharp
public class BaseClass
{
    protected int ProtectedField;
    
    protected void ProtectedMethod() { }
}

public class DerivedClass : BaseClass
{
    public void UseProtected()
    {
        ProtectedField = 10; // ✅ Accesible en clase derivada
        ProtectedMethod(); // ✅ Accesible en clase derivada
    }
}
```

### internal 🏠
**Accesible dentro del mismo assembly**

```csharp
internal class InternalClass
{
    internal int InternalProperty { get; set; }
}

// Accesible solo dentro del mismo proyecto/assembly
```

### protected internal 🛡️🏠
**Combinación de protected e internal**

```csharp
public class MyClass
{
    protected internal int ProtectedInternalField;
    
    // Accesible en:
    // 1. Misma clase
    // 2. Clases derivadas (incluso en otros assemblies)
    // 3. Cualquier clase en el mismo assembly
}
```

## 🏗️ Declaration Keywords (Keywords de Declaración)

Keywords para definir tipos y estructuras.

### class 🏫
**Define una clase**

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

### interface 🔗
**Declara una interfaz**

```csharp
public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
    bool ValidatePayment();
}
```

### struct 📦
**Crea un tipo de valor**

```csharp
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
```

### enum 📜
**Define una enumeración**

```csharp
public enum OrderStatus
{
    Pending,
    Processing,
    Completed,
    Cancelled
}

// Uso
var status = OrderStatus.Pending;
```

### record 📖
**Define una clase de datos inmutable (C# 9.0+)**

```csharp
public record Person(string Name, int Age);

// Uso
var person = new Person("John", 30);
var updated = person with { Age = 31 };
```

## 🧱 Type Keywords (Keywords de Tipo)

Keywords para tipos de datos básicos.

### string 📝
**Tipo de datos de texto**

```csharp
string name = "John Doe";
string message = $"Hello, {name}!";
```

### int 🔢
**Entero de 32 bits**

```csharp
int age = 30;
int count = 100;
```

### bool ✅❌
**Valor booleano**

```csharp
bool isActive = true;
bool isValid = false;
```

### double ⚖️
**Número de punto flotante de doble precisión**

```csharp
double price = 99.99;
double temperature = 25.5;
```

### decimal 💰
**Números decimales de alta precisión**

```csharp
decimal salary = 50000.50m;
decimal total = 1234.56m;
```

### var 🌀
**Declaración de tipo implícito**

```csharp
var name = "John"; // string
var age = 30; // int
var isActive = true; // bool

// El tipo se infiere del valor asignado
```

## 🛠️ Method and Property Modifiers (Modificadores de Métodos y Propiedades)

Keywords que modifican el comportamiento de métodos y propiedades.

### static 🗿
**Pertenece al tipo mismo, no a la instancia**

```csharp
public class MathHelper
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
    
    public static int Counter = 0;
}

// Uso sin instancia
var result = MathHelper.Add(5, 3);
var count = MathHelper.Counter;
```

### virtual 🔄
**Método puede ser sobrescrito**

```csharp
public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal sound");
    }
}

public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Woof!");
    }
}
```

### override 📝
**Implementa método virtual**

```csharp
public class BaseClass
{
    public virtual void Method() { }
}

public class DerivedClass : BaseClass
{
    public override void Method()
    {
        // Nueva implementación
    }
}
```

### abstract 📂
**Debe ser implementado por clase derivada**

```csharp
public abstract class Shape
{
    public abstract double GetArea();
}

public class Circle : Shape
{
    private double _radius;
    
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}
```

### async ⚡
**Método contiene operaciones asíncronas**

```csharp
public async Task<string> GetDataAsync()
{
    await Task.Delay(1000);
    return "Data loaded";
}
```

### await ⏳
**Espera la finalización de operación asíncrona**

```csharp
public async Task ProcessAsync()
{
    var data = await GetDataAsync();
    Console.WriteLine(data);
}
```

## 🔄 Control Flow (Flujo de Control)

Keywords para controlar el flujo de ejecución.

### if, else ❓
**Ejecución condicional**

```csharp
if (age >= 18)
{
    Console.WriteLine("Adult");
}
else
{
    Console.WriteLine("Minor");
}
```

### switch 🔀
**Decisión de múltiples ramas**

```csharp
switch (status)
{
    case OrderStatus.Pending:
        Console.WriteLine("Order is pending");
        break;
    case OrderStatus.Processing:
        Console.WriteLine("Order is processing");
        break;
    default:
        Console.WriteLine("Unknown status");
        break;
}
```

### for, foreach 🔁
**Sentencias de iteración**

```csharp
// for loop
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

// foreach loop
var numbers = new[] { 1, 2, 3, 4, 5 };
foreach (var number in numbers)
{
    Console.WriteLine(number);
}
```

### while, do 🔄
**Constructos de bucle**

```csharp
// while loop
int i = 0;
while (i < 10)
{
    Console.WriteLine(i);
    i++;
}

// do-while loop
int j = 0;
do
{
    Console.WriteLine(j);
    j++;
} while (j < 10);
```

### break 🚪
**Sale del bucle o switch**

```csharp
for (int i = 0; i < 10; i++)
{
    if (i == 5)
        break; // Sale del bucle
    Console.WriteLine(i);
}
```

### continue ⏩
**Salta a la siguiente iteración**

```csharp
for (int i = 0; i < 10; i++)
{
    if (i % 2 == 0)
        continue; // Salta números pares
    Console.WriteLine(i);
}
```

### return 🔙
**Sale del método con valor**

```csharp
public int Add(int a, int b)
{
    return a + b;
}

public void Process()
{
    if (condition)
        return; // Sale sin valor
    // Más código...
}
```

### throw 🚨
**Lanza una excepción**

```csharp
public void Validate(int value)
{
    if (value < 0)
        throw new ArgumentException("Value must be positive");
}
```

### try, catch, finally 🛠️
**Manejo de excepciones**

```csharp
try
{
    // Código que puede lanzar excepción
    var result = Divide(10, 0);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    // Siempre se ejecuta
    Console.WriteLine("Cleanup");
}
```

## 🚀 Modern C# Features (Características Modernas de C#)

Keywords introducidos en versiones recientes de C#.

### null 🚫
**Ausencia de valor**

```csharp
string? name = null; // Nullable reference type
int? age = null; // Nullable value type
```

### default 🛡️
**Valor por defecto del tipo**

```csharp
int value = default; // 0
string text = default; // null
bool flag = default; // false
```

### using 🧹
**Disposición de recursos**

```csharp
// using statement
using (var stream = new FileStream("file.txt", FileMode.Open))
{
    // Usar stream
} // Se dispone automáticamente

// using declaration (C# 8.0+)
using var stream = new FileStream("file.txt", FileMode.Open);
// Se dispone al final del scope
```

### is ❔
**Verificación de tipo**

```csharp
object obj = "Hello";

if (obj is string str)
{
    Console.WriteLine(str.ToUpper());
}
```

### as 🔄
**Conversión segura de tipo**

```csharp
object obj = "Hello";
string? str = obj as string;

if (str != null)
{
    Console.WriteLine(str);
}
```

### new() 🆕
**Instanciación de objeto**

```csharp
var person = new Person();
var list = new List<int>();
```

### nameof 🏷️
**Obtiene el nombre de variable/tipo**

```csharp
string name = "John";
Console.WriteLine(nameof(name)); // "name"
Console.WriteLine(nameof(Person)); // "Person"
```

### when 🧩
**Condición de pattern matching**

```csharp
switch (value)
{
    case int i when i > 0:
        Console.WriteLine("Positive");
        break;
    case int i when i < 0:
        Console.WriteLine("Negative");
        break;
}
```

## 🧠 Memory Management (Gestión de Memoria)

Keywords para gestión avanzada de memoria.

### fixed 📌
**Fija puntero en memoria**

```csharp
unsafe
{
    int[] array = { 1, 2, 3 };
    fixed (int* ptr = array)
    {
        // Usar ptr
    }
}
```

### unsafe ⚠️
**Permite operaciones con punteros**

```csharp
unsafe
{
    int* ptr;
    int value = 10;
    ptr = &value;
}
```

### stackalloc 📏
**Asignación en stack**

```csharp
unsafe
{
    int* numbers = stackalloc int[10];
    // Array en stack
}
```

### volatile 🔃
**Campo volátil entre threads**

```csharp
public class MyClass
{
    private volatile bool _isRunning;
    
    public void Stop()
    {
        _isRunning = false;
    }
}
```

## 📌 Contextual Keywords (Keywords Contextuales)

Keywords que solo tienen significado especial en ciertos contextos.

### value 📤
**Parámetro del setter de propiedad**

```csharp
private string _name;

public string Name
{
    get => _name;
    set => _name = value; // 'value' es el parámetro implícito
}
```

### get 🧾
**Accessor de propiedad**

```csharp
public string Name
{
    get { return _name; }
    set { _name = value; }
}
```

### set 🛠️
**Mutator de propiedad**

```csharp
public int Age
{
    get => _age;
    set => _age = value;
}
```

### yield 🔄
**Elemento de método iterador**

```csharp
public IEnumerable<int> GetNumbers()
{
    for (int i = 0; i < 10; i++)
    {
        yield return i;
    }
}
```

### partial 🧩
**Definición de tipo dividida**

```csharp
// Archivo 1
public partial class Person
{
    public string Name { get; set; }
}

// Archivo 2
public partial class Person
{
    public int Age { get; set; }
}
```

### where 📚
**Restricciones de tipo genérico**

```csharp
public class Repository<T> where T : class
{
    // T debe ser una clase
}

public interface IComparable<T> where T : IComparable<T>
{
    // Restricción más compleja
}
```

## 📊 Tabla Resumen de Keywords

| Categoría | Keywords Principales |
|-----------|---------------------|
| **Access Modifiers** | public, private, protected, internal, protected internal |
| **Declaration** | class, interface, struct, enum, record |
| **Types** | string, int, bool, double, decimal, var |
| **Method Modifiers** | static, virtual, override, abstract, async, await |
| **Control Flow** | if, else, switch, for, foreach, while, do, break, continue, return, throw, try, catch, finally |
| **Modern Features** | null, default, using, is, as, new, nameof, when |
| **Memory** | fixed, unsafe, stackalloc, volatile |
| **Contextual** | value, get, set, yield, partial, where |

## 📚 Recursos Adicionales

- [Microsoft Docs - C# Keywords](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/)
- [Microsoft Docs - C# Language Reference](https://docs.microsoft.com/dotnet/csharp/language-reference/)

## 📖 Nota Final

Los keywords son los bloques fundamentales de la sintaxis de C#. Comprenderlos a fondo te convertirá en un desarrollador C# más efectivo. Cada keyword tiene un propósito específico y entender cuándo y cómo usarlos es esencial para escribir código C# de calidad.

