# Collections in C# 📊✨

## Introducción

Las colecciones en C# son estructuras de datos fundamentales que simplifican la gestión de datos en cualquier proyecto. C# ofrece tres categorías principales de colecciones, cada una diseñada para diferentes escenarios y necesidades.

## 📊 Categorías de Colecciones

C# organiza las colecciones en tres namespaces principales:

```
Collections in C#
├── System.Collections.Generic (Genéricas)
├── System.Collections.Concurrent (Thread-Safe)
└── System.Collections (Legacy/No Genéricas)
```

## 🟦 1. System.Collections.Generic

Colecciones genéricas type-safe que son las más utilizadas en aplicaciones modernas.

### 🔑 Dictionary<TKey, TValue>

**Almacena pares clave-valor para búsquedas rápidas.**

```csharp
// ✅ BIEN: Dictionary para búsquedas rápidas por clave
var users = new Dictionary<int, string>
{
    { 1, "Alice" },
    { 2, "Bob" },
    { 3, "Charlie" }
};

// Búsqueda O(1) promedio
if (users.TryGetValue(1, out var userName))
{
    Console.WriteLine($"User: {userName}");
}

// Agregar elementos
users[4] = "David";

// Iterar sobre pares clave-valor
foreach (var kvp in users)
{
    Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
}
```

**Características:**
- Búsqueda rápida O(1) promedio
- No permite claves duplicadas
- Type-safe con genéricos
- Ideal para mapeos y búsquedas rápidas

### 📋 List<T>

**Un array dinámico para manejo flexible de datos.**

```csharp
// ✅ BIEN: List para colecciones dinámicas
var numbers = new List<int> { 1, 2, 3, 4, 5 };

// Agregar elementos
numbers.Add(6);
numbers.AddRange(new[] { 7, 8, 9 });

// Acceso por índice O(1)
var first = numbers[0];

// Búsqueda O(n)
var index = numbers.IndexOf(5);

// Operaciones LINQ
var evens = numbers.Where(n => n % 2 == 0).ToList();

// Iterar
foreach (var number in numbers)
{
    Console.WriteLine(number);
}
```

**Características:**
- Tamaño dinámico
- Acceso por índice O(1)
- Búsqueda O(n)
- Ideal para listas ordenadas y operaciones secuenciales

**🚀 .NET 9: AddRange ahora soporta Span<T>**

En **.NET 9**, `List<T>.AddRange()` ahora acepta directamente `Span<T>`, lo que mejora el rendimiento y reduce asignaciones de memoria.

```csharp
// ✅ BIEN: .NET 9 - AddRange con Span<T>
Span<int> span = stackalloc int[] { 1, 2, 3 };
List<int> list = new();
list.AddRange(span);  // Directamente desde Span<T>

// ❌ ANTES (.NET 8 y anteriores): Necesitabas convertir primero
Span<int> span = stackalloc int[] { 1, 2, 3 };
List<int> list = new();
// Tenías que hacer esto:
foreach (var item in span)
{
    list.Add(item);  // O convertir a array primero
}
```

**Beneficios en .NET 9:**
- ✅ **Código más limpio**: Sin conversiones innecesarias
- ✅ **Menos asignaciones**: Mejor uso de memoria
- ✅ **Mejor rendimiento**: Especialmente en operaciones con muchos datos
- ✅ **Type-safe**: Mantiene la seguridad de tipos

### 🎯 Queue<T>

**Estructura FIFO (First In, First Out) para tareas.**

```csharp
// ✅ BIEN: Queue para procesamiento FIFO
var taskQueue = new Queue<string>();

// Enqueue (agregar al final)
taskQueue.Enqueue("Task 1");
taskQueue.Enqueue("Task 2");
taskQueue.Enqueue("Task 3");

// Dequeue (remover del inicio) - FIFO
while (taskQueue.Count > 0)
{
    var task = taskQueue.Dequeue();
    Console.WriteLine($"Processing: {task}");
}

// Peek (ver sin remover)
var nextTask = taskQueue.Peek();
```

**Características:**
- FIFO (First In, First Out)
- Operaciones O(1)
- Ideal para procesamiento de tareas en orden
- Usado en algoritmos de gráficos (BFS)

### 📚 SortedList<TKey, TValue>

**Una colección clave-valor ordenada.**

```csharp
// ✅ BIEN: SortedList para mantener orden automático
var sortedScores = new SortedList<string, int>
{
    { "Alice", 95 },
    { "Bob", 87 },
    { "Charlie", 92 }
};

// Se mantiene ordenado automáticamente por clave
foreach (var kvp in sortedScores)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

// Búsqueda O(log n)
if (sortedScores.ContainsKey("Alice"))
{
    var score = sortedScores["Alice"];
}
```

