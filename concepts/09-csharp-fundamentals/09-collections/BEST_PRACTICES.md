# Mejores Prácticas: Collections en C#

## ✅ Reglas de Oro

### 1. Preferir Colecciones Genéricas sobre Legacy

```csharp
// ❌ MAL: Usar colecciones legacy
var list = new ArrayList();
list.Add("String");
list.Add(123); // No type-safe

// ✅ BIEN: Usar colecciones genéricas
var list = new List<string>();
list.Add("String");
// list.Add(123); // Error de compilación - type-safe
```

### 2. Usar Dictionary para Búsquedas Rápidas

```csharp
// ✅ BIEN: Dictionary para búsquedas O(1)
var userCache = new Dictionary<int, User>();
var user = userCache[userId]; // Búsqueda rápida

// ❌ MAL: List para búsquedas frecuentes
var users = new List<User>();
var user = users.FirstOrDefault(u => u.Id == userId); // O(n) - lento
```

### 3. Usar TryGetValue en lugar de ContainsKey + Indexer

```csharp
// ❌ MAL: Doble lookup
if (dictionary.ContainsKey(key))
{
    var value = dictionary[key]; // Segunda búsqueda
}

// ✅ BIEN: Un solo lookup
if (dictionary.TryGetValue(key, out var value))
{
    // Usar value
}
```

### 4. Usar Concurrent Collections para Multi-threading

```csharp
// ❌ MAL: Dictionary con lock manual
private readonly object _lock = new object();
private readonly Dictionary<int, string> _cache = new();

public string GetValue(int key)
{
    lock (_lock)
    {
        return _cache[key];
    }
}

// ✅ BIEN: ConcurrentDictionary thread-safe
private readonly ConcurrentDictionary<int, string> _cache = new();

public string GetValue(int key)
{
    return _cache.GetOrAdd(key, k => ComputeValue(k));
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Modificar Colección Durante Iteración

```csharp
// ❌ MAL: Modificar durante iteración
var list = new List<int> { 1, 2, 3, 4, 5 };
foreach (var item in list)
{
    if (item % 2 == 0)
        list.Remove(item); // InvalidOperationException
}

// ✅ BIEN: Iterar hacia atrás o usar ToList()
var list = new List<int> { 1, 2, 3, 4, 5 };
for (int i = list.Count - 1; i >= 0; i--)
{
    if (list[i] % 2 == 0)
        list.RemoveAt(i);
}

// ✅ MEJOR: Usar RemoveAll
list.RemoveAll(item => item % 2 == 0);
```

### 2. Usar List cuando Necesitas Búsquedas Rápidas

```csharp
// ❌ MAL: List para búsquedas frecuentes
var users = new List<User>();
var user = users.FirstOrDefault(u => u.Id == userId); // O(n)

// ✅ BIEN: Dictionary para búsquedas rápidas
var users = new Dictionary<int, User>();
var user = users[userId]; // O(1)
```

### 3. No Usar Capacity cuando Conoces el Tamaño

```csharp
// ❌ MAL: Sin capacidad inicial (múltiples reasignaciones)
var list = new List<int>();
for (int i = 0; i < 1000; i++)
{
    list.Add(i); // Puede causar múltiples reasignaciones
}

// ✅ BIEN: Especificar capacidad inicial
var list = new List<int>(1000);
for (int i = 0; i < 1000; i++)
{
    list.Add(i); // Sin reasignaciones
}
```

### 4. Usar Colecciones Legacy en Código Nuevo

```csharp
// ❌ MAL: Usar ArrayList en código nuevo
var list = new ArrayList();
list.Add("String");
list.Add(123); // No type-safe

// ✅ BIEN: Usar List<T>
var list = new List<string>();
list.Add("String");
```

## 🎯 Casos de Uso Específicos

### 1. Dictionary para Caché

```csharp
// ✅ BIEN: Dictionary como caché
public class UserCache
{
    private readonly Dictionary<int, User> _cache = new();
    private readonly IUserRepository _repository;
    
    public async Task<User> GetUserAsync(int id)
    {
        if (_cache.TryGetValue(id, out var cachedUser))
        {
            return cachedUser;
        }
        
        var user = await _repository.GetByIdAsync(id);
        _cache[id] = user;
        return user;
    }
}
```

### 2. Queue para Procesamiento de Tareas

```csharp
// ✅ BIEN: Queue para procesamiento FIFO
public class TaskProcessor
{
    private readonly Queue<Task> _taskQueue = new();
    
    public void EnqueueTask(Task task)
    {
        _taskQueue.Enqueue(task);
    }
    
    public void ProcessTasks()
    {
        while (_taskQueue.Count > 0)
        {
            var task = _taskQueue.Dequeue();
            task.Execute();
        }
    }
}
```

### 3. Stack para Undo/Redo

```csharp
// ✅ BIEN: Stack para undo/redo
public class UndoRedoManager
{
    private readonly Stack<Action> _undoStack = new();
    private readonly Stack<Action> _redoStack = new();
    
    public void Execute(Action action)
    {
        action.Execute();
        _undoStack.Push(action);
        _redoStack.Clear();
    }
    
    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            var action = _undoStack.Pop();
            action.Undo();
            _redoStack.Push(action);
        }
    }
}
```

### 4. ConcurrentDictionary para Contadores Thread-Safe

```csharp
// ✅ BIEN: ConcurrentDictionary para contadores
public class RequestCounter
{
    private readonly ConcurrentDictionary<string, int> _counters = new();
    
    public void Increment(string endpoint)
    {
        _counters.AddOrUpdate(endpoint, 1, (key, value) => value + 1);
    }
    
