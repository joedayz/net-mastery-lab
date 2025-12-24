using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace NetMasteryLab.Concepts.CSharpFundamentals.Collections.Examples
{
    /// <summary>
    /// Ejemplos que demuestran las diferentes colecciones en C#
    /// </summary>
    public class CollectionsExamples
    {
        /// <summary>
        /// Demuestra System.Collections.Generic
        /// </summary>
        public static void DemonstrateGenericCollections()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🟦 1. System.Collections.Generic");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("🔑 Dictionary<TKey, TValue>:");
            Console.WriteLine("  Almacena pares clave-valor para búsquedas rápidas\n");

            var users = new Dictionary<int, string>
            {
                { 1, "Alice" },
                { 2, "Bob" },
                { 3, "Charlie" }
            };
            Console.WriteLine($"Ejemplo Dictionary: {users.Count} usuarios");
            if (users.TryGetValue(1, out var userName))
            {
                Console.WriteLine($"  Usuario ID 1: {userName}");
            }

            Console.WriteLine("\n📋 List<T>:");
            Console.WriteLine("  Array dinámico para manejo flexible de datos\n");

            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            numbers.Add(6);
            Console.WriteLine($"Ejemplo List: {numbers.Count} elementos");
            Console.WriteLine($"  Primer elemento: {numbers[0]}");

            Console.WriteLine("\n🚀 .NET 9: AddRange ahora soporta Span<T>");
            Console.WriteLine("```csharp");
            Console.WriteLine("Span<int> span = stackalloc int[] { 1, 2, 3 };");
            Console.WriteLine("List<int> list = new();");
            Console.WriteLine("list.AddRange(span);  // Directamente desde Span<T>");
            Console.WriteLine("```");
            Console.WriteLine("Beneficios:");
            Console.WriteLine("  ✅ Código más limpio - Sin conversiones innecesarias");
            Console.WriteLine("  ✅ Menos asignaciones - Mejor uso de memoria");
            Console.WriteLine("  ✅ Mejor rendimiento - Especialmente en operaciones con muchos datos");
            Console.WriteLine("  ✅ Type-safe - Mantiene la seguridad de tipos");

            Console.WriteLine("\n🎯 Queue<T>:");
            Console.WriteLine("  Estructura FIFO (First In, First Out)\n");

            var queue = new Queue<string>();
            queue.Enqueue("Task 1");
            queue.Enqueue("Task 2");
            Console.WriteLine($"Ejemplo Queue: {queue.Count} elementos");
            if (queue.Count > 0)
            {
                Console.WriteLine($"  Próximo elemento: {queue.Peek()}");
            }

            Console.WriteLine("\n📚 SortedList<TKey, TValue>:");
            Console.WriteLine("  Colección clave-valor ordenada\n");

            var sortedList = new SortedList<string, int>
            {
                { "Alice", 95 },
                { "Bob", 87 },
                { "Charlie", 92 }
            };
            Console.WriteLine($"Ejemplo SortedList: {sortedList.Count} elementos");
            Console.WriteLine($"  Primera clave (ordenada): {sortedList.Keys[0]}");

            Console.WriteLine("\n📦 Stack<T>:");
            Console.WriteLine("  Estructura LIFO (Last In, First Out)\n");

            var stack = new Stack<string>();
            stack.Push("Action 1");
            stack.Push("Action 2");
            Console.WriteLine($"Ejemplo Stack: {stack.Count} elementos");
            if (stack.Count > 0)
            {
                Console.WriteLine($"  Elemento en tope: {stack.Peek()}");
            }
        }

        /// <summary>
        /// Demuestra System.Collections.Concurrent
        /// </summary>
        public static void DemonstrateConcurrentCollections()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🟩 2. System.Collections.Concurrent");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("🚀 ConcurrentDictionary<Key, Value>:");
            Console.WriteLine("  Diccionario thread-safe para programación paralela\n");

            var concurrentDict = new ConcurrentDictionary<int, string>();
            concurrentDict.TryAdd(1, "Value 1");
            concurrentDict.TryAdd(2, "Value 2");
            Console.WriteLine($"Ejemplo ConcurrentDictionary: {concurrentDict.Count} elementos");
            Console.WriteLine("  Thread-safe sin locks explícitos");

            Console.WriteLine("\n🔄 ConcurrentQueue<T> & ConcurrentStack<T>:");
            Console.WriteLine("  FIFO y LIFO optimizados para concurrencia\n");

            var concurrentQueue = new ConcurrentQueue<string>();
            concurrentQueue.Enqueue("Item 1");
            concurrentQueue.Enqueue("Item 2");
            Console.WriteLine($"Ejemplo ConcurrentQueue: {concurrentQueue.Count} elementos");

            var concurrentStack = new ConcurrentStack<string>();
            concurrentStack.Push("Item 1");
            concurrentStack.Push("Item 2");
            Console.WriteLine($"Ejemplo ConcurrentStack: {concurrentStack.Count} elementos");

            Console.WriteLine("\n⛓️ BlockingCollection<T>:");
            Console.WriteLine("  Ideal para escenarios producer-consumer\n");

            var blockingCollection = new BlockingCollection<string>();
            blockingCollection.Add("Item 1");
            blockingCollection.Add("Item 2");
            Console.WriteLine($"Ejemplo BlockingCollection: {blockingCollection.Count} elementos");
            Console.WriteLine("  Bloquea cuando está vacío (espera elementos)");
        }

        /// <summary>
        /// Demuestra System.Collections (Legacy)
        /// </summary>
        public static void DemonstrateLegacyCollections()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🟨 3. System.Collections (Legacy)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("⚠️ NOTA: Estas colecciones son legacy y no se recomiendan");
            Console.WriteLine("para código nuevo. Usa las versiones genéricas.\n");

            Console.WriteLine("📂 ArrayList:");
            Console.WriteLine("  Colección de objetos no genérica\n");
            Console.WriteLine("  ❌ No type-safe");
            Console.WriteLine("  ✅ MEJOR: Usar List<T> en código moderno\n");

            Console.WriteLine("🔑 Hashtable:");
            Console.WriteLine("  Almacenamiento clave-valor legacy\n");
            Console.WriteLine("  ❌ No type-safe");
            Console.WriteLine("  ✅ MEJOR: Usar Dictionary<TKey, TValue> en código moderno\n");

            Console.WriteLine("📤 Queue & Stack:");
            Console.WriteLine("  Estructuras FIFO y LIFO legacy\n");
            Console.WriteLine("  ❌ No type-safe");
            Console.WriteLine("  ✅ MEJOR: Usar Queue<T> y Stack<T> en código moderno\n");
        }

        /// <summary>
        /// Demuestra cuándo usar cada colección
        /// </summary>
        public static void DemonstrateWhenToUse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Cuándo Usar Cada Colección");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Dictionary<TKey, TValue>:");
            Console.WriteLine("  ✅ Búsquedas rápidas por clave");
            Console.WriteLine("  ✅ Mapeos y asociaciones");
            Console.WriteLine("  ✅ Caché y lookups\n");

            Console.WriteLine("List<T>:");
            Console.WriteLine("  ✅ Listas dinámicas");
            Console.WriteLine("  ✅ Acceso por índice");
            Console.WriteLine("  ✅ Operaciones secuenciales\n");

            Console.WriteLine("Queue<T>:");
            Console.WriteLine("  ✅ Procesamiento FIFO");
            Console.WriteLine("  ✅ Colas de tareas");
            Console.WriteLine("  ✅ BFS algorithms\n");

            Console.WriteLine("Stack<T>:");
            Console.WriteLine("  ✅ Procesamiento LIFO");
            Console.WriteLine("  ✅ Undo/redo");
            Console.WriteLine("  ✅ DFS algorithms\n");

            Console.WriteLine("ConcurrentDictionary:");
            Console.WriteLine("  ✅ Caché compartido entre threads");
            Console.WriteLine("  ✅ Contadores thread-safe");
            Console.WriteLine("  ✅ Programación paralela\n");

            Console.WriteLine("BlockingCollection:");
            Console.WriteLine("  ✅ Producer-consumer patterns");
            Console.WriteLine("  ✅ Procesamiento asíncrono");
            Console.WriteLine("  ✅ Colas de trabajo entre threads\n");
        }

        /// <summary>
        /// Demuestra por qué importan las colecciones
        /// </summary>
        public static void DemonstrateWhyItMatters()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Why Should You Care?");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("🚦 Collections Simplifican la Gestión de Datos:");
            Console.WriteLine("  • Organización de Datos: Estructuran datos eficientemente");
            Console.WriteLine("  • Operaciones Comunes: Operaciones pre-optimizadas");
            Console.WriteLine("  • Type Safety: Las genéricas proporcionan seguridad de tipos");
            Console.WriteLine("  • Performance: Optimizadas para diferentes casos de uso\n");

            Console.WriteLine("🔐 Concurrent Collections Habilitan Programación Thread-Safe:");
            Console.WriteLine("  • Thread Safety: Operaciones seguras sin locks explícitos");
            Console.WriteLine("  • Performance: Optimizadas para alta concurrencia");
            Console.WriteLine("  • Producer-Consumer: Patrones comunes de multi-threading");
            Console.WriteLine("  • Escalabilidad: Permiten aplicaciones escalables\n");

            Console.WriteLine("🎨 Perfectas para Escenarios Diversos:");
            Console.WriteLine("  • Algoritmos: BFS (Queue), DFS (Stack), Hash Tables");
            Console.WriteLine("  • Aplicaciones Web: Caché, Colas de procesamiento");
            Console.WriteLine("  • Multi-threading: Producer-Consumer, Caché compartido");
            Console.WriteLine("  • Data Processing: Listas dinámicas, Ordenamiento\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    Collections in C#                         ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateGenericCollections();
            Console.WriteLine("\n");
            DemonstrateConcurrentCollections();
            Console.WriteLine("\n");
            DemonstrateLegacyCollections();
            Console.WriteLine("\n");
            DemonstrateCollectionInterfaces();
            Console.WriteLine("\n");
            DemonstrateWhenToUse();
            Console.WriteLine("\n");
            DemonstrateWhyItMatters();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Categorías de Colecciones:");
            Console.WriteLine("   1. System.Collections.Generic: Type-safe, más utilizadas");
            Console.WriteLine("      • Dictionary, List, Queue, Stack, SortedList");
            Console.WriteLine("   2. System.Collections.Concurrent: Thread-safe");
            Console.WriteLine("      • ConcurrentDictionary, ConcurrentQueue, ConcurrentStack");
            Console.WriteLine("      • BlockingCollection, ConcurrentBag");
            Console.WriteLine("   3. System.Collections: Legacy (no genéricas)");
            Console.WriteLine("      • ArrayList, Hashtable, Queue, Stack\n");
            
            Console.WriteLine("💡 Por Qué Importan:");
            Console.WriteLine("   • Simplifican gestión de datos");
            Console.WriteLine("   • Habilitan programación thread-safe");
            Console.WriteLine("   • Perfectas para escenarios diversos\n");
            
            Console.WriteLine("🎯 Recomendación:");
            Console.WriteLine("   • Usa colecciones genéricas para código nuevo");
            Console.WriteLine("   • Usa concurrent collections para multi-threading");
            Console.WriteLine("   • Evita colecciones legacy (System.Collections)\n");
        }

        /// <summary>
        /// Demuestra las interfaces de colecciones: IEnumerable, ICollection, IList
        /// </summary>
        public static void DemonstrateCollectionInterfaces()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔍 Interfaces de Colecciones: IEnumerable, ICollection, IList");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("📊 Jerarquía de Interfaces:");
            Console.WriteLine("  IEnumerable<T> (Base - Solo iteración)");
            Console.WriteLine("      ↓");
            Console.WriteLine("  ICollection<T> (Agrega modificación)");
            Console.WriteLine("      ↓");
            Console.WriteLine("  IList<T> (Agrega acceso por índice)\n");

            // IEnumerable<T> - Solo iteración
            Console.WriteLine("🔍 IEnumerable<T> - La Base de la Iteración:");
            IEnumerable<int> enumerable = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine($"  Tipo: {enumerable.GetType().Name}");
            Console.WriteLine("  ✅ Permite iteración");
            Console.WriteLine("  ❌ No permite modificación");
            Console.WriteLine("  ❌ No tiene Count");
            Console.WriteLine("  ❌ No tiene acceso por índice\n");
            foreach (var item in enumerable)
            {
                Console.Write($"    {item} ");
            }
            Console.WriteLine("\n");

            // ICollection<T> - Agrega modificación
            Console.WriteLine("📂 ICollection<T> - Agregando Capacidades de Modificación:");
            ICollection<string> collection = new List<string> { "A", "B", "C" };
            Console.WriteLine($"  Tipo: {collection.GetType().Name}");
            Console.WriteLine($"  Count: {collection.Count}");
            Console.WriteLine("  ✅ Permite iteración (heredado)");
            Console.WriteLine("  ✅ Permite agregar/remover");
            Console.WriteLine("  ✅ Tiene Count");
            Console.WriteLine("  ❌ No tiene acceso por índice\n");
            collection.Add("D");
            collection.Remove("A");
            Console.WriteLine($"  Después de Add('D') y Remove('A'): Count = {collection.Count}\n");

            // IList<T> - Acceso completo con índice
            Console.WriteLine("📋 IList<T> - Control Completo con Indexación:");
            IList<string> list = new List<string> { "A", "B", "C" };
            Console.WriteLine($"  Tipo: {list.GetType().Name}");
            Console.WriteLine($"  Count: {list.Count}");
            Console.WriteLine($"  Primer elemento [0]: {list[0]}");
            Console.WriteLine("  ✅ Permite iteración (heredado)");
            Console.WriteLine("  ✅ Permite agregar/remover (heredado)");
            Console.WriteLine("  ✅ Tiene Count (heredado)");
            Console.WriteLine("  ✅ Tiene acceso por índice");
            Console.WriteLine("  ✅ Permite Insert/RemoveAt\n");
            list[1] = "X";
            list.Insert(2, "New");
            Console.WriteLine($"  Después de list[1] = 'X' e Insert(2, 'New'):");
            foreach (var item in list)
            {
                Console.Write($"    {item} ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Resumen de Diferencias");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("| Característica      | IEnumerable<T> | ICollection<T> | IList<T> |");
            Console.WriteLine("|---------------------|-----------------|----------------|----------|");
            Console.WriteLine("| Iteración           | ✅ Sí           | ✅ Sí          | ✅ Sí    |");
            Console.WriteLine("| Agregar/Remover     | ❌ No           | ✅ Sí          | ✅ Sí    |");
            Console.WriteLine("| Count               | ❌ No           | ✅ Sí          | ✅ Sí    |");
            Console.WriteLine("| Acceso por índice   | ❌ No           | ❌ No           | ✅ Sí    |");
            Console.WriteLine("| Insert/RemoveAt     | ❌ No           | ❌ No           | ✅ Sí    |\n");

            Console.WriteLine("🎯 Cuándo Usar:");
            Console.WriteLine("  • IEnumerable<T>: Solo lectura e iteración");
            Console.WriteLine("  • ICollection<T>: Modificación sin índice");
            Console.WriteLine("  • IList<T>: Modificación con acceso por índice\n");
        }
    }
}

