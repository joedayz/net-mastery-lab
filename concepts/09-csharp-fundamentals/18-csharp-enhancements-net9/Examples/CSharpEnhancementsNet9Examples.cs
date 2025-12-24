using System;

namespace NetMasteryLab.Concepts.CSharpFundamentals.CSharpEnhancementsNet9.Examples
{
    /// <summary>
    /// Ejemplos que demuestran las mejoras de C# en .NET 9.0
    /// </summary>
    public class CSharpEnhancementsNet9Examples
    {
        // ✅ BIEN: Primary Constructor - código limpio y expresivo
        public class Person(string name, int age)
        {
            public string Name { get; } = name;
            public int Age { get; } = age;
        }

        // ✅ BIEN: Auto-Default Struct
        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        /// <summary>
        /// Demuestra Primary Constructors
        /// </summary>
        public static void DemonstratePrimaryConstructors()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔧 Primary Constructors");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Primary Constructor - código limpio y expresivo");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Person(string name, int age)");
            Console.WriteLine("{");
            Console.WriteLine("    public string Name { get; } = name;");
            Console.WriteLine("    public int Age { get; } = age;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            var person = new Person("Alice", 30);
            Console.WriteLine($"Ejemplo: person = new Person(\"Alice\", 30)");
            Console.WriteLine($"  person.Name = \"{person.Name}\"");
            Console.WriteLine($"  person.Age = {person.Age}\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  ✅ Reduce Código: Elimina hasta un 50% de boilerplate");
            Console.WriteLine("  ✅ Más Legible: Código más limpio y expresivo");
            Console.WriteLine("  ✅ Perfecto para DI: Ideal para Dependency Injection");
            Console.WriteLine("  ✅ Ideal para Records: Combina perfectamente con records\n");
        }

