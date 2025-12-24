# Mejores Prácticas: List vs HashSet

## ✅ Reglas de Oro

### 1. Usar List<T> para Secuencias Ordenadas

```csharp
// ✅ BIEN: List para mantener orden
var processSteps = new List<string>
{
    "Initialize",
    "Process Data",
    "Validate",
    "Save Results"
};
// El orden se mantiene
```

### 2. Usar HashSet<T> para Elementos Únicos

```csharp
// ✅ BIEN: HashSet para elementos únicos
var userIds = new HashSet<int> { 1, 2, 3, 1, 2 };  // Duplicados eliminados
var emails = new HashSet<string>();  // Emails únicos
```

### 3. Usar HashSet<T> para Búsquedas Rápidas

```csharp
// ✅ BIEN: HashSet para verificar existencia rápidamente
var validIds = new HashSet<int> { 1, 2, 3, 4, 5 };
if (validIds.Contains(userId))  // O(1) - muy rápido
{
    ProcessUser(userId);
}

// ❌ MAL: List para búsquedas frecuentes
var validIds = new List<int> { 1, 2, 3, 4, 5 };
if (validIds.Contains(userId))  // O(n) - lento para listas grandes
{
    ProcessUser(userId);
}
```

### 4. Combinar List y HashSet cuando Sea Necesario

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

## ⚠️ Errores Comunes a Evitar

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

## 🎯 Casos de Uso Específicos

### 1. List para Secuencias Ordenadas

```csharp
// ✅ BIEN: List para pasos de un proceso ordenado
var processSteps = new List<string>
{
    "Initialize",
    "Process Data",
    "Validate",
    "Save Results"
};
```

### 2. HashSet para IDs Únicos

```csharp
// ✅ BIEN: HashSet para IDs de usuario únicos
var userIds = new HashSet<int> { 1, 2, 3, 1, 2 };  // Duplicados eliminados
Console.WriteLine($"Unique User IDs: {string.Join(", ", userIds)}");
// Output: "Unique User IDs: 1, 2, 3"
```

### 3. HashSet para Operaciones de Conjunto

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

## 💡 Pro Tips

### 1. Usar HashSet para Verificar Existencia Rápidamente

```csharp
// ✅ BIEN: HashSet para verificar existencia
var validIds = new HashSet<int> { 1, 2, 3, 4, 5 };
if (validIds.Contains(userId))  // O(1)
{
    ProcessUser(userId);
}
```

### 2. Usar List para Mantener Orden de Inserción

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

### 3. Optimizar Rendimiento con HashSet

```csharp
// ✅ BIEN: HashSet para evitar verificaciones costosas
var seen = new HashSet<int>();
foreach (var item in items)
{
    if (seen.Add(item))  // O(1) - rápido
    {
        ProcessItem(item);
    }
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - List<T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1)
- [Microsoft Docs - HashSet<T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.hashset-1)
- [Microsoft Docs - Collections](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/collections)

