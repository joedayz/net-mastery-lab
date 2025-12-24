# APIs Mínimas Mejoradas en ASP.NET Core 🔹

## Introducción

Las **Minimal APIs** son una característica de ASP.NET Core que permite crear aplicaciones web ligeras y de alto rendimiento con menos código repetitivo. Introducidas en .NET 6, han sido mejoradas continuamente en versiones posteriores para ofrecer mejor enrutamiento, inyección de dependencias optimizada y mejoras de rendimiento.

## 🎯 ¿Qué son las Minimal APIs?

Las Minimal APIs permiten crear endpoints HTTP con código mínimo, sin necesidad de controladores tradicionales. Son ideales para microservicios, APIs simples y aplicaciones de alto rendimiento.

### Comparación: Minimal APIs vs Controllers

```csharp
// ❌ ANTES: Controller tradicional
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return user == null ? NotFound() : Ok(user);
    }
}

// ✅ DESPUÉS: Minimal API
app.MapGet("/api/users/{id}", async (int id, IUserService userService) =>
{
    var user = await userService.GetUserByIdAsync(id);
    return user == null ? Results.NotFound() : Results.Ok(user);
});
```

## ✅ Beneficios de las Minimal APIs

### 1. Menos Código Boilerplate

```csharp
// ✅ Minimal API: Código conciso
app.MapGet("/hello", () => "Hello, World!");

// ❌ Controller: Más código necesario
[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("Hello, World!");
}
```

### 2. Mejor Rendimiento

- **Menos Overhead**: Sin la infraestructura completa de MVC
- **Inicio Más Rápido**: Menos código para cargar
- **Menor Consumo de Memoria**: Estructura más ligera

### 3. Inyección de Dependencias Optimizada

```csharp
// ✅ BIEN: DI automática en parámetros
app.MapGet("/users/{id}", async (
    int id,
    IUserService userService,
    ILogger<Program> logger) =>
{
    logger.LogInformation("Getting user {UserId}", id);
    var user = await userService.GetUserByIdAsync(id);
    return user == null ? Results.NotFound() : Results.Ok(user);
});
```

## 🛠️ Características Principales

### 1. Enrutamiento Mejorado

```csharp
// ✅ BIEN: Enrutamiento con parámetros
app.MapGet("/users/{id:int}", (int id) => GetUser(id));
app.MapGet("/users/{id:int}/orders", (int id) => GetUserOrders(id));

// ✅ BIEN: Enrutamiento con constraints
app.MapGet("/users/{id:int:min(1)}", (int id) => GetUser(id));
app.MapGet("/products/{slug:regex(^[a-z0-9-]+$)}", (string slug) => GetProduct(slug));
```

### 2. Tipos de Resultados Mejorados

```csharp
// ✅ BIEN: Results helper class
app.MapGet("/users/{id}", (int id) =>
{
    var user = GetUser(id);
    return user == null 
        ? Results.NotFound() 
        : Results.Ok(user);
});

// ✅ BIEN: Tipos específicos de resultado
app.MapGet("/users/{id}", (int id) =>
{
    var user = GetUser(id);
    if (user == null)
        return Results.NotFound(new { Message = "User not found" });
    
    return Results.Ok(user);
});
```

### 3. Validación Integrada

```csharp
// ✅ BIEN: Validación con Data Annotations
public record CreateUserRequest(
    [Required] [MinLength(3)] string Name,
    [Required] [EmailAddress] string Email,
    [Range(18, 120)] int Age
);

app.MapPost("/users", (CreateUserRequest request) =>
{
    // La validación se ejecuta automáticamente
    return Results.Created($"/users/{request.Name}", request);
});
```

### 4. Filtros y Middleware

```csharp
// ✅ BIEN: Filtros en Minimal APIs
app.MapGet("/users/{id}", (int id) => GetUser(id))
    .AddEndpointFilter(async (context, next) =>
    {
        var logger = context.HttpContext.RequestServices
            .GetRequiredService<ILogger<Program>>();
        
        logger.LogInformation("Executing endpoint");
        var result = await next(context);
        logger.LogInformation("Endpoint executed");
        return result;
    });
```

## 📊 Ejemplos Prácticos

### Ejemplo 1: API REST Completa

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// GET /users
app.MapGet("/users", async (IUserService userService) =>
{
    var users = await userService.GetAllUsersAsync();
    return Results.Ok(users);
});

// GET /users/{id}
app.MapGet("/users/{id:int}", async (int id, IUserService userService) =>
{
    var user = await userService.GetUserByIdAsync(id);
    return user == null ? Results.NotFound() : Results.Ok(user);
});

// POST /users
app.MapPost("/users", async (CreateUserRequest request, IUserService userService) =>
{
    var user = await userService.CreateUserAsync(request);
    return Results.Created($"/users/{user.Id}", user);
});

