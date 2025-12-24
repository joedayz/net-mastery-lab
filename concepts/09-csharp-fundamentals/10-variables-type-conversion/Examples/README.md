# Ejemplos Prácticos - Variables y Conversión de Tipos

Esta carpeta contiene ejemplos ejecutables que demuestran cómo trabajar con variables y conversión de tipos en C#.

## Archivos

### `VariablesTypeConversionExamples.cs`
Demostraciones prácticas de Variables y Conversión de Tipos:
- `DemonstrateVariableDeclaration()` - Declaración de variables y tipos de datos comunes
- `DemonstrateTypeInference()` - Inferencia de tipos con var
- `DemonstrateTypeConversion()` - Conversión implícita y explícita
- `DemonstrateConversionMethods()` - Métodos de conversión (Parse, TryParse, Convert)
- `DemonstrateNullableTypes()` - Tipos nullable
- `DemonstrateConstants()` - Constantes y readonly
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Variables y Conversión de Tipos
```

## Conceptos Clave

- **Tipos de Datos**: Enteros, punto flotante, texto, booleano
- **Conversión de Tipos**: Implícita, explícita, métodos de conversión
- **Inferencia de Tipos**: Keyword `var` para inferir tipos automáticamente
- **Tipos Nullable**: Tipos de valor que pueden ser null
- **Constantes**: Valores fijos que no cambian

## Ejemplo Básico: Declaración de Variables

```csharp
// Tipos explícitos
int age = 25;
string name = "Alice";
bool isActive = true;

// Inferencia de tipos con var
var count = 10;        // int
var message = "Hello"; // string
```

## Ejemplo Básico: Conversión de Tipos

```csharp
// Conversión implícita
int small = 100;
long large = small; // Automática

// Conversión explícita
double d = 99.99;
int i = (int)d; // Cast explícito
```

## Ejemplo Básico: TryParse

```csharp
string input = "123";
if (int.TryParse(input, out int number))
{
    Console.WriteLine($"Número: {number}");
}
```

## Notas

- Los ejemplos muestran claramente las diferencias entre tipos de datos
- Se incluyen ejemplos prácticos de cuándo usar cada tipo
- Se explican las mejores prácticas y errores comunes
- Se demuestra por qué las conversiones son importantes

## Requisitos

- .NET 6.0 o superior
- Conocimientos básicos de C#

