# ASP.NET Core 🚀

## Introducción

Esta sección contiene conceptos fundamentales y mejores prácticas para desarrollar aplicaciones web con ASP.NET Core, incluyendo middleware, routing, autenticación y más.

## 📚 Temas Disponibles

### 1. Middleware Order in .NET Pipeline
**Ubicación:** `concepts/06-aspnet-core/01-middleware-order/`

Guía completa sobre el orden recomendado de middlewares en el pipeline de ASP.NET Core y por qué el orden es crítico para el funcionamiento correcto de la aplicación.

### 2. ASP.NET Core MVC Request Life Cycle
**Ubicación:** `concepts/06-aspnet-core/02-mvc-request-lifecycle/`

Guía completa sobre el ciclo de vida completo de una petición HTTP en ASP.NET Core MVC, desde que entra al sistema hasta que se genera la respuesta.

**Etapas del Ciclo de Vida:**
- **Middleware Pipeline**: Primera parada, filtrado y procesamiento
- **Routing**: Dirección al controlador y acción correctos
- **Controller Initialization**: Instanciación con dependencias
- **Action Method Execution**: Ejecución de lógica de negocio
- **Result Execution**: Procesamiento del resultado
- **View Rendering**: Conversión de datos a HTML (MVC)
- **Response**: Respuesta final al cliente

**Por Qué Importa:**
- **Debugging Made Easier**: Rastrear y solucionar problemas eficientemente
- **Optimized Performance**: Afinar middleware y routing para mejor rendimiento
- **Cleaner Code**: Código más limpio y mantenible

### 3. APIs Mínimas Mejoradas
**Ubicación:** `concepts/06-aspnet-core/03-minimal-apis/`

Guía completa sobre Minimal APIs en ASP.NET Core, que permiten crear aplicaciones web ligeras y de alto rendimiento con menos código repetitivo.

**Características Principales:**
- **Menos Código Boilerplate**: Sintaxis más concisa que Controllers
- **Mejor Rendimiento**: Menos overhead, inicio más rápido
- **Inyección de Dependencias Optimizada**: DI automática en parámetros
- **Enrutamiento Mejorado**: Constraints y validación integrada
- **Tipos de Resultados Mejorados**: Results helper class

**Cuándo Usar:**
- ✅ Microservicios pequeños
- ✅ Endpoints simples y directos
- ✅ Prioridad en rendimiento y simplicidad
- ⚠️ Considerar Controllers para lógica compleja o múltiples acciones relacionadas

### 4. Web API Action Selection
**Ubicación:** `concepts/06-aspnet-core/04-web-api-action-selection/`

Guía completa sobre el proceso de selección de acciones en ASP.NET Core Web API y cómo evitar errores 404 Not Found.

**Proceso de Selección:**
1. **Route Matching**: Verificar si route data contiene "action"
2. **HTTP Method Filtering**: Seleccionar métodos que coincidan con el método HTTP
3. **Parameter Validation**: Verificar que parámetros coincidan
4. **HTTP Verb Validation**: Validar que el verbo HTTP coincida
5. **NonAction Check**: Excluir métodos marcados con [NonAction]
6. **Action Found**: Si todas las condiciones se cumplen, ejecutar acción

**Problemas Comunes que Causan 404:**
- ❌ Ruta incorrecta (`/users?id=1` vs `/users/1`)
- ❌ Método HTTP incorrecto (GET vs POST)
- ❌ Parámetros faltantes o incorrectos
- ❌ [NonAction] en método de API

**Mejores Prácticas:**
- ✅ Usar Attribute Routing explícito
- ✅ Hacer coincidir métodos HTTP correctamente
- ✅ Asegurar binding correcto de parámetros
- ✅ Evitar [NonAction] en métodos de API
- ✅ Depurar con logging

### 5. Scrutor: Auto-Register Dependencies
**Ubicación:** `concepts/06-aspnet-core/05-scrutor-auto-register/`

Guía completa sobre cómo usar Scrutor para auto-registrar dependencias en ASP.NET Core, reduciendo significativamente el código boilerplate.

