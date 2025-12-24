using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMasteryLab.Concepts.CSharpFundamentals.LinqMethods.Examples
{
    /// <summary>
    /// Ejemplos que demuestran los métodos LINQ en C#
    /// </summary>
    public class LinqMethodsExamples
    {
        /// <summary>
        /// Demuestra métodos de Filtering (Filtrado)
        /// </summary>
        public static void DemonstrateFiltering()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣ Filtering (Filtrado) 🎯");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Where - Filtra elementos basándose en condición:");
            var evens = numbers.Where(n => n % 2 == 0).ToList();
            Console.WriteLine($"  numbers.Where(n => n % 2 == 0) = [{string.Join(", ", evens)}]\n");

            Console.WriteLine("Take - Toma los primeros N elementos:");
            var firstThree = numbers.Take(3).ToList();
            Console.WriteLine($"  numbers.Take(3) = [{string.Join(", ", firstThree)}]\n");

            Console.WriteLine("Skip - Omite los primeros N elementos:");
            var lastThree = numbers.Skip(7).ToList();
            Console.WriteLine($"  numbers.Skip(7) = [{string.Join(", ", lastThree)}]\n");

            Console.WriteLine("TakeWhile - Toma elementos mientras se cumple condición:");
            var untilFive = numbers.TakeWhile(n => n < 5).ToList();
            Console.WriteLine($"  numbers.TakeWhile(n => n < 5) = [{string.Join(", ", untilFive)}]\n");
        }

        /// <summary>
        /// Demuestra métodos de Projection (Proyección)
        /// </summary>
        public static void DemonstrateProjection()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  2️⃣ Projection (Proyección) 🔄");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine("Select - Proyecta cada elemento en nueva forma:");
            var squares = numbers.Select(n => n * n).ToList();
            Console.WriteLine($"  numbers.Select(n => n * n) = [{string.Join(", ", squares)}]\n");

            Console.WriteLine("SelectMany - Aplana colecciones anidadas:");
            var departments = new List<Department>
            {
                new Department { Name = "IT", Employees = new List<string> { "Alice", "Bob" } },
                new Department { Name = "HR", Employees = new List<string> { "Charlie", "David" } }
            };
            var allEmployees = departments.SelectMany(d => d.Employees).ToList();
            Console.WriteLine($"  departments.SelectMany(d => d.Employees) = [{string.Join(", ", allEmployees)}]\n");
        }

        /// <summary>
        /// Demuestra métodos de Ordering (Ordenamiento)
        /// </summary>
        public static void DemonstrateOrdering()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  4️⃣ Ordering (Ordenamiento) 📊");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var numbers = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6 };

            Console.WriteLine("OrderBy - Ordena ascendente:");
            var sortedAsc = numbers.OrderBy(n => n).ToList();
            Console.WriteLine($"  numbers.OrderBy(n => n) = [{string.Join(", ", sortedAsc)}]\n");

            Console.WriteLine("OrderByDescending - Ordena descendente:");
            var sortedDesc = numbers.OrderByDescending(n => n).ToList();
            Console.WriteLine($"  numbers.OrderByDescending(n => n) = [{string.Join(", ", sortedDesc)}]\n");

            Console.WriteLine("Reverse - Invierte el orden:");
            var reversed = numbers.AsEnumerable().Reverse().ToList();
            Console.WriteLine($"  numbers.Reverse() = [{string.Join(", ", reversed)}]\n");
        }

        /// <summary>
        /// Demuestra métodos de Aggregation (Agregación)
        /// </summary>
        public static void DemonstrateAggregation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  6️⃣ Aggregation (Agregación) 🧮");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine("Sum - Suma valores:");
            var sum = numbers.Sum();
            Console.WriteLine($"  numbers.Sum() = {sum}\n");

            Console.WriteLine("Average - Calcula promedio:");
            var average = numbers.Average();
            Console.WriteLine($"  numbers.Average() = {average}\n");

            Console.WriteLine("Count - Cuenta elementos:");
            var count = numbers.Count();
            Console.WriteLine($"  numbers.Count() = {count}\n");

            Console.WriteLine("Min y Max - Encuentra extremos:");
            var min = numbers.Min();
            var max = numbers.Max();
            Console.WriteLine($"  numbers.Min() = {min}, numbers.Max() = {max}\n");

            Console.WriteLine("Aggregate - Operación personalizada:");
            var product = numbers.Aggregate(1, (acc, n) => acc * n);
            Console.WriteLine($"  numbers.Aggregate(1, (acc, n) => acc * n) = {product} (factorial)\n");
        }

        /// <summary>
        /// Demuestra métodos de Quantifiers (Cuantificadores)
        /// </summary>
        public static void DemonstrateQuantifiers()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  7️⃣ Quantifiers (Cuantificadores) ✅");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var numbers = new List<int> { 2, 4, 6, 8, 10 };

            Console.WriteLine("All - Verifica si todos cumplen condición:");
            var allEven = numbers.All(n => n % 2 == 0);
            Console.WriteLine($"  numbers.All(n => n % 2 == 0) = {allEven}\n");

            Console.WriteLine("Any - Verifica si alguno cumple condición:");
            var hasOdd = numbers.Any(n => n % 2 == 1);
            Console.WriteLine($"  numbers.Any(n => n % 2 == 1) = {hasOdd}\n");

            Console.WriteLine("Contains - Verifica si contiene elemento:");
            var containsFive = numbers.Contains(5);
            Console.WriteLine($"  numbers.Contains(5) = {containsFive}\n");

            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 1, 2, 3 };
            Console.WriteLine("SequenceEqual - Verifica si dos secuencias son iguales:");
            var areEqual = list1.SequenceEqual(list2);
            Console.WriteLine($"  list1.SequenceEqual(list2) = {areEqual}\n");
        }

        /// <summary>
        /// Demuestra métodos de Element Operations
        /// </summary>
        public static void DemonstrateElementOperations()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  8️⃣ Element Operations (Operaciones de Elementos) 🧩");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var numbers = new List<int> { 10, 20, 30, 40, 50 };

            Console.WriteLine("First y FirstOrDefault - Obtiene primer elemento:");
            var first = numbers.First();
            var firstOrDefault = numbers.FirstOrDefault(n => n > 100);
            Console.WriteLine($"  numbers.First() = {first}");
            Console.WriteLine($"  numbers.FirstOrDefault(n => n > 100) = {firstOrDefault} (default)\n");

            Console.WriteLine("Last y LastOrDefault - Obtiene último elemento:");
            var last = numbers.Last();
            Console.WriteLine($"  numbers.Last() = {last}\n");

            Console.WriteLine("ElementAt y ElementAtOrDefault - Obtiene elemento por índice:");
            var second = numbers.ElementAt(1);
            var outOfRange = numbers.ElementAtOrDefault(10);
            Console.WriteLine($"  numbers.ElementAt(1) = {second}");
            Console.WriteLine($"  numbers.ElementAtOrDefault(10) = {outOfRange} (default)\n");
        }

        /// <summary>
        /// Demuestra métodos de Set Operations
        /// </summary>
        public static void DemonstrateSetOperations()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  9️⃣ Set Operations (Operaciones de Conjuntos) 🔀");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 3, 4, 5 };

            Console.WriteLine("Union - Combina elementos únicos:");
            var union = list1.Union(list2).ToList();
            Console.WriteLine($"  list1.Union(list2) = [{string.Join(", ", union)}]\n");

            Console.WriteLine("Intersect - Elementos comunes:");
            var intersect = list1.Intersect(list2).ToList();
            Console.WriteLine($"  list1.Intersect(list2) = [{string.Join(", ", intersect)}]\n");

            Console.WriteLine("Except - Diferencia:");
            var except = list1.Except(list2).ToList();
            Console.WriteLine($"  list1.Except(list2) = [{string.Join(", ", except)}]\n");

            Console.WriteLine("Concat - Combina secuencias:");
            var concat = list1.Concat(list2).ToList();
            Console.WriteLine($"  list1.Concat(list2) = [{string.Join(", ", concat)}]\n");
        }

        /// <summary>
        /// Demuestra métodos de Conversion
        /// </summary>
        public static void DemonstrateConversion()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔟 Conversion Operations (Operaciones de Conversión) 🔄");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var numbers = Enumerable.Range(1, 5);

            Console.WriteLine("ToArray y ToList - Convierte a array o lista:");
            var array = numbers.ToArray();
            var list = numbers.ToList();
            Console.WriteLine($"  numbers.ToArray() = [{string.Join(", ", array)}]");
            Console.WriteLine($"  numbers.ToList() = [{string.Join(", ", list)}]\n");

            var users = new List<User>
            {
                new User { Id = 1, Name = "Alice", Department = "IT" },
                new User { Id = 2, Name = "Bob", Department = "IT" },
                new User { Id = 3, Name = "Charlie", Department = "HR" }
            };

            Console.WriteLine("ToDictionary - Convierte a diccionario:");
            var dict = users.ToDictionary(u => u.Id, u => u.Name);
            Console.WriteLine($"  users.ToDictionary(u => u.Id, u => u.Name)");
            Console.WriteLine($"    Dict[1] = {dict[1]}\n");

            Console.WriteLine("GroupBy - Agrupa elementos:");
            var grouped = users.GroupBy(u => u.Department).ToList();
            foreach (var group in grouped)
            {
                Console.WriteLine($"    Department: {group.Key}, Users: {string.Join(", ", group.Select(u => u.Name))}");
            }
            Console.WriteLine();

            Console.WriteLine("OfType - Filtra y convierte por tipo:");
            var mixed = new List<object> { 1, "hello", 2, "world", 3 };
            var numbersOnly = mixed.OfType<int>().ToList();
            var stringsOnly = mixed.OfType<string>().ToList();
            Console.WriteLine($"  mixed.OfType<int>() = [{string.Join(", ", numbersOnly)}]");
            Console.WriteLine($"  mixed.OfType<string>() = [{string.Join(", ", stringsOnly)}]\n");
        }

        /// <summary>
        /// Demuestra por qué usar LINQ
        /// </summary>
        public static void DemonstrateWhyUseLinq()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔥 ¿Por Qué Usar LINQ?");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Mejora la Legibilidad y Mantenibilidad:");
            Console.WriteLine("  • Código declarativo vs imperativo");
            Console.WriteLine("  • Expresiones claras y concisas");
            Console.WriteLine("  • Fácil de entender y mantener\n");

            Console.WriteLine("✅ Reduce Loops y Lógica Condicional:");
            Console.WriteLine("  • Menos código boilerplate");
            Console.WriteLine("  • Operaciones complejas en una expresión");
            Console.WriteLine("  • Menos errores de lógica\n");

            Console.WriteLine("✅ Proporciona Capacidades Poderosas:");
            Console.WriteLine("  • Filtrado, ordenamiento, agrupación");
            Console.WriteLine("  • Agregaciones y transformaciones");
            Console.WriteLine("  • Operaciones de conjuntos\n");

            Console.WriteLine("✅ Funciona con Varias Fuentes de Datos:");
            Console.WriteLine("  • Colecciones en memoria (List, Array)");
            Console.WriteLine("  • Bases de datos (Entity Framework)");
            Console.WriteLine("  • XML (LINQ to XML)");
            Console.WriteLine("  • JSON (con librerías)\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          Desbloqueando el Poder de LINQ en C#                  ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateFiltering();
            Console.WriteLine("\n");
            DemonstrateProjection();
            Console.WriteLine("\n");
            DemonstrateOrdering();
            Console.WriteLine("\n");
            DemonstrateAggregation();
            Console.WriteLine("\n");
            DemonstrateQuantifiers();
            Console.WriteLine("\n");
            DemonstrateElementOperations();
            Console.WriteLine("\n");
            DemonstrateSetOperations();
            Console.WriteLine("\n");
            DemonstrateConversion();
            Console.WriteLine("\n");
            DemonstrateWhyUseLinq();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Categorías de Métodos LINQ:");
            Console.WriteLine("   1. Filtering: Where, Take, Skip, TakeWhile, SkipWhile");
            Console.WriteLine("   2. Projection: Select, SelectMany");
            Console.WriteLine("   3. Joining: Join, GroupJoin, Zip");
            Console.WriteLine("   4. Ordering: OrderBy, ThenBy, Reverse");
            Console.WriteLine("   5. Grouping: GroupBy");
            Console.WriteLine("   6. Aggregation: Sum, Average, Count, Min, Max, Aggregate");
            Console.WriteLine("   7. Quantifiers: All, Any, Contains, SequenceEqual");
            Console.WriteLine("   8. Element: First, Last, Single, ElementAt");
            Console.WriteLine("   9. Set: Union, Intersect, Except, Concat");
            Console.WriteLine("   10. Conversion: ToArray, ToList, ToDictionary, Cast, OfType\n");
            
            Console.WriteLine("💡 Beneficios:");
            Console.WriteLine("   • Mejora legibilidad y mantenibilidad");
            Console.WriteLine("   • Reduce loops y lógica condicional");
            Console.WriteLine("   • Proporciona capacidades poderosas");
            Console.WriteLine("   • Funciona con varias fuentes de datos\n");
        }
    }

    // Clases de ejemplo
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Role { get; set; } = string.Empty;
    }

    public class Department
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Employees { get; set; } = new();
    }
}

