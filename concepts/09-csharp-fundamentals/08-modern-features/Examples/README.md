# Ejemplos Prácticos - Modern C# Features

Esta carpeta contiene ejemplos ejecutables que demuestran las características modernas de C#.

## Archivos

### `ModernFeaturesExamples.cs`
Demostraciones prácticas de características modernas de C#:
- `DemonstrateNullHandling()` - Filosofía de manejo de null (?. y ??)
- `DemonstratePatternMatching()` - Pattern matching avanzado
- `DemonstrateResourceManagement()` - Gestión de recursos con using
- `DemonstrateTargetTypedNew()` - Target-typed 'new' para inferencia de tipos
- `DemonstrateNameof()` - Importancia estratégica de 'nameof'
- `DemonstrateTypeConversion()` - Conversión segura de tipos con 'as'
- `DemonstrateImpact()` - Impacto de las características modernas
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Modern C# Features
```

## Conceptos Clave

- **Null Handling**: Operadores ?. y ?? para manejo seguro de null
- **Pattern Matching**: Type patterns, property patterns, relational patterns
- **Resource Management**: using statement y using declaration
- **Target-Typed new**: Inferencia de tipos para reducir verbosidad
- **nameof**: Referencias seguras ante refactoring
- **Type Conversion**: Operador 'as' para conversión segura

## Ejemplo Básico: Null Handling

```csharp
// Null-conditional operator
var city = person?.Address?.City ?? "Unknown";

// Null-coalescing operator
var name = person?.Name ?? "Unknown";
```

## Ejemplo Básico: Pattern Matching

```csharp
// Type pattern
if (obj is string str)
{
    Console.WriteLine(str.ToUpper());
}

// Switch expression
var message = value switch
{
    >= 90 => "A",
    >= 80 => "B",
    _ => "F"
};
```

## Ejemplo Básico: Resource Management

```csharp
// using declaration
using var stream = new FileStream("file.txt", FileMode.Open);
var content = await stream.ReadToEndAsync();
```

## Ejemplo Básico: Target-Typed new

```csharp
// Target-typed new
Dictionary<string, List<int>> dict = new();
List<string> items = new();
```

## Ejemplo Básico: nameof

```csharp
// nameof para referencias seguras
throw new ArgumentNullException(nameof(parameter));
```

## Ejemplo Básico: Type Conversion

```csharp
// Operador 'as' para conversión segura
var str = obj as string;
if (str != null)
{
    Console.WriteLine(str);
}
```

## Notas

- Los ejemplos muestran claramente el uso de cada característica moderna
- Se incluyen comparaciones antes/después
- Se demuestra el impacto de usar características modernas
- Se explican las mejores prácticas y errores comunes

## Requisitos

- C# 8.0 o superior (para algunas características)
- .NET 6.0 o superior

