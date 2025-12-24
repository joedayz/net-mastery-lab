using NetMasteryLab.Concepts.IEnumerableVsIQueryable.Examples;
using NetMasteryLab.Concepts.NullArgumentChecks.Examples;
using NetMasteryLab.Concepts.TryGetValueAvoidDoubleLookup.Examples;
using NetMasteryLab.Concepts.CleanCode.AvoidTooManyArguments.Examples;
using NetMasteryLab.Concepts.CleanCode.PreferIEnumerableOverList.Examples;
using NetMasteryLab.Concepts.CleanCode.NestedLoopsVsSelectMany.Examples;
using NetMasteryLab.Concepts.CleanCode.MinByMaxByInsteadOfOrderBy.Examples;
using NetMasteryLab.Concepts.CleanCode.NamingConventions.Examples;
using NetMasteryLab.Concepts.CleanCode.InterpolatedStrings.Examples;
using NetMasteryLab.Concepts.PerformanceOptimization.AsNoTrackingEFCore.Examples;
using NetMasteryLab.Concepts.PerformanceOptimization.LoadingStrategies.Examples;
using NetMasteryLab.Concepts.AspNetCore.MiddlewareOrder.Examples;
using NetMasteryLab.Concepts.Security.SecureStringExamples.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.Encapsulation.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.Abstraction.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.InheritanceVirtualOverrideDI.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.Polymorphism.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.KeyClassConcepts.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.ParseVsTryParse.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.DateTimeExamples.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.DataTypes.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.AttributesReflection.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.ModernLinqPatternMatching.Examples;
using NetMasteryLab.Concepts.DesignPatterns.UnitOfWork.Examples;

