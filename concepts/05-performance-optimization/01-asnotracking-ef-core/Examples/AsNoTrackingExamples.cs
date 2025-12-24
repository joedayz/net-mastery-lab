using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace NetMasteryLab.Concepts.PerformanceOptimization.AsNoTrackingEFCore.Examples;

/// <summary>
/// Ejemplos que demuestran el uso de AsNoTracking() en Entity Framework Core
/// </summary>
public class AsNoTrackingExamples
{
    /// <summary>
    /// Demuestra el problema de no usar AsNoTracking()
    /// </summary>
    public static void DemonstrateWithoutAsNoTracking()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ❌ SIN AsNoTracking(): Entity Framework rastrea entidades");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código problemático:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var users = context.Users");
        Console.WriteLine("    .Where(u => u.IsActive)");
        Console.WriteLine("    .ToList(); // Las entidades SON rastreadas");
        Console.WriteLine("```\n");

        Console.WriteLine("Problemas:");
        Console.WriteLine("  • Overhead de rendimiento - el cambio tracker consume recursos");
        Console.WriteLine("  • Mayor uso de memoria - las entidades rastreadas ocupan más espacio");
        Console.WriteLine("  • Innecesario para lectura - no necesitas tracking si solo lees");
        Console.WriteLine("  • Impacto en grandes consultas - el overhead se multiplica\n");

        // Simulación (sin base de datos real)
        Console.WriteLine("Simulación de consulta sin AsNoTracking():");
        Console.WriteLine("  • Entity Framework crea snapshots de las entidades");
        Console.WriteLine("  • Mantiene referencias en el cambio tracker");
        Console.WriteLine("  • Consume memoria adicional para cada entidad\n");
    }

    /// <summary>
    /// Demuestra la solución usando AsNoTracking()
    /// </summary>
    public static void DemonstrateWithAsNoTracking()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ✅ CON AsNoTracking(): Entity Framework NO rastrea entidades");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código optimizado:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var users = context.Users");
        Console.WriteLine("    .AsNoTracking()");
        Console.WriteLine("    .Where(u => u.IsActive)");
        Console.WriteLine("    .ToList(); // Las entidades NO son rastreadas");
        Console.WriteLine("```\n");

        Console.WriteLine("Ventajas:");
        Console.WriteLine("  ✅ Mejor rendimiento - elimina overhead del cambio tracker");
        Console.WriteLine("  ✅ Menor uso de memoria - entidades no rastreadas ocupan menos");
        Console.WriteLine("  ✅ Ideal para lectura - perfecto para operaciones de solo lectura");
        Console.WriteLine("  ✅ Fácil de implementar - solo agrega .AsNoTracking()\n");

        // Simulación
        Console.WriteLine("Simulación de consulta con AsNoTracking():");
        Console.WriteLine("  • Entity Framework NO crea snapshots");
        Console.WriteLine("  • NO mantiene referencias en el cambio tracker");
        Console.WriteLine("  • Usa menos memoria por entidad\n");
    }

    /// <summary>
    /// Demuestra el uso con proyecciones Select()
    /// </summary>
    public static void DemonstrateWithSelect()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🚀 Máximo Rendimiento: AsNoTracking() + Select()");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código optimizado:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var orderDetails = context.Orders");
        Console.WriteLine("    .AsNoTracking()");
        Console.WriteLine("    .Where(o => o.Status == \"Completed\")");
        Console.WriteLine("    .Select(o => new");
        Console.WriteLine("    {");
        Console.WriteLine("        o.OrderId,");
        Console.WriteLine("        o.OrderDate,");
        Console.WriteLine("        CustomerName = o.Customer.Name,");
        Console.WriteLine("        TotalAmount = o.OrderItems.Sum(oi => oi.Price * oi.Quantity)");
        Console.WriteLine("    })");
        Console.WriteLine("    .ToList();");
        Console.WriteLine("```\n");

        Console.WriteLine("Beneficios combinados:");
        Console.WriteLine("  ✅ AsNoTracking() - elimina tracking overhead");
        Console.WriteLine("  ✅ Select() - proyecta solo campos necesarios");
        Console.WriteLine("  ✅ Reduce datos transferidos desde la base de datos");
        Console.WriteLine("  ✅ Máximo rendimiento para consultas de solo lectura\n");
    }

    /// <summary>
    /// Demuestra casos de uso ideales
    /// </summary>
    public static void DemonstrateUseCases()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  📊 Casos de Uso Ideales para AsNoTracking()");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("1. Generación de Reportes:");
        Console.WriteLine("```csharp");
        Console.WriteLine("public IEnumerable<SalesReport> GetSalesReport(DateTime start, DateTime end)");
        Console.WriteLine("{");
        Console.WriteLine("    return _context.Orders");
        Console.WriteLine("        .AsNoTracking()");
        Console.WriteLine("        .Where(o => o.OrderDate >= start && o.OrderDate <= end)");
        Console.WriteLine("        .Select(o => new SalesReport { ... })");
        Console.WriteLine("        .ToList();");
        Console.WriteLine("}");
        Console.WriteLine("```\n");

        Console.WriteLine("2. Visualizaciones de Datos:");
        Console.WriteLine("```csharp");
        Console.WriteLine("public IEnumerable<UserDto> GetActiveUsers()");
        Console.WriteLine("{");
        Console.WriteLine("    return _context.Users");
        Console.WriteLine("        .AsNoTracking()");
        Console.WriteLine("        .Where(u => u.IsActive)");
        Console.WriteLine("        .Select(u => new UserDto { Name = u.Name })");
        Console.WriteLine("        .ToList();");
        Console.WriteLine("}");
        Console.WriteLine("```\n");

        Console.WriteLine("3. APIs de Solo Lectura:");
        Console.WriteLine("```csharp");
        Console.WriteLine("[HttpGet]");
        Console.WriteLine("public IActionResult GetProducts()");
        Console.WriteLine("{");
        Console.WriteLine("    var products = _context.Products");
        Console.WriteLine("        .AsNoTracking()");
        Console.WriteLine("        .ToList();");
        Console.WriteLine("    return Ok(products);");
        Console.WriteLine("}");
        Console.WriteLine("```\n");
    }

    /// <summary>
    /// Demuestra cuándo NO usar AsNoTracking()
    /// </summary>
    public static void DemonstrateWhenNotToUse()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ⚠️  Cuándo NO Usar AsNoTracking()");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("❌ NO uses AsNoTracking() cuando:");
        Console.WriteLine("\n1. Necesitas modificar y guardar entidades:");
        Console.WriteLine("```csharp");
        Console.WriteLine("// ❌ MAL: Los cambios no serán detectados");
        Console.WriteLine("var user = context.Users");
        Console.WriteLine("    .AsNoTracking()");
        Console.WriteLine("    .FirstOrDefault(u => u.Id == 1);");
        Console.WriteLine("user.Name = \"New Name\"; // NO será detectado");
        Console.WriteLine("context.SaveChanges(); // NO guardará el cambio");
        Console.WriteLine("```\n");

        Console.WriteLine("✅ BIEN: Sin AsNoTracking() para modificaciones");
        Console.WriteLine("```csharp");
        Console.WriteLine("var user = context.Users");
        Console.WriteLine("    .FirstOrDefault(u => u.Id == 1);");
        Console.WriteLine("user.Name = \"New Name\"; // Será detectado");
        Console.WriteLine("context.SaveChanges(); // Guardará el cambio");
        Console.WriteLine("```\n");

        Console.WriteLine("2. Necesitas que EF Core detecte cambios automáticamente");
        Console.WriteLine("3. Trabajas con relaciones que necesitan ser cargadas después\n");
    }

    /// <summary>
    /// Demuestra configuración global
    /// </summary>
    public static void DemonstrateGlobalConfiguration()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ⚙️  Configuración Global de AsNoTracking()");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Puedes configurar AsNoTracking() como comportamiento por defecto:");
        Console.WriteLine("```csharp");
        Console.WriteLine("public class ApplicationDbContext : DbContext");
        Console.WriteLine("{");
        Console.WriteLine("    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
        Console.WriteLine("    {");
        Console.WriteLine("        optionsBuilder.UseQueryTrackingBehavior(");
        Console.WriteLine("            QueryTrackingBehavior.NoTracking);");
        Console.WriteLine("    }");
        Console.WriteLine("}");
        Console.WriteLine("```\n");

        Console.WriteLine("Luego, usa .AsTracking() cuando necesites tracking:");
        Console.WriteLine("```csharp");
        Console.WriteLine("// Para operaciones de solo lectura (por defecto)");
        Console.WriteLine("var users = context.Users.ToList();");
        Console.WriteLine("");
        Console.WriteLine("// Para operaciones que necesitan tracking");
        Console.WriteLine("var user = context.Users");
        Console.WriteLine("    .AsTracking()");
        Console.WriteLine("    .FirstOrDefault(u => u.Id == 1);");
        Console.WriteLine("```\n");
    }

    /// <summary>
    /// Ejecuta todos los ejemplos
    /// </summary>
    public static void RunAllExamples()
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     Use AsNoTracking() in EF Core for Read-Only Queries       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

        DemonstrateWithoutAsNoTracking();
        Console.WriteLine("\n");
        DemonstrateWithAsNoTracking();
        Console.WriteLine("\n");
        DemonstrateWithSelect();
        Console.WriteLine("\n");
        DemonstrateUseCases();
        Console.WriteLine("\n");
        DemonstrateWhenNotToUse();
        Console.WriteLine("\n");
        DemonstrateGlobalConfiguration();

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  RESUMEN");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        Console.WriteLine("✅ Beneficios de AsNoTracking():");
        Console.WriteLine("   ◾ Performance Boost - mejora el rendimiento");
        Console.WriteLine("   ◾ Reduced Memory Usage - menor uso de memoria");
        Console.WriteLine("   ◾ Ideal for Reporting - perfecto para reportes");
        Console.WriteLine("   ◾ Simple to Implement - fácil de implementar\n");
        
        Console.WriteLine("💡 Regla General:");
        Console.WriteLine("   • Usa AsNoTracking() para consultas de solo lectura");
        Console.WriteLine("   • Combina con Select() para máximo rendimiento");
        Console.WriteLine("   • NO uses cuando necesites modificar entidades\n");
    }
}

