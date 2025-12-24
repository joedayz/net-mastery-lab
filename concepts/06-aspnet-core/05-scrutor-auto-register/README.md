# Scrutor in ASP.NET Core: Auto-Register Dependencies 🔄

## Introducción

**Scrutor** es una librería poderosa para ASP.NET Core que simplifica el registro de dependencias mediante el escaneo automático de assemblies. En lugar de registrar manualmente cada servicio uno por uno, Scrutor permite registrar múltiples servicios automáticamente basándose en convenciones, reduciendo significativamente el código boilerplate.

## 🚀 ¿Qué es Scrutor?

Scrutor es una librería de código abierto que extiende las capacidades del contenedor de inyección de dependencias de ASP.NET Core. Proporciona métodos de extensión que permiten escanear assemblies y registrar servicios automáticamente basándose en convenciones de nombres y tipos.

### Características Principales

- ✅ **Auto-Registro**: Registra servicios automáticamente basándose en convenciones
- ✅ **Escaneo de Assemblies**: Escanea assemblies completos en busca de servicios
- ✅ **Matching de Interfaces**: Empareja clases con sus interfaces correspondientes
- ✅ **Múltiples Lifetimes**: Soporta Scoped, Transient y Singleton
- ✅ **Filtrado Avanzado**: Permite filtrar qué clases registrar
- ✅ **Menos Boilerplate**: Reduce significativamente el código de registro

## 📖 El Problema: Registro Manual (Before) ❌

El registro manual de dependencias puede volverse verboso y propenso a errores cuando tienes muchos servicios.

```csharp
// ❌ ANTES: Registro manual - verboso y propenso a errores
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IShippingService, ShippingService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
// ... y muchos más
```

**Problemas del Registro Manual:**
- ❌ **Verboso**: Muchas líneas de código repetitivas
- ❌ **Propenso a Errores**: Fácil olvidar registrar un servicio
- ❌ **Difícil de Mantener**: Agregar nuevos servicios requiere actualizar el registro
- ❌ **No Escalable**: Con muchos servicios, el código se vuelve difícil de manejar

## ✅ La Solución: Scrutor (After) ✨

Scrutor permite registrar múltiples servicios automáticamente con una sola llamada.

```csharp
// ✅ DESPUÉS: Auto-registro con Scrutor - limpio y escalable
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses()
    .AsMatchingInterface()
    .WithScopedLifetime());
```

**Ventajas de Scrutor:**
- ✅ **Conciso**: Una sola línea registra múltiples servicios
- ✅ **Automático**: Nuevos servicios se registran automáticamente
- ✅ **Menos Errores**: No hay riesgo de olvidar registrar un servicio
- ✅ **Escalable**: Funciona igual con 10 o 100 servicios
- ✅ **Mantenible**: Agregar nuevos servicios no requiere cambios en el registro

## 🔧 Instalación

### NuGet Package

```bash
dotnet add package Scrutor
```

O desde el Package Manager Console:

```powershell
Install-Package Scrutor
```

### Usando .NET CLI

```bash
dotnet add package Scrutor
```

## 💡 Cómo Funciona Scrutor

### 1. Escaneo de Assembly

Scrutor escanea un assembly completo en busca de clases que coincidan con los criterios especificados.

```csharp
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()  // Escanea el assembly donde está OrderService
    .AddClasses()                    // Agrega todas las clases públicas
    .AsMatchingInterface()           // Las registra con su interfaz correspondiente
    .WithScopedLifetime());          // Con lifetime Scoped
```

### 2. Matching de Interfaces

Scrutor busca interfaces que coincidan con el nombre de la clase. Por ejemplo:
- `OrderService` → `IOrderService`
- `CustomerService` → `ICustomerService`
- `InvoiceService` → `IInvoiceService`

### 3. Registro Automático

Cada clase encontrada se registra automáticamente con su interfaz correspondiente y el lifetime especificado.

## 🎯 Ejemplos Prácticos

### Ejemplo 1: Registro Básico

