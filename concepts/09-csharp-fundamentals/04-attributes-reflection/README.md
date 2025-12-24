# Attributes & Reflection en .NET 🔍

## Introducción

En .NET, los atributos (Attributes) y la reflexión (Reflection) no son solo características técnicas—son herramientas esenciales para escribir código robusto, adaptable y altamente escalable. Estas capacidades mejoran el desarrollo de aplicaciones y la calidad del código.

## 📖 ¿Qué son los Attributes?

Los **Attributes** en .NET agregan una capa de metadatos a tu código, aplicados a clases, métodos, propiedades y más. Al marcar elementos con atributos como `[CustomValidation]` o `[Serializable]`, estás incrustando información crucial que el runtime de .NET, las bibliotecas y la aplicación misma pueden aprovechar para tomar decisiones en tiempo de ejecución.

### Características de los Attributes

- **Metadatos**: Proporcionan información adicional sobre elementos de código
- **No afectan la ejecución directa**: Los atributos por sí solos no cambian el comportamiento del código
- **Accesibles vía Reflection**: Se pueden leer en tiempo de ejecución usando Reflection
- **Decoradores**: Se aplican usando corchetes `[AttributeName]`

### Ejemplo Básico

```csharp
[Serializable] // Custom attribute applied to a class
public class MyClass
{
    // ...
}

// Using reflection to get the attribute:
Attribute[] attrs = Attribute.GetCustomAttributes(typeof(MyClass));
```

## 🎯 Attributes Predefinidos en .NET

### 1. Serializable

```csharp
[Serializable]
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

### 2. Obsolete

```csharp
[Obsolete("Use NewMethod() instead")]
public void OldMethod()
{
    // ...
}

[Obsolete("This method will be removed in v2.0", true)] // Error en lugar de warning
public void DeprecatedMethod()
{
    // ...
}
```

### 3. Required (Data Annotations)

```csharp
using System.ComponentModel.DataAnnotations;

public class User
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
    [EmailAddress]
    [Required]
    public string Email { get; set; }
}
```

### 4. Display (Data Annotations)

```csharp
[Display(Name = "Full Name", Description = "Enter your full name")]
public string FullName { get; set; }
```

## 🛠️ Crear Attributes Personalizados

### Ejemplo: Custom Validation Attribute

```csharp
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class CustomValidationAttribute : Attribute
{
    public string ErrorMessage { get; set; }
    public int MinLength { get; set; }
    
    public CustomValidationAttribute(int minLength)
    {
        MinLength = minLength;
    }
}

// Uso
public class Product
{
    [CustomValidation(5, ErrorMessage = "Name must be at least 5 characters")]
    public string Name { get; set; }
}
```

### Ejemplo: Author Attribute

```csharp
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorAttribute : Attribute
{
    public string Name { get; set; }
    public string Version { get; set; }
    
    public AuthorAttribute(string name)
    {
        Name = name;
    }
}

// Uso
[Author("John Doe", Version = "1.0")]
public class MyService
{
    // ...
}
```

## 🔍 Reflection: La Clave para la Flexibilidad en Runtime

**Reflection** es la característica de .NET que permite a las aplicaciones inspeccionar e interactuar con metadatos de objetos en tiempo de ejecución, haciendo posible analizar atributos y tipos dinámicamente.

### Características de Reflection

- **Inspección de Tipos**: Obtener información sobre tipos en tiempo de ejecución
- **Acceso a Metadatos**: Leer atributos y metadatos
- **Invocación Dinámica**: Ejecutar métodos sin conocer el tipo en tiempo de compilación
- **Creación Dinámica**: Crear instancias de tipos dinámicamente

## 💡 Casos de Uso de Attributes & Reflection

### 1. Dependency Injection

```csharp
[AttributeUsage(AttributeTargets.Class)]
public class InjectableAttribute : Attribute
{
    public ServiceLifetime Lifetime { get; set; }
    
    public InjectableAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        Lifetime = lifetime;
    }
}

