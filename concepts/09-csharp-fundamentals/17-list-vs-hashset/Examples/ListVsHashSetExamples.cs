using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMasteryLab.Concepts.CSharpFundamentals.ListVsHashSet.Examples
{
    /// <summary>
    /// Ejemplos que demuestran las diferencias entre List<T> y HashSet<T>
    /// </summary>
    public class ListVsHashSetExamples
    {
        /// <summary>
        /// Demuestra List<T> - Permite duplicados y mantiene orden
        /// </summary>
        public static void DemonstrateList()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ List<T> – Piensa en Orden y Duplicados Permitidos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ List permite duplicados y mantiene orden:");
            Console.WriteLine("```csharp");
            Console.WriteLine("var list = new List<string> { \"a\", \"b\", \"a\" };  // Permite duplicados");
            Console.WriteLine("Console.WriteLine(string.Join(\", \", list));  // Output: \"a, b, a\"");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            var list = new List<string> { "a", "b", "a" };
            Console.WriteLine($"Resultado: List = \"{string.Join(", ", list)}\"\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  ✅ Mantiene orden: Los elementos se mantienen en el orden de inserción");
            Console.WriteLine("  ✅ Permite duplicados: Puedes tener el mismo elemento múltiples veces");
            Console.WriteLine("  ✅ Acceso por índice: O(1) para acceso por índice");
            Console.WriteLine("  ✅ Búsqueda: O(n) para buscar elementos\n");

            Console.WriteLine("Casos de Uso Ideales:");
            Console.WriteLine("  • Necesitas mantener el orden de los elementos");
            Console.WriteLine("  • Los duplicados son aceptables o requeridos");
            Console.WriteLine("  • Necesitas acceso por índice");
            Console.WriteLine("  • Almacenar secuencias de pasos, logs, o inputs del usuario\n");
        }

        /// <summary>
        /// Demuestra HashSet<T> - Elimina duplicados automáticamente
        /// </summary>
        public static void DemonstrateHashSet()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🚫 HashSet<T> – Piensa en Unicidad y Rendimiento");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ HashSet elimina duplicados automáticamente:");
            Console.WriteLine("```csharp");
            Console.WriteLine("var set = new HashSet<string> { \"a\", \"b\", \"a\" };  // Elimina duplicados");
            Console.WriteLine("Console.WriteLine(string.Join(\", \", set));  // Output: \"a, b\"");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            var set = new HashSet<string> { "a", "b", "a" };
            Console.WriteLine($"Resultado: Set = \"{string.Join(", ", set)}\"\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  ✅ Solo elementos únicos: Elimina duplicados automáticamente");
            Console.WriteLine("  ✅ Sin orden garantizado: Los elementos no mantienen orden");
            Console.WriteLine("  ✅ Búsqueda rápida: O(1) promedio para buscar elementos");
            Console.WriteLine("  ✅ Inserción rápida: O(1) promedio para agregar elementos\n");

            Console.WriteLine("Casos de Uso Ideales:");
            Console.WriteLine("  • Necesitas prevenir duplicados");
            Console.WriteLine("  • No te importa el orden");
            Console.WriteLine("  • Quieres búsquedas rápidas (O(1))");
            Console.WriteLine("  • Listas de IDs únicos, emails, tags, o categorías\n");
        }

        /// <summary>
        /// Demuestra comparación visual
        /// </summary>
        public static void DemonstrateVisualComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Comparación Visual");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("List<T> - Permite Duplicados:");
            var list = new List<string> { "a", "b", "a" };
            Console.WriteLine($"  List: {string.Join(", ", list)}");
            Console.WriteLine("  Output: \"a, b, a\"\n");

            Console.WriteLine("HashSet<T> - Elimina Duplicados:");
            var set = new HashSet<string> { "a", "b", "a" };
            Console.WriteLine($"  Set: {string.Join(", ", set)}");
            Console.WriteLine("  Output: \"a, b\"\n");
        }

        /// <summary>
        /// Demuestra diferencias clave
        /// </summary>
        public static void DemonstrateKeyDifferences()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔍 Diferencias Clave");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("| Característica      | List<T> | HashSet<T> |");
            Console.WriteLine("|---------------------|---------|------------|");
            Console.WriteLine("| Duplicados          | ✅ Permite | ❌ Elimina |");
            Console.WriteLine("| Orden               | ✅ Mantiene | ❌ Sin orden |");
            Console.WriteLine("| Acceso por Índice   | ✅ O(1) | ❌ No |");
            Console.WriteLine("| Búsqueda (Contains) | ❌ O(n) | ✅ O(1) |");
            Console.WriteLine("| Inserción           | ✅ O(1) | ✅ O(1) |");
            Console.WriteLine("| Eliminación         | ❌ O(n) | ✅ O(1) |");
            Console.WriteLine("| Operaciones Conjunto| ❌ No | ✅ Sí |\n");
        }

        /// <summary>
        /// Demuestra ejemplos prácticos
        /// </summary>
        public static void DemonstratePracticalExamples()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Ejemplos Prácticos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo 1: List para Secuencia Ordenada");
            var processSteps = new List<string>
            {
                "Initialize",
                "Process Data",
                "Validate",
                "Save Results"
            };
            processSteps.Add("Initialize");  // Duplicado permitido
            Console.WriteLine($"  Pasos: {string.Join(" -> ", processSteps)}\n");

            Console.WriteLine("Ejemplo 2: HashSet para Elementos Únicos");
            var userIds = new HashSet<int> { 1, 2, 3, 1, 2 };  // Duplicados eliminados
            Console.WriteLine($"  Unique User IDs: {string.Join(", ", userIds)}");
            Console.WriteLine($"  Contains(2): {userIds.Contains(2)}  // O(1) - muy rápido\n");

            Console.WriteLine("Ejemplo 3: Operaciones de Conjunto con HashSet");
            var set1 = new HashSet<int> { 1, 2, 3, 4 };
            var set2 = new HashSet<int> { 3, 4, 5, 6 };
            
            var union = new HashSet<int>(set1);
            union.UnionWith(set2);
            Console.WriteLine($"  Union: {string.Join(", ", union)}");
            
            var intersection = new HashSet<int>(set1);
            intersection.IntersectWith(set2);
            Console.WriteLine($"  Intersection: {string.Join(", ", intersection)}");
            
            var difference = new HashSet<int>(set1);
            difference.ExceptWith(set2);
            Console.WriteLine($"  Difference: {string.Join(", ", difference)}\n");
        }

        /// <summary>
        /// Demuestra optimización de rendimiento
        /// </summary>
        public static void DemonstratePerformanceOptimization()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🚀 Bonus Tip: Optimización de Rendimiento");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ MAL: Verificar duplicados en List (O(n))");
            Console.WriteLine("```csharp");
            Console.WriteLine("var list = new List<int>();");
            Console.WriteLine("if (!list.Contains(i))  // O(n) - cada verificación es costosa");
            Console.WriteLine("    list.Add(i);");
            Console.WriteLine("// Complejidad total: O(n²) - muy lento");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: HashSet elimina duplicados automáticamente (O(1))");
            Console.WriteLine("```csharp");
            Console.WriteLine("var set = new HashSet<int>();");
            Console.WriteLine("set.Add(i);  // O(1) - verificación y adición rápidas");
            Console.WriteLine("// Complejidad total: O(n) - mucho más rápido");
            Console.WriteLine("```\n");

            Console.WriteLine("💡 En aplicaciones críticas para el rendimiento:");
            Console.WriteLine("  • List.Contains(): O(n) - lento para listas grandes");
            Console.WriteLine("  • HashSet.Contains(): O(1) - rápido incluso para grandes colecciones");
            Console.WriteLine("  • Cambiar a HashSet puede mejorar significativamente el rendimiento\n");
        }

        /// <summary>
        /// Demuestra errores comunes
        /// </summary>
        public static void DemonstrateCommonMistakes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Errores Comunes");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ Error 1: Usar List cuando Necesitas Unicidad");
            Console.WriteLine("```csharp");
            Console.WriteLine("var emails = new List<string>();");
            Console.WriteLine("if (!emails.Contains(email))  // O(n) - lento");
            Console.WriteLine("    emails.Add(email);");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Solución: HashSet para elementos únicos");
            Console.WriteLine("```csharp");
            Console.WriteLine("var emails = new HashSet<string>();");
            Console.WriteLine("emails.Add(email);  // O(1) - rápido y automáticamente único");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ Error 2: Usar HashSet cuando Necesitas Orden");
            Console.WriteLine("```csharp");
            Console.WriteLine("var orderedSteps = new HashSet<string> { \"Step 1\", \"Step 2\" };");
            Console.WriteLine("// El orden no está garantizado");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Solución: List cuando necesitas orden");
            Console.WriteLine("```csharp");
            Console.WriteLine("var orderedSteps = new List<string> { \"Step 1\", \"Step 2\" };");
            Console.WriteLine("// Mantiene el orden de inserción");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ Error 3: Usar List para Búsquedas Frecuentes");
            Console.WriteLine("```csharp");
            Console.WriteLine("var users = new List<User>();");
            Console.WriteLine("var user = users.FirstOrDefault(u => u.Id == userId);  // O(n) - lento");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Solución: HashSet o Dictionary para búsquedas frecuentes");
            Console.WriteLine("```csharp");
            Console.WriteLine("var users = new HashSet<User>(new UserIdComparer());");
            Console.WriteLine("var user = users.FirstOrDefault(u => u.Id == userId);  // O(1) - rápido");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              List vs HashSet en .NET                          ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateList();
            Console.WriteLine("\n");
            DemonstrateHashSet();
            Console.WriteLine("\n");
            DemonstrateVisualComparison();
            Console.WriteLine("\n");
            DemonstrateKeyDifferences();
            Console.WriteLine("\n");
            DemonstratePracticalExamples();
            Console.WriteLine("\n");
            DemonstratePerformanceOptimization();
            Console.WriteLine("\n");
            DemonstrateCommonMistakes();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ List<T> - Orden y Duplicados:");
            Console.WriteLine("   • Mantiene orden de inserción");
            Console.WriteLine("   • Permite duplicados");
            Console.WriteLine("   • Acceso por índice O(1)");
            Console.WriteLine("   • Búsqueda O(n)");
            Console.WriteLine("   • Ideal para secuencias ordenadas, logs, entradas del usuario\n");
            
            Console.WriteLine("✅ HashSet<T> - Unicidad y Rendimiento:");
            Console.WriteLine("   • Solo elementos únicos");
            Console.WriteLine("   • Sin orden garantizado");
            Console.WriteLine("   • Búsqueda O(1) promedio");
            Console.WriteLine("   • Inserción O(1) promedio");
            Console.WriteLine("   • Ideal para elementos únicos, búsquedas rápidas\n");
            
            Console.WriteLine("🧠 Key Takeaway:");
            Console.WriteLine("   • List<T>: Elementos ordenados, duplicados aceptables, indexado importante");
            Console.WriteLine("   • HashSet<T>: Búsquedas rápidas, sin duplicados, unicidad esencial\n");
        }
    }
}

