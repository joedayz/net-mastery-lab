# Ejemplos Prácticos - Keywords en C#

Esta carpeta contiene ejemplos ejecutables que demuestran los Keywords esenciales de C#.

## Archivos

### `KeywordsExamples.cs`
Demostraciones prácticas de Keywords en C#:
- `DemonstrateAccessModifiers()` - Modificadores de acceso (public, private, protected, etc.)
- `DemonstrateDeclarationKeywords()` - Keywords de declaración (class, interface, struct, enum, record)
- `DemonstrateTypeKeywords()` - Keywords de tipo (string, int, bool, double, decimal, var)
- `DemonstrateMethodModifiers()` - Modificadores de métodos (static, virtual, override, abstract, async, await)
- `DemonstrateControlFlow()` - Flujo de control (if, switch, for, foreach, while, try, catch)
- `DemonstrateModernFeatures()` - Características modernas (null, default, using, is, as, nameof, when)
- `DemonstrateContextualKeywords()` - Keywords contextuales (value, get, set, yield, partial, where)
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Keywords
```

## Conceptos Clave

- **Keywords**: Palabras reservadas con significado especial en C#
- **Access Modifiers**: Controlan la visibilidad (public, private, protected, internal)
- **Declaration Keywords**: Definen tipos (class, interface, struct, enum, record)
- **Type Keywords**: Tipos de datos básicos (string, int, bool, double, decimal, var)
- **Method Modifiers**: Modifican comportamiento de métodos (static, virtual, override, abstract)
- **Control Flow**: Controlan flujo de ejecución (if, switch, for, while, try, catch)
- **Modern Features**: Características modernas (null, default, using, is, as, nameof)
- **Contextual Keywords**: Solo tienen significado en ciertos contextos (value, get, set, yield)

## Ejemplo Básico: Access Modifiers

```csharp
public class MyClass
{
    public int PublicProperty { get; set; }      // Accesible desde cualquier lugar
    private int _privateField;                   // Solo dentro de esta clase
    protected int ProtectedProperty { get; set; } // Clase y derivadas
    internal int InternalProperty { get; set; }  // Mismo assembly
}
```

## Ejemplo Básico: Declaration Keywords

```csharp
// class
public class Person { }

// interface
public interface IPerson { }

// struct
public struct Point { }

// enum
public enum Status { Pending, Completed }

// record
public record Person(string Name, int Age);
```

## Ejemplo Básico: Control Flow

```csharp
// if/else
if (condition) { }
else { }

// switch
switch (value)
{
    case 1: break;
    default: break;
}

// for/foreach
for (int i = 0; i < 10; i++) { }
foreach (var item in items) { }

// try/catch
try { }
catch (Exception ex) { }
finally { }
```

## Ejemplo Básico: Modern Features

```csharp
// null
string? nullable = null;

// default
int value = default; // 0

// using
using var stream = new FileStream("file.txt", FileMode.Open);

// is
if (obj is string str) { }

// nameof
throw new ArgumentNullException(nameof(parameter));
```

## Notas

- Los ejemplos muestran claramente el uso de cada keyword
- Se incluyen ejemplos prácticos de cuándo usar cada keyword
- Se explican las mejores prácticas y errores comunes
- Se demuestran combinaciones de keywords para casos avanzados

## Requisitos

- C# 8.0 o superior (para algunas características modernas)
- .NET 6.0 o superior