**Características:**
- Mantiene orden automático por clave
- Búsqueda O(log n)
- Inserción O(n) en peor caso
- Ideal cuando necesitas orden y búsqueda rápida

### 📦 Stack<T>

**LIFO (Last In, First Out) para tareas en orden inverso.**

```csharp
// ✅ BIEN: Stack para procesamiento LIFO
var undoStack = new Stack<string>();

// Push (agregar al tope)
undoStack.Push("Action 1");
undoStack.Push("Action 2");
undoStack.Push("Action 3");

// Pop (remover del tope) - LIFO
while (undoStack.Count > 0)
{
    var action = undoStack.Pop();
    Console.WriteLine($"Undoing: {action}");
}

// Peek (ver sin remover)
var topAction = undoStack.Peek();
```

**Características:**
- LIFO (Last In, First Out)
- Operaciones O(1)
- Ideal para undo/redo, evaluación de expresiones
- Usado en algoritmos de gráficos (DFS)

## 🟩 2. System.Collections.Concurrent

Colecciones thread-safe optimizadas para programación paralela y concurrente.

### 🚀 ConcurrentDictionary<Key, Value>

**Diccionario thread-safe para programación paralela.**

```csharp
// ✅ BIEN: ConcurrentDictionary para acceso concurrente seguro
var concurrentDict = new ConcurrentDictionary<int, string>();

// Operaciones thread-safe
Parallel.For(0, 100, i =>
{
    concurrentDict.TryAdd(i, $"Value {i}");
});

// Obtener o agregar de forma atómica
var value = concurrentDict.GetOrAdd(1, key => $"Default {key}");

// Actualizar de forma thread-safe
concurrentDict.AddOrUpdate(1, "New", (key, oldValue) => "Updated");

// Iterar (snapshot thread-safe)
foreach (var kvp in concurrentDict)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}
```

**Características:**
- Thread-safe sin bloqueo explícito
- Operaciones atómicas
- Ideal para programación paralela
- Mejor rendimiento que Dictionary con locks

### 🔄 ConcurrentQueue<T> & ConcurrentStack<T>

**FIFO y LIFO optimizados para concurrencia.**

```csharp
// ✅ BIEN: ConcurrentQueue para FIFO thread-safe
var concurrentQueue = new ConcurrentQueue<string>();

// Múltiples threads pueden agregar simultáneamente
Parallel.For(0, 10, i =>
{
    concurrentQueue.Enqueue($"Item {i}");
});

// Múltiples threads pueden procesar
Parallel.ForEach(concurrentQueue, item =>
{
    Console.WriteLine($"Processing: {item}");
});

// ✅ BIEN: ConcurrentStack para LIFO thread-safe
var concurrentStack = new ConcurrentStack<string>();

concurrentStack.Push("Item 1");
concurrentStack.Push("Item 2");

if (concurrentStack.TryPop(out var item))
{
    Console.WriteLine($"Popped: {item}");
}
```

**Características:**
- Thread-safe sin locks explícitos
- Operaciones atómicas
- Ideal para producer-consumer patterns
- Optimizado para alta concurrencia

### ⛓️ BlockingCollection<T>

**Ideal para escenarios producer-consumer en multi-threading.**

```csharp
// ✅ BIEN: BlockingCollection para producer-consumer
var blockingCollection = new BlockingCollection<string>();

// Producer thread
Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
    {
        blockingCollection.Add($"Item {i}");
        Thread.Sleep(100);
    }
    blockingCollection.CompleteAdding();
});

// Consumer thread
Task.Run(() =>
{
    foreach (var item in blockingCollection.GetConsumingEnumerable())
    {
        Console.WriteLine($"Consumed: {item}");
    }
});
```

**Características:**
- Bloquea cuando está vacío (espera elementos)
- Thread-safe
- Ideal para producer-consumer patterns
- Puede usar cualquier colección concurrente como almacenamiento

### ConcurrentBag<T>

**Colección thread-safe sin orden específico.**

```csharp
// ✅ BIEN: ConcurrentBag para colección thread-safe sin orden
var bag = new ConcurrentBag<int>();

Parallel.For(0, 10, i =>
{
    bag.Add(i);
});

// Iterar (sin orden garantizado)
foreach (var item in bag)
{
    Console.WriteLine(item);
}

// TryTake (remover elemento)
if (bag.TryTake(out var value))
{
    Console.WriteLine($"Took: {value}");
}
```