**Características Principales:**
- **Auto-Registro**: Registra servicios automáticamente basándose en convenciones
- **Escaneo de Assemblies**: Escanea assemblies completos en busca de servicios
- **Matching de Interfaces**: Empareja clases con sus interfaces correspondientes
- **Múltiples Lifetimes**: Soporta Scoped, Transient y Singleton
- **Filtrado Avanzado**: Permite filtrar qué clases registrar

**Comparación:**
- ❌ **Antes**: Registro manual verboso (`AddScoped<IOrderService, OrderService>()` repetido muchas veces)
- ✅ **Después**: Auto-registro con Scrutor (una línea registra múltiples servicios)

**Ventajas:**
- ✅ Reduce código boilerplate significativamente
- ✅ Escalable y mantenible
- ✅ Menos propenso a errores
- ✅ Automático para nuevos servicios

**Cuándo Usar:**
- ✅ Muchos servicios para registrar (>10)
- ✅ Convenciones de nombres consistentes
- ✅ Necesitas mantener código limpio
- ✅ Agregas servicios frecuentemente

### 6. Object Mapping with AutoMapper
**Ubicación:** `concepts/06-aspnet-core/06-automapper-object-mapping/`

Guía completa sobre cómo usar AutoMapper para mapeo objeto-a-objeto en .NET, eliminando código boilerplate y reduciendo errores.

**Características Principales:**
- **Mapeo Automático**: Mapea propiedades automáticamente por nombre
- **Configuración Flexible**: Permite configuración personalizada para casos complejos
- **Reducción de Código**: Elimina código boilerplate de mapeo
- **Type-Safe**: Verificación de tipos en tiempo de compilación
- **Integración ASP.NET Core**: Funciona perfectamente con Dependency Injection

**Comparación:**
- ❌ **Antes**: Mapeo manual verboso (muchas líneas de código repetitivas)
- ✅ **Después**: AutoMapper (una línea mapea múltiples propiedades)

**Ventajas:**
- ✅ Elimina código repetitivo de mapeo
- ✅ Reduce errores humanos
- ✅ Mantiene código limpio y mantenible
- ✅ Ideal para mapear Entities ↔ DTOs

**Cuándo Usar:**
- ✅ Mapeo frecuente entre Entities y DTOs
- ✅ Múltiples DTOs para diferentes contextos
- ✅ APIs REST o microservicios
- ✅ Necesitas código limpio y mantenible

**Instalación:**
```bash
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

**Uso Básico:**
```csharp
// Configuración
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserProfile>();
    }
}

// Registro
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Uso
var userProfile = _mapper.Map<UserProfile>(user);
```

### 7. Logging in .NET Core
**Ubicación:** `concepts/06-aspnet-core/07-logging/`

Guía completa sobre Logging en .NET Core: el backbone de toda aplicación confiable. Si depurar es como trabajo de detective, entonces el logging es tu evidencia.

**Tres Enfoques Principales:**
- **Built-in ILogger**: Ligero, flexible, funciona out-of-the-box
- **Serilog**: Structured logging completo con múltiples sinks
- **NLog**: Simple, rápido y flexible

**Mejores Prácticas:**
- ✅ Preferir logs estructurados sobre texto plano
- ✅ Mantener formatos de log consistentes
- ✅ Nunca registrar información sensible (passwords, tokens, personal data)
- ✅ Centralizar logs usando Seq, Kibana, o Azure Monitor
- ✅ Usar niveles de log sabiamente (Information, Warning, Error, Critical)

**Cuándo Usar:**
- ✅ **Built-in ILogger**: Apps pequeñas, herramientas internas
- ✅ **Serilog**: Sistemas de producción complejos, necesita búsqueda avanzada
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

## 🎯 Objetivo

Este apartado está diseñado para ayudarte a:
- Comprender cómo funciona el pipeline de middlewares en ASP.NET Core
- Aplicar el orden correcto de middlewares
- Entender el flujo de request/response
- Construir aplicaciones web robustas y seguras

