# Ejemplos Prácticos - Inheritance with Virtual/Override and Dependency Injection

Esta carpeta contiene ejemplos ejecutables que demuestran cómo combinar herencia con métodos virtual/override y Dependency Injection en ASP.NET Core.

## Archivos

### `InheritanceDIExamples.cs`
Demostraciones prácticas de herencia con DI:
- `DemonstrateBasicInheritance()` - Herencia básica con virtual/override
- `DemonstrateDependencyInjection()` - Dependency Injection básico
- `DemonstrateAspNetCoreDI()` - Configuración de ASP.NET Core con DI
- `DemonstrateVirtualMethods()` - Métodos virtuales y concretos
- `DemonstrateWithInterfaces()` - Uso con interfaces (mejor práctica)
- `DemonstrateCompleteExample()` - Ejemplo completo con PaymentProcessor
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 38-39 para los ejemplos de Inheritance + DI:
#   38. Inheritance + DI - Comparación
#   39. Inheritance + DI - Ejemplos prácticos
```

## Conceptos Clave

- **Virtual Methods**: Permiten sobrescritura en clases derivadas, promoviendo flexibilidad
- **Override**: Proporciona implementación específica de métodos virtuales
- **Dependency Injection**: Inyección de dependencias en runtime para componentes desacoplados
- **Minimal APIs**: Endpoints concisos con DI automático en ASP.NET Core

## Ejemplo Básico

```csharp
// Base class with a virtual method
public class Animal
{
    public virtual string Speak() => "Animal sound";
}

// Derived class overriding the virtual method
public class Dog : Animal
{
    public override string Speak() => "Woof!";
}

// AnimalService using dependency injection
public class AnimalService
{
    private readonly Animal _animal;
    
    public AnimalService(Animal animal) => _animal = animal;
    
    public string GetAnimalSound() => _animal.Speak();
}
```

## Configuración ASP.NET Core

```csharp
// Program.cs (ASP.NET Core)
var builder = WebApplication.CreateBuilder(args);

// Register Dog or Cat class as Animal in the DI container
builder.Services.AddScoped<Animal, Dog>();

var app = builder.Build();

app.MapGet("/", (AnimalService animalService) => animalService.GetAnimalSound());

app.Run();
```

## Notas

- Los ejemplos muestran cómo combinar herencia con Dependency Injection
- Se incluyen ejemplos de configuración de ASP.NET Core con Minimal APIs
- Se demuestra el uso de interfaces para mejor desacoplamiento
- Se explica cómo los métodos virtuales permiten polimorfismo en tiempo de ejecución

