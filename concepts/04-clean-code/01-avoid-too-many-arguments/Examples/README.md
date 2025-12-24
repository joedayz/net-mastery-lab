# Ejemplos Prácticos - Avoid Too Many Arguments

Esta carpeta contiene ejemplos ejecutables que demuestran cómo evitar demasiados argumentos en funciones usando objetos para encapsular datos relacionados.

## Archivos

### `AvoidTooManyArgumentsExamples.cs`
Demostraciones prácticas de ambos enfoques:
- `DemonstrateBadPractice()` - Muestra el problema de tener demasiados argumentos individuales
- `DemonstrateGoodPractice()` - Muestra la solución usando objetos para encapsular datos
- `DemonstrateFlexibility()` - Demuestra cómo agregar campos sin cambiar la firma de la función
- `DemonstrateReadabilityComparison()` - Compara la legibilidad de ambos enfoques
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 16-17 para los ejemplos de Clean Code:
#   16. Avoid Too Many Arguments - Comparación
#   17. Avoid Too Many Arguments - Ejemplos prácticos
```

## Conceptos Clave

- **Regla General**: Limitar argumentos a 2-3 máximo
- **Encapsulación**: Usar structs o clases para agrupar parámetros relacionados
- **Ventajas**: Mejor legibilidad, mantenibilidad, testabilidad y flexibilidad

## Notas

- Los ejemplos muestran claramente la diferencia entre el enfoque problemático y la solución
- Se incluyen ejemplos prácticos de cómo agregar nuevos campos sin cambiar la firma de la función
- La comparación de legibilidad muestra por qué el código encapsulado es más fácil de leer y mantener

