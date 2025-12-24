# Object Mapping in .NET with AutoMapper ⚡

## Introducción

**AutoMapper** es una librería de mapeo objeto-a-objeto para .NET que ayuda a los desarrolladores a mapear automáticamente propiedades entre dos clases diferentes sin escribir código repetitivo. Es especialmente útil para mapear entre entidades de base de datos y DTOs (Data Transfer Objects) en aplicaciones ASP.NET Core.

## 🚀 ¿Qué es AutoMapper?

AutoMapper es una librería de código abierto que simplifica el mapeo entre objetos de diferentes tipos. En lugar de escribir código manual repetitivo para copiar propiedades de un objeto a otro, AutoMapper lo hace automáticamente basándose en convenciones o configuración personalizada.

### Características Principales

- ✅ **Mapeo Automático**: Mapea propiedades automáticamente por nombre
- ✅ **Configuración Flexible**: Permite configuración personalizada para casos complejos
- ✅ **Reducción de Código**: Elimina código boilerplate de mapeo
- ✅ **Type-Safe**: Verificación de tipos en tiempo de compilación
- ✅ **Integración ASP.NET Core**: Funciona perfectamente con Dependency Injection
- ✅ **Performance**: Optimizado para rendimiento

## 📖 El Problema: Mapeo Manual (Before) ❌

El mapeo manual entre objetos puede volverse verboso, propenso a errores y difícil de mantener.

```csharp
// ❌ ANTES: Mapeo manual - verboso y propenso a errores
public class UserService
{
    public UserProfile GetUserProfile(int userId)
    {
        var user = _userRepository.GetById(userId);
        
        // Mapeo manual - repetitivo y propenso a errores
        var userProfile = new UserProfile
        {
            UserId = user.Id,
            FullName = $"{user.FirstName} {user.LastName}",
            Email = user.Email,
            CreatedDate = user.CreatedAt,
            IsActive = user.IsActive
        };
        
        return userProfile;
    }
}
```

**Problemas del Mapeo Manual:**
- ❌ **Verboso**: Muchas líneas de código repetitivas
- ❌ **Propenso a Errores**: Fácil olvidar mapear una propiedad o mapearla incorrectamente
- ❌ **Difícil de Mantener**: Cambios en las clases requieren actualizar el mapeo
- ❌ **No Escalable**: Con muchos DTOs, el código se vuelve difícil de manejar

## ✅ La Solución: AutoMapper (After) ✨

AutoMapper permite mapear objetos automáticamente con configuración mínima.

```csharp
// ✅ DESPUÉS: AutoMapper - limpio y escalable
public class UserService
{
    private readonly IMapper _mapper;
    
    public UserService(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public UserProfile GetUserProfile(int userId)
    {
        var user = _userRepository.GetById(userId);
        
        // Mapeo automático - limpio y sin errores
        return _mapper.Map<UserProfile>(user);
    }
}
```

**Ventajas de AutoMapper:**
- ✅ **Conciso**: Una línea mapea múltiples propiedades
- ✅ **Automático**: Mapea propiedades por nombre automáticamente
- ✅ **Menos Errores**: No hay riesgo de olvidar propiedades
- ✅ **Escalable**: Funciona igual con 5 o 50 propiedades
- ✅ **Mantenible**: Cambios en las clases se reflejan automáticamente

## 🔧 Instalación

### NuGet Package

```bash
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

O desde el Package Manager Console:

```powershell
Install-Package AutoMapper
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
```

### Usando .NET CLI

```bash
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

## 💡 Cómo Funciona AutoMapper

### 1. Configuración Básica

AutoMapper necesita un perfil de mapeo que defina cómo mapear entre tipos.

```csharp
// Profile de AutoMapper
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeo simple - propiedades con mismo nombre
        CreateMap<User, UserProfile>();
        
        // Mapeo con configuración personalizada
        CreateMap<User, UserProfile>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
    }
}
```

### 2. Registro en Dependency Injection

```csharp
// Program.cs o Startup.cs
builder.Services.AddAutoMapper(typeof(MappingProfile));
```

### 3. Uso en Servicios

