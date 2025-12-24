namespace NetMasteryLab.Concepts.CSharpFundamentals.ModernFeatures.Examples
{
    /// <summary>
    /// Ejemplos que demuestran características modernas de C#
    /// </summary>
    public class ModernFeaturesExamples
    {
        /// <summary>
        /// Demuestra Null Handling Philosophy
        /// </summary>
        public static void DemonstrateNullHandling()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1. The Philosophy of Null Handling 🚫");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Null-Conditional Operator (?.)");
            Console.WriteLine("  Permite acceso seguro a miembros de objetos que pueden ser null\n");

            Console.WriteLine("❌ ANTES: Programación defensiva verbosa");
            Console.WriteLine("```csharp");
            Console.WriteLine("if (person != null && person.Address != null && person.Address.City != null)");
            Console.WriteLine("{");
            Console.WriteLine("    name = person.Address.City;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ DESPUÉS: Null-conditional operator");
            Console.WriteLine("```csharp");
            Console.WriteLine("string? name = person?.Address?.City;");
            Console.WriteLine("```\n");

            Console.WriteLine("Null-Coalescing Operator (??)");
            Console.WriteLine("  Proporciona un valor por defecto cuando la expresión es null\n");

            Console.WriteLine("✅ BIEN: Null-coalescing operator");
            Console.WriteLine("```csharp");
            Console.WriteLine("string name = person?.Name ?? \"Unknown\";");
            Console.WriteLine("```\n");

            Console.WriteLine("Key Benefits:");
            Console.WriteLine("  ✅ Reduced Runtime Exceptions");
            Console.WriteLine("  ✅ More Expressive Code Semantics");
            Console.WriteLine("  ✅ Better Compile-Time Safety Guarantees");
            Console.WriteLine("  ✅ Cleaner Null Propagation Chains\n");

            // Ejemplos prácticos
            Person? person = null;
            var city = person?.Address?.City ?? "Unknown";
            Console.WriteLine($"Ejemplo práctico: city = {city}");

            person = new Person { Name = "John", Address = new Address { City = "New York" } };
            city = person?.Address?.City ?? "Unknown";
            Console.WriteLine($"Ejemplo práctico: city = {city}\n");
        }

        /// <summary>
        /// Demuestra Pattern Matching
        /// </summary>
        public static void DemonstratePatternMatching()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  2. Pattern Matching: Beyond Simple Type Checks 🎯");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Type Patterns:");
            Console.WriteLine("  Simplifica las pruebas de tipo y conversión\n");

            Console.WriteLine("✅ BIEN: Type pattern");
            Console.WriteLine("```csharp");
            Console.WriteLine("if (obj is string str)");
            Console.WriteLine("{");
            Console.WriteLine("    Console.WriteLine(str.ToUpper());");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Property Patterns:");
            Console.WriteLine("  Coincide con propiedades de objetos\n");

            Console.WriteLine("✅ BIEN: Property pattern");
            Console.WriteLine("```csharp");
            Console.WriteLine("var message = person switch");
            Console.WriteLine("{");
            Console.WriteLine("    { Age: >= 18 } => \"Adult\",");
            Console.WriteLine("    { Age: < 18 } => \"Minor\",");
            Console.WriteLine("    _ => \"Unknown\"");
            Console.WriteLine("};");
            Console.WriteLine("```\n");

            Console.WriteLine("Relational Patterns:");
            Console.WriteLine("  Compara valores numéricos\n");

            Console.WriteLine("✅ BIEN: Relational pattern");
            Console.WriteLine("```csharp");
            Console.WriteLine("var grade = score switch");
            Console.WriteLine("{");
            Console.WriteLine("    >= 90 => \"A\",");
            Console.WriteLine("    >= 80 => \"B\",");
            Console.WriteLine("    >= 70 => \"C\",");
            Console.WriteLine("    _ => \"F\"");
            Console.WriteLine("};");
            Console.WriteLine("```\n");

            // Ejemplos prácticos
            object obj = "Hello";
            if (obj is string str)
            {
                Console.WriteLine($"Ejemplo type pattern: {str.ToUpper()}");
            }

            var person = new Person { Age = 25 };
            var message = person.Age switch
            {
                >= 18 => "Adult",
                < 18 => "Minor"
            };
            Console.WriteLine($"Ejemplo relational pattern: {message}\n");
        }

        /// <summary>
        /// Demuestra Resource Management with 'using'
        /// </summary>
        public static void DemonstrateResourceManagement()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  3. Resource Management Evolution with 'using' 🧹");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("using Statement:");
            Console.WriteLine("  Limpieza determinística de recursos\n");

            Console.WriteLine("✅ BIEN: using statement tradicional");
            Console.WriteLine("```csharp");
            Console.WriteLine("using (var stream = new FileStream(\"file.txt\", FileMode.Open))");
            Console.WriteLine("{");
            Console.WriteLine("    // Usar stream");
            Console.WriteLine("} // Se dispone automáticamente");
            Console.WriteLine("```\n");

            Console.WriteLine("using Declaration (C# 8.0+):");
            Console.WriteLine("  Gestión automática basada en scope\n");

            Console.WriteLine("✅ MEJOR: using declaration");
            Console.WriteLine("```csharp");
            Console.WriteLine("using var stream = new FileStream(\"file.txt\", FileMode.Open);");
            Console.WriteLine("// Se dispone al final del scope automáticamente");
            Console.WriteLine("```\n");

            Console.WriteLine("Resource Management Principles:");
            Console.WriteLine("  ✅ Deterministic Cleanup");
            Console.WriteLine("  ✅ Automatic Resource Disposal");
            Console.WriteLine("  ✅ Scope-Based Lifetime Management");
            Console.WriteLine("  ✅ Exception-Safe Resource Handling\n");

            // Ejemplo práctico con clase simulada
            using var resource = new DisposableResource();
            Console.WriteLine("Ejemplo práctico: Recurso creado y se dispondrá automáticamente\n");
        }

        /// <summary>
        /// Demuestra Target-Typed 'new'
        /// </summary>
        public static void DemonstrateTargetTypedNew()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  4. Target-Typed 'new': Type Inference Advancement 🆕");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ ANTES: Tipo explícito repetido");
            Console.WriteLine("```csharp");
            Console.WriteLine("Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ DESPUÉS: Target-typed new");
            Console.WriteLine("```csharp");
            Console.WriteLine("Dictionary<string, List<int>> dict = new();");
            Console.WriteLine("```\n");

            Console.WriteLine("Benefits:");
            Console.WriteLine("  ✅ Reduced Code Verbosity");
            Console.WriteLine("  ✅ Maintained Type Safety");
            Console.WriteLine("  ✅ Better Readability");
            Console.WriteLine("  ✅ Enhanced Maintainability\n");

            // Ejemplo práctico
            Dictionary<string, List<int>> dict = new();
            dict["numbers"] = new List<int> { 1, 2, 3 };
            Console.WriteLine($"Ejemplo práctico: dict creado con target-typed new, contiene {dict["numbers"].Count} elementos\n");
        }

        /// <summary>
        /// Demuestra Strategic Importance of 'nameof'
        /// </summary>
        public static void DemonstrateNameof()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  5. The Strategic Importance of 'nameof' 🏷️");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ ANTES: String literal (frágil ante refactoring)");
            Console.WriteLine("```csharp");
            Console.WriteLine("if (name == null)");
            Console.WriteLine("    throw new ArgumentNullException(\"name\");");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ DESPUÉS: nameof (seguro ante refactoring)");
            Console.WriteLine("```csharp");
            Console.WriteLine("if (name == null)");
            Console.WriteLine("    throw new ArgumentNullException(nameof(name));");
            Console.WriteLine("```\n");

            Console.WriteLine("Applications:");
            Console.WriteLine("  ✅ Exception Messages");
            Console.WriteLine("  ✅ Property Change Notifications");
            Console.WriteLine("  ✅ Logging and Diagnostics");
            Console.WriteLine("  ✅ Metadata Generation\n");

            // Ejemplo práctico
            string? name = null;
            try
            {
                if (name == null)
                    throw new ArgumentNullException(nameof(name));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Ejemplo práctico: Excepción con nameof - {ex.ParamName}\n");
            }
        }

        /// <summary>
        /// Demuestra Type Conversion Safety with 'as'
        /// </summary>
        public static void DemonstrateTypeConversion()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  6. Type Conversion Safety with 'as' 🔄");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ ANTES: Casting tradicional (puede lanzar excepción)");
            Console.WriteLine("```csharp");
            Console.WriteLine("string str = (string)obj; // Puede lanzar InvalidCastException");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ DESPUÉS: Operador 'as' (retorna null si falla)");
            Console.WriteLine("```csharp");
            Console.WriteLine("string? str = obj as string; // null si falla, sin excepción");
            Console.WriteLine("```\n");

            Console.WriteLine("Key Aspects:");
            Console.WriteLine("  ✅ Null-Based Failure Indication");
            Console.WriteLine("  ✅ Performance Optimization");
            Console.WriteLine("  ✅ Type Safety Enhancement");
            Console.WriteLine("  ✅ Better Error Handling Patterns\n");

            // Ejemplos prácticos
            object obj1 = "Hello";
            string? str1 = obj1 as string;
            Console.WriteLine($"Ejemplo 1 (éxito): str = {str1}");

            object obj2 = 123;
            string? str2 = obj2 as string;
            Console.WriteLine($"Ejemplo 2 (fallo): str = {str2 ?? "null"} (sin excepción)\n");
        }

        /// <summary>
        /// Demuestra C# 13 Simplified params
        /// </summary>
        public static void DemonstrateSimplifiedParams()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  7. C# 13: Simplified params with Collections 🚀");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ ANTES C# 13: Conversión explícita requerida");
            Console.WriteLine("```csharp");
            Console.WriteLine("var names = new List<string> { \"Alice\", \"Bob\", \"Charlie\" };");
            Console.WriteLine("PrintNames(names.ToArray()); // Conversión explícita necesaria");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ DESPUÉS C# 13: Sin conversión explícita");
            Console.WriteLine("```csharp");
            Console.WriteLine("var names = new List<string> { \"Alice\", \"Bob\", \"Charlie\" };");
            Console.WriteLine("PrintNames(names); // Sin conversión requerida");
            Console.WriteLine("```\n");

            Console.WriteLine("Why It Matters?");
            Console.WriteLine("  ✅ Reduces Boilerplate Code");
            Console.WriteLine("  ✅ Enhances Code Readability");
            Console.WriteLine("  ✅ Saves Time and Effort\n");

            // Ejemplo práctico
            var names = new List<string> { "Alice", "Bob", "Charlie" };
            Console.WriteLine("Ejemplo práctico:");
            Console.WriteLine("  List<string> names = new List<string> { \"Alice\", \"Bob\", \"Charlie\" };");
            Console.WriteLine("  PrintNames(names); // Funciona directamente sin .ToArray()\n");
            
            // Simulación de llamada
            Console.WriteLine("  Resultado:");
            foreach (var name in names)
            {
                Console.WriteLine($"    - {name}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra Locking Mechanism con System.Threading.Lock
        /// </summary>
        public static void DemonstrateLockingMechanism()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  8. Locking Mechanism with .NET 9 & C# 13 🔒");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ ANTES: Implementación tradicional");
            Console.WriteLine("```csharp");
            Console.WriteLine("private object myLock = new object();");
            Console.WriteLine("lock (myLock)");
            Console.WriteLine("{");
            Console.WriteLine("    // Your code");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ DESPUÉS: Con System.Threading.Lock");
            Console.WriteLine("```csharp");
            Console.WriteLine("private System.Threading.Lock myLock = new System.Threading.Lock();");
            Console.WriteLine("lock (myLock)");
            Console.WriteLine("{");
            Console.WriteLine("    // Your code");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Why Upgrade? 🚀");
            Console.WriteLine("  🔹 Performance Boost: Optimizado para mejor manejo de recursos");
            Console.WriteLine("  🔹 Compiler Support: C# 13 integra completamente con System.Threading.Lock");
            Console.WriteLine("  🔹 Code Safety: Detecta automáticamente uso incorrecto\n");

            Console.WriteLine("Minimal Change, Maximum Impact 🎉");
            Console.WriteLine("  1. ✅ Target .NET 9 en tu proyecto");
            Console.WriteLine("  2. ✅ Reemplaza object con System.Threading.Lock");
            Console.WriteLine("  ¡Eso es todo! Tu código es más eficiente y moderno.\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  ✅ Performance optimizado");
            Console.WriteLine("  ✅ Type safety mejorado");
            Console.WriteLine("  ✅ Compiler warnings para uso incorrecto");
            Console.WriteLine("  ✅ Mejor manejo de recursos\n");
        }

        /// <summary>
        /// Demuestra el impacto de las características modernas
        /// </summary>
        public static void DemonstrateImpact()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  Understanding the Impact 🚀");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("From Runtime to Compile-Time Safety:");
            Console.WriteLine("  1. Moving Error Detection Earlier");
            Console.WriteLine("     • Detección de errores más temprano en el ciclo de desarrollo");
            Console.WriteLine("     • Menos bugs en producción\n");

            Console.WriteLine("  2. Reducing Production Issues");
            Console.WriteLine("     • Menos problemas en producción");
            Console.WriteLine("     • Código más confiable\n");

            Console.WriteLine("  3. Improving Code Reliability");
            Console.WriteLine("     • Mejor confiabilidad del código");
            Console.WriteLine("     • Menos excepciones en tiempo de ejecución\n");

            Console.WriteLine("Comparación: Antes vs Después");
            Console.WriteLine("┌─────────────────────┬──────────────────┬──────────────────┐");
            Console.WriteLine("│ Aspecto             │ Antes            │ Después          │");
            Console.WriteLine("├─────────────────────┼──────────────────┼──────────────────┤");
            Console.WriteLine("│ Null Safety          │ Runtime exc.     │ Compile-time     │");
            Console.WriteLine("│ Type Checking        │ Runtime casting  │ Compile-time     │");
            Console.WriteLine("│ Resource Management │ Manual disposal  │ Automatic        │");
            Console.WriteLine("│ Code Verbosity      │ Repetitive types │ Target-typed new │");
            Console.WriteLine("│ Refactoring Safety  │ String literals  │ nameof operator  │");
            Console.WriteLine("│ Type Conversion     │ Exception-prone  │ Null-safe with as│");
            Console.WriteLine("└─────────────────────┴──────────────────┴──────────────────┘\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  Modern C# Features                           ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateNullHandling();
            Console.WriteLine("\n");
            DemonstratePatternMatching();
            Console.WriteLine("\n");
            DemonstrateResourceManagement();
            Console.WriteLine("\n");
            DemonstrateTargetTypedNew();
            Console.WriteLine("\n");
            DemonstrateNameof();
            Console.WriteLine("\n");
            DemonstrateTypeConversion();
            Console.WriteLine("\n");
            DemonstrateSimplifiedParams();
            Console.WriteLine("\n");
            DemonstrateLockingMechanism();
            Console.WriteLine("\n");
            DemonstrateImpact();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Características Modernas de C#:");
            Console.WriteLine("   1. Null Handling: Operadores ?. y ?? para seguridad");
            Console.WriteLine("   2. Pattern Matching: Lógica compleja más clara");
            Console.WriteLine("   3. Resource Management: using para limpieza automática");
            Console.WriteLine("   4. Target-Typed new: Código más conciso");
            Console.WriteLine("   5. nameof: Refactoring seguro");
            Console.WriteLine("   6. Type Conversion: Operador 'as' para conversión segura");
            Console.WriteLine("   7. Simplified params (C# 13): Colecciones directamente sin conversión");
            Console.WriteLine("   8. System.Threading.Lock (.NET 9/C# 13): Locking optimizado y type-safe\n");
            
            Console.WriteLine("🚀 Impacto:");
            Console.WriteLine("   • De Runtime a Compile-Time Safety");
            Console.WriteLine("   • Reducción de problemas en producción");
            Console.WriteLine("   • Mejora en confiabilidad del código\n");
        }
    }

    // Clases de ejemplo para demostración

    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public Address? Address { get; set; }
    }

    public class Address
    {
        public string? City { get; set; }
        public string? Street { get; set; }
    }

    public class DisposableResource : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("  Recurso dispuesto correctamente");
        }
    }
}

