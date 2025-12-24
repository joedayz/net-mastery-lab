# Ejemplos Prácticos - Clear & Descriptive Property Names

Esta carpeta contiene ejemplos ejecutables que demuestran cómo elegir nombres claros y descriptivos para propiedades en C#.

## Archivos

### `ClearDescriptivePropertyNamesExamples.cs`
Demostraciones prácticas de nombres claros y descriptivos:
- `DemonstrateClearDescriptiveNames()` - Nombres claros y descriptivos
- `DemonstrateAvoidAmbiguity()` - Evitar ambigüedad
- `DemonstrateConsistency()` - Consistencia en nomenclatura
- `DemonstrateAvoidRedundancy()` - Evitar redundancia
- `DemonstrateDomainTerms()` - Términos del dominio
- `DemonstrateBalance()` - Equilibrio en nombres
- `DemonstrateBeforeAfter()` - Comparación antes vs después
- `DemonstrateChecklist()` - Checklist para nombres
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Clear & Descriptive Property Names
```

## Conceptos Clave

- **Readability**: Nombres que se explican por sí mismos
- **Maintenance**: Código autoexplicativo para el futuro
- **Context**: Evitar ambigüedad con nombres específicos
- **Consistency**: Mantener convenciones consistentes
- **Simplicity**: Evitar redundancia innecesaria
- **Domain Terms**: Usar lenguaje del negocio
- **Balance**: Descriptivo pero no abrumador

## Ejemplo Básico: Nombres Claros

```csharp
public class Order
{
    public int OrderId { get; set; } // Unique identifier for the order
    public DateTime OrderDate { get; set; } // Date the order was placed
    public string CustomerName { get; set; } // Name of the customer placing the order
    public decimal OrderAmount { get; set; } // Total amount for the order
    public string OrderStatus { get; set; } // Status of the order
}
```

## Notas

- Los ejemplos muestran claramente las diferencias entre nombres buenos y malos
- Se incluyen errores comunes y cómo evitarlos
- Se explica cuándo usar redundancia y cuándo evitarla
- Se demuestra el equilibrio entre descriptivo y conciso

## Requisitos

- Conocimientos básicos de C#
- Comprensión de propiedades en C#
- Conocimientos básicos de Clean Code principles

