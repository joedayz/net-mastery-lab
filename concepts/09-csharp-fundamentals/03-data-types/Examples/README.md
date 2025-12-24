# Ejemplos Prácticos - Data Types

Esta carpeta contiene ejemplos ejecutables que demuestran Value Types vs Reference Types en C#.

## Archivos

### `DataTypesExamples.cs`
Demostraciones prácticas de Data Types:
- `DemonstratePreDefinedValueTypes()` - Tipos de valor predefinidos (int, char, bool, etc.)
- `DemonstrateUserDefinedValueTypes()` - Tipos de valor definidos por usuario (enum, struct)
- `DemonstratePreDefinedReferenceTypes()` - Tipos de referencia predefinidos (object, string)
- `DemonstrateUserDefinedReferenceTypes()` - Tipos de referencia definidos por usuario (class, array)
- `DemonstrateValueVsReferenceComparison()` - Comparación entre value y reference types
- `DemonstratePassingAsParameters()` - Pasar tipos como parámetros
- `DemonstrateTypeComparison()` - Comparación de tipos
- `DemonstrateNullableValueTypes()` - Nullable value types
- `DemonstratePracticalExamples()` - Ejemplos prácticos
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Data Types
```

## Conceptos Clave

- **Value Types**: Almacenan datos directamente, se copian por valor, se almacenan en la stack
- **Reference Types**: Almacenan dirección de memoria, se copian por referencia, se almacenan en la heap
- **Pre-Defined Types**: Tipos incorporados en el lenguaje (int, string, object)
- **User-Defined Types**: Tipos definidos por el usuario (struct, class, enum, interface)

## Ejemplo Básico

```csharp
// VALUE TYPE: Copia por valor
int a = 10;
int b = a;      // b es una copia independiente
b = 20;         // a sigue siendo 10

// REFERENCE TYPE: Copia por referencia
Person p1 = new Person { Name = "Alice" };
Person p2 = p1; // p2 apunta al mismo objeto
p2.Name = "Bob"; // p1.Name también es "Bob"
```

## Ejemplos Incluidos

### 1. Value Types Predefinidos
```csharp
int i = 42;
bool flag = true;
char c = 'A';
```

### 2. Value Types Definidos por Usuario
```csharp
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

Point p1 = new Point { X = 10, Y = 20 };
Point p2 = p1; // Copia por valor
```

### 3. Reference Types Predefinidos
```csharp
string str1 = "Hello";
string str2 = str1; // Referencia a la misma cadena
```

### 4. Reference Types Definidos por Usuario
```csharp
public class Person
{
    public string Name { get; set; }
}

Person p1 = new Person { Name = "Alice" };
Person p2 = p1; // Referencia al mismo objeto
```

## Notas

- Los ejemplos muestran claramente la diferencia entre value y reference types
- Se demuestra cómo se comportan al asignar y modificar
- Se explica el concepto de copia por valor vs copia por referencia
- Se incluyen ejemplos prácticos de cuándo usar cada tipo

