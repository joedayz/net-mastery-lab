# Mejores Prácticas: Attributes & Reflection

## ✅ Reglas de Oro

### 1. Usar Attributes para Metadatos Declarativos

```csharp
// ✅ BIEN: Usar attributes para información declarativa
[Author("John Doe", Version = "1.0")]
[Serializable]
public class MyClass
{
    // ...
}

// ❌ MAL: Intentar usar attributes para lógica de negocio
[ValidateAndProcess] // No usar attributes para lógica compleja
public class MyClass
{
    // ...
}
```

### 2. Cachear Información de Reflection

```csharp
// ❌ MAL: Obtener información de Reflection repetidamente
for (int i = 0; i < 1000000; i++)
{
    var method = obj.GetType().GetMethod("Process");
    method.Invoke(obj, null); // Muy lento
}

// ✅ BIEN: Cachear información de Reflection
private static readonly MethodInfo ProcessMethod = 
    typeof(MyClass).GetMethod("Process");

for (int i = 0; i < 1000000; i++)
{
    ProcessMethod.Invoke(obj, null); // Más rápido
}
```

### 3. Especificar AttributeTargets Correctamente

```csharp
// ✅ BIEN: Especificar dónde se puede usar el attribute
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorAttribute : Attribute
{
    // ...
}

// ❌ MAL: Permitir uso en cualquier lugar sin restricción
[AttributeUsage(AttributeTargets.All)] // Demasiado permisivo
public class AuthorAttribute : Attribute
{
    // ...
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Usar Reflection en Código Crítico de Rendimiento

```csharp
// ❌ MAL: Reflection en loops críticos
public void ProcessItems(List<object> items)
{
    foreach (var item in items)
    {
        var method = item.GetType().GetMethod("Process");
        method.Invoke(item, null); // Muy lento
    }
}

// ✅ BIEN: Cachear o usar alternativas más rápidas
private static readonly Dictionary<Type, MethodInfo> MethodCache = new();

public void ProcessItems(List<object> items)
{
    foreach (var item in items)
    {
        var type = item.GetType();
        if (!MethodCache.ContainsKey(type))
        {
            MethodCache[type] = type.GetMethod("Process");
        }
        MethodCache[type].Invoke(item, null);
    }
}
```

### 2. No Validar Null en Reflection

```csharp
// ❌ MAL: No validar si el método existe
var method = type.GetMethod("Process");
method.Invoke(obj, null); // Puede ser null

// ✅ BIEN: Validar antes de usar
var method = type.GetMethod("Process");
if (method != null)
{
    method.Invoke(obj, null);
}
else
{
    throw new MethodNotFoundException("Process method not found");
}
```

### 3. Usar Attributes Incorrectamente

```csharp
// ❌ MAL: Usar attributes para lógica de ejecución
[ExecuteOnStartup]
public class MyService
{
    // Attributes no ejecutan código directamente
}

// ✅ BIEN: Usar attributes para metadatos, procesar con Reflection
[Startup]
public class MyService
{
    // ...
}

// En otro lugar, procesar attributes
var types = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => t.GetCustomAttribute<StartupAttribute>() != null);
```

## 🎯 Casos de Uso Específicos

### 1. Validación con Attributes

```csharp
// ✅ BIEN: Validación declarativa con attributes
public class User
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; }
    
    [EmailAddress]
    [Required]
    public string Email { get; set; }
}

public class ValidationService
{
    public ValidationResult Validate(object obj)
    {
        var result = new ValidationResult();
        var type = obj.GetType();
        var properties = type.GetProperties();
        
        foreach (var prop in properties)
        {
            var value = prop.GetValue(obj);
            var attributes = prop.GetCustomAttributes<ValidationAttribute>();
            
            foreach (var attr in attributes)
            {
                if (!attr.IsValid(value))
                {
                    result.AddError(prop.Name, attr.ErrorMessage);
                }
            }
        }
        
        return result;
    }
}
```

### 2. Dependency Injection con Attributes

```csharp
// ✅ BIEN: Registrar servicios automáticamente
[AttributeUsage(AttributeTargets.Class)]
public class InjectableAttribute : Attribute
{
    public ServiceLifetime Lifetime { get; set; }
}

