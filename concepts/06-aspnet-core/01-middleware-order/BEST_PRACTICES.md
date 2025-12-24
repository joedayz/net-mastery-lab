# Mejores Prácticas: Middleware Order in .NET Pipeline

## ✅ Reglas de Oro

### 1. ExceptionHandler siempre primero

```csharp
// ✅ BIEN: ExceptionHandler primero
app.UseExceptionHandler("/Error");
app.UseHsts();
// ... otros middlewares

// ❌ MAL: ExceptionHandler después
app.UseHsts();
app.UseExceptionHandler("/Error"); // No captura excepciones de HSTS
```

**Razón**: Debe capturar excepciones de todos los middlewares siguientes.

### 2. Seguridad temprana (HSTS y HTTPS Redirection)

```csharp
// ✅ BIEN: Seguridad al inicio
app.UseExceptionHandler("/Error");
app.UseHsts();
app.UseHttpsRedirection();
// ... otros middlewares
```

**Razón**: Establece políticas de seguridad antes de procesar el contenido.

### 3. Static Files antes de Routing

```csharp
// ✅ BIEN: Static Files antes de Routing
app.UseStaticFiles();
app.UseRouting();

// ❌ MAL: Routing antes de Static Files
app.UseRouting();
app.UseStaticFiles(); // Puede no funcionar correctamente
```

**Razón**: Los archivos estáticos deben servirse directamente sin pasar por el routing.

### 4. Authentication antes de Authorization

```csharp
// ✅ BIEN: Authentication primero
app.UseAuthentication();
app.UseAuthorization();

// ❌ MAL: Authorization antes de Authentication
app.UseAuthorization(); // Error: no hay identidad establecida
app.UseAuthentication();
```

**Razón**: La autorización necesita la identidad del usuario establecida por la autenticación.

### 5. Routing antes de CORS/Authentication

```csharp
// ✅ BIEN: Routing antes de CORS y Auth
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

// ❌ MAL: CORS antes de Routing
app.UseCors(); // No sabe qué endpoint se está llamando
app.UseRouting();
```

**Razón**: CORS y Authentication necesitan información del endpoint determinado por Routing.

### 6. Endpoints al final

```csharp
// ✅ BIEN: Endpoints al final
app.UseAuthorization();
app.UseEndpoints(endpoints => { ... });

// ❌ MAL: Middlewares después de Endpoints
app.UseEndpoints(endpoints => { ... });
app.UseSomeMiddleware(); // No se ejecutará para requests normales
```

**Razón**: Los endpoints deben ser el último middleware antes de ejecutar el handler.

## ⚠️ Errores Comunes a Evitar

### 1. Authorization antes de Authentication

```csharp
// ❌ MAL: No funcionará correctamente
app.UseAuthorization();
app.UseAuthentication();
```

**Problema**: El sistema de autorización no puede verificar permisos porque la identidad del usuario no está establecida.

### 2. ExceptionHandler no está primero

```csharp
// ❌ MAL: No captura todas las excepciones
app.UseHsts();
app.UseHttpsRedirection();
app.UseExceptionHandler("/Error"); // Solo captura excepciones de middlewares siguientes
```

**Problema**: Las excepciones de middlewares anteriores no se capturan.

### 3. Routing después de Static Files

```csharp
// ❌ MAL: Puede causar problemas
app.UseStaticFiles();
app.UseRouting(); // Debería estar antes
```

**Problema**: Los archivos estáticos pueden no servirse correctamente.

### 4. CORS antes de Routing

```csharp
// ❌ MAL: CORS no tiene información del endpoint
app.UseCors();
app.UseRouting();
```

**Problema**: CORS no puede aplicar políticas específicas por endpoint porque no sabe qué endpoint se está llamando.

## 🎯 Casos de Uso Específicos

### 1. Aplicación Web Básica

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

### 2. API con CORS

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseExceptionHandler("/Error");
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors("AllowAll");
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

### 3. Aplicación con Compresión

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseExceptionHandler("/Error");
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseCors();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseResponseCompression();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

### 4. Con Middlewares Personalizados

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseExceptionHandler("/Error");
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    
    // Custom middlewares después de Routing
    app.UseRequestLogging();
    app.UseCustomValidation();
    
    app.UseCors();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

## 📊 Tabla de Orden Recomendado

| Orden | Middleware | Propósito | Crítico |
|-------|-----------|-----------|---------|
| 1 | UseExceptionHandler | Manejo global de excepciones | ✅ Sí |
| 2 | UseHsts | HTTP Strict Transport Security | ✅ Sí |
| 3 | UseHttpsRedirection | Redirección a HTTPS | ✅ Sí |
| 4 | UseStaticFiles | Servir archivos estáticos | ⚠️ Depende |
| 5 | UseRouting | Habilitar routing | ✅ Sí |
| 6 | UseCors | Cross-Origin Resource Sharing | ⚠️ Depende |
| 7 | UseAuthentication | Autenticación | ✅ Sí (si usas auth) |
| 8 | UseAuthorization | Autorización | ✅ Sí (si usas auth) |
| 9 | UseResponseCompression | Compresión de respuestas | ⚠️ Opcional |
| 10 | UseEndpoints | Mapear endpoints | ✅ Sí |

## 🚀 Tips Avanzados

### 1. Conditional Middleware

```csharp
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
```

### 2. Middleware Ordering Helper

```csharp
// Crear un método de extensión para mantener el orden
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseStandardMiddleware(this IApplicationBuilder app)
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        return app;
    }
}
```

### 3. Testing Middleware Order

```csharp
// En tests, verifica que el orden sea correcto
[Fact]
public void MiddlewareOrder_ShouldBeCorrect()
{
    // Arrange & Act
    var app = CreateWebApplication();
    
    // Assert
    // Verificar que los middlewares están en el orden correcto
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Middleware](https://docs.microsoft.com/aspnet/core/fundamentals/middleware/)
- [Microsoft Docs - Middleware Order](https://docs.microsoft.com/aspnet/core/fundamentals/middleware/#middleware-order)
- [ASP.NET Core Fundamentals](https://docs.microsoft.com/aspnet/core/fundamentals/)

