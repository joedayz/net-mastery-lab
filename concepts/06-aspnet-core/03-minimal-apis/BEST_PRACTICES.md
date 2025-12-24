# Mejores Prácticas: Minimal APIs

## ✅ Reglas de Oro

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

## ⚠️ Errores Comunes a Evitar

### 1. Lógica Compleja en Minimal APIs

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

### 2. No Agrupar Endpoints Relacionados

```csharp
// ❌ MAL: Endpoints dispersos
app.MapGet("/users", ...);
app.MapGet("/users/{id}", ...);
app.MapPost("/users", ...);
// ... muchos más sin organización

// ✅ BIEN: Agrupar con MapGroup
var usersApi = app.MapGroup("/api/users");
usersApi.MapGet("/", GetAllUsers);
usersApi.MapGet("/{id}", GetUser);
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Minimal APIs](https://docs.microsoft.com/aspnet/core/fundamentals/minimal-apis)

