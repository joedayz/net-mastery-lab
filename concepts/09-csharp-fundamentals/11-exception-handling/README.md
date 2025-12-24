# Manejo de Excepciones en C# ⚠️

## Introducción

El manejo de errores es crucial para crear programas confiables. C# proporciona un sistema robusto de manejo de excepciones que permite capturar y manejar errores de forma elegante, evitando que la aplicación se cierre inesperadamente.

## 📚 Conceptos Clave

### 1. Bloques try-catch

El bloque `try-catch` permite capturar y manejar excepciones:

```csharp
try
{
    // Código que puede lanzar excepciones
    int result = int.Parse("abc"); // FormatException
}
catch (FormatException ex)
{
    // Manejar excepción específica
    Console.WriteLine($"Error de formato: {ex.Message}");
}
catch (Exception ex)
{
    // Manejar cualquier otra excepción
    Console.WriteLine($"Error general: {ex.Message}");
}
```

### 2. Bloque finally

El bloque `finally` siempre se ejecuta, sin importar si hay excepción o no:

```csharp
FileStream? file = null;
try
{
    file = File.OpenRead("data.txt");
    // Procesar archivo
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Archivo no encontrado: {ex.Message}");
}
finally
{
    // Siempre se ejecuta - limpieza de recursos
    file?.Close();
    file?.Dispose();
}
```

### 3. Tipos de Excepciones

#### Excepciones Comunes del Sistema

```csharp
// ArgumentNullException - Argumento null
public void ProcessUser(User? user)
{
    ArgumentNullException.ThrowIfNull(user);
    // Procesar usuario
}

// ArgumentException - Argumento inválido
if (age < 0)
{
    throw new ArgumentException("La edad no puede ser negativa", nameof(age));
}

// InvalidOperationException - Operación inválida
if (isDisposed)
{
    throw new InvalidOperationException("El objeto ha sido eliminado");
}

// FormatException - Formato inválido
int.Parse("abc"); // FormatException

// FileNotFoundException - Archivo no encontrado
File.ReadAllText("nonexistent.txt"); // FileNotFoundException
```

### 4. Crear Excepciones Personalizadas

```csharp
// Excepción personalizada
public class InsufficientFundsException : Exception
{
    public decimal Balance { get; }
    public decimal RequestedAmount { get; }

    public InsufficientFundsException(decimal balance, decimal requestedAmount)
        : base($"Fondos insuficientes. Balance: {balance}, Solicitado: {requestedAmount}")
    {
        Balance = balance;
        RequestedAmount = requestedAmount;
    }
}

// Uso
public void Withdraw(decimal amount)
{
    if (amount > Balance)
    {
        throw new InsufficientFundsException(Balance, amount);
    }
    Balance -= amount;
}
```

### 5. Lanzar Excepciones

```csharp
// Lanzar excepción existente
if (user == null)
{
    throw new ArgumentNullException(nameof(user));
}

// Lanzar excepción personalizada
if (age < 0)
{
    throw new ArgumentException("La edad no puede ser negativa", nameof(age));
}

// Re-lanzar excepción (preservar stack trace)
try
{
    ProcessData();
}
catch (Exception ex)
{
    LogError(ex);
    throw; // Re-lanzar preservando stack trace
}

// Lanzar nueva excepción (perder stack trace original)
try
{
    ProcessData();
}
catch (Exception ex)
{
    throw new CustomException("Error procesando datos", ex); // Inner exception
}
```

### 6. Patrones Modernos de Manejo de Excepciones

#### Using Statement (Dispose Pattern)

```csharp
// ✅ BIEN: using statement - dispose automático
using (var file = File.OpenRead("data.txt"))
{
    // Procesar archivo
} // Dispose automático incluso si hay excepción

// ✅ MEJOR: using declaration (C# 8.0+)
using var file = File.OpenRead("data.txt");
// Procesar archivo
// Dispose automático al final del scope
```

#### Try-Catch con Return Values

```csharp
// ✅ BIEN: TryParse pattern (no lanza excepciones)
if (int.TryParse(input, out int result))
{
    return result;
}
return 0;

// ✅ BIEN: Método que retorna bool en lugar de lanzar excepción
public bool TryProcessUser(User user, out string result)
{
    if (user == null)
    {
        result = string.Empty;
        return false;
    }
    result = ProcessUser(user);
    return true;
}
```

## 📊 Jerarquía de Excepciones

