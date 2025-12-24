# Ejemplos Prácticos - Abstract Class vs Interface

Esta carpeta contiene ejemplos ejecutables que demuestran las diferencias entre Abstract Class e Interface.

## Archivos

### `AbstractClassVsInterfaceExamples.cs`
Demostraciones prácticas de Abstract Class vs Interface:
- `DemonstrateComparison()` - Comparación visual en tabla
- `DemonstrateImplementation()` - Diferencias en implementación
- `DemonstrateInheritance()` - Diferencias en herencia
- `DemonstrateAccessModifiers()` - Diferencias en modificadores de acceso
- `DemonstratePurpose()` - Diferencias en propósito
- `DemonstrateVehicleExample()` - Ejemplo completo con vehículos
- `DemonstrateWhenToUse()` - Cuándo usar cada uno
- `DemonstrateCombination()` - Combinando ambos
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Abstract Class vs Interface
```

## Conceptos Clave

- **Abstract Class**: Puede tener métodos abstractos y concretos, herencia simple, constructores, campos
- **Interface**: Principalmente declaraciones, herencia múltiple, sin constructores, sin campos
- **Implementation**: Abstract Class = abstract + concrete methods, Interface = principalmente declaraciones
- **Inheritance**: Abstract Class = simple, Interface = múltiple
- **Access Modifiers**: Abstract Class = todos, Interface = principalmente public
- **Purpose**: Abstract Class = comportamiento común, Interface = contrato

## Ejemplo Básico: Abstract Class

```csharp
public abstract class Animal
{
    protected string Name { get; set; }
    
    public Animal(string name) { Name = name; }
    
    public abstract void MakeSound();
    public void Sleep() { Console.WriteLine($"{Name} is sleeping"); }
}
```

## Ejemplo Básico: Interface

```csharp
public interface IAnimal
{
    void MakeSound();
    string Name { get; set; }
}
```

## Ejemplo: Combinación

```csharp
public abstract class Vehicle
{
    public int Speed { get; set; }
    public abstract void Accelerate();
}

public interface IVehicleFeatures
{
    void ApplyBrakes();
    void TurnOnLights();
}

public class Car : Vehicle, IVehicleFeatures
{
    public override void Accelerate() { Speed += 15; }
    public void ApplyBrakes() { Speed = Math.Max(0, Speed - 20); }
    public void TurnOnLights() { Console.WriteLine("Lights on"); }
}
```

## Notas

- Los ejemplos muestran claramente las diferencias entre Abstract Class e Interface
- Se incluyen ejemplos prácticos de cuándo usar cada uno
- Se demuestra cómo combinar ambos para máximo beneficio
- Se explican las mejores prácticas y errores comunes

## Requisitos

- C# 8.0 o superior (para algunas características de interfaces)
- .NET 6.0 o superior

