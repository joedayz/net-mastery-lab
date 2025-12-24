# Ejemplos Prácticos - Abstraction (Abstracción)

Esta carpeta contiene ejemplos ejecutables que demuestran el concepto de abstracción en C# usando abstract classes y records.

## Archivos

### `AbstractionExamples.cs`
Demostraciones prácticas de abstracción:
- `DemonstrateWithoutAbstraction()` - Muestra el problema de no usar abstracción
- `DemonstrateBasicAbstraction()` - Abstracción básica con abstract class
- `DemonstrateAbstractRecord()` - Abstract record (C# 10+)
- `DemonstrateMixedAbstraction()` - Abstracción mixta (métodos concretos y abstractos)
- `DemonstrateInterfaceAbstraction()` - Abstracción con interfaces
- `DemonstrateRealWorldAbstraction()` - Abstracción en sistemas reales (PaymentProcessor)
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 36-37 para los ejemplos de Abstraction:
#   36. Abstraction - Comparación
#   37. Abstraction - Ejemplos prácticos
```

## Conceptos Clave

- **Essential Features Only**: Solo expone características esenciales del objeto
- **Interface Design**: Define QUÉ hacer, no CÓMO hacerlo
- **Flexibility and Extensibility**: Permite múltiples implementaciones del mismo concepto
- **Separation of Concerns**: Separa el qué del cómo para código modular y mantenible

## Ejemplo Básico

```csharp
public abstract record Shape
{
    public abstract double GetArea(); // Abstract method to be implemented by derived classes
}

public record Circle(double Radius) : Shape
{
    public override double GetArea() => Math.PI * Radius * Radius;
    // Circle-specific implementation
}
```

## Notas

- Los ejemplos muestran claramente la diferencia entre código sin y con abstracción
- Se incluyen ejemplos con abstract classes, abstract records e interfaces
- Se demuestran casos de uso reales como procesadores de pago
- Se explica cómo la abstracción oculta detalles complejos y muestra solo lo esencial

