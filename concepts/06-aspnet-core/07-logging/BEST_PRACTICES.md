# Mejores Prácticas: Logging en .NET Core

## ✅ Reglas de Oro

### 1. Preferir Logs Estructurados sobre Texto Plano

```csharp
// ❌ MAL: Logging plano (difícil de buscar)
_logger.LogInformation($"User {userId} performed {action} in {duration}ms");

// ✅ BIEN: Logging estructurado (fácil de buscar)
_logger.LogInformation(
    "User {UserId} performed {Action} in {Duration}ms",
    userId, action, duration);
```

**Ventajas:**
- ✅ Fácil de buscar y filtrar
- ✅ Permite análisis avanzado
- ✅ Compatible con herramientas de logging estructurado

### 2. Mantener Formatos de Log Consistentes

```csharp
// ✅ BIEN: Formato consistente en toda la aplicación
_logger.LogInformation("Order {OrderId} created by user {UserId} at {Timestamp}",
    orderId, userId, DateTime.UtcNow);

_logger.LogInformation("Order {OrderId} shipped to {Address}",
    orderId, address);
```

**Ventajas:**
- ✅ Fácil de entender y analizar
- ✅ Permite búsquedas consistentes
- ✅ Facilita el mantenimiento

### 3. Nunca Registrar Información Sensible

```csharp
// ❌ MAL: Registrar información sensible
_logger.LogInformation("User {UserId} logged in with password {Password}",
    userId, password);

_logger.LogInformation("Processing payment with card {CardNumber}",
    cardNumber);

// ✅ BIEN: No registrar información sensible
_logger.LogInformation("User {UserId} logged in successfully", userId);

_logger.LogInformation("Processing payment {PaymentId}",
    paymentId);
```

**Información que NUNCA debes registrar:**
- ❌ Contraseñas
- ❌ Tokens de autenticación (JWT, API keys)
- ❌ Números de tarjetas de crédito completos
- ❌ Información personal sensible (SSN, números de identificación)
- ❌ Claves de API o secretos
- ❌ Datos biométricos

### 4. Centralizar Logs

```csharp
// ✅ BIEN: Centralizar logs usando Seq, Kibana, o Azure Monitor
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq("http://seq-server:5341")  // Centralizado
    .WriteTo.AzureAnalytics(workspaceId, authenticationId)  // Azure Monitor
    .CreateLogger();
```

**Ventajas:**
- ✅ Visibilidad centralizada
- ✅ Búsqueda y análisis avanzados
- ✅ Alertas y monitoreo

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

| Nivel | Cuándo Usar | Ejemplo |
|-------|-------------|---------|
| **Trace** | Información muy detallada (solo desarrollo) | "Entering method X" |
| **Debug** | Información de depuración (solo desarrollo) | "Validation passed" |
| **Information** | Flujo general de la aplicación | "Order created" |
| **Warning** | Eventos inesperados pero manejables | "Low stock warning" |
| **Error** | Errores y excepciones | "Failed to process order" |
| **Critical** | Fallos críticos que requieren atención inmediata | "Database connection lost" |

### 6. Incluir Contexto en los Logs

```csharp
// ✅ BIEN: Incluir contexto relevante
_logger.LogInformation(
    "Processing order {OrderId} for user {UserId} with {ItemCount} items",
    order.Id, order.UserId, order.Items.Count);
```

**Contexto Útil:**
- ✅ IDs de entidades (OrderId, UserId, etc.)
- ✅ Acciones realizadas (Action, Operation)
- ✅ Métricas de rendimiento (Duration, ResponseTime)
- ✅ Estados (Status, Result)
- ✅ Timestamps (cuando sea relevante)

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

**Ventajas:**
- ✅ Contexto automático en múltiples logs
- ✅ Reduce repetición de parámetros
- ✅ Facilita el seguimiento de operaciones

## ⚠️ Consideraciones Importantes

### 1. Performance

Demasiados logs pueden ralentizar tu aplicación:

```csharp
// ❌ MAL: Logging excesivo en loops
foreach (var item in items)
{
    _logger.LogDebug("Processing item {ItemId}", item.Id);  // Puede ser muy lento
}

// ✅ BIEN: Logging resumido
_logger.LogInformation("Processing {ItemCount} items", items.Count);
```

### 2. Log Levels en Producción

```csharp
// ✅ BIEN: Configurar niveles apropiados por ambiente
if (app.Environment.IsDevelopment())
{
    builder.Logging.SetMinimumLevel(LogLevel.Debug);
}
else
{
    builder.Logging.SetMinimumLevel(LogLevel.Information);
}
```

### 3. Manejo de Excepciones

```csharp
// ✅ BIEN: Incluir excepciones en logs de error
try
{
    await ProcessOrderAsync(order);
}
catch (Exception ex)
{
    _logger.LogError(ex, "Error processing order {OrderId}", order.Id);
    throw;
}
```

