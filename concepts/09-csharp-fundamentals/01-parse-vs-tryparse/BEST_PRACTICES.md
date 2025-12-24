# Mejores Prácticas: Understanding int.Parse() vs int.TryParse()

## ✅ Reglas de Oro

### 1. Usa TryParse para Entrada del Usuario

```csharp
// ✅ BIEN: TryParse para entrada del usuario
string userInput = Console.ReadLine();
if (int.TryParse(userInput, out int number))
{
    Console.WriteLine($"Número válido: {number}");
}
else
{
    Console.WriteLine("Error: Entrada inválida");
}

// ❌ MAL: Parse sin manejo de errores
string userInput = Console.ReadLine();
int number = int.Parse(userInput); // Puede lanzar excepción
```

### 2. Usa Parse para Datos Confiables

```csharp
// ✅ BIEN: Parse para datos confiables (constantes, configuración interna)
int maxRetries = int.Parse("3"); // Constante conocida
int timeout = int.Parse(configValue); // Si estás seguro del formato

// ⚠️ Pero siempre con validación si viene de fuente externa
```

### 3. Siempre Verifica el Resultado de TryParse

```csharp
// ✅ BIEN: Verificar el resultado
if (int.TryParse(input, out int result))
{
    // Usar result
    ProcessNumber(result);
}

// ❌ MAL: Ignorar si fue exitoso
int.TryParse(input, out int result);
ProcessNumber(result); // Puede procesar 0 si falló
```

## ⚠️ Errores Comunes a Evitar

### 1. Usar Parse sin Manejo de Errores

```csharp
// ❌ MAL: Puede lanzar excepciones inesperadas
string userInput = Console.ReadLine();
int number = int.Parse(userInput); // Peligroso

// ✅ BIEN: Usar TryParse
string userInput = Console.ReadLine();
if (int.TryParse(userInput, out int number))
{
    // Usar number
}
```

### 2. Ignorar el Resultado de TryParse

```csharp
// ❌ MAL: Ignorar si la conversión fue exitosa
int.TryParse(input, out int result);
Console.WriteLine(result); // Puede ser 0 si falló

// ✅ BIEN: Verificar el resultado
if (int.TryParse(input, out int result))
{
    Console.WriteLine(result);
}
else
{
    Console.WriteLine("Conversión fallida");
}
```

### 3. Usar TryParse cuando Parse es Apropiado

```csharp
// ⚠️ Si estás seguro del formato, Parse puede ser más claro
// Datos de configuración interna, constantes, etc.
int maxRetries = int.Parse("3"); // OK si es constante conocida

// Pero para entrada del usuario, siempre TryParse
int userAge = int.TryParse(userInput, out int age) ? age : 0;
```

## 🎯 Casos de Uso Específicos

### 1. Validación de Entrada del Usuario

```csharp
// ✅ BIEN: Validación con TryParse
public int GetUserAge()
{
    Console.Write("Ingresa tu edad: ");
    string input = Console.ReadLine();
    
    while (!int.TryParse(input, out int age) || age < 0 || age > 150)
    {
        Console.Write("Edad inválida. Ingresa tu edad: ");
        input = Console.ReadLine();
    }
    
    return int.TryParse(input, out int validAge) ? validAge : 0;
}
```

### 2. Parsing de Configuración con Valor por Defecto

```csharp
// ✅ BIEN: Parsing de configuración con valor por defecto
public int GetTimeoutFromConfig(string configValue)
{
    if (int.TryParse(configValue, out int timeout) && timeout > 0)
    {
        return timeout;
    }
    
    return 30; // Valor por defecto
}
```

### 3. Validación en Loops

```csharp
// ✅ BIEN: TryParse en loops es más eficiente
string[] inputs = { "123", "abc", "456", "invalid" };
List<int> numbers = new List<int>();

foreach (string input in inputs)
{
    if (int.TryParse(input, out int number))
    {
        numbers.Add(number);
    }
}
```

### 4. Parsing de Datos de API

```csharp
// ✅ BIEN: TryParse para datos de API (pueden ser inválidos)
public int ParseApiResponse(string apiValue)
{
    if (int.TryParse(apiValue, out int result))
    {
        return result;
    }
    
    throw new InvalidOperationException($"Invalid API response: {apiValue}");
}
```

## 📊 Comparación de Uso

| Escenario | Método Recomendado | Razón |
|-----------|-------------------|-------|
| Entrada del usuario | `TryParse` | Puede ser inválida |
| Datos de API | `TryParse` | Pueden ser inválidos |
| Constantes conocidas | `Parse` | Siempre válidas |
| Configuración interna | `TryParse` con default | Puede faltar |
| Datos de BD confiables | `Parse` | Formato garantizado |
| Validación en loops | `TryParse` | Más eficiente |

## 🚀 Tips Avanzados

### 1. Usar Pattern Matching (C# 7+)

```csharp
// ✅ BIEN: Pattern matching con TryParse
if (int.TryParse(input, out int number))
{
    switch (number)
    {
        case > 100:
            Console.WriteLine("Número grande");
            break;
        case > 0:
            Console.WriteLine("Número positivo");
            break;
        default:
            Console.WriteLine("Número no positivo");
            break;
    }
}
```

### 2. Extension Methods para Parsing

```csharp
// ✅ BIEN: Extension method para parsing con default
public static class StringExtensions
{
    public static int ToIntOrDefault(this string value, int defaultValue = 0)
    {
        return int.TryParse(value, out int result) ? result : defaultValue;
    }
}

// Uso:
int age = userInput.ToIntOrDefault(18);
```

### 3. Validación Combinada

```csharp
// ✅ BIEN: Validación combinada con TryParse
public bool IsValidAge(string input, out int age)
{
    if (int.TryParse(input, out age) && age >= 0 && age <= 150)
    {
        return true;
    }
    
    age = 0;
    return false;
}
```

### 4. TryParse con NumberStyles

```csharp
// ✅ BIEN: TryParse con NumberStyles para más control
string input = "1,234";
if (int.TryParse(input, NumberStyles.AllowThousands, 
    CultureInfo.InvariantCulture, out int number))
{
    Console.WriteLine(number); // 1234
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - int.Parse](https://docs.microsoft.com/dotnet/api/system.int32.parse)
- [Microsoft Docs - int.TryParse](https://docs.microsoft.com/dotnet/api/system.int32.tryparse)
- [Microsoft Docs - Exception Handling](https://docs.microsoft.com/dotnet/csharp/fundamentals/exceptions/)

