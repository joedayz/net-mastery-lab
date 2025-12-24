# Ejemplos Prácticos - Top 20 Características Esenciales de C#

Esta carpeta contiene ejemplos ejecutables que demuestran las 20 características esenciales de C# que todo desarrollador debe conocer.

## Archivos

### `EssentialCSharpFeaturesExamples.cs`
Demostraciones prácticas de las características esenciales:
- `DemonstrateGenerics()` - Genéricos para código reutilizable
- `DemonstrateDynamic()` - Tipo dynamic para flexibilidad
- `DemonstrateTuples()` - Tuplas y deconstrucción
- `DemonstrateTopLevelStatements()` - Top-Level Statements
- `DemonstratePartialClasses()` - Clases parciales
- `DemonstrateAsyncAwait()` - Async/Await para operaciones asíncronas
- `DemonstrateGlobalUsing()` - Directivas Global Using
- `DemonstrateListPatterns()` - List Patterns
- `DemonstrateLambdaExpressions()` - Expresiones Lambda
- `DemonstrateExpressionBodyMembers()` - Miembros con cuerpo de expresión
- `DemonstrateDefaultInterfaceMethods()` - Métodos por defecto en interfaces
- `DemonstrateRequiredModifier()` - Modificador required
- `DemonstrateExtensionMethods()` - Métodos de extensión
- `DemonstrateAutoPropertyInitializers()` - Inicializadores de auto-propiedades
- `DemonstrateRecords()` - Tipos Record
- `DemonstrateCollectionExpressions()` - Expresiones de colección
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Essential C# Features
```

## Conceptos Clave

- **20 Características Esenciales**: Desde genéricos hasta collection expressions
- **Versiones de C#**: Cubre características desde C# 2.0 hasta C# 12.0
- **Mejores Prácticas**: Cuándo usar cada característica
- **Ejemplos Prácticos**: Código real y casos de uso

## Ejemplo Básico: Genéricos

```csharp
public class Repository<T> where T : class
{
    private readonly List<T> _items = new();
    public void Add(T item) => _items.Add(item);
}
```

## Ejemplo Básico: Records

```csharp
public record Person(string Name, int Age);
var person = new Person("John", 30);
```

## Ejemplo Básico: Async/Await

```csharp
public async Task<string> GetDataAsync()
{
    using var httpClient = new HttpClient();
    return await httpClient.GetStringAsync("https://api.example.com");
}
```

## Notas

- Algunas características ya están cubiertas en detalle en otros temas del repositorio
- Este tema proporciona una visión general completa de todas las características
- Se incluyen referencias a temas relacionados para profundizar

## Requisitos

- .NET 6.0 o superior
- Conocimientos básicos de C#

