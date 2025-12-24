# Middleware Order in .NET Pipeline 💡

## Introducción

El orden de los middlewares en el pipeline de ASP.NET Core es crítico para el funcionamiento correcto de tu aplicación. Cada middleware procesa el request y luego pasa el control al siguiente middleware en la cadena. El orden determina cómo se procesan las solicitudes y respuestas.

## 📖 Flujo del Pipeline

El pipeline de middlewares funciona como una cadena donde:
1. **Request Flow (Hacia abajo)**: El request pasa a través de cada middleware en orden
2. **Response Flow (Hacia arriba)**: La respuesta regresa a través de los mismos middlewares en orden inverso

```
Request → Middleware1 → Middleware2 → ... → Endpoint → ... → Middleware2 → Middleware1 → Response
```

## ✅ Orden Recomendado de Middlewares

### 1. UseExceptionHandler
**Propósito**: Manejo global de excepciones

Este middleware se usa para el manejo global de excepciones. Captura cualquier excepción no manejada durante el procesamiento de la solicitud y genera una respuesta de error apropiada.

```csharp
app.UseExceptionHandler("/Error");
```

**Por qué primero**: Debe estar primero para capturar excepciones de todos los middlewares siguientes.

### 2. UseHsts
**Propósito**: Forzar HTTPS con HTTP Strict Transport Security

Este middleware se usa para forzar HTTPS. Agrega el header HTTP Strict Transport Security (HSTS) a la respuesta, instruyendo al cliente a usar siempre HTTPS.

```csharp
app.UseHsts();
```

**Por qué segundo**: Debe ejecutarse temprano para establecer políticas de seguridad antes de procesar el request.

### 3. UseHttpsRedirection
**Propósito**: Redirección automática a HTTPS

Este middleware causa una redirección automática a una URL HTTPS cuando se recibe una URL HTTP, forzando una conexión segura.

```csharp
app.UseHttpsRedirection();
```

**Por qué tercero**: Debe ejecutarse después de HSTS pero antes de procesar el contenido.

### 4. UseStaticFiles
**Propósito**: Servir archivos estáticos

Este middleware sirve archivos estáticos desde la carpeta `wwwroot`.

```csharp
app.UseStaticFiles();
```

**Por qué cuarto**: Debe ejecutarse antes del routing para servir archivos estáticos directamente sin pasar por el routing.

### 5. UseRouting
**Propósito**: Habilitar routing

Este middleware habilita el routing en la aplicación. Examina la solicitud entrante y la mapea al manejador de endpoint apropiado.

```csharp
app.UseRouting();
```

**Por qué quinto**: Debe ejecutarse después de los middlewares de seguridad pero antes de CORS y autenticación.

### 6. UseCors
**Propósito**: Habilitar Cross-Origin Resource Sharing

Este middleware habilita el intercambio de recursos de origen cruzado (CORS). Permite solicitudes entre dominios desde el navegador.

```csharp
app.UseCors();
```

**Por qué sexto**: Debe ejecutarse después del routing pero antes de la autenticación.

### 7. UseAuthentication
**Propósito**: Habilitar autenticación

Este middleware habilita la autenticación. Autentica al usuario que hace la solicitud.

```csharp
app.UseAuthentication();
```

**Por qué séptimo**: Debe ejecutarse antes de la autorización para establecer la identidad del usuario.

### 8. UseAuthorization
**Propósito**: Habilitar autorización

Este middleware habilita la autorización. Verifica si la solicitud entrante está autorizada para acceder al recurso solicitado.

```csharp
app.UseAuthorization();
```

**Por qué octavo**: Debe ejecutarse después de la autenticación porque necesita la identidad del usuario establecida.

### 9. UseResponseCompression
**Propósito**: Compresión de respuestas

Este middleware habilita la compresión de respuestas. Comprime el cuerpo de la respuesta usando Gzip o Deflate para reducir el tiempo de transferencia de red y mejorar el rendimiento de la aplicación.

```csharp
app.UseResponseCompression();
```

**Por qué noveno**: Debe ejecutarse antes de los endpoints para comprimir las respuestas.

