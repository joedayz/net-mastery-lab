# Mejores Prácticas: Variables y Conversión de Tipos

## ✅ Reglas de Oro

### 1. Usar Tipos Apropiados para Cada Escenario

```csharp
// ✅ BIEN: decimal para dinero (precisión exacta)
decimal price = 99.99m;
decimal total = price * 1.15m; // Sin errores de redondeo

// ❌ MAL: double para dinero (pérdida de precisión)
double price = 99.99;
double total = price * 1.15; // Puede tener errores de redondeo
```

### 2. Preferir TryParse sobre Parse

```csharp
// ✅ BIEN: TryParse (no lanza excepciones)
if (int.TryParse(userInput, out int number))
{
    ProcessNumber(number);
}
else
{
    ShowError("Número inválido");
}

// ❌ MAL: Parse (lanza excepciones, menos eficiente)
try
{
    int number = int.Parse(userInput);
    ProcessNumber(number);
}
catch (FormatException)
{
    ShowError("Número inválido");
}
```

### 3. Usar var con Moderación

```csharp
// ✅ BIEN: var cuando el tipo es obvio
var name = "Alice";
var age = 25;
var users = new List<User>();

// ✅ BIEN: Tipo explícito cuando no es obvio
List<User> activeUsers = GetActiveUsers();
Dictionary<string, int> userCounts = GetUserCounts();

// ❌ MAL: var cuando el tipo no es claro
var data = GetData(); // ¿Qué tipo retorna?
```

### 4. Validar Conversiones Antes de Usar

```csharp
// ✅ BIEN: Validar antes de convertir
string input = Console.ReadLine();
if (int.TryParse(input, out int number) && number > 0)
{
    ProcessNumber(number);
}
else
{
    Console.WriteLine("Por favor ingrese un número válido mayor que 0");
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Usar double para Dinero

```csharp
// ❌ MAL: double para dinero
double price = 99.99;
double total = price * 1.15; // Puede resultar en 114.9885... en lugar de 114.99

// ✅ BIEN: decimal para dinero
decimal price = 99.99m;
decimal total = price * 1.15m; // Resultado exacto: 114.9885
```

### 2. No Validar Conversiones

```csharp
// ❌ MAL: Asumir que la conversión siempre funciona
int number = int.Parse(userInput); // Puede lanzar excepción

// ✅ BIEN: Validar antes de convertir
if (int.TryParse(userInput, out int number))
{
    // Usar number
}
```

### 3. Abusar de var

```csharp
// ❌ MAL: var en todos lados
var result = GetData(); // Tipo no claro

// ✅ BIEN: var solo cuando es obvio
var name = "Alice"; // Obvio que es string
List<User> users = GetUsers(); // Tipo explícito para claridad
```

### 4. No Manejar Nullable Correctamente

```csharp
// ❌ MAL: Acceder a Value sin verificar
int? nullableInt = GetNullableInt();
int value = nullableInt.Value; // InvalidOperationException si es null

// ✅ BIEN: Verificar antes de acceder
int? nullableInt = GetNullableInt();
if (nullableInt.HasValue)
{
    int value = nullableInt.Value;
}

// ✅ MEJOR: Usar null-coalescing
int value = nullableInt ?? 0;
```

## 🎯 Casos de Uso Específicos

### 1. Conversión de String a Numérico

```csharp
// ✅ MEJOR: TryParse para entrada del usuario
public bool TryGetUserAge(string input, out int age)
{
    return int.TryParse(input, out age) && age > 0 && age < 150;
}

// ✅ ALTERNATIVA: Convert para valores conocidos
int defaultValue = Convert.ToInt32(null); // Retorna 0
```

### 2. Inferencia de Tipos con LINQ

```csharp
// ✅ BIEN: var con LINQ (tipo complejo)
var activeUsers = users
    .Where(u => u.IsActive)
    .Select(u => new { u.Name, u.Email })
    .ToList(); // List<AnonymousType>

// ✅ BIEN: Tipo explícito cuando es importante
List<string> userNames = users
    .Where(u => u.IsActive)
    .Select(u => u.Name)
    .ToList();
```

### 3. Tipos Nullable para Valores Opcionales

```csharp
// ✅ BIEN: Nullable para valores opcionales
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? LastLogin { get; set; } // Opcional
}

// Uso
if (user.LastLogin.HasValue)
{
    Console.WriteLine($"Último login: {user.LastLogin.Value}");
}
else
{
    Console.WriteLine("Nunca ha iniciado sesión");
}
```

## 💡 Pro Tips

### 1. Usar Literales Apropiados

```csharp
// ✅ BIEN: Sufijos para claridad
float f = 3.14f;      // 'f' para float
decimal d = 99.99m;   // 'm' para decimal
long l = 1000L;       // 'L' para long

// ❌ MAL: Sin sufijos (puede causar errores)
float f = 3.14;       // Error: no puede convertir double a float
```

### 2. Preferir Constantes para Valores Fijos

```csharp
// ✅ BIEN: Constantes para valores fijos
const int MaxRetries = 3;
const string ApiUrl = "https://api.example.com";

// ❌ MAL: Variables para valores que no cambian
int maxRetries = 3; // Debería ser const
```

### 3. Usar Readonly para Inmutabilidad

```csharp
// ✅ BIEN: readonly para valores que se asignan una vez
public class Configuration
{
    public readonly string ConnectionString;
    
    public Configuration(string connectionString)
    {
        ConnectionString = connectionString; // Solo aquí
    }
}
```

## 📊 Tabla de Decisión: Cuándo Usar Cada Tipo

| Escenario | Tipo Recomendado | Razón |
|-----------|------------------|-------|
| Dinero/Financiero | `decimal` | Precisión exacta |
| Gráficos/Juegos | `float` | Rendimiento |
| Cálculos Científicos | `double` | Precisión y rango |
| Contadores/Índices | `int` | Tipo estándar |
| Números Grandes | `long` | Rango amplio |
| Valores Opcionales | `T?` (nullable) | Permite null |
| Valores Fijos | `const` | Inmutabilidad |

## 📚 Recursos Adicionales

- [Microsoft Docs - Built-in Types](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/built-in-types)
- [Microsoft Docs - Type Conversions](https://docs.microsoft.com/dotnet/csharp/programming-guide/types/casting-and-type-conversions)
- [Microsoft Docs - var Keyword](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/var)

