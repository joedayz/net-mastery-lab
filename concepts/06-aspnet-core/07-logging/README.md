# Logging in .NET Core: The Backbone of Every Reliable Application 📝

## Introducción

Si depurar es como trabajo de detective, entonces el logging es tu evidencia. Una configuración robusta de logging te ayuda a rastrear problemas, monitorear el rendimiento y entender exactamente cómo se comporta tu aplicación, especialmente en producción.

El logging es esencial para:
- 🔍 **Trazar Problemas**: Identificar dónde y por qué ocurren errores
- 📊 **Monitorear Rendimiento**: Entender el comportamiento de la aplicación
- 🐛 **Debugging**: Facilitar la depuración en producción
- 📈 **Análisis**: Obtener insights sobre el uso de la aplicación

## 🎯 Tres Enfoques Principales de Logging

### 1️⃣ Built-in ILogger — Tu Punto de Partida ✅

ASP.NET Core incluye una interfaz `ILogger` ligera y flexible que funciona out-of-the-box.

#### Características

- ✅ **Ligero y Flexible**: Incluido en ASP.NET Core, sin dependencias adicionales
- ✅ **Múltiples Niveles de Log**: Information, Warning, Error, Critical, Debug, Trace
- ✅ **Funciona Out-of-the-Box**: No necesita configuración adicional
- ✅ **Integrado con DI**: Funciona perfectamente con Dependency Injection

#### Niveles de Log

```csharp
_logger.LogTrace("Trace - Información muy detallada");
_logger.LogDebug("Debug - Información de depuración");
_logger.LogInformation("Information - Flujo general de la aplicación");
_logger.LogWarning("Warning - Eventos inesperados pero manejables");
_logger.LogError("Error - Errores y excepciones");
_logger.LogCritical("Critical - Fallos críticos que requieren atención inmediata");
```

#### Ejemplo Básico

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
        
        try
        {
            var user = _userService.GetUser(id);
            _logger.LogInformation("User retrieved successfully: {UserId}", id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving user {UserId}", id);
            return StatusCode(500, "Internal server error");
        }
    }
}
```

**💡 Perfecto para:** Aplicaciones pequeñas o herramientas internas que solo necesitan visibilidad básica.

**👉 Ejemplo:** Cuando un controlador falla, `ILogger` registra dónde y por qué, ayudándote a depurar rápidamente.

### 2️⃣ Serilog — Structured & Powerful Logging ✅

Serilog trae logging estructurado, lo que significa que los logs se almacenan como pares clave-valor, no como texto plano.

#### Características

- ✅ **Structured Logging**: Logs como pares clave-valor, no texto plano
- ✅ **Búsqueda Fácil**: "Encuentra todas las peticiones donde response time > 2 segundos"
- ✅ **Múltiples Sinks**: Console, File, Seq, Elasticsearch, Application Insights, etc.
- ✅ **Rich Querying**: Consultas complejas sobre logs estructurados
- ✅ **Performance**: Optimizado para alto rendimiento

#### Ejemplo de Log Estructurado

```csharp
// ❌ ANTES: Logging plano (difícil de buscar)
_logger.LogInformation($"User {userId} performed {action} in {duration}ms");

// ✅ DESPUÉS: Logging estructurado (fácil de buscar y filtrar)
_logger.LogInformation(
    "User {UserId} performed {Action} in {Duration}ms",
    userId, action, duration);
```

**Ejemplo de Output:**
```json
{
  "Timestamp": "2024-01-15T10:30:00Z",
  "Level": "Information",
  "Message": "User 101 performed Checkout in 1800ms",
  "UserId": 101,
  "Action": "Checkout",
  "Duration": 1800
}
```

Esto hace que filtrar y monitorear sea sencillo.

#### Configuración de Serilog

```csharp
// Program.cs
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configurar Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

app.Run();
```

#### Ejemplo con Serilog

```csharp
public class OrderService
{
    private readonly ILogger<OrderService> _logger;
    
    public OrderService(ILogger<OrderService> logger)
    {
        _logger = logger;
    }
    
