namespace NetMasteryLab.Concepts.CleanCode.AvoidTooManyArguments.Examples;

/// <summary>
/// Ejemplos que demuestran cómo evitar demasiados argumentos en funciones
/// </summary>
public class AvoidTooManyArgumentsExamples
{
    /// <summary>
    /// Demuestra el problema de tener demasiados argumentos individuales
    /// </summary>
    public static void DemonstrateBadPractice()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ❌ MALA PRÁCTICA: Demasiados Argumentos");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código problemático:");
        Console.WriteLine("```csharp");
        Console.WriteLine("public Result GraduateStudent(");
        Console.WriteLine("    string name,");
        Console.WriteLine("    DateOnly birthDate,");
        Console.WriteLine("    string major,");
        Console.WriteLine("    int score,");
        Console.WriteLine("    int totalCourses)");
        Console.WriteLine("{");
        Console.WriteLine("    // graduates a student");
        Console.WriteLine("}");
        Console.WriteLine("```\n");

        Console.WriteLine("Problemas:");
        Console.WriteLine("  • Difícil de leer - firma muy larga");
        Console.WriteLine("  • Difícil de mantener - cambios requieren modificar muchas llamadas");
        Console.WriteLine("  • Difícil de probar - muchos argumentos en cada test");
        Console.WriteLine("  • Propenso a errores - fácil pasar argumentos en orden incorrecto");
        Console.WriteLine("  • Violación del principio de responsabilidad única\n");

        // Ejemplo de uso problemático
        var result = GraduateStudentBad(
            "John Doe",
            new DateOnly(2000, 5, 15),
            "Computer Science",
            85,
            10
        );

        Console.WriteLine($"Resultado: {result.Message}\n");
    }

    /// <summary>
    /// Demuestra la solución usando un objeto para encapsular datos relacionados
    /// </summary>
    public static void DemonstrateGoodPractice()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ✅ BUENA PRÁCTICA: Encapsular en Objeto");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código mejorado:");
        Console.WriteLine("```csharp");
        Console.WriteLine("public Result GraduateStudent(Student student)");
        Console.WriteLine("{");
        Console.WriteLine("    // graduates a student");
        Console.WriteLine("}");
        Console.WriteLine("```\n");

        Console.WriteLine("Ventajas:");
        Console.WriteLine("  ✅ Mejor legibilidad - firma clara y concisa");
        Console.WriteLine("  ✅ Más fácil de mantener - cambios en un solo lugar");
        Console.WriteLine("  ✅ Más fácil de probar - solo crear un objeto");
        Console.WriteLine("  ✅ Menos propenso a errores - no hay orden incorrecto");
        Console.WriteLine("  ✅ Más flexible - agregar campos sin cambiar la firma\n");

        // Ejemplo de uso mejorado
        var student = new Student
        {
            Name = "John Doe",
            BirthDate = new DateOnly(2000, 5, 15),
            Major = "Computer Science",
            Score = 85,
            TotalCourses = 10
        };

        var result = GraduateStudentGood(student);
        Console.WriteLine($"Resultado: {result.Message}\n");
    }

    /// <summary>
    /// Demuestra cómo agregar nuevos campos sin cambiar la firma de la función
    /// </summary>
    public static void DemonstrateFlexibility()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🔄 Flexibilidad: Agregar Campos Sin Cambiar la Firma");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Escenario: Necesitamos agregar un campo 'Advisor' al estudiante\n");

        Console.WriteLine("❌ Con muchos argumentos:");
        Console.WriteLine("   Debes cambiar TODAS las llamadas a la función:");
        Console.WriteLine("   GraduateStudent(name, birthDate, major, score, totalCourses, advisor);\n");

        Console.WriteLine("✅ Con objeto encapsulado:");
        Console.WriteLine("   Solo modificas la clase Student:");
        Console.WriteLine("   public class Student { ... public string Advisor { get; set; } }");
        Console.WriteLine("   La firma de GraduateStudent() NO cambia\n");

        // Ejemplo con nuevo campo
        var studentWithAdvisor = new Student
        {
            Name = "Jane Smith",
            BirthDate = new DateOnly(2001, 3, 20),
            Major = "Mathematics",
            Score = 92,
            TotalCourses = 12,
            Advisor = "Dr. Johnson" // Nuevo campo agregado sin cambiar la firma
        };

        var result = GraduateStudentGood(studentWithAdvisor);
        Console.WriteLine($"Resultado: {result.Message}");
        Console.WriteLine($"Asesor: {studentWithAdvisor.Advisor}\n");
    }

    /// <summary>
    /// Compara la legibilidad de ambos enfoques
    /// </summary>
    public static void DemonstrateReadabilityComparison()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  📖 Comparación de Legibilidad");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("❌ Con muchos argumentos:");
        Console.WriteLine("   ProcessOrder(");
        Console.WriteLine("       \"John\", \"Doe\", \"john@email.com\",");
        Console.WriteLine("       \"123 Main St\", \"New York\", \"NY\", \"10001\",");
        Console.WriteLine("       DateTime.Now, \"Credit Card\", \"1234-5678-9012-3456\");");
        Console.WriteLine("   // ¿Qué significa cada argumento? Difícil de entender\n");

        Console.WriteLine("✅ Con objeto encapsulado:");
        Console.WriteLine("   ProcessOrder(new Order");
        Console.WriteLine("   {");
        Console.WriteLine("       Customer = new Customer");
        Console.WriteLine("       {");
        Console.WriteLine("           FirstName = \"John\",");
        Console.WriteLine("           LastName = \"Doe\",");
        Console.WriteLine("           Email = \"john@email.com\"");
        Console.WriteLine("       },");
        Console.WriteLine("       ShippingAddress = new Address { ... },");
        Console.WriteLine("       PaymentMethod = new PaymentMethod { ... }");
        Console.WriteLine("   });");
        Console.WriteLine("   // Cada propiedad tiene un nombre claro y significado obvio\n");
    }

    /// <summary>
    /// Ejecuta todos los ejemplos
    /// </summary>
    public static void RunAllExamples()
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     Avoid Too Many Arguments In Functions - Clean Code       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

        DemonstrateBadPractice();
        Console.WriteLine("\n");
        DemonstrateGoodPractice();
        Console.WriteLine("\n");
        DemonstrateFlexibility();
        Console.WriteLine("\n");
        DemonstrateReadabilityComparison();

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  RESUMEN");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        Console.WriteLine("💡 Regla General:");
        Console.WriteLine("   • 0-2 argumentos: Ideal ✅");
        Console.WriteLine("   • 3 argumentos: Aceptable ⚠️");
        Console.WriteLine("   • 4+ argumentos: Considera refactorizar ❌\n");
        
        Console.WriteLine("🔥 Ventajas de evitar demasiados argumentos:");
        Console.WriteLine("   ◾ Mejor legibilidad del código");
        Console.WriteLine("   ◾ Más fácil de mantener");
        Console.WriteLine("   ◾ Testing simplificado");
        Console.WriteLine("   ◾ Mayor flexibilidad\n");
    }

    // Métodos de ejemplo (mala práctica)
    private static Result GraduateStudentBad(
        string name,
        DateOnly birthDate,
        string major,
        int score,
        int totalCourses)
    {
        // Lógica de graduación
        return new Result { IsSuccess = score >= 70, Message = $"Estudiante {name} procesado" };
    }

    // Métodos de ejemplo (buena práctica)
    private static Result GraduateStudentGood(Student student)
    {
        // Lógica de graduación
        return new Result 
        { 
            IsSuccess = student.Score >= 70, 
            Message = $"Estudiante {student.Name} procesado" 
        };
    }
}

// Clases de ejemplo
public class Student
{
    public string Name { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string Major { get; set; } = string.Empty;
    public int Score { get; set; }
    public int TotalCourses { get; set; }
    public string Advisor { get; set; } = string.Empty; // Campo agregado sin cambiar firma
}

public class Result
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
}

