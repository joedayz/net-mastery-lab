# Ejemplos Prácticos - Use MinBy or MaxBy Instead of OrderBy + First/Last

Esta carpeta contiene ejemplos ejecutables que demuestran cómo usar `MinBy` y `MaxBy` en lugar de `OrderBy` + `First`/`Last` para encontrar elementos extremos de manera más eficiente.

## Archivos

### `MinByMaxByExamples.cs`
Demostraciones prácticas de ambos enfoques:
- `DemonstrateOrderByFirst()` - Muestra el problema de usar `OrderBy` + `First`
- `DemonstrateMinByMaxBy()` - Muestra la solución usando `MinBy` y `MaxBy`
- `DemonstratePerformanceComparison()` - Comparación de rendimiento con colecciones grandes
- `DemonstrateWithDifferentObjects()` - Uso con diferentes tipos de objetos
- `DemonstrateWithOtherOperators()` - Combinación con otros operadores LINQ
- `DemonstrateEmptySequenceHandling()` - Manejo de secuencias vacías
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 26-27 para los ejemplos de MinBy/MaxBy:
#   26. MinBy/MaxBy vs OrderBy+First - Comparación
#   27. MinBy/MaxBy vs OrderBy+First - Ejemplos prácticos
```

## Conceptos Clave

- **Más Conciso**: Más fácil de leer y escribir
- **Más Eficiente**: O(n) vs O(n log n) - no necesita ordenar toda la secuencia
- **Más Legible**: La intención es clara y expresiva
- **Disponible en .NET 6+**: Introducido en .NET 6

## Notas

- Los ejemplos muestran claramente la diferencia de rendimiento entre ambos enfoques
- Se incluyen mediciones de tiempo para demostrar la mejora de rendimiento
- Se demuestra cómo usar con diferentes tipos de objetos
- Se explica cómo manejar secuencias vacías

## Ejemplo Básico

```csharp
// ❌ OrderBy + First (menos eficiente)
var cheapest = cars.OrderBy(c => c.Price).First();

// ✅ MinBy (más eficiente)
var cheapest = cars.MinBy(c => c.Price);
```

