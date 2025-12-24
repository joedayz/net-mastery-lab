# Web API Action Selection en ASP.NET Core 🚀

## Introducción

¿Alguna vez has encontrado un error misterioso de **404 Not Found** en tu ASP.NET Core Web API? 🤯 Estás seguro de que la ruta existe, el controlador es correcto, pero la API se niega a reconocer tu acción. ¿Por qué sucede esto?

Este documento explica el proceso estructurado que sigue ASP.NET Core para identificar el método de acción correcto para una solicitud entrante y qué puede llevar a una respuesta 404 Not Found.

## 🔍 El Proceso de Selección de Acciones en Web API

Cada vez que se hace una solicitud a una ASP.NET Core Web API, el framework sigue un enfoque estructurado para identificar el método de acción correcto. Si cualquier paso falla, la solicitud resulta en **404 Not Found**. 🚫

## 🔹 Proceso Paso a Paso

### Paso 1️⃣: Route Matching (Coincidencia de Rutas)

El framework verifica si los datos de ruta contienen un nombre de "action".

```csharp
// ✅ BIEN: Ruta con acción explícita
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]  // Ruta: /api/users/1
    public IActionResult GetUser(int id) { }
}

// ✅ BIEN: Ruta con acción en el nombre
[Route("api/users")]
public class UsersController : ControllerBase
{
    [HttpGet("get/{id}")]  // Ruta: /api/users/get/1
    public IActionResult Get(int id) { }
}
```

**Comportamiento:**
- ✅ Si se proporciona una acción en la ruta, filtra métodos que coincidan con el nombre
- ✅ Si no, pasa al siguiente paso

### Paso 2️⃣: HTTP Method Filtering (Filtrado por Método HTTP)

La API selecciona métodos que coincidan con el método HTTP de la solicitud (GET, POST, PUT, DELETE, etc.).

```csharp
// ✅ BIEN: Método HTTP correcto
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }

// ❌ MAL: Método HTTP incorrecto
// Solicitud: GET /api/users/1
[HttpPost("{id}")]  // Error: No coincide con GET
public IActionResult GetUser(int id) { }
```

**Comportamiento:**
- ✅ Selecciona acciones que coincidan con el método HTTP
- ❌ Si ninguna acción coincide con el método, ocurre un error 404

### Paso 3️⃣: Parameter Validation (Validación de Parámetros)

El framework verifica si los parámetros en la solicitud coinciden con los parámetros esperados de la acción.

```csharp
// ✅ BIEN: Parámetros coinciden
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }
// Solicitud: GET /api/users/1 ✅

// ❌ MAL: Parámetros no coinciden
[HttpGet("{id}")]
public IActionResult GetUser(int id, string name) { }
// Solicitud: GET /api/users/1 ❌ Falta parámetro 'name'

// ✅ BIEN: Parámetros opcionales
[HttpGet("{id}")]
public IActionResult GetUser(int id, string? name = null) { }
// Solicitud: GET /api/users/1 ✅ name es opcional
```

**Comportamiento:**
- ✅ Verifica que todos los parámetros requeridos estén presentes
- ✅ Valida tipos de datos
- ❌ Si los parámetros no coinciden, la acción se rechaza

### Paso 4️⃣: HTTP Verb Validation (Validación de Verbo HTTP)

Si se encuentra una acción pero no satisface el verbo HTTP (GET, POST, etc.), la solicitud se rechaza con un error 404.

```csharp
// ✅ BIEN: Verbo HTTP correcto
[HttpGet]
public IActionResult GetAllUsers() { }

// ❌ MAL: Verbo HTTP incorrecto
// Solicitud: POST /api/users
[HttpGet]  // Error: No coincide con POST
public IActionResult GetAllUsers() { }
```

**Comportamiento:**
- ✅ Valida que el verbo HTTP coincida con el atributo del método
- ❌ Si no coincide, se rechaza con 404

### Paso 5️⃣: [NonAction] Attribute Check (Verificación de Atributo [NonAction])

Incluso si todo es correcto, si el método está marcado con `[NonAction]`, se excluye de la selección.

