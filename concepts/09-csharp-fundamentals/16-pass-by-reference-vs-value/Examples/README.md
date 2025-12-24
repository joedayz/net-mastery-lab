# Ejemplos Prácticos - Pass By Reference vs Pass By Value

Esta carpeta contiene ejemplos ejecutables que demuestran las diferencias entre Pass By Reference y Pass By Value en C#.

## Archivos

### `PassByReferenceVsValueExamples.cs`
Demostraciones prácticas de Pass By Reference vs Pass By Value:
- `DemonstratePassByReference()` - Pass By Reference con ref
- `DemonstratePassByValue()` - Pass By Value (comportamiento por defecto)
- `DemonstrateDifference()` - Diferencia clave: reasignación
- `DemonstrateOutParameters()` - out parameters
- `DemonstrateInParameters()` - in parameters (C# 7.0+)
- `DemonstrateValueTypesVsReferenceTypes()` - Value Types vs Reference Types
- `DemonstrateCommonMistakes()` - Errores comunes a evitar
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Pass By Reference vs Pass By Value
```

## Conceptos Clave

- **Pass By Value**: Comportamiento por defecto, se pasa una copia
- **Pass By Reference**: Con `ref`, se pasa una referencia directa
- **out Parameters**: Similar a `ref` pero sin requerir inicialización
- **in Parameters**: Referencia de solo lectura (C# 7.0+)
- **Value Types**: Se pasan por copia del valor
- **Reference Types**: Se pasa una copia de la referencia

## Ejemplo Básico: Pass By Value

```csharp
void FillCup(Cup myCup)
{
    myCup.Contents = "coffee";  // Modifica el objeto original
    myCup = new Cup();          // Solo afecta la copia local
}
```

## Ejemplo Básico: Pass By Reference

```csharp
void FillCup(ref Cup myCup)
{
    myCup.Contents = "coffee";  // Modifica el objeto original
    myCup = new Cup();          // También afecta al original
}
```

## Notas

- Los ejemplos muestran claramente las diferencias entre Pass By Value y Pass By Reference
- Se incluyen errores comunes y cómo evitarlos
- Se explica cuándo usar cada enfoque según el escenario

## Requisitos

- Conocimientos básicos de C#
- Comprensión de Value Types vs Reference Types
- Conocimientos básicos de métodos y parámetros

