# Mejores Prácticas: Scrutor en ASP.NET Core

## ✅ Reglas de Oro

### 1. Seguir Convenciones Consistentes

```csharp
// ✅ BIEN: Convención consistente
public interface IOrderService { }
public class OrderService : IOrderService { }

// ❌ MAL: Nombres inconsistentes
public interface IOrderService { }
public class OrderServiceImpl : IOrderService { }  // No funcionará con AsMatchingInterface()
```

### 2. Agrupar por Responsabilidad

```csharp
// ✅ BIEN: Agrupar servicios por responsabilidad
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

### 3. Usar Filtros Específicos

```csharp
// ✅ BIEN: Filtros específicos para evitar registrar clases no deseadas
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

// ✅ SOLUCIÓN 1: Filtrar
builder.Services.Scan(scan => scan
    .FromAssemblyOf<FileLogger>()
    .AddClasses(classes => classes.Where(c => c.Name == "FileLogger"))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

// ✅ SOLUCIÓN 2: Registrar manualmente
builder.Services.AddScoped<ILogger, FileLogger>();
```

### 3. Clases Abstractas

Las clases abstractas no deben registrarse:

```csharp
// ✅ BIEN: Excluir clases abstractas
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes.Where(c => !c.IsAbstract))
    .AsMatchingInterface()
    .WithScopedLifetime());
```

## 🎯 Casos de Uso Específicos

### 1. Servicios con Diferentes Lifetimes

```csharp
// ✅ BIEN: Diferentes lifetimes según el tipo
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

// Caches Singleton
builder.Services.Scan(scan => scan
    .FromAssemblyOf<CacheService>()
    .AddClasses(classes => classes.Where(c => c.Name.EndsWith("Cache")))
    .AsMatchingInterface()
    .WithSingletonLifetime());
```

### 2. Múltiples Assemblies

```csharp
// ✅ BIEN: Escanear múltiples assemblies
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .FromAssemblyOf<CustomerService>()
    .AddClasses()
    .AsMatchingInterface()
    .WithScopedLifetime());
```

### 3. Filtrado por Namespace

```csharp
// ✅ BIEN: Filtrar por namespace
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes.InNamespaces("MyApp.Services", "MyApp.Business"))
    .AsMatchingInterface()
    .WithScopedLifetime());
```

### 4. Combinar con Registro Manual

```csharp
// ✅ BIEN: Auto-registro + registro manual para casos especiales
// Auto-registro para servicios estándar
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses()
    .AsMatchingInterface()
    .WithScopedLifetime());

// Registro manual para casos especiales
builder.Services.AddSingleton<IConfigurationService>(sp => 
    new ConfigurationService(configuration));
builder.Services.AddScoped<IEmailService>(sp => 
    new EmailService(emailSettings));
```

## 📊 Tabla de Decisión

| Escenario | Usar Scrutor | Usar Registro Manual | Razón |
|-----------|--------------|---------------------|-------|
| Muchos servicios (>10) | ✅ | ❌ | Reduce boilerplate |
| Pocos servicios (<5) | ⚠️ | ✅ | Overhead innecesario |
| Convenciones consistentes | ✅ | ❌ | Funciona perfectamente |
| Nombres inconsistentes | ❌ | ✅ | No funcionará bien |
| Múltiples implementaciones | ⚠️ | ✅ | Necesita filtrado específico |
| Configuración especial | ❌ | ✅ | Control granular necesario |
| Agregar servicios frecuentemente | ✅ | ❌ | Automático |

## 💡 Pro Tips

### 1. Validar Registro en Desarrollo

```csharp
// ✅ BIEN: Validar que los servicios se registraron correctamente
if (app.Environment.IsDevelopment())
{
    var serviceProvider = builder.Services.BuildServiceProvider();
    var orderService = serviceProvider.GetService<IOrderService>();
    if (orderService == null)
    {
        throw new InvalidOperationException("IOrderService no está registrado");
    }
}
```

### 2. Usar Logging para Debugging

```csharp
// ✅ BIEN: Logging para ver qué se registró
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses()
    .AsMatchingInterface()
    .WithScopedLifetime())
    .AddDebugLogging();  // Si Scrutor lo soporta
```

### 3. Documentar Convenciones

```csharp
// ✅ BIEN: Documentar las convenciones usadas
// Convenciones:
// - Servicios: I{Name}Service → {Name}Service
// - Repositorios: I{Name}Repository → {Name}Repository
// - Todos los servicios son Scoped
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses()
    .AsMatchingInterface()
    .WithScopedLifetime());
```

## 🚫 Errores Comunes a Evitar

### 1. No Filtrar Clases Abstractas

```csharp
// ❌ MAL: Puede intentar registrar clases abstractas
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses()  // Incluye clases abstractas
    .AsMatchingInterface()
    .WithScopedLifetime());

// ✅ BIEN: Filtrar clases abstractas
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes.Where(c => !c.IsAbstract))
    .AsMatchingInterface()
    .WithScopedLifetime());
```

### 2. Múltiples Implementaciones sin Filtrar

```csharp
// ❌ MAL: Múltiples implementaciones causarán error
public interface ILogger { }
public class FileLogger : ILogger { }
public class DatabaseLogger : ILogger { }

builder.Services.Scan(scan => scan
    .FromAssemblyOf<FileLogger>()
    .AddClasses()
    .AsMatchingInterface()  // Error: múltiples implementaciones
    .WithScopedLifetime());

// ✅ BIEN: Filtrar o usar AsImplementedInterfaces con cuidado
builder.Services.Scan(scan => scan
    .FromAssemblyOf<FileLogger>()
    .AddClasses(classes => classes.Where(c => c.Name == "FileLogger"))
    .AsImplementedInterfaces()
    .WithScopedLifetime());
```

### 3. No Considerar Rendimiento

```csharp
// ❌ MAL: Escanear assemblies grandes sin filtros
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses()  // Escanea TODO
    .AsMatchingInterface()
    .WithScopedLifetime());

// ✅ BIEN: Filtrar para mejorar rendimiento
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes
        .InNamespaces("MyApp.Services")  // Solo este namespace
        .Where(c => c.Name.EndsWith("Service")))
    .AsMatchingInterface()
    .WithScopedLifetime());
```

## 📚 Recursos Adicionales

- [Scrutor GitHub Repository](https://github.com/khellang/Scrutor)
- [Scrutor NuGet Package](https://www.nuget.org/packages/Scrutor/)
- [Microsoft Docs - Dependency Injection](https://learn.microsoft.com/aspnet/core/fundamentals/dependency-injection)

