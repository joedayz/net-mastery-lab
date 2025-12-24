using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetMasteryLab.Concepts.ObjectOrientedProgramming.TypesOfInheritance.Examples
{
    /// <summary>
    /// Ejemplos que demuestran los diferentes tipos de herencia en .NET Core
    /// </summary>
    public class TypesOfInheritanceExamples
    {
        /// <summary>
        /// Demuestra Single Inheritance (Herencia Simple)
        /// </summary>
        public static void DemonstrateSingleInheritance()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣ Single Inheritance (Herencia Simple)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Ejemplo: Vehicle → Car");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Vehicle");
            Console.WriteLine("{");
            Console.WriteLine("    public int Speed { get; set; }");
            Console.WriteLine("    public string Color { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("public class Car : Vehicle");
            Console.WriteLine("{");
            Console.WriteLine("    public int NumberOfDoors { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            var car = new Car { Speed = 100, Color = "Red", NumberOfDoors = 4 };
            Console.WriteLine($"Ejemplo práctico:");
            Console.WriteLine($"  car.Speed = {car.Speed} (heredado de Vehicle)");
            Console.WriteLine($"  car.Color = {car.Color} (heredado de Vehicle)");
            Console.WriteLine($"  car.NumberOfDoors = {car.NumberOfDoors} (propio de Car)\n");

            Console.WriteLine("✅ Caso de Uso en .NET Core:");
            Console.WriteLine("  BaseService → OrderService (funcionalidad común como logging)\n");
        }

        /// <summary>
        /// Demuestra Multiple Inheritance via Interfaces
        /// </summary>
        public static void DemonstrateMultipleInheritance()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  2️⃣ Multiple Inheritance (Herencia Múltiple vía Interfaces)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Ejemplo: ILogger + IDisposable");
            Console.WriteLine("```csharp");
            Console.WriteLine("public interface ILogger { void Log(string message); }");
            Console.WriteLine("public interface IDisposable { void Dispose(); }");
            Console.WriteLine("");
            Console.WriteLine("public class FileLogger : ILogger, IDisposable");
            Console.WriteLine("{");
            Console.WriteLine("    public void Log(string message) { }");
            Console.WriteLine("    public void Dispose() { }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            var logger = new FileLogger();
            logger.Log("Test message");
            logger.Dispose();
            Console.WriteLine("Ejemplo práctico:");
            Console.WriteLine("  FileLogger implementa ILogger y IDisposable\n");

            Console.WriteLine("✅ Caso de Uso en .NET Core:");
            Console.WriteLine("  Dependency Injection: IRepository + IValidator + IDisposable\n");
        }

        /// <summary>
        /// Demuestra Multilevel Inheritance
        /// </summary>
        public static void DemonstrateMultilevelInheritance()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  3️⃣ Multilevel Inheritance (Herencia Multinivel)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Ejemplo: Vehicle → Car → ElectricCar");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Vehicle { public int Speed { get; set; } }");
            Console.WriteLine("public class Car : Vehicle { public int Doors { get; set; } }");
            Console.WriteLine("public class ElectricCar : Car { public int Battery { get; set; } }");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            var electricCar = new ElectricCar 
            { 
                Speed = 120,      // De Vehicle
                NumberOfDoors = 4, // De Car
                BatteryCapacity = 100 // Propio
            };
            Console.WriteLine($"Ejemplo práctico:");
            Console.WriteLine($"  electricCar.Speed = {electricCar.Speed} (de Vehicle)");
            Console.WriteLine($"  electricCar.NumberOfDoors = {electricCar.NumberOfDoors} (de Car)");
            Console.WriteLine($"  electricCar.BatteryCapacity = {electricCar.BatteryCapacity} (propio)\n");

            Console.WriteLine("✅ Caso de Uso en .NET Core:");
            Console.WriteLine("  BaseService → CrudService → OrderService (servicios en capas)\n");
        }

        /// <summary>
        /// Demuestra Hierarchical Inheritance
        /// </summary>
        public static void DemonstrateHierarchicalInheritance()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  4️⃣ Hierarchical Inheritance (Herencia Jerárquica)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Ejemplo: Vehicle → Car, Bike, Truck");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Vehicle { public int Speed { get; set; } }");
            Console.WriteLine("public class Car : Vehicle { }");
            Console.WriteLine("public class Bike : Vehicle { }");
            Console.WriteLine("public class Truck : Vehicle { }");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            var car = new Car { Speed = 100 };
            var bike = new Bike { Speed = 30 };
            var truck = new Truck { Speed = 80 };
            
            Console.WriteLine($"Ejemplo práctico:");
            Console.WriteLine($"  car.Speed = {car.Speed} (heredado de Vehicle)");
            Console.WriteLine($"  bike.Speed = {bike.Speed} (heredado de Vehicle)");
            Console.WriteLine($"  truck.Speed = {truck.Speed} (heredado de Vehicle)\n");

            Console.WriteLine("✅ Caso de Uso en .NET Core:");
            Console.WriteLine("  BaseController → OrdersController, ProductsController, CustomersController\n");
        }

        /// <summary>
        /// Demuestra Hybrid Inheritance
        /// </summary>
        public static void DemonstrateHybridInheritance()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  5️⃣ Hybrid Inheritance (Herencia Híbrida)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Ejemplo: BaseEntity + IAuditable + ISoftDeletable");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class BaseEntity { public int Id { get; set; } }");
            Console.WriteLine("public interface IAuditable { string CreatedBy { get; set; } }");
            Console.WriteLine("public interface ISoftDeletable { bool IsDeleted { get; set; } }");
            Console.WriteLine("");
            Console.WriteLine("public class Order : BaseEntity, IAuditable, ISoftDeletable");
            Console.WriteLine("{");
            Console.WriteLine("    public string CreatedBy { get; set; }");
            Console.WriteLine("    public bool IsDeleted { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            var order = new Order 
            { 
                Id = 1,              // De BaseEntity
                CreatedBy = "Admin", // De IAuditable
                IsDeleted = false    // De ISoftDeletable
            };
            Console.WriteLine($"Ejemplo práctico:");
            Console.WriteLine($"  order.Id = {order.Id} (de BaseEntity)");
            Console.WriteLine($"  order.CreatedBy = {order.CreatedBy} (de IAuditable)");
            Console.WriteLine($"  order.IsDeleted = {order.IsDeleted} (de ISoftDeletable)\n");

            Console.WriteLine("✅ Caso de Uso en .NET Core:");
            Console.WriteLine("  Clean Architecture: BaseEntity + múltiples interfaces\n");
        }

        /// <summary>
        /// Demuestra beneficios de la herencia
        /// </summary>
        public static void DemonstrateBenefits()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Beneficios de Usar Herencia en .NET Core");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Code Reusability (Reutilización de Código)");
            Console.WriteLine("   • Evita duplicación de código");
            Console.WriteLine("   • Reduce el tamaño del código");
            Console.WriteLine("   • Facilita el mantenimiento\n");

            Console.WriteLine("✅ Maintainability (Mantenibilidad)");
            Console.WriteLine("   • Cambios centralizados se propagan automáticamente");
            Console.WriteLine("   • Fácil actualizar funcionalidad común\n");

            Console.WriteLine("✅ Scalability (Escalabilidad)");
            Console.WriteLine("   • Fácil agregar nuevas funcionalidades");
            Console.WriteLine("   • Extensión sin modificar código existente\n");

            Console.WriteLine("✅ Polymorphism (Polimorfismo)");
            Console.WriteLine("   • Tratamiento uniforme de objetos diferentes");
            Console.WriteLine("   • Flexibilidad en tiempo de ejecución\n");
        }

        /// <summary>
        /// Demuestra comparación de tipos
        /// </summary>
        public static void DemonstrateComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Comparación de Tipos de Herencia");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("┌──────────────────┬─────────────────────────────────────────────┬──────────────────────────────┐");
            Console.WriteLine("│ Tipo             │ Cuándo Usar                                │ Ejemplo en .NET Core         │");
            Console.WriteLine("├──────────────────┼─────────────────────────────────────────────┼──────────────────────────────┤");
            Console.WriteLine("│ Single           │ Funcionalidad común simple                 │ BaseService → OrderService   │");
            Console.WriteLine("│ Multiple         │ Contratos múltiples, DI                    │ IRepository + IValidator     │");
            Console.WriteLine("│ Multilevel       │ Extensión gradual                          │ Vehicle → Car → ElectricCar  │");
            Console.WriteLine("│ Hierarchical     │ Controllers, Services comunes              │ BaseController → OrdersCtrl   │");
            Console.WriteLine("│ Hybrid           │ Arquitecturas complejas                    │ BaseEntity + IAuditable       │");
            Console.WriteLine("└──────────────────┴─────────────────────────────────────────────┴──────────────────────────────┘\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Types of Inheritance in .NET Core                        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateSingleInheritance();
            Console.WriteLine("\n");
            DemonstrateMultipleInheritance();
            Console.WriteLine("\n");
            DemonstrateMultilevelInheritance();
            Console.WriteLine("\n");
            DemonstrateHierarchicalInheritance();
            Console.WriteLine("\n");
            DemonstrateHybridInheritance();
            Console.WriteLine("\n");
            DemonstrateBenefits();
            Console.WriteLine("\n");
            DemonstrateComparison();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Tipos de Herencia en .NET Core:");
            Console.WriteLine("   1. Single Inheritance: Una clase hereda de una base");
            Console.WriteLine("   2. Multiple Inheritance: Múltiples interfaces");
            Console.WriteLine("   3. Multilevel Inheritance: Cadena de herencia");
            Console.WriteLine("   4. Hierarchical Inheritance: Múltiples clases de una base");
            Console.WriteLine("   5. Hybrid Inheritance: Clase base + interfaces\n");
            
            Console.WriteLine("🚀 Beneficios Generales:");
            Console.WriteLine("   • ✅ Code Reusability: Reutilización sin duplicación");
            Console.WriteLine("   • ✅ Maintainability: Cambios centralizados");
            Console.WriteLine("   • ✅ Scalability: Fácil extensión");
            Console.WriteLine("   • ✅ Polymorphism: Tratamiento uniforme\n");
        }
    }

    // Clases de ejemplo para demostración

    // Single Inheritance
    public class Vehicle
    {
        public int Speed { get; set; }
        public string Color { get; set; } = string.Empty;
    }

    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
    }

    // Multiple Inheritance via Interfaces
    public interface ILogger
    {
        void Log(string message);
    }

    public interface IDisposable
    {
        void Dispose();
    }

    public class FileLogger : ILogger, IDisposable
    {
        public void Log(string message) => Console.WriteLine($"Log: {message}");
        public void Dispose() => Console.WriteLine("Disposing resources");
    }

    // Multilevel Inheritance
    public class ElectricCar : Car
    {
        public int BatteryCapacity { get; set; }
    }

    // Hierarchical Inheritance
    public class Bike : Vehicle
    {
        public bool HasBasket { get; set; }
    }

    public class Truck : Vehicle
    {
        public int LoadCapacity { get; set; }
    }

    // Hybrid Inheritance
    public class BaseEntity
    {
        public int Id { get; set; }
    }

    public interface IAuditable
    {
        string CreatedBy { get; set; }
    }

    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }

    public class Order : BaseEntity, IAuditable, ISoftDeletable
    {
        public string CreatedBy { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}