En C#, todas las excepciones derivan de la clase base `Exception`, que se divide en `SystemException`, `ApplicationException` y excepciones personalizadas.

```
Exception (base - clase raíz)
├── SystemException (Excepciones del Sistema)
│   ├── NullReferenceException
│   ├── InvalidOperationException
│   ├── OutOfMemoryException
│   ├── TimeoutException
│   ├── UriFormatException
│   ├── ArgumentException
│   │   ├── ArgumentNullException
│   │   └── ArgumentOutOfRangeException
│   ├── FormatException
│   ├── FileNotFoundException
│   └── ... (más excepciones del sistema)
├── ApplicationException (Legacy - no usar)
│   └── Custom Exceptions (heredar de Exception en lugar de ApplicationException)
└── Custom (User-Defined) Exceptions
    └── (Heredar directamente de Exception - recomendado)
```

### 🔹 SystemException (Excepciones Integradas)

`SystemException` incluye errores de tiempo de ejecución que ocurren debido a problemas a nivel del sistema. Estas son excepciones integradas proporcionadas por .NET.

#### NullReferenceException

Ocurre cuando intentas acceder a un objeto que es `null`.

```csharp
// ❌ MAL: Acceder a objeto null
string? text = null;
int length = text.Length; // NullReferenceException

// ✅ BIEN: Verificar null antes de acceder
string? text = null;
if (text != null)
{
    int length = text.Length;
}

// ✅ MEJOR: Usar null-conditional operator
int length = text?.Length ?? 0;
```

#### InvalidOperationException

Se lanza cuando una operación no es válida en el estado actual del objeto.

```csharp
// ✅ BIEN: InvalidOperationException para operaciones inválidas
public class Order
{
    private bool _isProcessed = false;

    public void Process()
    {
        if (_isProcessed)
        {
            throw new InvalidOperationException("La orden ya ha sido procesada");
        }
        _isProcessed = true;
    }
}
```

#### OutOfMemoryException

Se lanza cuando el sistema se queda sin memoria.

```csharp
// ⚠️ Raro pero posible: OutOfMemoryException
try
{
    var hugeArray = new int[int.MaxValue]; // Puede lanzar OutOfMemoryException
}
catch (OutOfMemoryException ex)
{
    Console.WriteLine($"Memoria insuficiente: {ex.Message}");
    // Limpiar recursos y manejar graciosamente
}
```

#### TimeoutException

Se lanza cuando una operación excede el tiempo asignado.

```csharp
// ✅ BIEN: Manejar TimeoutException
try
{
    var result = await httpClient.GetAsync(url, cancellationToken);
}
catch (TimeoutException ex)
{
    Console.WriteLine($"Operación excedió el tiempo límite: {ex.Message}");
    // Reintentar o notificar al usuario
}
```

#### UriFormatException

Ocurre cuando un URI no está en el formato correcto.

```csharp
// ✅ BIEN: Manejar UriFormatException
try
{
    var uri = new Uri("invalid-uri-format");
}
catch (UriFormatException ex)
{
    Console.WriteLine($"URI inválido: {ex.Message}");
    // Validar formato antes de crear URI
}
```

### 🔹 ApplicationException (Excepciones Definidas por el Usuario)

`ApplicationException` se diseñó originalmente para excepciones personalizadas definidas por el usuario. Sin embargo, **Microsoft recomienda heredar directamente de `Exception` en lugar de `ApplicationException`**.

```csharp
// ❌ MAL: Heredar de ApplicationException (legacy)
public class CustomException : ApplicationException
{
    public CustomException(string message) : base(message) { }
}

// ✅ BIEN: Heredar directamente de Exception (recomendado)
public class CustomException : Exception
{
    public CustomException(string message) : base(message) { }
}
```

**Razón:** `ApplicationException` no agrega funcionalidad adicional y puede causar confusión. Es mejor heredar directamente de `Exception`.

### 🔹 Custom Exceptions (Excepciones Personalizadas)

Las excepciones personalizadas deben heredar directamente de `Exception`:

```csharp
// ✅ BIEN: Excepción personalizada heredando de Exception
public class OrderNotFoundException : Exception
{
    public int OrderId { get; }

    public OrderNotFoundException(int orderId)
        : base($"Orden con ID {orderId} no encontrada")
    {
        OrderId = orderId;
    }
}

// ✅ BIEN: Excepción personalizada con InnerException
public class ValidationException : Exception
{
    public List<string> Errors { get; }

    public ValidationException(List<string> errors)
        : base($"Validación fallida: {string.Join(", ", errors)}")
    {
        Errors = errors;
    }

    public ValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
        Errors = new List<string>();
    }
}
```

