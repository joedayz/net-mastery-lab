using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMasteryLab.Concepts.CSharpFundamentals.EssentialCSharpFeatures.Examples
{
    /// <summary>
    /// Ejemplos que demuestran las 20 características esenciales de C#
    /// </summary>
    public class EssentialCSharpFeaturesExamples
    {
        /// <summary>
        /// Demuestra Genéricos
        /// </summary>
        public static void DemonstrateGenerics()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣ Genéricos 📦");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Clase genérica reutilizable:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Repository<T> where T : class");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly List<T> _items = new();");
            Console.WriteLine("    public void Add(T item) => _items.Add(item);");
            Console.WriteLine("    public T? GetById(int id) => _items.FirstOrDefault();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Reutilización de código sin sacrificar seguridad de tipos");
            Console.WriteLine("  • Evita conversiones de tipo (boxing/unboxing)");
            Console.WriteLine("  • Mejor rendimiento\n");
        }

        /// <summary>
        /// Demuestra Tipo Dynamic
        /// </summary>
        public static void DemonstrateDynamic()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  2️⃣ Tipo Dynamic ⚡");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Uso de dynamic para interoperabilidad:");
            Console.WriteLine("```csharp");
            Console.WriteLine("dynamic obj = GetObjectFromExternalSource();");
            Console.WriteLine("string name = obj.Name; // Resuelto en tiempo de ejecución");
            Console.WriteLine("int count = obj.Count;");
            Console.WriteLine("```\n");

            Console.WriteLine("Cuándo Usar:");
            Console.WriteLine("  • Interoperabilidad con COM");
            Console.WriteLine("  • APIs dinámicas (JSON, XML)");
            Console.WriteLine("  • Reflection avanzada\n");
        }

        /// <summary>
        /// Demuestra Tuplas y Deconstrucción
        /// </summary>
        public static void DemonstrateTuples()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  3️⃣ Tuplas y Deconstrucción 🔢");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Tupla simple:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public (string Name, int Age) GetPerson()");
            Console.WriteLine("    => (\"John\", 30);");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Deconstrucción:");
            Console.WriteLine("```csharp");
            Console.WriteLine("(string name, int age) = GetPerson();");
            Console.WriteLine("Console.WriteLine($\"{name} is {age} years old\");");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Deconstrucción con descarte:");
            Console.WriteLine("```csharp");
            Console.WriteLine("(string name, _) = GetPerson(); // Ignorar edad");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra Top-Level Statements
        /// </summary>
        public static void DemonstrateTopLevelStatements()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  4️⃣ Top-Level Statements ✨");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Top-Level Statements (C# 9.0+):");
            Console.WriteLine("```csharp");
            Console.WriteLine("using System;");
            Console.WriteLine("");
            Console.WriteLine("Console.WriteLine(\"Hello, World!\");");
            Console.WriteLine("var name = Console.ReadLine();");
            Console.WriteLine("Console.WriteLine($\"Hello, {name}!\");");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Código más simple para scripts");
            Console.WriteLine("  • Menos boilerplate");
            Console.WriteLine("  • Ideal para aprendizaje\n");
        }

        /// <summary>
        /// Demuestra Clases Parciales
        /// </summary>
        public static void DemonstratePartialClasses()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  5️⃣ Clases Parciales 🗂️");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Dividir clase en múltiples archivos:");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Archivo: User.cs");
            Console.WriteLine("public partial class User");
            Console.WriteLine("{");
            Console.WriteLine("    public int Id { get; set; }");
            Console.WriteLine("    public string Name { get; set; } = string.Empty;");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("// Archivo: User.Validation.cs");
            Console.WriteLine("public partial class User");
            Console.WriteLine("{");
            Console.WriteLine("    public bool IsValid() => !string.IsNullOrEmpty(Name);");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Cuándo Usar:");
            Console.WriteLine("  • Generadores de código (Entity Framework, WPF)");
            Console.WriteLine("  • Organizar clases grandes en archivos lógicos\n");
        }

        /// <summary>
        /// Demuestra Async/Await
        /// </summary>
        public static void DemonstrateAsyncAwait()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  6️⃣ Async / Await 🔄");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Método asíncrono:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public async Task<string> GetDataAsync()");
            Console.WriteLine("{");
            Console.WriteLine("    using var httpClient = new HttpClient();");
            Console.WriteLine("    var response = await httpClient.GetStringAsync(\"https://api.example.com/data\");");
            Console.WriteLine("    return response;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Múltiples operaciones asíncronas:");
            Console.WriteLine("```csharp");
            Console.WriteLine("var task1 = GetDataAsync();");
            Console.WriteLine("var task2 = GetOtherDataAsync();");
            Console.WriteLine("await Task.WhenAll(task1, task2);");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • No bloquea el hilo principal");
            Console.WriteLine("  • Mejor rendimiento y escalabilidad\n");
        }

        /// <summary>
        /// Demuestra Global Using
        /// </summary>
        public static void DemonstrateGlobalUsing()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  8️⃣ Directivas Global Using 🌍");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Global Using (C# 10.0+):");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Archivo: GlobalUsings.cs");
            Console.WriteLine("global using System;");
            Console.WriteLine("global using System.Collections.Generic;");
            Console.WriteLine("global using System.Linq;");
            Console.WriteLine("global using System.Threading.Tasks;");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Reduce repetición de using");
            Console.WriteLine("  • Código más limpio\n");
        }

        /// <summary>
        /// Demuestra List Patterns
        /// </summary>
        public static void DemonstrateListPatterns()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣2️⃣ List Patterns 📋");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ List patterns (C# 11.0+):");
            Console.WriteLine("```csharp");
            Console.WriteLine("int[] numbers = { 1, 2, 3 };");
            Console.WriteLine("");
            Console.WriteLine("var result = numbers switch");
            Console.WriteLine("{");
            Console.WriteLine("    [1, 2, 3] => \"Exact match\",");
            Console.WriteLine("    [1, ..] => \"Starts with 1\",");
            Console.WriteLine("    [.., 3] => \"Ends with 3\",");
            Console.WriteLine("    [1, .. var middle, 3] => $\"Middle: {string.Join(\", \", middle)}\",");
            Console.WriteLine("    _ => \"No match\"");
            Console.WriteLine("};");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra Expresiones Lambda
        /// </summary>
        public static void DemonstrateLambdaExpressions()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣3️⃣ Expresiones Lambda 🔥");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Lambda expression:");
            Console.WriteLine("```csharp");
            Console.WriteLine("Func<int, int> square = x => x * x;");
            Console.WriteLine("var result = square(5); // 25");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Lambda en LINQ:");
            Console.WriteLine("```csharp");
            Console.WriteLine("var activeUsers = users.Where(u => u.IsActive);");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Sintaxis concisa");
            Console.WriteLine("  • Ideal para LINQ y callbacks\n");
        }

        /// <summary>
        /// Demuestra Expression Body Members
        /// </summary>
        public static void DemonstrateExpressionBodyMembers()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣4️⃣ Miembros con Cuerpo de Expresión ✂️");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Método con expresión body:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public int Add(int x, int y) => x + y;");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Propiedad con expresión body:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public string FullName => $\"{FirstName} {LastName}\";");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Código más conciso");
            Console.WriteLine("  • Mejor legibilidad para métodos simples\n");
        }

        /// <summary>
        /// Demuestra Default Interface Methods
        /// </summary>
        public static void DemonstrateDefaultInterfaceMethods()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣5️⃣ Métodos por Defecto en Interfaces 🛠️");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Interface con método por defecto:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public interface ILogger");
            Console.WriteLine("{");
            Console.WriteLine("    void Log(string message);");
            Console.WriteLine("    void LogError(string message) => Log($\"ERROR: {message}\");");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Extiende interfaces sin romper compatibilidad");
            Console.WriteLine("  • Reduce duplicación de código\n");
        }

        /// <summary>
        /// Demuestra required modifier
        /// </summary>
        public static void DemonstrateRequiredModifier()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣6️⃣ Modificador required ✅");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Propiedades required (C# 11.0+):");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class User");
            Console.WriteLine("{");
            Console.WriteLine("    public required string Name { get; set; }");
            Console.WriteLine("    public required int Age { get; set; }");
            Console.WriteLine("    public string? Email { get; set; } // Opcional");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Debe inicializar propiedades required:");
            Console.WriteLine("```csharp");
            Console.WriteLine("var user = new User { Name = \"John\", Age = 30 };");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Garantiza inicialización de propiedades críticas");
            Console.WriteLine("  • Seguridad en tiempo de compilación\n");
        }

        /// <summary>
        /// Demuestra Extension Methods
        /// </summary>
        public static void DemonstrateExtensionMethods()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣7️⃣ Métodos de Extensión ✨");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Método de extensión:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public static class StringExtensions");
            Console.WriteLine("{");
            Console.WriteLine("    public static bool IsValidEmail(this string email)");
            Console.WriteLine("        => email.Contains(\"@\") && email.Contains(\".\");");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Uso:");
            Console.WriteLine("```csharp");
            Console.WriteLine("string email = \"user@example.com\";");
            Console.WriteLine("if (email.IsValidEmail())");
            Console.WriteLine("{");
            Console.WriteLine("    Console.WriteLine(\"Valid email\");");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Extiende tipos sin modificar su código fuente");
            Console.WriteLine("  • Sintaxis natural y legible\n");
        }

        /// <summary>
        /// Demuestra Auto-Property Initializers
        /// </summary>
        public static void DemonstrateAutoPropertyInitializers()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣8️⃣ Inicializadores de Auto-Propiedades 🏗️");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Auto-property initializer:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Configuration");
            Console.WriteLine("{");
            Console.WriteLine("    public string ApiUrl { get; set; } = \"https://api.example.com\";");
            Console.WriteLine("    public int Timeout { get; set; } = 30;");
            Console.WriteLine("    public List<string> AllowedDomains { get; set; } = new();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Código más conciso");
            Console.WriteLine("  • Valores por defecto claros\n");
        }

        /// <summary>
        /// Demuestra Records
        /// </summary>
        public static void DemonstrateRecords()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣9️⃣ Tipos Record 📖");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Record simple:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public record Person(string Name, int Age);");
            Console.WriteLine("");
            Console.WriteLine("var person1 = new Person(\"John\", 30);");
            Console.WriteLine("var person2 = new Person(\"John\", 30);");
            Console.WriteLine("Console.WriteLine(person1 == person2); // True (igualdad por valor)");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Record con with expression:");
            Console.WriteLine("```csharp");
            Console.WriteLine("var person3 = person1 with { Age = 31 }; // Nuevo record");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Inmutabilidad por defecto");
            Console.WriteLine("  • Igualdad por valor (no por referencia)");
            Console.WriteLine("  • Ideal para DTOs y value objects\n");
        }

        /// <summary>
        /// Demuestra Collection Expressions
        /// </summary>
        public static void DemonstrateCollectionExpressions()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  2️⃣0️⃣ Expresiones de Colección");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Collection expressions (C# 12.0+):");
            Console.WriteLine("```csharp");
            Console.WriteLine("int[] numbers = [1, 2, 3, 4, 5];");
            Console.WriteLine("List<string> names = [\"Alice\", \"Bob\", \"Charlie\"];");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Spread operator:");
            Console.WriteLine("```csharp");
            Console.WriteLine("int[] first = [1, 2, 3];");
            Console.WriteLine("int[] second = [4, 5, 6];");
            Console.WriteLine("int[] combined = [..first, ..second]; // [1, 2, 3, 4, 5, 6]");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  • Sintaxis más concisa que new[] { }");
            Console.WriteLine("  • Funciona con arrays, listas, spans\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║        Top 20 Características Esenciales de C#                ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateGenerics();
            Console.WriteLine("\n");
            DemonstrateDynamic();
            Console.WriteLine("\n");
            DemonstrateTuples();
            Console.WriteLine("\n");
            DemonstrateTopLevelStatements();
            Console.WriteLine("\n");
            DemonstratePartialClasses();
            Console.WriteLine("\n");
            DemonstrateAsyncAwait();
            Console.WriteLine("\n");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  7️⃣ Pattern Matching - Ya cubierto en Modern LINQ & Features");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("\n");
            DemonstrateGlobalUsing();
            Console.WriteLine("\n");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  9️⃣ LINQ - Ya cubierto en LINQ Methods");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("\n");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔟 Interpolación de Cadenas - Ya cubierto en Interpolated Strings");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("\n");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣1️⃣ Nullable Reference Types - Ya cubierto en Modern Features");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("\n");
            DemonstrateListPatterns();
            Console.WriteLine("\n");
            DemonstrateLambdaExpressions();
            Console.WriteLine("\n");
            DemonstrateExpressionBodyMembers();
            Console.WriteLine("\n");
            DemonstrateDefaultInterfaceMethods();
            Console.WriteLine("\n");
            DemonstrateRequiredModifier();
            Console.WriteLine("\n");
            DemonstrateExtensionMethods();
            Console.WriteLine("\n");
            DemonstrateAutoPropertyInitializers();
            Console.WriteLine("\n");
            DemonstrateRecords();
            Console.WriteLine("\n");
            DemonstrateCollectionExpressions();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Top 20 Características Esenciales de C#:");
            Console.WriteLine("   1. Genéricos - Código reutilizable y type-safe");
            Console.WriteLine("   2. Dynamic - Flexibilidad en tiempo de ejecución");
            Console.WriteLine("   3. Tuplas - Múltiples valores de retorno");
            Console.WriteLine("   4. Top-Level Statements - Código más simple");
            Console.WriteLine("   5. Partial Classes - Dividir clases en archivos");
            Console.WriteLine("   6. Async/Await - Programación asíncrona");
            Console.WriteLine("   7. Pattern Matching - Lógica condicional clara");
            Console.WriteLine("   8. Global Using - Menos repetición");
            Console.WriteLine("   9. LINQ - Consultas declarativas");
            Console.WriteLine("   10. String Interpolation - Formato limpio");
            Console.WriteLine("   11. Nullable Reference Types - Seguridad contra null");
            Console.WriteLine("   12. List Patterns - Pattern matching en colecciones");
            Console.WriteLine("   13. Lambda Expressions - Funciones anónimas");
            Console.WriteLine("   14. Expression Body Members - Métodos concisos");
            Console.WriteLine("   15. Default Interface Methods - Extender interfaces");
            Console.WriteLine("   16. required modifier - Propiedades obligatorias");
            Console.WriteLine("   17. Extension Methods - Extender tipos");
            Console.WriteLine("   18. Auto-Property Initializers - Inicialización directa");
            Console.WriteLine("   19. Records - Tipos inmutables");
            Console.WriteLine("   20. Collection Expressions - Inicialización concisa\n");
            
            Console.WriteLine("💡 Nota: Algunas características ya están cubiertas en detalle");
            Console.WriteLine("   en otros temas del repositorio. Este tema proporciona");
            Console.WriteLine("   una visión general completa de todas las características.\n");
        }
    }
}

