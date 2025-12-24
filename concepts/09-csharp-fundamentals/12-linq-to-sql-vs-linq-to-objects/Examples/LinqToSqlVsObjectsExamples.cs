using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMasteryLab.Concepts.CSharpFundamentals.LinqToSqlVsObjects.Examples
{
    /// <summary>
    /// Ejemplos que demuestran LINQ to SQL vs LINQ to Objects
    /// </summary>
    public class LinqToSqlVsObjectsExamples
    {
        /// <summary>
        /// Demuestra LINQ to SQL (simulado con IQueryable)
        /// </summary>
        public static void DemonstrateLinqToSql()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔹 LINQ to SQL");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("📌 ¿Qué es LINQ to SQL?");
            Console.WriteLine("  Tecnología que permite interactuar con bases de datos");
            Console.WriteLine("  relacionales usando consultas LINQ.\n");

            Console.WriteLine("📌 Características Clave:");
            Console.WriteLine("  ✅ Requiere DataContext/DbContext");
            Console.WriteLine("  ✅ Retorna IQueryable<T>");
            Console.WriteLine("  ✅ Traduce LINQ → SQL usando Expression Trees");
            Console.WriteLine("  ✅ Se ejecuta en la base de datos (server-side)");
            Console.WriteLine("  ✅ Optimizado para grandes datasets\n");

            Console.WriteLine("📌 Ejemplo Simulado:");
            Console.WriteLine("  // Consulta LINQ que se traduce a SQL");
            Console.WriteLine("  var users = dbContext.Users");
            Console.WriteLine("      .Where(u => u.IsActive == true)");
            Console.WriteLine("      .Select(u => new { u.Name, u.Email })");
            Console.WriteLine("      .ToList();\n");

            Console.WriteLine("  SQL generado (aproximado):");
            Console.WriteLine("    SELECT Name, Email FROM Users WHERE IsActive = 1\n");
        }

        /// <summary>
        /// Demuestra LINQ to Objects
        /// </summary>
        public static void DemonstrateLinqToObjects()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔹 LINQ to Objects");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("📌 ¿Qué es LINQ to Objects?");
            Console.WriteLine("  Permite consultar colecciones en memoria como listas,");
            Console.WriteLine("  arrays, diccionarios que implementan IEnumerable<T>.\n");

            Console.WriteLine("📌 Características Clave:");
            Console.WriteLine("  ✅ No requiere proveedor LINQ intermedio");
            Console.WriteLine("  ✅ Retorna IEnumerable<T>");
            Console.WriteLine("  ✅ Se ejecuta en memoria (client-side)");
            Console.WriteLine("  ✅ No hay traducción - ejecuta directamente en C#");
            Console.WriteLine("  ✅ Ideal para pequeños datasets\n");

            Console.WriteLine("📌 Ejemplo Práctico:");
            var users = new List<User>
            {
                new User { Name = "Alice", IsActive = true, Email = "alice@example.com" },
                new User { Name = "Bob", IsActive = false, Email = "bob@example.com" },
                new User { Name = "Charlie", IsActive = true, Email = "charlie@example.com" }
            };

            // LINQ to Objects - ejecuta en memoria
            var activeUsers = users
                .Where(u => u.IsActive == true)
                .Select(u => new { u.Name, u.Email })
                .ToList();

            Console.WriteLine("  var users = new List<User> { ... };");
            Console.WriteLine("  var activeUsers = users");
            Console.WriteLine("      .Where(u => u.IsActive == true)");
            Console.WriteLine("      .Select(u => new { u.Name, u.Email })");
            Console.WriteLine("      .ToList();\n");

            Console.WriteLine("  Resultado (ejecutado en memoria):");
            foreach (var user in activeUsers)
            {
                Console.WriteLine($"    - {user.Name}: {user.Email}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra diferencias clave entre LINQ to SQL y LINQ to Objects
        /// </summary>
        public static void DemonstrateKeyDifferences()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔥 Diferencias Clave");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1️⃣ Fuente de Datos:");
            Console.WriteLine("  LINQ to SQL:    Bases de datos relacionales");
            Console.WriteLine("  LINQ to Objects: Colecciones en memoria\n");

            Console.WriteLine("2️⃣ Ejecución de Consultas:");
            Console.WriteLine("  LINQ to SQL:    En base de datos (server-side)");
            Console.WriteLine("  LINQ to Objects: En memoria (client-side)\n");

            Console.WriteLine("3️⃣ Tipo de Retorno:");
            Console.WriteLine("  LINQ to SQL:    IQueryable<T>");
            Console.WriteLine("  LINQ to Objects: IEnumerable<T>\n");

            Console.WriteLine("4️⃣ Traducción:");
            Console.WriteLine("  LINQ to SQL:    LINQ → SQL usando Expression Trees");
            Console.WriteLine("  LINQ to Objects: Sin traducción - ejecuta directamente\n");

            Console.WriteLine("5️⃣ Rendimiento:");
            Console.WriteLine("  LINQ to SQL:    Optimizado para grandes datasets");
            Console.WriteLine("  LINQ to Objects: Rápido para pequeños datasets\n");
        }

        /// <summary>
        /// Demuestra cuándo usar cada uno
        /// </summary>
        public static void DemonstrateWhenToUse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 ¿Cuándo Usar Cada Uno?");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Usa LINQ to SQL cuando:");
            Console.WriteLine("  • Necesitas trabajar con bases de datos relacionales");
            Console.WriteLine("  • Requieres ejecución eficiente para grandes datasets");
            Console.WriteLine("  • Quieres realizar operaciones CRUD en tablas");
            Console.WriteLine("  • Necesitas ejecución diferida optimizada\n");

            Console.WriteLine("✅ Usa LINQ to Objects cuando:");
            Console.WriteLine("  • Estás trabajando con colecciones en memoria");
            Console.WriteLine("  • No necesitas interacciones con base de datos");
            Console.WriteLine("  • Quieres ejecución rápida para pequeños datasets");
            Console.WriteLine("  • Necesitas filtrado/ordenamiento rápido");
            Console.WriteLine("  • Necesitas usar métodos C# personalizados\n");
        }

        /// <summary>
        /// Demuestra tabla comparativa
        /// </summary>
        public static void DemonstrateComparisonTable()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Tabla Comparativa Completa");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("| Característica              | LINQ to SQL      | LINQ to Objects |");
            Console.WriteLine("|-----------------------------|------------------|-----------------|");
            Console.WriteLine("| Fuente de Datos            | Bases de datos  | Memoria         |");
            Console.WriteLine("| Tipo de Retorno            | IQueryable<T>    | IEnumerable<T>  |");
            Console.WriteLine("| Ejecución                  | Server-side      | Client-side     |");
            Console.WriteLine("| Traducción                 | LINQ → SQL       | Sin traducción  |");
            Console.WriteLine("| Requisitos                 | DataContext      | Ninguno         |");
            Console.WriteLine("| Rendimiento (grandes)      | ✅ Optimizado    | ❌ Puede ser lento |");
            Console.WriteLine("| Rendimiento (pequeños)     | ⚠️ Overhead red  | ✅ Muy rápido   |");
            Console.WriteLine("| Flexibilidad               | Limitada a SQL   | Completa C#     |");
            Console.WriteLine("| Operaciones CRUD           | ✅ Sí            | ❌ Solo lectura  |");
            Console.WriteLine("| Ejecución Diferida         | ✅ Sí            | ✅ Sí           |\n");
        }

        /// <summary>
        /// Demuestra errores comunes
        /// </summary>
        public static void DemonstrateCommonErrors()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Errores Comunes");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ Error 1: Convertir IQueryable a IEnumerable demasiado pronto");
            Console.WriteLine("  var users = dbContext.Users.ToList() // Trae TODOS");
            Console.WriteLine("      .Where(u => u.IsActive); // Filtra en memoria");
            Console.WriteLine();
            Console.WriteLine("  ✅ Solución:");
            Console.WriteLine("  var users = dbContext.Users");
            Console.WriteLine("      .Where(u => u.IsActive) // Filtra en DB");
            Console.WriteLine("      .ToList();\n");

            Console.WriteLine("❌ Error 2: Usar métodos no traducibles con LINQ to SQL");
            Console.WriteLine("  var users = dbContext.Users");
            Console.WriteLine("      .Where(u => IsValidUser(u)); // Error");
            Console.WriteLine();
            Console.WriteLine("  ✅ Solución:");
            Console.WriteLine("  var users = dbContext.Users");
            Console.WriteLine("      .AsEnumerable() // Convertir a IEnumerable");
            Console.WriteLine("      .Where(u => IsValidUser(u)); // Ahora funciona\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║         LINQ to SQL vs LINQ to Objects                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateLinqToSql();
            Console.WriteLine("\n");
            DemonstrateLinqToObjects();
            Console.WriteLine("\n");
            DemonstrateKeyDifferences();
            Console.WriteLine("\n");
            DemonstrateComparisonTable();
            Console.WriteLine("\n");
            DemonstrateWhenToUse();
            Console.WriteLine("\n");
            DemonstrateCommonErrors();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ LINQ to SQL:");
            Console.WriteLine("   • Para bases de datos relacionales");
            Console.WriteLine("   • Retorna IQueryable<T>");
            Console.WriteLine("   • Traduce LINQ → SQL");
            Console.WriteLine("   • Ejecuta en servidor\n");
            
            Console.WriteLine("✅ LINQ to Objects:");
            Console.WriteLine("   • Para colecciones en memoria");
            Console.WriteLine("   • Retorna IEnumerable<T>");
            Console.WriteLine("   • Sin traducción");
            Console.WriteLine("   • Ejecuta en memoria\n");
            
            Console.WriteLine("🎯 Regla General:");
            Console.WriteLine("   • Usa LINQ to SQL para bases de datos");
            Console.WriteLine("   • Usa LINQ to Objects para datos en memoria\n");
        }
    }

    /// <summary>
    /// Clase de ejemplo para demostración
    /// </summary>
    public class User
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}

