using System;

namespace NetMasteryLab.Concepts.AspNetCore.MinimalApis.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Minimal APIs en ASP.NET Core
    /// </summary>
    public class MinimalApisExamples
    {
        /// <summary>
        /// Demuestra la estructura básica de Minimal APIs
        /// </summary>
        public static void DemonstrateBasicStructure()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔹 APIs Mínimas Mejoradas - Estructura Básica");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Minimal API básica:");
            Console.WriteLine("```csharp");
            Console.WriteLine("app.MapGet(\"/hello\", () => \"Hello, World!\");");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Con parámetros:");
            Console.WriteLine("```csharp");
            Console.WriteLine("app.MapGet(\"/users/{id:int}\", (int id) => GetUser(id));");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Con Dependency Injection:");
            Console.WriteLine("```csharp");
            Console.WriteLine("app.MapGet(\"/users/{id}\", async (int id, IUserService service) =>");
            Console.WriteLine("    await service.GetUserByIdAsync(id));");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra comparación con Controllers
        /// </summary>
        public static void DemonstrateComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Comparación: Minimal APIs vs Controllers");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ Controller tradicional:");
            Console.WriteLine("```csharp");
            Console.WriteLine("[ApiController]");
            Console.WriteLine("[Route(\"api/[controller]\")]");
            Console.WriteLine("public class UsersController : ControllerBase");
            Console.WriteLine("{");
            Console.WriteLine("    [HttpGet(\"{id}\")]");
            Console.WriteLine("    public async Task<IActionResult> GetUser(int id)");
            Console.WriteLine("    {");
            Console.WriteLine("        var user = await _userService.GetUserByIdAsync(id);");
            Console.WriteLine("        return user == null ? NotFound() : Ok(user);");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Minimal API equivalente:");
            Console.WriteLine("```csharp");
            Console.WriteLine("app.MapGet(\"/api/users/{id}\", async (int id, IUserService service) =>");
            Console.WriteLine("{");
            Console.WriteLine("    var user = await service.GetUserByIdAsync(id);");
            Console.WriteLine("    return user == null ? Results.NotFound() : Results.Ok(user);");
            Console.WriteLine("});");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Menos código boilerplate");
            Console.WriteLine("  • Mejor rendimiento");
            Console.WriteLine("  • DI automática\n");
        }

        /// <summary>
        /// Demuestra agrupación de endpoints
        /// </summary>
        public static void DemonstrateGrouping()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🗂️ Agrupación de Endpoints");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Agrupar endpoints relacionados:");
            Console.WriteLine("```csharp");
            Console.WriteLine("var usersApi = app.MapGroup(\"/api/users\");");
            Console.WriteLine("usersApi.MapGet(\"/\", GetAllUsers);");
            Console.WriteLine("usersApi.MapGet(\"/{id}\", GetUser);");
            Console.WriteLine("usersApi.MapPost(\"/\", CreateUser);");
            Console.WriteLine("usersApi.MapPut(\"/{id}\", UpdateUser);");
            Console.WriteLine("usersApi.MapDelete(\"/{id}\", DeleteUser);");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra cuándo usar Minimal APIs
        /// </summary>
        public static void DemonstrateWhenToUse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Cuándo Usar Minimal APIs");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Usar Minimal APIs cuando:");
            Console.WriteLine("  • Creas microservicios pequeños");
            Console.WriteLine("  • Necesitas endpoints simples y directos");
            Console.WriteLine("  • Priorizas rendimiento y simplicidad");
            Console.WriteLine("  • Tienes pocos endpoints relacionados\n");

            Console.WriteLine("⚠️ Considerar Controllers cuando:");
            Console.WriteLine("  • Tienes múltiples acciones relacionadas");
            Console.WriteLine("  • Necesitas lógica compleja de negocio");
            Console.WriteLine("  • Requieres filtros y atributos avanzados");
            Console.WriteLine("  • Construyes aplicaciones grandes y complejas\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          APIs Mínimas Mejoradas en ASP.NET Core              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateBasicStructure();
            Console.WriteLine("\n");
            DemonstrateComparison();
            Console.WriteLine("\n");
            DemonstrateGrouping();
            Console.WriteLine("\n");
            DemonstrateWhenToUse();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Minimal APIs:");
            Console.WriteLine("   • Menos código boilerplate");
            Console.WriteLine("   • Mejor rendimiento");
            Console.WriteLine("   • DI automática");
            Console.WriteLine("   • Ideal para microservicios y APIs simples\n");
        }
    }
}

