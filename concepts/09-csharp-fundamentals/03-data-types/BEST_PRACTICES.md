# Mejores Prácticas: Data Types

## ✅ Reglas de Oro

### 1. Entender la Diferencia entre Value Types y Reference Types

```csharp
// ✅ BIEN: Entender que value types se copian por valor
int a = 10;
int b = a;      // b es una copia independiente
b = 20;          // a sigue siendo 10

// ✅ BIEN: Entender que reference types se copian por referencia
Person p1 = new Person { Name = "Alice" };
Person p2 = p1;  // p2 apunta al mismo objeto
p2.Name = "Bob"; // p1.Name también es "Bob"
```

### 2. Usar Structs para Tipos Pequeños e Inmutables

```csharp
// ✅ BIEN: Struct para tipos pequeños e inmutables
public struct Point
{
    public int X { get; }
    public int Y { get; }
    
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// ✅ BIEN: Struct para tipos de valor que representan un solo valor
public struct Money
{
    public decimal Amount { get; }
    public string Currency { get; }
    
    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
}
```

### 3. Usar Classes para Tipos con Comportamiento

```csharp
// ✅ BIEN: Class para tipos con comportamiento y estado mutable
public class BankAccount
{
    private decimal _balance;
    
    public void Deposit(decimal amount)
    {
        _balance += amount;
    }
    
    public void Withdraw(decimal amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
        }
    }
}
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
// Si necesitas compartir el mismo objeto, usa class
```

### 2. Comparar Reference Types con == Esperando Comparación de Valores

```csharp
// ❌ MAL: == compara referencias, no valores
Person p1 = new Person { Name = "Alice" };
Person p2 = new Person { Name = "Alice" };
bool areEqual = (p1 == p2); // false (referencias diferentes)

// ✅ BIEN: Usar Equals() para comparar valores
bool areEqualValues = p1.Equals(p2); // true (si Equals está implementado)

// ✅ BIEN: Implementar Equals() y GetHashCode() en clases
public class Person
{
    public string Name { get; set; }
    
    public override bool Equals(object? obj)
    {
        return obj is Person person && Name == person.Name;
    }
    
    public override int GetHashCode()
    {
        return Name?.GetHashCode() ?? 0;
    }
}
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

### 4. Usar Structs para Tipos Grandes o Mutables

```csharp
// ❌ MAL: Struct grande o mutable puede ser ineficiente
public struct LargeStruct
{
    public int Field1;
    public int Field2;
    // ... muchos campos más
    // Copiar este struct es costoso
}

// ✅ BIEN: Usar class para tipos grandes o mutables
public class LargeObject
{
    public int Field1 { get; set; }
    public int Field2 { get; set; }
    // ... muchos campos más
    // Solo se copia la referencia
}
```

## 🎯 Casos de Uso Específicos

### 1. Usar Value Types para Tipos Simples

```csharp
// ✅ BIEN: Value types para tipos simples y pequeños
public struct Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }
}

// Uso eficiente: se copia por valor, no hay overhead de heap
Coordinate c1 = new Coordinate { X = 10, Y = 20 };
Coordinate c2 = c1; // Copia rápida
```

### 2. Usar Reference Types para Entidades de Dominio

```csharp
// ✅ BIEN: Reference types para entidades con comportamiento
public class Order
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal Total { get; private set; }
    
    public void CalculateTotal()
    {
        Total = Items.Sum(item => item.Price * item.Quantity);
    }
}
```

### 3. Usar Nullable Types para Valores Opcionales

```csharp
// ✅ BIEN: Nullable types para valores opcionales
public class User
{
    public string Name { get; set; }
    public int? Age { get; set; } // Puede ser null
    
    public bool HasAge => Age.HasValue;
    
    public string GetAgeDisplay()
    {
        return Age.HasValue ? Age.Value.ToString() : "Not specified";
    }
}
```

### 4. Implementar Equals() y GetHashCode() en Classes

```csharp
// ✅ BIEN: Implementar comparación de valores en classes
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public override bool Equals(object? obj)
    {
        if (obj is not Person person)
            return false;
            
        return Name == person.Name && Age == person.Age;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age);
    }
    
    // También implementar operadores == y !=
    public static bool operator ==(Person? left, Person? right)
    {
        if (ReferenceEquals(left, right))
            return true;
            
        if (left is null || right is null)
            return false;
            
        return left.Equals(right);
    }
    
    public static bool operator !=(Person? left, Person? right)
    {
        return !(left == right);
    }
}
```

## 🚀 Tips Avanzados

### 1. Boxing y Unboxing

```csharp
// ⚠️ CUIDADO: Boxing es costoso
int value = 42;
object boxed = value; // Boxing: int -> object (costo de memoria)
int unboxed = (int)boxed; // Unboxing: object -> int

// ✅ BIEN: Evitar boxing cuando sea posible
// Usar genéricos en lugar de object
List<int> numbers = new List<int>(); // No hay boxing
// En lugar de
ArrayList list = new ArrayList(); // Boxing para cada int
```

### 2. Usar Readonly Structs para Inmutabilidad

```csharp
// ✅ BIEN: readonly struct para garantizar inmutabilidad
public readonly struct ImmutablePoint
{
    public int X { get; }
    public int Y { get; }
    
    public ImmutablePoint(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// No se puede modificar después de la creación
ImmutablePoint p = new ImmutablePoint(10, 20);
// p.X = 30; // Error de compilación
```

### 3. Usar Record Types para Inmutabilidad (.NET 5+)

```csharp
// ✅ BIEN: Record types para tipos inmutables con igualdad por valor
public record Person
{
    public string Name { get; init; }
    public int Age { get; init; }
}

Person p1 = new Person { Name = "Alice", Age = 30 };
Person p2 = new Person { Name = "Alice", Age = 30 };
bool areEqual = p1 == p2; // true (comparación por valor automática)
```

### 4. Usar Span<T> y Memory<T> para Performance (.NET Core 2.1+)

```csharp
// ✅ BIEN: Span<T> para trabajar con memoria sin copias
int[] array = { 1, 2, 3, 4, 5 };
Span<int> span = array.AsSpan();
span[0] = 10; // Modifica el array original sin copia

// Útil para operaciones de alto rendimiento
```

### 5. Entender el Ciclo de Vida de Reference Types

```csharp
// ✅ BIEN: Entender garbage collection
Person p = new Person { Name = "Alice" };
// p está en la heap, será recolectado cuando no haya referencias

p = null; // Ya no hay referencias al objeto
// El objeto será elegible para garbage collection
```

## 📊 Cuándo Usar Cada Tipo

### Usa Value Types cuando:
- ✅ Necesitas tipos simples y pequeños (int, bool, char)
- ✅ Quieres copias independientes de los datos
- ✅ Necesitas máximo rendimiento
- ✅ Los datos son inmutables o raramente cambian
- ✅ Ejemplos: coordenadas, colores, configuraciones simples

### Usa Reference Types cuando:
- ✅ Necesitas objetos complejos con comportamiento
- ✅ Quieres compartir el mismo objeto entre múltiples referencias
- ✅ Los objetos pueden ser null
- ✅ Necesitas herencia y polimorfismo
- ✅ Ejemplos: entidades de dominio, servicios, repositorios

## 📚 Recursos Adicionales

- [Microsoft Docs - Value Types](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/value-types)
- [Microsoft Docs - Reference Types](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/reference-types)
- [Microsoft Docs - Structs](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/struct)
- [Microsoft Docs - Boxing and Unboxing](https://docs.microsoft.com/dotnet/csharp/programming-guide/types/boxing-and-unboxing)
- [Microsoft Docs - Records](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/record)

