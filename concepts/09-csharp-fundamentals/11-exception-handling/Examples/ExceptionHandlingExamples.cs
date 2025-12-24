using System;
using System.Collections.Generic;
using System.IO;

namespace NetMasteryLab.Concepts.CSharpFundamentals.ExceptionHandling.Examples
{
    /// <summary>
    /// Ejemplos que demuestran el Manejo de Excepciones en C#
    /// </summary>
    public class ExceptionHandlingExamples
    {
        /// <summary>
        /// Demuestra bloques try-catch básicos
        /// </summary>
        public static void DemonstrateTryCatch()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Bloques try-catch");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // Ejemplo 1: Capturar excepción específica
            Console.WriteLine("📌 Ejemplo 1: Capturar excepción específica");
            try
            {
                int result = int.Parse("abc"); // FormatException
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"  ✅ FormatException capturada: {ex.Message}\n");
            }

            // Ejemplo 2: Múltiples catch blocks
            Console.WriteLine("📌 Ejemplo 2: Múltiples catch blocks");
            try
            {
                int[] numbers = { 1, 2, 3 };
                int value = numbers[10]; // IndexOutOfRangeException
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"  ✅ IndexOutOfRangeException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  ✅ Exception general: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Demuestra bloque finally
        /// </summary>
        public static void DemonstrateFinally()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🧹 Bloque finally");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            StreamReader? reader = null;
            try
            {
                Console.WriteLine("  Intentando abrir archivo...");
                reader = new StreamReader("nonexistent.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("  ✅ Archivo no encontrado - catch ejecutado");
            }
            finally
            {
                Console.WriteLine("  ✅ Bloque finally SIEMPRE se ejecuta");
                reader?.Dispose();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra excepciones comunes del sistema
        /// </summary>
        public static void DemonstrateCommonExceptions()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Excepciones Comunes del Sistema (SystemException)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // ArgumentNullException
            Console.WriteLine("📌 ArgumentNullException:");
            Console.WriteLine("  Ocurre cuando un argumento es null");
            try
            {
                string? nullValue = null;
                ArgumentNullException.ThrowIfNull(nullValue, nameof(DemonstrateCommonExceptions));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"  ✅ {ex.GetType().Name}: {ex.Message}\n");
            }

            // ArgumentException
            Console.WriteLine("📌 ArgumentException:");
            Console.WriteLine("  Ocurre cuando un argumento es inválido");
            try
            {
                if (true) // Simulando condición inválida
                {
                    throw new ArgumentException("Argumento inválido", nameof(DemonstrateCommonExceptions));
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"  ✅ {ex.GetType().Name}: {ex.Message}\n");
            }

            // InvalidOperationException
            Console.WriteLine("📌 InvalidOperationException:");
            Console.WriteLine("  Se lanza cuando una operación no es válida en el estado actual");
            try
            {
                throw new InvalidOperationException("Operación inválida en el estado actual");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"  ✅ {ex.GetType().Name}: {ex.Message}\n");
            }

            // NullReferenceException
            Console.WriteLine("📌 NullReferenceException:");
            Console.WriteLine("  Ocurre cuando intentas acceder a un objeto null");
            try
            {
                string? text = null;
                int length = text!.Length; // NullReferenceException - intentionally null for demonstration
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"  ✅ {ex.GetType().Name}: {ex.Message}");
                Console.WriteLine("  💡 Solución: Verificar null antes de acceder o usar ?.\n");
            }

