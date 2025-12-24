using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMasteryLab.Concepts.AspNetCore.AutoMapperObjectMapping.Examples
{
    /// <summary>
    /// Ejemplos que demuestran AutoMapper para Object Mapping en .NET
    /// </summary>
    public class AutoMapperExamples
    {
        /// <summary>
        /// Demuestra la comparación entre mapeo manual y AutoMapper
        /// </summary>
        public static void DemonstrateComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Mapeo Manual vs AutoMapper");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ ANTES: Mapeo Manual - verboso y propenso a errores");
            Console.WriteLine("```csharp");
            Console.WriteLine("public UserProfile GetUserProfile(int userId)");
            Console.WriteLine("{");
            Console.WriteLine("    var user = _userRepository.GetById(userId);");
            Console.WriteLine("    ");
            Console.WriteLine("    // Mapeo manual - repetitivo y propenso a errores");
            Console.WriteLine("    var userProfile = new UserProfile");
            Console.WriteLine("    {");
            Console.WriteLine("        UserId = user.Id,");
            Console.WriteLine("        FullName = $\"{user.FirstName} {user.LastName}\",");
            Console.WriteLine("        Email = user.Email,");
            Console.WriteLine("        CreatedDate = user.CreatedAt,");
            Console.WriteLine("        IsActive = user.IsActive");
            Console.WriteLine("    };");
            Console.WriteLine("    ");
            Console.WriteLine("    return userProfile;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ DESPUÉS: AutoMapper - limpio y escalable");
            Console.WriteLine("```csharp");
            Console.WriteLine("public UserProfile GetUserProfile(int userId)");
            Console.WriteLine("{");
            Console.WriteLine("    var user = _userRepository.GetById(userId);");
            Console.WriteLine("    ");
            Console.WriteLine("    // Mapeo automático - limpio y sin errores");
            Console.WriteLine("    return _mapper.Map<UserProfile>(user);");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas de AutoMapper:");
            Console.WriteLine("  ✅ Conciso: Una línea mapea múltiples propiedades");
            Console.WriteLine("  ✅ Automático: Mapea propiedades por nombre automáticamente");
            Console.WriteLine("  ✅ Menos Errores: No hay riesgo de olvidar propiedades");
            Console.WriteLine("  ✅ Escalable: Funciona igual con 5 o 50 propiedades");
            Console.WriteLine("  ✅ Mantenible: Cambios en las clases se reflejan automáticamente\n");
        }

        /// <summary>
        /// Demuestra cómo funciona AutoMapper
        /// </summary>
        public static void DemonstrateHowItWorks()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔧 Cómo Funciona AutoMapper");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Configuración del Profile");
            Console.WriteLine("   AutoMapper necesita un perfil que defina cómo mapear entre tipos\n");

            Console.WriteLine("2. Registro en Dependency Injection");
            Console.WriteLine("   Se registra AutoMapper en el contenedor de DI\n");

            Console.WriteLine("3. Uso en Servicios");
            Console.WriteLine("   Se inyecta IMapper y se usa para mapear objetos\n");

            Console.WriteLine("Ejemplo de código:");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Profile");
            Console.WriteLine("public class MappingProfile : Profile");
            Console.WriteLine("{");
            Console.WriteLine("    public MappingProfile()");
            Console.WriteLine("    {");
            Console.WriteLine("        CreateMap<User, UserProfile>()");
            Console.WriteLine("            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))");
            Console.WriteLine("            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $\"{src.FirstName} {src.LastName}\"));");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("// Registro");
            Console.WriteLine("builder.Services.AddAutoMapper(typeof(MappingProfile));");
            Console.WriteLine("");
            Console.WriteLine("// Uso");
            Console.WriteLine("var userProfile = _mapper.Map<UserProfile>(user);");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra ejemplos prácticos
        /// </summary>
        public static void DemonstratePracticalExamples()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Ejemplos Prácticos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo 1: Mapeo Básico");
            Console.WriteLine("```csharp");
            Console.WriteLine("CreateMap<User, UserProfile>()");
            Console.WriteLine("    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))");
            Console.WriteLine("    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $\"{src.FirstName} {src.LastName}\"));");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 2: Mapeo de Colecciones");
            Console.WriteLine("```csharp");
            Console.WriteLine("var users = _userRepository.GetAll();");
            Console.WriteLine("return _mapper.Map<List<UserProfile>>(users);");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 3: Mapeo Inverso");
            Console.WriteLine("```csharp");
            Console.WriteLine("CreateMap<User, UserProfile>().ReverseMap();");
            Console.WriteLine("var user = _mapper.Map<User>(userProfile);");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 4: Mapeo con Propiedades Anidadas");
            Console.WriteLine("```csharp");
            Console.WriteLine("CreateMap<Order, OrderDto>()");
            Console.WriteLine("    .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $\"{src.Customer.FirstName} {src.Customer.LastName}\"));");
            Console.WriteLine("CreateMap<OrderItem, OrderItemDto>();");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra métodos principales de AutoMapper
        /// </summary>
        public static void DemonstrateMainMethods()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔍 Métodos Principales de AutoMapper");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("CreateMap<TSource, TDestination>()");
            Console.WriteLine("  Crea un mapeo entre dos tipos");
            Console.WriteLine("  CreateMap<User, UserProfile>();\n");

            Console.WriteLine("ForMember()");
            Console.WriteLine("  Configura el mapeo de una propiedad específica");
            Console.WriteLine("  .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $\"{src.FirstName} {src.LastName}\"));\n");

            Console.WriteLine("Map<TDestination>(object source)");
            Console.WriteLine("  Mapea un objeto fuente a un objeto destino");
            Console.WriteLine("  var userProfile = _mapper.Map<UserProfile>(user);\n");

            Console.WriteLine("Map<TDestination>(IEnumerable<TSource> source)");
            Console.WriteLine("  Mapea una colección de objetos fuente");
            Console.WriteLine("  var userProfiles = _mapper.Map<List<UserProfile>>(users);\n");

            Console.WriteLine("ReverseMap()");
            Console.WriteLine("  Crea mapeo bidireccional");
            Console.WriteLine("  CreateMap<User, UserProfile>().ReverseMap();\n");

            Console.WriteLine("Ignore()");
            Console.WriteLine("  Ignora una propiedad durante el mapeo");
            Console.WriteLine("  .ForMember(dest => dest.Password, opt => opt.Ignore());\n");
        }

        /// <summary>
        /// Demuestra mejores prácticas
        /// </summary>
        public static void DemonstrateBestPractices()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Mejores Prácticas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Organizar Profiles por Dominio");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class UserMappingProfile : Profile");
            Console.WriteLine("{");
            Console.WriteLine("    public UserMappingProfile()");
            Console.WriteLine("    {");
            Console.WriteLine("        CreateMap<User, UserProfile>();");
            Console.WriteLine("        CreateMap<User, UserSummaryDto>();");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("2. Usar Dependency Injection");
            Console.WriteLine("```csharp");
            Console.WriteLine("builder.Services.AddAutoMapper(typeof(MappingProfile));");
            Console.WriteLine("");
            Console.WriteLine("public class UserService");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly IMapper _mapper;");
            Console.WriteLine("    ");
            Console.WriteLine("    public UserService(IMapper mapper)");
            Console.WriteLine("    {");
            Console.WriteLine("        _mapper = mapper;");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("3. Validar Configuración");
            Console.WriteLine("```csharp");
            Console.WriteLine("if (app.Environment.IsDevelopment())");
            Console.WriteLine("{");
            Console.WriteLine("    var mapper = app.Services.GetRequiredService<IMapper>();");
            Console.WriteLine("    mapper.ConfigurationProvider.AssertConfigurationIsValid();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra casos de uso
        /// </summary>
        public static void DemonstrateUseCases()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Casos de Uso");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Usa AutoMapper cuando:");
            Console.WriteLine("  • Necesitas mapear entre Entities y DTOs frecuentemente");
            Console.WriteLine("  • Tienes múltiples DTOs para diferentes contextos");
            Console.WriteLine("  • Quieres reducir código boilerplate");
            Console.WriteLine("  • Necesitas mantener código limpio y mantenible");
            Console.WriteLine("  • Trabajas con APIs REST o microservicios\n");

            Console.WriteLine("⚠️ Considera Mapeo Manual cuando:");
            Console.WriteLine("  • Tienes pocos mapeos simples (1-2 propiedades)");
            Console.WriteLine("  • Necesitas lógica de mapeo muy compleja");
            Console.WriteLine("  • El rendimiento es crítico y necesitas optimización manual");
            Console.WriteLine("  • Los objetos tienen estructuras muy diferentes\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Object Mapping in .NET with AutoMapper                     ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateComparison();
            Console.WriteLine("\n");
            DemonstrateHowItWorks();
            Console.WriteLine("\n");
            DemonstratePracticalExamples();
            Console.WriteLine("\n");
            DemonstrateMainMethods();
            Console.WriteLine("\n");
            DemonstrateBestPractices();
            Console.WriteLine("\n");
            DemonstrateUseCases();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ AutoMapper en .NET:");
            Console.WriteLine("   • Mapeo automático entre objetos");
            Console.WriteLine("   • Reducción de código boilerplate");
            Console.WriteLine("   • Configuración flexible y personalizable");
            Console.WriteLine("   • Integración con Dependency Injection");
            Console.WriteLine("   • Soporte para colecciones y propiedades anidadas\n");
            
            Console.WriteLine("🚀 Ventajas:");
            Console.WriteLine("   • Elimina código repetitivo de mapeo");
            Console.WriteLine("   • Reduce errores humanos");
            Console.WriteLine("   • Mantiene código limpio y mantenible");
            Console.WriteLine("   • Ideal para mapear Entities ↔ DTOs\n");
            
            Console.WriteLine("📦 Instalación:");
            Console.WriteLine("   dotnet add package AutoMapper");
            Console.WriteLine("   dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection\n");
            
            Console.WriteLine("💡 Uso Básico:");
            Console.WriteLine("   builder.Services.AddAutoMapper(typeof(MappingProfile));");
            Console.WriteLine("   var userProfile = _mapper.Map<UserProfile>(user);\n");
        }
    }
}

