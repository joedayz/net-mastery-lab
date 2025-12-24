# Mejores Prácticas: EF Core 9.0 - Nuevas Características

## ✅ Reglas de Oro

### 1. Usar Bulk Operations para Grandes Volúmenes

```csharp
// ✅ BIEN: Bulk operations para grandes volúmenes
var oldRecords = await dbContext.AuditLogs
    .Where(log => log.CreatedAt < DateTime.UtcNow.AddYears(-1))
    .ToListAsync();

await dbContext.BulkDeleteAsync(oldRecords);  // Eficiente para miles de registros

// ❌ MAL: Operaciones individuales para grandes volúmenes
var oldRecords = await dbContext.AuditLogs
    .Where(log => log.CreatedAt < DateTime.UtcNow.AddYears(-1))
    .ToListAsync();

foreach (var record in oldRecords)
{
    dbContext.AuditLogs.Remove(record);  // Múltiples queries SQL
}
await dbContext.SaveChangesAsync();
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

// Configuración
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>()
        .OwnsOne(u => u.Preferences, pref =>
        {
            pref.ToJson();  // Marca como columna JSON
        });
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

## 🎯 Casos de Uso Específicos

### 1. Bulk Delete para Limpieza de Datos

```csharp
// ✅ BIEN: Limpiar registros antiguos eficientemente
var oldLogs = await dbContext.AuditLogs
    .Where(log => log.CreatedAt < DateTime.UtcNow.AddYears(-1))
    .ToListAsync();

await dbContext.BulkDeleteAsync(oldLogs);
```

### 2. Bulk Update para Cambios Masivos

```csharp
// ✅ BIEN: Actualizar estado de múltiples registros
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

### 3. JSON Columns para Preferencias

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

## 📊 Tabla de Decisión

| Escenario | Recomendación | Razón |
|-----------|---------------|-------|
| Eliminar grandes volúmenes | BulkDeleteAsync | Una sola operación SQL |
| Actualizar grandes volúmenes | BulkUpdateAsync | Mejor rendimiento |
| Consultas complejas | Improved Query Translation | SQL optimizado automáticamente |
| Datos semi-estructurados | JSON Columns | Flexibilidad sin múltiples tablas |
| Preferencias de usuario | JSON Columns | Ideal para configuraciones |
| Metadatos dinámicos | JSON Columns | Sin cambios de esquema frecuentes |

## 💡 Pro Tips

### 1. Combinar Bulk Operations con Transacciones

```csharp
// ✅ BIEN: Bulk operations dentro de transacciones
using var transaction = await dbContext.Database.BeginTransactionAsync();
try
{
    var entities = await dbContext.Users
        .Where(u => u.IsInactive)
        .ToListAsync();

    await dbContext.BulkDeleteAsync(entities);
    await transaction.CommitAsync();
}
catch
{
    await transaction.RollbackAsync();
    throw;
}
```

### 2. Usar JSON Columns para Configuraciones

```csharp
// ✅ BIEN: Configuraciones como JSON
public class ApplicationSettings
{
    public Dictionary<string, string> FeatureFlags { get; set; } = new();
    public Dictionary<string, object> CustomSettings { get; set; } = new();
}
```

### 3. Aprovechar Query Translation para Consultas Complejas

```csharp
// ✅ BIEN: Consultas complejas que ahora se traducen mejor
var stats = await dbContext.Users
    .GroupBy(u => u.Department)
    .Select(g => new
    {
        Department = g.Key,
        Count = g.Count(),
        Average = g.Average(u => u.Salary)
    })
    .Where(x => x.Count > 10)
    .ToListAsync();
```

## 📚 Recursos Adicionales

- [Microsoft Docs - EF Core 9.0 What's New](https://learn.microsoft.com/ef/core/what-is-new/ef-core-9.0/whatsnew)
- [Microsoft Docs - Bulk Operations](https://learn.microsoft.com/ef/core/what-is-new/ef-core-9.0/whatsnew#bulk-updates-and-deletes)
- [Microsoft Docs - JSON Columns](https://learn.microsoft.com/ef/core/what-is-new/ef-core-9.0/whatsnew#json-columns)

