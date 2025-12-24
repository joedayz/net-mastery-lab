# Ejemplos Prácticos - Arrays vs ArrayList

Esta carpeta contiene ejemplos ejecutables que demuestran las diferencias entre Arrays y ArrayList (List<T>) en C#.

## Archivos

### `ArraysVsArrayListExamples.cs`
Demostraciones prácticas de Arrays vs ArrayList:
- `DemonstrateArrays()` - Arrays: El Rey de la Velocidad
- `DemonstrateList()` - List<T>: El Campeón de la Flexibilidad
- `DemonstrateKeyDifferences()` - Diferencias clave que importan
- `DemonstrateWhenToUse()` - Cuándo usar cada uno
- `DemonstrateCommonMistakes()` - Errores comunes a evitar
- `DemonstratePracticalExamples()` - Ejemplos prácticos
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Arrays vs ArrayList
```

## Conceptos Clave

- **Arrays**: Tamaño fijo, acceso ultra rápido, eficiente en memoria
- **List<T>**: Tamaño dinámico, gestión fácil, type-safe
- **ArrayList**: Legacy, no recomendado en código nuevo
- **Diferencias**: Tamaño, rendimiento, type-safety

## Ejemplo Básico: Array

```csharp
int[] numbers = new int[5];  // Tamaño fijo
numbers[0] = 10;
```

## Ejemplo Básico: List<T>

```csharp
List<int> numbers = new List<int>();  // Tamaño dinámico
numbers.Add(10);
numbers.Add(20);
```

## Notas

- Los ejemplos muestran claramente las diferencias entre Arrays y List<T>
- Se incluyen errores comunes y cómo evitarlos
- Se explica cuándo usar cada uno según el escenario

## Requisitos

- Conocimientos básicos de C#
- Comprensión de colecciones y tipos de datos

