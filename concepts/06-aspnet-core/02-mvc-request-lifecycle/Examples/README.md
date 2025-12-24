# Ejemplos Prácticos - ASP.NET Core MVC Request Life Cycle

Esta carpeta contiene ejemplos ejecutables que demuestran el ciclo de vida completo de una petición HTTP en ASP.NET Core MVC.

## Archivos

### `MvcRequestLifecycleExamples.cs`
Demostraciones prácticas del Request Life Cycle:
- `DemonstrateRequestLifecycle()` - Visión general del ciclo completo
- `DemonstrateMiddlewarePipeline()` - Pipeline de middleware
- `DemonstrateRouting()` - Sistema de routing
- `DemonstrateControllerInitialization()` - Inicialización de controladores
- `DemonstrateActionExecution()` - Ejecución de métodos de acción
- `DemonstrateResultExecution()` - Ejecución de resultados
- `DemonstrateViewRendering()` - Renderizado de vistas
- `DemonstrateWhyItMatters()` - Por qué importa entender el ciclo de vida
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Request Life Cycle
```

## Conceptos Clave

- **Middleware Pipeline**: Primera parada, filtrado y procesamiento
- **Routing**: Dirección al controlador y acción correctos
- **Controller Initialization**: Instanciación con dependencias
- **Action Method Execution**: Ejecución de lógica de negocio
- **Result Execution**: Procesamiento del resultado
- **View Rendering**: Conversión de datos a HTML (MVC)
- **Response**: Respuesta final al cliente

## Ejemplo Básico: Flujo Completo

```
HTTP Request
    ↓
Middleware Pipeline (Security, Logging, etc.)
    ↓
Routing (URL → Controller/Action)
    ↓
Controller Initialization (DI)
    ↓
Action Method Execution (Business Logic)
    ↓
Result Execution (Data or View Model)
    ↓
View Rendering (HTML generation)
    ↓
Response
```

## Ejemplo: Middleware Pipeline

```csharp
app.UseExceptionHandler();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
```

## Ejemplo: Controller con DI

```csharp
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }
}
```

## Notas

- Los ejemplos muestran claramente cada etapa del ciclo de vida
- Se incluyen ejemplos prácticos de código
- Se explica por qué entender el ciclo de vida es importante
- Se demuestran mejores prácticas y errores comunes

## Requisitos

- .NET 6.0 o superior
- Conocimientos básicos de ASP.NET Core MVC

