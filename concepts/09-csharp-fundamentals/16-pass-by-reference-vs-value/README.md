# Pass By Reference vs Pass By Value en C# 🧠

## Introducción

Comprender cómo C# pasa parámetros a métodos es fundamental para escribir código correcto y eficiente. Este concepto separa a los desarrolladores junior de los senior y puede hacer o romper aplicaciones .NET.

## 🔍 ¿Qué REALMENTE Sucede Cuando Pasas Variables en C#?

Cuando pasas variables a métodos en C#, hay dos mecanismos principales:

1. **Pass By Value** (Pasar por Valor) - Comportamiento por defecto
2. **Pass By Reference** (Pasar por Referencia) - Usando `ref`, `out`, o `in`

## 🏆 Pass By Reference (Pasar por Referencia)

Cuando pasas por referencia en C#, tu método obtiene un enlace directo al objeto original—¡es como entregarle a alguien tu taza real! Cualquier cambio que hagan afecta TU taza.

### Usando la Palabra Clave `ref`

```csharp
// ✅ BIEN: Usando 'ref' para pasar por referencia explícita
void FillCup(ref Cup myCup)
{
    myCup.Contents = "coffee";  // ¡La taza original se modifica!
}

// Cuando llamas:
Cup myOriginalCup = new Cup();
FillCup(ref myOriginalCup);  // myOriginalCup.Contents ahora es "coffee"
```

**Características:**
- ✅ El método recibe una referencia directa al objeto original
- ✅ Cualquier modificación afecta al objeto original
- ✅ La variable debe estar inicializada antes de pasarla
- ✅ Puedes reasignar la variable dentro del método

### Ejemplo Completo con `ref`

```csharp
public class Cup
{
    public string Contents { get; set; } = string.Empty;
}

// Método que modifica usando ref
void FillCup(ref Cup myCup)
{
    myCup.Contents = "coffee";  // Modifica el original
}

// Uso
Cup originalCup = new Cup();
FillCup(ref originalCup);
Console.WriteLine(originalCup.Contents);  // Output: "coffee"
```

## 📦 Pass By Value (Pasar por Valor)

Cuando pasas por valor en C#, tu método recibe una copia de la referencia al objeto original. Aunque puedes modificar las propiedades del objeto, reasignar el parámetro mismo no afectará a la variable original—¡es como darle a alguien direcciones a tu taza, no la taza misma!

### Comportamiento por Defecto en C#

```csharp
// ✅ BIEN: Pasar por valor (comportamiento por defecto)
void FillCup(Cup myCup)
{
    myCup.Contents = "coffee";  // Modifica el objeto al que apunta la referencia
    // Pero si reasignas:
    myCup = new Cup();  // Esto NO afecta al original
}

// Cuando llamas:
Cup myOriginalCup = new Cup();
FillCup(myOriginalCup);  // myOriginalCup.Contents es "coffee"
// Pero si el método reasigna myCup, myOriginalCup NO cambia
```

**Características:**
- ✅ Se pasa una copia de la referencia (para reference types)
- ✅ Puedes modificar propiedades del objeto
- ✅ Reasignar el parámetro no afecta al original
- ✅ Es el comportamiento por defecto en C#

### Ejemplo Completo con Pass By Value

```csharp
public class Cup
{
    public string Contents { get; set; } = string.Empty;
}

// Método que recibe por valor
void FillCup(Cup myCup)
{
    myCup.Contents = "coffee";  // Modifica el objeto original
}

void TryReassign(Cup myCup)
{
    myCup = new Cup { Contents = "tea" };  // Solo afecta la copia local
}

// Uso
Cup originalCup = new Cup();
FillCup(originalCup);
Console.WriteLine(originalCup.Contents);  // Output: "coffee"

TryReassign(originalCup);
Console.WriteLine(originalCup.Contents);  // Output: "coffee" (no cambió)
```

## 💥 ¿Por Qué Este Concepto Hace o Rompe Aplicaciones .NET?

Entender esta distinción puede:

- 🐛 **Eliminar bugs difíciles de encontrar** en sistemas ASP.NET complejos
- 🚀 **Mejorar dramáticamente el rendimiento** a través de optimización de memoria
- 🛡️ **Proteger la integridad de datos** en operaciones de Entity Framework
- 🧩 **Hacer tus métodos C# más predecibles y testeables**

## ⚡ Comportamiento Específico de Parámetros en .NET

### 1. Value Types (int, float, struct) - Pass By Value

