# Ejemplos Prácticos - Applying C# Interpolated Strings

Esta carpeta contiene ejemplos ejecutables que demuestran cómo usar Interpolated Strings en lugar de `string.Format` para código más limpio y legible.

## Archivos

### `InterpolatedStringsExamples.cs`
Demostraciones prácticas de ambos enfoques:
- `DemonstrateStringFormat()` - Muestra el problema de usar `string.Format`
- `DemonstrateInterpolatedStrings()` - Muestra la solución usando Interpolated Strings
- `DemonstrateWithExpressions()` - Uso con expresiones directamente en la cadena
- `DemonstrateWithFormatting()` - Uso con especificadores de formato
- `DemonstrateWithConditions()` - Uso con expresiones condicionales
- `DemonstrateWithObjects()` - Uso con objetos y propiedades
- `DemonstrateMultiline()` - Cadenas multilínea con interpolación
- `DemonstrateEscaping()` - Escapado de llaves literales
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 30-31 para los ejemplos de Interpolated Strings:
#   30. Interpolated Strings vs string.Format - Comparación
#   31. Interpolated Strings vs string.Format - Ejemplos prácticos
```

## Conceptos Clave

- **Improved Readability**: Mejor legibilidad al insertar expresiones directamente
- **Less Error-Prone**: Menos propenso a errores que placeholders posicionales
- **Dynamic Content**: Fácil incluir valores de variables y expresiones
- **Más Intuitivo**: Código más limpio e intuitivo

## Ejemplo Básico

```csharp
// ❌ string.Format (menos preferido)
string message = string.Format("Name: {0}, Age: {1}", name, age);

// ✅ Interpolated String (preferido)
string message = $"Name: {name}, Age: {age}";
```

## Notas

- Los ejemplos muestran claramente la diferencia entre ambos enfoques
- Se incluyen casos de uso avanzados como formato, condiciones y multilínea
- Se explica cómo escapar llaves literales cuando sea necesario
- Disponible desde C# 6.0+