```csharp
// Estructura de clases
public interface IOrderService { }
public class OrderService : IOrderService { }

public interface ICustomerService { }
public class CustomerService : ICustomerService { }

public interface IInvoiceService { }
public class InvoiceService : IInvoiceService { }

// Registro con Scrutor
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes.AssignableTo(typeof(IOrderService)))
    .AsImplementedInterfaces()
    .WithScopedLifetime());
```

### Ejemplo 2: Múltiples Assemblies

```csharp
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .FromAssemblyOf<CustomerService>()
    .AddClasses()
    .AsMatchingInterface()
    .WithScopedLifetime());
```

### Ejemplo 3: Filtrado por Namespace

```csharp
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes.InNamespaces("MyApp.Services"))
    .AsMatchingInterface()
    .WithScopedLifetime());
```

### Ejemplo 4: Diferentes Lifetimes

```csharp
// Servicios Scoped
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Service")))
    .AsMatchingInterface()
    .WithScopedLifetime());

// Repositorios Transient
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderRepository>()
    .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Repository")))
    .AsMatchingInterface()
    .WithTransientLifetime());

// Singletons
builder.Services.Scan(scan => scan
    .FromAssemblyOf<CacheService>()
    .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Cache")))
    .AsMatchingInterface()
    .WithSingletonLifetime());
```

### Ejemplo 5: Filtrado Avanzado

```csharp
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes
        .Where(c => c.Name.EndsWith("Service") && 
                    !c.IsAbstract && 
                    c.IsPublic))
    .AsMatchingInterface()
    .WithScopedLifetime());
```

### Ejemplo 6: Múltiples Interfaces

```csharp
// Si una clase implementa múltiples interfaces
public class OrderService : IOrderService, IDisposable
{
    // ...
}

// Registra con todas las interfaces implementadas
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses()
    .AsImplementedInterfaces()  // Registra con todas las interfaces
    .WithScopedLifetime());
```

## 📊 Comparación Detallada

| Aspecto | Registro Manual | Scrutor |
|---------|----------------|---------|
| **Líneas de Código** | 1 por servicio | 1 para múltiples servicios |
| **Mantenibilidad** | Baja (actualizar manualmente) | Alta (automático) |
| **Escalabilidad** | Difícil con muchos servicios | Excelente |
| **Propenso a Errores** | Alto (olvidar registrar) | Bajo (automático) |
| **Flexibilidad** | Alta (control total) | Alta (filtrado avanzado) |
| **Rendimiento** | Mismo | Mismo |

## 🎯 Casos de Uso

### ✅ Usa Scrutor cuando:

- Tienes muchos servicios para registrar
- Sigues convenciones de nombres consistentes
- Quieres reducir código boilerplate
- Necesitas mantener el código de registro limpio
- Agregas nuevos servicios frecuentemente

### ⚠️ Considera Registro Manual cuando:

- Tienes pocos servicios (menos de 5-10)
- Necesitas configuración específica por servicio
- Los servicios no siguen convenciones consistentes
- Necesitas registrar servicios con diferentes constructores
- Requieres control granular sobre el registro

## 🔍 Métodos Principales de Scrutor

### `FromAssemblyOf<T>()`
Especifica el assembly a escanear usando un tipo de referencia.

```csharp
.FromAssemblyOf<OrderService>()
```

### `AddClasses()`
Agrega todas las clases públicas del assembly.

```csharp
.AddClasses()
```

### `AddClasses(Action<IImplementationTypeFilter>)`
Agrega clases con filtrado personalizado.

```csharp
.AddClasses(classes => classes
    .Where(c => c.Name.EndsWith("Service")))
```

### `AsMatchingInterface()`
Registra cada clase con su interfaz correspondiente (por nombre).

```csharp
.AsMatchingInterface()
// OrderService → IOrderService
```

### `AsImplementedInterfaces()`
Registra cada clase con todas las interfaces que implementa.

```csharp
.AsImplementedInterfaces()
```

### `WithScopedLifetime()`
Registra servicios con lifetime Scoped.

```csharp
.WithScopedLifetime()
```

### `WithTransientLifetime()`
Registra servicios con lifetime Transient.

```csharp
.WithTransientLifetime()
```

### `WithSingletonLifetime()`
Registra servicios con lifetime Singleton.

