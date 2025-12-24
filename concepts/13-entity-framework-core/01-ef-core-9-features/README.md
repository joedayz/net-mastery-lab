# Entity Framework Core 9.0 - Nuevas Características 🚀

## Introducción

**Entity Framework Core 9.0** introduce características poderosas que mejoran significativamente el rendimiento, la flexibilidad y la simplicidad del desarrollo. Estas mejoras están claramente enfocadas en las necesidades modernas de los desarrolladores: rendimiento, flexibilidad y simplicidad.

## 🔄 Bulk Operations (Native Support)

EF Core 9.0 ahora incluye soporte nativo para actualizaciones y eliminaciones masivas. Ya no necesitas bibliotecas de terceros o lógica personalizada compleja — gestionar grandes conjuntos de datos es ahora más rápido, simple y eficiente.

### ¿Qué son las Bulk Operations?

Las operaciones masivas permiten actualizar o eliminar múltiples registros en una sola operación de base de datos, en lugar de hacerlo uno por uno. Esto mejora dramáticamente el rendimiento cuando trabajas con grandes volúmenes de datos.

### BulkDeleteAsync - Eliminación Masiva

```csharp
// ✅ BIEN: Eliminación masiva nativa en EF Core 9.0
var entities = await dbContext.Users
    .Where(u => u.IsInactive)
    .ToListAsync();

await dbContext.BulkDeleteAsync(entities);
```

**Ventajas:**
- ✅ **Rendimiento Mejorado**: Una sola operación SQL en lugar de múltiples
- ✅ **Sin Bibliotecas Externas**: Soporte nativo, sin dependencias adicionales
- ✅ **Código Más Simple**: No necesitas lógica personalizada compleja
- ✅ **Transaccional**: Las operaciones son atómicas

### BulkUpdateAsync - Actualización Masiva

```csharp
// ✅ BIEN: Actualización masiva nativa en EF Core 9.0
var users = await dbContext.Users
    .Where(u => u.IsInactive)
    .ToListAsync();

// Actualizar múltiples propiedades
foreach (var user in users)
{
    user.IsActive = true;
    user.ActivatedAt = DateTime.UtcNow;
}

await dbContext.BulkUpdateAsync(users);
```

**Ventajas:**
- ✅ **Actualización Eficiente**: Actualiza múltiples registros en una sola operación
- ✅ **Menos Round-trips**: Reduce las idas y venidas a la base de datos
- ✅ **Mejor Rendimiento**: Especialmente útil para grandes volúmenes de datos

### Comparación: Antes vs Después

#### Antes de EF Core 9.0

```csharp
// ❌ ANTES: Necesitabas bibliotecas externas o lógica personalizada
// Opción 1: Usar biblioteca externa (ej: Z.EntityFramework.Extensions)
await context.Users
    .Where(u => u.IsInactive)
    .DeleteAsync();  // Requiere biblioteca externa

// Opción 2: Lógica personalizada compleja
var users = await context.Users
    .Where(u => u.IsInactive)
    .ToListAsync();

foreach (var user in users)
{
    context.Users.Remove(user);  // Múltiples operaciones
}
await context.SaveChangesAsync();  // Múltiples queries SQL
```

**Problemas:**
- ❌ Dependencias externas adicionales
- ❌ Múltiples queries SQL (una por cada entidad)
- ❌ Código más complejo y propenso a errores
- ❌ Rendimiento inferior para grandes volúmenes

#### Después de EF Core 9.0

```csharp
// ✅ DESPUÉS: Soporte nativo simple y eficiente
var entities = await dbContext.Users
    .Where(u => u.IsInactive)
    .ToListAsync();

await dbContext.BulkDeleteAsync(entities);  // Una sola operación SQL
```

**Beneficios:**
- ✅ Sin dependencias externas
- ✅ Una sola query SQL optimizada
- ✅ Código más simple y limpio
- ✅ Rendimiento superior

### Ejemplos Prácticos

#### Ejemplo 1: Eliminar Registros Antiguos