```csharp
public class UserService
{
    private readonly IMapper _mapper;
    
    public UserService(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public UserProfile GetUserProfile(int userId)
    {
        var user = _userRepository.GetById(userId);
        return _mapper.Map<UserProfile>(user);
    }
}
```

## 🎯 Ejemplos Prácticos

### Ejemplo 1: Mapeo Básico

```csharp
// Entidad (Database)
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}

// DTO (API Response)
public class UserProfile
{
    public int UserId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}

// Profile
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserProfile>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt));
    }
}
```

### Ejemplo 2: Mapeo de Colecciones

```csharp
// Mapeo de lista de usuarios
public List<UserProfile> GetAllUserProfiles()
{
    var users = _userRepository.GetAll();
    return _mapper.Map<List<UserProfile>>(users);
}

// O usando IEnumerable
public IEnumerable<UserProfile> GetAllUserProfiles()
{
    var users = _userRepository.GetAll();
    return _mapper.Map<IEnumerable<UserProfile>>(users);
}
```

### Ejemplo 3: Mapeo Inverso

```csharp
// Profile con mapeo bidireccional
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserProfile>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ReverseMap(); // Permite mapeo inverso: UserProfile → User
    }
}

// Uso del mapeo inverso
public void UpdateUser(UserProfile userProfile)
{
    var user = _mapper.Map<User>(userProfile);
    _userRepository.Update(user);
}
```

### Ejemplo 4: Mapeo con Propiedades Anidadas

```csharp
// Entidad con propiedades anidadas
public class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public User Customer { get; set; }
    public List<OrderItem> Items { get; set; }
}

public class OrderItem
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

// DTO
public class OrderDto
{
    public int OrderId { get; set; }
    public decimal Total { get; set; }
    public string CustomerName { get; set; }
    public List<OrderItemDto> Items { get; set; }
}

public class OrderItemDto
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

// Profile
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"));
        
        CreateMap<OrderItem, OrderItemDto>();
    }
}
```

### Ejemplo 5: Mapeo con Condiciones

```csharp
// Profile con condiciones
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserProfile>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Email, opt => opt.Condition(src => src.IsActive)); // Solo mapea si IsActive es true
    }
}
```

### Ejemplo 6: Mapeo con Transformaciones

```csharp
// Profile con transformaciones
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserProfile>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLowerInvariant()))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt.ToString("yyyy-MM-dd")));
    }
}
```

## 📊 Comparación Detallada

| Aspecto | Mapeo Manual | AutoMapper |
|---------|--------------|------------|
| **Líneas de Código** | 1 por propiedad | 1 línea total |
| **Mantenibilidad** | Baja (actualizar manualmente) | Alta (automático) |
| **Escalabilidad** | Difícil con muchas propiedades | Excelente |
| **Propenso a Errores** | Alto (olvidar propiedades) | Bajo (automático) |
| **Flexibilidad** | Alta (control total) | Alta (configuración personalizada) |
| **Rendimiento** | Mismo | Optimizado |

## 🎯 Casos de Uso

### ✅ Usa AutoMapper cuando:

- Necesitas mapear entre Entities y DTOs frecuentemente
- Tienes múltiples DTOs para diferentes contextos
- Quieres reducir código boilerplate
- Necesitas mantener código limpio y mantenible
- Trabajas con APIs REST o microservicios

### ⚠️ Considera Mapeo Manual cuando:

- Tienes pocos mapeos simples (1-2 propiedades)
- Necesitas lógica de mapeo muy compleja
- El rendimiento es crítico y necesitas optimización manual
- Los objetos tienen estructuras muy diferentes

## 🔍 Métodos Principales de AutoMapper

### `CreateMap<TSource, TDestination>()`
Crea un mapeo entre dos tipos.

```csharp
CreateMap<User, UserProfile>();
```

### `ForMember()`
Configura el mapeo de una propiedad específica.

```csharp
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
```

### `Map<TDestination>(object source)`
Mapea un objeto fuente a un objeto destino.

```csharp
var userProfile = _mapper.Map<UserProfile>(user);
```

