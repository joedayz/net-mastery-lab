# Ejemplos Prácticos - AutoMapper en .NET

Esta carpeta contiene ejemplos ejecutables que demuestran cómo usar AutoMapper para mapeo de objetos en .NET.

## Archivos

### `AutoMapperExamples.cs`
Demostraciones prácticas de AutoMapper:
- `DemonstrateComparison()` - Comparación mapeo manual vs AutoMapper
- `DemonstrateHowItWorks()` - Cómo funciona AutoMapper internamente
- `DemonstratePracticalExamples()` - Ejemplos prácticos de uso
- `DemonstrateMainMethods()` - Métodos principales de AutoMapper
- `DemonstrateBestPractices()` - Mejores prácticas
- `DemonstrateUseCases()` - Casos de uso
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de AutoMapper
```

## Conceptos Clave

- **AutoMapper**: Librería para mapeo objeto-a-objeto
- **Profile**: Configuración de mapeos entre tipos
- **Map**: Método para mapear objetos
- **ForMember**: Configurar mapeo de propiedades específicas
- **ReverseMap**: Mapeo bidireccional

## Ejemplo Básico: Comparación

```csharp
// ❌ ANTES: Mapeo Manual
var userProfile = new UserProfile
{
    UserId = user.Id,
    FullName = $"{user.FirstName} {user.LastName}",
    Email = user.Email,
    CreatedDate = user.CreatedAt,
    IsActive = user.IsActive
};

// ✅ DESPUÉS: AutoMapper
var userProfile = _mapper.Map<UserProfile>(user);
```

## Ejemplo: Configuración Básica

```csharp
// Profile
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserProfile>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
    }
}

// Registro
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Uso
var userProfile = _mapper.Map<UserProfile>(user);
```

## Ejemplo: Mapeo de Colecciones

```csharp
var users = _userRepository.GetAll();
return _mapper.Map<List<UserProfile>>(users);
```

## Ejemplo: Mapeo Bidireccional

```csharp
CreateMap<User, UserProfile>().ReverseMap();
var user = _mapper.Map<User>(userProfile);
```

## Notas

- Los ejemplos muestran claramente la diferencia entre mapeo manual y AutoMapper
- Se incluyen todos los métodos principales de AutoMapper
- Se explican las mejores prácticas y cuándo usar cada enfoque
- Se cubren casos de uso comunes como Entities ↔ DTOs

## Requisitos

- Conocimientos básicos de C# y .NET
- Comprensión de Dependency Injection
- Conocimientos básicos de DTOs y Entities

## Instalación

```bash
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