```csharp
.WithSingletonLifetime()
```

## ⚠️ Consideraciones Importantes

### 1. Convenciones de Nombres

Scrutor funciona mejor cuando sigues convenciones consistentes:

```csharp
// ✅ BIEN: Convención consistente
public interface IOrderService { }
public class OrderService : IOrderService { }

// ❌ MAL: Nombres inconsistentes
public interface IOrderService { }
public class OrderServiceImpl : IOrderService { }  // No funcionará con AsMatchingInterface()
```

### 2. Múltiples Implementaciones

Si una interfaz tiene múltiples implementaciones, necesitas especificar cuál usar:

```csharp
// ❌ PROBLEMA: Múltiples implementaciones
public interface ILogger { }
public class FileLogger : ILogger { }
public class DatabaseLogger : ILogger { }

// ✅ SOLUCIÓN: Filtrar o registrar manualmente
builder.Services.Scan(scan => scan
    .FromAssemblyOf<FileLogger>()
    .AddClasses(classes => classes.Where(c => c.Name == "FileLogger"))
    .AsImplementedInterfaces()
    .WithScopedLifetime());
```

### 3. Rendimiento

El escaneo de assemblies ocurre al inicio de la aplicación, por lo que el impacto en el rendimiento es mínimo.

## 💡 Mejores Prácticas

### 1. Agrupar por Responsabilidad

```csharp
// Servicios de dominio
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes.InNamespaces("MyApp.Services"))
    .AsMatchingInterface()
    .WithScopedLifetime());

// Repositorios
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderRepository>()
    .AddClasses(classes => classes.InNamespaces("MyApp.Repositories"))
    .AsMatchingInterface()
    .WithScopedLifetime());
```

### 2. Usar Filtros Específicos

```csharp
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes
        .Where(c => c.Name.EndsWith("Service") && 
                    !c.IsAbstract && 
                    c.IsPublic &&
                    c.GetInterfaces().Any()))
    .AsMatchingInterface()
    .WithScopedLifetime());
```

### 3. Combinar con Registro Manual

```csharp
// Auto-registro para servicios estándar
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses()
    .AsMatchingInterface()
    .WithScopedLifetime());

// Registro manual para casos especiales
builder.Services.AddSingleton<IConfigurationService>(sp => 
    new ConfigurationService(configuration));
```

## 📚 Ejemplo Completo: Program.cs

```csharp
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

// Auto-registro de servicios con Scrutor
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes
        .Where(c => c.Name.EndsWith("Service") && 
                    !c.IsAbstract))
    .AsMatchingInterface()
    .WithScopedLifetime());

// Auto-registro de repositorios
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderRepository>()
    .AddClasses(classes => classes
        .Where(c => c.Name.EndsWith("Repository") && 
                    !c.IsAbstract))
    .AsMatchingInterface()
    .WithScopedLifetime());

// Configuración adicional
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

## 🎯 Resumen

### ✅ Scrutor en ASP.NET Core

**Características Clave:**
- ✅ Auto-registro de dependencias basado en convenciones
- ✅ Escaneo automático de assemblies
- ✅ Matching de interfaces por nombre
- ✅ Soporte para múltiples lifetimes
- ✅ Filtrado avanzado de clases

**Ventajas:**
- ✅ Reduce código boilerplate significativamente
- ✅ Escalable y mantenible
- ✅ Menos propenso a errores
- ✅ Automático para nuevos servicios

**Cuándo Usar:**
- ✅ Muchos servicios para registrar
- ✅ Convenciones de nombres consistentes
- ✅ Necesitas mantener código limpio
- ✅ Agregas servicios frecuentemente

**Instalación:**
```bash
dotnet add package Scrutor
```

**Uso Básico:**
```csharp
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses()
    .AsMatchingInterface()
    .WithScopedLifetime());
```

---

## 📚 Recursos Adicionales

- [Scrutor GitHub Repository](https://github.com/khellang/Scrutor)
- [Scrutor NuGet Package](https://www.nuget.org/packages/Scrutor/)
- [Microsoft Docs - Dependency Injection](https://learn.microsoft.com/aspnet/core/fundamentals/dependency-injection)

