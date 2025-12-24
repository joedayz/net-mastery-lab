# Mejores Prácticas: Manejo de Excepciones

## ✅ Reglas de Oro

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
    Console.WriteLine($"Archivo no encontrado: {ex.FileName}");
}
catch (UnauthorizedAccessException ex)
{
    // Manejar acceso denegado
    Console.WriteLine($"Acceso denegado: {ex.Message}");
}
catch (Exception ex)
{
    // Manejar cualquier otra excepción
    Console.WriteLine($"Error inesperado: {ex.Message}");
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

## ⚠️ Errores Comunes a Evitar

### 1. Capturar Exception Genérica sin Manejar

```csharp
// ❌ MAL: Capturar Exception sin hacer nada útil
try
{
    ProcessData();
}
catch (Exception ex)
{
    // Solo loguear no es suficiente si no puedes manejar
    Console.WriteLine(ex.Message);
}

// ✅ BIEN: Manejar o re-lanzar
try
{
    ProcessData();
}
catch (Exception ex)
{
    LogError(ex);
    throw; // Re-lanzar para que niveles superiores manejen
}
```

### 2. Usar Excepciones para Control de Flujo

```csharp
// ❌ MAL: Usar excepciones para control de flujo
try
{
    int value = int.Parse(input);
    ProcessValue(value);
}
catch (FormatException)
{
    // No hacer nada - valor inválido
}

// ✅ BIEN: Validar antes de procesar
if (int.TryParse(input, out int value))
{
    ProcessValue(value);
}
else
{
    ShowError("Valor inválido");
}
```

### 3. No Limpiar Recursos en finally

```csharp
// ❌ MAL: No limpiar recursos
FileStream file = File.OpenRead("data.txt");
try
{
    ProcessFile(file);
}
catch (Exception)
{
    // Si hay excepción, file nunca se cierra
}

// ✅ BIEN: Limpiar en finally
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
```

## 🎯 Casos de Uso Específicos

### 1. Validación de Argumentos

```csharp
// ✅ BIEN: Validar argumentos al inicio
public void ProcessUser(User? user)
{
    ArgumentNullException.ThrowIfNull(user, nameof(user));
    
    if (user.Age < 0)
    {
        throw new ArgumentOutOfRangeException(
            nameof(user), 
            "La edad no puede ser negativa"
        );
    }
    
    // Procesar usuario
}
```

### 2. Manejo de Archivos

```csharp
// ✅ BIEN: Manejar diferentes tipos de errores de archivo
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
        return "Acceso denegado";
    }
    catch (IOException ex)
    {
        return $"Error de E/S: {ex.Message}";
    }
}
```

### 3. Excepciones Personalizadas para Reglas de Negocio

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

// Uso
public Order GetOrder(int orderId)
{
    var order = _repository.Find(orderId);
    if (order == null)
    {
        throw new OrderNotFoundException(orderId);
    }
    return order;
}
```

## 💡 Pro Tips

### 1. Usar ArgumentNullException.ThrowIfNull()

```csharp
// ✅ BIEN: Método moderno (.NET 6+)
public void ProcessUser(User? user)
{
    ArgumentNullException.ThrowIfNull(user);
    // Procesar usuario
}

// ❌ MAL: Verificación manual
public void ProcessUser(User? user)
{
    if (user == null)
    {
        throw new ArgumentNullException(nameof(user));
    }
}
```

### 2. Preferir TryParse sobre Parse

```csharp
// ✅ BIEN: TryParse (no lanza excepciones)
if (int.TryParse(input, out int result))
{
    ProcessNumber(result);
}

// ❌ MAL: Parse (lanza excepciones)
try
{
    int result = int.Parse(input);
    ProcessNumber(result);
}
catch (FormatException)
{
    // Manejar error
}
```

### 3. Usar using Statement para Recursos

```csharp
// ✅ BIEN: using statement (dispose automático)
using var file = File.OpenRead("data.txt");
ProcessFile(file);

// ✅ BIEN: using statement tradicional
using (var file = File.OpenRead("data.txt"))
{
    ProcessFile(file);
}
```

### 4. Logging de Excepciones

```csharp
// ✅ BIEN: Logging completo de excepciones
try
{
    ProcessData();
}
catch (Exception ex)
{
    _logger.LogError(ex, "Error procesando datos. UserId: {UserId}", userId);
    throw; // Re-lanzar después de loguear
}
```

## 📊 Tabla de Decisión: Cuándo Usar Cada Patrón

| Escenario | Patrón Recomendado | Razón |
|-----------|-------------------|-------|
| Validación de entrada | TryParse, validación manual | Evitar excepciones para control de flujo |
| Recursos (archivos, conexiones) | using statement | Dispose automático |
| Errores recuperables | try-catch específico | Manejar y continuar |
| Errores no recuperables | Re-lanzar o dejar propagar | Dejar que niveles superiores manejen |
| Reglas de negocio | Excepciones personalizadas | Claridad y contexto |

## 📚 Recursos Adicionales

- [Microsoft Docs - Exception Handling](https://docs.microsoft.com/dotnet/csharp/fundamentals/exceptions/)
- [Microsoft Docs - Best Practices for Exceptions](https://docs.microsoft.com/dotnet/standard/exceptions/best-practices-for-exceptions)
- [Microsoft Docs - Creating Custom Exceptions](https://docs.microsoft.com/dotnet/standard/exceptions/how-to-create-localized-exception-messages)

