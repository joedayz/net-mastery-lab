using System.Diagnostics;

namespace NetMasteryLab.Concepts.CleanCode.MinByMaxByInsteadOfOrderBy.Examples;

/// <summary>
/// Ejemplos que demuestran cómo usar MinBy y MaxBy en lugar de OrderBy + First/Last
/// </summary>
public class MinByMaxByExamples
{
    private static List<Car> GetCars()
    {
        return new List<Car>
        {
            new Car { Id = 1, Brand = "Toyota", Model = "Camry", Price = 25000 },
            new Car { Id = 2, Brand = "Honda", Model = "Civic", Price = 22000 },
            new Car { Id = 3, Brand = "BMW", Model = "3 Series", Price = 45000 },
            new Car { Id = 4, Brand = "Mercedes", Model = "C-Class", Price = 42000 },
            new Car { Id = 5, Brand = "Ford", Model = "Focus", Price = 20000 }
        };
    }

    private static List<Student> GetStudents()
    {
        return new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Grade = 95 },
            new Student { Id = 2, Name = "Bob", Grade = 87 },
            new Student { Id = 3, Name = "Charlie", Grade = 92 },
            new Student { Id = 4, Name = "Diana", Grade = 88 }
        };
    }

    /// <summary>
    /// Demuestra el problema de usar OrderBy + First
    /// </summary>
    public static void DemonstrateOrderByFirst()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ❌ MALA PRÁCTICA: OrderBy + First/Last (.NET 5)");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código problemático:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var cheapest = cars.OrderBy(c => c.Price).First();");
        Console.WriteLine("var priciest = cars.OrderByDescending(c => c.Price).First();");
        Console.WriteLine("```\n");

        Console.WriteLine("Problemas:");
        Console.WriteLine("  • Menos eficiente - ordena toda la secuencia O(n log n)");
        Console.WriteLine("  • Más código - requiere dos operaciones");
        Console.WriteLine("  • Menos legible - la intención no es inmediatamente clara");
        Console.WriteLine("  • Overhead innecesario - para colecciones grandes es costoso\n");

        var cars = GetCars();
        var stopwatch = Stopwatch.StartNew();
        var cheapest = cars.OrderBy(c => c.Price).First();
        var priciest = cars.OrderByDescending(c => c.Price).First();
        stopwatch.Stop();

        Console.WriteLine($"Carro más barato: {cheapest.Brand} {cheapest.Model} - ${cheapest.Price:N0}");
        Console.WriteLine($"Carro más caro: {priciest.Brand} {priciest.Model} - ${priciest.Price:N0}");
        Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedTicks} ticks\n");
    }

    /// <summary>
    /// Demuestra la solución usando MinBy y MaxBy
    /// </summary>
    public static void DemonstrateMinByMaxBy()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ✅ BUENA PRÁCTICA: MinBy y MaxBy (.NET 6+)");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código mejorado:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var cheapest = cars.MinBy(c => c.Price);");
        Console.WriteLine("var priciest = cars.MaxBy(c => c.Price);");
        Console.WriteLine("```\n");

        Console.WriteLine("Ventajas:");
        Console.WriteLine("  ✅ Más eficiente - solo encuentra el extremo O(n)");
        Console.WriteLine("  ✅ Más conciso - una sola operación");
        Console.WriteLine("  ✅ Más legible - la intención es clara");
        Console.WriteLine("  ✅ Mejor rendimiento - especialmente en colecciones grandes\n");

        var cars = GetCars();
        var stopwatch = Stopwatch.StartNew();
        var cheapest = cars.MinBy(c => c.Price);
        var priciest = cars.MaxBy(c => c.Price);
        stopwatch.Stop();

        Console.WriteLine($"Carro más barato: {cheapest.Brand} {cheapest.Model} - ${cheapest.Price:N0}");
        Console.WriteLine($"Carro más caro: {priciest.Brand} {priciest.Model} - ${priciest.Price:N0}");
        Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedTicks} ticks\n");
    }

    /// <summary>
    /// Demuestra comparación de rendimiento
    /// </summary>
    public static void DemonstratePerformanceComparison()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  📊 Comparación de Rendimiento");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        var largeCarsList = Enumerable.Range(1, 10000)
            .Select(i => new Car 
            { 
                Id = i, 
                Brand = $"Brand{i}", 
                Model = $"Model{i}", 
                Price = Random.Shared.Next(15000, 50000) 
            })
            .ToList();

        // Método antiguo
        var stopwatch1 = Stopwatch.StartNew();
        var cheapest1 = largeCarsList.OrderBy(c => c.Price).First();
        stopwatch1.Stop();

        // Método nuevo
        var stopwatch2 = Stopwatch.StartNew();
        var cheapest2 = largeCarsList.MinBy(c => c.Price);
        stopwatch2.Stop();

        Console.WriteLine($"Colección de {largeCarsList.Count:N0} carros:\n");
        Console.WriteLine($"❌ OrderBy + First: {stopwatch1.ElapsedMilliseconds} ms");
        Console.WriteLine($"✅ MinBy:            {stopwatch2.ElapsedMilliseconds} ms");

        if (stopwatch1.ElapsedMilliseconds > stopwatch2.ElapsedMilliseconds)
        {
            var improvement = ((double)(stopwatch1.ElapsedMilliseconds - stopwatch2.ElapsedMilliseconds) / stopwatch1.ElapsedMilliseconds) * 100;
            Console.WriteLine($"\n🚀 Mejora: {improvement:F1}% más rápido con MinBy");
        }

        Console.WriteLine("\n💡 MinBy es O(n) mientras que OrderBy + First es O(n log n)\n");
    }

    /// <summary>
    /// Demuestra uso con diferentes tipos de objetos
    /// </summary>
    public static void DemonstrateWithDifferentObjects()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🎯 Uso con Diferentes Tipos de Objetos");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        var students = GetStudents();

        Console.WriteLine("Encontrar el estudiante con mejor calificación:");
        Console.WriteLine("```csharp");
        Console.WriteLine("var bestStudent = students.MaxBy(s => s.Grade);");
        Console.WriteLine("```\n");

        var bestStudent = students.MaxBy(s => s.Grade);
        Console.WriteLine($"Mejor estudiante: {bestStudent.Name} - Calificación: {bestStudent.Grade}\n");

        var cars = GetCars();
        Console.WriteLine("Encontrar el carro más barato:");
        var cheapestCar = cars.MinBy(c => c.Price);
        Console.WriteLine($"Carro más barato: {cheapestCar.Brand} {cheapestCar.Model} - ${cheapestCar.Price:N0}\n");
    }

    /// <summary>
    /// Demuestra combinación con otros operadores LINQ
    /// </summary>
    public static void DemonstrateWithOtherOperators()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🔄 Combinación con Otros Operadores LINQ");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        var cars = GetCars();

        Console.WriteLine("MinBy con Where (filtrado previo):");
        Console.WriteLine("```csharp");
        Console.WriteLine("var cheapestActiveCar = cars");
        Console.WriteLine("    .Where(c => c.Price > 20000)");
        Console.WriteLine("    .MinBy(c => c.Price);");
        Console.WriteLine("```\n");

        var cheapestActiveCar = cars
            .Where(c => c.Price > 20000)
            .MinBy(c => c.Price);

        Console.WriteLine($"Carro más barato (precio > $20,000): {cheapestActiveCar.Brand} - ${cheapestActiveCar.Price:N0}\n");
    }

    /// <summary>
    /// Demuestra manejo de secuencias vacías
    /// </summary>
    public static void DemonstrateEmptySequenceHandling()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ⚠️  Manejo de Secuencias Vacías");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("⚠️  MinBy/MaxBy lanzan InvalidOperationException si la secuencia está vacía:\n");

        var emptyList = new List<Car>();

        try
        {
            var cheapest = emptyList.MinBy(c => c.Price);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}\n");
        }

        Console.WriteLine("✅ Soluciones:");
        Console.WriteLine("```csharp");
        Console.WriteLine("// Opción 1: Verificar primero");
        Console.WriteLine("var cheapest = cars.Any() ? cars.MinBy(c => c.Price) : null;");
        Console.WriteLine("");
        Console.WriteLine("// Opción 2: Usar DefaultIfEmpty");
        Console.WriteLine("var cheapest = cars.DefaultIfEmpty().MinBy(c => c?.Price ?? decimal.MaxValue);");
        Console.WriteLine("```\n");
    }

    /// <summary>
    /// Ejecuta todos los ejemplos
    /// </summary>
    public static void RunAllExamples()
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     Use MinBy or MaxBy Instead of OrderBy + First/Last       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

        DemonstrateOrderByFirst();
        Console.WriteLine("\n");
        DemonstrateMinByMaxBy();
        Console.WriteLine("\n");
        DemonstratePerformanceComparison();
        Console.WriteLine("\n");
        DemonstrateWithDifferentObjects();
        Console.WriteLine("\n");
        DemonstrateWithOtherOperators();
        Console.WriteLine("\n");
        DemonstrateEmptySequenceHandling();

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  RESUMEN");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        Console.WriteLine("✅ Ventajas de MinBy/MaxBy:");
        Console.WriteLine("   ◾ Más conciso y fácil de leer");
        Console.WriteLine("   ◾ Más eficiente - O(n) vs O(n log n)");
        Console.WriteLine("   ◾ Funciona con cualquier tipo de secuencia\n");
        
        Console.WriteLine("💡 Regla General:");
        Console.WriteLine("   • Usa MinBy/MaxBy cuando solo necesitas el elemento extremo");
        Console.WriteLine("   • Disponible en .NET 6+");
        Console.WriteLine("   • Considera OrderBy solo si necesitas elementos ordenados\n");
    }
}

// Clases de ejemplo
public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Grade { get; set; }
}