public static void RegisterServices(IServiceCollection services, Assembly assembly)
{
    var types = assembly.GetTypes()
        .Where(t => t.GetCustomAttribute<InjectableAttribute>() != null);
    
    foreach (var type in types)
    {
        var attr = type.GetCustomAttribute<InjectableAttribute>();
        var interfaces = type.GetInterfaces();
        
        foreach (var interfaceType in interfaces)
        {
            services.Add(new ServiceDescriptor(
                interfaceType, 
                type, 
                attr.Lifetime));
        }
    }
}
```

### 3. Serialización Personalizada

```csharp
// ✅ BIEN: Usar attributes para controlar serialización
[AttributeUsage(AttributeTargets.Property)]
public class JsonIgnoreAttribute : Attribute
{
}

public class JsonSerializer
{
    public string Serialize(object obj)
    {
        var type = obj.GetType();
        var properties = type.GetProperties()
            .Where(p => p.GetCustomAttribute<JsonIgnoreAttribute>() == null);
        
        // Serializar solo propiedades sin JsonIgnore
        // ...
    }
}
```

## 🚀 Tips Avanzados

### 1. Usar Expresiones en lugar de Reflection cuando sea posible

```csharp
// ⚠️ CUIDADO: Reflection es más lento que expresiones
var method = type.GetMethod("Process");
method.Invoke(obj, null);

// ✅ BIEN: Usar expresiones para mejor rendimiento
Expression<Action<T>> expression = x => x.Process();
var compiled = expression.Compile();
compiled(obj);
```

### 2. Usar Source Generators para Attributes (.NET 5+)

```csharp
// ✅ BIEN: Source generators pueden procesar attributes en tiempo de compilación
[GenerateValidation]
public class User
{
    public string Name { get; set; }
}

// El source generator genera código de validación automáticamente
```

### 3. Combinar Attributes con Reflection para Frameworks

```csharp
// ✅ BIEN: Crear framework que use attributes y reflection
[Route("/api/users")]
public class UserController
{
    [HttpGet("{id}")]
    public User GetUser(int id)
    {
        // ...
    }
}

// Framework procesa attributes para routing
public class RoutingFramework
{
    public void RegisterRoutes(Assembly assembly)
    {
        var controllers = assembly.GetTypes()
            .Where(t => t.GetCustomAttribute<RouteAttribute>() != null);
        
        foreach (var controller in controllers)
        {
            var route = controller.GetCustomAttribute<RouteAttribute>();
            var methods = controller.GetMethods()
                .Where(m => m.GetCustomAttribute<HttpGetAttribute>() != null);
            
            // Registrar rutas dinámicamente
        }
    }
}
```

### 4. Validar Attributes en Tiempo de Compilación

```csharp
// ✅ BIEN: Validar attributes en tiempo de compilación cuando sea posible
[AttributeUsage(AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute
{
    public string[] Roles { get; set; }
    
    public AuthorizeAttribute(params string[] roles)
    {
        if (roles == null || roles.Length == 0)
        {
            throw new ArgumentException("At least one role is required");
        }
        Roles = roles;
    }
}
```

## 📊 Comparación: Reflection vs Alternativas

| Método | Rendimiento | Flexibilidad | Complejidad |
|--------|-------------|--------------|-------------|
| **Reflection** | Lento | Alta | Media |
| **Expresiones** | Rápido | Media | Alta |
| **Delegates** | Muy rápido | Baja | Baja |
| **Source Generators** | Compile-time | Alta | Alta |

## 📚 Recursos Adicionales

- [Microsoft Docs - Attributes](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/attributes/)
- [Microsoft Docs - Reflection](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/reflection)
- [Microsoft Docs - Source Generators](https://docs.microsoft.com/dotnet/csharp/roslyn-sdk/source-generators-overview)

