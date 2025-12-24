namespace NetMasteryLab.Concepts.CSharpFundamentals.ParseVsTryParse.Examples
{
    /// <summary>
    /// Ejemplos que demuestran las diferencias entre int.Parse() e int.TryParse()
    /// </summary>
    public class ParseVsTryParseExamples
    {
        /// <summary>
        /// Demuestra el comportamiento de int.Parse() con diferentes casos
        /// </summary>
        public static void DemonstrateIntParse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️  int.Parse() - Lanza Excepciones");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Casos que lanzan excepciones:\n");

            // Caso 1: null
            Console.WriteLine("1. Entrada null:");
            Console.WriteLine("   string val = null;");
            Console.WriteLine("   int value = int.Parse(val);");
            Console.WriteLine("   // ArgumentNullException\n");

            try
            {
                string? val = null;
                int value = int.Parse(val!); // Intentionally null for demonstration
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("   ✅ ArgumentNullException capturada\n");
            }

            // Caso 2: Formato inválido
            Console.WriteLine("2. Formato inválido:");
            Console.WriteLine("   string val = \"100.11\";");
            Console.WriteLine("   int value = int.Parse(val);");
            Console.WriteLine("   // FormatException\n");

            try
            {
                string val = "100.11";
                int value = int.Parse(val);
            }
            catch (FormatException)
            {
                Console.WriteLine("   ✅ FormatException capturada\n");
            }

            // Caso 3: Overflow
            Console.WriteLine("3. Overflow:");
            Console.WriteLine("   string val = \"999999999999999999\";");
            Console.WriteLine("   int value = int.Parse(val);");
            Console.WriteLine("   // OverflowException\n");

            try
            {
                string val = "999999999999999999";
                int value = int.Parse(val);
            }
            catch (OverflowException)
            {
                Console.WriteLine("   ✅ OverflowException capturada\n");
            }

            // Caso exitoso
            Console.WriteLine("4. Entrada válida:");
            Console.WriteLine("   string val = \"123\";");
            Console.WriteLine("   int value = int.Parse(val);");
            Console.WriteLine("   // value = 123\n");

            string validVal = "123";
            int validValue = int.Parse(validVal);
            Console.WriteLine($"   ✅ Conversión exitosa: {validValue}\n");
        }

        /// <summary>
        /// Demuestra el comportamiento de int.TryParse() con diferentes casos
        /// </summary>
        public static void DemonstrateIntTryParse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ int.TryParse() - Sin Excepciones");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Casos que retornan false sin lanzar excepciones:\n");

            // Caso 1: null
            Console.WriteLine("1. Entrada null:");
            Console.WriteLine("   string val = null;");
            Console.WriteLine("   bool ifSuccess = int.TryParse(val, out result);");
            Console.WriteLine("   // ifSuccess = false | result = 0\n");

            string? val1 = null;
            bool success1 = int.TryParse(val1, out int result1);
            Console.WriteLine($"   ✅ ifSuccess = {success1} | result = {result1}\n");

            // Caso 2: Formato inválido
            Console.WriteLine("2. Formato inválido:");
            Console.WriteLine("   string val = \"100.11\";");
            Console.WriteLine("   bool ifSuccess = int.TryParse(val, out result);");
            Console.WriteLine("   // ifSuccess = false | result = 0\n");

            string val2 = "100.11";
            bool success2 = int.TryParse(val2, out int result2);
            Console.WriteLine($"   ✅ ifSuccess = {success2} | result = {result2}\n");

            // Caso 3: Overflow
            Console.WriteLine("3. Overflow:");
            Console.WriteLine("   string val = \"999999999999999999\";");
            Console.WriteLine("   bool ifSuccess = int.TryParse(val, out result);");
            Console.WriteLine("   // ifSuccess = false | result = 0\n");

            string val3 = "999999999999999999";
            bool success3 = int.TryParse(val3, out int result3);
            Console.WriteLine($"   ✅ ifSuccess = {success3} | result = {result3}\n");

            // Caso exitoso
            Console.WriteLine("4. Entrada válida:");
            Console.WriteLine("   string val = \"123\";");
            Console.WriteLine("   bool ifSuccess = int.TryParse(val, out result);");
            Console.WriteLine("   // ifSuccess = true | result = 123\n");

            string validVal = "123";
            bool validSuccess = int.TryParse(validVal, out int validResult);
            Console.WriteLine($"   ✅ ifSuccess = {validSuccess} | result = {validResult}\n");
        }

        /// <summary>
        /// Demuestra comparación de rendimiento
        /// </summary>
        public static void DemonstratePerformanceComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚡ Comparación de Rendimiento");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("⚠️  int.Parse() con excepciones es más lento:");
            Console.WriteLine("   • Overhead de crear stack trace");
            Console.WriteLine("   • Propagación de excepción");
            Console.WriteLine("   • Costo de try-catch\n");

            Console.WriteLine("✅ int.TryParse() es más rápido:");
            Console.WriteLine("   • Sin overhead de excepciones");
            Console.WriteLine("   • Retorno simple de boolean");
            Console.WriteLine("   • Más eficiente en loops y validaciones frecuentes\n");

            // Demostración simple
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            
            // TryParse (más rápido)
            for (int i = 0; i < 1000; i++)
            {
                int.TryParse("123", out _);
            }
            stopwatch.Stop();
            var tryParseTime = stopwatch.ElapsedTicks;

            stopwatch.Restart();
            
            // Parse con try-catch (más lento)
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    int.Parse("123");
                }
                catch { }
            }
            stopwatch.Stop();
            var parseTime = stopwatch.ElapsedTicks;

            Console.WriteLine($"   TryParse (1000 iteraciones): {tryParseTime} ticks");
            Console.WriteLine($"   Parse con try-catch (1000 iteraciones): {parseTime} ticks");
            Console.WriteLine($"   TryParse es aproximadamente {parseTime / (double)tryParseTime:F1}x más rápido\n");
        }

        /// <summary>
        /// Demuestra uso práctico con entrada del usuario
        /// </summary>
        public static void DemonstrateUserInput()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  👤 Manejo de Entrada del Usuario");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ MAL: int.Parse() sin manejo de errores");
            Console.WriteLine("```csharp");
            Console.WriteLine("string userInput = Console.ReadLine();");
            Console.WriteLine("int number = int.Parse(userInput); // Puede lanzar excepción");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: int.TryParse() - Manejo elegante");
            Console.WriteLine("```csharp");
            Console.WriteLine("string userInput = Console.ReadLine();");
            Console.WriteLine("if (int.TryParse(userInput, out int number))");
            Console.WriteLine("{");
            Console.WriteLine("    Console.WriteLine($\"Número válido: {number}\");");
            Console.WriteLine("}");
            Console.WriteLine("else");
            Console.WriteLine("{");
            Console.WriteLine("    Console.WriteLine(\"Error: Entrada inválida\");");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            // Simulación
            string?[] testInputs = { "123", "abc", "45.67", null };
            
            foreach (var input in testInputs)
            {
                if (int.TryParse(input, out int number))
                {
                    Console.WriteLine($"   Entrada '{input}': ✅ Válido - {number}");
                }
                else
                {
                    Console.WriteLine($"   Entrada '{input ?? "null"}': ❌ Inválido");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra uso con valores por defecto
        /// </summary>
        public static void DemonstrateDefaultValues()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔢 Uso con Valores por Defecto");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Usar valor por defecto si falla");
            Console.WriteLine("```csharp");
            Console.WriteLine("string userInput = Console.ReadLine();");
            Console.WriteLine("int number = int.TryParse(userInput, out int result) ? result : 0;");
            Console.WriteLine("```\n");

            string?[] testInputs = { "42", "invalid", null };
            
            foreach (var input in testInputs)
            {
                int number = int.TryParse(input, out int result) ? result : 0;
                Console.WriteLine($"   Entrada '{input ?? "null"}': Número = {number}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra otros tipos con TryParse
        /// </summary>
        public static void DemonstrateOtherTypes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Otros Tipos con TryParse");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ TryParse disponible para múltiples tipos:\n");

            // int
            int.TryParse("123", out int intValue);
            Console.WriteLine($"   int.TryParse(\"123\"): {intValue}");

            // long
            long.TryParse("1234567890123", out long longValue);
            Console.WriteLine($"   long.TryParse(\"1234567890123\"): {longValue}");

            // double
            double.TryParse("123.45", out double doubleValue);
            Console.WriteLine($"   double.TryParse(\"123.45\"): {doubleValue}");

            // decimal
            decimal.TryParse("123.45", out decimal decimalValue);
            Console.WriteLine($"   decimal.TryParse(\"123.45\"): {decimalValue}");

            // bool
            bool.TryParse("true", out bool boolValue);
            Console.WriteLine($"   bool.TryParse(\"true\"): {boolValue}");

            // DateTime
            DateTime.TryParse("2024-01-01", out DateTime dateValue);
            Console.WriteLine($"   DateTime.TryParse(\"2024-01-01\"): {dateValue:yyyy-MM-dd}\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Understanding int.Parse() vs int.TryParse() in C#         ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateIntParse();
            Console.WriteLine("\n");
            DemonstrateIntTryParse();
            Console.WriteLine("\n");
            DemonstratePerformanceComparison();
            Console.WriteLine("\n");
            DemonstrateUserInput();
            Console.WriteLine("\n");
            DemonstrateDefaultValues();
            Console.WriteLine("\n");
            DemonstrateOtherTypes();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ int.Parse():");
            Console.WriteLine("   • Lanza ArgumentNullException si input es null");
            Console.WriteLine("   • Lanza FormatException si formato es inválido");
            Console.WriteLine("   • Lanza OverflowException si está fuera de rango");
            Console.WriteLine("   • Requiere try-catch para manejo de errores\n");
            
            Console.WriteLine("✅ int.TryParse():");
            Console.WriteLine("   • Retorna false si falla, true si es exitoso");
            Console.WriteLine("   • Establece result en 0 si falla");
            Console.WriteLine("   • No lanza excepciones");
            Console.WriteLine("   • Más rápido y seguro para entrada del usuario\n");
            
            Console.WriteLine("💡 Key Takeaway:");
            Console.WriteLine("   • int.TryParse() es más seguro cuando quieres evitar excepciones");
            Console.WriteLine("   • int.Parse() es directo pero menos tolerante si la entrada no es correcta");
            Console.WriteLine("   • Usa TryParse para entrada del usuario, Parse para datos confiables\n");
        }
    }
}