            // UriFormatException
            Console.WriteLine("📌 UriFormatException:");
            Console.WriteLine("  Ocurre cuando un URI no está en el formato correcto");
            try
            {
                var uri = new Uri("invalid-uri-format");
            }
            catch (UriFormatException ex)
            {
                Console.WriteLine($"  ✅ {ex.GetType().Name}: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Demuestra la jerarquía de excepciones
        /// </summary>
        public static void DemonstrateExceptionHierarchy()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Jerarquía de Excepciones");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Exception (base - clase raíz)");
            Console.WriteLine("├── SystemException (Excepciones del Sistema)");
            Console.WriteLine("│   ├── NullReferenceException");
            Console.WriteLine("│   ├── InvalidOperationException");
            Console.WriteLine("│   ├── OutOfMemoryException");
            Console.WriteLine("│   ├── TimeoutException");
            Console.WriteLine("│   ├── UriFormatException");
            Console.WriteLine("│   ├── ArgumentException");
            Console.WriteLine("│   │   ├── ArgumentNullException");
            Console.WriteLine("│   │   └── ArgumentOutOfRangeException");
            Console.WriteLine("│   └── ... (más excepciones del sistema)");
            Console.WriteLine("├── ApplicationException (Legacy - no usar)");
            Console.WriteLine("└── Custom Exceptions (Heredar de Exception)\n");

            Console.WriteLine("🔹 SystemException:");
            Console.WriteLine("  • Excepciones integradas del sistema");
            Console.WriteLine("  • Errores de tiempo de ejecución");
            Console.WriteLine("  • Problemas a nivel del sistema\n");

            Console.WriteLine("🔹 ApplicationException:");
            Console.WriteLine("  • Diseñado originalmente para excepciones personalizadas");
            Console.WriteLine("  • ❌ NO RECOMENDADO: Microsoft recomienda heredar de Exception");
            Console.WriteLine("  • Legacy - no usar en código nuevo\n");

            Console.WriteLine("🔹 Custom Exceptions:");
            Console.WriteLine("  • ✅ RECOMENDADO: Heredar directamente de Exception");
            Console.WriteLine("  • Permite definir errores específicos del dominio");
            Console.WriteLine("  • Proporciona contexto y significado\n");
        }