```csharp
// ✅ Value types se pasan por copia de su valor
void Increment(int number)
{
    number++;  // Solo afecta la copia local
}

int num = 10;
Increment(num);
Console.WriteLine(num);  // Output: 10 (no cambió)

// ✅ Para modificar, usa ref
void Increment(ref int number)
{
    number++;  // Afecta al original
}

int num2 = 10;
Increment(ref num2);
Console.WriteLine(num2);  // Output: 11 (cambió)
```

### 2. Reference Types (objects, arrays) - Pass By Value de la Referencia

```csharp
// ✅ Reference types pasan una copia de la referencia
void ModifyPerson(Person person)
{
    person.Name = "Modified";  // Modifica el objeto original
    person = new Person();     // Solo afecta la copia local de la referencia
}

Person p = new Person { Name = "Original" };
ModifyPerson(p);
Console.WriteLine(p.Name);  // Output: "Modified" (el objeto cambió)
```

### 3. Usar `ref` para Pasar por Referencia Explícita

```csharp
// ✅ ref permite pasar por referencia para cualquier tipo
void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

int x = 10;
int y = 20;
Swap(ref x, ref y);
Console.WriteLine($"x = {x}, y = {y}");  // Output: x = 20, y = 10
```

### 4. `out` Parameters - Similar a `ref` pero sin Inicialización

```csharp
// ✅ out no requiere que la variable esté inicializada
bool TryParse(string input, out int result)
{
    if (int.TryParse(input, out result))
    {
        return true;
    }
    result = 0;  // Debe asignarse antes de retornar
    return false;
}

int value;
if (TryParse("123", out value))
{
    Console.WriteLine(value);  // Output: 123
}
```

**Diferencias entre `ref` y `out`:**
- `ref`: La variable debe estar inicializada antes de pasarla
- `out`: La variable NO necesita estar inicializada, pero DEBE asignarse dentro del método

### 5. `in` Keyword (C# 7.0+) - Parámetros de Solo Lectura por Referencia

```csharp
// ✅ in permite pasar por referencia pero solo lectura
void ProcessLargeStruct(in LargeStruct data)
{
    // Puedes leer data pero no modificarlo
    var value = data.Field1;  // ✅ OK
    // data.Field1 = 10;      // ❌ Error de compilación
}

// Beneficio: Evita copiar structs grandes pero garantiza inmutabilidad
```

**Ventajas de `in`:**
- ✅ Evita copiar structs grandes (mejor rendimiento)
- ✅ Garantiza que el parámetro no se modifique
- ✅ Útil para structs grandes en métodos de solo lectura

## 📊 Comparación Visual

### Pass By Value (Comportamiento por Defecto)

```csharp
void FillCup(Cup myCup)
{
    myCup.Contents = "coffee";  // Modifica el objeto original
    myCup = new Cup();          // Solo afecta la copia local
}

Cup originalCup = new Cup();
FillCup(originalCup);
// originalCup.Contents es "coffee" (modificado)
// originalCup sigue siendo el mismo objeto (no reasignado)
```

### Pass By Reference (con `ref`)

```csharp
void FillCup(ref Cup myCup)
{
    myCup.Contents = "coffee";  // Modifica el objeto original
    myCup = new Cup();          // ¡También afecta al original!
}

Cup originalCup = new Cup();
FillCup(ref originalCup);
// originalCup puede ser un objeto diferente si se reasignó
```

## 💡 Ejemplos Prácticos

### Ejemplo 1: Modificar Value Types

```csharp
// ❌ MAL: Intentar modificar value type sin ref
void Increment(int value)
{
    value++;  // No afecta al original
}

int num = 10;
Increment(num);
Console.WriteLine(num);  // Output: 10

// ✅ BIEN: Usar ref para modificar
void Increment(ref int value)
{
    value++;  // Afecta al original
}

int num2 = 10;
Increment(ref num2);
Console.WriteLine(num2);  // Output: 11
```

### Ejemplo 2: Reasignar Reference Types

```csharp
// Pass By Value: Reasignar no afecta al original
void ReassignPerson(Person person)
{
    person = new Person { Name = "New" };  // Solo afecta la copia local
}

Person p = new Person { Name = "Original" };
ReassignPerson(p);
Console.WriteLine(p.Name);  // Output: "Original"

// Pass By Reference: Reasignar afecta al original
void ReassignPerson(ref Person person)
{
    person = new Person { Name = "New" };  // Afecta al original
}

Person p2 = new Person { Name = "Original" };
ReassignPerson(ref p2);
Console.WriteLine(p2.Name);  // Output: "New"
```

### Ejemplo 3: Usar `out` para Múltiples Valores de Retorno

