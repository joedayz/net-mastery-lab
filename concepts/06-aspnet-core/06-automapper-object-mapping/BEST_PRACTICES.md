# Mejores Prácticas: AutoMapper en .NET

## ✅ Reglas de Oro

### 1. Organizar Profiles por Dominio

```csharp
// ✅ BIEN: Profiles organizados por dominio
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserProfile>();
        CreateMap<User, UserSummaryDto>();
        CreateMap<User, UserCreateDto>().ReverseMap();
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
    
    public UserProfile GetUserProfile(int userId)
    {
        var user = _userRepository.GetById(userId);
        return _mapper.Map<UserProfile>(user);
    }
}
```

### 3. Validar Configuración en Desarrollo

```csharp
// ✅ BIEN: Validar configuración en desarrollo
if (app.Environment.IsDevelopment())
{
    var mapper = app.Services.GetRequiredService<IMapper>();
    mapper.ConfigurationProvider.AssertConfigurationIsValid();
}
```

## ⚠️ Consideraciones Importantes

### 1. Convenciones de Nombres

AutoMapper funciona mejor cuando sigues convenciones consistentes:

```csharp
// ✅ BIEN: Nombres similares - mapeo automático
public class User { public int Id { get; set; } }
public class UserDto { public int Id { get; set; } }

// ⚠️ ADVERTENCIA: Nombres diferentes requieren configuración
public class User { public int Id { get; set; } }
public class UserDto { public int UserId { get; set; } } // Requiere ForMember
```

### 2. Propiedades Nullables

AutoMapper maneja propiedades nullables automáticamente:

```csharp
// ✅ BIEN: Funciona automáticamente
public class User { public string? Email { get; set; } }
public class UserDto { public string Email { get; set; } }
```

### 3. Propiedades de Solo Lectura

Las propiedades de solo lectura requieren configuración especial:

```csharp
// ✅ BIEN: Configurar propiedades de solo lectura
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
```

### 4. Propiedades Anidadas

AutoMapper mapea propiedades anidadas automáticamente si tienen el mismo nombre:

```csharp
// ✅ BIEN: Mapeo automático de propiedades anidadas
public class Order
{
    public Customer Customer { get; set; }
}

public class OrderDto
{
    public CustomerDto Customer { get; set; }
}

// Profile
CreateMap<Order, OrderDto>();
CreateMap<Customer, CustomerDto>();
```

## 🎯 Casos de Uso Específicos

### 1. Mapeo Simple (Mismo Nombre)

```csharp
// ✅ BIEN: Mapeo simple cuando los nombres coinciden
CreateMap<User, UserDto>();
// Mapea automáticamente: Id → Id, Email → Email, etc.
```

### 2. Mapeo con Transformaciones

```csharp
// ✅ BIEN: Transformaciones durante el mapeo
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLowerInvariant()))
    .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt.ToString("yyyy-MM-dd")));
```

### 3. Mapeo Bidireccional

```csharp
// ✅ BIEN: ReverseMap para mapeos bidireccionales
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
    .ReverseMap(); // Permite UserProfile → User
```

### 4. Ignorar Propiedades

```csharp
// ✅ BIEN: Ignorar propiedades sensibles
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.Password, opt => opt.Ignore())
    .ForMember(dest => dest.Salt, opt => opt.Ignore());
```

### 5. Mapeo Condicional

```csharp
// ✅ BIEN: Mapeo condicional
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.Email, opt => opt.Condition(src => src.IsActive))
    .ForMember(dest => dest.Phone, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Phone)));
```

## 📊 Tabla de Decisión

| Escenario | Usar AutoMapper | Usar Mapeo Manual | Razón |
|-----------|----------------|-------------------|-------|
| Muchas propiedades (>5) | ✅ | ❌ | Reduce boilerplate |
| Pocas propiedades (<3) | ⚠️ | ✅ | Overhead innecesario |
| Nombres similares | ✅ | ❌ | Mapeo automático |
| Nombres muy diferentes | ✅ | ⚠️ | Requiere configuración |
| Propiedades anidadas | ✅ | ❌ | Mapeo automático |
| Lógica compleja | ⚠️ | ✅ | Puede ser difícil de configurar |
| Múltiples DTOs | ✅ | ❌ | Escalable |
| APIs REST | ✅ | ❌ | Caso de uso común |

## 💡 Pro Tips

### 1. Usar AfterMap para Lógica Compleja

```csharp
// ✅ BIEN: AfterMap para lógica compleja después del mapeo
CreateMap<User, UserProfile>()
    .AfterMap((src, dest) => 
    {
        dest.FullName = $"{src.FirstName} {src.LastName}";
        dest.Age = CalculateAge(src.BirthDate);
    });
```

### 2. Usar ConstructUsing para Creación Personalizada

```csharp
// ✅ BIEN: ConstructUsing para creación personalizada
CreateMap<User, UserProfile>()
    .ConstructUsing(src => new UserProfile
    {
        UserId = src.Id,
        FullName = $"{src.FirstName} {src.LastName}"
    });
```

### 3. Validar Mapeos en Tests

```csharp
// ✅ BIEN: Validar mapeos en tests unitarios
[Fact]
public void User_To_UserProfile_Mapping_Is_Valid()
{
    var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
    config.AssertConfigurationIsValid();
}
```

### 4. Usar ProjectTo para IQueryable

```csharp
// ✅ BIEN: ProjectTo para mapear IQueryable directamente a SQL
var userProfiles = _context.Users
    .ProjectTo<UserProfile>(_mapper.ConfigurationProvider)
    .ToList();
```

## 🚫 Errores Comunes a Evitar

### 1. No Validar Configuración

```csharp
// ❌ MAL: No validar configuración puede causar errores en runtime
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Sin validación

// ✅ BIEN: Validar en desarrollo
if (app.Environment.IsDevelopment())
{
    var mapper = app.Services.GetRequiredService<IMapper>();
    mapper.ConfigurationProvider.AssertConfigurationIsValid();
}
```

### 2. Mapear Propiedades Sensibles

```csharp
// ❌ MAL: Mapear propiedades sensibles sin protección
CreateMap<User, UserProfile>();
// Password se mapea automáticamente

// ✅ BIEN: Ignorar propiedades sensibles
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.Password, opt => opt.Ignore())
    .ForMember(dest => dest.Salt, opt => opt.Ignore());
```

### 3. No Manejar Nulls

```csharp
// ❌ MAL: No manejar nulls puede causar NullReferenceException
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
// Si FirstName o LastName son null, falla

// ✅ BIEN: Manejar nulls
CreateMap<User, UserProfile>()
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => 
        $"{src.FirstName ?? ""} {src.LastName ?? ""}".Trim()));
```

### 4. Crear Múltiples Instancias de IMapper

```csharp
// ❌ MAL: Crear múltiples instancias
var mapper1 = new Mapper(config);
var mapper2 = new Mapper(config);

// ✅ BIEN: Usar Dependency Injection
public class UserService
{
    private readonly IMapper _mapper;
    
    public UserService(IMapper mapper)
    {
        _mapper = mapper;
    }
}
```

## 📚 Recursos Adicionales

- [AutoMapper GitHub Repository](https://github.com/AutoMapper/AutoMapper)
- [AutoMapper NuGet Package](https://www.nuget.org/packages/AutoMapper/)
- [AutoMapper Documentation](https://docs.automapper.org/)
- [AutoMapper.Extensions.Microsoft.DependencyInjection](https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/)