### 10. UseEndpoints
**Propósito**: Mapear requests HTTP a endpoint handlers

Este middleware mapea solicitudes HTTP a manejadores de endpoints. Se usa para configurar el routing de la aplicación. Mapea acciones de controladores a los endpoints apropiados.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
```

**Por qué último**: Debe ser el último middleware antes de ejecutar el endpoint handler.

## 🔥 Orden Completo del Pipeline

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // 1. Exception Handler (primero para capturar todas las excepciones)
    app.UseExceptionHandler("/Error");
    
    // 2. HSTS (seguridad temprana)
    app.UseHsts();
    
    // 3. HTTPS Redirection (redirección antes de procesar)
    app.UseHttpsRedirection();
    
    // 4. Static Files (servir archivos estáticos directamente)
    app.UseStaticFiles();
    
    // 5. Routing (habilitar routing)
    app.UseRouting();
    
    // 6. CORS (después del routing, antes de autenticación)
    app.UseCors();
    
    // 7. Authentication (establecer identidad del usuario)
    app.UseAuthentication();
    
    // 8. Authorization (verificar permisos después de autenticación)
    app.UseAuthorization();
    
    // 9. Response Compression (comprimir respuestas)
    app.UseResponseCompression();
    
    // 10. Endpoints (último, mapear a handlers)
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
```

## ⚠️ Importancia del Orden

Es importante notar que el orden de los middlewares puede afectar el comportamiento de tu aplicación. Por ejemplo:

### ❌ Error Común: Authorization antes de Authentication

```csharp
// ❌ MAL: Authorization antes de Authentication
app.UseAuthorization(); // Error: el usuario aún no está autenticado
app.UseAuthentication();
```

**Problema**: Si `UseAuthorization` se coloca antes de `UseAuthentication`, el sistema de autenticación no podrá autenticar al usuario y el sistema de autorización no podrá autorizar al usuario porque la identidad del usuario aún no se ha establecido.

### ✅ Correcto: Authentication antes de Authorization

```csharp
// ✅ BIEN: Authentication antes de Authorization
app.UseAuthentication(); // Primero autentica
app.UseAuthorization(); // Luego autoriza
```

## 🎯 Middlewares Personalizados

Los middlewares personalizados generalmente se colocan después de `UseRouting` y antes de `UseEndpoints`:

```csharp
app.UseRouting();

// Custom middlewares aquí
app.UseCustomMiddleware1();
app.UseCustomMiddleware2();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => { ... });
```

## 📊 Diagrama del Flujo

```
Request
  ↓
ExceptionHandler (captura excepciones)
  ↓
HSTS (agrega headers de seguridad)
  ↓
HttpsRedirection (redirige a HTTPS)
  ↓
StaticFiles (sirve archivos estáticos)
  ↓
Routing (determina el endpoint)
  ↓
CORS (maneja cross-origin)
  ↓
Authentication (establece identidad)
  ↓
Authorization (verifica permisos)
  ↓
ResponseCompression (comprime respuesta)
  ↓
Endpoints (ejecuta el handler)
  ↓
Response (regresa por la cadena en orden inverso)
```

## 💡 Mejores Prácticas

1. **ExceptionHandler siempre primero**: Para capturar excepciones de todos los middlewares
2. **Seguridad temprana**: HSTS y HTTPS Redirection deben estar al inicio
3. **Static Files antes de Routing**: Para servir archivos directamente
4. **Routing antes de CORS/Auth**: Para determinar el endpoint antes de aplicar políticas
5. **Authentication antes de Authorization**: La identidad debe establecerse primero
6. **Endpoints al final**: Después de todo el procesamiento de middlewares

## 📚 Recursos Adicionales

- [Microsoft Docs - Middleware](https://docs.microsoft.com/aspnet/core/fundamentals/middleware/)
- [Microsoft Docs - Middleware Order](https://docs.microsoft.com/aspnet/core/fundamentals/middleware/#middleware-order)
- [ASP.NET Core Fundamentals](https://docs.microsoft.com/aspnet/core/fundamentals/)

