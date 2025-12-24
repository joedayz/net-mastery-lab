using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMasteryLab.Concepts.CSharpFundamentals.VariablesTypeConversion.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Variables y Conversión de Tipos en C#
    /// </summary>
    public class VariablesTypeConversionExamples
    {
        /// <summary>
        /// Demuestra declaración de variables y tipos de datos comunes
        /// </summary>
        public static void DemonstrateVariableDeclaration()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📝 Declaración de Variables y Tipos de Datos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // Tipos numéricos enteros
            Console.WriteLine("🔢 Tipos Numéricos Enteros:");
            byte b = 255;
            short s = -32768;
            int i = 2147483647;
            long l = 9223372036854775807;
            Console.WriteLine($"  byte: {b}, short: {s}, int: {i}, long: {l}\n");

            // Tipos de punto flotante
            Console.WriteLine("⚖️ Tipos de Punto Flotante:");
            float f = 3.14f;
            double d = 3.14159265359;
            decimal dec = 99.99m;
            Console.WriteLine($"  float: {f}, double: {d}, decimal: {dec}\n");

            // Tipos de texto
            Console.WriteLine("📝 Tipos de Texto:");
            string text = "Hello World";
            char character = 'A';
            Console.WriteLine($"  string: {text}, char: {character}\n");

            // Tipo booleano
            Console.WriteLine("✅ Tipo Booleano:");
            bool isTrue = true;
            bool isFalse = false;
            Console.WriteLine($"  isTrue: {isTrue}, isFalse: {isFalse}\n");
        }

        /// <summary>
        /// Demuestra inferencia de tipos con var
        /// </summary>
        public static void DemonstrateTypeInference()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔍 Inferencia de Tipos con var");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // var infiere el tipo del valor asignado
            var name = "Alice";              // string
            var age = 25;                    // int
            var isActive = true;             // bool
            var prices = new List<decimal>(); // List<decimal>

            Console.WriteLine($"✅ var name = \"Alice\"; // Tipo: {name.GetType().Name}");
            Console.WriteLine($"✅ var age = 25; // Tipo: {age.GetType().Name}");
            Console.WriteLine($"✅ var isActive = true; // Tipo: {isActive.GetType().Name}");
            Console.WriteLine($"✅ var prices = new List<decimal>(); // Tipo: {prices.GetType().Name}\n");

            // var con LINQ
            var users = new List<string> { "Alice", "Bob", "Charlie" };
            var activeUsers = users.Where(u => u.Length > 3).ToList();
            Console.WriteLine($"✅ var con LINQ: {activeUsers.GetType().Name}\n");
        }

        /// <summary>
        /// Demuestra conversión implícita y explícita
        /// </summary>
        public static void DemonstrateTypeConversion()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Conversión de Tipos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // Conversión implícita (automática)
            Console.WriteLine("🟢 Conversión Implícita (Automática):");
            int small = 100;
            long large = small; // Conversión implícita
            Console.WriteLine($"  int {small} → long {large} (automática)\n");

            float f = 3.14f;
            double d = f; // Conversión implícita
            Console.WriteLine($"  float {f} → double {d} (automática)\n");

            // Conversión explícita (cast)
            Console.WriteLine("🔴 Conversión Explícita (Cast):");
            double price = 99.99;
            int integerPrice = (int)price; // Conversión explícita
            Console.WriteLine($"  double {price} → int {integerPrice} (pérdida de decimales)\n");

            long bigNumber = 1000;
            int smallNumber = (int)bigNumber; // Conversión explícita
            Console.WriteLine($"  long {bigNumber} → int {smallNumber}\n");
        }

        /// <summary>
        /// Demuestra métodos de conversión
        /// </summary>
        public static void DemonstrateConversionMethods()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🛠️ Métodos de Conversión");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // int.Parse()
            Console.WriteLine("📌 int.Parse() - Lanza excepciones si falla:");
            string validNumber = "123";
            int parsed = int.Parse(validNumber);
            Console.WriteLine($"  int.Parse(\"{validNumber}\") = {parsed}\n");

            // int.TryParse() - Recomendado
            Console.WriteLine("✅ int.TryParse() - Retorna bool, no lanza excepciones:");
            string input1 = "123";
            string input2 = "abc";

            if (int.TryParse(input1, out int result1))
            {
                Console.WriteLine($"  int.TryParse(\"{input1}\", out int) = {result1} ✅");
            }

            if (!int.TryParse(input2, out int result2))
            {
                Console.WriteLine($"  int.TryParse(\"{input2}\", out int) = false ❌\n");
            }

            // Convert.ToInt32()
            Console.WriteLine("🔧 Convert.ToInt32() - Maneja null:");
            string numberStr = "456";
            int converted = Convert.ToInt32(numberStr);
            Console.WriteLine($"  Convert.ToInt32(\"{numberStr}\") = {converted}");
            Console.WriteLine($"  Convert.ToInt32(null) = {Convert.ToInt32(null)} (retorna 0)\n");
        }

        /// <summary>
        /// Demuestra tipos nullable
        /// </summary>
        public static void DemonstrateNullableTypes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ❓ Tipos Nullable");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            int? nullableInt = null;
            bool? nullableBool = null;
            DateTime? nullableDate = null;

            Console.WriteLine($"int? nullableInt = null; // {nullableInt}");
            Console.WriteLine($"bool? nullableBool = null; // {nullableBool}");
            Console.WriteLine($"DateTime? nullableDate = null; // {nullableDate}\n");

            // Verificar si tiene valor
            nullableInt = 42;
            if (nullableInt.HasValue)
            {
                Console.WriteLine($"✅ nullableInt.HasValue = true, Value = {nullableInt.Value}\n");
            }

            // Operador null-coalescing
            int result = nullableInt ?? 0;
            Console.WriteLine($"int result = nullableInt ?? 0; // {result}\n");
        }

        /// <summary>
        /// Demuestra constantes y readonly
        /// </summary>
        public static void DemonstrateConstants()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔒 Constantes y Variables de Solo Lectura");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // Constante
            const int MaxRetries = 3;
            const string ApiUrl = "https://api.example.com";
            Console.WriteLine($"const int MaxRetries = {MaxRetries};");
            Console.WriteLine($"const string ApiUrl = \"{ApiUrl}\";\n");

            // Readonly (se inicializa en constructor)
            var example = new ExampleClass("connection-string-value");
            Console.WriteLine($"readonly string ConnectionString = \"{example.ConnectionString}\";\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          Variables y Conversión de Tipos en C#                ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateVariableDeclaration();
            Console.WriteLine("\n");
            DemonstrateTypeInference();
            Console.WriteLine("\n");
            DemonstrateTypeConversion();
            Console.WriteLine("\n");
            DemonstrateConversionMethods();
            Console.WriteLine("\n");
            DemonstrateNullableTypes();
            Console.WriteLine("\n");
            DemonstrateConstants();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Tipos de Datos:");
            Console.WriteLine("   • Enteros: byte, short, int, long");
            Console.WriteLine("   • Punto flotante: float, double, decimal");
            Console.WriteLine("   • Texto: string, char");
            Console.WriteLine("   • Booleano: bool\n");
            
            Console.WriteLine("✅ Conversión de Tipos:");
            Console.WriteLine("   • Implícita: Automática (de menor a mayor precisión)");
            Console.WriteLine("   • Explícita: Cast (puede haber pérdida de datos)");
            Console.WriteLine("   • Métodos: Parse(), TryParse(), Convert\n");
            
            Console.WriteLine("✅ Inferencia de Tipos:");
            Console.WriteLine("   • var: Infiere tipo del valor asignado");
            Console.WriteLine("   • Usar cuando el tipo es obvio");
            Console.WriteLine("   • Evitar cuando el tipo no es claro\n");
            
            Console.WriteLine("✅ Mejores Prácticas:");
            Console.WriteLine("   • Preferir TryParse sobre Parse");
            Console.WriteLine("   • Usar decimal para dinero");
            Console.WriteLine("   • Validar conversiones antes de usar\n");
        }
    }

    /// <summary>
    /// Clase de ejemplo para demostrar readonly
    /// </summary>
    public class ExampleClass
    {
        public readonly string ConnectionString;

        public ExampleClass(string connectionString)
        {
            ConnectionString = connectionString; // Solo se puede asignar aquí
        }
    }
}

