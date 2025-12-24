# Mejores Prácticas: TryGetValue para Evitar Doble Búsqueda

## ✅ Reglas de Oro

### 1. Siempre usa `TryGetValue` cuando necesites verificar y obtener un valor

```csharp
// ❌ MAL: Doble búsqueda, menos eficiente
if (myDictionary.ContainsKey("key"))
{
    var value = myDictionary["key"];
    // ...
}

// ✅ BIEN: Una sola búsqueda, más eficiente y conciso
if (myDictionary.TryGetValue("key", out var value))
{
    // ...
}
```

### 2. Considera el rendimiento en bucles y operaciones frecuentes

En escenarios donde se realizan muchas búsquedas en diccionarios (por ejemplo, dentro de bucles o en servicios de alto rendimiento), la diferencia de rendimiento entre una y dos búsquedas puede ser significativa.

```csharp
// Ejemplo de un bucle donde TryGetValue es crucial
foreach (var item in listOfItemsToProcess)
{
    if (cache.TryGetValue(item.Id, out var cachedValue))
    {
        // Usar valor en caché
        ProcessItem(cachedValue);
    }
    else
    {
        // Calcular y añadir a caché
        var computedValue = ComputeValue(item);
        cache[item.Id] = computedValue;
        ProcessItem(computedValue);
    }
}
```

### 3. `TryGetValue` es seguro contra `KeyNotFoundException`

El uso del indexador `dictionary[key]` lanzará una `KeyNotFoundException` si la clave no existe. `TryGetValue` devuelve `false` en su lugar, lo que a menudo resulta en un código más limpio y menos propenso a excepciones inesperadas.

```csharp
// ❌ MAL: Puede lanzar KeyNotFoundException
try
{
    var value = myDictionary["nonExistentKey"];
    ProcessValue(value);
}
catch (KeyNotFoundException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// ✅ BIEN: Manejo de ausencia de clave sin excepciones
if (myDictionary.TryGetValue("nonExistentKey", out var value))
{
    ProcessValue(value);
}
else
{
    Console.WriteLine("La clave no existe.");
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Usar `ContainsKey` y luego el indexador

Como se mencionó, este es el error principal que `TryGetValue` busca resolver. Evita este patrón siempre que sea posible.

```csharp
// ❌ MAL: Patrón a evitar
if (dictionary.ContainsKey(key))
{
    var value = dictionary[key]; // Segunda búsqueda innecesaria
}
```

### 2. Ignorar el valor de retorno de `TryGetValue`

El valor booleano de retorno de `TryGetValue` es crucial para saber si la operación fue exitosa. No lo ignores.

```csharp
// ❌ MAL: Ignorando el resultado, 'value' podría ser el valor por defecto
myDictionary.TryGetValue("key", out var value);
// ... el código asume que 'value' tiene un valor real
// Si la clave no existe, 'value' será 0 (int), null (string), etc.

// ✅ BIEN: Siempre verifica el resultado
if (myDictionary.TryGetValue("key", out var value))
{
    // Usar value solo si la clave existe
    ProcessValue(value);
}
```

### 3. Usar `TryGetValue` cuando sabes que la clave existe

Si estás absolutamente seguro de que una clave existe (por ejemplo, porque la acabas de añadir o es parte de un conjunto de datos validado), el uso directo del indexador `dictionary[key]` puede ser ligeramente más rápido ya que no hay una verificación booleana adicional. Sin embargo, en la mayoría de los casos, la seguridad y claridad de `TryGetValue` superan esta pequeña ganancia de rendimiento.

```csharp
// Caso especial: Si estás 100% seguro de que la clave existe
// (por ejemplo, acabas de añadirla)
dictionary[key] = newValue;
var value = dictionary[key]; // OK si estás seguro

// Pero en la mayoría de casos, TryGetValue es mejor
if (dictionary.TryGetValue(key, out var value))
{
    // Más seguro y claro
}
```

## 🎯 Casos de Uso Específicos

### 1. Caché de Datos

```csharp
public class DataCache
{
    private readonly Dictionary<string, CachedData> _cache = new();

    public CachedData? GetData(string key)
    {
        if (_cache.TryGetValue(key, out var cachedData))
        {
            if (cachedData.IsExpired)
            {
                _cache.Remove(key);
                return null;
            }
            return cachedData;
        }
        return null;
    }
}
```

### 2. Configuración con Valores por Defecto

```csharp
public class Configuration
{
    private readonly Dictionary<string, string> _settings = new();

    public string GetSetting(string key, string defaultValue = "")
    {
        if (_settings.TryGetValue(key, out var value))
        {
            return value;
        }
        return defaultValue;
    }
}
```

### 3. Contadores y Estadísticas

```csharp
public class StatisticsTracker
{
    private readonly Dictionary<string, int> _counters = new();

    public void IncrementCounter(string counterName)
    {
        if (_counters.TryGetValue(counterName, out var currentValue))
        {
            _counters[counterName] = currentValue + 1;
        }
        else
        {
            _counters[counterName] = 1;
        }
    }
}
```

## 📊 Comparación de Métodos

| Aspecto | ContainsKey + Indexer | TryGetValue |
|---------|----------------------|-------------|
| **Búsquedas** | 2 (cuando existe) | 1 |
| **Rendimiento** | Más lento | Más rápido |
| **Excepciones** | Puede lanzar KeyNotFoundException | Nunca lanza excepción |
| **Legibilidad** | Más verboso | Más conciso |
| **Recomendado** | ❌ | ✅ |

## 🚀 Optimizaciones Adicionales

### 1. Usar con ConcurrentDictionary en escenarios multi-hilo

```csharp
private readonly ConcurrentDictionary<string, int> _threadSafeCache = new();

public int GetValue(string key)
{
    if (_threadSafeCache.TryGetValue(key, out var value))
    {
        return value;
    }
    // Calcular y añadir de forma thread-safe
    return _threadSafeCache.GetOrAdd(key, ComputeValue);
}
```

### 2. Combinar con pattern matching (C# 7+)

```csharp
if (dictionary.TryGetValue(key, out var value) && value > 0)
{
    // Usar value solo si existe Y es mayor que 0
    ProcessValue(value);
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Dictionary<TKey, TValue>.TryGetValue](https://docs.microsoft.com/dotnet/api/system.collections.generic.dictionary-2.trygetvalue)
- [Microsoft Docs - ConcurrentDictionary](https://docs.microsoft.com/dotnet/api/system.collections.concurrent.concurrentdictionary-2)
- [Performance Best Practices](https://docs.microsoft.com/dotnet/fundamentals/performance/)

