# List vs HashSet en .NET 🆚

## Introducción

Comprender cuándo usar `List<T>` vs `HashSet<T>` es fundamental para escribir código eficiente y correcto en .NET. Esta decisión puede afectar significativamente el rendimiento y la funcionalidad de tu aplicación.

## ✅ List<T> – Piensa en Orden y Duplicados Permitidos

Un `List<T>` es como un array dinámico. Mantiene el orden en que se agregan los elementos y permite duplicados.

### Características de List<T>

```csharp
// ✅ BIEN: List permite duplicados y mantiene orden
var list = new List<string> { "a", "b", "a" };  // Permite duplicados
Console.WriteLine(string.Join(", ", list));  // Output: "a, b, a"
```

**Características:**
- ✅ **Mantiene orden**: Los elementos se mantienen en el orden de inserción
- ✅ **Permite duplicados**: Puedes tener el mismo elemento múltiples veces
- ✅ **Acceso por índice**: O(1) para acceso por índice
- ✅ **Búsqueda**: O(n) para buscar elementos
- ✅ **Inserción**: O(1) amortizado al final, O(n) en medio

### Cuándo Usar List<T>

```csharp
// ✅ BIEN: List para secuencias ordenadas
var steps = new List<string> { "Step 1", "Step 2", "Step 3" };
var logs = new List<LogEntry>();  // Logs ordenados por tiempo
var userInputs = new List<string>();  // Entradas del usuario en orden
```

**Casos de Uso Ideales:**
- ✅ Necesitas mantener el orden de los elementos
- ✅ Los duplicados son aceptables o requeridos
- ✅ Necesitas acceso por índice
- ✅ Quieres realizar operaciones como ordenamiento, filtrado o mapeo
- ✅ Almacenar secuencias de pasos, entradas ordenadas, logs, o inputs del usuario

## 🚫 HashSet<T> – Piensa en Unicidad y Rendimiento

Un `HashSet<T>` es una colección desordenada que almacena solo elementos únicos. Si intentas agregar un duplicado, será ignorado.

### Características de HashSet<T>

```csharp
// ✅ BIEN: HashSet elimina duplicados automáticamente
var set = new HashSet<string> { "a", "b", "a" };  // Elimina duplicados
Console.WriteLine(string.Join(", ", set));  // Output: "a, b"
```

**Características:**
- ✅ **Solo elementos únicos**: Elimina duplicados automáticamente
- ✅ **Sin orden garantizado**: Los elementos no mantienen orden de inserción
- ✅ **Búsqueda rápida**: O(1) promedio para buscar elementos
- ✅ **Inserción rápida**: O(1) promedio para agregar elementos
- ✅ **Eliminación rápida**: O(1) promedio para remover elementos

### Cuándo Usar HashSet<T>

```csharp
// ✅ BIEN: HashSet para elementos únicos
var userIds = new HashSet<int> { 1, 2, 3, 1 };  // Solo IDs únicos
var emails = new HashSet<string>();  // Emails únicos
var tags = new HashSet<string> { "C#", ".NET", "C#" };  // Tags únicos
```

**Casos de Uso Ideales:**
- ✅ Necesitas prevenir duplicados
- ✅ No te importa el orden
- ✅ Quieres búsquedas rápidas (O(1))
- ✅ Necesitas operaciones de conjunto (unión, intersección, diferencia)
- ✅ Listas de IDs de usuario únicos, direcciones de email, tags, o categorías

## 📊 Comparación Visual

### List<T> - Permite Duplicados

```csharp
var list = new List<string> { "a", "b", "a" };  // Permite duplicados
Console.WriteLine($"List: {string.Join(", ", list)}");
// Output: "a, b, a"
```

### HashSet<T> - Elimina Duplicados

```csharp
var set = new HashSet<string> { "a", "b", "a" };  // Elimina duplicados
Console.WriteLine($"Set: {string.Join(", ", set)}");
// Output: "a, b"
```

## 🔍 Diferencias Clave

| Característica | List<T> | HashSet<T> |
|----------------|---------|-------------|
| **Duplicados** | ✅ Permite | ❌ Elimina automáticamente |
| **Orden** | ✅ Mantiene orden de inserción | ❌ Sin orden garantizado |
| **Acceso por Índice** | ✅ O(1) | ❌ No soportado |
| **Búsqueda (Contains)** | ❌ O(n) | ✅ O(1) promedio |
| **Inserción** | ✅ O(1) amortizado | ✅ O(1) promedio |
| **Eliminación** | ❌ O(n) | ✅ O(1) promedio |
| **Operaciones de Conjunto** | ❌ No | ✅ Sí (Union, Intersect, Except) |

