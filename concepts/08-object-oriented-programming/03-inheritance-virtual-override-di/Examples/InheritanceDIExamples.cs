namespace NetMasteryLab.Concepts.ObjectOrientedProgramming.InheritanceVirtualOverrideDI.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Inheritance con Virtual/Override y Dependency Injection
    /// </summary>
    public class InheritanceDIExamples
    {
        /// <summary>
        /// Demuestra la estructura básica de herencia con virtual/override
        /// </summary>
        public static void DemonstrateBasicInheritance()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Herencia Básica con Virtual/Override");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Código:");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Base class with a virtual method");
            Console.WriteLine("public class Animal");
            Console.WriteLine("{");
            Console.WriteLine("    public virtual string Speak() => \"Animal sound\";");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("// Derived class overriding the virtual method");
            Console.WriteLine("public class Dog : Animal");
            Console.WriteLine("{");
            Console.WriteLine("    public override string Speak() => \"Woof!\";");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Animal animal = new Animal();
            Animal dog = new Dog();
            Animal cat = new Cat();

            Console.WriteLine($"✅ Animal base: {animal.Speak()}");
            Console.WriteLine($"✅ Dog (polimorfismo): {dog.Speak()}");
            Console.WriteLine($"✅ Cat (polimorfismo): {cat.Speak()}\n");
        }

        /// <summary>
        /// Demuestra Dependency Injection básico
        /// </summary>
        public static void DemonstrateDependencyInjection()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💉 Dependency Injection Básico");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Service usando Dependency Injection");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class AnimalService");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly Animal _animal;");
            Console.WriteLine("    ");
            Console.WriteLine("    public AnimalService(Animal animal) => _animal = animal;");
            Console.WriteLine("    ");
            Console.WriteLine("    public string GetAnimalSound() => _animal.Speak();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            // Simulando DI - en ASP.NET Core esto se haría automáticamente
            Animal dog = new Dog();
            var dogService = new AnimalService(dog);
            Console.WriteLine($"✅ AnimalService con Dog: {dogService.GetAnimalSound()}");

            Animal cat = new Cat();
            var catService = new AnimalService(cat);
            Console.WriteLine($"✅ AnimalService con Cat: {catService.GetAnimalSound()}\n");
        }

        /// <summary>
        /// Demuestra configuración de ASP.NET Core con DI
        /// </summary>
        public static void DemonstrateAspNetCoreDI()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🌐 ASP.NET Core con Dependency Injection");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Configuración en Program.cs");
            Console.WriteLine("```csharp");
            Console.WriteLine("var builder = WebApplication.CreateBuilder(args);");
            Console.WriteLine("");
            Console.WriteLine("// Register Dog or Cat class as Animal in the DI container");
            Console.WriteLine("builder.Services.AddScoped<Animal, Dog>();");
            Console.WriteLine("builder.Services.AddScoped<AnimalService>();");
            Console.WriteLine("");
            Console.WriteLine("var app = builder.Build();");
            Console.WriteLine("");
            Console.WriteLine("app.MapGet(\"/\", (AnimalService animalService) => ");
            Console.WriteLine("    animalService.GetAnimalSound());");
            Console.WriteLine("");
            Console.WriteLine("app.Run();");
            Console.WriteLine("```\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  • Minimal APIs para endpoints concisos");
            Console.WriteLine("  • DI automático en parámetros del endpoint");
            Console.WriteLine("  • Scoped lifetime: una instancia por request\n");
        }

        /// <summary>
        /// Demuestra herencia con métodos virtuales y concretos
        /// </summary>
        public static void DemonstrateVirtualMethods()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Métodos Virtuales y Concretos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Métodos virtuales con implementación por defecto");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Animal");
            Console.WriteLine("{");
            Console.WriteLine("    public virtual string Speak() => \"Animal sound\";");
            Console.WriteLine("    public virtual void Eat() => Console.WriteLine(\"Eating...\");");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            var dog = new Dog();
            var cat = new Cat();

            Console.WriteLine($"✅ Dog.Speak(): {dog.Speak()}");
            Console.Write("✅ Dog.Eat(): ");
            dog.Eat();

            Console.WriteLine($"✅ Cat.Speak(): {cat.Speak()}");
            Console.Write("✅ Cat.Eat(): ");
            cat.Eat();
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra uso con interfaces (mejor práctica)
        /// </summary>
        public static void DemonstrateWithInterfaces()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔌 Con Interfaces (Mejor Práctica)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Usar interfaces para mejor desacoplamiento");
            Console.WriteLine("```csharp");
            Console.WriteLine("public interface IAnimal");
            Console.WriteLine("{");
            Console.WriteLine("    string Speak();");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("public class Animal : IAnimal");
            Console.WriteLine("{");
            Console.WriteLine("    public virtual string Speak() => \"Animal sound\";");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            IAnimal dog = new Dog();
            IAnimal cat = new Cat();

            var dogService = new AnimalServiceWithInterface(dog);
            var catService = new AnimalServiceWithInterface(cat);

            Console.WriteLine($"✅ Service con Dog (interface): {dogService.GetAnimalSound()}");
            Console.WriteLine($"✅ Service con Cat (interface): {catService.GetAnimalSound()}\n");
        }

        /// <summary>
        /// Demuestra ejemplo completo con PaymentProcessor
        /// </summary>
        public static void DemonstrateCompleteExample()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💳 Ejemplo Completo - PaymentProcessor");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Ejemplo real con múltiples implementaciones");
            Console.WriteLine("```csharp");
            Console.WriteLine("public abstract class PaymentProcessor");
            Console.WriteLine("{");
            Console.WriteLine("    public virtual string ProcessPayment(decimal amount)");
            Console.WriteLine("    {");
            Console.WriteLine("        return $\"Processing payment of ${amount}\";");
            Console.WriteLine("    }");
            Console.WriteLine("    ");
            Console.WriteLine("    public abstract string GetPaymentMethod();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            PaymentProcessor creditCard = new CreditCardProcessor();
            PaymentProcessor paypal = new PayPalProcessor();

            var creditCardService = new PaymentService(creditCard);
            var paypalService = new PaymentService(paypal);

            Console.WriteLine($"✅ Credit Card: {creditCardService.Process(100m)}");
            Console.WriteLine($"✅ PayPal: {paypalService.Process(100m)}\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  Inheritance with Virtual/Override and Dependency Injection   ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateBasicInheritance();
            Console.WriteLine("\n");
            DemonstrateDependencyInjection();
            Console.WriteLine("\n");
            DemonstrateAspNetCoreDI();
            Console.WriteLine("\n");
            DemonstrateVirtualMethods();
            Console.WriteLine("\n");
            DemonstrateWithInterfaces();
            Console.WriteLine("\n");
            DemonstrateCompleteExample();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Conceptos Clave:");
            Console.WriteLine("   • Virtual Methods - Permiten sobrescritura en clases derivadas");
            Console.WriteLine("   • Override - Proporciona implementación específica");
            Console.WriteLine("   • Dependency Injection - Inyección de dependencias en runtime\n");
            
            Console.WriteLine("💡 Beneficios de Combinar Herencia y DI:");
            Console.WriteLine("   • Decoupled Implementations - Implementaciones desacopladas");
            Console.WriteLine("   • Customizable Behavior - Comportamiento personalizable");
            Console.WriteLine("   • Maintainability - Mantenibilidad mejorada\n");
        }
    }

    // Clases de ejemplo para demostración

    // Con interfaces (mejor práctica)
    public interface IAnimal
    {
        string Speak();
    }

    // Base class with a virtual method implementing IAnimal
    public class Animal : IAnimal
    {
        public virtual string Speak() => "Animal sound";
        
        public virtual void Eat()
        {
            Console.WriteLine("Eating...");
        }
    }

    // Derived class overriding the virtual method
    public class Dog : Animal
    {
        public override string Speak() => "Woof!";
    }

    public class Cat : Animal
    {
        public override string Speak() => "Meow!";
    }

    // AnimalService using dependency injection
    public class AnimalService
    {
        private readonly Animal _animal;
        
        public AnimalService(Animal animal) => _animal = animal;
        
        public string GetAnimalSound() => _animal.Speak(); 
        // Calls the correct Speak() based on the injected animal
    }

    public class AnimalWithInterface : Animal, IAnimal
    {
        // Implementa IAnimal a través de Animal
    }

    public class AnimalServiceWithInterface
    {
        private readonly IAnimal _animal;
        
        public AnimalServiceWithInterface(IAnimal animal) => _animal = animal;
        
        public string GetAnimalSound() => _animal.Speak();
    }

    // Ejemplo completo con PaymentProcessor
    public abstract class PaymentProcessor
    {
        public virtual string ProcessPayment(decimal amount)
        {
            return $"Processing payment of ${amount}";
        }
        
        public abstract string GetPaymentMethod();
    }

    public class CreditCardProcessor : PaymentProcessor
    {
        public override string ProcessPayment(decimal amount)
        {
            return $"Processing credit card payment of ${amount}";
        }
        
        public override string GetPaymentMethod() => "Credit Card";
    }

    public class PayPalProcessor : PaymentProcessor
    {
        public override string ProcessPayment(decimal amount)
        {
            return $"Processing PayPal payment of ${amount}";
        }
        
        public override string GetPaymentMethod() => "PayPal";
    }

    public class PaymentService
    {
        private readonly PaymentProcessor _processor;
        
        public PaymentService(PaymentProcessor processor) => _processor = processor;
        
        public string Process(decimal amount) => _processor.ProcessPayment(amount);
    }
}

