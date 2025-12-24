# Ejemplos Prácticos - Entity Framework Core

Esta carpeta contiene ejemplos ejecutables que demuestran Entity Framework Core (EF Core) y sus características principales.

## Archivos

### `EntityFrameworkCoreExamples.cs`
Demostraciones prácticas de EF Core:
- `DemonstrateWhatIsEfCore()` - Qué es EF Core y sus características
- `DemonstrateWhyUseEfCore()` - Por qué usar EF Core (8 razones principales)
- `DemonstrateHowEfCoreWorks()` - Cómo funciona EF Core (flujo de trabajo)
- `DemonstrateAdvancedFeatures()` - Características avanzadas
- `DemonstrateCrudOperations()` - Operaciones CRUD completas
- `DemonstrateLinqQueries()` - Consultas LINQ avanzadas
- `DemonstrateImportantConsiderations()` - Consideraciones importantes
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de EF Core
```

## Conceptos Clave

- **ORM**: Object-Relational Mapper que mapea objetos a tablas
- **DbContext**: Gestiona operaciones de base de datos
- **LINQ**: Consultas type-safe en lugar de SQL crudo
- **Migraciones**: Versionado automático de esquema de base de datos
- **CRUD**: Create, Read, Update, Delete operations
- **Eager/Lazy Loading**: Estrategias de carga de datos relacionados
- **AsNoTracking**: Optimización para consultas de solo lectura

## Ejemplo Básico: Configuración

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
```

## Ejemplo Básico: CRUD

```csharp
// Create
context.Users.Add(user);
await context.SaveChangesAsync();

// Read
var user = await context.Users.FindAsync(1);

// Update
user.Name = "Updated";
await context.SaveChangesAsync();

// Delete
context.Users.Remove(user);
await context.SaveChangesAsync();
```

## Notas

- Los ejemplos muestran claramente las ventajas de EF Core
- Se incluyen mejores prácticas y consideraciones importantes
- Se explica cuándo usar EF Core y cuándo no

## Requisitos

- Conocimientos básicos de C# y .NET
- Comprensión de bases de datos relacionales
- Conocimientos básicos de LINQ

## Temas Relacionados

Este repositorio cubre temas avanzados de EF Core:
- **AsNoTracking**: Optimización para consultas de solo lectura
- **Eager, Lazy & Explicit Loading**: Estrategias de carga
- **Unit of Work & Repository Pattern**: Patrones de diseño con EF Core