**Características:**
- Thread-safe
- Sin orden específico
- Optimizado para cuando el orden no importa
- Ideal para pooling de objetos

## 🟨 3. System.Collections

Colecciones legacy no genéricas (menos utilizadas en código moderno).

### 📂 ArrayList

**Colección de objetos no genérica (legacy).**

```csharp
// ⚠️ LEGACY: ArrayList (no genérica, menos eficiente)
var arrayList = new ArrayList();
arrayList.Add("String");
arrayList.Add(123);
arrayList.Add(new object());

// ❌ No type-safe
var value = arrayList[0]; // object, necesita casting

// ✅ MEJOR: Usar List<T> en código moderno
var list = new List<string>();
list.Add("String");
// list.Add(123); // Error de compilación - type-safe
```

**Características:**
- No type-safe
- Boxing/unboxing overhead
- Legacy - usar List<T> en código moderno

### 🔑 Hashtable

**Almacenamiento clave-valor legacy para objetos.**

```csharp
// ⚠️ LEGACY: Hashtable (no genérica)
var hashtable = new Hashtable();
hashtable.Add("key1", "value1");
hashtable.Add(123, "value2");

// ❌ No type-safe
var value = hashtable["key1"]; // object

// ✅ MEJOR: Usar Dictionary<TKey, TValue> en código moderno
var dictionary = new Dictionary<string, string>();
dictionary.Add("key1", "value1");
```

**Características:**
- No type-safe
- Legacy - usar Dictionary<TKey, TValue> en código moderno

### 📤 Queue & Stack

**Estructuras FIFO y LIFO legacy.**

```csharp
// ⚠️ LEGACY: Queue no genérica
var queue = new Queue();
queue.Enqueue("Item");
var item = queue.Dequeue(); // object

// ✅ MEJOR: Usar Queue<T> en código moderno
var genericQueue = new Queue<string>();
genericQueue.Enqueue("Item");
var typedItem = genericQueue.Dequeue(); // string
```

**Características:**
- No type-safe
- Legacy - usar Queue<T> y Stack<T> en código moderno

## 🔍 Interfaces de Colecciones: IEnumerable<T>, ICollection<T>, e IList<T>

Las interfaces de colecciones forman una jerarquía que define diferentes niveles de funcionalidad. Comprender estas interfaces es esencial para escribir código optimizado y mantenible.

### 📊 Jerarquía de Interfaces

```
IEnumerable<T> (Base - Solo iteración)
    ↓
ICollection<T> (Agrega modificación)
    ↓
IList<T> (Agrega acceso por índice)
```

### 🔍 1. IEnumerable<T> – La Base de la Iteración

`IEnumerable<T>` es la interfaz más básica que permite iterar sobre una colección. Proporciona una forma de recorrer elementos usando un bucle `foreach`, pero **no permite modificar** la colección.

**Características Clave:**
- ✅ Permite iteración simple sobre una colección
- ✅ No soporta agregar o remover elementos
- ✅ Ideal para acceso de solo lectura

```csharp
// ✅ BIEN: IEnumerable<T> para iteración
IEnumerable<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

// Iterar sobre la colección
foreach (var number in numbers)
{
    Console.WriteLine(number);
}

// ✅ BIEN: Retornar IEnumerable<T> desde métodos
public IEnumerable<User> GetActiveUsers()
{
    return _users.Where(u => u.IsActive);
    // Retorna IEnumerable, no List - más flexible
}

// ❌ MAL: No puedes modificar IEnumerable<T>
// numbers.Add(6); // Error: IEnumerable<T> no tiene método Add
```

**Cuándo Usar:**
- ✅ Cuando solo necesitas leer e iterar sobre datos
- ✅ Como tipo de retorno de métodos (más flexible)
- ✅ Para consultas LINQ y procesamiento de datos
- ✅ Cuando trabajas con datos de solo lectura

### 📂 2. ICollection<T> – Agregando Capacidades de Modificación

`ICollection<T>` extiende `IEnumerable<T>` agregando funcionalidad para **modificar** la colección. Permite agregar, remover y contar elementos. Sin embargo, **no proporciona acceso indexado**.

**Características Clave:**
- ✅ Soporta agregar y remover elementos
- ✅ Proporciona la propiedad `Count` para verificar el número de elementos
- ✅ Aún no permite acceso directo por índice

