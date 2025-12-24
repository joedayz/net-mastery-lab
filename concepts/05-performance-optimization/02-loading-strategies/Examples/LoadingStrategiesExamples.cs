namespace NetMasteryLab.Concepts.PerformanceOptimization.LoadingStrategies.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Eager, Lazy y Explicit Loading en Entity Framework Core
    /// </summary>
    public class LoadingStrategiesExamples
    {
        /// <summary>
        /// Demuestra Eager Loading
        /// </summary>
        public static void DemonstrateEagerLoading()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📦 Eager Loading");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Definición:");
            Console.WriteLine("  Eager Loading recupera datos relacionados inmediatamente junto con la consulta principal.\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  • Cuándo se carga: Cuando se obtiene la entidad principal");
            Console.WriteLine("  • Mejor para: Cuando los datos relacionados se requieren inmediatamente");
            Console.WriteLine("  • Pros: Reduce hits a la BD y mejora rendimiento");
            Console.WriteLine("  • Cons: Puede recuperar datos innecesarios\n");

            Console.WriteLine("Ejemplo con Include():");
            Console.WriteLine("```csharp");
            Console.WriteLine("var orders = await _context.Orders");
            Console.WriteLine("    .Include(o => o.Customer)");
            Console.WriteLine("    .Include(o => o.OrderItems)");
            Console.WriteLine("        .ThenInclude(oi => oi.Product)");
            Console.WriteLine("    .ToListAsync();");
            Console.WriteLine("```\n");

            Console.WriteLine("Resultado:");
            Console.WriteLine("  ✅ Una sola consulta SQL con JOINs");
            Console.WriteLine("  ✅ Todos los datos disponibles inmediatamente");
            Console.WriteLine("  ✅ Evita problema N+1\n");
        }

        /// <summary>
        /// Demuestra Lazy Loading
        /// </summary>
        public static void DemonstrateLazyLoading()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💤 Lazy Loading");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Definición:");
            Console.WriteLine("  Lazy Loading obtiene datos relacionados solo cuando se accede por primera vez.\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  • Cuándo se carga: Cuando se accede a la propiedad de navegación");
            Console.WriteLine("  • Mejor para: Cuando los datos relacionados son opcionales");
            Console.WriteLine("  • Pros: Eficiente cuando los datos raramente se necesitan");
            Console.WriteLine("  • Cons: Puede causar problema N+1\n");

            Console.WriteLine("Ejemplo:");
            Console.WriteLine("```csharp");
            Console.WriteLine("var orders = await _context.Orders.ToListAsync(); // 1 consulta");
            Console.WriteLine("");
            Console.WriteLine("foreach (var order in orders)");
            Console.WriteLine("{");
            Console.WriteLine("    var customer = order.Customer; // Consulta adicional por orden");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("⚠️ Problema N+1:");
            Console.WriteLine("  • 1 consulta inicial para Orders");
            Console.WriteLine("  • N consultas adicionales (una por cada orden)");
            Console.WriteLine("  • Total: 1 + N consultas\n");
        }

        /// <summary>
        /// Demuestra Explicit Loading
        /// </summary>
        public static void DemonstrateExplicitLoading()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔑 Explicit Loading");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Definición:");
            Console.WriteLine("  Explicit Loading da control completo sobre cuándo y cómo se recuperan datos relacionados.\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  • Cuándo se carga: Activado manualmente después de obtener la entidad");
            Console.WriteLine("  • Mejor para: Control fino sobre la obtención de datos");
            Console.WriteLine("  • Pros: Control completo sobre consultas y rendimiento");
            Console.WriteLine("  • Cons: Requiere más código y gestión\n");

            Console.WriteLine("Ejemplo con Load():");
            Console.WriteLine("```csharp");
            Console.WriteLine("var order = await _context.Orders");
            Console.WriteLine("    .FirstOrDefaultAsync(o => o.Id == orderId);");
            Console.WriteLine("");
            Console.WriteLine("if (order != null)");
            Console.WriteLine("{");
            Console.WriteLine("    await _context.Entry(order)");
            Console.WriteLine("        .Reference(o => o.Customer)");
            Console.WriteLine("        .LoadAsync();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  ✅ Control granular sobre qué cargar");
            Console.WriteLine("  ✅ Puedes cargar condicionalmente");
            Console.WriteLine("  ✅ Optimización precisa basada en necesidades\n");
        }

        /// <summary>
        /// Demuestra comparación de estrategias
        /// </summary>
        public static void DemonstrateComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Comparación de Estrategias");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("┌──────────────────┬──────────────────────────┬──────────────────┬──────────────────┐");
            Console.WriteLine("│ Estrategia       │ Cuándo se Carga          │ Pros             │ Cons             │");
            Console.WriteLine("├──────────────────┼──────────────────────────┼──────────────────┼──────────────────┤");
            Console.WriteLine("│ Lazy Loading     │ Al acceder propiedad     │ Ahorra recursos  │ Problema N+1     │");
            Console.WriteLine("│ Eager Loading    │ Con entidad principal    │ Eficiente        │ Consultas grandes│");
            Console.WriteLine("│ Explicit Loading │ Manualmente activado     │ Control completo│ Más código      │");
            Console.WriteLine("└──────────────────┴──────────────────────────┴──────────────────┴──────────────────┘\n");
        }

        /// <summary>
        /// Demuestra problema N+1
        /// </summary>
        public static void DemonstrateNPlusOneProblem()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Problema N+1");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ MAL: Lazy Loading causa N+1");
            Console.WriteLine("```csharp");
            Console.WriteLine("var orders = await _context.Orders.ToListAsync(); // 1 consulta");
            Console.WriteLine("");
            Console.WriteLine("foreach (var order in orders)");
            Console.WriteLine("{");
            Console.WriteLine("    var customer = order.Customer; // N consultas adicionales");
            Console.WriteLine("}");
            Console.WriteLine("// Total: 1 + N consultas");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: Eager Loading evita N+1");
            Console.WriteLine("```csharp");
            Console.WriteLine("var orders = await _context.Orders");
            Console.WriteLine("    .Include(o => o.Customer)");
            Console.WriteLine("    .ToListAsync(); // 1 consulta con JOIN");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: Explicit Loading con control");
            Console.WriteLine("```csharp");
            Console.WriteLine("var orders = await _context.Orders.ToListAsync(); // 1 consulta");
            Console.WriteLine("var customerIds = orders.Select(o => o.CustomerId).Distinct();");
            Console.WriteLine("var customers = await _context.Customers");
            Console.WriteLine("    .Where(c => customerIds.Contains(c.Id))");
            Console.WriteLine("    .ToListAsync(); // 1 consulta adicional");
            Console.WriteLine("// Total: 2 consultas (mucho mejor que N+1)");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra cuándo usar cada estrategia
        /// </summary>
        public static void DemonstrateWhenToUse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Cuándo Usar Cada Estrategia");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("📦 Eager Loading es Ideal Para:");
            Console.WriteLine("  ✅ Rendimiento cuando necesitas todos los datos relacionados");
            Console.WriteLine("  ✅ Relaciones conocidas que siempre se usan");
            Console.WriteLine("  ✅ Evitar problemas N+1");
            Console.WriteLine("  ✅ Escenarios donde el overhead inicial es aceptable\n");

            Console.WriteLine("💤 Lazy Loading es Mejor Para:");
            Console.WriteLine("  ✅ Mantener tiempos de carga inicial bajos");
            Console.WriteLine("  ✅ Obtener datos relacionados solo cuando sea necesario");
            Console.WriteLine("  ✅ Datos opcionales que no siempre se necesitan");
            Console.WriteLine("  ⚠️ PERO: Debe manejarse cuidadosamente para evitar N+1\n");

            Console.WriteLine("🔑 Explicit Loading Ofrece:");
            Console.WriteLine("  ✅ El equilibrio óptimo");
            Console.WriteLine("  ✅ Control preciso sobre el rendimiento");
            Console.WriteLine("  ✅ Control completo sobre tus consultas");
            Console.WriteLine("  ✅ Flexibilidad para optimizar según necesidades\n");
        }

        /// <summary>
        /// Demuestra por qué Explicit Loading es preferido
        /// </summary>
        public static void DemonstrateWhyExplicitIsPreferred()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚡ ¿Por Qué Explicit Loading es Preferido?");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Explicit Loading ha emergido como la estrategia más flexible y eficiente:\n");

            Console.WriteLine("1. Control Granular:");
            Console.WriteLine("   • Cargas exactamente lo que necesitas, cuando lo necesitas");
            Console.WriteLine("   • No más, no menos\n");

            Console.WriteLine("2. Optimización Precisa:");
            Console.WriteLine("   • Puedes optimizar basándote en condiciones específicas");
            Console.WriteLine("   • Cargas condicionales según lógica de negocio\n");

            Console.WriteLine("3. Evita Problemas N+1:");
            Console.WriteLine("   • Control explícito evita consultas inesperadas");
            Console.WriteLine("   • Sabes exactamente cuándo se ejecutan las consultas\n");

            Console.WriteLine("4. Flexibilidad:");
            Console.WriteLine("   • Puedes combinar con filtros y condiciones");
            Console.WriteLine("   • Ideal para aplicaciones modernas y sensibles al rendimiento\n");
        }

        /// <summary>
        /// Demuestra ejemplos prácticos
        /// </summary>
        public static void DemonstratePracticalExamples()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Ejemplos Prácticos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo 1: Eager Loading para Dashboard");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Dashboard necesita todos los datos");
            Console.WriteLine("var dashboardData = await _context.Orders");
            Console.WriteLine("    .Include(o => o.Customer)");
            Console.WriteLine("    .Include(o => o.OrderItems)");
            Console.WriteLine("        .ThenInclude(oi => oi.Product)");
            Console.WriteLine("    .Where(o => o.OrderDate >= startDate)");
            Console.WriteLine("    .ToListAsync();");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 2: Explicit Loading Condicional");
            Console.WriteLine("```csharp");
            Console.WriteLine("var order = await _context.Orders");
            Console.WriteLine("    .FirstOrDefaultAsync(o => o.Id == orderId);");
            Console.WriteLine("");
            Console.WriteLine("if (order != null && order.Status == OrderStatus.Pending)");
            Console.WriteLine("{");
            Console.WriteLine("    // Solo cargar si es necesario");
            Console.WriteLine("    await _context.Entry(order)");
            Console.WriteLine("        .Reference(o => o.Customer)");
            Console.WriteLine("        .LoadAsync();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 3: Explicit Loading con Filtros");
            Console.WriteLine("```csharp");
            Console.WriteLine("var order = await _context.Orders");
            Console.WriteLine("    .FirstOrDefaultAsync(o => o.Id == orderId);");
            Console.WriteLine("");
            Console.WriteLine("if (order != null)");
            Console.WriteLine("{");
            Console.WriteLine("    // Cargar solo OrderItems con cantidad > 0");
            Console.WriteLine("    await _context.Entry(order)");
            Console.WriteLine("        .Collection(o => o.OrderItems)");
            Console.WriteLine("        .Query()");
            Console.WriteLine("        .Where(oi => oi.Quantity > 0)");
            Console.WriteLine("        .LoadAsync();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║    Optimizing ORM: Eager, Lazy & Explicit Loading              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateEagerLoading();
            Console.WriteLine("\n");
            DemonstrateLazyLoading();
            Console.WriteLine("\n");
            DemonstrateExplicitLoading();
            Console.WriteLine("\n");
            DemonstrateComparison();
            Console.WriteLine("\n");
            DemonstrateNPlusOneProblem();
            Console.WriteLine("\n");
            DemonstrateWhenToUse();
            Console.WriteLine("\n");
            DemonstrateWhyExplicitIsPreferred();
            Console.WriteLine("\n");
            DemonstratePracticalExamples();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("📦 Eager Loading:");
            Console.WriteLine("   • Carga datos relacionados inmediatamente");
            Console.WriteLine("   • Ideal cuando necesitas todos los datos");
            Console.WriteLine("   • Evita problema N+1\n");
            
            Console.WriteLine("💤 Lazy Loading:");
            Console.WriteLine("   • Carga datos cuando se accede");
            Console.WriteLine("   • Ideal para datos opcionales");
            Console.WriteLine("   • ⚠️ Puede causar problema N+1\n");
            
            Console.WriteLine("🔑 Explicit Loading:");
            Console.WriteLine("   • Control manual sobre cuándo cargar");
            Console.WriteLine("   • Más flexible y eficiente");
            Console.WriteLine("   • Preferido para aplicaciones modernas\n");
            
            Console.WriteLine("💡 Pro Tip:");
            Console.WriteLine("   • Explicit Loading ofrece control y precisión superiores");
            Console.WriteLine("   • Siempre evalúa las compensaciones entre rendimiento y carga");
            Console.WriteLine("   • Evita N+1 usando Eager o Explicit Loading\n");
        }
    }
}

