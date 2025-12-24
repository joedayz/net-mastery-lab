namespace NetMasteryLab.Concepts.ObjectOrientedProgramming.AbstractClassVsInterface.Examples
{
    /// <summary>
    /// Ejemplos que demuestran las diferencias entre Abstract Class e Interface
    /// </summary>
    public class AbstractClassVsInterfaceExamples
    {
        /// <summary>
        /// Demuestra la comparación visual entre Abstract Class e Interface
        /// </summary>
        public static void DemonstrateComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Comparación: Abstract Class vs Interface");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("┌─────────────────────┬──────────────────┬──────────────────┐");
            Console.WriteLine("│ Aspecto             │ Abstract Class   │ Interface        │");
            Console.WriteLine("├─────────────────────┼──────────────────┼──────────────────┤");
            Console.WriteLine("│ Methods             │ Abstract + Concreto│ Principalmente   │");
            Console.WriteLine("│                     │                  │ declaraciones    │");
            Console.WriteLine("│ Keyword              │ abstract         │ interface        │");
            Console.WriteLine("│ Inheritance         │ Simple (una)     │ Múltiple         │");
            Console.WriteLine("│ Constructors        │ Sí               │ No               │");
            Console.WriteLine("│ Access Modifiers    │ Todos            │ Principalmente   │");
            Console.WriteLine("│                     │                  │ public           │");
            Console.WriteLine("│ Fields              │ Sí               │ No (solo props) │");
            Console.WriteLine("│ Purpose             │ Comportamiento   │ Contrato         │");
            Console.WriteLine("│                     │ común            │                  │");
            Console.WriteLine("└─────────────────────┴──────────────────┴──────────────────┘\n");
        }

        /// <summary>
        /// Demuestra Implementation (Implementación)
        /// </summary>
        public static void DemonstrateImplementation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📌 1. Implementation (Implementación)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("🟢 Abstract Class:");
            Console.WriteLine("  Puede tener métodos abstractos (sin cuerpo) y concretos (con cuerpo)\n");

            Console.WriteLine("Ejemplo Abstract Class:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public abstract class Animal");
            Console.WriteLine("{");
            Console.WriteLine("    protected string Name { get; set; }");
            Console.WriteLine("    ");
            Console.WriteLine("    public Animal(string name) { Name = name; }");
            Console.WriteLine("    ");
            Console.WriteLine("    // Método abstracto (sin implementación)");
            Console.WriteLine("    public abstract void MakeSound();");
            Console.WriteLine("    ");
            Console.WriteLine("    // Método concreto (con implementación)");
            Console.WriteLine("    public void Sleep()");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine($\"{Name} is sleeping\");");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("🔵 Interface:");
            Console.WriteLine("  Principalmente declaraciones de métodos. Desde C# 8.0, también definiciones\n");

            Console.WriteLine("Ejemplo Interface:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public interface IAnimal");
            Console.WriteLine("{");
            Console.WriteLine("    // Declaración de método");
            Console.WriteLine("    void MakeSound();");
            Console.WriteLine("    ");
            Console.WriteLine("    // Propiedad (no campos)");
            Console.WriteLine("    string Name { get; set; }");
            Console.WriteLine("    ");
            Console.WriteLine("    // Implementación por defecto (C# 8.0+)");
            Console.WriteLine("    void Sleep()");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine(\"Animal is sleeping\");");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra Inheritance (Herencia)
        /// </summary>
        public static void DemonstrateInheritance()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📌 2. Inheritance (Herencia)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("🟢 Abstract Class:");
            Console.WriteLine("  Una clase puede heredar de SOLO UNA clase abstracta (herencia simple)\n");

            Console.WriteLine("```csharp");
            Console.WriteLine("public abstract class Vehicle { }");
            Console.WriteLine("public class Car : Vehicle { } // ✅ Correcto");
            Console.WriteLine("// public class HybridCar : Vehicle, ElectricVehicle // ❌ Error");
            Console.WriteLine("```\n");

            Console.WriteLine("🔵 Interface:");
            Console.WriteLine("  Una clase puede implementar MÚLTIPLES interfaces (herencia múltiple)\n");

            Console.WriteLine("```csharp");
            Console.WriteLine("public interface IVehicleFeatures { }");
            Console.WriteLine("public interface IMaintenance { }");
            Console.WriteLine("");
            Console.WriteLine("public class Car : IVehicleFeatures, IMaintenance");
            Console.WriteLine("{");
            Console.WriteLine("    // Implementa ambas interfaces");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra Access Modifiers
        /// </summary>
        public static void DemonstrateAccessModifiers()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📌 3. Access Modifiers (Modificadores de Acceso)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("🟢 Abstract Class:");
            Console.WriteLine("  Puede definir métodos con varios modificadores de acceso\n");

            Console.WriteLine("```csharp");
            Console.WriteLine("public abstract class Animal");
            Console.WriteLine("{");
            Console.WriteLine("    public abstract void MakeSound();      // Public");
            Console.WriteLine("    protected virtual void Internal() { }   // Protected");
            Console.WriteLine("    private void Private() { }              // Private");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("🔵 Interface:");
            Console.WriteLine("  Métodos son implícitamente públicos y abstractos\n");

            Console.WriteLine("```csharp");
            Console.WriteLine("public interface IAnimal");
            Console.WriteLine("{");
            Console.WriteLine("    void MakeSound(); // Implícitamente public");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra Purpose (Propósito)
        /// </summary>
        public static void DemonstratePurpose()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📌 4. Purpose (Propósito)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("🟢 Abstract Class:");
            Console.WriteLine("  Usado cuando las clases comparten comportamiento común");
            Console.WriteLine("  pero necesitan implementaciones únicas\n");

            Console.WriteLine("Ejemplo:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public abstract class Vehicle");
            Console.WriteLine("{");
            Console.WriteLine("    public int Speed { get; set; }");
            Console.WriteLine("    public void StartEngine() { } // Común");
            Console.WriteLine("    public abstract void Accelerate(); // Único");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("🔵 Interface:");
            Console.WriteLine("  Usado para definir un contrato que múltiples clases");
            Console.WriteLine("  deben seguir sin especificar cómo implementarlo\n");

            Console.WriteLine("Ejemplo:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public interface IVehicleFeatures");
            Console.WriteLine("{");
            Console.WriteLine("    void ApplyBrakes();");
            Console.WriteLine("    void TurnOnLights();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra caso de uso completo con vehículos
        /// </summary>
        public static void DemonstrateVehicleExample()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🚗 Ejemplo Completo: Diferentes Tipos de Vehículos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Usa Abstract Class \"Vehicle\" para:");
            Console.WriteLine("  • Propiedades comunes (Speed, Brand)");
            Console.WriteLine("  • Métodos comunes (StartEngine)");
            Console.WriteLine("  • Métodos abstractos (Accelerate)\n");

            Console.WriteLine("Usa Interface \"IVehicleFeatures\" para:");
            Console.WriteLine("  • Capacidades adicionales (ApplyBrakes, TurnOnLights)");
            Console.WriteLine("  • Múltiples clases pueden implementar\n");

            Console.WriteLine("Implementación:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public abstract class Vehicle");
            Console.WriteLine("{");
            Console.WriteLine("    public int Speed { get; protected set; }");
            Console.WriteLine("    public string Brand { get; set; }");
            Console.WriteLine("    ");
            Console.WriteLine("    public void StartEngine()");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine($\"{Brand} engine started\");");
            Console.WriteLine("    }");
            Console.WriteLine("    ");
            Console.WriteLine("    public abstract void Accelerate();");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("public interface IVehicleFeatures");
            Console.WriteLine("{");
            Console.WriteLine("    void ApplyBrakes();");
            Console.WriteLine("    void TurnOnLights();");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("public class Car : Vehicle, IVehicleFeatures");
            Console.WriteLine("{");
            Console.WriteLine("    public override void Accelerate() { Speed += 15; }");
            Console.WriteLine("    public void ApplyBrakes() { Speed = Math.Max(0, Speed - 20); }");
            Console.WriteLine("    public void TurnOnLights() { Console.WriteLine(\"Lights on\"); }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra cuándo usar cada uno
        /// </summary>
        public static void DemonstrateWhenToUse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Cuándo Usar Cada Uno");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("🟢 Usa Abstract Class Cuando:");
            Console.WriteLine("  ✅ Necesitas compartir código común entre clases relacionadas");
            Console.WriteLine("  ✅ Necesitas campos (variables de instancia)");
            Console.WriteLine("  ✅ Necesitas constructores");
            Console.WriteLine("  ✅ Necesitas métodos con diferentes modificadores de acceso");
            Console.WriteLine("  ✅ Las clases tienen una relación \"is-a\" clara");
            Console.WriteLine("     Ejemplo: \"Car is a Vehicle\"\n");

            Console.WriteLine("🔵 Usa Interface Cuando:");
            Console.WriteLine("  ✅ Necesitas definir un contrato para clases no relacionadas");
            Console.WriteLine("  ✅ Necesitas herencia múltiple");
            Console.WriteLine("  ✅ Solo necesitas definir qué hacer, no cómo hacerlo");
            Console.WriteLine("  ✅ Las clases tienen una relación \"can-do\" o \"has-a\"");
            Console.WriteLine("     Ejemplo: \"Car can apply brakes\"\n");
        }

        /// <summary>
        /// Demuestra combinación de ambos
        /// </summary>
        public static void DemonstrateCombination()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Combinando Abstract Class e Interface");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Puedes combinar ambos para obtener lo mejor de ambos mundos:\n");

            Console.WriteLine("```csharp");
            Console.WriteLine("// Abstract Class para comportamiento común");
            Console.WriteLine("public abstract class Vehicle");
            Console.WriteLine("{");
            Console.WriteLine("    public int Speed { get; set; }");
            Console.WriteLine("    public abstract void Accelerate();");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("// Interface para capacidades adicionales");
            Console.WriteLine("public interface IVehicleFeatures");
            Console.WriteLine("{");
            Console.WriteLine("    void ApplyBrakes();");
            Console.WriteLine("    void TurnOnLights();");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("// Implementación combinada");
            Console.WriteLine("public class Car : Vehicle, IVehicleFeatures");
            Console.WriteLine("{");
            Console.WriteLine("    public override void Accelerate() { Speed += 15; }");
            Console.WriteLine("    public void ApplyBrakes() { Speed = Math.Max(0, Speed - 20); }");
            Console.WriteLine("    public void TurnOnLights() { Console.WriteLine(\"Lights on\"); }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║         Difference Between Abstract Class and Interface       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateComparison();
            Console.WriteLine("\n");
            DemonstrateImplementation();
            Console.WriteLine("\n");
            DemonstrateInheritance();
            Console.WriteLine("\n");
            DemonstrateAccessModifiers();
            Console.WriteLine("\n");
            DemonstratePurpose();
            Console.WriteLine("\n");
            DemonstrateVehicleExample();
            Console.WriteLine("\n");
            DemonstrateWhenToUse();
            Console.WriteLine("\n");
            DemonstrateCombination();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Diferencias Clave:");
            Console.WriteLine("   1. Implementation: Abstract Class tiene métodos abstractos y concretos");
            Console.WriteLine("                      Interface principalmente declaraciones (C# 8.0+ también definiciones)");
            Console.WriteLine("   2. Inheritance: Abstract Class = herencia simple");
            Console.WriteLine("                   Interface = herencia múltiple");
            Console.WriteLine("   3. Access Modifiers: Abstract Class = todos los modificadores");
            Console.WriteLine("                       Interface = principalmente public");
            Console.WriteLine("   4. Purpose: Abstract Class = comportamiento común");
            Console.WriteLine("               Interface = contrato\n");
            
            Console.WriteLine("💡 Cuándo Usar:");
            Console.WriteLine("   🟢 Abstract Class: Relación \"is-a\", código común, campos, constructores");
            Console.WriteLine("   🔵 Interface: Contrato, herencia múltiple, relación \"can-do\"\n");
            
            Console.WriteLine("🔄 Combinación:");
            Console.WriteLine("   Puedes combinar ambos para obtener lo mejor de ambos mundos\n");
        }
    }

    // Clases de ejemplo para demostración

    // Abstract Class Example
    public abstract class Animal
    {
        protected string Name { get; set; }
        
        public Animal(string name)
        {
            Name = name;
        }
        
        public abstract void MakeSound();
        
        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping");
        }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }
    }

    // Interface Example
    public interface IAnimal
    {
        void MakeSound();
        string Name { get; set; }
    }

    public class Cat : IAnimal
    {
        public string Name { get; set; } = string.Empty;
        
        public void MakeSound()
        {
            Console.WriteLine($"{Name} says: Meow!");
        }
    }

    // Vehicle Example
    public abstract class Vehicle
    {
        public int Speed { get; protected set; }
        public string Brand { get; set; }
        
        public Vehicle(string brand)
        {
            Brand = brand;
            Speed = 0;
        }
        
        public void StartEngine()
        {
            Console.WriteLine($"{Brand} engine started");
        }
        
        public abstract void Accelerate();
    }

    public interface IVehicleFeatures
    {
        void ApplyBrakes();
        void TurnOnLights();
    }

    public class Car : Vehicle, IVehicleFeatures
    {
        public Car(string brand) : base(brand) { }
        
        public override void Accelerate()
        {
            Speed += 15;
            Console.WriteLine($"Car speed: {Speed} km/h");
        }
        
        public void ApplyBrakes()
        {
            Speed = Math.Max(0, Speed - 20);
            Console.WriteLine("Car brakes applied");
        }
        
        public void TurnOnLights()
        {
            Console.WriteLine("Car lights turned on");
        }
    }
}