        /// <summary>
        /// Demuestra excepciones personalizadas
        /// </summary>
        public static void DemonstrateCustomExceptions()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎨 Excepciones Personalizadas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            try
            {
                var account = new BankAccount(100);
                account.Withdraw(200); // Lanza InsufficientFundsException
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"  ✅ Excepción personalizada capturada:");
                Console.WriteLine($"     Mensaje: {ex.Message}");
                Console.WriteLine($"     Balance: {ex.Balance}");
                Console.WriteLine($"     Monto solicitado: {ex.RequestedAmount}\n");
            }
        }

        /// <summary>
        /// Demuestra lanzar excepciones
        /// </summary>
        public static void DemonstrateThrowingExceptions()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🚨 Lanzar Excepciones");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // Lanzar excepción con mensaje descriptivo
            Console.WriteLine("📌 Lanzar excepción con mensaje descriptivo:");
            try
            {
                ValidateAge(-5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"  ✅ {ex.GetType().Name}: {ex.Message}\n");
            }

            // Re-lanzar excepción preservando stack trace
            Console.WriteLine("📌 Re-lanzar excepción (preservar stack trace):");
            try
            {
                try
                {
                    int.Parse("abc");
                }
                catch (FormatException)
                {
                    Console.WriteLine("  Capturada, re-lanzando...");
                    throw; // Preserva stack trace
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"  ✅ Re-lanzada: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Demuestra manejo de archivos con excepciones
        /// </summary>
        public static void DemonstrateFileHandling()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📂 Manejo de Archivos con Excepciones");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            string filePath = "nonexistent.txt";
            
            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine($"  Contenido: {content}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"  ✅ Archivo '{filePath}' no encontrado");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"  ✅ Acceso denegado al archivo '{filePath}'");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"  ✅ Error de E/S: {ex.Message}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra using statement para manejo automático de recursos
        /// </summary>
        public static void DemonstrateUsingStatement()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Using Statement (Dispose Automático)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // Using statement tradicional
            Console.WriteLine("📌 Using statement tradicional:");
            using (var writer = new StringWriter())
            {
                writer.Write("Hello");
                Console.WriteLine($"  ✅ Escrito en writer, se dispose automáticamente");
            }
            Console.WriteLine("  ✅ Writer ya fue disposed\n");

            // Using declaration (C# 8.0+)
            Console.WriteLine("📌 Using declaration (C# 8.0+):");
            using var reader = new StringReader("Hello");
            string? line = reader.ReadLine();
            Console.WriteLine($"  ✅ Leído: {line}");
            Console.WriteLine("  ✅ Reader se dispose automáticamente al final del scope\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              Manejo de Excepciones en C#                      ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateTryCatch();
            Console.WriteLine("\n");
            DemonstrateFinally();
            Console.WriteLine("\n");
            DemonstrateExceptionHierarchy();
            Console.WriteLine("\n");
            DemonstrateCommonExceptions();
            Console.WriteLine("\n");
            DemonstrateCustomExceptions();
            Console.WriteLine("\n");
            DemonstrateThrowingExceptions();
            Console.WriteLine("\n");
            DemonstrateFileHandling();
            Console.WriteLine("\n");
            DemonstrateUsingStatement();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Jerarquía de Excepciones:");
            Console.WriteLine("   • Exception (base)");
            Console.WriteLine("   • SystemException: Excepciones del sistema");
            Console.WriteLine("   • ApplicationException: Legacy (no usar)");
            Console.WriteLine("   • Custom Exceptions: Heredar de Exception\n");
            
            Console.WriteLine("✅ SystemException (Excepciones Integradas):");
            Console.WriteLine("   • NullReferenceException: Acceso a objeto null");
            Console.WriteLine("   • InvalidOperationException: Operación inválida");
            Console.WriteLine("   • OutOfMemoryException: Memoria insuficiente");
            Console.WriteLine("   • TimeoutException: Operación excedió tiempo");
            Console.WriteLine("   • UriFormatException: URI inválido\n");
            
            Console.WriteLine("✅ Bloques try-catch-finally:");
            Console.WriteLine("   • Capturar excepciones específicas primero");
            Console.WriteLine("   • Usar catch general al final");
            Console.WriteLine("   • Proporcionar mensajes descriptivos\n");
            
            Console.WriteLine("✅ Bloque finally:");
            Console.WriteLine("   • Siempre se ejecuta");
            Console.WriteLine("   • Ideal para limpieza de recursos");
            Console.WriteLine("   • Usar using statement cuando sea posible\n");
            
            Console.WriteLine("✅ Excepciones Personalizadas:");
            Console.WriteLine("   • Heredar de Exception (no ApplicationException)");
            Console.WriteLine("   • Proporcionar contexto útil en mensajes");
            Console.WriteLine("   • Incluir propiedades adicionales cuando sea útil\n");
            
            Console.WriteLine("✅ Mejores Prácticas:");
            Console.WriteLine("   • Usar try-catch-finally para manejo elegante");
            Console.WriteLine("   • Registrar errores siempre para debugging");
            Console.WriteLine("   • Lanzar excepciones específicas (evitar genéricas)");
            Console.WriteLine("   • No suprimir excepciones - usar mensajes significativos");
            Console.WriteLine("   • No capturar excepciones que no puedes manejar\n");
        }

        // Métodos auxiliares
        private static void ValidateAge(int age)
        {
            if (age < 0)
            {
                throw new ArgumentException("La edad no puede ser negativa", nameof(age));
            }
        }
    }

    /// <summary>
    /// Excepción personalizada para fondos insuficientes
    /// </summary>
    public class InsufficientFundsException : Exception
    {
        public decimal Balance { get; }
        public decimal RequestedAmount { get; }

        public InsufficientFundsException(decimal balance, decimal requestedAmount)
            : base($"Fondos insuficientes. Balance: {balance}, Solicitado: {requestedAmount}")
        {
            Balance = balance;
            RequestedAmount = requestedAmount;
        }
    }

    /// <summary>
    /// Clase de ejemplo para demostrar excepciones personalizadas
    /// </summary>
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientFundsException(Balance, amount);
            }
            Balance -= amount;
        }
    }
}

