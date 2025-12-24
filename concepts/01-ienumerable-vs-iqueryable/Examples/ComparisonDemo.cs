namespace NetMasteryLab.Concepts.IEnumerableVsIQueryable.Examples;

/// <summary>
/// Demostración comparativa de IEnumerable vs IQueryable
/// Basado en el ejemplo de la imagen proporcionada
/// </summary>
public class ComparisonDemo
{
    /// <summary>
    /// Demuestra la diferencia clave mostrada en la imagen:
    /// IEnumerable: TOP 10 se pierde porque filtra en el cliente
    /// IQueryable: TOP 10 existe porque ejecuta en SQL Server con todos los filtros
    /// </summary>
    public static void ShowKeyDifference()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  COMPARACIÓN: IEnumerable vs IQueryable");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        // ========== IEnumerable ==========
        Console.WriteLine("// IEnumerable");
        Console.WriteLine("IEnumerable<Employee> list = dc.Employees.Where(p => p.Name.StartsWith(\"S\"));");
        Console.WriteLine("list = list.Take<Employee>(10);\n");

        var employees = GenerateEmployees(100);
        IEnumerable<Employee> enumerableList = employees.Where(p => p.EmpName.StartsWith("S"));
        enumerableList = enumerableList.Take(10);

        Console.WriteLine("// TOP 10 is missing since IEnumerable filters records on the client side");
        Console.WriteLine("SQL generado (simulado):");
        Console.WriteLine("  SELECT [t0].[EmpID], [t0].[EmpName], [t0].[Salary]");
        Console.WriteLine("  FROM [Employee] AS [t0]");
        Console.WriteLine("  WHERE [t0].[EmpName] LIKE @p0");
        Console.WriteLine("  -- ⚠️  NO hay TOP 10 en el SQL\n");

        Console.WriteLine("Flujo de datos:");
        Console.WriteLine("  DATABASE → ALL RECORDS → IENUMERABLE → [FILTER en CLIENT] → CLIENT\n");

        var enumerableResults = enumerableList.ToList();
        Console.WriteLine($"Registros traídos de DB: {employees.Where(p => p.EmpName.StartsWith("S")).Count()}");
        Console.WriteLine($"Registros después de Take(10): {enumerableResults.Count}\n");

        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        // ========== IQueryable ==========
        Console.WriteLine("// IQueryable");
        Console.WriteLine("IQueryable<Employee> list = dc.Employees.Where(p => p.Name.StartsWith(\"S\"));");
        Console.WriteLine("list = list.Take<Employee>(10);\n");

        Console.WriteLine("// TOP 10 exists since IQueryable executes query in SQL server with all filters");
        Console.WriteLine("SQL generado:");
        Console.WriteLine("  SELECT TOP 10 [t0].[EmpID], [t0].[EmpName], [t0].[Salary]");
        Console.WriteLine("  FROM [Employee] AS [t0]");
        Console.WriteLine("  WHERE [t0].[EmpName] LIKE @p0");
        Console.WriteLine("  -- ✅ TOP 10 está presente en el SQL\n");

        Console.WriteLine("Flujo de datos:");
        Console.WriteLine("  IQUERYABLE → DATABASE → [FILTER en DATABASE] → ONLY REQUIRED RECORDS → CLIENT\n");

        // Simulamos IQueryable (en un caso real sería con Entity Framework)
        var queryableResults = employees
            .Where(p => p.EmpName.StartsWith("S"))
            .Take(10)
            .ToList();

        Console.WriteLine($"Registros traídos de DB: {queryableResults.Count} (solo los necesarios)");
        Console.WriteLine($"Registros devueltos: {queryableResults.Count}\n");

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  RESUMEN DE DIFERENCIAS");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("IEnumerable:");
        Console.WriteLine("  ❌ Trae TODOS los registros que cumplen el filtro");
        Console.WriteLine("  ❌ Aplica Take(10) en memoria después de traer todo");
        Console.WriteLine("  ❌ No hay TOP 10 en el SQL generado");
        Console.WriteLine("  ⚠️  Ineficiente con grandes volúmenes de datos\n");

        Console.WriteLine("IQueryable:");
        Console.WriteLine("  ✅ Traduce Take(10) a TOP 10 en SQL");
        Console.WriteLine("  ✅ Solo trae los 10 registros necesarios");
        Console.WriteLine("  ✅ Optimizado para grandes volúmenes de datos");
        Console.WriteLine("  ✅ Aprovecha el poder del servidor de base de datos\n");
    }

    private static IEnumerable<Employee> GenerateEmployees(int count)
    {
        var random = new Random(42);
        var names = new[] { "Sara", "Sofia", "Samuel", "Sergio", "Silvia", "John", "Jane", "Mike", "Mary", "David" };

        for (int i = 1; i <= count; i++)
        {
            yield return new Employee
            {
                EmpID = i,
                EmpName = names[random.Next(names.Length)],
                Salary = random.Next(30000, 150000),
                Age = random.Next(22, 65),
                Department = "IT"
            };
        }
    }
}

