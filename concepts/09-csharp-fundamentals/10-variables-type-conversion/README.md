# Variables y Conversión de Tipos en C# 🔢

## Introducción

Las variables son esenciales en cualquier lenguaje de programación, y C# no es la excepción. Comprender cómo declarar variables, asignar valores y convertir entre tipos es fundamental para escribir código efectivo en C#.

## 📚 Conceptos Clave

### 1. Declaración de Variables

En C#, puedes declarar variables de varias formas:

```csharp
// Declaración explícita de tipo
int age = 25;
string name = "Alice";
bool isActive = true;
double price = 99.99;

// Inferencia de tipos con var (C# 3.0+)
var count = 10;        // int
var message = "Hello"; // string
var isReady = true;    // bool

// Declaración con tipo explícito (recomendado cuando el tipo no es obvio)
var result = CalculateResult(); // Tipo inferido del método
List<string> items = new List<string>(); // Tipo explícito para claridad
```

### 2. Tipos de Datos Comunes

#### Tipos Numéricos Enteros

```csharp
byte b = 255;           // 0 a 255 (8 bits)
sbyte sb = -128;       // -128 a 127 (8 bits)
short s = -32768;      // -32,768 a 32,767 (16 bits)
ushort us = 65535;     // 0 a 65,535 (16 bits)
int i = -2147483648;   // -2,147,483,648 a 2,147,483,647 (32 bits)
uint ui = 4294967295;   // 0 a 4,294,967,295 (32 bits)
long l = -9223372036854775808; // 64 bits
ulong ul = 18446744073709551615; // 0 a 18,446,744,073,709,551,615 (64 bits)
```

#### Tipos de Punto Flotante

```csharp
float f = 3.14f;       // Precisión simple (32 bits), requiere sufijo 'f'
double d = 3.14159;    // Precisión doble (64 bits), tipo por defecto
decimal dec = 99.99m;  // Precisión alta (128 bits), requiere sufijo 'm'
```

**Cuándo Usar Cada Uno:**
- **float**: Gráficos, juegos (cuando el rendimiento es crítico)
- **double**: Cálculos científicos, matemáticos (tipo por defecto)
- **decimal**: Dinero, cálculos financieros (precisión exacta)

#### Tipos de Texto

```csharp
string text = "Hello World";  // Cadena de caracteres (inmutable)
char character = 'A';           // Un solo carácter (16 bits Unicode)
```

#### Tipo Booleano

```csharp
bool isTrue = true;
bool isFalse = false;
```

### 3. Conversión de Tipos

#### Conversión Implícita (Automática)

```csharp
// Conversión segura automática (de menor a mayor precisión)
int small = 100;
long large = small; // Conversión implícita

float f = 3.14f;
double d = f; // Conversión implícita

byte b = 100;
int i = b; // Conversión implícita
```

#### Conversión Explícita (Cast)

```csharp
// Conversión explícita cuando puede haber pérdida de datos
double d = 99.99;
int i = (int)d; // i = 99 (pérdida de decimales)

long l = 1000;
int i = (int)l; // Conversión explícita

float f = 3.14f;
int i = (int)f; // i = 3
```

#### Métodos de Conversión

```csharp
// Convert.ToInt32() - Maneja null y lanza excepciones
string str = "123";
int number = Convert.ToInt32(str); // 123
int nullValue = Convert.ToInt32(null); // 0

// int.Parse() - Lanza excepciones si falla
int parsed = int.Parse("123"); // 123
// int.Parse("abc"); // FormatException

// int.TryParse() - Retorna bool, no lanza excepciones
if (int.TryParse("123", out int result))
{
    Console.WriteLine(result); // 123
}
```

### 4. Inferencia de Tipos con `var`

El keyword `var` permite que el compilador infiera el tipo basándose en el valor asignado:

```csharp
// ✅ BIEN: Usar var cuando el tipo es obvio
var name = "Alice";           // string
var age = 25;                 // int
var prices = new List<decimal>(); // List<decimal>

// ✅ BIEN: var con LINQ (tipo complejo)
var result = users.Where(u => u.IsActive)
                  .Select(u => u.Name)
                  .ToList(); // List<string>

// ❌ MAL: No usar var cuando el tipo no es claro
var data = GetData(); // ¿Qué tipo retorna GetData()?

// ✅ MEJOR: Tipo explícito cuando no es obvio
List<User> users = GetUsers();
```

