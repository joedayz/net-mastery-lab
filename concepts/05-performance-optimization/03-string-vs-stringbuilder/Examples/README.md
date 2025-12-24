# Ejemplos Prácticos - String vs StringBuilder

Esta carpeta contiene ejemplos ejecutables que demuestran las diferencias entre String y StringBuilder en cuanto a asignación de memoria y rendimiento.

## Archivos

### `StringVsStringBuilderExamples.cs`
Demostraciones prácticas de String vs StringBuilder:
- `DemonstrateStringMemoryAllocation()` - Asignación de memoria para String
- `DemonstrateStringBuilderMemoryAllocation()` - Asignación de memoria para StringBuilder
- `DemonstratePerformanceComparison()` - Comparación de rendimiento entre ambos
- `DemonstrateWhenToUse()` - Cuándo usar cada uno
- `DemonstrateCommonErrors()` - Errores comunes y cómo evitarlos
- `DemonstratePracticalExamples()` - Ejemplos prácticos de uso
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de String vs StringBuilder
```

## Conceptos Clave

- **String (Inmutable)**: Cada modificación crea nuevo objeto, múltiples objetos en memoria, O(n²)
- **StringBuilder (Mutable)**: Modifica el mismo objeto, un objeto que crece, O(n)
- **Asignación de Memoria**: String crea múltiples objetos, StringBuilder modifica uno
- **Rendimiento**: String para pocas operaciones, StringBuilder para muchas

## Ejemplo Básico: String

```csharp
// Cada concatenación crea nuevo objeto
string result = "Hello";
result += " World"; // Nuevo objeto creado
```

## Ejemplo Básico: StringBuilder

```csharp
// Modifica el mismo objeto
StringBuilder sb = new StringBuilder();
sb.Append("Hello");
sb.Append(" World");
string result = sb.ToString();
```

## Notas

- Los ejemplos muestran claramente las diferencias en asignación de memoria
- Se incluyen ejemplos prácticos de cuándo usar cada uno
- Se explican las mejores prácticas y errores comunes
- Se demuestra por qué elegir la herramienta correcta es importante para el rendimiento

## Requisitos

- .NET 6.0 o superior
- Conocimientos básicos de C#