    public async Task<Order> ProcessOrderAsync(Order order)
    {
        _logger.LogInformation(
            "Processing order {OrderId} for user {UserId}",
            order.Id, order.UserId);
        
        var stopwatch = Stopwatch.StartNew();
        
        try
        {
            // Procesar orden
            await _orderRepository.SaveAsync(order);
            
            stopwatch.Stop();
            _logger.LogInformation(
                "Order {OrderId} processed successfully in {Duration}ms",
                order.Id, stopwatch.ElapsedMilliseconds);
            
            return order;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Error processing order {OrderId} for user {UserId}",
                order.Id, order.UserId);
            throw;
        }
    }
}
```

**💡 Ideal para:** Sistemas de producción que requieren insights ricos y consultables.

### 3️⃣ NLog — Simple, Fast & Flexible ✅

NLog es logging estructurado ligero con configuración mínima.

#### Características

- ✅ **Ligero**: Configuración mínima requerida
- ✅ **Rápido**: Conocido por su velocidad
- ✅ **Flexible**: Soporta múltiples destinos
- ✅ **Múltiples Targets**: Archivos, bases de datos, email, event logs
- ✅ **Configuración XML**: Configuración simple mediante archivos XML

#### Configuración de NLog

```xml
<!-- nlog.config -->
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd">
  <targets>
    <target xsi:type="File" name="fileTarget"
            fileName="logs/app.log"
            layout="${longdate} ${level} ${message} ${exception}" />
    <target xsi:type="Console" name="consoleTarget"
            layout="${longdate} ${level} ${message} ${exception}" />
  </targets>
  <rules>
    <logger name="*" minlevel="Info" writeTo="fileTarget,consoleTarget" />
  </rules>
</nlog>
```

```csharp
// Program.cs
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Configurar NLog
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

app.Run();
```

#### Ejemplo con NLog

```csharp
public class PaymentService
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    
    public async Task ProcessPaymentAsync(Payment payment)
    {
        Logger.Info("Processing payment {PaymentId} for amount {Amount}",
            payment.Id, payment.Amount);
        
        try
        {
            // Procesar pago
            await _paymentGateway.ProcessAsync(payment);
            
            Logger.Info("Payment {PaymentId} processed successfully", payment.Id);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Error processing payment {PaymentId}", payment.Id);
            throw;
        }
    }
}
```

**💡 Si el rendimiento y la simplicidad son prioridades principales, NLog es una excelente opción.**

## 📊 Comparación de Opciones

| Característica | Built-in ILogger | Serilog | NLog |
|----------------|------------------|---------|------|
| **Setup** | ✅ Out-of-the-box | ⚠️ Requiere configuración | ⚠️ Requiere configuración |
| **Structured Logging** | ⚠️ Básico | ✅ Completo | ✅ Completo |
| **Performance** | ✅ Excelente | ✅ Excelente | ✅ Muy rápido |
| **Sinks/Targets** | ⚠️ Limitado | ✅ Múltiples | ✅ Múltiples |
| **Búsqueda** | ❌ Limitada | ✅ Avanzada | ✅ Avanzada |
| **Ideal Para** | Apps pequeñas | Producción | Background services |

## ✅ Mejores Prácticas para Logging Como un Pro

### 1. Preferir Logs Estructurados sobre Texto Plano

```csharp
// ❌ MAL: Logging plano (difícil de buscar)
_logger.LogInformation($"User {userId} performed {action}");

// ✅ BIEN: Logging estructurado (fácil de buscar)
_logger.LogInformation("User {UserId} performed {Action}", userId, action);
```

### 2. Mantener Formatos de Log Consistentes

```csharp
// ✅ BIEN: Formato consistente en toda la aplicación
_logger.LogInformation("Order {OrderId} created by user {UserId} at {Timestamp}",
    orderId, userId, DateTime.UtcNow);

_logger.LogInformation("Order {OrderId} shipped to {Address}",
    orderId, address);
```

### 3. Nunca Registrar Información Sensible

```csharp
// ❌ MAL: Registrar información sensible
_logger.LogInformation("User {UserId} logged in with password {Password}",
    userId, password);

// ✅ BIEN: No registrar información sensible
_logger.LogInformation("User {UserId} logged in successfully", userId);
```

**Información que NUNCA debes registrar:**
- ❌ Contraseñas
- ❌ Tokens de autenticación
- ❌ Números de tarjetas de crédito
- ❌ Información personal sensible (SSN, etc.)
- ❌ Claves de API

### 4. Centralizar Logs

```csharp
// ✅ BIEN: Centralizar logs usando Seq, Kibana, o Azure Monitor
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq("http://seq-server:5341")  // Centralizado
    .WriteTo.AzureAnalytics(workspaceId, authenticationId)  // Azure Monitor
    .CreateLogger();
```

### 5. Usar Niveles de Log Sabiamente

```csharp
// ✅ BIEN: Usar niveles apropiados
_logger.LogTrace("Entering method ProcessOrder");  // Muy detallado
_logger.LogDebug("Order validation passed");  // Depuración
_logger.LogInformation("Order {OrderId} created", orderId);  // Flujo normal
_logger.LogWarning("Order {OrderId} has low stock", orderId);  // Advertencia
_logger.LogError(ex, "Error processing order {OrderId}", orderId);  // Error
_logger.LogCritical(ex, "Database connection lost");  // Crítico
```

**Guía de Niveles:**
- **Trace**: Información muy detallada (solo desarrollo)
- **Debug**: Información de depuración (solo desarrollo)
- **Information**: Flujo general de la aplicación
- **Warning**: Eventos inesperados pero manejables
- **Error**: Errores y excepciones
- **Critical**: Fallos críticos que requieren atención inmediata

### 6. Incluir Contexto en los Logs

```csharp
// ✅ BIEN: Incluir contexto relevante
_logger.LogInformation(
    "Processing order {OrderId} for user {UserId} with {ItemCount} items",
    order.Id, order.UserId, order.Items.Count);