    public int GetCount(string endpoint)
    {
        return _counters.GetOrAdd(endpoint, 0);
    }
}
```

### 5. BlockingCollection para Producer-Consumer

```csharp
// ✅ BIEN: BlockingCollection para producer-consumer
public class MessageProcessor
{
    private readonly BlockingCollection<Message> _messages = new();
    
    public void StartProcessing()
    {
        // Producer
        Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                _messages.Add(new Message { Id = i });
            }
            _messages.CompleteAdding();
        });
        
        // Consumer
        Task.Run(() =>
        {
            foreach (var message in _messages.GetConsumingEnumerable())
            {
                ProcessMessage(message);
            }
        });
    }
}
```

## 🚀 Tips Avanzados

### 1. Usar Initializers para Inicialización Rápida

```csharp
// ✅ BIEN: Collection initializers
var dictionary = new Dictionary<string, int>
{
    { "Alice", 95 },
    { "Bob", 87 },
    { "Charlie", 92 }
};

var list = new List<int> { 1, 2, 3, 4, 5 };
```

### 2. Especificar Capacity para Mejor Performance

```csharp
// ✅ BIEN: Especificar capacidad cuando la conoces
var list = new List<int>(1000); // Evita reasignaciones
var dictionary = new Dictionary<int, string>(100); // Mejor rendimiento inicial
```

### 3. Usar LINQ con Colecciones

```csharp
// ✅ BIEN: LINQ con colecciones
var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var evens = numbers.Where(n => n % 2 == 0).ToList();
var sum = numbers.Sum();
var max = numbers.Max();
var grouped = numbers.GroupBy(n => n % 2);
```

### 4. Comparadores Personalizados

```csharp
// ✅ BIEN: Comparadores personalizados
var sortedList = new SortedList<string, int>(
    Comparer<string>.Create((x, y) => y.CompareTo(x)) // Orden descendente
);
```

## 📊 Tabla de Decisión: Cuándo Usar Cada Colección

| Escenario | Colección Recomendada | Razón |
|-----------|------------------------|-------|
| Búsquedas rápidas por clave | Dictionary<TKey, TValue> | O(1) lookup |
| Lista dinámica con acceso por índice | List<T> | O(1) acceso por índice |
| Procesamiento FIFO | Queue<T> | Estructura FIFO |
| Procesamiento LIFO | Stack<T> | Estructura LIFO |
| Orden automático + búsqueda | SortedList<TKey, TValue> | Orden + búsqueda O(log n) |
| Caché thread-safe | ConcurrentDictionary | Thread-safe sin locks |
| Producer-consumer | BlockingCollection | Bloqueo automático |
| Pooling sin orden | ConcurrentBag | Thread-safe, sin orden |

## 💡 Pro Tips

### 1. Siempre Usar Colecciones Genéricas

```csharp
// Preferir siempre las versiones genéricas
List<T> en lugar de ArrayList
Dictionary<TKey, TValue> en lugar de Hashtable
Queue<T> en lugar de Queue
Stack<T> en lugar de Stack
```

### 2. Considerar Performance Characteristics

```csharp
// Dictionary: O(1) lookup, O(1) insertion
// List: O(1) acceso por índice, O(n) búsqueda
// SortedList: O(log n) búsqueda, O(n) inserción
```

### 3. Usar Concurrent Collections Solo cuando Sea Necesario

```csharp
// ⚠️ Concurrent collections tienen overhead
// Solo úsalas cuando realmente necesites thread-safety
// Para single-threaded, usa colecciones regulares
```

### 4. Preferir IEnumerable<T> como Tipo de Retorno

```csharp
// ✅ BIEN: Retornar IEnumerable<T>
public IEnumerable<User> GetUsers()
{
    return _users.Where(u => u.IsActive);
}

// ❌ MAL: Retornar List<T> específico
public List<User> GetUsers()
{
    return _users.Where(u => u.IsActive).ToList();
}
```

## 🚀 Mejoras en .NET 9

### AddRange ahora soporta Span<T>

**.NET 9** introduce soporte directo para `Span<T>` en `List<T>.AddRange()`, mejorando significativamente el rendimiento y reduciendo asignaciones de memoria.

**Antes de .NET 9:**
```csharp
// ❌ MAL: Necesitabas convertir o iterar
Span<int> span = stackalloc int[] { 1, 2, 3 };
List<int> list = new();
foreach (var item in span)
{
    list.Add(item);  // Múltiples asignaciones
}
```

**En .NET 9:**
```csharp
// ✅ BIEN: Soporte directo para Span<T>
Span<int> span = stackalloc int[] { 1, 2, 3 };
List<int> list = new();
list.AddRange(span);  // Directamente desde Span<T>
Console.WriteLine(string.Join(", ", list));  // Output: 1, 2, 3
```

**Beneficios:**
- ✅ **Código más limpio**: Sin conversiones innecesarias
- ✅ **Menos asignaciones**: Mejor uso de memoria
- ✅ **Mejor rendimiento**: Especialmente en operaciones con muchos datos
- ✅ **Type-safe**: Mantiene la seguridad de tipos

**Cuándo usar:**
- ✅ Cuando trabajas con `Span<T>` o `ReadOnlySpan<T>`
- ✅ En código crítico para el rendimiento
- ✅ Cuando necesitas reducir asignaciones de memoria
- ✅ Al trabajar con buffers stack-allocated

## 📚 Recursos Adicionales

- [Microsoft Docs - Collections](https://docs.microsoft.com/dotnet/standard/collections/)
- [Microsoft Docs - Generic Collections](https://docs.microsoft.com/dotnet/standard/collections/generic/)
- [Microsoft Docs - Concurrent Collections](https://docs.microsoft.com/dotnet/standard/collections/thread-safe/)
- [.NET 9 Performance Improvements](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-9/)

