# Ejemplos Prácticos - Types of Inheritance in .NET Core

Esta carpeta contiene ejemplos ejecutables que demuestran los diferentes tipos de herencia en .NET Core.

## Archivos

### `TypesOfInheritanceExamples.cs`
Demostraciones prácticas de los tipos de herencia:
- `DemonstrateSingleInheritance()` - Herencia simple (Vehicle → Car)
- `DemonstrateMultipleInheritance()` - Herencia múltiple vía interfaces (ILogger + IDisposable)
- `DemonstrateMultilevelInheritance()` - Herencia multinivel (Vehicle → Car → ElectricCar)
- `DemonstrateHierarchicalInheritance()` - Herencia jerárquica (Vehicle → Car, Bike, Truck)
- `DemonstrateHybridInheritance()` - Herencia híbrida (BaseEntity + IAuditable + ISoftDeletable)
- `DemonstrateBenefits()` - Beneficios de usar herencia
- `DemonstrateComparison()` - Comparación de tipos de herencia
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Types of Inheritance
```

## Conceptos Clave

- **Single Inheritance**: Una clase hereda de una clase base única
- **Multiple Inheritance**: Una clase implementa múltiples interfaces
- **Multilevel Inheritance**: Cadena de herencia (A → B → C)
- **Hierarchical Inheritance**: Múltiples clases de una base común
- **Hybrid Inheritance**: Combinación de clase base + interfaces
- **Code Reusability**: Reutilización de código sin duplicación
- **Maintainability**: Cambios centralizados se propagan automáticamente
- **Scalability**: Fácil agregar nuevas funcionalidades
- **Polymorphism**: Tratamiento uniforme de objetos diferentes

## Ejemplo Básico: Single Inheritance

```csharp
public class Vehicle
{
    public int Speed { get; set; }
}

public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
}
```

## Ejemplo Básico: Multiple Inheritance

```csharp
public interface ILogger { void Log(string message); }
public interface IDisposable { void Dispose(); }

public class FileLogger : ILogger, IDisposable
{
    public void Log(string message) { }
    public void Dispose() { }
}
```

## Ejemplo Básico: Multilevel Inheritance

```csharp
public class Vehicle { }
public class Car : Vehicle { }
public class ElectricCar : Car { }
```

## Ejemplo Básico: Hierarchical Inheritance

```csharp
public class Vehicle { }
public class Car : Vehicle { }
public class Bike : Vehicle { }
public class Truck : Vehicle { }
```

## Ejemplo Básico: Hybrid Inheritance

```csharp
public class BaseEntity { }
public interface IAuditable { }
public interface ISoftDeletable { }

public class Order : BaseEntity, IAuditable, ISoftDeletable { }
```

## Notas

- Los ejemplos muestran claramente cada tipo de herencia
- Se incluyen casos de uso prácticos en .NET Core
- Se explican los beneficios de cada tipo
- Se proporciona una comparación completa

## Requisitos

- Conocimientos básicos de C# y OOP
- Comprensión de clases e interfaces
- Conocimientos básicos de .NET Core