```csharp
// ✅ BIEN: Método público sin [NonAction]
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }

// ❌ MAL: Método marcado con [NonAction]
[HttpGet("{id}")]
[NonAction]  // Error: Método excluido de selección
public IActionResult GetUser(int id) { }

// ✅ BIEN: Método privado (automáticamente excluido)
private IActionResult HelperMethod() { }
```

**Comportamiento:**
- ✅ Previene que métodos no deseados se expongan como endpoints de API
- ❌ Si el método tiene `[NonAction]`, se excluye automáticamente

### ✅ Paso Final: ¡Acción Encontrada!

Si todas las condiciones se cumplen, ¡la acción correcta se ejecuta! 🎯

## 📊 Flujo del Proceso de Selección

```
Start
  ↓
1. ¿"action" en route data?
  ├─ Sí → a) Seleccionar acciones basadas en nombre
  │         ↓
  │         b) ¿Satisface verbo HTTP?
  │         ├─ Sí → Continuar
  │         └─ No → 404
  │
  └─ No → 2. Seleccionar acciones basadas en método HTTP
            ↓
3. ¿Satisface parámetros?
  ├─ Sí → Continuar
  └─ No → 404
            ↓
4. ¿Atributo [NonAction]?
  ├─ Sí → 404
  └─ No → ✅ Acción Encontrada
```

## 🔥 ¿Por Qué Esto Importa?

Entender este proceso ayuda a depurar problemas de enrutamiento de API de manera eficiente y previene errores 404 inesperados.

### Errores Comunes que Causan 404:

#### ❌ Parámetros de Ruta Faltantes o Incorrectos

```csharp
// ❌ MAL: Llamar /users?id=1 en lugar de /users/1
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }

// Solicitud incorrecta: GET /api/users?id=1
// Solicitud correcta: GET /api/users/1
```

#### ❌ Desajuste de Método HTTP

```csharp
// ❌ MAL: Enviar POST en lugar de GET
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }

// Solicitud incorrecta: POST /api/users/1
// Solicitud correcta: GET /api/users/1
```

#### ❌ Uso Incorrecto de Atributos

```csharp
// ❌ MAL: Marcar método de API con [NonAction]
[HttpGet("{id}")]
[NonAction]  // Error: Excluye el método de selección
public IActionResult GetUser(int id) { }
```

#### ❌ Problemas de Binding de Parámetros

```csharp
// ❌ MAL: Parámetro requerido no proporcionado
[HttpGet("{id}")]
public IActionResult GetUser(int id, string name) { }
// Solicitud: GET /api/users/1 ❌ Falta 'name'

// ✅ BIEN: Parámetro opcional o desde query string
[HttpGet("{id}")]
public IActionResult GetUser(int id, string? name = null) { }
// Solicitud: GET /api/users/1?name=John ✅
```

## 💡 Mejores Prácticas para Enrutamiento de API en ASP.NET Core

### 1. Usar Attribute Routing

Define rutas explícitamente usando `[HttpGet]`, `[HttpPost]`, etc.

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
```

### 2. Hacer Coincidir Métodos HTTP Correctamente

Asegúrate de que el método de solicitud coincida con el método de acción.

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

Define parámetros correctamente en la URL o body de la solicitud.

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

// ✅ BIEN: Parámetros desde header
[HttpGet]
public IActionResult GetUser([FromHeader] string authorization) { }
```

### 4. Evitar Errores con [NonAction]

Marca solo métodos no-API con este atributo.

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

### 5. Depurar con Logging

Usa ILogger para registrar detalles de solicitud y errores de enrutamiento.

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        _logger.LogInformation("Getting user {UserId}", id);
        
        try
        {
            var user = GetUserById(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting user {UserId}", id);
            return NotFound();
        }
    }
}
```

## 📊 Ejemplos Prácticos

### Ejemplo 1: Ruta Correcta vs Incorrecta

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetUser(int id) { }
}

// ✅ BIEN: Solicitud correcta
// GET /api/users/1

// ❌ MAL: Solicitud incorrecta
// GET /api/users?id=1  // No coincide con ruta {id}
```

