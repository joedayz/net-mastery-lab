# Entity Framework Core (EF Core) 🚀

## Introducción

**Entity Framework Core (EF Core)** es un ORM (Object-Relational Mapper) ligero, extensible, open-source y multiplataforma para aplicaciones .NET. Proporciona una abstracción de alto nivel sobre la base de datos, permitiendo a los desarrolladores realizar operaciones CRUD sin escribir SQL crudo.

Con EF Core, defines la estructura de tu base de datos usando clases C#, y el framework maneja automáticamente la creación de la base de datos, migraciones y consultas. Soporta múltiples proveedores de base de datos, incluyendo SQL Server, MySQL, PostgreSQL y SQLite.

## 📌 ¿Qué es EF Core?

EF Core es la evolución de Entity Framework, diseñado específicamente para .NET Core y .NET 5+. Es un ORM que:

- ✅ **Mapea objetos a tablas**: Las clases C# se convierten en tablas de base de datos
- ✅ **Traduce LINQ a SQL**: Las consultas LINQ se convierten automáticamente en SQL
- ✅ **Maneja relaciones**: Define y maneja relaciones entre entidades automáticamente
- ✅ **Gestiona cambios**: Rastrea cambios en entidades y los sincroniza con la base de datos
- ✅ **Soporta múltiples bases de datos**: SQL Server, MySQL, PostgreSQL, SQLite, etc.

## 🚀 ¿Por Qué Usar EF Core?

### 1️⃣ No Necesitas Consultas SQL Crudas

```csharp
// ❌ SIN EF Core: SQL crudo
var query = "SELECT * FROM Users WHERE Age > @age";
var users = connection.Query<User>(query, new { age = 18 });

// ✅ CON EF Core: LINQ
var users = context.Users
    .Where(u => u.Age > 18)
    .ToList();
```

**Ventajas:**
- ✅ Consultas type-safe en tiempo de compilación
- ✅ IntelliSense completo
- ✅ Refactoring seguro
- ✅ Menos errores de sintaxis SQL

### 2️⃣ Independiente de la Base de Datos

```csharp
// ✅ EF Core soporta múltiples proveedores
// SQL Server
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// PostgreSQL
services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// SQLite
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));
```

**Ventajas:**
- ✅ Cambiar de base de datos sin cambiar código
- ✅ Desarrollo con SQLite, producción con SQL Server
- ✅ Testing más fácil con bases de datos en memoria

### 3️⃣ Migraciones Automáticas de Esquema

```csharp
// ✅ Crear migración
dotnet ef migrations add InitialCreate

// ✅ Aplicar migración
dotnet ef database update

// ✅ Revertir migración
dotnet ef database update PreviousMigration
```

**Ventajas:**
- ✅ Versionado de esquema de base de datos
- ✅ Migraciones automáticas en desarrollo y producción
- ✅ Historial completo de cambios

### 4️⃣ Productividad Mejorada

```csharp
// ✅ CRUD operations simples
// Create
var user = new User { Name = "Alice", Email = "alice@example.com" };
context.Users.Add(user);
await context.SaveChangesAsync();

// Read
var user = await context.Users.FindAsync(1);
var users = await context.Users.Where(u => u.IsActive).ToListAsync();

// Update
user.Name = "Alice Updated";
await context.SaveChangesAsync();

// Delete
context.Users.Remove(user);
await context.SaveChangesAsync();
```

**Ventajas:**
- ✅ Menos código boilerplate
- ✅ Enfoque en lógica de negocio
- ✅ Operaciones CRUD simplificadas

### 5️⃣ Seguimiento de Cambios Integrado

```csharp
// ✅ EF Core rastrea cambios automáticamente
var user = await context.Users.FindAsync(1);
user.Name = "Updated Name";  // Cambio detectado automáticamente
await context.SaveChangesAsync();  // Solo actualiza campos modificados
```

**Ventajas:**
- ✅ No necesitas rastrear cambios manualmente
- ✅ Optimización automática (solo actualiza campos modificados)
- ✅ Detección de conflictos de concurrencia

### 6️⃣ Carga Lazy y Eager

```csharp
// ✅ Eager Loading: Cargar relaciones inmediatamente
var users = await context.Users
    .Include(u => u.Orders)
    .ThenInclude(o => o.Items)
    .ToListAsync();

// ✅ Lazy Loading: Cargar relaciones bajo demanda
var user = await context.Users.FindAsync(1);
var orders = user.Orders;  // Carga automáticamente cuando se accede
```

**Ventajas:**
- ✅ Control sobre cuándo cargar datos relacionados
- ✅ Optimización de consultas
- ✅ Prevención de problemas N+1

### 7️⃣ Mejor Rendimiento con Consultas Compiladas

```csharp
// ✅ Consultas compiladas para mejor rendimiento
private static readonly Func<AppDbContext, int, Task<User?>> GetUserById =
    EF.CompileAsyncQuery((AppDbContext context, int id) =>
        context.Users.FirstOrDefault(u => u.Id == id));

// Uso
var user = await GetUserById(context, 1);
```

