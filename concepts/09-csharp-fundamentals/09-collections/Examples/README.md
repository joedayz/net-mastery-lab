# Ejemplos Prácticos - Collections in C#

Esta carpeta contiene ejemplos ejecutables que demuestran las diferentes colecciones disponibles en C#.

## Archivos

### `CollectionsExamples.cs`
Demostraciones prácticas de Collections en C#:
- `DemonstrateGenericCollections()` - Colecciones genéricas (Dictionary, List, Queue, Stack, SortedList)
- `DemonstrateConcurrentCollections()` - Colecciones concurrentes thread-safe
- `DemonstrateLegacyCollections()` - Colecciones legacy (no recomendadas)
- `DemonstrateWhenToUse()` - Cuándo usar cada colección
- `DemonstrateWhyItMatters()` - Por qué importan las colecciones
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Collections
```

## Conceptos Clave

- **System.Collections.Generic**: Colecciones type-safe más utilizadas
- **System.Collections.Concurrent**: Colecciones thread-safe para programación paralela
- **System.Collections**: Colecciones legacy (no recomendadas para código nuevo)

## Ejemplo Básico: Dictionary

```csharp
var users = new Dictionary<int, string>
{
    { 1, "Alice" },
    { 2, "Bob" }
};

if (users.TryGetValue(1, out var userName))
{
    Console.WriteLine(userName);
}
```

## Ejemplo Básico: List

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
numbers.Add(6);
var first = numbers[0];
```

## Ejemplo Básico: Queue

```csharp
var queue = new Queue<string>();
queue.Enqueue("Task 1");
queue.Enqueue("Task 2");
var task = queue.Dequeue(); // FIFO
```

## Ejemplo Básico: Stack

```csharp
var stack = new Stack<string>();
stack.Push("Action 1");
stack.Push("Action 2");
var action = stack.Pop(); // LIFO
```

## Ejemplo Básico: ConcurrentDictionary

```csharp
var dict = new ConcurrentDictionary<int, string>();
dict.TryAdd(1, "Value 1");
var value = dict.GetOrAdd(1, key => "Default");
```

## Notas

- Los ejemplos muestran claramente las diferencias entre tipos de colecciones
- Se incluyen ejemplos prácticos de cuándo usar cada colección
- Se explican las mejores prácticas y errores comunes
- Se demuestra por qué las colecciones son importantes

## Requisitos

- .NET 6.0 o superior
- Conocimientos básicos de C#

