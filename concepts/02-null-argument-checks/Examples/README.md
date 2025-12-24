# Ejemplos Prácticos - Null Argument Checks

Esta carpeta contiene ejemplos ejecutables que demuestran los diferentes métodos de validación de argumentos nulos en C#.

## Archivos

### `NullCheckExamples.cs`
Demostraciones prácticas de los tres métodos de validación:
- `DemonstrateNullChecks()` - Comparación visual de los tres métodos
- `DemonstratePracticalUsage()` - Ejemplo práctico en un método real
- `DemonstrateMultipleValidations()` - Validación de múltiples argumentos

### `NullCheckBenchmark.cs`
Benchmarks de rendimiento usando BenchmarkDotNet:
- Compara el rendimiento de los tres métodos
- Muestra resultados en nanosegundos
- Demuestra que `ArgumentNullException.ThrowIfNull(arg, nameof(arg))` es ~48x más rápido

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 10-13 para los ejemplos de Null Argument Checks
```

## Resultados Esperados

Los benchmarks muestran que:
- **Old Way**: ~0.0048 ns (más lento)
- **New Way**: ~0.0009 ns (más rápido)
- **New Way Upgraded**: ~0.0001 ns (más rápido, recomendado)

## Notas

- Los ejemplos muestran cómo cada método lanza excepciones cuando se pasa `null`
- Los benchmarks requieren BenchmarkDotNet y pueden tardar unos momentos en ejecutarse
- Todos los métodos son válidos, pero se recomienda usar el método moderno mejorado en proyectos .NET 6+

