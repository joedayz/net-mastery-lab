using System;
using System.Text;

namespace NetMasteryLab.Concepts.PerformanceOptimization.StringVsStringBuilder.Examples
{
    /// <summary>
    /// Ejemplos que demuestran String vs StringBuilder: Asignación de Memoria
    /// </summary>
    public class StringVsStringBuilderExamples
    {
        /// <summary>
        /// Demuestra asignación de memoria para String
        /// </summary>
        public static void DemonstrateStringMemoryAllocation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🛑 Asignación de Memoria para String");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Características Clave:");
            Console.WriteLine("  🔹 Inmutable – Cualquier modificación crea un nuevo objeto");
            Console.WriteLine("  🔹 Asignación en Heap – Cada cambio resulta en nueva asignación");
            Console.WriteLine("  🔹 Impacto en Rendimiento – Modificaciones frecuentes causan problemas\n");

            Console.WriteLine("Ejemplo de Múltiples Concatenaciones:");
            string sampleString = "Welcome";
            Console.WriteLine($"  Iteración 1: \"{sampleString}\" (objeto 1 creado)");
            
            sampleString += " everyone";
            Console.WriteLine($"  Iteración 2: \"{sampleString}\" (objeto 2 creado, objeto 1 → basura)");
            
            sampleString += ",";
            Console.WriteLine($"  Iteración 3: \"{sampleString}\" (objeto 3 creado, objetos 1-2 → basura)");
            
            sampleString += " how are you?";
            Console.WriteLine($"  Iteración 4: \"{sampleString}\" (objeto 4 creado, objetos 1-3 → basura)\n");

