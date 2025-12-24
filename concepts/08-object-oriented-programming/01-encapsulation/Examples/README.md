# Ejemplos Prácticos - Encapsulation (Encapsulación)

Esta carpeta contiene ejemplos ejecutables que demuestran el concepto de encapsulación en C#.

## Archivos

### `EncapsulationExamples.cs`
Demostraciones prácticas de encapsulación:
- `DemonstrateWithoutEncapsulation()` - Muestra el problema de no usar encapsulación
- `DemonstrateBasicEncapsulation()` - Encapsulación básica con auto-properties
- `DemonstrateEncapsulationWithValidation()` - Encapsulación con validación
- `DemonstrateReadOnlyProperties()` - Propiedades de solo lectura
- `DemonstrateCalculatedProperties()` - Propiedades calculadas
- `DemonstrateFullEncapsulation()` - Encapsulación completa con BankAccount
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 34-35 para los ejemplos de Encapsulation:
#   34. Encapsulation - Comparación
#   35. Encapsulation - Ejemplos prácticos
```

## Conceptos Clave

- **Bundling Data and Methods**: Agrupa datos (campos) y métodos dentro de una clase
- **Restrict Direct Access**: Restringe acceso directo a componentes internos
- **Protect Internal State**: Protege el estado interno del objeto
- **Well-Defined Interfaces**: Expone solo funcionalidad necesaria a través de propiedades y métodos

## Ejemplo Básico

```csharp
public class Person
{
    public string Name { get; set; } = "Default Name"; // Auto-property with default value
}
```

## Notas

- Los ejemplos muestran claramente la diferencia entre código sin y con encapsulación
- Se incluyen diferentes niveles de encapsulación (básica, con validación, completa)
- Se demuestran propiedades calculadas y de solo lectura
- Se explica cómo proteger el estado interno de los objetos

