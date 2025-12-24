# Mejores Prácticas: ASP.NET Core MVC Request Life Cycle

## ✅ Reglas de Oro

### 1. Middleware Order Matters

```csharp
// ✅ BIEN: Orden correcto de middleware
app.UseExceptionHandler();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
```

### 2. Use Dependency Injection en Controladores

```csharp
// ✅ BIEN: DI en controladores
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ILogger<OrdersController> _logger;
    
    public OrdersController(
        IOrderService orderService,
        ILogger<OrdersController> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }
}

// ❌ MAL: Crear instancias directamente
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService = new OrderService(); // ❌
}
```

### 3. Proper Error Handling

```csharp
// ✅ BIEN: Manejo de errores apropiado
public IActionResult GetOrder(int id)
{
    try
    {
        var order = _orderService.GetOrderById(id);
        return order == null ? NotFound() : Ok(order);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error getting order {OrderId}", id);
        return StatusCode(500, "Internal server error");
    }
}

// ❌ MAL: Dejar excepciones sin manejar
public IActionResult GetOrder(int id)
{
    var order = _orderService.GetOrderById(id); // ❌ Puede lanzar excepción
    return Ok(order);
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Middleware en Orden Incorrecto

```csharp
// ❌ MAL: Orden incorrecto
app.UseRouting();
app.UseAuthentication(); // ❌ Debe estar después de UseRouting
app.UseAuthorization();
app.UseStaticFiles(); // ❌ Debe estar antes de UseRouting

// ✅ BIEN: Orden correcto
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
```

### 2. No Validar ModelState

```csharp
// ❌ MAL: No validar ModelState
[HttpPost]
public IActionResult CreateOrder(CreateOrderDto dto)
{
    var order = _orderService.CreateOrder(dto); // ❌ Puede tener datos inválidos
    return Ok(order);
}

// ✅ BIEN: Validar ModelState
[HttpPost]
public IActionResult CreateOrder(CreateOrderDto dto)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
    
    var order = _orderService.CreateOrder(dto);
    return Ok(order);
}
```

### 3. No Usar Async/Await Correctamente

```csharp
// ❌ MAL: Bloquear threads
public IActionResult GetOrders()
{
    var orders = _orderService.GetOrdersAsync().Result; // ❌ Bloquea thread
    return Ok(orders);
}

// ✅ BIEN: Async/await
public async Task<IActionResult> GetOrders()
{
    var orders = await _orderService.GetOrdersAsync();
    return Ok(orders);
}
```

## 🎯 Casos de Uso Específicos

### 1. API Controller Completo

```csharp
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ILogger<OrdersController> _logger;
    
    public OrdersController(
        IOrderService orderService,
        ILogger<OrdersController> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var order = await _orderService.CreateOrderAsync(dto);
        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }
}
```

### 2. MVC Controller con View

```csharp
public class HomeController : Controller
{
    private readonly IProductService _productService;
    
    public HomeController(IProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetFeaturedProductsAsync();
        var model = new HomeViewModel
        {
            FeaturedProducts = products
        };
        
        return View(model);
    }
}
```

### 3. Custom Middleware

```csharp
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;
    
    public RequestLoggingMiddleware(
        RequestDelegate next,
        ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Request: {Method} {Path}", 
            context.Request.Method, 
            context.Request.Path);
        
        await _next(context);
        
        _logger.LogInformation("Response: {StatusCode}", 
            context.Response.StatusCode);
    }
}
```

## 🚀 Tips Avanzados

### 1. Action Filters para Cross-Cutting Concerns

```csharp
public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}

// Uso
[ValidateModel]
[HttpPost]
public IActionResult CreateOrder(CreateOrderDto dto)
{
    // ModelState ya está validado
    var order = _orderService.CreateOrder(dto);
    return Ok(order);
}
```

### 2. Result Filters para Transformar Respuestas

```csharp
public class ResponseWrapperAttribute : ResultFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is ObjectResult objectResult)
        {
            var wrapped = new ApiResponse
            {
                Success = true,
                Data = objectResult.Value
            };
            context.Result = new ObjectResult(wrapped);
        }
    }
}
```

### 3. Custom Model Binders

```csharp
public class CustomDateModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }
        
        var value = valueProviderResult.FirstValue;
        
        if (DateTime.TryParse(value, out var date))
        {
            bindingContext.Result = ModelBindingResult.Success(date);
        }
        
        return Task.CompletedTask;
    }
}
```

## 📊 Tabla de Decisión: Cuándo Usar Cada Tipo de Result

| Tipo de Result | Cuándo Usar | Ejemplo |
|----------------|-------------|---------|
| **Ok()** | Respuesta exitosa con datos | `return Ok(order);` |
| **CreatedAtAction()** | Recurso creado | `return CreatedAtAction(nameof(GetOrder), new { id }, order);` |
| **NotFound()** | Recurso no encontrado | `return NotFound();` |
| **BadRequest()** | Solicitud inválida | `return BadRequest(ModelState);` |
| **View()** | Renderizar vista MVC | `return View(model);` |
| **RedirectToAction()** | Redirección | `return RedirectToAction("Index");` |
| **File()** | Retornar archivo | `return File(bytes, "application/pdf");` |

## 💡 Pro Tips

### 1. Siempre Usar Async/Await en I/O Operations

```csharp
// ✅ BIEN: Async para operaciones I/O
public async Task<IActionResult> GetOrders()
{
    var orders = await _orderService.GetOrdersAsync();
    return Ok(orders);
}
```

### 2. Usar ActionResult<T> para Type Safety

```csharp
// ✅ BIEN: ActionResult<T> para type safety
[HttpGet("{id}")]
public async Task<ActionResult<OrderDto>> GetOrder(int id)
{
    var order = await _orderService.GetOrderByIdAsync(id);
    return order == null ? NotFound() : order;
}
```

### 3. Logging en Puntos Clave

```csharp
public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
{
    _logger.LogInformation("Creating order for customer {CustomerId}", dto.CustomerId);
    
    try
    {
        var order = await _orderService.CreateOrderAsync(dto);
        _logger.LogInformation("Order {OrderId} created successfully", order.Id);
        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error creating order");
        return StatusCode(500, "Internal server error");
    }
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - ASP.NET Core Fundamentals](https://docs.microsoft.com/aspnet/core/fundamentals/)
- [Microsoft Docs - Routing](https://docs.microsoft.com/aspnet/core/fundamentals/routing)
- [Microsoft Docs - Controllers](https://docs.microsoft.com/aspnet/core/mvc/controllers/)
- [Microsoft Docs - Model Binding](https://docs.microsoft.com/aspnet/core/mvc/models/model-binding)