### `Map<TDestination>(IEnumerable<TSource> source)`
Mapea una colección de objetos fuente.

```csharp
var userProfiles = _mapper.Map<List<UserProfile>>(users);
```

### `ReverseMap()`
Crea mapeo bidireccional.

```csharp
CreateMap<User, UserProfile>().ReverseMap();
```

### `Ignore()`
Ignora una propiedad durante el mapeo.

```csharp
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.Password, opt => opt.Ignore());
```

## ⚠️ Consideraciones Importantes

### 1. Convenciones de Nombres

AutoMapper funciona mejor cuando sigues convenciones consistentes:

```csharp
// ✅ BIEN: Nombres similares
public class User { public int Id { get; set; } }
public class UserDto { public int Id { get; set; } }

// ⚠️ ADVERTENCIA: Nombres diferentes requieren configuración
public class User { public int Id { get; set; } }
public class UserDto { public int UserId { get; set; } } // Requiere ForMember
```

### 2. Propiedades Nullables

AutoMapper maneja propiedades nullables automáticamente:

```csharp
// Funciona automáticamente
public class User { public string? Email { get; set; } }
public class UserDto { public string Email { get; set; } }
```

### 3. Propiedades de Solo Lectura

Las propiedades de solo lectura requieren configuración especial:

```csharp
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
```

## 💡 Mejores Prácticas

### 1. Organizar Profiles por Dominio

```csharp
// ✅ BIEN: Profiles organizados por dominio
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserProfile>();
        CreateMap<User, UserSummaryDto>();
    }
}

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<OrderItem, OrderItemDto>();
    }
}
```

### 2. Usar Dependency Injection

```csharp
// ✅ BIEN: Registrar AutoMapper en DI
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ✅ BIEN: Inyectar IMapper en servicios
public class UserService
{
    private readonly IMapper _mapper;
    
    public UserService(IMapper mapper)
    {
        _mapper = mapper;
    }
}
```

### 3. Validar Configuración

```csharp
// ✅ BIEN: Validar configuración en desarrollo
if (app.Environment.IsDevelopment())
{
    var mapper = app.Services.GetRequiredService<IMapper>();
    mapper.ConfigurationProvider.AssertConfigurationIsValid();
}
```

### 4. Usar ReverseMap para Mapeos Bidireccionales

```csharp
// ✅ BIEN: ReverseMap para mapeos bidireccionales
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
    .ReverseMap();
```

## 📚 Ejemplo Completo: Program.cs

```csharp
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Otros servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Validar configuración en desarrollo
if (app.Environment.IsDevelopment())
{
    var mapper = app.Services.GetRequiredService<IMapper>();
    mapper.ConfigurationProvider.AssertConfigurationIsValid();
}

// Configuración de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

## 🎯 Resumen

### ✅ AutoMapper en .NET

**Características Clave:**
- ✅ Mapeo automático entre objetos
- ✅ Reducción de código boilerplate
- ✅ Configuración flexible y personalizable
- ✅ Integración con Dependency Injection
- ✅ Soporte para colecciones y propiedades anidadas

**Ventajas:**
- ✅ Elimina código repetitivo de mapeo
- ✅ Reduce errores humanos
- ✅ Mantiene código limpio y mantenible
- ✅ Ideal para mapear Entities ↔ DTOs

**Cuándo Usar:**
- ✅ Mapeo frecuente entre Entities y DTOs
- ✅ Múltiples DTOs para diferentes contextos
- ✅ APIs REST o microservicios
- ✅ Necesitas código limpio y mantenible

**Instalación:**
```bash
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

**Uso Básico:**
```csharp
// Configuración
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserProfile>();
    }
}

// Registro
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Uso
var userProfile = _mapper.Map<UserProfile>(user);
```

---

## 📚 Recursos Adicionales

- [AutoMapper GitHub Repository](https://github.com/AutoMapper/AutoMapper)
- [AutoMapper NuGet Package](https://www.nuget.org/packages/AutoMapper/)
- [AutoMapper Documentation](https://docs.automapper.org/)
- [AutoMapper.Extensions.Microsoft.DependencyInjection](https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/)