```csharp
// ✅ BIEN: ICollection<T> para modificación sin índice
ICollection<string> items = new List<string> { "A", "B", "C" };

// Agregar elementos
items.Add("D");
items.Add("E");

// Remover elementos
items.Remove("A");

// Contar elementos
Console.WriteLine($"Total: {items.Count}"); // Total: 4

// Iterar (heredado de IEnumerable<T>)
foreach (var item in items)
{
    Console.WriteLine(item);
}

// ❌ MAL: No puedes acceder por índice
// var first = items[0]; // Error: ICollection<T> no tiene indexer
```

**Cuándo Usar:**
- ✅ Cuando necesitas modificar la colección pero no requieres acceso indexado
- ✅ Para gestionar listas dinámicas de objetos
- ✅ Cuando el orden no es crítico para el acceso

### 📋 3. IList<T> – Control Completo con Indexación

`IList<T>` se construye sobre `ICollection<T>` agregando **acceso basado en índice**. Esto significa que puedes recuperar, insertar o remover elementos en posiciones específicas. Combina todas las características de `IEnumerable<T>` e `ICollection<T>`, haciéndola la opción más flexible.

**Características Clave:**
- ✅ Soporta acceso indexado, permitiendo recuperación y modificación por índice
- ✅ Permite inserción y eliminación en posiciones específicas
- ✅ Ideal para casos donde necesitas modificación y acceso aleatorio

```csharp
// ✅ BIEN: IList<T> para acceso completo con índice
IList<string> items = new List<string> { "A", "B", "C" };

// Acceso por índice O(1)
var first = items[0];        // "A"
items[1] = "X";              // Modificar por índice

// Insertar en posición específica
items.Insert(1, "New");      // Inserta en índice 1

// Remover por índice
items.RemoveAt(0);           // Remueve primer elemento

// Todas las operaciones de ICollection<T>
items.Add("D");
items.Remove("B");
Console.WriteLine($"Count: {items.Count}");

// Todas las operaciones de IEnumerable<T>
foreach (var item in items)
{
    Console.WriteLine(item);
}
```

**Cuándo Usar:**
- ✅ Cuando necesitas modificar la colección y requieres acceso indexado
- ✅ Para trabajar con listas que permiten manipulación directa de elementos
- ✅ Cuando necesitas insertar o remover en posiciones específicas

### 🔥 Diferencias Clave en un Vistazo

| Característica | IEnumerable<T> | ICollection<T> | IList<T> |
|----------------|----------------|----------------|----------|
| **Iteración** | ✅ Sí | ✅ Sí (heredado) | ✅ Sí (heredado) |
| **Agregar elementos** | ❌ No | ✅ Sí | ✅ Sí (heredado) |
| **Remover elementos** | ❌ No | ✅ Sí | ✅ Sí (heredado) |
| **Count** | ❌ No | ✅ Sí | ✅ Sí (heredado) |
| **Acceso por índice** | ❌ No | ❌ No | ✅ Sí |
| **Insertar por índice** | ❌ No | ❌ No | ✅ Sí |
| **Remover por índice** | ❌ No | ❌ No | ✅ Sí |

### 📊 Tabla de Decisión: Cuándo Usar Cada Interfaz

| Escenario | Interfaz Recomendada | Razón |
|-----------|---------------------|-------|
| Solo lectura e iteración | `IEnumerable<T>` | Más flexible, no permite modificación accidental |
| Modificación sin índice | `ICollection<T>` | Permite modificar sin necesidad de acceso indexado |
| Modificación con índice | `IList<T>` | Acceso completo a todas las operaciones |
| Tipo de retorno de métodos | `IEnumerable<T>` | Máxima flexibilidad para el consumidor |
| Parámetros de métodos | `ICollection<T>` o `IList<T>` | Depende de si necesitas índice |

### 💡 Mejores Prácticas

#### 1. Preferir IEnumerable<T> como Tipo de Retorno

```csharp
// ✅ BIEN: Retornar IEnumerable<T> (más flexible)
public IEnumerable<User> GetActiveUsers()
{
    return _users.Where(u => u.IsActive);
    // El consumidor puede convertir a List, Array, etc. si lo necesita
}

// ❌ MAL: Retornar List<T> específico
public List<User> GetActiveUsers()
{
    return _users.Where(u => u.IsActive).ToList();
    // Fuerza al consumidor a usar List específicamente
}
```

#### 2. Usar la Interfaz Más Específica Necesaria

```csharp
// ✅ BIEN: Usar ICollection<T> si no necesitas índice
public void ProcessItems(ICollection<string> items)
{
    items.Add("New Item");
    items.Remove("Old Item");
    // No necesitas acceso por índice
}

// ✅ BIEN: Usar IList<T> si necesitas índice
public void ProcessItems(IList<string> items)
{
    items[0] = "First";
    items.Insert(1, "Second");
    // Necesitas acceso por índice
}
```

