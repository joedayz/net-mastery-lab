# Mejores Prácticas: Arrays vs ArrayList

## ✅ Reglas de Oro

### 1. Preferir List<T> sobre ArrayList

```csharp
// ❌ MAL: ArrayList (legacy, no type-safe)
ArrayList list = new ArrayList();
list.Add(10);
list.Add("Hello");  // Permite cualquier tipo
int value = (int)list[0];  // Requiere casting

// ✅ BIEN: List<T> (moderno, type-safe)
List<int> list = new List<int>();
list.Add(10);
// list.Add("Hello");  // Error de compilación
int value = list[0];  // Sin casting
```

### 2. Usar Array para Rendimiento Crítico

```csharp
// ✅ BIEN: Array para buffers de tamaño fijo
byte[] buffer = new byte[4096];
int bytesRead = stream.Read(buffer, 0, buffer.Length);
ProcessBuffer(buffer, bytesRead);

// ❌ MAL: List<T> cuando el tamaño es conocido y fijo
List<byte> buffer = new List<byte>(4096);  // Overhead innecesario
```

### 3. Usar List<T> para Datos Dinámicos

```csharp
// ✅ BIEN: List<T> para colecciones que crecen
List<User> users = new List<User>();
users.Add(new User { Name = "Alice" });
users.Add(new User { Name = "Bob" });
users.RemoveAll(u => !u.IsActive);

// ❌ MAL: Array cuando el tamaño es desconocido
User[] users = new User[100];  // ¿Qué pasa si hay más de 100 usuarios?
```

### 4. Considerar Capacidad Inicial para List<T>

```csharp
// ✅ BIEN: Especificar capacidad inicial si la conoces
List<int> numbers = new List<int>(1000);  // Evita redimensionamientos

// ⚠️ MEJORABLE: Sin capacidad inicial
List<int> numbers = new List<int>();  // Se redimensiona varias veces
```

## ⚠️ Errores Comunes a Evitar

### 1. Usar Array cuando Necesitas Tamaño Dinámico

```csharp
// ❌ MAL: Array con tamaño desconocido
int[] numbers = new int[100];
// ... código ...
// numbers[100] = 10;  // IndexOutOfRangeException

// ✅ BIEN: List<T> para tamaño dinámico
List<int> numbers = new List<int>();
numbers.Add(10);  // Se adapta automáticamente
```

### 2. Usar List<T> cuando el Tamaño es Conocido y Fijo

```csharp
// ❌ MAL: List<T> cuando el tamaño es conocido
List<int> scores = new List<int>();
for (int i = 0; i < 10; i++)
{
    scores.Add(GetScore(i));  // Overhead innecesario
}

// ✅ BIEN: Array cuando el tamaño es conocido
int[] scores = new int[10];
for (int i = 0; i < scores.Length; i++)
{
    scores[i] = GetScore(i);
}
```

### 3. Usar ArrayList en Código Nuevo

```csharp
// ❌ MAL: ArrayList (legacy)
ArrayList list = new ArrayList();
list.Add(10);
list.Add("Hello");

// ✅ BIEN: List<T> (moderno)
List<int> list = new List<int>();
list.Add(10);
```

## 🎯 Casos de Uso Específicos

### 1. Array para Buffers de Tamaño Fijo

```csharp
// ✅ BIEN: Buffer de tamaño fijo
public class StreamProcessor
{
    private readonly byte[] _buffer = new byte[8192];  // 8KB buffer fijo
    
    public void ProcessStream(Stream stream)
    {
        int bytesRead;
        while ((bytesRead = stream.Read(_buffer, 0, _buffer.Length)) > 0)
        {
            ProcessChunk(_buffer, bytesRead);
        }
    }
}
```

### 2. List<T> para Colecciones Dinámicas

```csharp
// ✅ BIEN: Colección que crece dinámicamente
public class OrderService
{
    private readonly List<Order> _orders = new List<Order>();
    
    public void AddOrder(Order order)
    {
        _orders.Add(order);  // Se adapta automáticamente
    }
    
    public void RemoveCancelledOrders()
    {
        _orders.RemoveAll(o => o.Status == OrderStatus.Cancelled);
    }
}
```

### 3. Conversión Entre Array y List<T>

```csharp
// ✅ BIEN: Convertir cuando sea necesario
int[] array = { 1, 2, 3, 4, 5 };
List<int> list = array.ToList();  // Para operaciones dinámicas

List<int> list = new List<int> { 1, 2, 3, 4, 5 };
int[] array = list.ToArray();  // Para tamaño fijo
```

## 💡 Pro Tips

### 1. Usar Array.Sort() para Ordenar Arrays

```csharp
// ✅ BIEN: Ordenar array in-place
int[] numbers = { 5, 2, 8, 1, 9 };
Array.Sort(numbers);  // Ordena el array original
```

### 2. Usar List<T>.Capacity para Optimizar

```csharp
// ✅ BIEN: Establecer capacidad inicial
List<int> numbers = new List<int>(1000);
// Evita múltiples redimensionamientos
```

### 3. Usar Span<T> para Slices de Arrays

```csharp
// ✅ BIEN: Span<T> para slices eficientes
int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Span<int> slice = array.AsSpan(2, 5);  // Elementos 2-6
```

## 📊 Tabla de Decisión

| Escenario | Recomendación | Razón |
|-----------|---------------|-------|
| Tamaño conocido, rendimiento crítico | Array | Más rápido, menos memoria |
| Tamaño desconocido | List<T> | Se adapta dinámicamente |
| Modificaciones frecuentes | List<T> | Fácil agregar/remover |
| Operaciones matemáticas | Array | Acceso directo más rápido |
| Type-safety importante | List<T> | Type-safe con generics |
| Buffer de tamaño fijo | Array | Sin overhead dinámico |
| Colección que crece | List<T> | Redimensionamiento automático |

## 📚 Recursos Adicionales

- [Microsoft Docs - Arrays](https://docs.microsoft.com/dotnet/csharp/programming-guide/arrays/)
- [Microsoft Docs - List<T>](https://docs.microsoft.com/dotnet/api/system.collections.generic.list-1)
- [Microsoft Docs - Collections](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/collections)

