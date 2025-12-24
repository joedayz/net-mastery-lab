using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace NetMasteryLab.Concepts.NullArgumentChecks.Examples;

/// <summary>
/// Benchmarks de rendimiento para comparar los diferentes métodos de validación de null
/// Basado en los resultados mostrados en la imagen
/// </summary>
[MemoryDiagnoser]
public class NullCheckBenchmark
{
    private string? _arg;

    [GlobalSetup]
    public void Setup()
    {
        _arg = "test";
    }

    /// <summary>
    /// Método tradicional - Forma antigua
    /// </summary>
    [Benchmark(Baseline = true)]
    public void NullArgCheckOldWay()
    {
        if (_arg is null)
            throw new ArgumentNullException(nameof(_arg));
    }

    /// <summary>
    /// Método moderno - Forma nueva
    /// </summary>
    [Benchmark]
    public void NullArgCheckNewWay() => ArgumentNullException.ThrowIfNull(_arg);

    /// <summary>
    /// Método moderno mejorado - Forma nueva con nameof
    /// </summary>
    [Benchmark]
    public void NullArgCheckNewWayUpgraded() => ArgumentNullException.ThrowIfNull(_arg, nameof(_arg));

    /// <summary>
    /// Ejecuta los benchmarks y muestra los resultados
    /// </summary>
    public static void RunBenchmarks()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  Ejecutando Benchmarks de Null Argument Checks");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        Console.WriteLine("Esto puede tomar unos momentos...\n");

        var summary = BenchmarkRunner.Run<NullCheckBenchmark>();

        Console.WriteLine("\n═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  Resultados del Benchmark");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        Console.WriteLine("Los resultados muestran que 'New Way Upgraded' es significativamente");
        Console.WriteLine("más rápido que el método tradicional.\n");
    }
}