#### 3. Evitar Convertir Innecesariamente

```csharp
// ❌ MAL: Convertir IEnumerable a List innecesariamente
var users = GetUsers().ToList(); // Si solo vas a iterar, no necesitas List

// ✅ BIEN: Mantener como IEnumerable si solo iteras
var users = GetUsers();
foreach (var user in users)
{
    ProcessUser(user);
}
```

## 💡 Why Should You Care?

### 🚦 Collections Simplifican la Gestión de Datos

Las colecciones son fundamentales en cualquier proyecto .NET:

- **Organización de Datos**: Estructuran y organizan datos eficientemente
- **Operaciones Comunes**: Proporcionan operaciones comunes pre-optimizadas
- **Type Safety**: Las genéricas proporcionan seguridad de tipos
- **Performance**: Optimizadas para diferentes casos de uso

### 🔐 Concurrent Collections Habilitan Programación Thread-Safe

Las colecciones concurrentes son esenciales para aplicaciones modernas:

- **Thread Safety**: Operaciones seguras sin locks explícitos
- **Performance**: Optimizadas para alta concurrencia
- **Producer-Consumer**: Patrones comunes de multi-threading
- **Escalabilidad**: Permiten aplicaciones escalables

### 🎨 Perfectas para Escenarios Diversos

Desde algoritmos hasta aplicaciones del mundo real:

- **Algoritmos**: BFS (Queue), DFS (Stack), Hash Tables (Dictionary)
- **Aplicaciones Web**: Caché (Dictionary), Colas de procesamiento (Queue)
- **Multi-threading**: Producer-Consumer (BlockingCollection), Caché compartido (ConcurrentDictionary)
- **Data Processing**: Listas dinámicas (List), Ordenamiento (SortedList)

## 📊 Tabla Comparativa de Colecciones Genéricas

| Colección | Orden | Búsqueda | Inserción | Thread-Safe | Caso de Uso |
|-----------|-------|----------|-----------|-------------|-------------|
| **Dictionary<TKey, TValue>** | No | O(1) | O(1) | No | Mapeos, búsquedas rápidas |
| **List<T>** | Sí (por índice) | O(n) | O(1) amortizado | No | Listas dinámicas |
| **Queue<T>** | FIFO | N/A | O(1) | No | Procesamiento en orden |
| **Stack<T>** | LIFO | N/A | O(1) | No | Undo/redo, evaluación |
| **SortedList<TKey, TValue>** | Sí (por clave) | O(log n) | O(n) | No | Orden + búsqueda |

## 📊 Tabla Comparativa de Colecciones Concurrentes

| Colección | Orden | Thread-Safe | Caso de Uso |
|-----------|-------|-------------|-------------|
| **ConcurrentDictionary** | No | Sí | Caché compartido, contadores |
| **ConcurrentQueue** | FIFO | Sí | Producer-consumer FIFO |
| **ConcurrentStack** | LIFO | Sí | Producer-consumer LIFO |
| **ConcurrentBag** | No | Sí | Pooling, cuando orden no importa |
| **BlockingCollection** | Depende | Sí | Producer-consumer con bloqueo |

## 🎯 Cuándo Usar Cada Colección

### Dictionary<TKey, TValue>
- ✅ Búsquedas rápidas por clave
- ✅ Mapeos y asociaciones
- ✅ Caché y lookups

### List<T>
- ✅ Listas dinámicas
- ✅ Acceso por índice
- ✅ Operaciones secuenciales

### Queue<T>
- ✅ Procesamiento FIFO
- ✅ Colas de tareas
- ✅ BFS algorithms

### Stack<T>
- ✅ Procesamiento LIFO
- ✅ Undo/redo
- ✅ DFS algorithms
- ✅ Evaluación de expresiones

### SortedList<TKey, TValue>
- ✅ Necesitas orden automático
- ✅ Búsquedas frecuentes
- ✅ Pocas inserciones

### ConcurrentDictionary
- ✅ Caché compartido entre threads
- ✅ Contadores thread-safe
- ✅ Programación paralela

### BlockingCollection
- ✅ Producer-consumer patterns
- ✅ Procesamiento asíncrono
- ✅ Colas de trabajo entre threads

## 📚 Recursos Adicionales

- [Microsoft Docs - Collections](https://docs.microsoft.com/dotnet/standard/collections/)
- [Microsoft Docs - Generic Collections](https://docs.microsoft.com/dotnet/standard/collections/generic/)
- [Microsoft Docs - Concurrent Collections](https://docs.microsoft.com/dotnet/standard/collections/thread-safe/)