```csharp
// ✅ BIEN: out para retornar múltiples valores
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

int q, r;
if (TryDivide(10, 3, out q, out r))
{
    Console.WriteLine($"Quotient: {q}, Remainder: {r}");  // Output: Quotient: 3, Remainder: 1
}
```

### Ejemplo 4: Usar `in` para Structs Grandes

```csharp
public struct LargeStruct
{
    public int Field1;
    public int Field2;
    // ... muchos campos más
}

// ✅ BIEN: in evita copiar el struct grande
void ProcessLargeStruct(in LargeStruct data)
{
    var value = data.Field1 + data.Field2;  // Lee sin copiar
    // data.Field1 = 10;  // ❌ Error: no se puede modificar
}

LargeStruct large = new LargeStruct { Field1 = 10, Field2 = 20 };
ProcessLargeStruct(in large);  // Pasa por referencia pero solo lectura
```

## 📊 Tabla Comparativa

| Característica | Pass By Value | Pass By Reference (`ref`) | `out` | `in` |
|----------------|---------------|---------------------------|-------|------|
| **Inicialización Requerida** | No | Sí | No | Sí |
| **Puede Modificar Objeto** | Sí (propiedades) | Sí | Sí | No |
| **Puede Reasignar Variable** | No | Sí | Sí | No |
| **Uso Común** | Comportamiento por defecto | Modificar variables | Múltiples retornos | Structs grandes |
| **Value Types** | Copia del valor | Referencia al original | Referencia al original | Referencia solo lectura |
| **Reference Types** | Copia de referencia | Referencia al original | Referencia al original | Referencia solo lectura |

## ⚠️ Errores Comunes

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

## 🎯 Cuándo Usar Cada Enfoque

### Usa Pass By Value cuando:
- ✅ Pasas objetos que solo necesitas leer o modificar propiedades
- ✅ No necesitas reasignar la variable
- ✅ Quieres el comportamiento por defecto (más seguro)
- ✅ Trabajas con reference types normalmente

### Usa `ref` cuando:
- ✅ Necesitas modificar value types
- ✅ Necesitas reasignar reference types
- ✅ Quieres intercambiar valores (swap)
- ✅ Necesitas que el método pueda cambiar qué objeto referencia la variable

### Usa `out` cuando:
- ✅ Necesitas retornar múltiples valores
- ✅ El método debe asignar un valor antes de retornar
- ✅ Quieres indicar claramente que el parámetro es un resultado
- ✅ Ejemplos: `TryParse`, métodos que retornan éxito/fallo + valor

### Usa `in` cuando:
- ✅ Pasas structs grandes y solo necesitas leerlos
- ✅ Quieres evitar copias costosas pero garantizar inmutabilidad
- ✅ El método solo necesita leer el parámetro
- ✅ Optimización de rendimiento para structs grandes

## 💡 Mejores Prácticas

### 1. Preferir Pass By Value para Reference Types

```csharp
// ✅ BIEN: Pass by value es más seguro por defecto
void ProcessUser(User user)
{
    user.Name = "Updated";  // Modifica el objeto original
    // No puedes reasignar user accidentalmente
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
void ProcessUser(ref User user)  // ¿Realmente necesitas reasignar?
{
    user.Name = "Updated";
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

## 📚 Relación con Otros Conceptos

Este tema está relacionado con:
- **Value Types vs Reference Types**: `concepts/09-csharp-fundamentals/03-data-types/`
- **Keywords en C#**: `concepts/09-csharp-fundamentals/07-keywords/` (cubre `ref`, `out`, `in`)

## 🎯 Resumen

### Pass By Value (Por Defecto)
- ✅ Se pasa una copia de la referencia (reference types) o del valor (value types)
- ✅ Puedes modificar propiedades del objeto
- ✅ Reasignar el parámetro no afecta al original
- ✅ Más seguro y predecible

### Pass By Reference (`ref`)
- ✅ Se pasa una referencia directa al original
- ✅ Cualquier modificación afecta al original
- ✅ Puedes reasignar la variable
- ✅ Requiere inicialización previa

### `out` Parameters
- ✅ Similar a `ref` pero sin requerir inicialización
- ✅ Debe asignarse dentro del método
- ✅ Ideal para múltiples valores de retorno

### `in` Parameters
- ✅ Referencia de solo lectura
- ✅ Evita copiar structs grandes
- ✅ Garantiza inmutabilidad

## 📚 Recursos Adicionales

- [Microsoft Docs - ref keyword](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/ref)
- [Microsoft Docs - out keyword](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/out-parameter-modifier)
- [Microsoft Docs - in keyword](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/in-parameter-modifier)
- [Microsoft Docs - Passing Parameters](https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/passing-parameters)

