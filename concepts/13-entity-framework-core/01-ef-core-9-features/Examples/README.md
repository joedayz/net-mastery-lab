# Ejemplos Prácticos - EF Core 9.0 - Nuevas Características

Esta carpeta contiene ejemplos ejecutables que demuestran las nuevas características de Entity Framework Core 9.0.

## Archivos

### `EfCore9FeaturesExamples.cs`
Demostraciones prácticas de las nuevas características de EF Core 9.0:
- `DemonstrateBulkOperations()` - Bulk Operations (Native Support)
- `DemonstrateImprovedQueryTranslation()` - Improved Query Translation
- `DemonstrateJsonColumnSupport()` - JSON Column Support
- `DemonstrateBeforeAfter()` - Comparación antes vs después
- `DemonstratePracticalExamples()` - Ejemplos prácticos
- `DemonstrateWhenToUse()` - Cuándo usar cada característica
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de EF Core 9.0
```

## Conceptos Clave

- **Bulk Operations**: Operaciones masivas nativas para eliminar y actualizar grandes volúmenes
- **Query Translation**: Mejoras en la traducción de LINQ a SQL
- **JSON Columns**: Soporte completo para columnas JSON en bases de datos relacionales
- **Rendimiento**: Operaciones más rápidas y eficientes
- **Simplicidad**: Menos código, menos dependencias

## Ejemplo Básico: Bulk Delete

```csharp
var entities = await dbContext.Users
    .Where(u => u.IsInactive)
    .ToListAsync();

await dbContext.BulkDeleteAsync(entities);
```

## Ejemplo Básico: JSON Column

```csharp
public class User
{
    public int Id { get; set; }
    public UserPreferences Preferences { get; set; } = new();
}

// Configuración
modelBuilder.Entity<User>()
    .OwnsOne(u => u.Preferences, pref => pref.ToJson());
```

## Notas

- Los ejemplos muestran claramente las nuevas características de EF Core 9.0
- Se incluyen comparaciones antes vs después
- Se explica cuándo usar cada característica según el escenario
- Se demuestran las mejoras de rendimiento y simplicidad

## Requisitos

- Conocimientos básicos de Entity Framework Core
- Comprensión de LINQ y consultas
- Conocimientos básicos de bases de datos relacionales

