# Ejemplos Prácticos - Logging en .NET Core

Esta carpeta contiene ejemplos ejecutables que demuestran cómo usar Logging en .NET Core.

## Archivos

### `LoggingExamples.cs`
Demostraciones prácticas de Logging:
- `DemonstrateBuiltInLogger()` - Built-in ILogger
- `DemonstrateSerilog()` - Serilog structured logging
- `DemonstrateNLog()` - NLog simple y rápido
- `DemonstrateBestPractices()` - Mejores prácticas
- `DemonstrateWhenToUse()` - Cuándo usar cada opción
- `DemonstratePracticalExamples()` - Ejemplos prácticos
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Logging
```

## Conceptos Clave

- **Built-in ILogger**: Logging ligero incluido en ASP.NET Core
- **Serilog**: Structured logging completo con múltiples sinks
- **NLog**: Logging simple, rápido y flexible
- **Structured Logging**: Logs como pares clave-valor
- **Log Levels**: Trace, Debug, Information, Warning, Error, Critical

## Ejemplo Básico: Built-in ILogger

```csharp
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    
    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult GetUser(int id)
    {
        _logger.LogInformation("Getting user with ID: {UserId}", id);
        // ...
    }
}
```

## Ejemplo: Serilog Structured Logging

```csharp
// Configuración
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/app.log")
    .CreateLogger();

// Uso
_logger.LogInformation(
    "User {UserId} performed {Action} in {Duration}ms",
    userId, action, duration);
```

## Ejemplo: Logging con Scopes

```csharp
using (_logger.BeginScope("OrderId: {OrderId}", orderId))
{
    _logger.LogInformation("Starting order processing");
    // Todos los logs incluyen OrderId automáticamente
}
```

## Notas

- Los ejemplos muestran claramente las diferencias entre las tres opciones
- Se incluyen todas las mejores prácticas
- Se explican cuándo usar cada opción
- Se cubren casos de uso comunes

## Requisitos

- Conocimientos básicos de ASP.NET Core
- Comprensión de Dependency Injection
- Conocimientos básicos de logging

## Instalación

**Serilog:**
```bash
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
```

**NLog:**
```bash
dotnet add package NLog.Web.AspNetCore
```