## 💡 Mejores Prácticas

### 1. Capturar Excepciones Específicas Primero

```csharp
// ✅ BIEN: Excepciones específicas primero
try
{
    ProcessFile("data.txt");
}
catch (FileNotFoundException ex)
{
    // Manejar archivo no encontrado
}
catch (UnauthorizedAccessException ex)
{
    // Manejar acceso denegado
}
catch (Exception ex)
{
    // Manejar cualquier otra excepción
}
```

### 2. No Capturar Excepciones que No Puedes Manejar

```csharp
// ❌ MAL: Capturar y hacer nada
try
{
    ProcessData();
}
catch (Exception)
{
    // Silenciar excepción - MALA PRÁCTICA
}

// ✅ BIEN: Manejar o re-lanzar
try
{
    ProcessData();
}
catch (Exception ex)
{
    LogError(ex);
    throw; // Re-lanzar si no puedes manejar
}
```

### 3. Usar finally para Limpieza de Recursos

```csharp
// ✅ BIEN: finally para limpieza
FileStream? file = null;
try
{
    file = File.OpenRead("data.txt");
    ProcessFile(file);
}
finally
{
    file?.Dispose();
}

// ✅ MEJOR: using statement
using var file = File.OpenRead("data.txt");
ProcessFile(file);
```

### 4. Proporcionar Mensajes de Error Útiles

```csharp
// ✅ BIEN: Mensaje descriptivo con contexto
if (age < 0)
{
    throw new ArgumentOutOfRangeException(
        nameof(age), 
        age, 
        "La edad debe ser un número positivo"
    );
}

// ❌ MAL: Mensaje genérico
throw new Exception("Error");
```

### 5. Usar Excepciones Personalizadas para Errores de Negocio

```csharp
// ✅ BIEN: Excepción personalizada para reglas de negocio
public class OrderNotFoundException : Exception
{
    public int OrderId { get; }
    
    public OrderNotFoundException(int orderId)
        : base($"Orden con ID {orderId} no encontrada")
    {
        OrderId = orderId;
    }
}
```

## 🎯 Ejemplos Prácticos

### Ejemplo 1: Manejo Básico de Excepciones

```csharp
public int Divide(int a, int b)
{
    try
    {
        return a / b;
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"Error: División por cero - {ex.Message}");
        return 0;
    }
}
```

### Ejemplo 2: Manejo de Archivos

```csharp
public string ReadFileContent(string filePath)
{
    try
    {
        return File.ReadAllText(filePath);
    }
    catch (FileNotFoundException)
    {
        return "Archivo no encontrado";
    }
    catch (UnauthorizedAccessException)
    {
        return "Acceso denegado al archivo";
    }
    catch (IOException ex)
    {
        return $"Error de E/S: {ex.Message}";
    }
}
```

### Ejemplo 3: Excepción Personalizada

```csharp
public class ValidationException : Exception
{
    public List<string> Errors { get; }

    public ValidationException(List<string> errors)
        : base($"Validación fallida: {string.Join(", ", errors)}")
    {
        Errors = errors;
    }
}

public void ValidateUser(User user)
{
    var errors = new List<string>();
    
    if (string.IsNullOrWhiteSpace(user.Name))
        errors.Add("El nombre es requerido");
    
    if (user.Age < 0)
        errors.Add("La edad no puede ser negativa");
    
    if (errors.Count > 0)
        throw new ValidationException(errors);
}
```

### Ejemplo 4: Try-Catch-Finally Completo

```csharp
public void ProcessData()
{
    StreamReader? reader = null;
    try
    {
        reader = new StreamReader("data.txt");
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            ProcessLine(line);
        }
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine($"Archivo no encontrado: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inesperado: {ex.Message}");
        throw; // Re-lanzar para logging superior
    }
    finally
    {
        reader?.Dispose(); // Siempre cerrar recursos
    }
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Exception Handling](https://docs.microsoft.com/dotnet/csharp/fundamentals/exceptions/)
- [Microsoft Docs - Creating Custom Exceptions](https://docs.microsoft.com/dotnet/standard/exceptions/how-to-create-localized-exception-messages)
- [Microsoft Docs - Best Practices for Exceptions](https://docs.microsoft.com/dotnet/standard/exceptions/best-practices-for-exceptions)

