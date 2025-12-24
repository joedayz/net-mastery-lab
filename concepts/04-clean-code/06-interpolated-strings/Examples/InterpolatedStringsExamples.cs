namespace NetMasteryLab.Concepts.CleanCode.InterpolatedStrings.Examples
{
    /// <summary>
    /// Ejemplos que demuestran cómo usar Interpolated Strings en lugar de string.Format
    /// </summary>
    public class InterpolatedStringsExamples
    {
        /// <summary>
        /// Demuestra el problema de usar string.Format
        /// </summary>
        public static void DemonstrateStringFormat()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ❌ MENOS PREFERIDO: string.Format");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Código problemático:");
            Console.WriteLine("```csharp");
            Console.WriteLine("string name = \"Alice\";");
            Console.WriteLine("int age = 30;");
            Console.WriteLine("string message = string.Format(\"Name: {0}, Age: {1}\", name, age);");
            Console.WriteLine("```\n");

            Console.WriteLine("Problemas:");
            Console.WriteLine("  • Menos legible - placeholders {0}, {1} no son descriptivos");
            Console.WriteLine("  • Propenso a errores - fácil pasar argumentos en orden incorrecto");
            Console.WriteLine("  • Difícil de mantener - cambiar orden requiere actualizar índices");
            Console.WriteLine("  • Menos intuitivo - no es claro qué valor corresponde a cada placeholder\n");

            // Ejecutar el código problemático
            string name = "Alice";
            int age = 30;
            string message = string.Format("Name: {0}, Age: {1}", name, age);
            Console.WriteLine($"Resultado: {message}\n");
        }

        /// <summary>
        /// Demuestra la solución usando Interpolated Strings
        /// </summary>
        public static void DemonstrateInterpolatedStrings()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ PREFERIDO: Interpolated Strings");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Código mejorado:");
            Console.WriteLine("```csharp");
            Console.WriteLine("string name = \"Alice\";");
            Console.WriteLine("int age = 30;");
            Console.WriteLine("string message = $\"Name: {name}, Age: {age}\";");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  ✅ Más legible - nombres de variables directamente en la cadena");
            Console.WriteLine("  ✅ Menos propenso a errores - no hay riesgo de orden incorrecto");
            Console.WriteLine("  ✅ Más fácil de mantener - cambios automáticos");
            Console.WriteLine("  ✅ Más intuitivo - claro qué valor se está usando\n");

            // Ejecutar el código mejorado
            string name = "Alice";
            int age = 30;
            string message = $"Name: {name}, Age: {age}";
            Console.WriteLine($"Resultado: {message}\n");
        }

        /// <summary>
        /// Demuestra uso con expresiones
        /// </summary>
        public static void DemonstrateWithExpressions()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔢 Con Expresiones");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Expresiones directamente en la cadena");
            Console.WriteLine("```csharp");
            Console.WriteLine("var price = 10.50m;");
            Console.WriteLine("var quantity = 5;");
            Console.WriteLine("var message = $\"Total: ${price * quantity:F2}\";");
            Console.WriteLine("```\n");

            var price = 10.50m;
            var quantity = 5;
            var message = $"Total: ${price * quantity:F2}";
            Console.WriteLine($"Resultado: {message}\n");

            Console.WriteLine("✅ También puedes usar métodos:");
            var result = $"Sum: {CalculateSum(10, 20)}";
            Console.WriteLine($"Resultado: {result}\n");
        }

        /// <summary>
        /// Demuestra uso con formato específico
        /// </summary>
        public static void DemonstrateWithFormatting()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎨 Con Formato Específico");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Especificadores de formato");
            Console.WriteLine("```csharp");
            Console.WriteLine("var date = DateTime.Now;");
            Console.WriteLine("var message = $\"Today is {date:yyyy-MM-dd}\";");
            Console.WriteLine("var price = $\"Price: {amount:C}\"; // Formato de moneda");
            Console.WriteLine("var percentage = $\"Progress: {progress:P}\"; // Porcentaje");
            Console.WriteLine("```\n");

            var date = DateTime.Now;
            var dateMessage = $"Today is {date:yyyy-MM-dd}";
            Console.WriteLine($"Fecha: {dateMessage}");

            var amount = 1234.56m;
            var priceMessage = $"Price: {amount:C}";
            Console.WriteLine($"Precio: {priceMessage}");

            var progress = 0.75;
            var progressMessage = $"Progress: {progress:P}";
            Console.WriteLine($"Progreso: {progressMessage}\n");
        }

        /// <summary>
        /// Demuestra uso con condiciones
        /// </summary>
        public static void DemonstrateWithConditions()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔀 Con Condiciones");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Expresiones condicionales");
            Console.WriteLine("```csharp");
            Console.WriteLine("var isActive = true;");
            Console.WriteLine("var status = $\"User is {(isActive ? \"active\" : \"inactive\")}\";");
            Console.WriteLine("```\n");

            var isActive = true;
            var status = $"User is {(isActive ? "active" : "inactive")}";
            Console.WriteLine($"Estado: {status}");

            var unreadCount = 5;
            var countMessage = $"You have {unreadCount} {(unreadCount == 1 ? "message" : "messages")}";
            Console.WriteLine($"Mensajes: {countMessage}\n");
        }

        /// <summary>
        /// Demuestra uso con objetos y propiedades
        /// </summary>
        public static void DemonstrateWithObjects()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📦 Con Objetos y Propiedades");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Propiedades y métodos de objetos");
            Console.WriteLine("```csharp");
            Console.WriteLine("var user = new User { Name = \"Alice\", Email = \"alice@example.com\" };");
            Console.WriteLine("var info = $\"User: {user.Name}, Email: {user.Email}\";");
            Console.WriteLine("```\n");

            var user = new ExampleUser { Name = "Alice", Email = "alice@example.com", CreatedDate = DateTime.Now.AddDays(-30) };
            var info = $"User: {user.Name}, Email: {user.Email}, Created: {user.CreatedDate:yyyy-MM-dd}";
            Console.WriteLine($"Información: {info}\n");
        }

        /// <summary>
        /// Demuestra uso multilínea
        /// </summary>
        public static void DemonstrateMultiline()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📄 Cadenas Multilínea");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Interpolated strings multilínea con @");
            Console.WriteLine("```csharp");
            Console.WriteLine("var message = $@\"");
            Console.WriteLine("    User: {userName}");
            Console.WriteLine("    Age: {age}");
            Console.WriteLine("    Email: {email}");
            Console.WriteLine("\";");
            Console.WriteLine("```\n");

            var userName = "Alice";
            var age = 30;
            var email = "alice@example.com";
            var multilineMessage = $@"
    User: {userName}
    Age: {age}
    Email: {email}
