using System.Security;
using System.Runtime.InteropServices;

namespace NetMasteryLab.Concepts.Security.SecureStringExamples.Examples
{
    /// <summary>
    /// Ejemplos que demuestran cómo usar SecureString para proteger datos sensibles
    /// </summary>
    public class SecureStringExamples
    {
        /// <summary>
        /// Demuestra el problema de usar strings normales para datos sensibles
        /// </summary>
        public static void DemonstrateStringProblem()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ❌ PROBLEMA: Strings Normales (Inseguro)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Código problemático:");
            Console.WriteLine("```csharp");
            Console.WriteLine("string password = \"P@ssword!\";");
            Console.WriteLine("// El password puede persistir en memoria y ser accesible desde memory dumps");
            Console.WriteLine("```\n");

            Console.WriteLine("Problemas:");
            Console.WriteLine("  • Memory Dumps - Los strings pueden ser leídos desde volcados de memoria");
            Console.WriteLine("  • Garbage Collection - Los strings pueden permanecer en memoria");
            Console.WriteLine("  • String Interning - Los strings pueden ser compartidos");
            Console.WriteLine("  • Logging - Los strings pueden aparecer en logs o excepciones\n");

            // Ejemplo de string normal (solo para demostración)
            string password = "P@ssword!";
            Console.WriteLine($"⚠️  String normal almacenado: {password}");
            Console.WriteLine("   Este string puede persistir en memoria y ser accesible desde memory dumps\n");
        }

