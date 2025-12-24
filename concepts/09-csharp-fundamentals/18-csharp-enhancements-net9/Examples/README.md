# Ejemplos Prácticos - C# Enhancements in .NET 9.0

Esta carpeta contiene ejemplos ejecutables que demuestran las mejoras de C# en .NET 9.0.

## Archivos

### `CSharpEnhancementsNet9Examples.cs`
Demostraciones prácticas de las mejoras de C# en .NET 9.0:
- `DemonstratePrimaryConstructors()` - Primary Constructors
- `DemonstrateAutoDefaultStructs()` - Auto-Default Structs
- `DemonstrateEnhancedPatternMatching()` - Enhanced Pattern Matching
- `DemonstrateBeforeAfter()` - Comparación antes vs después
- `DemonstratePracticalExamples()` - Ejemplos prácticos
- `DemonstrateWhenToUse()` - Cuándo usar cada característica
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de C# Enhancements in .NET 9.0
```

## Conceptos Clave

- **Primary Constructors**: Simplifica inicialización de clases y records
- **Auto-Default Structs**: Inicialización automática de miembros de struct
- **Enhanced Pattern Matching**: Capacidades más poderosas y flexibles
- **Rendimiento**: Código más eficiente sin sacrificar legibilidad
- **Simplicidad**: Menos código, menos errores, más productividad

## Ejemplo Básico: Primary Constructor

```csharp
public class Person(string name, int age)
{
    public string Name { get; } = name;
    public int Age { get; } = age;
}
```

## Ejemplo Básico: Auto-Default Struct

```csharp
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

var point = new Point();
// X, Y automáticamente inicializados a 0
```

## Ejemplo Básico: Enhanced Pattern Matching

```csharp
var result = person switch
{
    { Age: >= 18, Name: not null } => $"{person.Name} is an adult",
    { Age: < 18, Name: not null } => $"{person.Name} is a minor",
    _ => "Unknown"
};
```

## Notas

- Los ejemplos muestran claramente las mejoras de C# en .NET 9.0
- Se incluyen comparaciones antes vs después
- Se explica cuándo usar cada característica según el escenario
- Se demuestran las mejoras de rendimiento y simplicidad

## Requisitos

- Conocimientos básicos de C#
- Comprensión de constructores y structs
- Conocimientos básicos de pattern matching