// Automáticamente resolver dependencias escaneando atributos
public static void RegisterServices(IServiceCollection services)
{
    var types = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.GetCustomAttribute<InjectableAttribute>() != null);
    
    foreach (var type in types)
    {
        var attr = type.GetCustomAttribute<InjectableAttribute>();
        services.Add(new ServiceDescriptor(type, type, attr.Lifetime));
    }
}
```

### 2. Validation & Custom Serialization

```csharp
public class ValidationService
{
    public bool Validate(object obj)
    {
        var type = obj.GetType();
        var properties = type.GetProperties();
        
        foreach (var prop in properties)
        {
            var requiredAttr = prop.GetCustomAttribute<RequiredAttribute>();
            if (requiredAttr != null)
            {
                var value = prop.GetValue(obj);
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    return false; // Validation failed
                }
            }
        }
        
        return true;
    }
}
```

### 3. Dynamic Method Invocation

```csharp
public class MethodInvoker
{
    public object InvokeMethod(object obj, string methodName, params object[] parameters)
    {
        var type = obj.GetType();
        var method = type.GetMethod(methodName);
        
        if (method != null)
        {
            return method.Invoke(obj, parameters);
        }
        
        throw new MethodNotFoundException($"Method {methodName} not found");
    }
}

// Uso
var service = new MyService();
var invoker = new MethodInvoker();
var result = invoker.InvokeMethod(service, "ProcessData", "input");
```

## 🎯 Ejemplos Prácticos

### Ejemplo 1: Obtener Attributes de una Clase

```csharp
[Author("Jane Doe", Version = "2.0")]
public class MyClass
{
    // ...
}

// Obtener atributos usando Reflection
var attributes = Attribute.GetCustomAttributes(typeof(MyClass));
foreach (var attr in attributes)
{
    if (attr is AuthorAttribute author)
    {
        Console.WriteLine($"Author: {author.Name}, Version: {author.Version}");
    }
}
```

### Ejemplo 2: Inspeccionar Propiedades con Attributes

```csharp
public class User
{
    [Required]
    [Display(Name = "User Name")]
    public string UserName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
}

// Inspeccionar propiedades
var userType = typeof(User);
var properties = userType.GetProperties();

foreach (var prop in properties)
{
    Console.WriteLine($"Property: {prop.Name}");
    
    var attributes = prop.GetCustomAttributes();
    foreach (var attr in attributes)
    {
        Console.WriteLine($"  Attribute: {attr.GetType().Name}");
    }
}
```

### Ejemplo 3: Crear Instancias Dinámicamente

```csharp
public class Factory
{
    public T CreateInstance<T>(string typeName) where T : class
    {
        var type = Type.GetType(typeName);
        if (type != null)
        {
            return Activator.CreateInstance(type) as T;
        }
        return null;
    }
}

// Uso
var factory = new Factory();
var instance = factory.CreateInstance<MyClass>("MyNamespace.MyClass");
```

## ⚠️ Consideraciones de Rendimiento

### Reflection es Costoso

```csharp
// ❌ MAL: Usar Reflection en código crítico de rendimiento
for (int i = 0; i < 1000000; i++)
{
    var method = obj.GetType().GetMethod("Process");
    method.Invoke(obj, null); // Muy lento
}

// ✅ BIEN: Cachear información de Reflection
var method = obj.GetType().GetMethod("Process");
var methodDelegate = (Action)Delegate.CreateDelegate(typeof(Action), obj, method);

for (int i = 0; i < 1000000; i++)
{
    methodDelegate(); // Mucho más rápido
}
```

## 🚀 Por qué Attributes y Reflection Importan

Attributes y Reflection permiten a los desarrolladores de .NET crear código flexible, reutilizable y altamente mantenible. Frameworks importantes como **ASP.NET Core** y **Entity Framework** dependen de estas características para implementar funcionalidad central, como:

- **Routing**: Mapeo de rutas basado en atributos
- **Model Validation**: Validación automática de modelos
- **Data Mapping**: Mapeo de datos entre objetos y bases de datos
- **Dependency Injection**: Resolución automática de dependencias

### Beneficios

1. **Streamline Codebase**: Reducir código boilerplate haciendo aplicaciones más adaptables
2. **Boost Flexibility**: Habilitar ajustes dinámicos al comportamiento de la aplicación basados en metadatos
3. **Enhance Reusability**: Permitir código limpio y modular que puede ser fácilmente extendido o adaptado

## 📚 Recursos Adicionales

- [Microsoft Docs - Attributes](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/attributes/)
- [Microsoft Docs - Reflection](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/reflection)
- [Microsoft Docs - Creating Custom Attributes](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/attributes/creating-custom-attributes)