**Ventajas:**
- ✅ Consultas precompiladas
- ✅ Mejor rendimiento en consultas repetitivas
- ✅ Reducción de overhead de compilación

### 8️⃣ Integración Perfecta con ASP.NET Core

```csharp
// ✅ Inyección de dependencias automática
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }
}
```

**Ventajas:**
- ✅ Integración nativa con DI
- ✅ Funciona con MVC, Web API y Blazor
- ✅ Configuración simplificada

## 📌 ¿Cómo Funciona EF Core?

EF Core sigue un flujo de trabajo simple para interactuar con bases de datos:

### 1️⃣ Definir Modelos

```csharp
// ✅ Crear clases que representan tablas
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    // Relación uno a muchos
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    
    // Relación muchos a uno
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
```

### 2️⃣ Configurar DbContext

```csharp
// ✅ DbContext gestiona operaciones de base de datos
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de modelos
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
            entity.HasIndex(e => e.Email).IsUnique();
        });

        // Configurar relaciones
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);
    }
}
```

### 3️⃣ Ejecutar Migraciones

```bash
# ✅ Crear migración
dotnet ef migrations add InitialCreate

# ✅ Aplicar migración a la base de datos
dotnet ef database update

# ✅ Revertir última migración
dotnet ef database update PreviousMigrationName
```

### 4️⃣ Realizar Operaciones CRUD

```csharp
// ✅ Create
var user = new User 
{ 
    Name = "Alice", 
    Email = "alice@example.com",
    CreatedAt = DateTime.UtcNow
};
context.Users.Add(user);
await context.SaveChangesAsync();

// ✅ Read
var user = await context.Users.FindAsync(1);
var users = await context.Users
    .Where(u => u.IsActive)
    .OrderBy(u => u.Name)
    .ToListAsync();

// ✅ Update
var user = await context.Users.FindAsync(1);
user.Name = "Updated Name";
await context.SaveChangesAsync();

// ✅ Delete
var user = await context.Users.FindAsync(1);
context.Users.Remove(user);
await context.SaveChangesAsync();
```

## 🚀 Características Avanzadas de EF Core

### ✅ Consultas LINQ

```csharp
// ✅ Consultar bases de datos usando expresiones C#
var activeUsers = await context.Users
    .Where(u => u.IsActive && u.CreatedAt > DateTime.UtcNow.AddYears(-1))
    .Select(u => new { u.Name, u.Email })
    .ToListAsync();

// ✅ Consultas complejas con joins
var userOrders = await context.Users
    .Join(context.Orders,
        user => user.Id,
        order => order.UserId,
        (user, order) => new { user.Name, order.Total })
    .ToListAsync();
```

### ✅ Filtros de Consulta Globales

```csharp
// ✅ Aplicar condiciones a todas las consultas
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>()
        .HasQueryFilter(u => u.IsActive);  // Filtro global

    // Todas las consultas automáticamente filtran usuarios inactivos
    var users = await context.Users.ToListAsync();  // Solo usuarios activos
}
```

**Ventajas:**
- ✅ Soft delete automático
- ✅ Multi-tenancy simplificado
- ✅ Seguridad a nivel de datos

### ✅ Soporte de Transacciones

```csharp
// ✅ Transacciones para consistencia de datos
using var transaction = await context.Database.BeginTransactionAsync();
try
{
    var user = new User { Name = "Alice" };
    context.Users.Add(user);
    await context.SaveChangesAsync();

    var order = new Order { UserId = user.Id, Total = 100 };
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

**Ventajas:**
- ✅ Consistencia de datos garantizada
- ✅ Operaciones atómicas
- ✅ Rollback automático en caso de error

### ✅ Data Seeding

```csharp
// ✅ Insertar registros por defecto automáticamente
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>().HasData(
        new User { Id = 1, Name = "Admin", Email = "admin@example.com" },
        new User { Id = 2, Name = "User", Email = "user@example.com" }
    );
}

// Aplicar seed data durante migraciones
dotnet ef migrations add SeedInitialData
dotnet ef database update
```

**Ventajas:**
- ✅ Datos iniciales automáticos
- ✅ Datos de prueba consistentes
- ✅ Configuración inicial simplificada

### ✅ Consultas Compiladas

```csharp
// ✅ Optimizar rendimiento con consultas precompiladas
private static readonly Func<AppDbContext, int, Task<User?>> GetUserById =
    EF.CompileAsyncQuery((AppDbContext context, int id) =>
        context.Users.FirstOrDefault(u => u.Id == id));

