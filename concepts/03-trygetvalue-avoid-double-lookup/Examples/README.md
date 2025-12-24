# Ejemplos Prácticos - TryGetValue

Esta carpeta contiene ejemplos ejecutables que demuestran cómo `TryGetValue` es más eficiente que `ContainsKey` + indexador para evitar dobles búsquedas en diccionarios.

## Archivos

### `TryGetValueExamples.cs`
Demostraciones prácticas de ambos enfoques:
- `DemonstrateInefficientLookup()` - Muestra el enfoque con `ContainsKey` + indexador (doble búsqueda)
- `DemonstrateEfficientLookup()` - Muestra el enfoque con `TryGetValue` (una sola búsqueda)
- `DemonstratePerformanceComparison()` - Comparación de rendimiento con múltiples iteraciones
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 14-15 para los ejemplos de TryGetValue:
#   14. Comparación: ContainsKey vs TryGetValue
#   15. Ejemplo de rendimiento
```

## Resultados Esperados

Los ejemplos muestran que:
- **ContainsKey + Indexer**: Realiza 2 búsquedas cuando la clave existe
- **TryGetValue**: Realiza 1 sola búsqueda
- **Mejora de rendimiento**: Especialmente notable en bucles y operaciones frecuentes

## Notas

- Los ejemplos incluyen medición de tiempo para demostrar la diferencia de rendimiento
- El diccionario de ejemplo contiene nombres y edades
- La comparación de rendimiento ejecuta múltiples iteraciones para mostrar la diferencia acumulada
- `TryGetValue` es especialmente beneficioso en aplicaciones críticas para el rendimiento