```

### 7. Usar Logging Scopes para Contexto

```csharp
// ✅ BIEN: Usar scopes para agregar contexto
using (_logger.BeginScope("OrderId: {OrderId}", orderId))
{
    _logger.LogInformation("Starting order processing");
    // Todos los logs dentro de este scope incluirán OrderId
    _logger.LogInformation("Validating order items");
    _logger.LogInformation("Calculating total");
}
```

## 🎯 Cuándo Usar Cada Opción

### ✅ Usa Built-in ILogger cuando:

- Tienes una aplicación pequeña o interna
- No necesitas logging estructurado avanzado
- Quieres algo que funcione sin configuración
- Estás empezando con .NET Core

### ✅ Usa Serilog cuando:

- Necesitas logging estructurado completo
- Quieres múltiples sinks (Seq, Elasticsearch, etc.)
- Necesitas búsqueda avanzada de logs
- Estás construyendo sistemas de producción complejos

### ✅ Usa NLog cuando:

- Priorizas rendimiento y simplicidad
- Trabajas con background services
- Migras aplicaciones legacy
- Necesitas configuración flexible

## 📚 Ejemplos Prácticos

### Ejemplo 1: Logging en Controladores

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserService _userService;
    
    public UsersController(ILogger<UsersController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        _logger.LogInformation("Getting user {UserId}", id);
        
        try
        {
            var user = await _userService.GetUserAsync(id);
            
            if (user == null)
            {
                _logger.LogWarning("User {UserId} not found", id);
                return NotFound();
            }
            
            _logger.LogInformation("User {UserId} retrieved successfully", id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving user {UserId}", id);
            return StatusCode(500, "Internal server error");
        }
    }
}
```

### Ejemplo 2: Logging con Scopes

```csharp
public class OrderService
{
    private readonly ILogger<OrderService> _logger;
    
    public async Task ProcessOrderAsync(Order order)
    {
        using (_logger.BeginScope("OrderId: {OrderId}, UserId: {UserId}",
            order.Id, order.UserId))
        {
            _logger.LogInformation("Starting order processing");
            
            await ValidateOrderAsync(order);
            await CalculateTotalAsync(order);
            await SaveOrderAsync(order);
            
            _logger.LogInformation("Order processing completed");
        }
    }
}
```

### Ejemplo 3: Logging Estructurado con Serilog

```csharp
public class PaymentService
{
    private readonly ILogger<PaymentService> _logger;
    
    public async Task ProcessPaymentAsync(Payment payment)
    {
        _logger.LogInformation(
            "Processing payment {PaymentId} for amount {Amount} by user {UserId}",
            payment.Id, payment.Amount, payment.UserId);
        
        var stopwatch = Stopwatch.StartNew();
        
        try
        {
            await _paymentGateway.ProcessAsync(payment);
            
            stopwatch.Stop();
            _logger.LogInformation(
                "Payment {PaymentId} processed successfully in {Duration}ms",
                payment.Id, stopwatch.ElapsedMilliseconds);
        }
        catch (PaymentException ex)
        {
            _logger.LogWarning(ex,
                "Payment {PaymentId} failed: {Reason}",
                payment.Id, ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Unexpected error processing payment {PaymentId}",
                payment.Id);
            throw;
        }
    }
}
```

## 🎯 Resumen

### ✅ Logging en .NET Core

**Características Clave:**
- ✅ Built-in ILogger: Ligero, flexible, out-of-the-box
- ✅ Serilog: Structured logging completo con múltiples sinks
- ✅ NLog: Simple, rápido y flexible

**Mejores Prácticas:**
- ✅ Preferir logs estructurados sobre texto plano
- ✅ Mantener formatos consistentes
- ✅ Nunca registrar información sensible
- ✅ Centralizar logs
- ✅ Usar niveles de log sabiamente
- ✅ Incluir contexto en los logs

**Cuándo Usar:**
- ✅ **Built-in ILogger**: Apps pequeñas, herramientas internas
- ✅ **Serilog**: Sistemas de producción complejos
- ✅ **NLog**: Background services, prioridad en rendimiento

**Instalación:**

**Serilog:**
```bash
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
dotnet add package Serilog.Sinks.Seq
```

**NLog:**
```bash
dotnet add package NLog.Web.AspNetCore
```

---

## 📚 Recursos Adicionales

- [Microsoft Docs - Logging in .NET](https://learn.microsoft.com/dotnet/core/extensions/logging)
- [Serilog Documentation](https://serilog.net/)
- [NLog Documentation](https://nlog-project.org/)
- [Seq - Structured Logging](https://datalust.co/seq)

