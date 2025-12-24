# Ejemplos Prácticos - Flattening Nested Collections Using SelectMany

Esta carpeta contiene ejemplos ejecutables que demuestran cómo usar `SelectMany` para aplanar colecciones anidadas, reemplazando bucles anidados con código más legible y conciso.

## Archivos

### `SelectManyExamples.cs`
Demostraciones prácticas de ambos enfoques:
- `DemonstrateNestedLoops()` - Muestra el problema de usar bucles anidados
- `DemonstrateSelectMany()` - Muestra la solución usando `SelectMany`
- `DemonstrateSelectManyWithFiltering()` - Demuestra cómo combinar con `Where()`
- `DemonstrateSelectManyWithTransformation()` - Demuestra cómo combinar con `Select()`
- `DemonstrateSelectManyMultipleLevels()` - Aplanar múltiples niveles de anidación
- `DemonstrateSelectVsSelectMany()` - Diferencia entre `Select` y `SelectMany`
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 22-23 para los ejemplos de SelectMany:
#   22. Nested Loops vs SelectMany - Comparación
#   23. Nested Loops vs SelectMany - Ejemplos prácticos
```

## Conceptos Clave

- **Código Conciso**: Una línea en lugar de bucles anidados
- **Más Legible**: La intención es clara y expresiva
- **Enfoque Funcional**: Declarativo y fácil de entender
- **Composable**: Fácil de combinar con otros operadores LINQ

## Notas

- Los ejemplos muestran claramente la diferencia entre bucles anidados y `SelectMany`
- Se incluyen ejemplos de cómo combinar `SelectMany` con otros operadores LINQ
- Se demuestra cómo aplanar múltiples niveles de anidación
- Se explica la diferencia entre `Select` y `SelectMany`

## Ejemplo Básico

```csharp
// ❌ Bucles anidados
var employees = new List<Employee>();
foreach (var dept in departments)
{
    foreach (var employee in dept.Employees)
    {
        employees.Add(employee);
    }
}

// ✅ SelectMany
var employees = departments
    .SelectMany(dept => dept.Employees)
    .ToList();
```

