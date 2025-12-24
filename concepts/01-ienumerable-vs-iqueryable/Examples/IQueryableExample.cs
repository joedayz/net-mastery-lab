using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace NetMasteryLab.Concepts.IEnumerableVsIQueryable.Examples;

/// <summary>
/// Ejemplo que demuestra cómo IQueryable ejecuta consultas en el servidor (server-side)
/// </summary>
public class IQueryableExample
{
    /// <summary>
    /// Demuestra que IQueryable traduce la consulta a SQL y ejecuta en el servidor
    /// </summary>
    public static async Task DemonstrateServerSideExecution()
    {
        Console.WriteLine("=== IQueryable Example: Server-Side Execution ===\n");

        // Configuramos una base de datos en memoria para simular Entity Framework
        var options = new DbContextOptionsBuilder<EmployeeDbContext>()
            .UseInMemoryDatabase(databaseName: "EmployeeDb")
            .Options;

        using var context = new EmployeeDbContext(options);

        // Insertamos datos de ejemplo
        await SeedDatabase(context);

        var totalEmployees = await context.Employees.CountAsync();
        Console.WriteLine($"Total empleados en base de datos: {totalEmployees}\n");

        // IQueryable: La consulta se traduce a SQL
        IQueryable<Employee> query = context.Employees.Where(p => p.EmpName.StartsWith("S"));

        Console.WriteLine("Definiendo consulta: Where(p => p.EmpName.StartsWith(\"S\"))...");
        Console.WriteLine("(La consulta aún NO se ha ejecutado)\n");

        // Take(10) se traduce a TOP 10 en SQL
        query = query.Take(10);

        Console.WriteLine("Agregando Take(10) a la consulta...");
        Console.WriteLine("(La consulta aún NO se ha ejecutado - deferred execution)\n");

        // La consulta se ejecuta AHORA cuando llamamos ToListAsync()
        // SQL generado: SELECT TOP 10 * FROM Employees WHERE EmpName LIKE 'S%'
        Console.WriteLine("Ejecutando consulta (ToListAsync())...");
        var results = await query.ToListAsync();

        Console.WriteLine($"Registros devueltos: {results.Count}\n");

        // Mostrar resultados
        Console.WriteLine("Primeros 10 empleados con nombre que empieza con 'S':");
        foreach (var emp in results)
        {
            Console.WriteLine($"  ID: {emp.EmpID}, Nombre: {emp.EmpName}, Salario: {emp.Salary:C}");
        }

        Console.WriteLine("\n✅ NOTA: Con IQueryable, solo se trajeron los 10 registros necesarios.");
        Console.WriteLine("   La consulta se tradujo a SQL con TOP 10, optimizando el rendimiento.\n");
    }

    /// <summary>
    /// Demuestra cómo IQueryable traduce expresiones complejas a SQL
    /// </summary>
    public static async Task DemonstrateQueryTranslation()
    {
        Console.WriteLine("=== IQueryable: Query Translation ===\n");

        var options = new DbContextOptionsBuilder<EmployeeDbContext>()
            .UseInMemoryDatabase(databaseName: "QueryTranslationDb")
            .Options;

        using var context = new EmployeeDbContext(options);
        await SeedDatabase(context);

        // Consulta compleja que se traduce completamente a SQL
        var query = context.Employees
            .Where(e => e.Age > 25 && e.Salary > 50000)
            .OrderBy(e => e.Salary)
            .ThenBy(e => e.EmpName)
            .Take(5);

        Console.WriteLine("Consulta definida:");
        Console.WriteLine("  Where(e => e.Age > 25 && e.Salary > 50000)");
        Console.WriteLine("  OrderBy(e => e.Salary)");
        Console.WriteLine("  ThenBy(e => e.EmpName)");
        Console.WriteLine("  Take(5)");
        Console.WriteLine("\nEsta consulta se traducirá a SQL y se ejecutará en el servidor.\n");

        var results = await query.ToListAsync();

        Console.WriteLine($"Resultados obtenidos: {results.Count}");
        foreach (var emp in results)
        {
            Console.WriteLine($"  {emp.EmpName} - Edad: {emp.Age}, Salario: {emp.Salary:C}");
        }

        Console.WriteLine("\n✅ Solo se trajeron los 5 registros necesarios desde la base de datos.\n");
    }

