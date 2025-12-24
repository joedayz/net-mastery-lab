# Ejemplos Prácticos - LINQ to SQL vs LINQ to Objects

Esta carpeta contiene ejemplos ejecutables que demuestran las diferencias entre LINQ to SQL y LINQ to Objects.

## Archivos

### `LinqToSqlVsObjectsExamples.cs`
Demostraciones prácticas de LINQ to SQL vs LINQ to Objects:
- `DemonstrateLinqToSql()` - Características y funcionamiento de LINQ to SQL
- `DemonstrateLinqToObjects()` - Características y funcionamiento de LINQ to Objects
- `DemonstrateKeyDifferences()` - Diferencias clave entre ambos
- `DemonstrateComparisonTable()` - Tabla comparativa completa
- `DemonstrateWhenToUse()` - Cuándo usar cada uno
- `DemonstrateCommonErrors()` - Errores comunes y cómo evitarlos
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de LINQ to SQL vs LINQ to Objects
```

## Conceptos Clave

- **LINQ to SQL**: Para bases de datos relacionales, retorna `IQueryable<T>`, traduce a SQL
- **LINQ to Objects**: Para colecciones en memoria, retorna `IEnumerable<T>`, ejecuta directamente
- **Diferencias**: Fuente de datos, ejecución, traducción, rendimiento, flexibilidad
- **Cuándo usar**: LINQ to SQL para DB, LINQ to Objects para memoria

## Ejemplo Básico: LINQ to SQL

```csharp
// Consulta que se traduce a SQL
var users = dbContext.Users
    .Where(u => u.IsActive)
    .ToList();
```

## Ejemplo Básico: LINQ to Objects

```csharp
// Consulta ejecutada en memoria
var users = userList
    .Where(u => u.IsActive)
    .ToList();
```

## Notas

- Los ejemplos muestran claramente las diferencias entre ambas tecnologías
- Se incluyen ejemplos prácticos de cuándo usar cada una
- Se explican las mejores prácticas y errores comunes
- Se demuestra por qué elegir la tecnología correcta es importante

## Requisitos

- .NET 6.0 o superior
- Conocimientos básicos de C# y LINQ

