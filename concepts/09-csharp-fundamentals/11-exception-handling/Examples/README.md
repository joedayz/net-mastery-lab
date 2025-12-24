# Ejemplos Prácticos - Manejo de Excepciones

Esta carpeta contiene ejemplos ejecutables que demuestran el manejo de excepciones en C#.

## Archivos

### `ExceptionHandlingExamples.cs`
Demostraciones prácticas de Manejo de Excepciones:
- `DemonstrateTryCatch()` - Bloques try-catch básicos
- `DemonstrateFinally()` - Bloque finally para limpieza
- `DemonstrateCommonExceptions()` - Excepciones comunes del sistema
- `DemonstrateCustomExceptions()` - Excepciones personalizadas
- `DemonstrateThrowingExceptions()` - Lanzar y re-lanzar excepciones
- `DemonstrateFileHandling()` - Manejo de archivos con excepciones
- `DemonstrateUsingStatement()` - Using statement para recursos
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Manejo de Excepciones
```

## Conceptos Clave

- **try-catch**: Capturar y manejar excepciones
- **finally**: Bloque que siempre se ejecuta para limpieza
- **Excepciones del Sistema**: ArgumentException, FileNotFoundException, etc.
- **Excepciones Personalizadas**: Crear excepciones específicas para tu dominio
- **Using Statement**: Manejo automático de recursos

## Ejemplo Básico: try-catch

```csharp
try
{
    int result = int.Parse("abc");
}
catch (FormatException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

## Ejemplo Básico: finally

```csharp
FileStream? file = null;
try
{
    file = File.OpenRead("data.txt");
}
finally
{
    file?.Dispose(); // Siempre se ejecuta
}
```

## Ejemplo Básico: Using Statement

```csharp
using var file = File.OpenRead("data.txt");
// Procesar archivo
// Dispose automático al final del scope
```

## Notas

- Los ejemplos muestran claramente cómo manejar diferentes tipos de excepciones
- Se incluyen ejemplos prácticos de cuándo usar cada patrón
- Se explican las mejores prácticas y errores comunes
- Se demuestra por qué el manejo de excepciones es importante

## Requisitos

- .NET 6.0 o superior
- Conocimientos básicos de C#