```csharp
// ✅ BIEN: Eliminar registros antiguos de forma eficiente
var oldLogs = await dbContext.AuditLogs
    .Where(log => log.CreatedAt < DateTime.UtcNow.AddYears(-1))
    .ToListAsync();

await dbContext.BulkDeleteAsync(oldLogs);
```

#### Ejemplo 2: Actualizar Estado Masivo

```csharp
// ✅ BIEN: Actualizar estado de múltiples órdenes
var pendingOrders = await dbContext.Orders
    .Where(o => o.Status == OrderStatus.Pending && o.CreatedAt < DateTime.UtcNow.AddDays(-30))
    .ToListAsync();

foreach (var order in pendingOrders)
{
    order.Status = OrderStatus.Cancelled;
    order.CancelledAt = DateTime.UtcNow;
}

await dbContext.BulkUpdateAsync(pendingOrders);
```

## ⚡ Improved Query Translation

La traducción de LINQ a SQL ha sido significativamente mejorada, permitiendo consultas más complejas y tiempos de ejecución más rápidos. Los desarrolladores ahora pueden escribir consultas expresivas sin sacrificar rendimiento.

### ¿Qué es Query Translation?

Query Translation es el proceso por el cual EF Core convierte tus consultas LINQ en SQL que la base de datos puede ejecutar. EF Core 9.0 mejora este proceso para generar SQL más eficiente y soportar más patrones de consulta.

### Mejoras en la Traducción

```csharp
// ✅ BIEN: Consultas complejas que ahora se traducen mejor
var result = await dbContext.Users
    .Where(u => u.IsActive)
    .GroupBy(u => u.Department)
    .Select(g => new
    {
        Department = g.Key,
        Count = g.Count(),
        AverageAge = g.Average(u => u.Age),
        MaxSalary = g.Max(u => u.Salary)
    })
    .Where(x => x.Count > 10)
    .OrderByDescending(x => x.AverageAge)
    .ToListAsync();
```

**Mejoras Clave:**
- ✅ **Consultas Más Complejas**: Soporta patrones más avanzados
- ✅ **SQL Optimizado**: Genera SQL más eficiente
- ✅ **Mejor Rendimiento**: Tiempos de ejecución más rápidos
- ✅ **Más Expresivo**: Puedes escribir consultas más complejas sin perder rendimiento

### Ejemplos de Mejoras

#### Ejemplo 1: Consultas con Subconsultas

```csharp
// ✅ BIEN: Subconsultas mejoradas en EF Core 9.0
var usersWithRecentOrders = await dbContext.Users
    .Where(u => dbContext.Orders
        .Where(o => o.UserId == u.Id && o.CreatedAt > DateTime.UtcNow.AddDays(-30))
        .Any())
    .ToListAsync();
```

#### Ejemplo 2: Consultas con Agregaciones Complejas

```csharp
// ✅ BIEN: Agregaciones complejas mejor traducidas
var departmentStats = await dbContext.Users
    .GroupBy(u => u.Department)
    .Select(g => new
    {
        Department = g.Key,
        TotalUsers = g.Count(),
        ActiveUsers = g.Count(u => u.IsActive),
        AverageSalary = g.Average(u => u.Salary),
        TotalOrders = g.SelectMany(u => u.Orders).Count()
    })
    .ToListAsync();
```

## 🧩 JSON Column Support

EF Core 9.0 ofrece soporte completo para consultar y actualizar columnas JSON en bases de datos relacionales. Ideal para aplicaciones que trabajan con datos semi-estructurados — proporcionando flexibilidad y poder en un solo paquete.

### ¿Qué es JSON Column Support?

JSON Column Support permite almacenar y consultar datos JSON directamente en columnas de bases de datos relacionales, combinando la estructura de bases de datos relacionales con la flexibilidad de JSON.

### Configuración de Columnas JSON

```csharp
// ✅ BIEN: Configurar columna JSON en EF Core 9.0
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    // Propiedad JSON
    public UserPreferences Preferences { get; set; } = new();
}

public class UserPreferences
{
    public string Theme { get; set; } = "light";
    public string Language { get; set; } = "en";
    public bool NotificationsEnabled { get; set; } = true;
}

// Configuración en DbContext
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>()
        .OwnsOne(u => u.Preferences, pref =>
        {
            pref.ToJson();  // Marca como columna JSON
        });
}
```

