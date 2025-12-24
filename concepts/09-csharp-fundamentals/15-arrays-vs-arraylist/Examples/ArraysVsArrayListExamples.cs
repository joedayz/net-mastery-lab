using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NetMasteryLab.Concepts.CSharpFundamentals.ArraysVsArrayList.Examples
{
    /// <summary>
    /// Ejemplos que demuestran las diferencias entre Arrays y ArrayList
    /// </summary>
    public class ArraysVsArrayListExamples
    {
        /// <summary>
        /// Demuestra Arrays: El Rey de la Velocidad
        /// </summary>
        public static void DemonstrateArrays()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔹 Arrays: El Rey de la Velocidad y Eficiencia ⚡");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Array de enteros:");
            Console.WriteLine("```csharp");
            Console.WriteLine("int[] numbers = new int[5];  // Tamaño fijo: 5 elementos");
            Console.WriteLine("numbers[0] = 10;");
            Console.WriteLine("numbers[1] = 20;");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Array inicializado:");
            Console.WriteLine("```csharp");
            Console.WriteLine("int[] numbers = { 10, 20, 30, 40, 50 };");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  • Acceso ultra rápido por índice (O(1))");
            Console.WriteLine("  • Eficiencia de memoria (tamaño predefinido)");
            Console.WriteLine("  • Sin overhead de gestión dinámica\n");

            Console.WriteLine("Cuándo Usar:");
            Console.WriteLine("  • Tamaño conocido de antemano");
            Console.WriteLine("  • Rendimiento crítico");
            Console.WriteLine("  • Operaciones matemáticas intensivas");
            Console.WriteLine("  • Buffers de tamaño fijo\n");
        }

        /// <summary>
        /// Demuestra List<T>: El Campeón de la Flexibilidad
        /// </summary>
        public static void DemonstrateList()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔹 List<T>: El Campeón de la Flexibilidad 🔄");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ List<T> (recomendado - type-safe):");
            Console.WriteLine("```csharp");
            Console.WriteLine("List<int> numbers = new List<int>();");
            Console.WriteLine("numbers.Add(10);  // Tamaño: 1");
            Console.WriteLine("numbers.Add(20);  // Tamaño: 2");
            Console.WriteLine("numbers.Add(30);  // Tamaño: 3");
            Console.WriteLine("// Se redimensiona automáticamente");
            Console.WriteLine("```\n");

            Console.WriteLine("⚠️ ArrayList (legacy, no recomendado):");
            Console.WriteLine("```csharp");
            Console.WriteLine("ArrayList list = new ArrayList();");
            Console.WriteLine("list.Add(10);");
            Console.WriteLine("list.Add(\"Hello\");  // Puede almacenar cualquier tipo");
            Console.WriteLine("int value = (int)list[0];  // Requiere casting");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  • Tamaño dinámico (se adapta automáticamente)");
            Console.WriteLine("  • Gestión fácil de elementos (agregar/remover)");
            Console.WriteLine("  • Type-safe con generics (List<T>)\n");

            Console.WriteLine("Cuándo Usar:");
            Console.WriteLine("  • Tamaño desconocido de antemano");
            Console.WriteLine("  • Modificaciones frecuentes");
            Console.WriteLine("  • Necesitas operaciones de colección\n");
        }

        /// <summary>
        /// Demuestra diferencias clave
        /// </summary>
        public static void DemonstrateKeyDifferences()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚡ Diferencias Clave que Importan");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("🔹 Tamaño:");
            Console.WriteLine("  • Array: Fijo - new int[5] siempre tiene 5 elementos");
            Console.WriteLine("  • List<T>: Dinámico - se redimensiona automáticamente\n");

            Console.WriteLine("🔹 Rendimiento:");
            Console.WriteLine("  • Array: Más rápido para acceso por índice");
            Console.WriteLine("  • List<T>: Más flexible pero ligeramente más lento\n");

            Console.WriteLine("🔹 Type Safety:");
            Console.WriteLine("  • Array: Strictly typed en tiempo de compilación");
            Console.WriteLine("  • ArrayList: No type-safe (legacy)");
            Console.WriteLine("  • List<T>: Type-safe con generics\n");

            Console.WriteLine("Comparación de Rendimiento:");
            Console.WriteLine("  | Operación      | Array | List<T> |");
            Console.WriteLine("  |----------------|-------|---------|");
            Console.WriteLine("  | Acceso índice  | O(1)  | O(1)    |");
            Console.WriteLine("  | Agregar        | ❌    | O(1)    |");
            Console.WriteLine("  | Remover        | ❌    | O(n)    |");
            Console.WriteLine("  | Memoria        | Menor | Mayor   |\n");
        }

        /// <summary>
        /// Demuestra cuándo usar cada uno
        /// </summary>
        public static void DemonstrateWhenToUse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Eligiendo el Correcto");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("🔹 ¿Necesitas Velocidad Cruda y Eficiencia de Memoria?");
            Console.WriteLine("   → Usa Arrays\n");
            Console.WriteLine("   Ejemplo:");
            Console.WriteLine("   ```csharp");
            Console.WriteLine("   int[] buffer = new int[1024];  // Buffer de tamaño fijo");
            Console.WriteLine("   for (int i = 0; i < buffer.Length; i++)");
            Console.WriteLine("   {");
            Console.WriteLine("       buffer[i] = ProcessData(i);  // Acceso ultra rápido");
            Console.WriteLine("   }");
            Console.WriteLine("   ```\n");

            Console.WriteLine("🔹 ¿Necesitas Flexibilidad y Gestión Fácil?");
            Console.WriteLine("   → Usa List<T>\n");
            Console.WriteLine("   Ejemplo:");
            Console.WriteLine("   ```csharp");
            Console.WriteLine("   List<User> users = new List<User>();");
            Console.WriteLine("   users.Add(new User { Name = \"Alice\" });");
            Console.WriteLine("   users.RemoveAll(u => u.IsInactive);");
            Console.WriteLine("   ```\n");
        }

        /// <summary>
        /// Demuestra errores comunes
        /// </summary>
        public static void DemonstrateCommonMistakes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Errores Comunes");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ Error 1: Usar Array cuando Necesitas Tamaño Dinámico");
            Console.WriteLine("```csharp");
            Console.WriteLine("int[] numbers = new int[100];  // ¿Qué pasa si necesitas más?");
            Console.WriteLine("// numbers[100] = 10;  // IndexOutOfRangeException");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Solución: Usar List<T>");
            Console.WriteLine("```csharp");
            Console.WriteLine("List<int> numbers = new List<int>();");
            Console.WriteLine("numbers.Add(10);  // Se adapta automáticamente");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ Error 2: Usar List<T> cuando el Tamaño es Conocido");
            Console.WriteLine("```csharp");
            Console.WriteLine("List<int> scores = new List<int>();  // Overhead innecesario");
            Console.WriteLine("for (int i = 0; i < 10; i++)");
            Console.WriteLine("    scores.Add(GetScore(i));");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Solución: Usar Array");
            Console.WriteLine("```csharp");
            Console.WriteLine("int[] scores = new int[10];");
            Console.WriteLine("for (int i = 0; i < scores.Length; i++)");
            Console.WriteLine("    scores[i] = GetScore(i);");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ Error 3: Usar ArrayList en lugar de List<T>");
            Console.WriteLine("```csharp");
            Console.WriteLine("ArrayList list = new ArrayList();  // Legacy, no type-safe");
            Console.WriteLine("list.Add(10);");
            Console.WriteLine("list.Add(\"Hello\");  // Permite cualquier tipo");
            Console.WriteLine("int value = (int)list[0];  // Requiere casting");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Solución: Usar List<T>");
            Console.WriteLine("```csharp");
            Console.WriteLine("List<int> list = new List<int>();  // Type-safe");
            Console.WriteLine("list.Add(10);");
            Console.WriteLine("// list.Add(\"Hello\");  // Error de compilación");
            Console.WriteLine("int value = list[0];  // Sin casting");
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

            Console.WriteLine("Ejemplo 1: Array para Rendimiento Crítico");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Buffer de tamaño fijo para procesamiento");
            Console.WriteLine("byte[] buffer = new byte[1024 * 1024];  // 1MB buffer fijo");
            Console.WriteLine("int bytesRead = stream.Read(buffer, 0, buffer.Length);");
            Console.WriteLine("ProcessBuffer(buffer, bytesRead);  // Acceso ultra rápido");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 2: List<T> para Datos Dinámicos");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Gestión dinámica de usuarios");
            Console.WriteLine("List<User> users = new List<User>();");
            Console.WriteLine("users.Add(new User { Name = \"Alice\" });");
            Console.WriteLine("users.RemoveAll(u => !u.IsActive);");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 3: Conversión Entre Array y List<T>");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Array → List<T>");
            Console.WriteLine("int[] array = { 1, 2, 3 };");
            Console.WriteLine("List<int> list = array.ToList();");
            Console.WriteLine("");
            Console.WriteLine("// List<T> → Array");
            Console.WriteLine("List<int> list = new List<int> { 1, 2, 3 };");
            Console.WriteLine("int[] array = list.ToArray();");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              Arrays vs ArrayList en C#                       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateArrays();
            Console.WriteLine("\n");
            DemonstrateList();
            Console.WriteLine("\n");
            DemonstrateKeyDifferences();
            Console.WriteLine("\n");
            DemonstrateWhenToUse();
            Console.WriteLine("\n");
            DemonstrateCommonMistakes();
            Console.WriteLine("\n");
            DemonstratePracticalExamples();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Arrays: El Rey de la Velocidad ⚡");
            Console.WriteLine("   • Tamaño fijo - Eficiente en memoria");
            Console.WriteLine("   • Acceso ultra rápido - O(1) por índice");
            Console.WriteLine("   • Ideal para: Rendimiento crítico, tamaño conocido\n");
            
            Console.WriteLine("✅ List<T>: El Campeón de la Flexibilidad 🔄");
            Console.WriteLine("   • Tamaño dinámico - Se adapta automáticamente");
            Console.WriteLine("   • Gestión fácil - Agregar/remover elementos");
            Console.WriteLine("   • Type-safe - Type-safety en tiempo de compilación\n");
            
            Console.WriteLine("⚠️ Nota Importante:");
            Console.WriteLine("   • ArrayList es legacy - NO usar en código nuevo");
            Console.WriteLine("   • Usar List<T> en su lugar para type-safety\n");
            
            Console.WriteLine("💡 Regla de Oro:");
            Console.WriteLine("   • Array → Tamaño conocido, rendimiento crítico");
            Console.WriteLine("   • List<T> → Tamaño desconocido, modificaciones frecuentes\n");
        }
    }
}

