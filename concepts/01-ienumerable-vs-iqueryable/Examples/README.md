# Ejemplos Prácticos

Esta carpeta contiene ejemplos ejecutables que demuestran las diferencias entre `IEnumerable` e `IQueryable`.

## Archivos

### `Employee.cs`
Modelo de datos de ejemplo usado en todos los ejemplos.

### `IEnumerableExample.cs`
Demostraciones de cómo `IEnumerable` ejecuta consultas en memoria:
- `DemonstrateClientSideExecution()` - Muestra cómo se traen todos los registros a memoria
- `DemonstrateDeferredExecution()` - Ejecución diferida
- `DemonstratePerformance()` - Impacto en rendimiento

### `IQueryableExample.cs`
Demostraciones de cómo `IQueryable` ejecuta consultas en el servidor:
- `DemonstrateServerSideExecution()` - Muestra cómo se traduce a SQL
- `DemonstrateQueryTranslation()` - Traducción de expresiones complejas
- `DemonstratePerformance()` - Optimización de rendimiento
- `DemonstrateCommonMistake()` - Error común y cómo evitarlo

### `ComparisonDemo.cs`
Comparación visual basada en el ejemplo de la imagen, mostrando:
- La diferencia clave en el SQL generado
- El flujo de datos para cada interfaz
- Resumen de diferencias

### `EmployeeDbContext.cs`
DbContext de Entity Framework Core para los ejemplos de `IQueryable`.

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Ejecutar todos los ejemplos
dotnet run -- --all
```

El programa mostrará un menú interactivo donde puedes seleccionar qué ejemplo ejecutar.

## Notas

- Los ejemplos de `IQueryable` usan Entity Framework Core con una base de datos en memoria
- Los ejemplos de `IEnumerable` trabajan con colecciones en memoria
- Todos los ejemplos son ejecutables y muestran salida en consola

