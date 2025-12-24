# Ejemplos Prácticos - Key Class Concepts

Esta carpeta contiene ejemplos ejecutables que demuestran los conceptos clave de clases en OOP.

## Archivos

### `KeyClassConceptsExamples.cs`
Demostraciones prácticas de conceptos clave de clases:
- `DemonstrateInstanceOfClass()` - Instancias de una clase
- `DemonstrateReferenceOfClass()` - Referencias de una clase
- `DemonstrateInstanceVariables()` - Variables de instancia
- `DemonstrateStaticVariables()` - Variables estáticas (class variables)
- `DemonstrateInstanceVsReference()` - Comparación instancia vs referencia
- `DemonstrateInstanceVsStaticVariables()` - Comparación instance vs static variables
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 44-45 para los ejemplos de Key Class Concepts:
#   44. Key Class Concepts - Comparación
#   45. Key Class Concepts - Ejemplos prácticos
```

## Conceptos Clave

- **Instance of a Class**: Objeto creado con 'new', tiene su propia memoria
- **Reference of a Class**: Variable que apunta a instancia existente (no es copia)
- **Instance Variables**: Variables que pertenecen a cada instancia (no compartidas)
- **Static Variables**: Variables que pertenecen a la clase (compartidas por todas las instancias)

## Ejemplo Básico

```csharp
// INSTANCE: Crea un nuevo objeto en memoria
Person person1 = new Person { Name = "Alice", Age = 30 };
Person person2 = new Person { Name = "Bob", Age = 25 };
// person1 y person2 son objetos diferentes

// REFERENCE: Apunta al mismo objeto
Person person3 = person1;
// person3 y person1 apuntan al mismo objeto en memoria

// INSTANCE VARIABLES: Cada instancia tiene su propia copia
public class BankAccount
{
    private decimal _balance; // Cada cuenta tiene su propio balance
}

// STATIC VARIABLES: Compartidas por todas las instancias
public class Counter
{
    public static int TotalCount = 0; // Compartida por todas
}
```

## Notas

- Los ejemplos muestran claramente la diferencia entre instancias y referencias
- Se demuestra cómo las instance variables son independientes
- Se explica cómo las static variables son compartidas
- Se incluyen comparaciones visuales entre los conceptos

