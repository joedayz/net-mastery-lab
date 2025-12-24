using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMasteryLab.Concepts.EntityFrameworkCore.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Entity Framework Core
    /// </summary>
    public class EntityFrameworkCoreExamples
    {
        /// <summary>
        /// Demuestra qué es EF Core y sus ventajas
        /// </summary>
        public static void DemonstrateWhatIsEfCore()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📌 ¿Qué es EF Core?");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Entity Framework Core es un ORM (Object-Relational Mapper) que:");
            Console.WriteLine("  • Mapea objetos a tablas: Las clases C# se convierten en tablas");
            Console.WriteLine("  • Traduce LINQ a SQL: Las consultas LINQ se convierten en SQL");
            Console.WriteLine("  • Maneja relaciones: Define y maneja relaciones automáticamente");
            Console.WriteLine("  • Gestiona cambios: Rastrea cambios y los sincroniza con la BD");
            Console.WriteLine("  • Soporta múltiples BD: SQL Server, MySQL, PostgreSQL, SQLite\n");
        }

        /// <summary>
        /// Demuestra por qué usar EF Core
        /// </summary>
        public static void DemonstrateWhyUseEfCore()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🚀 ¿Por Qué Usar EF Core?");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1️⃣ No Necesitas Consultas SQL Crudas");
            Console.WriteLine("   ❌ SIN EF Core: SQL crudo");
            Console.WriteLine("   var query = \"SELECT * FROM Users WHERE Age > @age\";");
            Console.WriteLine("");
            Console.WriteLine("   ✅ CON EF Core: LINQ type-safe");
            Console.WriteLine("   var users = context.Users.Where(u => u.Age > 18).ToList();\n");

            Console.WriteLine("2️⃣ Independiente de la Base de Datos");
            Console.WriteLine("   ✅ Soporta múltiples proveedores:");
            Console.WriteLine("   • SQL Server");
            Console.WriteLine("   • PostgreSQL");
            Console.WriteLine("   • MySQL");
            Console.WriteLine("   • SQLite\n");

            Console.WriteLine("3️⃣ Migraciones Automáticas de Esquema");
            Console.WriteLine("   ✅ Versionado de esquema de base de datos");
            Console.WriteLine("   ✅ Migraciones automáticas en desarrollo y producción\n");

            Console.WriteLine("4️⃣ Productividad Mejorada");
            Console.WriteLine("   ✅ Menos código boilerplate");
            Console.WriteLine("   ✅ Enfoque en lógica de negocio");
            Console.WriteLine("   ✅ Operaciones CRUD simplificadas\n");

            Console.WriteLine("5️⃣ Seguimiento de Cambios Integrado");
            Console.WriteLine("   ✅ No necesitas rastrear cambios manualmente");
            Console.WriteLine("   ✅ Optimización automática\n");

            Console.WriteLine("6️⃣ Carga Lazy y Eager");
            Console.WriteLine("   ✅ Control sobre cuándo cargar datos relacionados");
            Console.WriteLine("   ✅ Optimización de consultas\n");

            Console.WriteLine("7️⃣ Mejor Rendimiento con Consultas Compiladas");
            Console.WriteLine("   ✅ Consultas precompiladas");
            Console.WriteLine("   ✅ Mejor rendimiento en consultas repetitivas\n");

            Console.WriteLine("8️⃣ Integración Perfecta con ASP.NET Core");
            Console.WriteLine("   ✅ Inyección de dependencias automática");
            Console.WriteLine("   ✅ Funciona con MVC, Web API y Blazor\n");
        }

        /// <summary>
        /// Demuestra cómo funciona EF Core
        /// </summary>
        public static void DemonstrateHowEfCoreWorks()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📌 ¿Cómo Funciona EF Core?");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1️⃣ Definir Modelos");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class User");
            Console.WriteLine("{");
            Console.WriteLine("    public int Id { get; set; }");
            Console.WriteLine("    public string Name { get; set; }");
            Console.WriteLine("    public string Email { get; set; }");
            Console.WriteLine("    public ICollection<Order> Orders { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("2️⃣ Configurar DbContext");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class AppDbContext : DbContext");
            Console.WriteLine("{");
            Console.WriteLine("    public DbSet<User> Users { get; set; }");
            Console.WriteLine("    public DbSet<Order> Orders { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("3️⃣ Ejecutar Migraciones");
            Console.WriteLine("   dotnet ef migrations add InitialCreate");
            Console.WriteLine("   dotnet ef database update\n");

            Console.WriteLine("4️⃣ Realizar Operaciones CRUD");
            Console.WriteLine("   • Create: context.Users.Add(user);");
            Console.WriteLine("   • Read: context.Users.Find(id);");
            Console.WriteLine("   • Update: user.Name = \"Updated\";");
            Console.WriteLine("   • Delete: context.Users.Remove(user);\n");
        }

        /// <summary>
        /// Demuestra características avanzadas
        /// </summary>
        public static void DemonstrateAdvancedFeatures()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🚀 Características Avanzadas de EF Core");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Consultas LINQ");
            Console.WriteLine("   • Consultar bases de datos usando expresiones C#");
            Console.WriteLine("   • Type-safe en tiempo de compilación");
            Console.WriteLine("   • IntelliSense completo\n");

            Console.WriteLine("✅ Filtros de Consulta Globales");
            Console.WriteLine("   • Aplicar condiciones a todas las consultas");
            Console.WriteLine("   • Soft delete automático");
            Console.WriteLine("   • Multi-tenancy simplificado\n");

            Console.WriteLine("✅ Soporte de Transacciones");
            Console.WriteLine("   • Consistencia de datos garantizada");
            Console.WriteLine("   • Operaciones atómicas");
            Console.WriteLine("   • Rollback automático en caso de error\n");

            Console.WriteLine("✅ Data Seeding");
            Console.WriteLine("   • Insertar registros por defecto automáticamente");
            Console.WriteLine("   • Datos iniciales automáticos");
            Console.WriteLine("   • Datos de prueba consistentes\n");

            Console.WriteLine("✅ Consultas Compiladas");
            Console.WriteLine("   • Consultas precompiladas");
            Console.WriteLine("   • Mejor rendimiento en consultas repetitivas");
            Console.WriteLine("   • Reducción de overhead de compilación\n");
        }

        /// <summary>
        /// Demuestra operaciones CRUD
        /// </summary>
        public static void DemonstrateCrudOperations()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Operaciones CRUD con EF Core");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Create (Crear)");
            Console.WriteLine("```csharp");
            Console.WriteLine("var user = new User");
            Console.WriteLine("{");
            Console.WriteLine("    Name = \"Alice\",");
            Console.WriteLine("    Email = \"alice@example.com\",");
            Console.WriteLine("    CreatedAt = DateTime.UtcNow");
            Console.WriteLine("};");
            Console.WriteLine("context.Users.Add(user);");
            Console.WriteLine("await context.SaveChangesAsync();");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Read (Leer)");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Por ID");
            Console.WriteLine("var user = await context.Users.FindAsync(1);");
            Console.WriteLine("");
            Console.WriteLine("// Con filtros");
            Console.WriteLine("var users = await context.Users");
            Console.WriteLine("    .Where(u => u.IsActive)");
            Console.WriteLine("    .OrderBy(u => u.Name)");
            Console.WriteLine("    .ToListAsync();");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Update (Actualizar)");
            Console.WriteLine("```csharp");
            Console.WriteLine("var user = await context.Users.FindAsync(1);");
            Console.WriteLine("user.Name = \"Updated Name\";");
            Console.WriteLine("await context.SaveChangesAsync();");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Delete (Eliminar)");
            Console.WriteLine("```csharp");
            Console.WriteLine("var user = await context.Users.FindAsync(1);");
            Console.WriteLine("context.Users.Remove(user);");
            Console.WriteLine("await context.SaveChangesAsync();");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra consultas LINQ avanzadas
        /// </summary>
        public static void DemonstrateLinqQueries()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Consultas LINQ Avanzadas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Consultas con múltiples condiciones");
            Console.WriteLine("```csharp");
            Console.WriteLine("var users = await context.Users");
            Console.WriteLine("    .Where(u => u.IsActive)");
            Console.WriteLine("    .Where(u => u.CreatedAt > DateTime.UtcNow.AddMonths(-6))");
            Console.WriteLine("    .Select(u => new UserDto");
            Console.WriteLine("    {");
            Console.WriteLine("        Id = u.Id,");
            Console.WriteLine("        Name = u.Name,");
            Console.WriteLine("        OrderCount = u.Orders.Count");
            Console.WriteLine("    })");
            Console.WriteLine("    .OrderByDescending(u => u.OrderCount)");
            Console.WriteLine("    .Take(10)");
            Console.WriteLine("    .ToListAsync();");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Consultas con relaciones (Eager Loading)");
            Console.WriteLine("```csharp");
            Console.WriteLine("var users = await context.Users");
            Console.WriteLine("    .Include(u => u.Orders)");
            Console.WriteLine("    .ThenInclude(o => o.Items)");
            Console.WriteLine("    .ToListAsync();");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra consideraciones importantes
        /// </summary>
        public static void DemonstrateImportantConsiderations()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Consideraciones Importantes");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Rendimiento - Evitar N+1 Query Problem");
            Console.WriteLine("   ❌ MAL:");
            Console.WriteLine("   var users = await context.Users.ToListAsync();");
            Console.WriteLine("   foreach (var user in users)");
            Console.WriteLine("       var orders = user.Orders.ToList();  // Query adicional");
            Console.WriteLine("");
            Console.WriteLine("   ✅ BIEN:");
            Console.WriteLine("   var users = await context.Users");
            Console.WriteLine("       .Include(u => u.Orders)");
            Console.WriteLine("       .ToListAsync();\n");

            Console.WriteLine("2. AsNoTracking para Lecturas");
            Console.WriteLine("   ✅ BIEN: AsNoTracking para consultas de solo lectura");
            Console.WriteLine("   var users = await context.Users");
            Console.WriteLine("       .AsNoTracking()");
            Console.WriteLine("       .Where(u => u.IsActive)");
            Console.WriteLine("       .ToListAsync();\n");

            Console.WriteLine("3. Paginación");
            Console.WriteLine("   ✅ BIEN: Paginación eficiente");
            Console.WriteLine("   var users = await context.Users");
            Console.WriteLine("       .OrderBy(u => u.Name)");
            Console.WriteLine("       .Skip((page - 1) * pageSize)");
            Console.WriteLine("       .Take(pageSize)");
            Console.WriteLine("       .ToListAsync();\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          Entity Framework Core (EF Core)                     ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateWhatIsEfCore();
            Console.WriteLine("\n");
            DemonstrateWhyUseEfCore();
            Console.WriteLine("\n");
            DemonstrateHowEfCoreWorks();
            Console.WriteLine("\n");
            DemonstrateAdvancedFeatures();
            Console.WriteLine("\n");
            DemonstrateCrudOperations();
            Console.WriteLine("\n");
            DemonstrateLinqQueries();
            Console.WriteLine("\n");
            DemonstrateImportantConsiderations();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Ventajas de EF Core:");
            Console.WriteLine("   • No SQL Crudo: Consultas type-safe con LINQ");
            Console.WriteLine("   • Independiente de BD: Soporta múltiples proveedores");
            Console.WriteLine("   • Migraciones Automáticas: Versionado de esquema");
            Console.WriteLine("   • Alta Productividad: Menos código boilerplate");
            Console.WriteLine("   • Seguimiento Automático: Detección de cambios integrada");
            Console.WriteLine("   • Carga Flexible: Eager, Lazy y Explicit loading");
            Console.WriteLine("   • Consultas Optimizadas: Compiled queries");
            Console.WriteLine("   • Integración ASP.NET Core: Funciona perfectamente\n");
            
            Console.WriteLine("🚀 Cuándo Usar EF Core:");
            Console.WriteLine("   • Aplicaciones .NET Core/.NET 5+");
            Console.WriteLine("   • Desarrollo rápido de aplicaciones");
            Console.WriteLine("   • Necesitas trabajar con múltiples bases de datos");
            Console.WriteLine("   • Prefieres LINQ sobre SQL crudo");
            Console.WriteLine("   • Necesitas migraciones automáticas\n");
            
            Console.WriteLine("⚠️ Cuándo NO Usar EF Core:");
            Console.WriteLine("   • Rendimiento extremadamente crítico (considerar Dapper)");
            Console.WriteLine("   • Consultas SQL muy complejas y específicas");
            Console.WriteLine("   • Aplicaciones legacy que requieren control total sobre SQL\n");
        }
    }
}

