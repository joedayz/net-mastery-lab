using System.Collections.Generic;
using System.Diagnostics;

namespace NetMasteryLab.Concepts.TryGetValueAvoidDoubleLookup.Examples;

/// <summary>
/// Ejemplos que demuestran el uso de ContainsKey + indexer vs TryGetValue
/// </summary>
public class TryGetValueExamples
{
    private static readonly Dictionary<string, int> _ages = new Dictionary<string, int>
    {
        { "Alice", 30 },
        { "Bob", 24 },
        { "Charlie", 35 },
        { "Diana", 28 },
        { "Eve", 32 }
    };

    /// <summary>
    /// Demuestra el enfoque menos eficiente con ContainsKey y el indexador.
    /// </summary>
    public static void DemonstrateInefficientLookup()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ❌ Enfoque Ineficiente: ContainsKey + Indexer");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        string searchKey = "Alice";
        string missingKey = "David";

        Console.WriteLine($"Buscando la clave: '{searchKey}'");
        Console.WriteLine("Código:");
        Console.WriteLine("  if (dictionary.ContainsKey(key))");
        Console.WriteLine("  {");
        Console.WriteLine("      var value = dictionary[key];");
        Console.WriteLine("  }\n");

        var stopwatch = Stopwatch.StartNew();
        if (_ages.ContainsKey(searchKey))
        {
            int age = _ages[searchKey]; // Segunda búsqueda aquí
            Console.WriteLine($"  ✅ Edad de {searchKey}: {age}");
        }
        else
        {
            Console.WriteLine($"  ❌ La clave '{searchKey}' no fue encontrada.");
        }
        stopwatch.Stop();
        Console.WriteLine($"  ⏱️  Tiempo: {stopwatch.ElapsedTicks} ticks (DOS búsquedas)\n");

        Console.WriteLine($"Buscando la clave: '{missingKey}'");
        stopwatch.Restart();
        if (_ages.ContainsKey(missingKey))
        {
            int age = _ages[missingKey];
            Console.WriteLine($"  ✅ Edad de {missingKey}: {age}");
        }
        else
        {
            Console.WriteLine($"  ❌ La clave '{missingKey}' no fue encontrada.");
        }
        stopwatch.Stop();
        Console.WriteLine($"  ⏱️  Tiempo: {stopwatch.ElapsedTicks} ticks (una búsqueda para ContainsKey)\n");

        Console.WriteLine("⚠️  PROBLEMA: Se realizan DOS búsquedas cuando la clave existe:");
        Console.WriteLine("   1. ContainsKey() verifica la existencia");
        Console.WriteLine("   2. dictionary[key] recupera el valor\n");
    }

    /// <summary>
    /// Demuestra el enfoque más eficiente con TryGetValue.
    /// </summary>
    public static void DemonstrateEfficientLookup()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ✅ Enfoque Eficiente: TryGetValue");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        string searchKey = "Bob";
        string missingKey = "Eve";

        Console.WriteLine($"Buscando la clave: '{searchKey}'");
        Console.WriteLine("Código:");
        Console.WriteLine("  if (dictionary.TryGetValue(key, out var value))");
        Console.WriteLine("  {");
        Console.WriteLine("      // Usar value");
        Console.WriteLine("  }\n");

        var stopwatch = Stopwatch.StartNew();
        if (_ages.TryGetValue(searchKey, out int age))
        {
            Console.WriteLine($"  ✅ Edad de {searchKey}: {age}");
        }
        else
        {
            Console.WriteLine($"  ❌ La clave '{searchKey}' no fue encontrada.");
        }
        stopwatch.Stop();
        Console.WriteLine($"  ⏱️  Tiempo: {stopwatch.ElapsedTicks} ticks (UNA sola búsqueda)\n");

        Console.WriteLine($"Buscando la clave: '{missingKey}'");
        stopwatch.Restart();
        if (_ages.TryGetValue(missingKey, out age))
        {
            Console.WriteLine($"  ✅ Edad de {missingKey}: {age}");
        }
        else
        {
            Console.WriteLine($"  ❌ La clave '{missingKey}' no fue encontrada.");
        }
        stopwatch.Stop();
        Console.WriteLine($"  ⏱️  Tiempo: {stopwatch.ElapsedTicks} ticks (UNA sola búsqueda)\n");

        Console.WriteLine("✅ VENTAJA: Solo se realiza UNA búsqueda:");
        Console.WriteLine("   TryGetValue() verifica y recupera en una sola operación\n");
    }

    /// <summary>
    /// Compara el rendimiento de ambos enfoques en múltiples iteraciones.
    /// </summary>
    public static void DemonstratePerformanceComparison()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  📊 Comparación de Rendimiento");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        var keys = new[] { "Alice", "Bob", "Charlie", "David", "Eve", "Frank" };
        int iterations = 100000;

        // Método ineficiente
        var stopwatch1 = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            foreach (var key in keys)
            {
                if (_ages.ContainsKey(key))
                {
                    var value = _ages[key];
                }
            }
        }
        stopwatch1.Stop();

        // Método eficiente
        var stopwatch2 = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            foreach (var key in keys)
            {
                if (_ages.TryGetValue(key, out var value))
                {
                    // Usar value
                }
            }
        }
        stopwatch2.Stop();

        Console.WriteLine($"Ejecutando {iterations:N0} iteraciones con {keys.Length} claves cada una:\n");
        Console.WriteLine($"❌ ContainsKey + Indexer: {stopwatch1.ElapsedMilliseconds} ms");
        Console.WriteLine($"✅ TryGetValue:            {stopwatch2.ElapsedMilliseconds} ms");
        
        if (stopwatch1.ElapsedMilliseconds > stopwatch2.ElapsedMilliseconds)
        {
            var improvement = ((double)(stopwatch1.ElapsedMilliseconds - stopwatch2.ElapsedMilliseconds) / stopwatch1.ElapsedMilliseconds) * 100;
            Console.WriteLine($"\n🚀 Mejora: {improvement:F1}% más rápido con TryGetValue");
        }

        Console.WriteLine("\n💡 En aplicaciones críticas para el rendimiento, esta diferencia");
        Console.WriteLine("   puede ser significativa!\n");
    }

    /// <summary>
    /// Ejecuta todos los ejemplos para una comparación completa.
    /// </summary>
    public static void RunAllExamples()
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     TryGetValue: Evitar Doble Búsqueda en Diccionarios       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

        DemonstrateInefficientLookup();
        Console.WriteLine("\n");
        DemonstrateEfficientLookup();
        Console.WriteLine("\n");
        DemonstratePerformanceComparison();

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  RESUMEN");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        Console.WriteLine("❌ ContainsKey + Indexer:");
        Console.WriteLine("   • Realiza DOS búsquedas cuando la clave existe");
        Console.WriteLine("   • Más código y menos legible");
        Console.WriteLine("   • Puede lanzar KeyNotFoundException\n");
        
        Console.WriteLine("✅ TryGetValue:");
        Console.WriteLine("   • Realiza UNA sola búsqueda");
        Console.WriteLine("   • Código más conciso y legible");
        Console.WriteLine("   • Previene excepciones innecesarias");
        Console.WriteLine("   • Mejor rendimiento en aplicaciones críticas\n");
    }
}