### Ejemplo 2: Método HTTP Correcto vs Incorrecto

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserRequest request) { }
}

// ✅ BIEN: Solicitud correcta
// POST /api/users
// Body: { "name": "John", "email": "john@example.com" }

// ❌ MAL: Solicitud incorrecta
// GET /api/users  // No coincide con HttpPost
```

### Ejemplo 3: Parámetros Opcionales

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult SearchUsers(
        [FromQuery] string? name = null,
        [FromQuery] int? age = null)
    {
        // Ambos parámetros son opcionales
    }
}

// ✅ BIEN: Todas estas solicitudes funcionan
// GET /api/users
// GET /api/users?name=John
// GET /api/users?age=30
// GET /api/users?name=John&age=30
```

### Ejemplo 4: Evitar [NonAction] en Métodos de API

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    // ✅ BIEN: Método de API sin [NonAction]
    [HttpGet("{id}")]
    public IActionResult GetUser(int id) { }

    // ✅ BIEN: Método helper privado (no necesita [NonAction])
    private bool IsValidUser(int id) { }

    // ✅ BIEN: Método público que NO es endpoint
    [NonAction]
    public void LogActivity(string message) { }
}
```

## ⚠️ Problemas Potenciales de 404

### Problema 1: Ruta Incorrecta

```csharp
// Controlador
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }

// ❌ MAL: Llamar /users?id=1 en lugar de /users/1
// GET /api/users?id=1  → 404

// ✅ BIEN: Ruta correcta
// GET /api/users/1  → 200 OK
```

### Problema 2: Método HTTP Incorrecto

```csharp
// Controlador
[HttpPost]
public IActionResult CreateUser([FromBody] CreateUserRequest request) { }

// ❌ MAL: Enviar GET en lugar de POST
// GET /api/users  → 404

// ✅ BIEN: Método HTTP correcto
// POST /api/users  → 201 Created
```

### Problema 3: Parámetro No Pasado Correctamente

```csharp
// Controlador
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }

// ❌ MAL: Parámetro faltante
// GET /api/users  → 404

// ✅ BIEN: Parámetro proporcionado
// GET /api/users/1  → 200 OK
```

### Problema 4: [NonAction] en Método de API

```csharp
// ❌ MAL: Método de API con [NonAction]
[HttpGet("{id}")]
[NonAction]
public IActionResult GetUser(int id) { }
// GET /api/users/1  → 404

// ✅ BIEN: Sin [NonAction]
[HttpGet("{id}")]
public IActionResult GetUser(int id) { }
// GET /api/users/1  → 200 OK
```

## 💡 Checklist para Evitar 404

### ✅ Antes de Depurar, Verifica:

1. **Ruta Correcta**
   - ✅ ¿La URL coincide con la ruta definida?
   - ✅ ¿Los parámetros de ruta están en el lugar correcto?

2. **Método HTTP Correcto**
   - ✅ ¿El método HTTP (GET, POST, PUT, DELETE) coincide?
   - ✅ ¿Estás usando el cliente HTTP correcto?

3. **Parámetros Correctos**
   - ✅ ¿Todos los parámetros requeridos están presentes?
   - ✅ ¿Los tipos de datos coinciden?
   - ✅ ¿Los parámetros opcionales tienen valores por defecto?

4. **Atributos Correctos**
   - ✅ ¿El método NO tiene `[NonAction]`?
   - ✅ ¿El método es público?
   - ✅ ¿Tiene el atributo HTTP correcto (`[HttpGet]`, `[HttpPost]`, etc.)?

5. **Binding Correcto**
   - ✅ ¿Los parámetros están marcados correctamente (`[FromRoute]`, `[FromQuery]`, `[FromBody]`)?
   - ✅ ¿El formato del body es correcto (JSON, XML, etc.)?

## 📚 Recursos Adicionales

- [Microsoft Docs - Routing in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/routing)
- [Microsoft Docs - Web API Controllers](https://docs.microsoft.com/aspnet/core/web-api/)
- [Microsoft Docs - Model Binding](https://docs.microsoft.com/aspnet/core/mvc/models/model-binding)

