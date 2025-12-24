# Mejores Prácticas: Métodos LINQ

## ✅ Reglas de Oro

### 1. Usar Any() en lugar de Count() > 0

```csharp
// ✅ BIEN: Any() es más eficiente
if (users.Any(u => u.IsActive))
{
    // Se detiene en el primer elemento encontrado
}

// ❌ MAL: Count() cuenta todos los elementos
if (users.Count(u => u.IsActive) > 0)
{
    // Menos eficiente - cuenta todos los elementos
}
```

### 2. Usar FirstOrDefault() en lugar de First() cuando Pueda No Haber Elementos

```csharp
// ✅ BIEN: FirstOrDefault() maneja casos vacíos
var user = users.FirstOrDefault(u => u.Id == 123);
if (user != null)
{
    ProcessUser(user);
}

// ❌ MAL: First() lanza excepción si no hay elementos
try
{
    var user = users.First(u => u.Id == 123);
    ProcessUser(user);
}
catch (InvalidOperationException)
{
    // Manejar error
}
```

### 3. Combinar Métodos Eficientemente

```csharp
// ✅ BIEN: Encadenar métodos LINQ eficientemente
var result = users
    .Where(u => u.IsActive)
    .OrderBy(u => u.Name)
    .Select(u => u.Name)
    .Take(10)
    .ToList();

// ❌ MAL: Múltiples iteraciones
var activeUsers = users.Where(u => u.IsActive).ToList();
var sorted = activeUsers.OrderBy(u => u.Name).ToList();
var names = sorted.Select(u => u.Name).ToList();
var result = names.Take(10).ToList();
```

### 4. Usar Select() para Proyección Temprana

```csharp
// ✅ BIEN: Proyección temprana - solo trae campos necesarios
var userNames = users
    .Where(u => u.IsActive)
    .Select(u => u.Name)
    .ToList();

// ❌ MAL: Trae todos los campos y luego selecciona
var activeUsers = users.Where(u => u.IsActive).ToList();
var userNames = activeUsers.Select(u => u.Name).ToList();
```

## ⚠️ Errores Comunes a Evitar

### 1. Usar Count() cuando Solo Necesitas Verificar Existencia

```csharp
// ❌ MAL: Count() cuenta todos los elementos
if (users.Count(u => u.IsActive) > 0)
{
    // Ineficiente
}

// ✅ BIEN: Any() se detiene en el primer elemento
if (users.Any(u => u.IsActive))
{
    // Eficiente
}
```

### 2. No Usar Deferred Execution Correctamente

```csharp
// ❌ MAL: Ejecutar consulta múltiples veces
var query = users.Where(u => u.IsActive);
var count = query.Count(); // Ejecuta consulta
var list = query.ToList(); // Ejecuta consulta de nuevo

// ✅ BIEN: Materializar una vez
var activeUsers = users.Where(u => u.IsActive).ToList();
var count = activeUsers.Count; // Usa propiedad
var list = activeUsers; // Mismo objeto
```

### 3. Usar Single() cuando Puede Haber Múltiples Elementos

```csharp
// ❌ MAL: Single() lanza excepción si hay múltiples elementos
var admin = users.Single(u => u.Role == "Admin"); // Error si hay 2+ admins

// ✅ BIEN: FirstOrDefault() o SingleOrDefault()
var admin = users.FirstOrDefault(u => u.Role == "Admin");
// O si realmente debe haber exactamente uno:
var admin = users.SingleOrDefault(u => u.Role == "Admin");
if (admin == null)
{
    throw new InvalidOperationException("No admin found");
}
```

### 4. No Especificar Comparadores para Strings

```csharp
// ⚠️ MEJORABLE: Comparación case-sensitive
var sorted = users.OrderBy(u => u.Name).ToList();

// ✅ MEJOR: Especificar comparador si es necesario
var sorted = users.OrderBy(u => u.Name, StringComparer.OrdinalIgnoreCase).ToList();
```

