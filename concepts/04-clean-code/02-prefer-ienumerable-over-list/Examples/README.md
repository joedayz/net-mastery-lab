# Ejemplos Prácticos - Prefer IEnumerable<T> Over List<T>

Esta carpeta contiene ejemplos ejecutables que demuestran por qué preferir `IEnumerable<T>` sobre `List<T>` para tipos de retorno.

## Archivos

### `IEnumerableVsListExamples.cs`
Demostraciones prácticas de ambos enfoques:
- `DemonstrateListReturn()` - Muestra el problema de devolver `List<T>`
- `DemonstrateIEnumerableReturn()` - Muestra la solución usando `IEnumerable<T>`
- `DemonstrateFlexibility()` - Demuestra cómo cambiar la implementación sin afectar consumidores
- `DemonstrateDeferredExecution()` - Compara ejecución inmediata vs diferida
- `DemonstrateEncapsulation()` - Muestra mejor encapsulación con `IEnumerable<T>`
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 18-19 para los ejemplos de IEnumerable vs List:
#   18. IEnumerable<T> vs List<T> - Comparación
#   19. IEnumerable<T> vs List<T> - Ejemplos prácticos
```

## Conceptos Clave

- **Flexibilidad**: Cambiar implementación sin afectar consumidores
- **Mejor Encapsulación**: Oculta detalles de implementación
- **Ejecución Diferida**: Más eficiente, evita operaciones innecesarias
- **Regla General**: Usa `IEnumerable<T>` como tipo de retorno por defecto

## Notas

- Los ejemplos muestran claramente la diferencia entre devolver `List<T>` y `IEnumerable<T>`
- Se incluyen mediciones de tiempo para demostrar la diferencia en ejecución
- La comparación de flexibilidad muestra cómo puedes cambiar la implementación sin afectar el código consumidor
- La demostración de ejecución diferida muestra cómo `IEnumerable<T>` es más eficiente

