using System.Diagnostics;

namespace NetMasteryLab.Concepts.IEnumerableVsIQueryable.Examples;

/// <summary>
/// Ejemplo que demuestra cómo IEnumerable ejecuta consultas en memoria (client-side)
/// </summary>
public class IEnumerableExample
{
    /// <summary>
    /// Demuestra que IEnumerable trae TODOS los registros a memoria antes de aplicar Take(10)
    /// </summary>
    public static void DemonstrateClientSideExecution()
    {
        Console.WriteLine("=== IEnumerable Example: Client-Side Execution ===\n");

        // Simulamos una colección en memoria (como si viniera de una base de datos)
        var employees = GenerateEmployees(1000); // Generamos 1000 empleados

        Console.WriteLine($"Total empleados generados: {employees.Count()}\n");

        // IEnumerable: La consulta se ejecuta en memoria
        IEnumerable<Employee> list = employees.Where(p => p.EmpName.StartsWith("S"));
        
        Console.WriteLine("Aplicando filtro Where(p => p.EmpName.StartsWith(\"S\"))...");
        Console.WriteLine($"Registros después del filtro: {list.Count()}\n");

        // Take(10) se aplica DESPUÉS de traer todos los registros que cumplen el filtro
        list = list.Take(10);

        Console.WriteLine("Aplicando Take(10)...");
        Console.WriteLine($"Registros finales: {list.Count()}\n");

        // Mostrar resultados
        Console.WriteLine("Primeros 10 empleados con nombre que empieza con 'S':");
        foreach (var emp in list)
        {
            Console.WriteLine($"  ID: {emp.EmpID}, Nombre: {emp.EmpName}, Salario: {emp.Salary:C}");
        }

        Console.WriteLine("\n⚠️  NOTA: Con IEnumerable, TODOS los registros que cumplen el filtro");
        Console.WriteLine("   fueron traídos a memoria antes de aplicar Take(10).");
        Console.WriteLine("   Si hubiera 100,000 registros con nombre 'S', todos se traerían.\n");
    }

    /// <summary>
    /// Demuestra la ejecución diferida (deferred execution) de IEnumerable
    /// </summary>
    public static void DemonstrateDeferredExecution()
    {
        Console.WriteLine("=== IEnumerable: Deferred Execution ===\n");

        var employees = GenerateEmployees(10);

        // La consulta NO se ejecuta aquí, solo se define
        IEnumerable<Employee> query = employees.Where(e => e.Age > 25);

        Console.WriteLine("Consulta definida pero NO ejecutada aún...");
        Console.WriteLine("Agregando más empleados a la colección...\n");

        // Agregamos más empleados después de definir la consulta
        var newEmployees = GenerateEmployees(5, startId: 11);
        employees = employees.Concat(newEmployees);

        // La consulta se ejecuta AHORA cuando iteramos
        Console.WriteLine("Ejecutando consulta (iterando)...");
        var results = query.ToList();

        Console.WriteLine($"Resultados: {results.Count} empleados con edad > 25");
        Console.WriteLine("(Incluye los nuevos empleados agregados después de definir la consulta)\n");
    }

    /// <summary>
    /// Compara el rendimiento: IEnumerable procesa todo en memoria
    /// </summary>
    public static void DemonstratePerformance()
    {
        Console.WriteLine("=== IEnumerable: Performance Impact ===\n");

        var largeDataSet = GenerateEmployees(10000);

        var stopwatch = Stopwatch.StartNew();

        // IEnumerable: Trae todos los registros a memoria, luego filtra
        var result = largeDataSet
            .Where(e => e.EmpName.StartsWith("S"))
            .OrderBy(e => e.Salary)
            .Take(10)
            .ToList();

        stopwatch.Stop();

        Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Registros procesados en memoria: {largeDataSet.Count()}");
        Console.WriteLine($"Registros filtrados: {largeDataSet.Where(e => e.EmpName.StartsWith("S")).Count()}");
        Console.WriteLine($"Registros devueltos: {result.Count}");
        Console.WriteLine("\n⚠️  Todos los registros fueron procesados en memoria antes de aplicar Take(10)\n");
    }

    private static IEnumerable<Employee> GenerateEmployees(int count, int startId = 1)
    {
        var random = new Random(42); // Seed fijo para resultados reproducibles
        var names = new[] { "Sara", "Sofia", "Samuel", "Sergio", "Silvia", "John", "Jane", "Mike", "Mary", "David" };
        var departments = new[] { "IT", "HR", "Finance", "Sales", "Marketing" };

        for (int i = 0; i < count; i++)
        {
            yield return new Employee
            {
                EmpID = startId + i,
                EmpName = names[random.Next(names.Length)],
                Salary = random.Next(30000, 150000),
                Age = random.Next(22, 65),
                Department = departments[random.Next(departments.Length)]
            };
        }
    }
}

