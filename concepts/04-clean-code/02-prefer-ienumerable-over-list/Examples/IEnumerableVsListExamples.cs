using System.Diagnostics;

namespace NetMasteryLab.Concepts.CleanCode.PreferIEnumerableOverList.Examples;

/// <summary>
/// Ejemplos que demuestran por qué preferir IEnumerable<T> sobre List<T> para tipos de retorno
/// </summary>
public class IEnumerableVsListExamples
{
    private static readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "Alice", IsActive = true },
        new User { Id = 2, Name = "Bob", IsActive = false },
        new User { Id = 3, Name = "Charlie", IsActive = true },
        new User { Id = 4, Name = "Diana", IsActive = true },
        new User { Id = 5, Name = "Eve", IsActive = false }
    };

    /// <summary>
    /// Demuestra el problema de devolver List<T>
    /// </summary>
    public static void DemonstrateListReturn()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ❌ MALA PRÁCTICA: Devolver List<T>");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código problemático:");
        Console.WriteLine("```csharp");
        Console.WriteLine("public List<User> GetActiveUsers()");
        Console.WriteLine("{");
        Console.WriteLine("    return _users.Where(u => u.IsActive).ToList();");
        Console.WriteLine("}");
        Console.WriteLine("```\n");

        Console.WriteLine("Problemas:");
        Console.WriteLine("  • Menos flexible - acopla el código a List<T>");
        Console.WriteLine("  • Expone detalles de implementación");
        Console.WriteLine("  • Ejecución inmediata - fuerza ToList()");
        Console.WriteLine("  • Menos eficiente - ejecuta operaciones innecesarias\n");

        var stopwatch = Stopwatch.StartNew();
        var users = GetActiveUsersList(); // Ejecuta ToList() aquí
        stopwatch.Stop();

        Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedTicks} ticks");
        Console.WriteLine($"Usuarios obtenidos: {users.Count}");
        Console.WriteLine($"Tipo devuelto: {users.GetType().Name}\n");
    }

    /// <summary>
    /// Demuestra la solución usando IEnumerable<T>
    /// </summary>
    public static void DemonstrateIEnumerableReturn()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ✅ BUENA PRÁCTICA: Devolver IEnumerable<T>");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código mejorado:");
        Console.WriteLine("```csharp");
        Console.WriteLine("public IEnumerable<User> GetActiveUsers()");
        Console.WriteLine("{");
        Console.WriteLine("    return _users.Where(u => u.IsActive);");
        Console.WriteLine("}");
        Console.WriteLine("```\n");

        Console.WriteLine("Ventajas:");
        Console.WriteLine("  ✅ Más flexible - puedes cambiar la implementación");
        Console.WriteLine("  ✅ Mejor encapsulación - oculta detalles de implementación");
        Console.WriteLine("  ✅ Ejecución diferida - se ejecuta cuando se itera");
        Console.WriteLine("  ✅ Más eficiente - evita operaciones innecesarias\n");

        var stopwatch = Stopwatch.StartNew();
        var users = GetActiveUsersIEnumerable(); // No ejecuta nada aquí
        stopwatch.Stop();

        Console.WriteLine($"Tiempo hasta obtener enumerable: {stopwatch.ElapsedTicks} ticks (casi instantáneo)");
        
        stopwatch.Restart();
        var firstUser = users.First(); // Ejecuta aquí
        stopwatch.Stop();

        Console.WriteLine($"Tiempo para obtener primer usuario: {stopwatch.ElapsedTicks} ticks");
        Console.WriteLine($"Primer usuario: {firstUser.Name}");
        Console.WriteLine($"Tipo devuelto: {users.GetType().Name}\n");
    }

    /// <summary>
    /// Demuestra la flexibilidad de cambiar la implementación
    /// </summary>
    public static void DemonstrateFlexibility()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🔄 Flexibilidad: Cambiar Implementación Sin Afectar Consumidores");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Con IEnumerable<T>, puedes cambiar la implementación:");
        Console.WriteLine("  • De lista en memoria a base de datos");
        Console.WriteLine("  • De array a HashSet");
        Console.WriteLine("  • De cualquier colección a otra");
        Console.WriteLine("  • Sin cambiar la firma del método\n");

        // Diferentes implementaciones con la misma firma
        var users1 = GetUsersImplementation1();
        var users2 = GetUsersImplementation2();
        var users3 = GetUsersImplementation3();

        Console.WriteLine("Implementación 1 (List):");
        Console.WriteLine($"  Tipo: {users1.GetType().Name}");
        Console.WriteLine($"  Count: {users1.Count()}\n");

        Console.WriteLine("Implementación 2 (Array):");
        Console.WriteLine($"  Tipo: {users2.GetType().Name}");
        Console.WriteLine($"  Count: {users2.Count()}\n");

        Console.WriteLine("Implementación 3 (HashSet):");
        Console.WriteLine($"  Tipo: {users3.GetType().Name}");
        Console.WriteLine($"  Count: {users3.Count()}\n");

        Console.WriteLine("✅ Todas tienen la misma firma: IEnumerable<User>");
        Console.WriteLine("✅ Los consumidores no necesitan cambiar su código\n");
    }

    /// <summary>
    /// Demuestra la ejecución diferida
    /// </summary>
    public static void DemonstrateDeferredExecution()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ⏱️  Ejecución Diferida (Deferred Execution)");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Con List<T>:");
        Console.WriteLine("  var users = GetActiveUsersList(); // Ejecuta ToList() INMEDIATAMENTE");
        Console.WriteLine("  var first = users.First(); // Ya tenía todos los datos\n");

        var stopwatch1 = Stopwatch.StartNew();
        var listUsers = GetActiveUsersList(); // Ejecuta aquí
        var listFirst = listUsers.First();
        stopwatch1.Stop();
        Console.WriteLine($"Tiempo total: {stopwatch1.ElapsedTicks} ticks\n");

        Console.WriteLine("Con IEnumerable<T>:");
        Console.WriteLine("  var users = GetActiveUsersIEnumerable(); // NO ejecuta nada");
        Console.WriteLine("  var first = users.First(); // Ejecuta SOLO lo necesario\n");

        var stopwatch2 = Stopwatch.StartNew();
        var enumUsers = GetActiveUsersIEnumerable(); // No ejecuta
        var enumFirst = enumUsers.First(); // Ejecuta solo para obtener el primero
        stopwatch2.Stop();
        Console.WriteLine($"Tiempo total: {stopwatch2.ElapsedTicks} ticks\n");

        Console.WriteLine("💡 Con IEnumerable<T>, solo procesas lo que realmente necesitas\n");
    }

    /// <summary>
    /// Demuestra mejor encapsulación
    /// </summary>
    public static void DemonstrateEncapsulation()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🔒 Mejor Encapsulación");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("❌ Con List<T>:");
        Console.WriteLine("  public List<User> GetUsers() { }");
        Console.WriteLine("  • Expone que estás usando List<T>");
        Console.WriteLine("  • El consumidor sabe que puede usar métodos de List<T>");
        Console.WriteLine("  • Acopla el código a una implementación específica\n");

        Console.WriteLine("✅ Con IEnumerable<T>:");
        Console.WriteLine("  public IEnumerable<User> GetUsers() { }");
        Console.WriteLine("  • Solo expone que puedes enumerar usuarios");
        Console.WriteLine("  • Oculta los detalles de implementación");
        Console.WriteLine("  • Permite cambiar la implementación internamente\n");

        var users = GetActiveUsersIEnumerable();
        Console.WriteLine($"Tipo devuelto: {users.GetType().Name}");
        Console.WriteLine("El consumidor solo sabe que puede iterar, no cómo está implementado\n");
    }

    /// <summary>
    /// Ejecuta todos los ejemplos
    /// </summary>
    public static void RunAllExamples()
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     Prefer IEnumerable<T> Over List<T> for Return Types      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

        DemonstrateListReturn();
        Console.WriteLine("\n");
        DemonstrateIEnumerableReturn();
        Console.WriteLine("\n");
        DemonstrateFlexibility();
        Console.WriteLine("\n");
        DemonstrateDeferredExecution();
        Console.WriteLine("\n");
        DemonstrateEncapsulation();

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  RESUMEN");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        Console.WriteLine("✅ Ventajas de IEnumerable<T>:");
        Console.WriteLine("   ◾ Flexibilidad - cambiar implementación fácilmente");
        Console.WriteLine("   ◾ Mejor encapsulación - oculta detalles de implementación");
        Console.WriteLine("   ◾ Ejecución diferida - más eficiente");
        Console.WriteLine("   ◾ Evita operaciones innecesarias\n");
        
        Console.WriteLine("💡 Regla General:");
        Console.WriteLine("   • Usa IEnumerable<T> como tipo de retorno por defecto");
        Console.WriteLine("   • Solo usa List<T> si el consumidor específicamente lo necesita");
        Console.WriteLine("   • El consumidor puede convertir a List si es necesario: .ToList()\n");
    }

    // Métodos de ejemplo (mala práctica)
    private static List<User> GetActiveUsersList()
    {
        return _users.Where(u => u.IsActive).ToList(); // Ejecuta inmediatamente
    }

    // Métodos de ejemplo (buena práctica)
    private static IEnumerable<User> GetActiveUsersIEnumerable()
    {
        return _users.Where(u => u.IsActive); // Ejecución diferida
    }

    // Diferentes implementaciones con la misma firma
    private static IEnumerable<User> GetUsersImplementation1()
    {
        return _users.Where(u => u.IsActive).ToList(); // List
    }

    private static IEnumerable<User> GetUsersImplementation2()
    {
        return _users.Where(u => u.IsActive).ToArray(); // Array
    }

    private static IEnumerable<User> GetUsersImplementation3()
    {
        return _users.Where(u => u.IsActive).ToHashSet(); // HashSet
    }
}

// Clases de ejemplo
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