// PUT /users/{id}
app.MapPut("/users/{id:int}", async (
    int id,
    UpdateUserRequest request,
    IUserService userService) =>
{
    var updated = await userService.UpdateUserAsync(id, request);
    return updated ? Results.NoContent() : Results.NotFound();
});

// DELETE /users/{id}
app.MapDelete("/users/{id:int}", async (int id, IUserService userService) =>
{
    var deleted = await userService.DeleteUserAsync(id);
    return deleted ? Results.NoContent() : Results.NotFound();
});

app.Run();
```

### Ejemplo 2: Con Autenticación y Autorización

```csharp
app.MapGet("/users/{id}", (int id) => GetUser(id))
    .RequireAuthorization();

app.MapGet("/admin/users", (IUserService userService) => GetAllUsers(userService))
    .RequireAuthorization(policy => policy.RequireRole("Admin"));
```

### Ejemplo 3: Con Rate Limiting

```csharp
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.Window = TimeSpan.FromSeconds(10);
        opt.PermitLimit = 5;
    });
});

app.UseRateLimiter();

app.MapGet("/api/data", () => GetData())
    .RequireRateLimiting("fixed");
```

## 💡 Mejores Prácticas

### 1. Usar Minimal APIs para Endpoints Simples

```csharp
// ✅ BIEN: Minimal API para endpoint simple
app.MapGet("/health", () => Results.Ok(new { Status = "Healthy" }));

// ⚠️ CONSIDERAR: Controller para lógica compleja
// Si tienes múltiples acciones relacionadas, considera un controller
```

### 2. Agrupar Endpoints Relacionados

```csharp
// ✅ BIEN: Agrupar endpoints relacionados
var usersApi = app.MapGroup("/api/users");
usersApi.MapGet("/", GetAllUsers);
usersApi.MapGet("/{id}", GetUser);
usersApi.MapPost("/", CreateUser);
usersApi.MapPut("/{id}", UpdateUser);
usersApi.MapDelete("/{id}", DeleteUser);
```

### 3. Usar Tipos de Retorno Explícitos

```csharp
// ✅ BIEN: Tipo de retorno explícito
app.MapGet("/users/{id}", async (int id, IUserService service) =>
    await service.GetUserByIdAsync(id) is User user
        ? Results.Ok(user)
        : Results.NotFound());
```

### 4. Validación y Manejo de Errores

```csharp
// ✅ BIEN: Validación y manejo de errores
app.MapPost("/users", async (CreateUserRequest request, IUserService service) =>
{
    try
    {
        var user = await service.CreateUserAsync(request);
        return Results.Created($"/users/{user.Id}", user);
    }
    catch (ValidationException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});
```

## ⚠️ Cuándo NO Usar Minimal APIs

### 1. Lógica Compleja de Negocio

```csharp
// ❌ MAL: Lógica compleja en Minimal API
app.MapPost("/orders", async (CreateOrderRequest request) =>
{
    // 100+ líneas de lógica compleja
    // Mejor usar Controller o Service
});

// ✅ BIEN: Delegar a servicio
app.MapPost("/orders", async (CreateOrderRequest request, IOrderService service) =>
    await service.CreateOrderAsync(request));
```

### 2. Múltiples Acciones Relacionadas

```csharp
// ❌ MAL: Muchos endpoints relacionados como Minimal APIs
app.MapGet("/users", ...);
app.MapGet("/users/{id}", ...);
app.MapPost("/users", ...);
app.MapPut("/users/{id}", ...);
app.MapDelete("/users/{id}", ...);
app.MapGet("/users/{id}/orders", ...);
app.MapGet("/users/{id}/profile", ...);
// ... muchos más

// ✅ BIEN: Usar Controller para agrupar
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase { }
```

## 📊 Comparación: Minimal APIs vs Controllers

| Característica | Minimal APIs | Controllers |
|----------------|--------------|-------------|
| **Código** | Mínimo | Más verboso |
| **Rendimiento** | Mejor | Bueno |
| **Complejidad** | Simple | Más estructura |
| **Escalabilidad** | Limitada | Excelente |
| **Testing** | Más simple | Más completo |
| **Uso Ideal** | Microservicios, APIs simples | Aplicaciones complejas |

## 🎯 Casos de Uso Ideales

### ✅ Usar Minimal APIs cuando:
- Creas microservicios pequeños
- Necesitas endpoints simples y directos
- Priorizas rendimiento y simplicidad
- Tienes pocos endpoints relacionados
- Construyes APIs de prototipo rápido

### ⚠️ Considerar Controllers cuando:
- Tienes múltiples acciones relacionadas
- Necesitas lógica compleja de negocio
- Requieres filtros y atributos avanzados
- Construyes aplicaciones grandes y complejas
- Necesitas mejor organización del código

## 📚 Recursos Adicionales

- [Microsoft Docs - Minimal APIs](https://docs.microsoft.com/aspnet/core/fundamentals/minimal-apis)
- [Microsoft Docs - Minimal API Tutorial](https://docs.microsoft.com/aspnet/core/tutorials/minimal-apis)

