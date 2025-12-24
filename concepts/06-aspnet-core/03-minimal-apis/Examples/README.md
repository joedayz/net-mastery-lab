# Ejemplos Prácticos - Minimal APIs

Esta carpeta contiene ejemplos ejecutables que demuestran cómo usar Minimal APIs en ASP.NET Core.

## Archivos

### `MinimalApisExamples.cs`
Demostraciones prácticas de Minimal APIs:
- `DemonstrateBasicStructure()` - Estructura básica de Minimal APIs
- `DemonstrateComparison()` - Comparación con Controllers tradicionales
- `DemonstrateGrouping()` - Agrupación de endpoints relacionados
- `DemonstrateWhenToUse()` - Cuándo usar Minimal APIs vs Controllers
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Minimal APIs
```

## Conceptos Clave

- **Menos Código**: Sintaxis más concisa que Controllers
- **Mejor Rendimiento**: Menos overhead, inicio más rápido
- **DI Automática**: Inyección de dependencias en parámetros
- **Agrupación**: MapGroup para organizar endpoints relacionados

## Ejemplo Básico

```csharp
app.MapGet("/hello", () => "Hello, World!");
app.MapGet("/users/{id}", (int id) => GetUser(id));
```

## Notas

- Ideal para microservicios y APIs simples
- Considerar Controllers para lógica compleja
- Usar MapGroup para organizar endpoints relacionados

