# Ejemplos Prácticos - Attributes & Reflection

Esta carpeta contiene ejemplos ejecutables que demuestran Attributes & Reflection en .NET.

## Archivos

### `AttributesReflectionExamples.cs`
Demostraciones prácticas de Attributes & Reflection:
- `DemonstratePredefinedAttributes()` - Attributes predefinidos en .NET
- `DemonstrateCustomAttributes()` - Crear attributes personalizados
- `DemonstrateGettingAttributes()` - Obtener attributes usando Reflection
- `DemonstrateInspectingProperties()` - Inspeccionar propiedades con attributes
- `DemonstrateDynamicMethodInvocation()` - Invocación dinámica de métodos
- `DemonstrateValidation()` - Validación usando attributes y reflection
- `DemonstrateDynamicInstanceCreation()` - Creación dinámica de instancias
- `DemonstrateDependencyInjection()` - Dependency Injection con attributes
- `DemonstratePerformanceConsiderations()` - Consideraciones de rendimiento
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Attributes & Reflection
```

## Conceptos Clave

- **Attributes**: Agregan metadatos a elementos de código
- **Reflection**: Inspecciona metadatos en tiempo de ejecución
- **Custom Attributes**: Crear attributes personalizados para necesidades específicas
- **Dynamic Invocation**: Ejecutar métodos dinámicamente sin conocer el tipo en tiempo de compilación

## Ejemplo Básico

```csharp
// Custom attribute applied to a class
[Author("John Doe", Version = "1.0")]
public class MyClass
{
    // ...
}

// Using reflection to get the attribute:
Attribute[] attrs = Attribute.GetCustomAttributes(typeof(MyClass));
```

## Ejemplos Incluidos

### 1. Attributes Predefinidos
```csharp
[Serializable]
public class Person { ... }

[Obsolete("Use NewMethod() instead")]
public void OldMethod() { ... }
```

### 2. Attributes Personalizados
```csharp
[AttributeUsage(AttributeTargets.Class)]
public class AuthorAttribute : Attribute
{
    public string Name { get; set; }
}
```

### 3. Reflection para Obtener Attributes
```csharp
var attributes = Attribute.GetCustomAttributes(typeof(MyClass));
foreach (var attr in attributes)
{
    if (attr is AuthorAttribute author)
    {
        Console.WriteLine($"Author: {author.Name}");
    }
}
```

### 4. Invocación Dinámica
```csharp
var method = obj.GetType().GetMethod("Process");
var result = method.Invoke(obj, new object[] { "input" });
```

## Notas

- Los ejemplos muestran cómo usar attributes y reflection juntos
- Se demuestra la creación de attributes personalizados
- Se incluyen ejemplos prácticos de validación y DI
- Se explican consideraciones de rendimiento importantes