### Consultar Columnas JSON

```csharp
// ✅ BIEN: Consultar datos dentro de columnas JSON
var darkThemeUsers = await dbContext.Users
    .Where(u => u.Preferences.Theme == "dark")
    .ToListAsync();

var usersWithNotifications = await dbContext.Users
    .Where(u => u.Preferences.NotificationsEnabled == true)
    .ToListAsync();
```

**Ventajas:**
- ✅ **Flexibilidad**: Almacena datos semi-estructurados sin esquema rígido
- ✅ **Consultas Type-Safe**: Consultas LINQ type-safe sobre datos JSON
- ✅ **Sin Cambios de Esquema**: Agrega campos JSON sin migraciones complejas
- ✅ **Ideal para Configuraciones**: Perfecto para preferencias de usuario, configuraciones, etc.

### Actualizar Columnas JSON

```csharp
// ✅ BIEN: Actualizar datos JSON
var user = await dbContext.Users.FindAsync(userId);
user.Preferences.Theme = "dark";
user.Preferences.Language = "es";
await dbContext.SaveChangesAsync();
```

### Ejemplos Prácticos

#### Ejemplo 1: Preferencias de Usuario

```csharp
// ✅ BIEN: Almacenar preferencias de usuario como JSON
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public UserSettings Settings { get; set; } = new();
}

public class UserSettings
{
    public string Theme { get; set; } = "light";
    public string Language { get; set; } = "en";
    public Dictionary<string, bool> FeatureFlags { get; set; } = new();
}

// Consultar usuarios con tema oscuro
var darkThemeUsers = await dbContext.Users
    .Where(u => u.Settings.Theme == "dark")
    .ToListAsync();
```

#### Ejemplo 2: Metadatos Dinámicos

```csharp
// ✅ BIEN: Almacenar metadatos dinámicos como JSON
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductMetadata Metadata { get; set; } = new();
}

public class ProductMetadata
{
    public Dictionary<string, string> Tags { get; set; } = new();
    public List<string> Categories { get; set; } = new();
    public Dictionary<string, object> CustomAttributes { get; set; } = new();
}
```

## 📊 Comparación: EF Core 8.0 vs EF Core 9.0

| Característica | EF Core 8.0 | EF Core 9.0 |
|----------------|-------------|-------------|
| **Bulk Operations** | ❌ Requiere bibliotecas externas | ✅ Soporte nativo |
| **Query Translation** | ⚠️ Limitado | ✅ Significativamente mejorado |
| **JSON Columns** | ⚠️ Soporte básico | ✅ Soporte completo |
| **Rendimiento** | ✅ Bueno | ✅ Mejorado |
| **Simplicidad** | ⚠️ Requiere trabajo adicional | ✅ Más simple |

## 🎯 Cuándo Usar Cada Característica

### Usa Bulk Operations cuando:
- ✅ Necesitas eliminar o actualizar grandes volúmenes de datos
- ✅ El rendimiento es crítico
- ✅ Quieres evitar dependencias externas
- ✅ Necesitas operaciones transaccionales masivas

### Usa Improved Query Translation cuando:
- ✅ Tienes consultas complejas con múltiples joins
- ✅ Necesitas agregaciones avanzadas
- ✅ Quieres mejor rendimiento sin cambiar código
- ✅ Trabajas con consultas que antes no se traducían bien

### Usa JSON Column Support cuando:
- ✅ Tienes datos semi-estructurados
- ✅ Necesitas flexibilidad en el esquema
- ✅ Trabajas con configuraciones o preferencias
- ✅ Quieres evitar múltiples tablas relacionadas para datos simples

## 💡 Mejores Prácticas

### 1. Usar Bulk Operations para Grandes Volúmenes