## 🎯 Casos de Uso Específicos

### 1. Filtrado y Proyección Combinados

```csharp
// ✅ BIEN: Combinar Where y Select eficientemente
var activeUserNames = users
    .Where(u => u.IsActive && u.Age > 18)
    .Select(u => u.Name)
    .ToList();
```

### 2. Agrupación con Agregaciones

```csharp
// ✅ BIEN: GroupBy con agregaciones
var departmentStats = users
    .GroupBy(u => u.Department)
    .Select(g => new
    {
        Department = g.Key,
        Count = g.Count(),
        AvgSalary = g.Average(u => u.Salary),
        MaxAge = g.Max(u => u.Age)
    })
    .ToList();
```

### 3. Paginación Eficiente

```csharp
// ✅ BIEN: Paginación con Skip y Take
var pageSize = 10;
var pageNumber = 2;
var page = users
    .OrderBy(u => u.Name)
    .Skip(pageNumber * pageSize)
    .Take(pageSize)
    .ToList();
```

### 4. Búsqueda y Verificación

```csharp
// ✅ BIEN: Usar métodos apropiados para búsqueda
var hasActiveUsers = users.Any(u => u.IsActive);
var allAdults = users.All(u => u.Age >= 18);
var containsUser = users.Any(u => u.Id == 123);
```

## 💡 Pro Tips

### 1. Usar SelectMany para Aplanar Colecciones Anidadas

```csharp
// ✅ BIEN: SelectMany para aplanar
var allOrders = customers
    .SelectMany(c => c.Orders)
    .ToList();

// Más eficiente que:
// var allOrders = new List<Order>();
// foreach (var customer in customers)
// {
//     allOrders.AddRange(customer.Orders);
// }
```

### 2. Usar Zip para Combinar Secuencias

```csharp
// ✅ BIEN: Zip para combinar dos secuencias
var numbers = new List<int> { 1, 2, 3 };
var letters = new List<string> { "A", "B", "C" };
var combined = numbers.Zip(letters, (n, l) => $"{n}{l}").ToList();
// ["1A", "2B", "3C"]
```

### 3. Usar Aggregate para Operaciones Personalizadas

```csharp
// ✅ BIEN: Aggregate para operaciones complejas
var csv = items.Aggregate(
    new StringBuilder(),
    (sb, item) => sb.Append($"{item},"),
    sb => sb.ToString().TrimEnd(',')
);
```

### 4. Preferir ToList() sobre ToArray() para Colecciones Mutables

```csharp
// ✅ BIEN: ToList() para colecciones que pueden cambiar
var userList = users.Where(u => u.IsActive).ToList();
userList.Add(newUser); // Funciona

// ⚠️ ToArray() para colecciones fijas
var userArray = users.Where(u => u.IsActive).ToArray();
// userArray es inmutable después de la creación
```

## 📊 Tabla de Decisión: Qué Método Usar

| Escenario | Método Recomendado | Razón |
|-----------|-------------------|-------|
| Verificar existencia | `Any()` | Más eficiente que `Count() > 0` |
| Contar elementos | `Count()` | Propósito específico |
| Obtener primer elemento | `FirstOrDefault()` | Maneja casos vacíos |
| Obtener único elemento | `SingleOrDefault()` | Verifica unicidad |
| Filtrar elementos | `Where()` | Método estándar |
| Transformar elementos | `Select()` | Proyección |
| Aplanar colecciones | `SelectMany()` | Específico para anidados |
| Ordenar | `OrderBy()` / `ThenBy()` | Ordenamiento estándar |
| Agrupar | `GroupBy()` | Agrupación |
| Agregar | `Sum()`, `Average()`, etc. | Cálculos agregados |

## 📚 Recursos Adicionales

- [Microsoft Docs - LINQ](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq/)
- [Microsoft Docs - Standard Query Operators](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq/standard-query-operators-overview)
- [101 LINQ Samples](https://github.com/microsoftarchive/linq-samples)

