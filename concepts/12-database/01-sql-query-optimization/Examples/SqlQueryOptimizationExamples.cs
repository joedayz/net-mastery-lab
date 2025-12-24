using System;

namespace NetMasteryLab.Concepts.Database.SqlQueryOptimization.Examples
{
    /// <summary>
    /// Ejemplos que demuestran optimización de consultas SQL
    /// </summary>
    public class SqlQueryOptimizationExamples
    {
        /// <summary>
        /// Demuestra por qué optimizar consultas SQL
        /// </summary>
        public static void DemonstrateWhyOptimize()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🚀 ¿Por Qué Optimizar Consultas SQL?");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Velocidad:");
            Console.WriteLine("   • Recuperación de datos más rápida");
            Console.WriteLine("   • Reducción del tiempo de respuesta");
            Console.WriteLine("   • Mejor experiencia de usuario\n");

            Console.WriteLine("✅ Eficiencia:");
            Console.WriteLine("   • Minimiza uso de CPU, memoria y disco");
            Console.WriteLine("   • Menor consumo de recursos del servidor");
            Console.WriteLine("   • Mejor aprovechamiento de infraestructura\n");

            Console.WriteLine("✅ Escalabilidad:");
            Console.WriteLine("   • Maneja cargas de trabajo más grandes");
            Console.WriteLine("   • Soporta más usuarios concurrentes");
            Console.WriteLine("   • Crecimiento sostenible\n");

