# Ejemplos Prácticos - Scrutor en ASP.NET Core

Esta carpeta contiene ejemplos ejecutables que demuestran cómo usar Scrutor para auto-registrar dependencias en ASP.NET Core.

## Archivos

### `ScrutorExamples.cs`
Demostraciones prácticas de Scrutor:
- `DemonstrateComparison()` - Comparación registro manual vs Scrutor
- `DemonstrateHowItWorks()` - Cómo funciona Scrutor internamente
- `DemonstratePracticalExamples()` - Ejemplos prácticos de uso
- `DemonstrateMainMethods()` - Métodos principales de Scrutor
- `DemonstrateBestPractices()` - Mejores prácticas
- `DemonstrateConsiderations()` - Consideraciones importantes
- `DemonstrateWhenToUse()` - Cuándo usar Scrutor
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Scrutor
```

## Conceptos Clave

- **Scrutor**: Librería para auto-registro de dependencias
- **Scan**: Escanea assemblies en busca de clases
- **AsMatchingInterface**: Empareja clases con interfaces por nombre
- **Lifetimes**: Scoped, Transient, Singleton
- **Filtrado**: Filtrar qué clases registrar

## Ejemplo Básico: Comparación

```csharp
// ❌ ANTES: Registro Manual
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
// ... muchos más

// ✅ DESPUÉS: Scrutor
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses()
    .AsMatchingInterface()
    .WithScopedLifetime());
```

## Ejemplo: Registro Básico

```csharp
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses()
    .AsMatchingInterface()
    .WithScopedLifetime());
```

## Ejemplo: Filtrado por Namespace

```csharp
builder.Services.Scan(scan => scan
    .FromAssemblyOf<OrderService>()
    .AddClasses(classes => classes.InNamespaces("MyApp.Services"))
    .AsMatchingInterface()
    .WithScopedLifetime());
```

## Ejemplo: Diferentes Lifetimes

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
```

## Notas

- Los ejemplos muestran claramente la diferencia entre registro manual y Scrutor
- Se incluyen todos los métodos principales de Scrutor
- Se explican las mejores prácticas y cuándo usar cada enfoque
- Se cubren consideraciones importantes como múltiples implementaciones

## Requisitos

- Conocimientos básicos de ASP.NET Core
- Comprensión de Dependency Injection
- Conocimientos básicos de convenciones de nombres en C#

## Instalación

```bash
dotnet add package Scrutor
```

