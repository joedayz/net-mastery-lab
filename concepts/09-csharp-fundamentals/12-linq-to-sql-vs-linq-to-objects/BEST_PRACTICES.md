# Mejores Prácticas: LINQ to SQL vs LINQ to Objects

## ✅ Reglas de Oro

### 1. Mantener IQueryable hasta el Final

```csharp
// ✅ BIEN: Mantener IQueryable para optimización
var users = dbContext.Users
    .Where(u => u.IsActive)
    .OrderBy(u => u.Name)
    .Take(100)
    .ToList(); // Ejecuta consulta optimizada en DB

// ❌ MAL: Convertir a IEnumerable demasiado pronto
var users = dbContext.Users.ToList() // Trae TODOS
    .Where(u => u.IsActive)
    .Take(100); // Filtra en memoria
```

### 2. Usar LINQ to SQL para Bases de Datos

```csharp
// ✅ BIEN: LINQ to SQL para bases de datos
public async Task<List<UserDto>> GetActiveUsersAsync()
{
    return await _context.Users
        .Where(u => u.IsActive)
        .Select(u => new UserDto { Name = u.Name })
        .ToListAsync();
}

// ❌ MAL: Cargar todos y filtrar en memoria
public async Task<List<UserDto>> GetActiveUsersAsync()
{
    var allUsers = await _context.Users.ToListAsync(); // Trae todos
    return allUsers
        .Where(u => u.IsActive) // Filtra en memoria
        .Select(u => new UserDto { Name = u.Name })
        .ToList();
}
```

### 3. Usar LINQ to Objects para Datos en Memoria

```csharp
// ✅ BIEN: LINQ to Objects para datos en memoria
public List<UserDto> ProcessUsers(List<User> users)
{
    return users
        .Where(u => u.IsActive)
        .Select(u => new UserDto { Name = u.Name })
        .ToList();
}

// ✅ BIEN: Usar métodos C# personalizados
public List<User> FilterUsers(List<User> users)
{
    return users
        .Where(u => IsValidUser(u)) // Método personalizado
        .ToList();
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Convertir IQueryable a IEnumerable Demasiado Pronto

```csharp
// ❌ MAL: Trae todos los registros a memoria
var users = dbContext.Users.ToList()
    .Where(u => u.Age > 25)
    .Take(10);

// ✅ BIEN: Filtra en la base de datos
var users = dbContext.Users
    .Where(u => u.Age > 25)
    .Take(10)
    .ToList();
```

### 2. Usar Métodos No Traducibles con LINQ to SQL

```csharp
// ❌ MAL: Método personalizado no traducible
var users = dbContext.Users
    .Where(u => IsValidUser(u)); // Error de compilación

// ✅ BIEN: Usar expresiones traducibles
var users = dbContext.Users
    .Where(u => u.IsActive && u.Age > 18);

// ✅ ALTERNATIVA: Convertir a IEnumerable primero
var users = dbContext.Users
    .AsEnumerable()
    .Where(u => IsValidUser(u));
```

### 3. Mezclar LINQ to SQL y LINQ to Objects Innecesariamente

```csharp
// ❌ MAL: Mezcla innecesaria
var users = await dbContext.Users.ToListAsync(); // LINQ to SQL
var filtered = users.Where(u => u.IsActive); // LINQ to Objects

// ✅ BIEN: Usar LINQ to SQL directamente
var filtered = await dbContext.Users
    .Where(u => u.IsActive)
    .ToListAsync();
```

## 🎯 Casos de Uso Específicos

### 1. Consultas de Base de Datos (LINQ to SQL)

```csharp
// ✅ BIEN: LINQ to SQL para consultas de DB
public class UserRepository
{
    private readonly ApplicationDbContext _context;

