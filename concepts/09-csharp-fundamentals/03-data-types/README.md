# Data Types en C# 📊

## Introducción

En programación, los tipos de datos juegan un papel crucial en cómo se almacena y accede a la información. Comprender la diferencia entre Value Types y Reference Types es fundamental para gestionar la memoria de manera eficiente y optimizar el rendimiento.

## 📖 Clasificación de Tipos de Datos en C#

Los tipos de datos en C# se clasifican en tres categorías principales:

1. **Value Data Types** (Tipos de Valor)
2. **Reference Data Types** (Tipos de Referencia)
3. **Pointer Data Type** (Tipo de Puntero) - Solo en código no seguro (unsafe)

## 💎 Value Types (Tipos de Valor)

Los **Value Types** almacenan directamente los datos. Una vez asignados, contienen ese valor específico. Se almacenan en la **stack** (pila) y se copian por valor cuando se asignan o pasan como parámetros.

### Características de Value Types

- **Almacenamiento**: Se almacenan en la stack
- **Copia**: Se copian por valor (cada variable tiene su propia copia)
- **Tamaño**: Generalmente pequeños y de tamaño fijo
- **Null**: No pueden ser null (excepto nullable types)
- **Rendimiento**: Más rápidos de acceder

### Pre-Defined Value Types (Predefinidos)

#### Tipos Numéricos Enteros

```csharp
byte b = 255;           // 0 a 255 (8 bits)
sbyte sb = -128;        // -128 a 127 (8 bits)
short s = -32768;       // -32,768 a 32,767 (16 bits)
ushort us = 65535;      // 0 a 65,535 (16 bits)
int i = -2147483648;    // -2,147,483,648 a 2,147,483,647 (32 bits)
uint ui = 4294967295;   // 0 a 4,294,967,295 (32 bits)
long l = -9223372036854775808;  // 64 bits
ulong ul = 18446744073709551615; // 64 bits
```

#### Tipos Numéricos de Punto Flotante

```csharp
float f = 3.14f;        // ~7 dígitos de precisión (32 bits)
double d = 3.141592653589793; // ~15-17 dígitos de precisión (64 bits)
decimal dec = 123.456m; // 28-29 dígitos de precisión (128 bits)
```

#### Otros Tipos Predefinidos

```csharp
bool flag = true;       // true o false
char c = 'A';           // Carácter Unicode (16 bits)
```

### User-Defined Value Types (Definidos por el Usuario)

#### Enumeration (Enum)

```csharp
public enum Status
{
    Pending,
    InProgress,
    Completed,
    Cancelled
}

Status currentStatus = Status.Pending;
```

#### Structure (Struct)

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

Point p1 = new Point(10, 20);
Point p2 = p1; // Copia por valor
p2.X = 30;    // p1.X sigue siendo 10
```

## 🔗 Reference Types (Tipos de Referencia)

Los **Reference Types** contienen una dirección de memoria que apunta a la ubicación real de los datos, no los datos mismos. Se almacenan en la **heap** (montón) y se copian por referencia cuando se asignan o pasan como parámetros.

### Características de Reference Types

- **Almacenamiento**: Se almacenan en la heap
- **Copia**: Se copian por referencia (múltiples variables pueden apuntar al mismo objeto)
- **Tamaño**: Pueden ser de cualquier tamaño
- **Null**: Pueden ser null
- **Rendimiento**: Más lentos de acceder (requieren indirección)

### Pre-Defined Reference Types (Predefinidos)

#### Object

```csharp
object obj = new object();
object str = "Hello";   // string es también un reference type
object num = 42;        // Boxing: int se convierte a object
```

#### String

```csharp
string str1 = "Hello";
string str2 = str1;     // str2 apunta a la misma cadena
// Nota: string es inmutable, así que modificar crea nueva instancia
```

### User-Defined Reference Types (Definidos por el Usuario)

#### Class

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

Person p1 = new Person { Name = "Alice", Age = 30 };
Person p2 = p1;         // p2 apunta al mismo objeto
p2.Name = "Bob";        // p1.Name también es "Bob"
```

#### Interface

```csharp
public interface ILogger
{
    void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message) { /* ... */ }
}

ILogger logger = new FileLogger(); // Reference type
```

#### Array

```csharp
int[] numbers = new int[] { 1, 2, 3, 4, 5 };
int[] copy = numbers;   // copy apunta al mismo array
copy[0] = 10;           // numbers[0] también es 10
```

## 🔄 Comparación: Value Types vs Reference Types

### Ejemplo 1: Asignación

```csharp
// VALUE TYPE: Copia por valor
int a = 10;
int b = a;      // b es una copia independiente
b = 20;         // a sigue siendo 10
Console.WriteLine($"a = {a}, b = {b}"); // a = 10, b = 20

// REFERENCE TYPE: Copia por referencia
Person p1 = new Person { Name = "Alice" };
Person p2 = p1;         // p2 apunta al mismo objeto
p2.Name = "Bob";        // p1.Name también es "Bob"
Console.WriteLine($"p1.Name = {p1.Name}, p2.Name = {p2.Name}"); 
// p1.Name = Bob, p2.Name = Bob
```

### Ejemplo 2: Pasar como Parámetros

