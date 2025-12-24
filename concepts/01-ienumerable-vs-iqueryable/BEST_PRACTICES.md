# Mejores Prácticas: IEnumerable vs IQueryable

## ✅ Reglas de Oro

### 1. Mantén IQueryable hasta el final

```csharp
// ❌ MAL: Convierte a IEnumerable demasiado pronto
var employees = dbContext.Employees.ToList()
    .Where(e => e.Age > 25)
    .Take(10);

// ✅ BIEN: Mantén IQueryable hasta el final
var employees = await dbContext.Employees
    .Where(e => e.Age > 25)
    .Take(10)
    .ToListAsync();
```

### 2. Usa métodos asíncronos con IQueryable

```csharp
// ❌ MAL: Bloquea el hilo
var employees = dbContext.Employees.Where(e => e.Age > 25).ToList();

// ✅ BIEN: No bloquea el hilo
var employees = await dbContext.Employees.Where(e => e.Age > 25).ToListAsync();
```

### 3. No mezcles IEnumerable e IQueryable innecesariamente

```csharp
// ❌ MAL: Mezcla innecesaria
IQueryable<Employee> query = dbContext.Employees;
IEnumerable<Employee> filtered = query.Where(e => e.Age > 25); // Convierte a IEnumerable
var result = filtered.Take(10).ToList(); // Pierde optimización

// ✅ BIEN: Mantén el tipo correcto
IQueryable<Employee> query = dbContext.Employees.Where(e => e.Age > 25);
var result = await query.Take(10).ToListAsync();
```

## 🎯 Cuándo Usar Cada Uno

### Usa IEnumerable cuando:

1. **Trabajas con colecciones en memoria**
   ```csharp
   var list = new List<Employee> { /* ... */ };
   var filtered = list.Where(e => e.Age > 25);
   ```

2. **Necesitas métodos que no están en IQueryable**
   ```csharp
   var result = employees
       .Where(e => e.Age > 25)
       .Select(e => new { e.Name, FullName = GetFullName(e) }) // Método C# personalizado
       .ToList();
   ```

3. **Los datos ya están cargados**
   ```csharp
   var allEmployees = await dbContext.Employees.ToListAsync(); // Ya cargado
   var filtered = allEmployees.Where(e => e.Age > 25); // Filtra en memoria
   ```

### Usa IQueryable cuando:

1. **Trabajas con Entity Framework Core**
   ```csharp
   var query = dbContext.Employees.Where(e => e.Age > 25);
   var result = await query.ToListAsync();
   ```

2. **Necesitas optimizar consultas grandes**
   ```csharp
   var topEmployees = await dbContext.Employees
       .Where(e => e.Salary > 100000)
       .OrderByDescending(e => e.Salary)
       .Take(10)
       .ToListAsync(); // Solo trae 10 registros
   ```

3. **Quieres aprovechar índices de base de datos**
   ```csharp
   var employees = await dbContext.Employees
       .Where(e => e.Department == "IT") // Usa índice si existe
       .ToListAsync();
   ```

## ⚠️ Errores Comunes y Cómo Evitarlos

### Error 1: ToList() demasiado pronto

```csharp
// ❌ PROBLEMA: Trae todos los registros a memoria
var all = dbContext.Employees.ToList();
var filtered = all.Where(e => e.Age > 25).Take(10);

// ✅ SOLUCIÓN: Aplaza ToList() hasta el final
var filtered = await dbContext.Employees
    .Where(e => e.Age > 25)
    .Take(10)
    .ToListAsync();
```

### Error 2: Usar métodos que no se traducen a SQL

```csharp
// ❌ PROBLEMA: GetFullName() no se puede traducir a SQL
var result = dbContext.Employees
    .Where(e => GetFullName(e).StartsWith("John"))
    .ToList(); // Error en tiempo de ejecución

// ✅ SOLUCIÓN: Carga primero, luego filtra
var employees = await dbContext.Employees.ToListAsync();
var result = employees
    .Where(e => GetFullName(e).StartsWith("John"))
    .ToList();
```

### Error 3: No usar async/await

```csharp
// ❌ PROBLEMA: Bloquea el hilo
var employees = dbContext.Employees.Where(e => e.Age > 25).ToList();

// ✅ SOLUCIÓN: Usa async/await
var employees = await dbContext.Employees.Where(e => e.Age > 25).ToListAsync();
```

## 🔍 Debugging Tips

### Ver el SQL generado

```csharp
// En desarrollo, habilita el logging de SQL
optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
    .EnableSensitiveDataLogging();
```

### Verificar si es IEnumerable o IQueryable

```csharp
IQueryable<Employee> query = dbContext.Employees;
Console.WriteLine(query.GetType().Name); // Debería mostrar IQueryable

IEnumerable<Employee> enumerable = query.AsEnumerable();
Console.WriteLine(enumerable.GetType().Name); // Debería mostrar IEnumerable
```

## 📊 Comparación Rápida

| Aspecto | IEnumerable | IQueryable |
|---------|-------------|------------|
| **Ejecución** | En memoria (cliente) | En servidor (DB) |
| **Traducción SQL** | No | Sí |
| **Performance (grandes datasets)** | Baja | Alta |
| **Métodos disponibles** | Todos los de LINQ | Solo los traducibles a SQL |
| **Uso recomendado** | Colecciones en memoria | Bases de datos |
| **Deferred Execution** | Sí | Sí |

## 🚀 Optimizaciones Avanzadas

### 1. Proyección temprana

```csharp
// ❌ Trae todas las columnas
var employees = await dbContext.Employees
    .Where(e => e.Age > 25)
    .ToListAsync();

// ✅ Solo trae lo necesario
var employees = await dbContext.Employees
    .Where(e => e.Age > 25)
    .Select(e => new { e.Name, e.Salary })
    .ToListAsync();
```

### 2. Usar AsNoTracking() cuando no necesitas tracking

```csharp
// ✅ Mejor rendimiento si solo vas a leer
var employees = await dbContext.Employees
    .AsNoTracking()
    .Where(e => e.Age > 25)
    .ToListAsync();
```

### 3. Paginación eficiente

```csharp
// ✅ Paginación en base de datos
var page = await dbContext.Employees
    .Where(e => e.Age > 25)
    .OrderBy(e => e.Name)
    .Skip(pageNumber * pageSize)
    .Take(pageSize)
    .ToListAsync();
```

## 📚 Recursos Adicionales

- [Entity Framework Core Performance](https://docs.microsoft.com/ef/core/performance/)
- [LINQ Query Execution](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq/query-execution)
- [IQueryable Interface](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1)

