using NetMasteryLab.Concepts.IEnumerableVsIQueryable.Examples;
using NetMasteryLab.Concepts.NullArgumentChecks.Examples;
using NetMasteryLab.Concepts.TryGetValueAvoidDoubleLookup.Examples;
using NetMasteryLab.Concepts.CleanCode.AvoidTooManyArguments.Examples;
using NetMasteryLab.Concepts.CleanCode.PreferIEnumerableOverList.Examples;
using NetMasteryLab.Concepts.CleanCode.NestedLoopsVsSelectMany.Examples;
using NetMasteryLab.Concepts.CleanCode.MinByMaxByInsteadOfOrderBy.Examples;
using NetMasteryLab.Concepts.CleanCode.NamingConventions.Examples;
using NetMasteryLab.Concepts.CleanCode.InterpolatedStrings.Examples;
using NetMasteryLab.Concepts.CleanCode.ClearDescriptivePropertyNames.Examples;
using NetMasteryLab.Concepts.PerformanceOptimization.AsNoTrackingEFCore.Examples;
using NetMasteryLab.Concepts.PerformanceOptimization.LoadingStrategies.Examples;
using NetMasteryLab.Concepts.PerformanceOptimization.StringVsStringBuilder.Examples;
using NetMasteryLab.Concepts.AspNetCore.MiddlewareOrder.Examples;
using NetMasteryLab.Concepts.AspNetCore.MvcRequestLifecycle.Examples;
using NetMasteryLab.Concepts.AspNetCore.MinimalApis.Examples;
using NetMasteryLab.Concepts.AspNetCore.WebApiActionSelection.Examples;
using NetMasteryLab.Concepts.AspNetCore.ScrutorAutoRegister.Examples;
using NetMasteryLab.Concepts.AspNetCore.AutoMapperObjectMapping.Examples;
using NetMasteryLab.Concepts.AspNetCore.Logging.Examples;
using NetMasteryLab.Concepts.Security.SecureStringExamples.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.Encapsulation.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.Abstraction.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.InheritanceVirtualOverrideDI.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.Polymorphism.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.TypesOfInheritance.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.KeyClassConcepts.Examples;
using NetMasteryLab.Concepts.ObjectOrientedProgramming.AbstractClassVsInterface.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.ParseVsTryParse.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.DateTimeExamples.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.DataTypes.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.AttributesReflection.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.ModernLinqPatternMatching.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.PrimaryConstructors.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.Keywords.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.ModernFeatures.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.Collections.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.LinqToSqlVsObjects.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.LinqMethods.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.EssentialCSharpFeatures.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.ArraysVsArrayList.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.PassByReferenceVsValue.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.ListVsHashSet.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.CSharpEnhancementsNet9.Examples;
using NetMasteryLab.Concepts.CSharpFundamentals.SwitchExpressions.Examples;
using NetMasteryLab.Concepts.DesignPatterns.UnitOfWork.Examples;
using NetMasteryLab.Concepts.EntityFrameworkCore.Examples;
using NetMasteryLab.Concepts.EntityFrameworkCore.EfCore9Features.Examples;
using NetMasteryLab.Concepts.Database.SqlQueryOptimization.Examples;

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
        Console.WriteLine("  30. Clear & Descriptive Property Names - Comparación");
        Console.WriteLine("  31. Clear & Descriptive Property Names - Ejemplos prácticos");
        Console.WriteLine("  32. Interpolated Strings vs string.Format - Comparación");
        Console.WriteLine("  33. Interpolated Strings vs string.Format - Ejemplos prácticos\n");
        
        Console.WriteLine("🚀 Performance Optimization:");
        Console.WriteLine("  20. AsNoTracking() EF Core - Comparación");
        Console.WriteLine("  21. AsNoTracking() EF Core - Ejemplos prácticos");
        Console.WriteLine("  56. Loading Strategies (Eager/Lazy/Explicit) - Comparación");
        Console.WriteLine("  57. Loading Strategies (Eager/Lazy/Explicit) - Ejemplos prácticos");
        Console.WriteLine("  68. String vs StringBuilder - Comparación");
        Console.WriteLine("  69. String vs StringBuilder - Ejemplos prácticos\n");
        
        Console.WriteLine("🌐 ASP.NET Core:");
        Console.WriteLine("  24. Middleware Order - Orden correcto");
        Console.WriteLine("  25. Middleware Order - Ejemplos prácticos");
        Console.WriteLine("  26. MVC Request Life Cycle - Comparación");
        Console.WriteLine("  27. MVC Request Life Cycle - Ejemplos prácticos");
        Console.WriteLine("  28. Minimal APIs - Comparación");
        Console.WriteLine("  29. Minimal APIs - Ejemplos prácticos");
        Console.WriteLine("  30. Web API Action Selection - Comparación");
        Console.WriteLine("  31. Web API Action Selection - Ejemplos prácticos");
        Console.WriteLine("  32. Scrutor Auto-Register - Comparación");
        Console.WriteLine("  33. Scrutor Auto-Register - Ejemplos prácticos");
        Console.WriteLine("  34. AutoMapper Object Mapping - Comparación");
        Console.WriteLine("  35. AutoMapper Object Mapping - Ejemplos prácticos");
        Console.WriteLine("  36. Logging in .NET Core - Comparación");
        Console.WriteLine("  37. Logging in .NET Core - Ejemplos prácticos\n");
        
        Console.WriteLine("🔒 Security:");
        Console.WriteLine("  38. SecureString - Comparación");
        Console.WriteLine("  39. SecureString - Ejemplos prácticos\n");
        
        Console.WriteLine("🎯 Object-Oriented Programming (OOP):");
        Console.WriteLine("  40. Encapsulation - Comparación");
        Console.WriteLine("  41. Encapsulation - Ejemplos prácticos");
        Console.WriteLine("  42. Abstraction - Comparación");
        Console.WriteLine("  43. Abstraction - Ejemplos prácticos");
        Console.WriteLine("  44. Inheritance + DI - Comparación");
        Console.WriteLine("  45. Inheritance + DI - Ejemplos prácticos");
        Console.WriteLine("  46. Types of Inheritance - Comparación");
        Console.WriteLine("  47. Types of Inheritance - Ejemplos prácticos");
        Console.WriteLine("  48. Polymorphism - Comparación");
        Console.WriteLine("  49. Polymorphism - Ejemplos prácticos");
        Console.WriteLine("  50. Key Class Concepts - Comparación");
        Console.WriteLine("  51. Key Class Concepts - Ejemplos prácticos");
        Console.WriteLine("  52. Abstract Class vs Interface - Comparación");
        Console.WriteLine("  53. Abstract Class vs Interface - Ejemplos prácticos\n");
        
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
        Console.WriteLine("  53. Modern LINQ with Pattern Matching - Ejemplos prácticos");
        Console.WriteLine("  58. Primary Constructors - Comparación");
        Console.WriteLine("  60. Keywords en C# - Comparación");
        Console.WriteLine("  61. Keywords en C# - Ejemplos prácticos");
        Console.WriteLine("  62. Modern C# Features - Comparación");
        Console.WriteLine("  63. Modern C# Features - Ejemplos prácticos");
        Console.WriteLine("  64. Collections en C# - Comparación");
        Console.WriteLine("  65. Collections en C# - Ejemplos prácticos");
        Console.WriteLine("  66. LINQ to SQL vs LINQ to Objects - Comparación");
        Console.WriteLine("  67. LINQ to SQL vs LINQ to Objects - Ejemplos prácticos");
        Console.WriteLine("  70. Métodos LINQ - Comparación");
        Console.WriteLine("  72. Métodos LINQ - Ejemplos prácticos");
        Console.WriteLine("  73. Top 20 Características Esenciales de C# - Comparación");
        Console.WriteLine("  74. Top 20 Características Esenciales de C# - Ejemplos prácticos");
        Console.WriteLine("  77. Arrays vs ArrayList - Comparación");
        Console.WriteLine("  78. Arrays vs ArrayList - Ejemplos prácticos");
        Console.WriteLine("  81. Pass By Reference vs Pass By Value - Comparación");
        Console.WriteLine("  82. Pass By Reference vs Pass By Value - Ejemplos prácticos");
        Console.WriteLine("  83. List vs HashSet - Comparación");
        Console.WriteLine("  84. List vs HashSet - Ejemplos prácticos");
        Console.WriteLine("  87. C# Enhancements in .NET 9.0 - Comparación");
        Console.WriteLine("  88. C# Enhancements in .NET 9.0 - Ejemplos prácticos");
        Console.WriteLine("  91. Switch Expressions - Comparación");
        Console.WriteLine("  92. Switch Expressions - Ejemplos prácticos\n");
        
        Console.WriteLine("🗄️ Database & SQL Optimization:");
        Console.WriteLine("  75. Optimización de Consultas SQL - Comparación");
        Console.WriteLine("  76. Optimización de Consultas SQL - Ejemplos prácticos\n");
        
        Console.WriteLine("🚀 Entity Framework Core:");
        Console.WriteLine("  79. Entity Framework Core - Comparación");
        Console.WriteLine("  80. Entity Framework Core - Ejemplos prácticos");
        Console.WriteLine("  85. EF Core 9.0 - Nuevas Características - Comparación");
        Console.WriteLine("  86. EF Core 9.0 - Nuevas Características - Ejemplos prácticos\n");
        
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
                ClearDescriptivePropertyNamesExamples.RunAllExamples();
                break;
            case "31":
                ClearDescriptivePropertyNamesExamples.DemonstrateClearDescriptiveNames();
                ClearDescriptivePropertyNamesExamples.DemonstrateAvoidAmbiguity();
                ClearDescriptivePropertyNamesExamples.DemonstrateConsistency();
                ClearDescriptivePropertyNamesExamples.DemonstrateBeforeAfter();
                break;
            case "32":
                InterpolatedStringsExamples.RunAllExamples();
                break;
            case "33":
                InterpolatedStringsExamples.DemonstrateWithExpressions();
                InterpolatedStringsExamples.DemonstrateWithFormatting();
                InterpolatedStringsExamples.DemonstrateNet9Improvements();
                break;
            
            // Performance Optimization
            case "20":
                AsNoTrackingExamples.RunAllExamples();
                break;
            case "21":
                AsNoTrackingExamples.DemonstrateWithSelect();
                break;
            
            // ASP.NET Core
            case "24":
                MiddlewareOrderExamples.RunAllExamples();
                break;
            case "25":
                MiddlewareOrderExamples.DemonstrateCommonMistakes();
                break;
            case "34":
                AutoMapperExamples.RunAllExamples();
                break;
            case "35":
                AutoMapperExamples.DemonstrateComparison();
                AutoMapperExamples.DemonstrateHowItWorks();
                AutoMapperExamples.DemonstratePracticalExamples();
                break;
            case "36":
                LoggingExamples.RunAllExamples();
                break;
            case "37":
                LoggingExamples.DemonstrateBuiltInLogger();
                LoggingExamples.DemonstrateSerilog();
                LoggingExamples.DemonstrateNLog();
                LoggingExamples.DemonstrateBestPractices();
                break;
            
            // Security
            case "38":
                SecureStringExamples.RunAllExamples();
                break;
            case "39":
                SecureStringExamples.DemonstrateSecureStringWithUsing();
                SecureStringExamples.DemonstrateBestPractices();
                break;
            
            // Object-Oriented Programming
            case "40":
                EncapsulationExamples.RunAllExamples();
                break;
            case "41":
                EncapsulationExamples.DemonstrateFullEncapsulation();
                EncapsulationExamples.DemonstrateEncapsulationWithValidation();
                break;
            case "42":
                AbstractionExamples.RunAllExamples();
                break;
            case "43":
                AbstractionExamples.DemonstrateAbstractRecord();
                AbstractionExamples.DemonstrateRealWorldAbstraction();
                break;
            case "44":
                InheritanceDIExamples.RunAllExamples();
                break;
            case "45":
                InheritanceDIExamples.DemonstrateAspNetCoreDI();
                InheritanceDIExamples.DemonstrateCompleteExample();
                break;
            case "46":
                TypesOfInheritanceExamples.RunAllExamples();
                break;
            case "47":
                TypesOfInheritanceExamples.DemonstrateSingleInheritance();
                TypesOfInheritanceExamples.DemonstrateMultipleInheritance();
                TypesOfInheritanceExamples.DemonstrateMultilevelInheritance();
                TypesOfInheritanceExamples.DemonstrateHierarchicalInheritance();
                TypesOfInheritanceExamples.DemonstrateHybridInheritance();
                break;
            case "48":
                PolymorphismExamples.RunAllExamples();
                break;
            case "49":
                PolymorphismExamples.DemonstratePolymorphismWithDI();
                PolymorphismExamples.DemonstrateMultipleImplementations();
                break;
            case "50":
                KeyClassConceptsExamples.RunAllExamples();
                break;
            case "51":
                KeyClassConceptsExamples.DemonstrateInstanceVsReference();
                KeyClassConceptsExamples.DemonstrateInstanceVsStaticVariables();
                break;
            case "52":
                AbstractClassVsInterfaceExamples.RunAllExamples();
                break;
            case "53":
                AbstractClassVsInterfaceExamples.DemonstrateComparison();
                AbstractClassVsInterfaceExamples.DemonstrateWhenToUse();
                break;
            
            // C# Fundamentals
            case "54":
                ParseVsTryParseExamples.RunAllExamples();
                break;
            case "55":
                ParseVsTryParseExamples.DemonstrateUserInput();
                ParseVsTryParseExamples.DemonstratePerformanceComparison();
                break;
            case "56":
                DateTimeExamples.RunAllExamples();
                break;
            case "57":
                DateTimeExamples.DemonstrateImmutability();
                DateTimeExamples.DemonstrateDateTimeOperations();
                DateTimeExamples.DemonstratePracticalExamples();
                break;
            case "58":
                DataTypesExamples.RunAllExamples();
                break;
            case "59":
                DataTypesExamples.DemonstrateValueVsReferenceComparison();
                DataTypesExamples.DemonstratePassingAsParameters();
                DataTypesExamples.DemonstratePracticalExamples();
                break;
            case "60":
                AttributesReflectionExamples.RunAllExamples();
                break;
            case "61":
                AttributesReflectionExamples.DemonstrateCustomAttributes();
                AttributesReflectionExamples.DemonstrateGettingAttributes();
                AttributesReflectionExamples.DemonstrateValidation();
                AttributesReflectionExamples.DemonstrateDependencyInjection();
                break;
            case "62":
                ModernLinqPatternMatchingExamples.RunAllExamples();
                break;
            case "63":
                ModernLinqPatternMatchingExamples.DemonstrateSimplifiedFiltering();
                ModernLinqPatternMatchingExamples.DemonstrateImprovedReadability();
                ModernLinqPatternMatchingExamples.DemonstrateSwitchExpressions();
                break;
            case "64":
                KeywordsExamples.RunAllExamples();
                break;
            case "65":
                KeywordsExamples.DemonstrateAccessModifiers();
                KeywordsExamples.DemonstrateDeclarationKeywords();
                KeywordsExamples.DemonstrateControlFlow();
                break;
            case "66":
                ModernFeaturesExamples.RunAllExamples();
                break;
            case "67":
                ModernFeaturesExamples.DemonstrateNullHandling();
                ModernFeaturesExamples.DemonstratePatternMatching();
                ModernFeaturesExamples.DemonstrateNameof();
                break;
            case "68":
                PrimaryConstructorsExamples.RunAllExamples();
                break;
            case "69":
                PrimaryConstructorsExamples.DemonstrateCodeReduction();
                PrimaryConstructorsExamples.DemonstrateServiceClasses();
                PrimaryConstructorsExamples.DemonstrateWithRecords();
                break;
            case "70":
                CollectionsExamples.RunAllExamples();
                break;
            case "71":
                CollectionsExamples.DemonstrateGenericCollections();
                CollectionsExamples.DemonstrateConcurrentCollections();
                CollectionsExamples.DemonstrateWhenToUse();
                break;
            case "72":
                LinqToSqlVsObjectsExamples.RunAllExamples();
                break;
            case "73":
                LinqToSqlVsObjectsExamples.DemonstrateLinqToSql();
                LinqToSqlVsObjectsExamples.DemonstrateLinqToObjects();
                LinqToSqlVsObjectsExamples.DemonstrateKeyDifferences();
                LinqToSqlVsObjectsExamples.DemonstrateWhenToUse();
                break;
            case "74":
                LinqMethodsExamples.RunAllExamples();
                break;
            case "75":
                LinqMethodsExamples.DemonstrateFiltering();
                LinqMethodsExamples.DemonstrateProjection();
                LinqMethodsExamples.DemonstrateAggregation();
                LinqMethodsExamples.DemonstrateQuantifiers();
                LinqMethodsExamples.DemonstrateSetOperations();
                break;
            case "76":
                EssentialCSharpFeaturesExamples.RunAllExamples();
                break;
            case "77":
                EssentialCSharpFeaturesExamples.DemonstrateGenerics();
                EssentialCSharpFeaturesExamples.DemonstrateTuples();
                EssentialCSharpFeaturesExamples.DemonstrateAsyncAwait();
                EssentialCSharpFeaturesExamples.DemonstrateRecords();
                EssentialCSharpFeaturesExamples.DemonstrateCollectionExpressions();
                break;
            case "78":
                ArraysVsArrayListExamples.RunAllExamples();
                break;
            case "79":
                ArraysVsArrayListExamples.DemonstrateArrays();
                ArraysVsArrayListExamples.DemonstrateList();
                ArraysVsArrayListExamples.DemonstrateKeyDifferences();
                ArraysVsArrayListExamples.DemonstrateWhenToUse();
                break;
            case "80":
                PassByReferenceVsValueExamples.RunAllExamples();
                break;
            case "81":
                PassByReferenceVsValueExamples.DemonstratePassByReference();
                PassByReferenceVsValueExamples.DemonstratePassByValue();
                PassByReferenceVsValueExamples.DemonstrateDifference();
                PassByReferenceVsValueExamples.DemonstrateOutParameters();
                break;
            case "82":
                ListVsHashSetExamples.RunAllExamples();
                break;
            case "83":
                ListVsHashSetExamples.DemonstrateList();
                ListVsHashSetExamples.DemonstrateHashSet();
                ListVsHashSetExamples.DemonstrateVisualComparison();
                ListVsHashSetExamples.DemonstrateKeyDifferences();
                break;
            case "84":
                CSharpEnhancementsNet9Examples.RunAllExamples();
                break;
            case "85":
                CSharpEnhancementsNet9Examples.DemonstratePrimaryConstructors();
                CSharpEnhancementsNet9Examples.DemonstrateAutoDefaultStructs();
                CSharpEnhancementsNet9Examples.DemonstrateEnhancedPatternMatching();
                break;
            case "86":
                SqlQueryOptimizationExamples.RunAllExamples();
                break;
            case "87":
                SqlQueryOptimizationExamples.DemonstrateWhyOptimize();
                SqlQueryOptimizationExamples.DemonstrateKeyFactors();
                SqlQueryOptimizationExamples.DemonstrateBestPractices();
                SqlQueryOptimizationExamples.DemonstrateOptimizedQueries();
                break;
            case "88":
                EntityFrameworkCoreExamples.RunAllExamples();
                break;
            case "89":
                EntityFrameworkCoreExamples.DemonstrateWhatIsEfCore();
                EntityFrameworkCoreExamples.DemonstrateWhyUseEfCore();
                EntityFrameworkCoreExamples.DemonstrateHowEfCoreWorks();
                EntityFrameworkCoreExamples.DemonstrateCrudOperations();
                break;
            case "90":
                EfCore9FeaturesExamples.RunAllExamples();
                break;
            case "91":
                SwitchExpressionsExamples.RunAllExamples();
                break;
            case "92":
                SwitchExpressionsExamples.DemonstrateComparison();
                SwitchExpressionsExamples.DemonstratePerfectUseCases();
                SwitchExpressionsExamples.DemonstrateWithPatternMatching();
                break;
            case "93":
                UnitOfWorkExamples.RunAllExamples();
                break;
            case "94":
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
        Console.WriteLine("  ASP.NET CORE - MVC REQUEST LIFE CYCLE");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        MvcRequestLifecycleExamples.RunAllExamples();
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
        Console.WriteLine("  OOP - ABSTRACT CLASS VS INTERFACE");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        AbstractClassVsInterfaceExamples.RunAllExamples();
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
        Console.WriteLine("  C# FUNDAMENTALS - PRIMARY CONSTRUCTORS");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        PrimaryConstructorsExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  C# FUNDAMENTALS - KEYWORDS");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        KeywordsExamples.RunAllExamples();
        await Task.Delay(2000);

        Console.WriteLine("\n\n");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  C# FUNDAMENTALS - MODERN C# FEATURES");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        ModernFeaturesExamples.RunAllExamples();
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