        /// <summary>
        /// Demuestra Auto-Default Structs
        /// </summary>
        public static void DemonstrateAutoDefaultStructs()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🧱 Auto-Default Structs");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Auto-Default Structs en .NET 9.0");
            Console.WriteLine("```csharp");
            Console.WriteLine("public struct Point");
            Console.WriteLine("{");
            Console.WriteLine("    public int X { get; set; }");
            Console.WriteLine("    public int Y { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("var point = new Point();");
            Console.WriteLine("// X e Y están automáticamente inicializados a 0");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            var point = new Point();
            Console.WriteLine($"Ejemplo: var point = new Point();");
            Console.WriteLine($"  point.X = {point.X} (valor por defecto)");
            Console.WriteLine($"  point.Y = {point.Y} (valor por defecto)\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  ✅ Sin Inicialización Manual: Los miembros se inicializan automáticamente");
            Console.WriteLine("  ✅ Menos Bugs: Evita errores relacionados con campos no inicializados");
            Console.WriteLine("  ✅ Código Más Limpio: No necesitas inicializar manualmente cada campo");
            Console.WriteLine("  ✅ Comportamiento Predecible: Valores por defecto garantizados\n");
        }

        /// <summary>
        /// Demuestra Enhanced Pattern Matching
        /// </summary>
        public static void DemonstrateEnhancedPatternMatching()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🧠 Enhanced Pattern Matching");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Enhanced Pattern Matching - código elegante y legible");
            Console.WriteLine("```csharp");
            Console.WriteLine("var result = person switch");
            Console.WriteLine("{");
            Console.WriteLine("    { Age: >= 18, Name: not null } => $\"{person.Name} is an adult\",");
            Console.WriteLine("    { Age: < 18, Name: not null } => $\"{person.Name} is a minor\",");
            Console.WriteLine("    { Name: null } => \"Unknown person\",");
            Console.WriteLine("    _ => \"Invalid\"");
            Console.WriteLine("};");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  ✅ Código Más Elegante: Lógica condicional más limpia");
            Console.WriteLine("  ✅ Más Legible: Reduce cadenas if-else anidadas");
            Console.WriteLine("  ✅ Más Expresivo: Patrones más poderosos y flexibles");
            Console.WriteLine("  ✅ Type-Safe: Verificación de tipos en tiempo de compilación\n");
        }

        /// <summary>
        /// Demuestra comparación antes vs después
        /// </summary>
        public static void DemonstrateBeforeAfter()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Comparación: Antes vs Después");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Primary Constructors:");
            Console.WriteLine("  ❌ ANTES: ~10 líneas con constructor tradicional");
            Console.WriteLine("  ✅ DESPUÉS: ~3 líneas con Primary Constructor\n");

            Console.WriteLine("Auto-Default Structs:");
            Console.WriteLine("  ❌ ANTES: Inicialización manual o comportamiento indefinido");
            Console.WriteLine("  ✅ DESPUÉS: Inicialización automática garantizada\n");

            Console.WriteLine("Enhanced Pattern Matching:");
            Console.WriteLine("  ❌ ANTES: If-else anidados complejos");
            Console.WriteLine("  ✅ DESPUÉS: Expresiones elegantes y legibles\n");
        }

        /// <summary>
        /// Demuestra ejemplos prácticos
        /// </summary>
        public static void DemonstratePracticalExamples()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Ejemplos Prácticos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo 1: Primary Constructor para Service Class");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class OrderService(IOrderRepository repository, ILogger logger)");
            Console.WriteLine("{");
            Console.WriteLine("    public async Task<Order> GetOrderAsync(int id)");
            Console.WriteLine("    {");
            Console.WriteLine("        logger.LogInformation(\"Getting order {OrderId}\", id);");
            Console.WriteLine("        return await repository.GetByIdAsync(id);");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 2: Auto-Default Struct");
            Console.WriteLine("```csharp");
            Console.WriteLine("public struct Coordinate");
            Console.WriteLine("{");
            Console.WriteLine("    public int X { get; set; }");
            Console.WriteLine("    public int Y { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("var coord = new Coordinate();");
            Console.WriteLine("// X, Y automáticamente inicializados a 0");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 3: Enhanced Pattern Matching");
            Console.WriteLine("```csharp");
            Console.WriteLine("var message = order switch");
            Console.WriteLine("{");
            Console.WriteLine("    { Status: OrderStatus.Pending, Total: > 1000 } => \"High-value pending\",");
            Console.WriteLine("    { Status: OrderStatus.Shipped } => \"Order shipped\",");
            Console.WriteLine("    _ => \"Standard order\"");
            Console.WriteLine("};");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra cuándo usar cada característica
        /// </summary>
        public static void DemonstrateWhenToUse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Cuándo Usar Cada Característica");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Usa Primary Constructors cuando:");
            Console.WriteLine("  ✅ Tienes clases con pocos parámetros");
            Console.WriteLine("  ✅ Necesitas Dependency Injection");
            Console.WriteLine("  ✅ Trabajas con records o clases de datos");
            Console.WriteLine("  ✅ Quieres reducir boilerplate\n");

            Console.WriteLine("Usa Auto-Default Structs cuando:");
            Console.WriteLine("  ✅ Trabajas con structs simples");
            Console.WriteLine("  ✅ Quieres evitar bugs de inicialización");
            Console.WriteLine("  ✅ Necesitas comportamiento predecible");
            Console.WriteLine("  ✅ Quieres código más limpio\n");

            Console.WriteLine("Usa Enhanced Pattern Matching cuando:");
            Console.WriteLine("  ✅ Tienes lógica condicional compleja");
            Console.WriteLine("  ✅ Quieres reducir if-else anidados");
            Console.WriteLine("  ✅ Necesitas código más expresivo");
            Console.WriteLine("  ✅ Quieres mejor legibilidad\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║    C# Enhancements: Writing Cleaner Code in .NET 9.0         ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstratePrimaryConstructors();
            Console.WriteLine("\n");
            DemonstrateAutoDefaultStructs();
            Console.WriteLine("\n");
            DemonstrateEnhancedPatternMatching();
            Console.WriteLine("\n");
            DemonstrateBeforeAfter();
            Console.WriteLine("\n");
            DemonstratePracticalExamples();
            Console.WriteLine("\n");
            DemonstrateWhenToUse();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Mejoras de C# en .NET 9.0:");
            Console.WriteLine("   1. Primary Constructors");
            Console.WriteLine("      • Simplifica inicialización de clases y records");
            Console.WriteLine("      • Reduce código hasta en un 50%");
            Console.WriteLine("      • Perfecto para aplicaciones centradas en datos\n");
            
            Console.WriteLine("   2. Auto-Default Structs");
            Console.WriteLine("      • Inicialización automática de miembros");
            Console.WriteLine("      • Evita bugs de campos no inicializados");
            Console.WriteLine("      • Comportamiento predecible\n");
            
            Console.WriteLine("   3. Enhanced Pattern Matching");
            Console.WriteLine("      • Capacidades más poderosas y flexibles");
            Console.WriteLine("      • Lógica condicional elegante y legible");
            Console.WriteLine("      • Reduce cadenas if-else anidadas\n");
            
            Console.WriteLine("🚀 Beneficios Generales:");
            Console.WriteLine("   • ⚡ Rendimiento: Código más eficiente");
            Console.WriteLine("   • 🧩 Flexibilidad: Más opciones para expresar lógica");
            Console.WriteLine("   • 💡 Simplicidad: Menos código, menos errores");
            Console.WriteLine("   • ✨ Expresividad: Código más limpio y elegante\n");
        }
    }
}