// Uso en código repetitivo
public async Task<User?> GetUserAsync(int id)
{
    return await GetUserById(_context, id);
}
```

**Ventajas:**
- ✅ Consultas más rápidas
- ✅ Menos overhead de compilación
- ✅ Ideal para consultas repetitivas

## 📊 Comparación: Con vs Sin EF Core

| Aspecto | Sin EF Core | Con EF Core |
|---------|-------------|-------------|
| **Consultas** | SQL crudo | LINQ type-safe |
| **Migraciones** | Scripts SQL manuales | Migraciones automáticas |
| **Cambios de BD** | Cambiar código SQL | Cambiar proveedor |
| **Seguimiento** | Manual | Automático |
| **Relaciones** | JOINs manuales | Configuración automática |
| **Productividad** | Baja | Alta |
| **Type Safety** | No | Sí |

## 💡 Ejemplos Prácticos

### Ejemplo 1: Configuración Básica

```csharp
// Program.cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
```

### Ejemplo 2: Operaciones CRUD Completas

```csharp
public class UserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task<User> CreateUserAsync(string name, string email)
    {
        var user = new User { Name = name, Email = email, CreatedAt = DateTime.UtcNow };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    // Read
    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<List<User>> GetActiveUsersAsync()
    {
        return await _context.Users
            .Where(u => u.IsActive)
            .OrderBy(u => u.Name)
            .ToListAsync();
    }

    // Update
    public async Task<bool> UpdateUserAsync(int id, string name)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        user.Name = name;
        await _context.SaveChangesAsync();
        return true;
    }

    // Delete
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

### Ejemplo 3: Consultas Avanzadas con LINQ

```csharp
// ✅ Consultas complejas con múltiples condiciones
var result = await context.Users
    .Where(u => u.IsActive)
    .Where(u => u.CreatedAt > DateTime.UtcNow.AddMonths(-6))
    .Select(u => new UserDto
    {
        Id = u.Id,
        Name = u.Name,
        Email = u.Email,
        OrderCount = u.Orders.Count,
        TotalSpent = u.Orders.Sum(o => o.Total)
    })
    .OrderByDescending(u => u.TotalSpent)
    .Take(10)
    .ToListAsync();
```

## ⚠️ Consideraciones Importantes

### 1. Rendimiento

```csharp
// ❌ MAL: N+1 Query Problem
var users = await context.Users.ToListAsync();
foreach (var user in users)
{
    var orders = user.Orders.ToList();  // Query adicional por cada usuario
}

// ✅ BIEN: Eager Loading
var users = await context.Users
    .Include(u => u.Orders)
    .ToListAsync();
```

### 2. AsNoTracking para Lecturas

```csharp
// ✅ BIEN: AsNoTracking para consultas de solo lectura
var users = await context.Users
    .AsNoTracking()
    .Where(u => u.IsActive)
    .ToListAsync();
```

### 3. Paginación

```csharp
// ✅ BIEN: Paginación eficiente
var page = 1;
var pageSize = 10;
var users = await context.Users
    .OrderBy(u => u.Name)
    .Skip((page - 1) * pageSize)
    .Take(pageSize)
    .ToListAsync();
```

## 📚 Temas Relacionados

Este repositorio cubre temas avanzados de EF Core:

- **EF Core 9.0 - Nuevas Características**: Bulk Operations, Improved Query Translation, JSON Columns
- **AsNoTracking**: Optimización para consultas de solo lectura
- **Eager, Lazy & Explicit Loading**: Estrategias de carga de datos relacionados
- **Unit of Work & Repository Pattern**: Patrones de diseño con EF Core

## 🎯 Resumen

### ✅ Ventajas de EF Core

- ✅ **No SQL Crudo**: Consultas type-safe con LINQ
- ✅ **Independiente de BD**: Soporta múltiples proveedores
- ✅ **Migraciones Automáticas**: Versionado de esquema simplificado
- ✅ **Alta Productividad**: Menos código boilerplate
- ✅ **Seguimiento Automático**: Detección de cambios integrada
- ✅ **Carga Flexible**: Eager, Lazy y Explicit loading
- ✅ **Consultas Optimizadas**: Compiled queries para mejor rendimiento
- ✅ **Integración ASP.NET Core**: Funciona perfectamente con el framework

### 🚀 Cuándo Usar EF Core

- ✅ Aplicaciones .NET Core/.NET 5+
- ✅ Desarrollo rápido de aplicaciones
- ✅ Necesitas trabajar con múltiples bases de datos
- ✅ Prefieres LINQ sobre SQL crudo
- ✅ Necesitas migraciones automáticas
- ✅ Aplicaciones ASP.NET Core

### ⚠️ Cuándo NO Usar EF Core

- ⚠️ Rendimiento extremadamente crítico (considerar Dapper)
- ⚠️ Consultas SQL muy complejas y específicas
- ⚠️ Aplicaciones legacy que requieren control total sobre SQL

## 📚 Recursos Adicionales

- [Microsoft Docs - Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [EF Core Migrations](https://docs.microsoft.com/ef/core/managing-schemas/migrations/)
- [EF Core Performance](https://docs.microsoft.com/ef/core/performance/)