        /// <summary>
        /// Demuestra cómo crear un SecureString básico
        /// </summary>
        public static void DemonstrateBasicSecureString()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ SOLUCIÓN: SecureString Básico");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Código seguro:");
            Console.WriteLine("```csharp");
            Console.WriteLine("using System.Security;");
            Console.WriteLine("");
            Console.WriteLine("var securePassword = new SecureString();");
            Console.WriteLine("foreach (char c in \"P@ssword!\")");
            Console.WriteLine("{");
            Console.WriteLine("    securePassword.AppendChar(c);");
            Console.WriteLine("}");
            Console.WriteLine("securePassword.MakeReadOnly();");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  🔹 Encrypts sensitive data in memory");
            Console.WriteLine("  🔹 Automatically clears the value when no longer needed");
            Console.WriteLine("  🔹 Prevents sensitive data from being easily retrieved via memory dumps\n");

            var securePassword = new SecureString();
            foreach (char c in "P@ssword!")
            {
                securePassword.AppendChar(c);
            }
            securePassword.MakeReadOnly();

            Console.WriteLine($"✅ SecureString creado con {securePassword.Length} caracteres");
            Console.WriteLine("   Los datos están encriptados en memoria y protegidos\n");

            // Limpiar
            securePassword.Dispose();
        }

        /// <summary>
        /// Demuestra cómo usar SecureString con using statement
        /// </summary>
        public static void DemonstrateSecureStringWithUsing()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔒 SecureString con Using Statement");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Usar using para limpieza automática");
            Console.WriteLine("```csharp");
            Console.WriteLine("using (var securePassword = new SecureString())");
            Console.WriteLine("{");
            Console.WriteLine("    foreach (char c in password)");
            Console.WriteLine("    {");
            Console.WriteLine("        securePassword.AppendChar(c);");
            Console.WriteLine("    }");
            Console.WriteLine("    securePassword.MakeReadOnly();");
            Console.WriteLine("    // Usar securePassword aquí");
            Console.WriteLine("}");
            Console.WriteLine("// securePassword se limpia automáticamente al salir del bloque using");
            Console.WriteLine("```\n");

            using (var securePassword = new SecureString())
            {
                foreach (char c in "SecurePass123!")
                {
                    securePassword.AppendChar(c);
                }
                securePassword.MakeReadOnly();

                Console.WriteLine($"✅ SecureString creado dentro del bloque using");
                Console.WriteLine($"   Longitud: {securePassword.Length} caracteres");
            }

            Console.WriteLine("✅ SecureString limpiado automáticamente al salir del bloque using\n");
        }

        /// <summary>
        /// Demuestra cómo crear SecureString desde entrada del usuario
        /// </summary>
        public static void DemonstrateSecureStringFromInput()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⌨️  SecureString desde Entrada del Usuario");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Leer password de forma segura desde consola");
            Console.WriteLine("```csharp");
            Console.WriteLine("Console.Write(\"Enter password: \");");
            Console.WriteLine("var securePassword = new SecureString();");
            Console.WriteLine("ConsoleKeyInfo key;");
            Console.WriteLine("do");
            Console.WriteLine("{");
            Console.WriteLine("    key = Console.ReadKey(true);");
            Console.WriteLine("    if (key.Key != ConsoleKey.Enter)");
            Console.WriteLine("    {");
            Console.WriteLine("        securePassword.AppendChar(key.KeyChar);");
            Console.WriteLine("        Console.Write(\"*\");");
            Console.WriteLine("    }");
            Console.WriteLine("} while (key.Key != ConsoleKey.Enter);");
            Console.WriteLine("securePassword.MakeReadOnly();");
            Console.WriteLine("```\n");

            Console.WriteLine("💡 Nota: Este ejemplo muestra el concepto. En producción, usa bibliotecas especializadas.\n");
        }

        /// <summary>
        /// Demuestra cómo convertir SecureString a String (cuando sea necesario)
        /// </summary>
        public static void DemonstrateSecureStringToString()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️  Conversión de SecureString a String");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("⚠️  CUIDADO: Convertir a string anula los beneficios de seguridad");
            Console.WriteLine("```csharp");
            Console.WriteLine("public static string SecureStringToString(SecureString secureString)");
            Console.WriteLine("{");
            Console.WriteLine("    IntPtr ptr = IntPtr.Zero;");
            Console.WriteLine("    try");
            Console.WriteLine("    {");
            Console.WriteLine("        ptr = Marshal.SecureStringToBSTR(secureString);");
            Console.WriteLine("        return Marshal.PtrToStringBSTR(ptr);");
            Console.WriteLine("    }");
            Console.WriteLine("    finally");
            Console.WriteLine("    {");
            Console.WriteLine("        if (ptr != IntPtr.Zero)");
            Console.WriteLine("        {");
            Console.WriteLine("            Marshal.ZeroFreeBSTR(ptr); // Limpiar memoria");
            Console.WriteLine("        }");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Siempre limpiar la memoria después de convertir\n");
        }

        /// <summary>
        /// Demuestra mejores prácticas
        /// </summary>
        public static void DemonstrateBestPractices()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Mejores Prácticas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Siempre hacer readonly después de construir:");
            Console.WriteLine("   ✅ securePassword.MakeReadOnly();\n");

            Console.WriteLine("2. Usar using para limpieza automática:");
            Console.WriteLine("   ✅ using (var securePassword = new SecureString()) { ... }\n");

            Console.WriteLine("3. Evitar convertir a string cuando sea posible:");
            Console.WriteLine("   ⚠️  Convertir anula los beneficios de seguridad\n");

            Console.WriteLine("4. Limpiar memoria después de convertir:");
            Console.WriteLine("   ✅ Marshal.ZeroFreeBSTR(ptr);\n");

            Console.WriteLine("5. Considerar limitaciones en .NET Core/.NET 5+:");
            Console.WriteLine("   ⚠️  En Linux/macOS la protección es limitada\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Keep Your Data Safe with SecureString in C#               ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateStringProblem();
            Console.WriteLine("\n");
            DemonstrateBasicSecureString();
            Console.WriteLine("\n");
            DemonstrateSecureStringWithUsing();
            Console.WriteLine("\n");
            DemonstrateSecureStringFromInput();
            Console.WriteLine("\n");
            DemonstrateSecureStringToString();
            Console.WriteLine("\n");
            DemonstrateBestPractices();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Ventajas de SecureString:");
            Console.WriteLine("   🔹 Encrypts sensitive data in memory");
            Console.WriteLine("   🔹 Automatically clears the value when no longer needed");
            Console.WriteLine("   🔹 Prevents sensitive data from being easily retrieved via memory dumps\n");
            
            Console.WriteLine("💡 Regla General:");
            Console.WriteLine("   • Usa SecureString para contraseñas y datos sensibles");
            Console.WriteLine("   • Siempre llama MakeReadOnly() después de construir");
            Console.WriteLine("   • Usa using para limpieza automática");
            Console.WriteLine("   • Evita convertir a string cuando sea posible\n");
        }

        /// <summary>
        /// Convierte SecureString a String (solo cuando sea absolutamente necesario)
        /// </summary>
        public static string SecureStringToString(SecureString secureString)
        {
            if (secureString == null)
                return string.Empty;

            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.SecureStringToBSTR(secureString);
                return Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(ptr); // Limpiar memoria
                }
            }
        }
    }
}

