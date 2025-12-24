namespace NetMasteryLab.Concepts.CleanCode.NestedLoopsVsSelectMany.Examples;

/// <summary>
/// Ejemplos que demuestran cómo usar SelectMany para aplanar colecciones anidadas
/// </summary>
public class SelectManyExamples
{
    private static List<Department> GetDepartments()
    {
        return new List<Department>
        {
            new Department
            {
                Name = "IT",
                Employees = new List<Employee>
                {
                    new Employee { Id = 1, Name = "Alice", IsActive = true },
                    new Employee { Id = 2, Name = "Bob", IsActive = true }
                }
            },
            new Department
            {
                Name = "HR",
                Employees = new List<Employee>
                {
                    new Employee { Id = 3, Name = "Charlie", IsActive = false },
                    new Employee { Id = 4, Name = "Diana", IsActive = true }
                }
            },
            new Department
            {
                Name = "Finance",
                Employees = new List<Employee>
                {
                    new Employee { Id = 5, Name = "Eve", IsActive = true }
                }
            }
        };
    }

    /// <summary>
    /// Demuestra el problema de usar bucles anidados
    /// </summary>
    public static void DemonstrateNestedLoops()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ❌ MALA PRÁCTICA: Bucles Anidados (Nested Loops)");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código problemático:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var departments = GetDepartments();");
        Console.WriteLine("var employees = new List<Employee>();");
        Console.WriteLine("");
        Console.WriteLine("foreach (var dept in departments)");
        Console.WriteLine("{");
        Console.WriteLine("    foreach (var employee in dept.Employees)");
        Console.WriteLine("    {");
        Console.WriteLine("        employees.Add(employee);");
        Console.WriteLine("    }");
        Console.WriteLine("}");
        Console.WriteLine("```\n");

        Console.WriteLine("Problemas:");
        Console.WriteLine("  • Código verboso - requiere múltiples líneas");
        Console.WriteLine("  • Menos legible - la intención no es inmediatamente clara");
        Console.WriteLine("  • Propenso a errores - fácil olvidar inicializar la lista");
        Console.WriteLine("  • Menos funcional - enfoque imperativo\n");

        // Ejecutar el código problemático
        var departments = GetDepartments();
        var employees = new List<Employee>();

        foreach (var dept in departments)
        {
            foreach (var employee in dept.Employees)
            {
                employees.Add(employee);
            }
        }

        Console.WriteLine($"Resultado: {employees.Count} empleados obtenidos");
        Console.WriteLine($"Empleados: {string.Join(", ", employees.Select(e => e.Name))}\n");
    }

    /// <summary>
    /// Demuestra la solución usando SelectMany
    /// </summary>
    public static void DemonstrateSelectMany()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ✅ BUENA PRÁCTICA: SelectMany");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código mejorado:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var employees = GetDepartments()");
        Console.WriteLine("    .SelectMany(dept => dept.Employees)");
        Console.WriteLine("    .ToList();");
        Console.WriteLine("```\n");

        Console.WriteLine("Ventajas:");
        Console.WriteLine("  ✅ Código conciso - una sola línea");
        Console.WriteLine("  ✅ Más legible - la intención es clara");
        Console.WriteLine("  ✅ Menos propenso a errores - no necesitas manejar listas temporales");
        Console.WriteLine("  ✅ Enfoque funcional - declarativo y fácil de entender\n");

        // Ejecutar el código mejorado
        var employees = GetDepartments()
            .SelectMany(dept => dept.Employees)
            .ToList();

        Console.WriteLine($"Resultado: {employees.Count} empleados obtenidos");
        Console.WriteLine($"Empleados: {string.Join(", ", employees.Select(e => e.Name))}\n");
    }

    /// <summary>
    /// Demuestra SelectMany con filtrado
    /// </summary>
    public static void DemonstrateSelectManyWithFiltering()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🔥 SelectMany con Filtrado");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var activeEmployees = GetDepartments()");
        Console.WriteLine("    .SelectMany(dept => dept.Employees)");
        Console.WriteLine("    .Where(emp => emp.IsActive)");
        Console.WriteLine("    .ToList();");
        Console.WriteLine("```\n");

        var activeEmployees = GetDepartments()
            .SelectMany(dept => dept.Employees)
            .Where(emp => emp.IsActive)
            .ToList();

        Console.WriteLine($"Empleados activos: {activeEmployees.Count}");
        Console.WriteLine($"Nombres: {string.Join(", ", activeEmployees.Select(e => e.Name))}\n");
    }

    /// <summary>
    /// Demuestra SelectMany con transformación
    /// </summary>
    public static void DemonstrateSelectManyWithTransformation()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🔄 SelectMany con Transformación");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var employeeNames = GetDepartments()");
        Console.WriteLine("    .SelectMany(dept => dept.Employees)");
        Console.WriteLine("    .Select(emp => emp.Name)");
        Console.WriteLine("    .ToList();");
        Console.WriteLine("```\n");

        var employeeNames = GetDepartments()
            .SelectMany(dept => dept.Employees)
            .Select(emp => emp.Name)
            .ToList();

        Console.WriteLine($"Nombres de empleados: {string.Join(", ", employeeNames)}\n");
    }

    /// <summary>
    /// Demuestra SelectMany con múltiples niveles
    /// </summary>
    public static void DemonstrateSelectManyMultipleLevels()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  📊 SelectMany con Múltiples Niveles");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Ejemplo: Compañías → Órdenes → Items");
        Console.WriteLine("```csharp");
        Console.WriteLine("var allOrderItems = GetCompanies()");
        Console.WriteLine("    .SelectMany(company => company.Orders)");
        Console.WriteLine("    .SelectMany(order => order.OrderItems)");
        Console.WriteLine("    .ToList();");
        Console.WriteLine("```\n");

        var companies = new List<Company>
        {
            new Company
            {
                Name = "Company A",
                Orders = new List<Order>
                {
                    new Order { Id = 1, OrderItems = new List<OrderItem> { new OrderItem { Name = "Item 1" } } },
                    new Order { Id = 2, OrderItems = new List<OrderItem> { new OrderItem { Name = "Item 2" } } }
                }
            },
            new Company
            {
                Name = "Company B",
                Orders = new List<Order>
                {
                    new Order { Id = 3, OrderItems = new List<OrderItem> { new OrderItem { Name = "Item 3" } } }
                }
            }
        };

        var allOrderItems = companies
            .SelectMany(company => company.Orders)
            .SelectMany(order => order.OrderItems)
            .ToList();

        Console.WriteLine($"Total de items en todas las órdenes: {allOrderItems.Count}");
        Console.WriteLine($"Items: {string.Join(", ", allOrderItems.Select(i => i.Name))}\n");
    }

    /// <summary>
    /// Demuestra la diferencia entre Select y SelectMany
    /// </summary>
    public static void DemonstrateSelectVsSelectMany()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🔍 Diferencia: Select vs SelectMany");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Select devuelve una colección de colecciones:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var employeeLists = departments.Select(dept => dept.Employees);");
        Console.WriteLine("// Resultado: IEnumerable<IEnumerable<Employee>>");
        Console.WriteLine("```\n");

        var employeeLists = GetDepartments().Select(dept => dept.Employees);
        Console.WriteLine($"Tipo: {employeeLists.GetType().Name}");
        Console.WriteLine($"Cantidad de listas: {employeeLists.Count()}\n");

        Console.WriteLine("SelectMany aplana en una sola colección:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var employees = departments.SelectMany(dept => dept.Employees);");
        Console.WriteLine("// Resultado: IEnumerable<Employee>");
        Console.WriteLine("```\n");

        var employees = GetDepartments().SelectMany(dept => dept.Employees);
        Console.WriteLine($"Tipo: {employees.GetType().Name}");
        Console.WriteLine($"Cantidad de empleados: {employees.Count()}\n");
    }

    /// <summary>
    /// Ejecuta todos los ejemplos
    /// </summary>
    public static void RunAllExamples()
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     Flattening Nested Collections Using SelectMany            ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

        DemonstrateNestedLoops();
        Console.WriteLine("\n");
        DemonstrateSelectMany();
        Console.WriteLine("\n");
        DemonstrateSelectManyWithFiltering();
        Console.WriteLine("\n");
        DemonstrateSelectManyWithTransformation();
        Console.WriteLine("\n");
        DemonstrateSelectManyMultipleLevels();
        Console.WriteLine("\n");
        DemonstrateSelectVsSelectMany();

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  RESUMEN");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        Console.WriteLine("✅ Ventajas de SelectMany:");
        Console.WriteLine("   ◾ Simplifica el proceso de aplanar colecciones");
        Console.WriteLine("   ◾ Código más legible y conciso");
        Console.WriteLine("   ◾ Enfoque funcional y declarativo");
        Console.WriteLine("   ◾ Fácil de combinar con otros operadores LINQ\n");
        
        Console.WriteLine("💡 Regla General:");
        Console.WriteLine("   • Usa SelectMany para aplanar colecciones anidadas");
        Console.WriteLine("   • Evita bucles anidados cuando SelectMany es más claro");
        Console.WriteLine("   • Combina con Where, Select, etc. para máximo poder\n");
    }
}

// Clases de ejemplo
public class Department
{
    public string Name { get; set; } = string.Empty;
    public List<Employee> Employees { get; set; } = new();
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class Company
{
    public string Name { get; set; } = string.Empty;
    public List<Order> Orders { get; set; } = new();
}

public class Order
{
    public int Id { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
}

public class OrderItem
{
    public string Name { get; set; } = string.Empty;
}