            Console.WriteLine("✅ Ahorro de Costos:");
            Console.WriteLine("   • Reduce gastos de infraestructura");
            Console.WriteLine("   • Menor necesidad de hardware adicional");
            Console.WriteLine("   • Optimización de recursos cloud\n");
        }

        /// <summary>
        /// Demuestra factores clave que afectan el rendimiento
        /// </summary>
        public static void DemonstrateKeyFactors()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔹 Factores Clave que Afectan el Rendimiento");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1️⃣ Índices:");
            Console.WriteLine("   ✅ Mejoran velocidad de búsqueda");
            Console.WriteLine("   ⚠️ Pueden ralentizar escrituras (INSERT/UPDATE/DELETE)");
            Console.WriteLine("   💡 Usar en columnas frecuentemente consultadas\n");

            Console.WriteLine("2️⃣ Joins & Subqueries:");
            Console.WriteLine("   ✅ JOINs bien estructurados son eficientes");
            Console.WriteLine("   ❌ Subconsultas correlacionadas pueden ser lentas");
            Console.WriteLine("   💡 Preferir JOINs sobre subconsultas cuando sea posible\n");

            Console.WriteLine("3️⃣ Query Execution Plan:");
            Console.WriteLine("   ✅ Determina la forma más eficiente de ejecutar");
            Console.WriteLine("   💡 Analizar con EXPLAIN o SET SHOWPLAN");
            Console.WriteLine("   💡 Buscar Table Scans y operaciones costosas\n");

            Console.WriteLine("4️⃣ Data Types:");
            Console.WriteLine("   ✅ Tipos correctos mejoran almacenamiento y velocidad");
            Console.WriteLine("   ❌ VARCHAR para números es ineficiente");
            Console.WriteLine("   💡 Usar INT, DECIMAL, DATETIME apropiadamente\n");

            Console.WriteLine("5️⃣ Hardware Resources:");
            Console.WriteLine("   ✅ CPU, RAM y velocidad de disco impactan rendimiento");
            Console.WriteLine("   💡 SSD es mucho más rápido que HDD");
            Console.WriteLine("   💡 Más RAM = menos I/O de disco\n");
        }

        /// <summary>
        /// Demuestra mejores prácticas de optimización
        /// </summary>
        public static void DemonstrateBestPractices()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔹 Mejores Prácticas de Optimización SQL");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1️⃣ Indexing para Búsquedas Más Rápidas:");
            Console.WriteLine("   ✅ Usar índices en columnas frecuentemente consultadas");
            Console.WriteLine("   ✅ Crear índices compuestos para consultas complejas");
            Console.WriteLine("   ❌ Evitar demasiados índices (ralentizan escrituras)\n");

            Console.WriteLine("2️⃣ Obtener Solo Datos Requeridos:");
            Console.WriteLine("   ❌ SELECT * trae todas las columnas");
            Console.WriteLine("   ✅ SELECT columnas específicas");
            Console.WriteLine("   ✅ Usar paginación para grandes datasets\n");

            Console.WriteLine("3️⃣ Optimizar Joins:");
            Console.WriteLine("   ✅ Usar columnas indexadas en JOINs");
            Console.WriteLine("   ✅ Reemplazar subconsultas con JOINs cuando sea posible");
            Console.WriteLine("   ✅ Usar INNER JOIN cuando solo necesites coincidencias\n");

            Console.WriteLine("4️⃣ Usar Filtrado Eficiente:");
            Console.WriteLine("   ✅ WHERE filtra antes de agrupar");
            Console.WriteLine("   ❌ HAVING filtra después de agrupar (menos eficiente)");
            Console.WriteLine("   ✅ EXISTS en lugar de IN para mejor rendimiento\n");

            Console.WriteLine("5️⃣ Minimizar Ordenamiento y Agrupación:");
            Console.WriteLine("   ✅ Ordenar solo cuando sea necesario");
            Console.WriteLine("   ✅ Usar columnas indexadas para ordenar");
            Console.WriteLine("   ❌ Evitar ordenar sin necesidad\n");

            Console.WriteLine("6️⃣ Elegir Tipos de Datos Correctos:");
            Console.WriteLine("   ✅ INT en lugar de VARCHAR para IDs");
            Console.WriteLine("   ✅ DECIMAL para valores monetarios");
            Console.WriteLine("   ✅ DATETIME en lugar de VARCHAR para fechas\n");

            Console.WriteLine("7️⃣ Analizar Planes de Ejecución:");
            Console.WriteLine("   ✅ Usar EXPLAIN o SET SHOWPLAN");
            Console.WriteLine("   ✅ Buscar Table Scans (malo)");
            Console.WriteLine("   ✅ Buscar Index Seeks (bueno)\n");

            Console.WriteLine("8️⃣ Mantener y Optimizar Almacenamiento:");
            Console.WriteLine("   ✅ Reconstruir índices periódicamente");
            Console.WriteLine("   ✅ Actualizar estadísticas");
            Console.WriteLine("   ✅ Archivar datos antiguos\n");
        }

        /// <summary>
        /// Demuestra ejemplos de consultas optimizadas
        /// </summary>
        public static void DemonstrateOptimizedQueries()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Ejemplos de Consultas Optimizadas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ MAL: Consulta no optimizada");
            Console.WriteLine("```sql");
            Console.WriteLine("SELECT * ");
            Console.WriteLine("FROM Orders o");
            Console.WriteLine("INNER JOIN Users u ON u.Email = o.CustomerEmail");
            Console.WriteLine("WHERE o.OrderDate > '2024-01-01'");
            Console.WriteLine("ORDER BY o.OrderDate DESC;");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: Consulta optimizada");
            Console.WriteLine("```sql");
            Console.WriteLine("SELECT ");
            Console.WriteLine("    o.OrderId,");
            Console.WriteLine("    o.OrderDate,");
            Console.WriteLine("    o.Total,");
            Console.WriteLine("    u.Name AS CustomerName,");
            Console.WriteLine("    u.Email");
            Console.WriteLine("FROM Orders o");
            Console.WriteLine("INNER JOIN Users u ON u.Id = o.CustomerId  -- JOIN en ID indexado");
            Console.WriteLine("WHERE o.OrderDate >= '2024-01-01'  -- Filtro con índice");
            Console.WriteLine("    AND o.Status = 'Completed'");
            Console.WriteLine("ORDER BY o.OrderDate DESC  -- Ordenar por columna indexada");
            Console.WriteLine("OFFSET 0 ROWS FETCH NEXT 50 ROWS ONLY;  -- Paginación");
            Console.WriteLine("```\n");

            Console.WriteLine("Mejoras aplicadas:");
            Console.WriteLine("  • SELECT específico en lugar de SELECT *");
            Console.WriteLine("  • JOIN en ID indexado en lugar de Email");
            Console.WriteLine("  • Filtro con índice en OrderDate");
            Console.WriteLine("  • Paginación para limitar resultados\n");
        }

        /// <summary>
        /// Demuestra comparación de técnicas
        /// </summary>
        public static void DemonstrateComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Comparación: Antes vs Después");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("SELECT:");
            Console.WriteLine("  ❌ SELECT * → Trae todas las columnas");
            Console.WriteLine("  ✅ SELECT columnas específicas → Solo lo necesario\n");

            Console.WriteLine("WHERE:");
            Console.WriteLine("  ❌ Sin índices → Table Scan (lento)");
            Console.WriteLine("  ✅ Con índices → Index Seek (rápido)\n");

            Console.WriteLine("JOINs:");
            Console.WriteLine("  ❌ Subconsultas correlacionadas → Múltiples ejecuciones");
            Console.WriteLine("  ✅ JOINs eficientes → Una sola ejecución\n");

            Console.WriteLine("Paginación:");
            Console.WriteLine("  ❌ Sin paginación → Carga todos los registros");
            Console.WriteLine("  ✅ Con paginación → Solo lo necesario\n");

            Console.WriteLine("Filtrado:");
            Console.WriteLine("  ❌ HAVING → Filtra después de agrupar");
            Console.WriteLine("  ✅ WHERE → Filtra antes de agrupar\n");

            Console.WriteLine("Tipos de Datos:");
            Console.WriteLine("  ❌ VARCHAR para números → Comparaciones lentas");
            Console.WriteLine("  ✅ INT, DECIMAL → Comparaciones rápidas\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Optimizando Consultas SQL para Máximo Rendimiento       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateWhyOptimize();
            Console.WriteLine("\n");
            DemonstrateKeyFactors();
            Console.WriteLine("\n");
            DemonstrateBestPractices();
            Console.WriteLine("\n");
            DemonstrateOptimizedQueries();
            Console.WriteLine("\n");
            DemonstrateComparison();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Por Qué Optimizar:");
            Console.WriteLine("   • Velocidad: Consultas más rápidas");
            Console.WriteLine("   • Eficiencia: Menor uso de recursos");
            Console.WriteLine("   • Escalabilidad: Manejar más carga");
            Console.WriteLine("   • Ahorro de Costos: Menor infraestructura\n");
            
            Console.WriteLine("✅ Factores Clave:");
            Console.WriteLine("   1. Índices - Mejoran búsquedas");
            Console.WriteLine("   2. Joins & Subqueries - Estructura importante");
            Console.WriteLine("   3. Query Execution Plan - Analizar regularmente");
            Console.WriteLine("   4. Data Types - Tipos correctos");
            Console.WriteLine("   5. Hardware Resources - CPU, RAM, disco\n");
            
            Console.WriteLine("✅ Mejores Prácticas:");
            Console.WriteLine("   • Usar índices en columnas frecuentemente consultadas");
            Console.WriteLine("   • SELECT solo columnas necesarias");
            Console.WriteLine("   • Usar paginación para grandes datasets");
            Console.WriteLine("   • Optimizar JOINs");
            Console.WriteLine("   • Usar WHERE en lugar de HAVING");
            Console.WriteLine("   • Elegir tipos de datos correctos");
            Console.WriteLine("   • Analizar planes de ejecución");
            Console.WriteLine("   • Mantener índices y estadísticas\n");
            
            Console.WriteLine("💡 Impacto Típico:");
            Console.WriteLine("   • Velocidad: 10x - 100x más rápido");
            Console.WriteLine("   • Memoria: 50-80% reducción");
            Console.WriteLine("   • Escalabilidad: 10x más datos");
            Console.WriteLine("   • Costo: 30-50% reducción\n");
        }
    }
}

