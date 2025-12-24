# Mejores Prácticas: Pass By Reference vs Pass By Value

## ✅ Reglas de Oro

### 1. Preferir Pass By Value para Reference Types

```csharp
// ✅ BIEN: Pass by value es más seguro por defecto
void ProcessUser(User user)
{
    user.Name = "Updated";  // Modifica el objeto original
    // No puedes reasignar user accidentalmente
}

// ❌ MAL: Usar ref innecesariamente
void ProcessUser(ref User user)  // ¿Realmente necesitas reasignar?
{
    user.Name = "Updated";
}
```

### 2. Usar `ref` Solo Cuando es Necesario

```csharp
// ✅ BIEN: Usar ref solo cuando realmente necesitas reasignar
void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

// ❌ MAL: Usar ref innecesariamente
void ProcessUser(ref User user)
{
    user.Name = "Updated";  // No necesitas ref aquí
}
```

### 3. Usar `out` para Métodos Try-Pattern

```csharp
// ✅ BIEN: Patrón Try-Pattern con out
bool TryGetUser(int id, out User? user)
{
    user = _repository.Find(id);
    return user != null;
}

// Uso
if (TryGetUser(1, out var user))
{
    Console.WriteLine(user.Name);
}
```

### 4. Usar `in` para Structs Grandes

```csharp
// ✅ BIEN: in para structs grandes de solo lectura
void CalculateTotal(in Order order)
{
    var total = order.Items.Sum(i => i.Price);  // Lee sin copiar
    // order.Items = null;  // ❌ Error: no se puede modificar
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Asumir que Reference Types se Pasan por Referencia por Defecto

```csharp
// ❌ MAL: Asumir que reasignar afecta al original
void Reassign(Person person)
{
    person = new Person { Name = "New" };  // Solo afecta la copia local
}

Person p = new Person { Name = "Original" };
Reassign(p);
Console.WriteLine(p.Name);  // Output: "Original" (no cambió)

// ✅ BIEN: Usar ref si necesitas reasignar
void Reassign(ref Person person)
{
    person = new Person { Name = "New" };  // Afecta al original
}
```

### 2. Intentar Modificar Value Types sin `ref`

```csharp
// ❌ MAL: Modificar value type sin ref
void Swap(int a, int b)
{
    int temp = a;
    a = b;
    b = temp;  // No funciona - solo afecta copias locales
}

int x = 10, y = 20;
Swap(x, y);
Console.WriteLine($"x = {x}, y = {y}");  // Output: x = 10, y = 20 (no cambió)

// ✅ BIEN: Usar ref para modificar
void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;  // Funciona - afecta a los originales
}

int x2 = 10, y2 = 20;
Swap(ref x2, ref y2);
Console.WriteLine($"x = {x2}, y = {y2}");  // Output: x = 20, y = 10 (cambió)
```

### 3. No Asignar Variables `out` Dentro del Método

```csharp
// ❌ MAL: No asignar variable out
bool TryGetValue(out int value)
{
    if (someCondition)
    {
        return true;  // Error: value no fue asignado
    }
    value = 0;
    return false;
}

// ✅ BIEN: Siempre asignar variable out
bool TryGetValue(out int value)
{
    value = 0;  // Asignar valor por defecto primero
    if (someCondition)
    {
        value = 42;
        return true;
    }
    return false;
}
```

## 🎯 Casos de Uso Específicos

### 1. Modificar Value Types

```csharp
// ✅ BIEN: Usar ref para modificar value types
void Increment(ref int value)
{
    value++;  // Afecta al original
}

int num = 10;
Increment(ref num);
Console.WriteLine(num);  // Output: 11
```

### 2. Intercambiar Valores (Swap)

```csharp
// ✅ BIEN: Swap usando ref
void Swap<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}

int x = 10, y = 20;
Swap(ref x, ref y);
Console.WriteLine($"x = {x}, y = {y}");  // Output: x = 20, y = 10
```

### 3. Múltiples Valores de Retorno

```csharp
// ✅ BIEN: out para múltiples valores de retorno
bool TryDivide(int dividend, int divisor, out int quotient, out int remainder)
{
    if (divisor == 0)
    {
        quotient = 0;
        remainder = 0;
        return false;
    }
    
    quotient = dividend / divisor;
    remainder = dividend % divisor;
    return true;
}
```

### 4. Structs Grandes de Solo Lectura

```csharp
// ✅ BIEN: in para structs grandes
public struct LargeStruct
{
    public int Field1;
    public int Field2;
    // ... muchos campos más
}

void ProcessLargeStruct(in LargeStruct data)
{
    var value = data.Field1 + data.Field2;  // Lee sin copiar
}
```

## 📊 Tabla de Decisión

| Escenario | Recomendación | Razón |
|-----------|---------------|-------|
| Modificar propiedades de objeto | Pass By Value | Comportamiento por defecto, más seguro |
| Reasignar reference type | `ref` | Necesitas cambiar qué objeto referencia |
| Modificar value type | `ref` | Necesitas modificar el valor original |
| Múltiples valores de retorno | `out` | Patrón Try-Pattern estándar |
| Struct grande de solo lectura | `in` | Evita copias costosas |
| Intercambiar valores (swap) | `ref` | Necesitas modificar ambos valores |

## 💡 Pro Tips

### 1. Usar `out` en C# 7.0+ con Declaración Inline

```csharp
// ✅ BIEN: Declaración inline de out (C# 7.0+)
if (TryGetUser(1, out var user))
{
    Console.WriteLine(user.Name);
}
```

### 2. Combinar `ref` con `readonly` para Inmutabilidad

```csharp
// ✅ BIEN: ref readonly para structs grandes (C# 7.2+)
void ProcessLargeStruct(ref readonly LargeStruct data)
{
    var value = data.Field1;  // Lee sin copiar
    // data.Field1 = 10;  // ❌ Error: no se puede modificar
}
```

### 3. Usar Tuplas en lugar de `out` para Múltiples Valores

```csharp
// ✅ BIEN: Tuplas para múltiples valores (C# 7.0+)
(int quotient, int remainder) Divide(int dividend, int divisor)
{
    return (dividend / divisor, dividend % divisor);
}

var (q, r) = Divide(10, 3);
```

## 📚 Recursos Adicionales

- [Microsoft Docs - ref keyword](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/ref)
- [Microsoft Docs - out keyword](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/out-parameter-modifier)
- [Microsoft Docs - in keyword](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/in-parameter-modifier)
- [Microsoft Docs - Passing Parameters](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/passing-parameters)