    public async Task<List<User>> GetActiveUsersAsync()
    {
        return await _context.Users
            .Where(u => u.IsActive)
            .OrderBy(u => u.Name)
            .ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}
```

### 2. Procesamiento en Memoria (LINQ to Objects)

```csharp
// ✅ BIEN: LINQ to Objects para procesamiento en memoria
public class UserProcessor
{
    public List<UserDto> ProcessUsers(List<User> users)
    {
        return users
            .Where(u => u.IsActive)
            .Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            })
            .OrderBy(u => u.Name)
            .ToList();
    }

    public Dictionary<string, List<User>> GroupByDepartment(List<User> users)
    {
        return users
            .GroupBy(u => u.Department)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}
```

### 3. Combinación Estratégica

```csharp
// ✅ BIEN: Combinar ambos cuando sea necesario
public async Task<List<UserDto>> GetProcessedUsersAsync()
{
    // LINQ to SQL: Traer datos de DB
    var users = await _context.Users
        .Where(u => u.IsActive)
        .Select(u => new { u.Id, u.Name, u.Email, u.Department })
        .ToListAsync();

    // LINQ to Objects: Procesamiento complejo en memoria
    return users
        .Where(u => IsValidUser(u)) // Método personalizado
        .Select(u => new UserDto
        {
            Id = u.Id,
            Name = FormatName(u.Name), // Método personalizado
            Email = u.Email
        })
        .ToList();
}
```

## 💡 Pro Tips

### 1. Usar Proyección Temprana

```csharp
// ✅ BIEN: Proyección temprana - solo trae campos necesarios
var users = await _context.Users
    .Where(u => u.IsActive)
    .Select(u => new UserDto { Name = u.Name, Email = u.Email })
    .ToListAsync();

// ❌ MAL: Trae todas las columnas
var users = await _context.Users
    .Where(u => u.IsActive)
    .ToListAsync();
var dtos = users.Select(u => new UserDto { Name = u.Name, Email = u.Email });
```

### 2. Usar AsNoTracking() para Solo Lectura

```csharp
// ✅ BIEN: AsNoTracking para solo lectura
var users = await _context.Users
    .AsNoTracking()
    .Where(u => u.IsActive)
    .ToListAsync();

// Mejor rendimiento si no necesitas tracking
```

### 3. Paginación Eficiente

```csharp
// ✅ BIEN: Paginación en base de datos
var page = await _context.Users
    .Where(u => u.IsActive)
    .OrderBy(u => u.Name)
    .Skip(pageNumber * pageSize)
    .Take(pageSize)
    .ToListAsync();

// Solo trae los registros de la página solicitada
```

### 4. Usar AsEnumerable() Estratégicamente

```csharp
// ✅ BIEN: Usar AsEnumerable() cuando necesitas métodos C#
var users = await _context.Users
    .Where(u => u.IsActive)
    .AsEnumerable() // Convertir a IEnumerable
    .Where(u => ComplexValidation(u)) // Método C# personalizado
    .ToList();
```

## 📊 Tabla de Decisión: Cuándo Usar Cada Uno

| Escenario | Tecnología Recomendada | Razón |
|-----------|------------------------|-------|
| Consultas de base de datos | LINQ to SQL (IQueryable) | Optimización en servidor |
| Datos ya en memoria | LINQ to Objects (IEnumerable) | Sin overhead de red |
| Grandes datasets | LINQ to SQL | Solo trae lo necesario |
| Pequeños datasets | LINQ to Objects | Más rápido sin red |
| Métodos C# personalizados | LINQ to Objects | Flexibilidad completa |
| Operaciones CRUD | LINQ to SQL | Soporte nativo |
| Filtrado/ordenamiento rápido | LINQ to Objects | Ejecución inmediata |

## 📚 Recursos Adicionales

- [Microsoft Docs - LINQ to SQL](https://docs.microsoft.com/dotnet/framework/data/adonet/sql/linq/)
- [Microsoft Docs - LINQ to Objects](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq/linq-to-objects)
- [Microsoft Docs - IQueryable vs IEnumerable](https://docs.microsoft.com/dotnet/api/system.linq.iqueryable-1)
- [Entity Framework Core - Querying](https://docs.microsoft.com/ef/core/querying/)

