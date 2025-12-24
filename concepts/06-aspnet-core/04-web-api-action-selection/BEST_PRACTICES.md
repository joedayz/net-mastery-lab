# Mejores Prácticas: Web API Action Selection

## ✅ Reglas de Oro

### 1. Usar Attribute Routing Explícito

```csharp
// ✅ BIEN: Attribute routing explícito
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetUser(int id) { }
    
    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserRequest request) { }
}

// ❌ MAL: Depender solo de convenciones
public class UsersController : ControllerBase
{
    public IActionResult Get(int id) { }  // Menos claro
}
```

### 2. Hacer Coincidir Métodos HTTP Correctamente

```csharp
// ✅ BIEN: Métodos HTTP correctos
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }

[HttpPost]
public IActionResult CreateUser([FromBody] CreateUserRequest request) { }

[HttpPut("{id}")]
public IActionResult UpdateUser(int id, [FromBody] UpdateUserRequest request) { }

[HttpDelete("{id}")]
public IActionResult DeleteUser(int id) { }
```

### 3. Asegurar Binding Correcto de Parámetros

```csharp
// ✅ BIEN: Parámetros desde ruta
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }

// ✅ BIEN: Parámetros desde query string
[HttpGet]
public IActionResult SearchUsers([FromQuery] string? name) { }

// ✅ BIEN: Parámetros desde body
[HttpPost]
public IActionResult CreateUser([FromBody] CreateUserRequest request) { }

// ✅ BIEN: Parámetros opcionales
[HttpGet("{id}")]
public IActionResult GetUser(int id, [FromQuery] string? include = null) { }
```

### 4. Evitar [NonAction] en Métodos de API

```csharp
// ✅ BIEN: Método de API público
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }

// ✅ BIEN: Método helper privado (no necesita [NonAction])
private bool ValidateUser(User user) { }

// ✅ BIEN: Método público que NO es endpoint
[NonAction]
public void LogUserActivity(User user) { }
```

## ⚠️ Errores Comunes a Evitar

### 1. Ruta Incorrecta

```csharp
// ❌ MAL: Llamar /users?id=1 en lugar de /users/1
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }
// Solicitud: GET /api/users?id=1  → 404

// ✅ BIEN: Ruta correcta
// Solicitud: GET /api/users/1  → 200 OK
```

### 2. Método HTTP Incorrecto

```csharp
// ❌ MAL: Enviar GET en lugar de POST
[HttpPost]
public IActionResult CreateUser([FromBody] CreateUserRequest request) { }
// Solicitud: GET /api/users  → 404

// ✅ BIEN: Método HTTP correcto
// Solicitud: POST /api/users  → 201 Created
```

### 3. Parámetros Faltantes

```csharp
// ❌ MAL: Parámetro requerido no proporcionado
[HttpGet("{id}")]
public IActionResult GetUser(int id, string name) { }
// Solicitud: GET /api/users/1  → 404 (falta 'name')

// ✅ BIEN: Parámetro opcional
[HttpGet("{id}")]
public IActionResult GetUser(int id, string? name = null) { }
// Solicitud: GET /api/users/1  → 200 OK
```

### 4. [NonAction] en Método de API

```csharp
// ❌ MAL: Método de API con [NonAction]
[HttpGet("{id}")]
[NonAction]
public IActionResult GetUser(int id) { }
// Cualquier solicitud → 404

// ✅ BIEN: Sin [NonAction]
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }
// Solicitud: GET /api/users/1  → 200 OK
```

## 🎯 Casos de Uso Específicos

### 1. Parámetros Múltiples desde Diferentes Fuentes

```csharp
// ✅ BIEN: Parámetros desde diferentes fuentes
[HttpGet("{id}/orders")]
public IActionResult GetUserOrders(
    int id,  // Desde ruta
    [FromQuery] int? page = 1,  // Desde query string
    [FromQuery] int? pageSize = 10)  // Desde query string
{
    // GET /api/users/1/orders?page=2&pageSize=20
}
```

### 2. Binding Complejo desde Body

```csharp
// ✅ BIEN: Binding complejo desde body
[HttpPost]
public IActionResult CreateUser([FromBody] CreateUserRequest request)
{
    // POST /api/users
    // Body: { "name": "John", "email": "john@example.com" }
}
```

### 3. Validación de Modelo

```csharp
// ✅ BIEN: Validación automática con [ApiController]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserRequest request)
    {
        // ModelState.IsValid se valida automáticamente
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // ...
    }
}
```

## 💡 Pro Tips

### 1. Usar [ApiController] para Validación Automática

```csharp
// ✅ BIEN: [ApiController] habilita validación automática
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    // ModelState se valida automáticamente
}
```

### 2. Logging para Depuración

```csharp
// ✅ BIEN: Logging para identificar problemas
[HttpGet("{id}")]
public IActionResult GetUser(int id, ILogger<UsersController> logger)
{
    logger.LogInformation("Getting user {UserId}", id);
    // ...
}
```

### 3. Usar Swagger/OpenAPI para Documentación

```csharp
// ✅ BIEN: Documentación con atributos
/// <summary>
/// Gets a user by ID
/// </summary>
/// <param name="id">The user ID</param>
/// <returns>The user</returns>
[HttpGet("{id}")]
[ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public IActionResult GetUser(int id) { }
```

## 📊 Checklist para Evitar 404

### ✅ Antes de Depurar, Verifica:

- [ ] **Ruta Correcta**: ¿La URL coincide con la ruta definida?
- [ ] **Método HTTP**: ¿El método HTTP coincide con el atributo?
- [ ] **Parámetros**: ¿Todos los parámetros requeridos están presentes?
- [ ] **Tipos de Datos**: ¿Los tipos de datos coinciden?
- [ ] **Atributos**: ¿El método NO tiene `[NonAction]`?
- [ ] **Binding**: ¿Los parámetros están marcados correctamente?
- [ ] **Formato**: ¿El formato del body es correcto (JSON, etc.)?

## 📚 Recursos Adicionales

- [Microsoft Docs - Routing in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/routing)
- [Microsoft Docs - Web API Controllers](https://docs.microsoft.com/aspnet/core/web-api/)
- [Microsoft Docs - Model Binding](https://docs.microsoft.com/aspnet/core/mvc/models/model-binding)