```csharp
// ✅ BIEN: Bulk operations para grandes volúmenes
var oldRecords = await dbContext.AuditLogs
    .Where(log => log.CreatedAt < DateTime.UtcNow.AddYears(-1))
    .ToListAsync();

await dbContext.BulkDeleteAsync(oldRecords);  // Eficiente para miles de registros
```

### 2. Aprovechar Query Translation Mejorado

```csharp
// ✅ BIEN: Consultas complejas que ahora funcionan mejor
var complexQuery = await dbContext.Users
    .Where(u => u.IsActive)
    .GroupBy(u => u.Department)
    .Select(g => new DepartmentStats
    {
        Department = g.Key,
        UserCount = g.Count(),
        AverageSalary = g.Average(u => u.Salary)
    })
    .Where(s => s.UserCount > 10)
    .ToListAsync();
```

### 3. Usar JSON Columns para Datos Flexibles

```csharp
// ✅ BIEN: JSON columns para datos semi-estructurados
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public UserPreferences Preferences { get; set; } = new();  // JSON column
}
```

## ⚠️ Consideraciones Importantes

### 1. Bulk Operations y Change Tracking

```csharp
// ⚠️ IMPORTANTE: Bulk operations no usan change tracking
// Las entidades no se rastrean automáticamente
var entities = await dbContext.Users
    .Where(u => u.IsInactive)
    .ToListAsync();

await dbContext.BulkDeleteAsync(entities);  // No afecta el change tracker
```

### 2. JSON Columns y Migraciones

```csharp
// ⚠️ IMPORTANTE: JSON columns requieren configuración explícita
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>()
        .OwnsOne(u => u.Preferences, pref =>
        {
            pref.ToJson();  // Debe configurarse explícitamente
        });
}
```

### 3. Compatibilidad de Base de Datos

```csharp
// ⚠️ IMPORTANTE: No todas las bases de datos soportan todas las características
// SQL Server: ✅ Soporta todas las características
// PostgreSQL: ✅ Soporta JSON columns nativamente
// SQLite: ⚠️ Soporte limitado para algunas características
```

## 📚 Relación con Otros Conceptos

Este tema está relacionado con:
- **Entity Framework Core**: `concepts/13-entity-framework-core/` (conceptos generales)
- **AsNoTracking**: `concepts/05-performance-optimization/01-asnotracking-ef-core/` (optimización)
- **LINQ to SQL**: `concepts/09-csharp-fundamentals/12-linq-to-sql-vs-linq-to-objects/` (query translation)

## 🎯 Resumen

### ✅ Nuevas Características de EF Core 9.0

1. **Bulk Operations (Native Support)**
   - ✅ Eliminación y actualización masiva nativa
   - ✅ Sin dependencias externas
   - ✅ Mejor rendimiento para grandes volúmenes
   - ✅ Código más simple

2. **Improved Query Translation**
   - ✅ Consultas más complejas soportadas
   - ✅ SQL más optimizado
   - ✅ Mejor rendimiento
   - ✅ Más expresivo

3. **JSON Column Support**
   - ✅ Soporte completo para columnas JSON
   - ✅ Consultas type-safe sobre JSON
   - ✅ Ideal para datos semi-estructurados
   - ✅ Flexibilidad sin sacrificar estructura

### 🚀 Beneficios Generales

Con estas mejoras, EF Core 9.0 está claramente enfocado en las necesidades modernas de los desarrolladores:
- ⚡ **Rendimiento**: Operaciones más rápidas y eficientes
- 🧩 **Flexibilidad**: Soporte para datos estructurados y semi-estructurados
- 💡 **Simplicidad**: Menos código, menos dependencias, más productividad

## 📚 Recursos Adicionales

- [Microsoft Docs - EF Core 9.0 What's New](https://learn.microsoft.com/ef/core/what-is-new/ef-core-9.0/whatsnew)
- [Microsoft Docs - Bulk Operations](https://learn.microsoft.com/ef/core/what-is-new/ef-core-9.0/whatsnew#bulk-updates-and-deletes)
- [Microsoft Docs - JSON Columns](https://learn.microsoft.com/ef/core/what-is-new/ef-core-9.0/whatsnew#json-columns)