";
            Console.WriteLine("Resultado:");
            Console.WriteLine(multilineMessage);
        }

        /// <summary>
        /// Demuestra escapado de llaves
        /// </summary>
        public static void DemonstrateEscaping()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔒 Escapado de Llaves");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Para incluir llaves literales, usa doble llave:");
            Console.WriteLine("```csharp");
            Console.WriteLine("var message = $\"Price: {{price}}\"; // Resultado: \"Price: {price}\"");
            Console.WriteLine("var message = $\"Price: {{{price}}}\"; // Resultado: \"Price: {100}\"");
            Console.WriteLine("```\n");

            var price = 100;
            var literalMessage = $"Price: {{price}}";
            Console.WriteLine($"Llaves literales: {literalMessage}");

            var mixedMessage = $"Price: {{{price}}}";
            Console.WriteLine($"Mezclado: {mixedMessage}\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Applying C# Interpolated Strings for Cleaner Formatting  ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateStringFormat();
            Console.WriteLine("\n");
            DemonstrateInterpolatedStrings();
            Console.WriteLine("\n");
            DemonstrateWithExpressions();
            Console.WriteLine("\n");
            DemonstrateWithFormatting();
            Console.WriteLine("\n");
            DemonstrateWithConditions();
            Console.WriteLine("\n");
            DemonstrateWithObjects();
            Console.WriteLine("\n");
            DemonstrateMultiline();
            Console.WriteLine("\n");
            DemonstrateEscaping();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Ventajas de Interpolated Strings:");
            Console.WriteLine("   ◾ Improved Readability - mejor legibilidad");
            Console.WriteLine("   ◾ Less Error-Prone - menos propenso a errores");
            Console.WriteLine("   ◾ Dynamic Content - contenido dinámico fácil\n");
            
            Console.WriteLine("💡 Regla General:");
            Console.WriteLine("   • Usa interpolated strings ($\"...\") en lugar de string.Format");
            Console.WriteLine("   • Disponible desde C# 6.0+");
            Console.WriteLine("   • Hace tu código más limpio e intuitivo\n");
        }

        private static int CalculateSum(int a, int b) => a + b;
    }

    // Clase de ejemplo
    public class ExampleUser
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}