namespace NetMasteryLab;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                  .NET Mastery Lab 🚀                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

        if (args.Length > 0 && args[0] == "--all")
        {
            await RunAllExamples();
        }
        else
        {
            ShowMenu();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  CONCEPTOS DISPONIBLES");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        Console.WriteLine("📚 IEnumerable vs IQueryable:");
        Console.WriteLine("  1. Comparación clave (IEnumerable vs IQueryable)");
        Console.WriteLine("  2. IEnumerable - Ejecución en cliente");
        Console.WriteLine("  3. IEnumerable - Ejecución diferida");
        Console.WriteLine("  4. IEnumerable - Impacto en rendimiento");
        Console.WriteLine("  5. IQueryable - Ejecución en servidor");
        Console.WriteLine("  6. IQueryable - Traducción de consultas");
        Console.WriteLine("  7. IQueryable - Optimización de rendimiento");
        Console.WriteLine("  8. Error común: Convertir IQueryable demasiado pronto\n");
        
        Console.WriteLine("🔍 Null Argument Checks:");
        Console.WriteLine("  10. Comparación de métodos de validación");
        Console.WriteLine("  11. Ejemplo práctico de uso");
        Console.WriteLine("  12. Validación múltiple de argumentos");
        Console.WriteLine("  13. Benchmarks de rendimiento\n");
        
        Console.WriteLine("🔑 TryGetValue - Evitar Doble Búsqueda:");
        Console.WriteLine("  14. Comparación: ContainsKey vs TryGetValue");
        Console.WriteLine("  15. Ejemplo de rendimiento\n");
        
        Console.WriteLine("💎 Clean Code:");
        Console.WriteLine("  16. Avoid Too Many Arguments - Comparación");
        Console.WriteLine("  17. Avoid Too Many Arguments - Ejemplos prácticos");
        Console.WriteLine("  18. IEnumerable<T> vs List<T> - Comparación");
        Console.WriteLine("  19. IEnumerable<T> vs List<T> - Ejemplos prácticos");
        Console.WriteLine("  22. Nested Loops vs SelectMany - Comparación");
        Console.WriteLine("  23. Nested Loops vs SelectMany - Ejemplos prácticos");
        Console.WriteLine("  26. MinBy/MaxBy vs OrderBy+First - Comparación");
        Console.WriteLine("  27. MinBy/MaxBy vs OrderBy+First - Ejemplos prácticos");
        Console.WriteLine("  28. Naming Conventions - Tabla de referencia");
        Console.WriteLine("  29. Naming Conventions - Ejemplos prácticos");
        Console.WriteLine("  30. Interpolated Strings vs string.Format - Comparación");
        Console.WriteLine("  31. Interpolated Strings vs string.Format - Ejemplos prácticos\n");
        
        Console.WriteLine("🚀 Performance Optimization:");
        Console.WriteLine("  20. AsNoTracking() EF Core - Comparación");
        Console.WriteLine("  21. AsNoTracking() EF Core - Ejemplos prácticos");
        Console.WriteLine("  56. Loading Strategies (Eager/Lazy/Explicit) - Comparación");
        Console.WriteLine("  57. Loading Strategies (Eager/Lazy/Explicit) - Ejemplos prácticos\n");
        
        Console.WriteLine("🌐 ASP.NET Core:");
        Console.WriteLine("  24. Middleware Order - Orden correcto");
        Console.WriteLine("  25. Middleware Order - Ejemplos prácticos\n");
        
        Console.WriteLine("🔒 Security:");
        Console.WriteLine("  32. SecureString - Comparación");
        Console.WriteLine("  33. SecureString - Ejemplos prácticos\n");
        
        Console.WriteLine("🎯 Object-Oriented Programming (OOP):");
        Console.WriteLine("  34. Encapsulation - Comparación");
        Console.WriteLine("  35. Encapsulation - Ejemplos prácticos");
        Console.WriteLine("  36. Abstraction - Comparación");
        Console.WriteLine("  37. Abstraction - Ejemplos prácticos");
        Console.WriteLine("  38. Inheritance + DI - Comparación");
        Console.WriteLine("  39. Inheritance + DI - Ejemplos prácticos");
        Console.WriteLine("  42. Polymorphism - Comparación");
        Console.WriteLine("  43. Polymorphism - Ejemplos prácticos");
        Console.WriteLine("  44. Key Class Concepts - Comparación");
        Console.WriteLine("  45. Key Class Concepts - Ejemplos prácticos\n");
        
        Console.WriteLine("🔧 C# Fundamentals:");
        Console.WriteLine("  40. int.Parse() vs int.TryParse() - Comparación");
        Console.WriteLine("  41. int.Parse() vs int.TryParse() - Ejemplos prácticos");
        Console.WriteLine("  46. Date & Time - Comparación");
        Console.WriteLine("  47. Date & Time - Ejemplos prácticos");
        Console.WriteLine("  48. Data Types - Comparación");
        Console.WriteLine("  49. Data Types - Ejemplos prácticos");
        Console.WriteLine("  50. Attributes & Reflection - Comparación");
        Console.WriteLine("  51. Attributes & Reflection - Ejemplos prácticos");
        Console.WriteLine("  52. Modern LINQ with Pattern Matching - Comparación");
        Console.WriteLine("  53. Modern LINQ with Pattern Matching - Ejemplos prácticos\n");
        
        Console.WriteLine("🎨 Design Patterns:");
        Console.WriteLine("  54. Unit of Work Pattern - Comparación");
        Console.WriteLine("  55. Unit of Work Pattern - Ejemplos prácticos\n");
        
        Console.WriteLine("📦 Otros:");
        Console.WriteLine("  9. Ejecutar todos los ejemplos\n");

        Console.Write("Ingresa el número: ");
        var choice = Console.ReadLine();

        Console.Clear();
        ExecuteExample(choice).Wait();
    }

    static async Task ExecuteExample(string? choice)
    {
        switch (choice)
        {
            // IEnumerable vs IQueryable
            case "1":
                ComparisonDemo.ShowKeyDifference();
                break;
            case "2":
                IEnumerableExample.DemonstrateClientSideExecution();
                break;
            case "3":
                IEnumerableExample.DemonstrateDeferredExecution();
                break;
            case "4":
                IEnumerableExample.DemonstratePerformance();
                break;
            case "5":
                await IQueryableExample.DemonstrateServerSideExecution();
                break;
            case "6":
                await IQueryableExample.DemonstrateQueryTranslation();
                break;
            case "7":
                await IQueryableExample.DemonstratePerformance();
                break;
            case "8":
                await IQueryableExample.DemonstrateCommonMistake();
                break;
            
            // Null Argument Checks
            case "10":
                NullCheckExamples.DemonstrateNullChecks();
                break;
            case "11":
                NullCheckExamples.DemonstratePracticalUsage();
                break;
            case "12":
                NullCheckExamples.DemonstrateMultipleValidations();
                break;
            case "13":
                NullCheckBenchmark.RunBenchmarks();
                break;
            
            // TryGetValue
            case "14":
                TryGetValueExamples.RunAllExamples();
                break;
            case "15":
                TryGetValueExamples.DemonstratePerformanceComparison();
                break;
            
            // Clean Code
            case "16":
                AvoidTooManyArgumentsExamples.RunAllExamples();
                break;
            case "17":
                AvoidTooManyArgumentsExamples.DemonstrateReadabilityComparison();
                break;
            case "18":
                IEnumerableVsListExamples.RunAllExamples();
                break;
            case "19":
                IEnumerableVsListExamples.DemonstrateDeferredExecution();
                break;
            case "22":
                SelectManyExamples.RunAllExamples();
                break;
            case "23":
                SelectManyExamples.DemonstrateSelectManyWithFiltering();
                break;
            case "26":
                MinByMaxByExamples.RunAllExamples();
                break;
            case "27":
                MinByMaxByExamples.DemonstratePerformanceComparison();
                break;
            case "28":
                NamingConventionsExamples.RunAllExamples();
                break;
            case "29":
                NamingConventionsExamples.DemonstrateBestPractices();
                break;
            case "30":
                InterpolatedStringsExamples.RunAllExamples();
                break;
            case "31":
                InterpolatedStringsExamples.DemonstrateWithExpressions();
                InterpolatedStringsExamples.DemonstrateWithFormatting();
                break;
            
            // Performance Optimization
            case "20":
                AsNoTrackingExamples.RunAllExamples();
                break;
            case "21":
                AsNoTrackingExamples.DemonstrateWithSelect();
                break;
            case "56":
                LoadingStrategiesExamples.RunAllExamples();
                break;
            case "57":
                LoadingStrategiesExamples.DemonstrateEagerLoading();
                LoadingStrategiesExamples.DemonstrateExplicitLoading();
                LoadingStrategiesExamples.DemonstrateNPlusOneProblem();
                break;
            
            // ASP.NET Core
            case "24":
                MiddlewareOrderExamples.RunAllExamples();
                break;
            case "25":
                MiddlewareOrderExamples.DemonstrateCommonMistakes();
                break;
            
            // Security
            case "32":
                SecureStringExamples.RunAllExamples();
                break;
            case "33":
                SecureStringExamples.DemonstrateSecureStringWithUsing();
                SecureStringExamples.DemonstrateBestPractices();
                break;
            
            // Object-Oriented Programming
            case "34":
                EncapsulationExamples.RunAllExamples();
                break;
            case "35":
                EncapsulationExamples.DemonstrateFullEncapsulation();
                EncapsulationExamples.DemonstrateEncapsulationWithValidation();
                break;
            case "36":
                AbstractionExamples.RunAllExamples();
                break;
            case "37":
                AbstractionExamples.DemonstrateAbstractRecord();
                AbstractionExamples.DemonstrateRealWorldAbstraction();
                break;
            case "38":
                InheritanceDIExamples.RunAllExamples();
                break;
            case "39":
                InheritanceDIExamples.DemonstrateAspNetCoreDI();
                InheritanceDIExamples.DemonstrateCompleteExample();
                break;
            case "42":
                PolymorphismExamples.RunAllExamples();
                break;
            case "43":
                PolymorphismExamples.DemonstratePolymorphismWithDI();
                PolymorphismExamples.DemonstrateMultipleImplementations();
                break;
            case "44":
                KeyClassConceptsExamples.RunAllExamples();
                break;
            case "45":
                KeyClassConceptsExamples.DemonstrateInstanceVsReference();
                KeyClassConceptsExamples.DemonstrateInstanceVsStaticVariables();
                break;
            
            // C# Fundamentals
            case "40":
                ParseVsTryParseExamples.RunAllExamples();
                break;
            case "41":
                ParseVsTryParseExamples.DemonstrateUserInput();
                ParseVsTryParseExamples.DemonstratePerformanceComparison();
                break;
            case "46":
                DateTimeExamples.RunAllExamples();
                break;
            case "47":
                DateTimeExamples.DemonstrateImmutability();
                DateTimeExamples.DemonstrateDateTimeOperations();
                DateTimeExamples.DemonstratePracticalExamples();
                break;
            case "48":
                DataTypesExamples.RunAllExamples();
                break;
            case "49":
                DataTypesExamples.DemonstrateValueVsReferenceComparison();
                DataTypesExamples.DemonstratePassingAsParameters();
                DataTypesExamples.DemonstratePracticalExamples();
                break;
            case "50":
                AttributesReflectionExamples.RunAllExamples();
                break;
            case "51":
                AttributesReflectionExamples.DemonstrateCustomAttributes();
                AttributesReflectionExamples.DemonstrateGettingAttributes();
                AttributesReflectionExamples.DemonstrateValidation();
                AttributesReflectionExamples.DemonstrateDependencyInjection();
                break;
            case "52":
                ModernLinqPatternMatchingExamples.RunAllExamples();
                break;
            case "53":
                ModernLinqPatternMatchingExamples.DemonstrateSimplifiedFiltering();
                ModernLinqPatternMatchingExamples.DemonstrateImprovedReadability();
                ModernLinqPatternMatchingExamples.DemonstrateSwitchExpressions();
                break;
            case "54":
                UnitOfWorkExamples.RunAllExamples();
                break;
            case "55":
                UnitOfWorkExamples.DemonstrateImplementation();
                UnitOfWorkExamples.DemonstrateTransactionalOperation();
                UnitOfWorkExamples.DemonstrateBestPractices();
                break;
            
            // Otros
            case "9":
                await RunAllExamples();
                break;
            default:
                Console.WriteLine("Opción no válida. Ejecutando ejemplo de comparación...\n");
                ComparisonDemo.ShowKeyDifference();
                break;
        }
    }

    static async Task RunAllExamples()
    {
        Console.WriteLine("Ejecutando todos los ejemplos...\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        ComparisonDemo.ShowKeyDifference();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        IEnumerableExample.DemonstrateClientSideExecution();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        IEnumerableExample.DemonstrateDeferredExecution();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        IEnumerableExample.DemonstratePerformance();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        await IQueryableExample.DemonstrateServerSideExecution();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        await IQueryableExample.DemonstrateQueryTranslation();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        await IQueryableExample.DemonstratePerformance();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        await IQueryableExample.DemonstrateCommonMistake();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  NULL ARGUMENT CHECKS");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        NullCheckExamples.DemonstrateNullChecks();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        NullCheckExamples.DemonstratePracticalUsage();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        NullCheckExamples.DemonstrateMultipleValidations();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  TRYGETVALUE - EVITAR DOBLE BÚSQUEDA");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        TryGetValueExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  CLEAN CODE - AVOID TOO MANY ARGUMENTS");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        AvoidTooManyArgumentsExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  CLEAN CODE - PREFER IENUMERABLE<T> OVER LIST<T>");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        IEnumerableVsListExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  CLEAN CODE - NESTED LOOPS VS SELECTMANY");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        SelectManyExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  CLEAN CODE - MINBY/MAXBY VS ORDERBY+FIRST");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        MinByMaxByExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  CLEAN CODE - NAMING CONVENTIONS");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        NamingConventionsExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  CLEAN CODE - INTERPOLATED STRINGS");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        InterpolatedStringsExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  PERFORMANCE OPTIMIZATION - ASNOTRACKING() EF CORE");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        AsNoTrackingExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  PERFORMANCE OPTIMIZATION - LOADING STRATEGIES");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        LoadingStrategiesExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ASP.NET CORE - MIDDLEWARE ORDER");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        MiddlewareOrderExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  SECURITY - SECURESTRING");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        SecureStringExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  OOP - ENCAPSULATION");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        EncapsulationExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  OOP - ABSTRACTION");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        AbstractionExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  OOP - INHERITANCE + DEPENDENCY INJECTION");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        InheritanceDIExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  OOP - POLYMORPHISM");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        PolymorphismExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  OOP - KEY CLASS CONCEPTS");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        KeyClassConceptsExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  C# FUNDAMENTALS - INT.PARSE() VS INT.TRYPARSE()");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        ParseVsTryParseExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  C# FUNDAMENTALS - DATE & TIME");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        DateTimeExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  C# FUNDAMENTALS - DATA TYPES");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        DataTypesExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  C# FUNDAMENTALS - ATTRIBUTES & REFLECTION");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        AttributesReflectionExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  C# FUNDAMENTALS - MODERN LINQ WITH PATTERN MATCHING");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        ModernLinqPatternMatchingExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  DESIGN PATTERNS - UNIT OF WORK");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        UnitOfWorkExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              Todos los ejemplos completados ✅                ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");
    }
}

