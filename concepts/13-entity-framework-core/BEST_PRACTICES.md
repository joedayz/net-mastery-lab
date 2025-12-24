# Mejores Prácticas: Entity Framework Core

## ✅ Reglas de Oro

### 1. Usar DbContext Correctamente

```csharp
// ✅ BIEN: Inyectar DbContext en servicios
public class UserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }
}

// ❌ MAL: Crear DbContext manualmente
public class UserService
{
    public void DoSomething()
    {
        using var context = new AppDbContext();  // No usar DI
    }
}
```

### 2. Usar AsNoTracking para Consultas de Solo Lectura

```csharp
// ✅ BIEN: AsNoTracking para reportes y lecturas
var users = await context.Users
    .AsNoTracking()
    .Where(u => u.IsActive)
    .ToListAsync();

// ❌ MAL: Tracking innecesario para solo lectura
var users = await context.Users
    .Where(u => u.IsActive)
    .ToListAsync();
```

### 3. Evitar N+1 Query Problem

```csharp
// ❌ MAL: N+1 Query Problem
var users = await context.Users.ToListAsync();
foreach (var user in users)
{
    var orders = user.Orders.ToList();  // Query adicional por cada usuario
}

// ✅ BIEN: Eager Loading con Include
var users = await context.Users
    .Include(u => u.Orders)
    .ToListAsync();
```

### 4. Usar Paginación para Grandes Conjuntos de Datos

```csharp
// ✅ BIEN: Paginación eficiente
var page = 1;
var pageSize = 10;
var users = await context.Users
    .OrderBy(u => u.Name)
    .Skip((page - 1) * pageSize)
    .Take(pageSize)
    .ToListAsync();

// ❌ MAL: Cargar todos los registros
var users = await context.Users.ToListAsync();  // Puede ser millones
```

### 5. Usar Transacciones para Operaciones Múltiples

```csharp
// ✅ BIEN: Transacciones para consistencia
using var transaction = await context.Database.BeginTransactionAsync();
try
{
    var user = new User { Name = "Alice" };
    context.Users.Add(user);
    await context.SaveChangesAsync();

    var order = new Order { UserId = user.Id };
    context.Orders.Add(order);
    await context.SaveChangesAsync();

    await transaction.CommitAsync();
}
catch
{
    await transaction.RollbackAsync();
    throw;
}
```

## ⚠️ Errores Comunes a Evitar

### 1. No Disposed DbContext

```csharp
// ❌ MAL: DbContext no disposed
public class UserService
{
    private AppDbContext _context = new AppDbContext();  // Nunca se dispose
}

// ✅ BIEN: DbContext inyectado y gestionado por DI
public class UserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }
}
```

### 2. Cargar Demasiados Datos

```csharp
// ❌ MAL: Cargar todos los datos relacionados
var users = await context.Users
    .Include(u => u.Orders)
        .ThenInclude(o => o.Items)
            .ThenInclude(i => i.Product)
                .ThenInclude(p => p.Category)
    .ToListAsync();  // Demasiados datos cargados

// ✅ BIEN: Cargar solo lo necesario
var users = await context.Users
    .Include(u => u.Orders)
    .Select(u => new UserDto
    {
        Id = u.Id,
        Name = u.Name,
        OrderCount = u.Orders.Count
    })
    .ToListAsync();
```

### 3. No Usar Async/Await

```csharp
// ❌ MAL: Métodos síncronos bloquean el hilo
var users = context.Users.ToList();

// ✅ BIEN: Métodos asíncronos
var users = await context.Users.ToListAsync();
```

### 4. Consultas en Loops

```csharp
// ❌ MAL: Consultas dentro de loops
foreach (var userId in userIds)
{
    var user = await context.Users.FindAsync(userId);  // Múltiples queries
}

// ✅ BIEN: Consulta única con filtro
var users = await context.Users
    .Where(u => userIds.Contains(u.Id))
    .ToListAsync();
```

## 🎯 Casos de Uso Específicos

### 1. Configuración de DbContext

```csharp
// ✅ BIEN: Configuración en Program.cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
```

### 2. Operaciones CRUD Completas

```csharp
// ✅ BIEN: Servicio completo con CRUD
public class UserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUserAsync(string name, string email)
    {
        var user = new User { Name = name, Email = email };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<bool> UpdateUserAsync(int id, string name)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        user.Name = name;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
```

### 3. Consultas Optimizadas

```csharp
// ✅ BIEN: Consultas optimizadas con proyección
var result = await context.Users
    .Where(u => u.IsActive)
    .Select(u => new UserSummaryDto
    {
        Id = u.Id,
        Name = u.Name,
        OrderCount = u.Orders.Count,
        TotalSpent = u.Orders.Sum(o => o.Total)
    })
    .OrderByDescending(u => u.TotalSpent)
    .Take(10)
    .ToListAsync();
```

## 💡 Pro Tips

### 1. Usar Compiled Queries para Consultas Repetitivas

```csharp
// ✅ BIEN: Compiled query para mejor rendimiento
private static readonly Func<AppDbContext, int, Task<User?>> GetUserById =
    EF.CompileAsyncQuery((AppDbContext context, int id) =>
        context.Users.FirstOrDefault(u => u.Id == id));

public async Task<User?> GetUserAsync(int id)
{
    return await GetUserById(_context, id);
}
```

### 2. Usar Global Query Filters

```csharp
// ✅ BIEN: Filtro global para soft delete
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>()
        .HasQueryFilter(u => u.IsActive);
}
```

### 3. Configurar Relaciones Correctamente

```csharp
// ✅ BIEN: Configuración explícita de relaciones
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Order>()
        .HasOne(o => o.User)
        .WithMany(u => u.Orders)
        .HasForeignKey(o => o.UserId)
        .OnDelete(DeleteBehavior.Cascade);
}
```

### 4. Usar Data Seeding para Datos Iniciales

```csharp
// ✅ BIEN: Seed data en migraciones
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>().HasData(
        new User { Id = 1, Name = "Admin", Email = "admin@example.com" }
    );
}
```

## 📊 Tabla de Decisión

| Escenario | Recomendación | Razón |
|-----------|---------------|-------|
| Consultas de solo lectura | AsNoTracking | Mejor rendimiento |
| Datos relacionados necesarios | Eager Loading | Evita N+1 |
| Datos relacionados opcionales | Lazy/Explicit Loading | Ahorra recursos |
| Grandes conjuntos de datos | Paginación | Mejor rendimiento |
| Operaciones múltiples | Transacciones | Consistencia |
| Consultas repetitivas | Compiled Queries | Mejor rendimiento |
| Soft delete | Global Query Filters | Automático |
| Datos iniciales | Data Seeding | Automático |

## 📚 Recursos Adicionales

- [Microsoft Docs - Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [EF Core Migrations](https://docs.microsoft.com/ef/core/managing-schemas/migrations/)
- [EF Core Performance](https://docs.microsoft.com/ef/core/performance/)