**Cuándo Usar `var`:**
- ✅ Cuando el tipo es obvio del lado derecho
- ✅ Con tipos anónimos
- ✅ Con LINQ queries complejas
- ❌ Cuando el tipo no es claro
- ❌ Cuando necesitas documentar el tipo explícitamente

### 5. Tipos Nullable

Permiten que los tipos de valor acepten `null`:

```csharp
// Tipos nullable con ?
int? nullableInt = null;
bool? nullableBool = null;
DateTime? nullableDate = null;

// Verificar si tiene valor
if (nullableInt.HasValue)
{
    int value = nullableInt.Value;
}

// Operador null-coalescing
int result = nullableInt ?? 0; // Si es null, usa 0

// Null-conditional operator
string name = user?.Name ?? "Unknown";
```

### 6. Constantes y Variables de Solo Lectura

```csharp
// Constante (debe inicializarse, no puede cambiar)
const int MaxRetries = 3;
const string ApiUrl = "https://api.example.com";

// Variable de solo lectura (se inicializa en constructor)
readonly string ConnectionString;

public MyClass(string connectionString)
{
    ConnectionString = connectionString; // Solo aquí
}
```

## 📊 Tabla de Conversiones Comunes

| Tipo Origen | Tipo Destino | Método | Pérdida de Datos |
|-------------|--------------|--------|------------------|
| `int` | `long` | Implícita | No |
| `long` | `int` | `(int)` | Posible |
| `double` | `int` | `(int)` | Sí (decimales) |
| `string` | `int` | `int.Parse()` o `int.TryParse()` | N/A |
| `int` | `string` | `.ToString()` | No |
| `object` | `int` | `(int)` o `Convert.ToInt32()` | Depende |

## 💡 Mejores Prácticas

### 1. Usar Tipos Apropiados

```csharp
// ✅ BIEN: Usar decimal para dinero
decimal price = 99.99m;

// ❌ MAL: Usar double para dinero (pérdida de precisión)
double price = 99.99; // Puede tener errores de redondeo
```

### 2. Preferir TryParse sobre Parse

```csharp
// ✅ BIEN: TryParse (no lanza excepciones)
if (int.TryParse(input, out int result))
{
    // Usar result
}

// ❌ MAL: Parse (lanza excepciones)
try
{
    int result = int.Parse(input);
}
catch (FormatException)
{
    // Manejar error
}
```

### 3. Usar var con Moderación

```csharp
// ✅ BIEN: var cuando es obvio
var users = new List<User>();
var name = "Alice";

// ✅ BIEN: Tipo explícito cuando no es obvio
List<User> activeUsers = GetActiveUsers();
```

### 4. Validar Conversiones

```csharp
// ✅ BIEN: Validar antes de convertir
if (int.TryParse(userInput, out int number))
{
    ProcessNumber(number);
}
else
{
    ShowError("Número inválido");
}
```

## 🎯 Ejemplos Prácticos

### Ejemplo 1: Conversión de Tipos Numéricos

```csharp
int integer = 100;
long longValue = integer;        // Implícita
double doubleValue = integer;    // Implícita
float floatValue = (float)integer; // Explícita

double d = 99.99;
int i = (int)d; // i = 99 (pérdida de decimales)
```

### Ejemplo 2: Conversión String a Numérico

```csharp
string input = "123";

// Método 1: Parse (lanza excepciones)
int number1 = int.Parse(input);

// Método 2: TryParse (recomendado)
if (int.TryParse(input, out int number2))
{
    Console.WriteLine($"Número: {number2}");
}

// Método 3: Convert (maneja null)
int number3 = Convert.ToInt32(input);
```

### Ejemplo 3: Inferencia de Tipos

```csharp
// var infiere el tipo del valor asignado
var name = "Alice";              // string
var age = 25;                    // int
var isActive = true;             // bool
var prices = new List<decimal>(); // List<decimal>

// Con LINQ
var activeUsers = users
    .Where(u => u.IsActive)
    .Select(u => u.Name)
    .ToList(); // List<string>
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Built-in Types](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/built-in-types)
- [Microsoft Docs - Type Conversions](https://docs.microsoft.com/dotnet/csharp/programming-guide/types/casting-and-type-conversions)
- [Microsoft Docs - var Keyword](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/var)