            Console.WriteLine("Problema:");
            Console.WriteLine("  • Se crean 4 objetos String en memoria");
            Console.WriteLine("  • Los primeros 3 quedan como basura hasta que el GC los recolecte");
            Console.WriteLine("  • Complejidad: O(n²) debido a copias repetidas\n");
        }

        /// <summary>
        /// Demuestra asignación de memoria para StringBuilder
        /// </summary>
        public static void DemonstrateStringBuilderMemoryAllocation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🚀 Asignación de Memoria para StringBuilder");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Características Clave:");
            Console.WriteLine("  🔹 Mutable – Modificaciones en la misma asignación");
            Console.WriteLine("  🔹 Eficiente – Reduce sobrecarga de memoria");
            Console.WriteLine("  🔹 Ideal para Actualizaciones Frecuentes – Optimizado para concatenación\n");

            Console.WriteLine("Ejemplo de Múltiples Concatenaciones:");
            StringBuilder sampleString = new StringBuilder();
            
            sampleString.Append("Welcome");
            Console.WriteLine($"  Iteración 1: Append(\"Welcome\") - Buffer: \"{sampleString}\"");
            
            sampleString.Append(" everyone");
            Console.WriteLine($"  Iteración 2: Append(\" everyone\") - Buffer: \"{sampleString}\"");
            
            sampleString.Append(",");
            Console.WriteLine($"  Iteración 3: Append(\",\") - Buffer: \"{sampleString}\"");
            
            sampleString.Append(" how are you?");
            Console.WriteLine($"  Iteración 4: Append(\" how are you?\") - Buffer: \"{sampleString}\"\n");

            Console.WriteLine("Ventaja:");
            Console.WriteLine("  • Se crea 1 objeto StringBuilder (mismo objeto en todas las iteraciones)");
            Console.WriteLine("  • El buffer interno crece eficientemente");
            Console.WriteLine("  • Complejidad: O(n) - mucho más rápido\n");
        }

        /// <summary>
        /// Demuestra comparación de rendimiento
        /// </summary>
        public static void DemonstratePerformanceComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚡ Comparación de Rendimiento");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            const int iterations = 100;

            // String - O(n²)
            Console.WriteLine("❌ String (Inmutable) - Complejidad O(n²):");
            var startTime = DateTime.Now;
            string stringResult = "";
            for (int i = 0; i < iterations; i++)
            {
                stringResult += $"Item {i} ";
            }
            var stringTime = DateTime.Now - startTime;
            Console.WriteLine($"  Tiempo: {stringTime.TotalMilliseconds:F2} ms");
            Console.WriteLine($"  Objetos creados: ~{iterations} objetos String");
            Console.WriteLine($"  Memoria: Alta (muchos objetos temporales)\n");

            // StringBuilder - O(n)
            Console.WriteLine("✅ StringBuilder (Mutable) - Complejidad O(n):");
            startTime = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                sb.Append($"Item {i} ");
            }
            string sbResult = sb.ToString();
            var sbTime = DateTime.Now - startTime;
            Console.WriteLine($"  Tiempo: {sbTime.TotalMilliseconds:F2} ms");
            Console.WriteLine($"  Objetos creados: 1 objeto StringBuilder + 1 String final");
            Console.WriteLine($"  Memoria: Baja (buffer eficiente)\n");

            Console.WriteLine($"Mejora de Rendimiento: ~{stringTime.TotalMilliseconds / sbTime.TotalMilliseconds:F1}x más rápido con StringBuilder\n");
        }

        /// <summary>
        /// Demuestra cuándo usar cada uno
        /// </summary>
        public static void DemonstrateWhenToUse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ Key Takeaways");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✔ Usa String para:");
            Console.WriteLine("  • Modificaciones pequeñas e infrecuentes");
            Console.WriteLine("  • Strings literales y constantes");
            Console.WriteLine("  • Interpolación de strings (C# 6+)");
            Console.WriteLine("  • 1-2 concatenaciones simples\n");

            Console.WriteLine("Ejemplo - String es apropiado:");
            Console.WriteLine("  string message = \"Hello\";");
            Console.WriteLine("  message += \" World\"; // Solo 2 objetos, String es suficiente\n");

            Console.WriteLine("✔ Usa StringBuilder para:");
            Console.WriteLine("  • Modificaciones frecuentes");
            Console.WriteLine("  • Construcción dinámica de texto");
            Console.WriteLine("  • Operaciones de alto rendimiento");
            Console.WriteLine("  • 3+ concatenaciones en loops\n");

            Console.WriteLine("Ejemplo - StringBuilder es necesario:");
            Console.WriteLine("  StringBuilder sb = new StringBuilder();");
            Console.WriteLine("  for (int i = 0; i < 1000; i++)");
            Console.WriteLine("  {");
            Console.WriteLine("      sb.Append($\"Item {i} \");");
            Console.WriteLine("  }\n");
        }

        /// <summary>
        /// Demuestra errores comunes
        /// </summary>
        public static void DemonstrateCommonErrors()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Errores Comunes");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ Error 1: Usar String para múltiples concatenaciones");
            Console.WriteLine("  string result = \"\";");
            Console.WriteLine("  for (int i = 0; i < 1000; i++)");
            Console.WriteLine("  {");
            Console.WriteLine("      result += $\"Item {i}\"; // Muy ineficiente");
            Console.WriteLine("  }");
            Console.WriteLine();
            Console.WriteLine("  ✅ Solución:");
            Console.WriteLine("  StringBuilder sb = new StringBuilder();");
            Console.WriteLine("  for (int i = 0; i < 1000; i++)");
            Console.WriteLine("  {");
            Console.WriteLine("      sb.Append($\"Item {i}\");");
            Console.WriteLine("  }\n");

            Console.WriteLine("❌ Error 2: Usar StringBuilder para operaciones simples");
            Console.WriteLine("  StringBuilder sb = new StringBuilder();");
            Console.WriteLine("  sb.Append(\"Hello\");");
            Console.WriteLine("  sb.Append(\" World\");");
            Console.WriteLine("  string result = sb.ToString(); // Overhead innecesario");
            Console.WriteLine();
            Console.WriteLine("  ✅ Solución:");
            Console.WriteLine("  string result = \"Hello\" + \" World\"; // Más simple\n");

            Console.WriteLine("⚠️ Error 3: No especificar capacidad inicial");
            Console.WriteLine("  StringBuilder sb = new StringBuilder(); // Capacidad: 16");
            Console.WriteLine();
            Console.WriteLine("  ✅ Mejor:");
            Console.WriteLine("  StringBuilder sb = new StringBuilder(1000); // Evita reasignaciones\n");
        }

        /// <summary>
        /// Demuestra ejemplos prácticos
        /// </summary>
        public static void DemonstratePracticalExamples()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Ejemplos Prácticos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo 1: Construcción de Query SQL");
            Console.WriteLine("  ❌ MAL: String");
            Console.WriteLine("    string query = \"SELECT * FROM Users WHERE \";");
            Console.WriteLine("    query += \"IsActive = 1\";");
            Console.WriteLine("    query += \" AND Age > 18\";");
            Console.WriteLine("    // Múltiples objetos creados\n");

            Console.WriteLine("  ✅ BIEN: StringBuilder");
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT * FROM Users WHERE ");
            queryBuilder.Append("IsActive = 1");
            queryBuilder.Append(" AND Age > 18");
            string query = queryBuilder.ToString();
            Console.WriteLine($"    Query resultante: {query}\n");

            Console.WriteLine("Ejemplo 2: Construcción de HTML");
            var items = new[] { "Item 1", "Item 2", "Item 3" };
            
            Console.WriteLine("  ❌ MAL: String en loop");
            Console.WriteLine("    string html = \"<ul>\";");
            Console.WriteLine("    foreach (var item in items)");
            Console.WriteLine("    {");
            Console.WriteLine("        html += $\"<li>{item}</li>\"; // Ineficiente");
            Console.WriteLine("    }\n");

            Console.WriteLine("  ✅ BIEN: StringBuilder en loop");
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<ul>");
            foreach (var item in items)
            {
                htmlBuilder.Append($"<li>{item}</li>");
            }
            htmlBuilder.Append("</ul>");
            string html = htmlBuilder.ToString();
            Console.WriteLine($"    HTML resultante: {html}\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║      String vs StringBuilder: Asignación de Memoria          ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateStringMemoryAllocation();
            Console.WriteLine("\n");
            DemonstrateStringBuilderMemoryAllocation();
            Console.WriteLine("\n");
            DemonstratePerformanceComparison();
            Console.WriteLine("\n");
            DemonstrateWhenToUse();
            Console.WriteLine("\n");
            DemonstrateCommonErrors();
            Console.WriteLine("\n");
            DemonstratePracticalExamples();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ String (Inmutable):");
            Console.WriteLine("   • Cada modificación crea nuevo objeto");
            Console.WriteLine("   • Múltiples objetos en memoria");
            Console.WriteLine("   • Complejidad: O(n²)");
            Console.WriteLine("   • Usar para: pocas modificaciones\n");
            
            Console.WriteLine("✅ StringBuilder (Mutable):");
            Console.WriteLine("   • Modifica el mismo objeto");
            Console.WriteLine("   • Un objeto que crece eficientemente");
            Console.WriteLine("   • Complejidad: O(n)");
            Console.WriteLine("   • Usar para: muchas modificaciones\n");
            
            Console.WriteLine("🎯 Regla General:");
            Console.WriteLine("   • String: 1-2 concatenaciones");
            Console.WriteLine("   • StringBuilder: 3+ concatenaciones o loops\n");
        }
    }
}