## 🎯 Casos de Uso Específicos

### 1. Logging en Controladores

```csharp
// ✅ BIEN: Logging completo en controladores
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        _logger.LogInformation(
            "Creating order for user {UserId} with {ItemCount} items",
            request.UserId, request.Items.Count);
        
        try
        {
            var order = await _orderService.CreateOrderAsync(request);
            
            _logger.LogInformation(
                "Order {OrderId} created successfully for user {UserId}",
                order.Id, request.UserId);
            
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }
        catch (ValidationException ex)
        {
            _logger.LogWarning(ex, "Validation failed for order creation by user {UserId}",
                request.UserId);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating order for user {UserId}",
                request.UserId);
            return StatusCode(500, "Internal server error");
        }
    }
}
```

### 2. Logging con Métricas de Rendimiento

```csharp
// ✅ BIEN: Incluir métricas de rendimiento
public async Task<Order> ProcessOrderAsync(Order order)
{
    var stopwatch = Stopwatch.StartNew();
    
    _logger.LogInformation("Starting order processing for order {OrderId}",
        order.Id);
    
    try
    {
        await ValidateOrderAsync(order);
        await CalculateTotalAsync(order);
        await SaveOrderAsync(order);
        
        stopwatch.Stop();
        _logger.LogInformation(
            "Order {OrderId} processed successfully in {Duration}ms",
            order.Id, stopwatch.ElapsedMilliseconds);
        
        return order;
    }
    catch (Exception ex)
    {
        stopwatch.Stop();
        _logger.LogError(ex,
            "Order {OrderId} processing failed after {Duration}ms",
            order.Id, stopwatch.ElapsedMilliseconds);
        throw;
    }
}
```

### 3. Logging Estructurado con Serilog

```csharp
// ✅ BIEN: Logging estructurado completo
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
```

## 📊 Tabla de Decisión

| Escenario | Built-in ILogger | Serilog | NLog |
|-----------|------------------|---------|------|
| App pequeña/interna | ✅ | ❌ | ❌ |
| Producción compleja | ⚠️ | ✅ | ⚠️ |
| Background services | ⚠️ | ⚠️ | ✅ |
| Necesitas Seq/Elasticsearch | ❌ | ✅ | ⚠️ |
| Prioridad en velocidad | ✅ | ✅ | ✅ |
| Configuración mínima | ✅ | ❌ | ❌ |

## 💡 Pro Tips

### 1. Usar Logging Scopes para Operaciones Complejas

```csharp
// ✅ BIEN: Scope para operaciones complejas
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
```

### 2. Filtrar Logs por Categoría

```csharp
// ✅ BIEN: Filtrar logs por categoría
builder.Logging.AddFilter("Microsoft", LogLevel.Warning);
builder.Logging.AddFilter("System", LogLevel.Warning);
builder.Logging.AddFilter("MyApp", LogLevel.Information);
```

### 3. Usar Logging para Auditoría

```csharp
// ✅ BIEN: Logging para auditoría
_logger.LogInformation(
    "User {UserId} performed {Action} on {ResourceType} {ResourceId}",
    userId, action, resourceType, resourceId);
```

### 4. Configurar Logging por Ambiente

```csharp
// ✅ BIEN: Configuración por ambiente
if (app.Environment.IsDevelopment())
{
    builder.Logging.AddConsole();
    builder.Logging.AddDebug();
}
else
{
    builder.Logging.AddApplicationInsights();
    builder.Logging.AddEventLog();
}
```

## 🚫 Errores Comunes a Evitar

### 1. Logging Excesivo

```csharp
// ❌ MAL: Logging excesivo en loops
foreach (var item in items)
{
    _logger.LogDebug("Processing item {ItemId}", item.Id);
}

// ✅ BIEN: Logging resumido
_logger.LogInformation("Processing {ItemCount} items", items.Count);
```

### 2. Registrar Información Sensible

```csharp
// ❌ MAL: Registrar información sensible
_logger.LogInformation("User {UserId} password: {Password}", userId, password);

// ✅ BIEN: No registrar información sensible
_logger.LogInformation("User {UserId} logged in", userId);
```

### 3. No Incluir Excepciones

```csharp
// ❌ MAL: No incluir excepción
_logger.LogError("Error processing order");

// ✅ BIEN: Incluir excepción
_logger.LogError(ex, "Error processing order {OrderId}", orderId);
```

### 4. Logging en Nivel Incorrecto

```csharp
// ❌ MAL: Usar nivel incorrecto
_logger.LogError("User logged in");  // Debería ser Information

// ✅ BIEN: Usar nivel apropiado
_logger.LogInformation("User {UserId} logged in", userId);
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Logging in .NET](https://learn.microsoft.com/dotnet/core/extensions/logging)
- [Serilog Documentation](https://serilog.net/)
- [NLog Documentation](https://nlog-project.org/)
- [Seq - Structured Logging](https://datalust.co/seq)