## 💡 Ejemplos Prácticos

### Ejemplo 1: List para Secuencia Ordenada

```csharp
// ✅ BIEN: List para pasos de un proceso ordenado
var processSteps = new List<string>
{
    "Initialize",
    "Process Data",
    "Validate",
    "Save Results"
};

// Mantiene el orden y permite duplicados si es necesario
processSteps.Add("Initialize");  // Duplicado permitido
Console.WriteLine(string.Join(" -> ", processSteps));
// Output: "Initialize -> Process Data -> Validate -> Save Results -> Initialize"
```

### Ejemplo 2: HashSet para Elementos Únicos

```csharp
// ✅ BIEN: HashSet para IDs de usuario únicos
var userIds = new HashSet<int> { 1, 2, 3, 1, 2 };  // Duplicados eliminados
Console.WriteLine($"Unique User IDs: {string.Join(", ", userIds)}");
// Output: "Unique User IDs: 1, 2, 3"

// Verificar si existe rápidamente
if (userIds.Contains(2))  // O(1) - muy rápido
{
    Console.WriteLine("User ID 2 exists");
}
```

### Ejemplo 3: Comparación de Rendimiento

```csharp
// ❌ MAL: List para verificar existencia (O(n))
var list = new List<int> { 1, 2, 3, 4, 5, /* ... 1000 elementos más */ };
if (list.Contains(500))  // O(n) - lento para listas grandes
{
    // ...
}

// ✅ BIEN: HashSet para verificar existencia (O(1))
var set = new HashSet<int> { 1, 2, 3, 4, 5, /* ... 1000 elementos más */ };
if (set.Contains(500))  // O(1) - rápido incluso para grandes colecciones
{
    // ...
}
```

### Ejemplo 4: Operaciones de Conjunto con HashSet

```csharp
// ✅ BIEN: Operaciones de conjunto con HashSet
var set1 = new HashSet<int> { 1, 2, 3, 4 };
var set2 = new HashSet<int> { 3, 4, 5, 6 };

// Unión
var union = new HashSet<int>(set1);
union.UnionWith(set2);  // { 1, 2, 3, 4, 5, 6 }

// Intersección
var intersection = new HashSet<int>(set1);
intersection.IntersectWith(set2);  // { 3, 4 }

// Diferencia
var difference = new HashSet<int>(set1);
difference.ExceptWith(set2);  // { 1, 2 }
```

## 🚀 Bonus Tip: Optimización de Rendimiento

En aplicaciones críticas para el rendimiento donde verificar duplicados manualmente en un `List<T>` puede ser costoso (O(n)), cambiar a `HashSet<T>` puede mejorar significativamente el rendimiento (O(1) para búsquedas).

### Comparación de Rendimiento

```csharp
// ❌ MAL: Verificar duplicados en List (O(n))
var list = new List<int>();
for (int i = 0; i < 10000; i++)
{
    if (!list.Contains(i))  // O(n) - cada verificación es costosa
    {
        list.Add(i);
    }
}
// Complejidad total: O(n²) - muy lento

// ✅ BIEN: HashSet elimina duplicados automáticamente (O(1))
var set = new HashSet<int>();
for (int i = 0; i < 10000; i++)
{
    set.Add(i);  // O(1) - verificación y adición rápidas
}
// Complejidad total: O(n) - mucho más rápido
```

## ⚠️ Errores Comunes

### 1. Usar List cuando Necesitas Unicidad

```csharp
// ❌ MAL: List para elementos únicos
var emails = new List<string>();
if (!emails.Contains(email))  // O(n) - lento
{
    emails.Add(email);
}

// ✅ BIEN: HashSet para elementos únicos
var emails = new HashSet<string>();
emails.Add(email);  // O(1) - rápido y automáticamente único
```

### 2. Usar HashSet cuando Necesitas Orden

```csharp
// ❌ MAL: HashSet cuando necesitas orden
var orderedSteps = new HashSet<string> { "Step 1", "Step 2", "Step 3" };
// El orden no está garantizado

// ✅ BIEN: List cuando necesitas orden
var orderedSteps = new List<string> { "Step 1", "Step 2", "Step 3" };
// Mantiene el orden de inserción
```

### 3. Usar List para Búsquedas Frecuentes