```csharp
// VALUE TYPE: Se pasa por valor (copia)
void ModifyInt(int value)
{
    value = 100; // No afecta al original
}

int num = 10;
ModifyInt(num);
Console.WriteLine(num); // Sigue siendo 10

// REFERENCE TYPE: Se pasa por referencia (puntero)
void ModifyPerson(Person person)
{
    person.Name = "Modified"; // Afecta al original
}

Person p = new Person { Name = "Original" };
ModifyPerson(p);
Console.WriteLine(p.Name); // "Modified"
```

### Ejemplo 3: Comparación

```csharp
// VALUE TYPE: Comparación por valor
int a = 10;
int b = 10;
bool areEqual = (a == b); // true (comparan valores)

// REFERENCE TYPE: Comparación por referencia
Person p1 = new Person { Name = "Alice" };
Person p2 = new Person { Name = "Alice" };
bool areEqual = (p1 == p2); // false (comparan referencias, no valores)

// Para comparar valores en reference types, usar Equals()
bool areEqualValues = p1.Equals(p2); // true (si está implementado)
```

## 📊 Tabla Comparativa

| Característica | Value Types | Reference Types |
|----------------|-------------|-----------------|
| **Almacenamiento** | Stack | Heap |
| **Copia** | Por valor | Por referencia |
| **Null** | No (excepto nullable) | Sí |
| **Rendimiento** | Más rápido | Más lento |
| **Tamaño** | Fijo, pequeño | Variable, puede ser grande |
| **Ejemplos** | int, char, bool, struct | string, class, array, interface |

## 💡 Ejemplos Prácticos

### Ejemplo 1: Value Type - Struct

```csharp
public struct Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }
}

Coordinate c1 = new Coordinate { X = 10, Y = 20 };
Coordinate c2 = c1;     // Copia por valor
c2.X = 30;              // c1.X sigue siendo 10

Console.WriteLine($"c1: ({c1.X}, {c1.Y})"); // (10, 20)
Console.WriteLine($"c2: ({c2.X}, {c2.Y})"); // (30, 20)
```

### Ejemplo 2: Reference Type - Class

```csharp
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
}

Address addr1 = new Address { Street = "Main St", City = "NYC" };
Address addr2 = addr1;     // Referencia al mismo objeto
addr2.City = "LA";          // addr1.City también es "LA"

Console.WriteLine($"addr1.City: {addr1.City}"); // LA
Console.WriteLine($"addr2.City: {addr2.City}"); // LA
```

### Ejemplo 3: Nullable Value Types

```csharp
// Value types pueden ser null usando nullable
int? nullableInt = null;
bool? nullableBool = null;

// O usando Nullable<T>
Nullable<int> number = null;

// Verificar si tiene valor
if (nullableInt.HasValue)
{
    Console.WriteLine($"Value: {nullableInt.Value}");
}
else
{
    Console.WriteLine("No value");
}

// Null-coalescing operator
int result = nullableInt ?? 0; // Si es null, usa 0
```

## ⚠️ Errores Comunes a Evitar

### 1. Asumir que Value Types se Copian como Reference Types

```csharp
// ❌ MAL: Asumir que struct se comporta como class
public struct Point
{
    public int X { get; set; }
}

Point p1 = new Point { X = 10 };
Point p2 = p1;
p2.X = 20;
// p1.X sigue siendo 10, no 20

// ✅ BIEN: Entender que struct se copia por valor
```

### 2. Comparar Reference Types con ==

```csharp
// ⚠️ CUIDADO: == compara referencias, no valores
Person p1 = new Person { Name = "Alice" };
Person p2 = new Person { Name = "Alice" };
bool areEqual = (p1 == p2); // false (referencias diferentes)

// ✅ BIEN: Usar Equals() para comparar valores
bool areEqualValues = p1.Equals(p2); // true (si Equals está implementado)
```

### 3. Modificar Value Types en Métodos sin ref/out

```csharp
// ❌ MAL: Intentar modificar value type sin ref
void Increment(int value)
{
    value++; // No afecta al original
}

int num = 10;
Increment(num);
Console.WriteLine(num); // Sigue siendo 10

// ✅ BIEN: Usar ref para modificar
void Increment(ref int value)
{
    value++; // Afecta al original
}

int num = 10;
Increment(ref num);
Console.WriteLine(num); // 11
```

## 🎯 Cuándo Usar Cada Tipo

### Usa Value Types cuando:
- Necesitas tipos simples y pequeños (int, bool, char)
- Quieres copias independientes de los datos
- Necesitas máximo rendimiento
- Los datos son inmutables o raramente cambian
- Ejemplos: coordenadas, colores, configuraciones simples

### Usa Reference Types cuando:
- Necesitas objetos complejos con comportamiento
- Quieres compartir el mismo objeto entre múltiples referencias
- Los objetos pueden ser null
- Necesitas herencia y polimorfismo
- Ejemplos: entidades de dominio, servicios, repositorios

## 📚 Recursos Adicionales

- [Microsoft Docs - Value Types](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/value-types)
- [Microsoft Docs - Reference Types](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/reference-types)
- [Microsoft Docs - Structs](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/struct)
- [Microsoft Docs - Boxing and Unboxing](https://docs.microsoft.com/dotnet/csharp/programming-guide/types/boxing-and-unboxing)

