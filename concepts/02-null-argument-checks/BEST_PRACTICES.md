# Mejores Prácticas: Null Argument Checks

## ✅ Reglas de Oro

### 1. Usa `ArgumentNullException.ThrowIfNull` en .NET 6+

```csharp
// ❌ MAL: Método tradicional (más lento)
public void ProcessData(string? data)
{
    if (data is null)
        throw new ArgumentNullException(nameof(data));
    // ...
}

// ✅ BIEN: Método moderno (más rápido y conciso)
public void ProcessData(string? data)
{
    ArgumentNullException.ThrowIfNull(data, nameof(data));
    // ...
}
```

### 2. Siempre incluye `nameof()` para mensajes claros

```csharp
// ⚠️  Funciona pero el mensaje puede ser menos claro
ArgumentNullException.ThrowIfNull(data);

// ✅ Mejor: Mensaje de error explícito
ArgumentNullException.ThrowIfNull(data, nameof(data));
```

### 3. Valida al inicio del método

```csharp
// ❌ MAL: Validación después de lógica
public void ProcessOrder(Order? order)
{
    var total = CalculateTotal(order.Items); // Puede fallar si order es null
    ArgumentNullException.ThrowIfNull(order, nameof(order));
}

// ✅ BIEN: Validación al inicio
public void ProcessOrder(Order? order)
{
    ArgumentNullException.ThrowIfNull(order, nameof(order));
    var total = CalculateTotal(order.Items);
}
```

## 🎯 Cuándo Usar Cada Método

### Usa `ArgumentNullException.ThrowIfNull` cuando:

1. **Estás en .NET 6+**
   ```csharp
   public void ModernMethod(string? data)
   {
       ArgumentNullException.ThrowIfNull(data, nameof(data));
   }
   ```

2. **Necesitas el mejor rendimiento**
   - Es ~48x más rápido que el método tradicional
   - Optimizado internamente por el runtime

3. **Quieres código más limpio**
   - Una línea vs múltiples líneas
   - Más legible y mantenible

### Usa el método tradicional cuando:

1. **Necesitas compatibilidad con versiones anteriores**
   ```csharp
   // Para .NET Framework o versiones anteriores a .NET 6
   if (data is null)
       throw new ArgumentNullException(nameof(data));
   ```

2. **Necesitas lógica adicional en la validación**
   ```csharp
   if (data is null)
   {
       LogWarning("Data is null");
       throw new ArgumentNullException(nameof(data));
   }
   ```

## ⚠️ Errores Comunes y Cómo Evitarlos

### Error 1: Validar después de usar

```csharp
// ❌ PROBLEMA: Acceso a null antes de validar
public void ProcessUser(User? user)
{
    var name = user.Name; // NullReferenceException aquí
    ArgumentNullException.ThrowIfNull(user, nameof(user));
}

// ✅ SOLUCIÓN: Validar primero
public void ProcessUser(User? user)
{
    ArgumentNullException.ThrowIfNull(user, nameof(user));
    var name = user.Name; // Seguro ahora
}
```

### Error 2: No usar nameof()

```csharp
// ⚠️  Funciona pero menos claro
ArgumentNullException.ThrowIfNull(user);

// ✅ Mejor práctica
ArgumentNullException.ThrowIfNull(user, nameof(user));
```

### Error 3: Usar en métodos que aceptan null intencionalmente

```csharp
// ❌ PROBLEMA: Validación innecesaria
public void LogMessage(string? message)
{
    ArgumentNullException.ThrowIfNull(message, nameof(message)); // ¿Por qué?
    Console.WriteLine(message ?? "No message");
}

// ✅ SOLUCIÓN: Solo valida si null no es válido
public void ProcessMessage(string message) // No nullable
{
    ArgumentNullException.ThrowIfNull(message, nameof(message));
    // Procesar...
}
```

## 🔍 Patrones Avanzados

### 1. Validación con mensaje personalizado

```csharp
// Si necesitas un mensaje personalizado, usa el método tradicional
if (user is null)
    throw new ArgumentNullException(nameof(user), "User is required to process the order");
```

### 2. Validación condicional

```csharp
public void UpdateUser(User? user, bool validateUser = true)
{
    if (validateUser)
        ArgumentNullException.ThrowIfNull(user, nameof(user));
    
    // Actualizar usuario...
}
```

### 3. Validación en propiedades

```csharp
private string? _name;

public string Name
{
    get => _name ?? throw new InvalidOperationException("Name not initialized");
    set => _name = value ?? throw new ArgumentNullException(nameof(value));
}
```

## 📊 Comparación de Métodos

| Aspecto | Old Way | New Way | New Way Upgraded |
|---------|---------|---------|------------------|
| **Rendimiento** | Más lento | Rápido | Más rápido |
| **Concisión** | Múltiples líneas | Una línea | Una línea |
| **Mensaje de error** | Explícito | Inferido | Explícito |
| **Compatibilidad** | Todas las versiones | .NET 6+ | .NET 6+ |
| **Recomendado** | ❌ | ⚠️ | ✅ |

## 🚀 Optimizaciones

### 1. Validación temprana

```csharp
// ✅ Valida todos los argumentos al inicio
public void CreateOrder(Customer? customer, Product? product, Address? address)
{
    ArgumentNullException.ThrowIfNull(customer, nameof(customer));
    ArgumentNullException.ThrowIfNull(product, nameof(product));
    ArgumentNullException.ThrowIfNull(address, nameof(address));
    
    // Lógica del método...
}
```

### 2. Combinar con Nullable Reference Types

```csharp
#nullable enable

public void ProcessUser(User user) // 'user' no es nullable
{
    // En .NET 6+ con NRT, el compilador ayuda pero aún puedes validar
    ArgumentNullException.ThrowIfNull(user, nameof(user));
}
```

## 📚 Recursos Adicionales

- [ArgumentNullException.ThrowIfNull Documentation](https://docs.microsoft.com/dotnet/api/system.argumentnullexception.throwifnull)
- [Nullable Reference Types](https://docs.microsoft.com/dotnet/csharp/nullable-references)
- [Performance Best Practices](https://docs.microsoft.com/dotnet/fundamentals/performance/)