```csharp
// ❌ MAL: List para búsquedas frecuentes
var users = new List<User>();
var user = users.FirstOrDefault(u => u.Id == userId);  // O(n) - lento

// ✅ BIEN: HashSet o Dictionary para búsquedas frecuentes
var users = new HashSet<User>(new UserIdComparer());
var user = users.FirstOrDefault(u => u.Id == userId);  // O(1) - rápido

// O mejor aún, usar Dictionary
var users = new Dictionary<int, User>();
var user = users[userId];  // O(1) - más rápido
```

## 🎯 Cuándo Usar Cada Uno

### Usa List<T> cuando:
- ✅ Necesitas mantener el orden de los elementos
- ✅ Los duplicados son aceptables o requeridos
- ✅ Necesitas acceso por índice
- ✅ Quieres realizar operaciones como ordenamiento, filtrado o mapeo
- ✅ Almacenar secuencias de pasos, entradas ordenadas, logs, o inputs del usuario

### Usa HashSet<T> cuando:
- ✅ Necesitas prevenir duplicados automáticamente
- ✅ No te importa el orden
- ✅ Quieres búsquedas rápidas (O(1))
- ✅ Necesitas operaciones de conjunto (unión, intersección, diferencia)
- ✅ Listas de IDs de usuario únicos, direcciones de email, tags, o categorías

## 📊 Tabla de Decisión

| Escenario | Recomendación | Razón |
|-----------|---------------|-------|
| Elementos ordenados | List<T> | Mantiene orden de inserción |
| Elementos únicos | HashSet<T> | Elimina duplicados automáticamente |
| Acceso por índice | List<T> | Soporta indexación O(1) |
| Búsquedas frecuentes | HashSet<T> | Contains() es O(1) |
| Duplicados permitidos | List<T> | Permite elementos repetidos |
| Operaciones de conjunto | HashSet<T> | Union, Intersect, Except |
| Secuencias ordenadas | List<T> | Mantiene orden |
| IDs únicos | HashSet<T> | Garantiza unicidad |

## 💡 Mejores Prácticas

### 1. Usar HashSet para Verificar Existencia

```csharp
// ✅ BIEN: HashSet para verificar existencia rápidamente
var validIds = new HashSet<int> { 1, 2, 3, 4, 5 };
if (validIds.Contains(userId))  // O(1)
{
    ProcessUser(userId);
}
```

### 2. Usar List para Secuencias Ordenadas

```csharp
// ✅ BIEN: List para mantener orden
var processingOrder = new List<string>
{
    "Validate",
    "Process",
    "Save"
};
// El orden se mantiene
```

### 3. Combinar List y HashSet cuando Sea Necesario

```csharp
// ✅ BIEN: Combinar ambos cuando necesitas orden Y unicidad
var uniqueOrderedItems = new List<string>();
var seen = new HashSet<string>();

foreach (var item in items)
{
    if (seen.Add(item))  // Add retorna true si es nuevo
    {
        uniqueOrderedItems.Add(item);  // Mantiene orden
    }
}
```

## 📚 Relación con Otros Conceptos

Este tema está relacionado con:
- **Collections in C#**: `concepts/09-csharp-fundamentals/09-collections/`
- **Arrays vs ArrayList**: `concepts/09-csharp-fundamentals/15-arrays-vs-arraylist/`

## 🎯 Resumen

### List<T> - Orden y Duplicados
- ✅ Mantiene orden de inserción
- ✅ Permite duplicados
- ✅ Acceso por índice O(1)
- ✅ Búsqueda O(n)
- ✅ Ideal para secuencias ordenadas, logs, entradas del usuario

### HashSet<T> - Unicidad y Rendimiento
- ✅ Solo elementos únicos
- ✅ Sin orden garantizado
- ✅ Búsqueda O(1) promedio
- ✅ Inserción O(1) promedio
- ✅ Ideal para elementos únicos, búsquedas rápidas, operaciones de conjunto

### 🧠 Key Takeaway

**Usa List<T> cuando:**
- Necesitas elementos ordenados
- Los duplicados son aceptables
- El indexado es importante

**Usa HashSet<T> cuando:**
- Necesitas búsquedas rápidas
- No quieres duplicados
- La unicidad es esencial

## 📚 Recursos Adicionales

- [Microsoft Docs - List<T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1)
- [Microsoft Docs - HashSet<T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.hashset-1)
- [Microsoft Docs - Collections](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/collections)