    /// <summary>
    /// Compara el rendimiento: IQueryable optimiza en el servidor
    /// </summary>
    public static async Task DemonstratePerformance()
    {
        Console.WriteLine("=== IQueryable: Performance Optimization ===\n");

        var options = new DbContextOptionsBuilder<EmployeeDbContext>()
            .UseInMemoryDatabase(databaseName: "PerformanceDb")
            .Options;

        using var context = new EmployeeDbContext(options);
        await SeedLargeDatabase(context, 10000);

        var stopwatch = Stopwatch.StartNew();

        // IQueryable: La consulta se ejecuta en el servidor con optimizaciones
        var result = await context.Employees
            .Where(e => e.EmpName.StartsWith("S"))
            .OrderBy(e => e.Salary)
            .Take(10)
            .ToListAsync();

        stopwatch.Stop();

        var totalInDb = await context.Employees.CountAsync();
        var filteredInDb = await context.Employees.Where(e => e.EmpName.StartsWith("S")).CountAsync();

        Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Registros en base de datos: {totalInDb}");
        Console.WriteLine($"Registros que cumplen filtro: {filteredInDb}");
        Console.WriteLine($"Registros devueltos: {result.Count}");
        Console.WriteLine("\n✅ Solo se procesaron y trajeron los 10 registros necesarios.");
        Console.WriteLine("   La base de datos hizo el trabajo pesado.\n");
    }

    /// <summary>
    /// Demuestra el error común de convertir IQueryable a IEnumerable demasiado pronto
    /// </summary>
    public static async Task DemonstrateCommonMistake()
    {
        Console.WriteLine("=== ⚠️  Error Común: Convertir IQueryable a IEnumerable demasiado pronto ===\n");

        var options = new DbContextOptionsBuilder<EmployeeDbContext>()
            .UseInMemoryDatabase(databaseName: "MistakeDb")
            .Options;

        using var context = new EmployeeDbContext(options);
        await SeedLargeDatabase(context, 10000);

        Console.WriteLine("❌ MAL: Convirtiendo a IEnumerable antes de aplicar filtros");
        var stopwatch1 = Stopwatch.StartNew();
        var badResult = context.Employees
            .ToList() // ⚠️ Esto trae TODOS los registros a memoria
            .Where(e => e.EmpName.StartsWith("S"))
            .Take(10)
            .ToList();
        stopwatch1.Stop();

        Console.WriteLine($"Tiempo: {stopwatch1.ElapsedMilliseconds} ms");
        Console.WriteLine($"Registros traídos: 10,000 (todos)\n");

        Console.WriteLine("✅ BIEN: Manteniendo IQueryable hasta el final");
        var stopwatch2 = Stopwatch.StartNew();
        var goodResult = await context.Employees
            .Where(e => e.EmpName.StartsWith("S"))
            .Take(10)
            .ToListAsync(); // La consulta se ejecuta aquí con optimización
        stopwatch2.Stop();

        Console.WriteLine($"Tiempo: {stopwatch2.ElapsedMilliseconds} ms");
        Console.WriteLine($"Registros traídos: Solo los 10 necesarios\n");

        Console.WriteLine($"Mejora de rendimiento: {stopwatch1.ElapsedMilliseconds / (double)stopwatch2.ElapsedMilliseconds:F2}x más rápido\n");
    }

    private static async Task SeedDatabase(EmployeeDbContext context)
    {
        if (await context.Employees.AnyAsync())
            return;

        var random = new Random(42);
        var names = new[] { "Sara", "Sofia", "Samuel", "Sergio", "Silvia", "John", "Jane", "Mike", "Mary", "David" };
        var departments = new[] { "IT", "HR", "Finance", "Sales", "Marketing" };

        var employees = new List<Employee>();
        for (int i = 1; i <= 100; i++)
        {
            employees.Add(new Employee
            {
                EmpID = i,
                EmpName = names[random.Next(names.Length)],
                Salary = random.Next(30000, 150000),
                Age = random.Next(22, 65),
                Department = departments[random.Next(departments.Length)]
            });
        }

        context.Employees.AddRange(employees);
        await context.SaveChangesAsync();
    }

    private static async Task SeedLargeDatabase(EmployeeDbContext context, int count)
    {
        if (await context.Employees.AnyAsync())
            return;

        var random = new Random(42);
        var names = new[] { "Sara", "Sofia", "Samuel", "Sergio", "Silvia", "John", "Jane", "Mike", "Mary", "David" };
        var departments = new[] { "IT", "HR", "Finance", "Sales", "Marketing" };

        var employees = new List<Employee>();
        for (int i = 1; i <= count; i++)
        {
            employees.Add(new Employee
            {
                EmpID = i,
                EmpName = names[random.Next(names.Length)],
                Salary = random.Next(30000, 150000),
                Age = random.Next(22, 65),
                Department = departments[random.Next(departments.Length)]
            });
        }

        context.Employees.AddRange(employees);
        await context.SaveChangesAsync();
    }
}

