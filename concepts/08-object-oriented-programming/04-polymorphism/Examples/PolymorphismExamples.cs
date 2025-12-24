namespace NetMasteryLab.Concepts.ObjectOrientedProgramming.Polymorphism.Examples
{
    /// <summary>
    /// Ejemplos que demuestran el concepto de Polimorfismo en C#
    /// </summary>
    public class PolymorphismExamples
    {
        /// <summary>
        /// Demuestra polimorfismo básico con herencia
        /// </summary>
        public static void DemonstrateBasicPolymorphism()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Polimorfismo Básico con Herencia");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Código:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public abstract class Animal");
            Console.WriteLine("{");
            Console.WriteLine("    public virtual void MakeSound()");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine(\"Animal makes a sound\");");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("public class Dog : Animal");
            Console.WriteLine("{");
            Console.WriteLine("    public override void MakeSound()");
            Console.WriteLine("    {");
            Console.WriteLine("        Console.WriteLine(\"Dog barks: Woof! Woof!\");");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Uso polimórfico:");
            Animal[] animals = { new Dog(), new Cat() };
            foreach (Animal animal in animals)
            {
                Console.Write("   ");
                animal.MakeSound(); // Cada uno hace su sonido específico
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra polimorfismo con interfaces
        /// </summary>
        public static void DemonstrateInterfacePolymorphism()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔌 Polimorfismo con Interfaces");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: One Interface, Many Implementations");
            Console.WriteLine("```csharp");
            Console.WriteLine("public interface IShape");
            Console.WriteLine("{");
            Console.WriteLine("    double GetArea();");
            Console.WriteLine("    double GetPerimeter();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            IShape[] shapes = { new Circle(5), new Rectangle(4, 6) };
            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"   {shape.GetType().Name}: Area={shape.GetArea():F2}, Perimeter={shape.GetPerimeter():F2}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra polimorfismo con Dependency Injection
        /// </summary>
        public static void DemonstratePolymorphismWithDI()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💉 Polimorfismo con Dependency Injection");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Client class using DI to inject the payment processor");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class CheckoutService");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly IPaymentProcessor _paymentProcessor;");
            Console.WriteLine("    ");
            Console.WriteLine("    public CheckoutService(IPaymentProcessor paymentProcessor)");
            Console.WriteLine("    {");
            Console.WriteLine("        _paymentProcessor = paymentProcessor;");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            // Simulando DI - en ASP.NET Core esto se haría automáticamente
            // Con Credit Card
            IPaymentProcessor creditCard = new CreditCardPaymentProcessor();
            var checkoutService1 = new CheckoutService(creditCard);
            Console.WriteLine("   Con CreditCardPaymentProcessor:");
            checkoutService1.Checkout();
            Console.WriteLine();

            // Con PayPal
            IPaymentProcessor paypal = new PaypalPaymentProcessor();
            var checkoutService2 = new CheckoutService(paypal);
            Console.WriteLine("   Con PaypalPaymentProcessor:");
            checkoutService2.Checkout();
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra registro en DI container
        /// </summary>
        public static void DemonstrateDIContainerRegistration()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📦 Registro en DI Container (ASP.NET Core)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: En el DI container (e.g., ASP.NET Core)");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Opción 1: Credit Card");
            Console.WriteLine("services.AddTransient<IPaymentProcessor, CreditCardPaymentProcessor>();");
            Console.WriteLine("");
            Console.WriteLine("// Opción 2: PayPal");
            Console.WriteLine("services.AddTransient<IPaymentProcessor, PaypalPaymentProcessor>();");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  • Puedes cambiar la implementación sin modificar CheckoutService");
            Console.WriteLine("  • Fácil de testear con mocks");
            Console.WriteLine("  • Código desacoplado y flexible\n");
        }

        /// <summary>
        /// Demuestra polimorfismo con múltiples implementaciones
        /// </summary>
        public static void DemonstrateMultipleImplementations()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Múltiples Implementaciones del Mismo Contrato");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Diferentes implementaciones, mismo comportamiento");
            Console.WriteLine("```csharp");
            Console.WriteLine("public interface ILogger");
            Console.WriteLine("{");
            Console.WriteLine("    void Log(string message);");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            ILogger[] loggers = { new FileLogger(), new ConsoleLogger(), new DatabaseLogger() };
            foreach (ILogger logger in loggers)
            {
                Console.Write($"   {logger.GetType().Name}: ");
                logger.Log("Test message");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra selección dinámica de implementaciones con Factory Pattern
        /// </summary>
        public static void DemonstrateDynamicSelection()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Selección Dinámica de Implementaciones");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Factory Pattern con DI para selección dinámica");
            Console.WriteLine("```csharp");
            Console.WriteLine("services.AddTransient<Func<string, IPaymentProcessor>>(serviceProvider => key =>");
            Console.WriteLine("{");
            Console.WriteLine("    return key switch");
            Console.WriteLine("    {");
            Console.WriteLine("        \"CreditCard\" => serviceProvider.GetService<CreditCardPaymentProcessor>(),");
            Console.WriteLine("        \"PayPal\" => serviceProvider.GetService<PayPalPaymentProcessor>(),");
            Console.WriteLine("        _ => throw new ArgumentException(\"Invalid payment method\")");
            Console.WriteLine("    };");
            Console.WriteLine("});");
            Console.WriteLine("```\n");

            // Simulando factory pattern
            Console.WriteLine("Uso dinámico:");
            var factory = new PaymentProcessorFactory();
            
            Console.WriteLine("   Usuario selecciona 'CreditCard':");
            var creditCardProcessor = factory.GetProcessor("CreditCard");
            creditCardProcessor.ProcessPayment();
            
            Console.WriteLine("   Usuario selecciona 'PayPal':");
            var paypalProcessor = factory.GetProcessor("PayPal");
            paypalProcessor.ProcessPayment();
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra uso en controller con selección dinámica
        /// </summary>
        public static void DemonstrateControllerUsage()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎮 Uso en Controller con Selección Dinámica");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Controller usando factory para selección dinámica");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class OrderController");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly Func<string, IPaymentProcessor> _paymentProcessorFactory;");
            Console.WriteLine("    ");
            Console.WriteLine("    public OrderController(Func<string, IPaymentProcessor> factory)");
            Console.WriteLine("    {");
            Console.WriteLine("        _paymentProcessorFactory = factory;");
            Console.WriteLine("    }");
            Console.WriteLine("    ");
            Console.WriteLine("    public void Checkout(string paymentMethod)");
            Console.WriteLine("    {");
            Console.WriteLine("        var processor = _paymentProcessorFactory(paymentMethod);");
            Console.WriteLine("        processor.ProcessPayment();");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            // Simulación
            var factory = new PaymentProcessorFactory();
            var controller = new OrderController(factory);
            
            Console.WriteLine("Ejemplo de uso:");
            Console.WriteLine("   controller.Checkout(\"PayPal\");");
            controller.Checkout("PayPal");
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra beneficios del polimorfismo
        /// </summary>
        public static void DemonstrateBenefits()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Beneficios del Polimorfismo con DI");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Flexibilidad:");
            Console.WriteLine("   • Puedes cambiar implementaciones sin modificar código cliente");
            Console.WriteLine("   • Múltiples implementaciones del mismo contrato");
            Console.WriteLine("   • Selección dinámica basada en condiciones de runtime\n");

            Console.WriteLine("✅ Testabilidad:");
            Console.WriteLine("   • Fácil crear mocks para testing");
            Console.WriteLine("   • Puedes inyectar implementaciones de prueba\n");

            Console.WriteLine("✅ Desacoplamiento:");
            Console.WriteLine("   • Código cliente depende de abstracciones, no implementaciones");
            Console.WriteLine("   • Reduce acoplamiento entre componentes\n");

            Console.WriteLine("✅ Escalabilidad:");
            Console.WriteLine("   • Fácil agregar nuevas implementaciones");
            Console.WriteLine("   • Extiende funcionalidad sin modificar código existente");
            Console.WriteLine("   • Aplicación adaptable y dinámica\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Polymorphism (Polimorfismo) - OOP Fundamentals            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateBasicPolymorphism();
            Console.WriteLine("\n");
            DemonstrateInterfacePolymorphism();
            Console.WriteLine("\n");
            DemonstratePolymorphismWithDI();
            Console.WriteLine("\n");
            DemonstrateDIContainerRegistration();
            Console.WriteLine("\n");
            DemonstrateMultipleImplementations();
            Console.WriteLine("\n");
            DemonstrateDynamicSelection();
            Console.WriteLine("\n");
            DemonstrateControllerUsage();
            Console.WriteLine("\n");
            DemonstrateBenefits();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Polimorfismo:");
            Console.WriteLine("   • \"One Interface, Many Implementations\"");
            Console.WriteLine("   • Permite que objetos de diferentes tipos respondan al mismo método");
            Console.WriteLine("   • Logrado a través de interfaces, herencia y DI\n");
            
            Console.WriteLine("✅ Selección Dinámica:");
            Console.WriteLine("   • Factory Pattern con DI para selección en tiempo de ejecución");
            Console.WriteLine("   • Permite cambiar implementaciones basado en condiciones");
            Console.WriteLine("   • Hace la aplicación adaptable y dinámica\n");
            
            Console.WriteLine("💡 Key Takeaway:");
            Console.WriteLine("   • Con DI, el polimorfismo es naturalmente soportado");
            Console.WriteLine("   • Inyectar diferentes implementaciones permite diseño flexible");
            Console.WriteLine("   • El mismo código puede trabajar con diferentes implementaciones");
            Console.WriteLine("   • Selección dinámica mejora la extensibilidad del sistema\n");
        }
    }

    // Clases de ejemplo para demostración

    // Polimorfismo con herencia
    public abstract class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks: Woof! Woof!");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Cat meows: Meow!");
        }
    }

    // Polimorfismo con interfaces
    public interface IShape
    {
        double GetArea();
        double GetPerimeter();
    }

    public class Circle : IShape
    {
        private double _radius;
        
        public Circle(double radius) => _radius = radius;
        
        public double GetArea() => Math.PI * _radius * _radius;
        public double GetPerimeter() => 2 * Math.PI * _radius;
    }

    public class Rectangle : IShape
    {
        private double _width;
        private double _height;
        
        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }
        
        public double GetArea() => _width * _height;
        public double GetPerimeter() => 2 * (_width + _height);
    }

    // Polimorfismo con DI
    public interface IPaymentProcessor
    {
        void ProcessPayment();
    }

    // First implementation for credit card payments
    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing credit card payment.");
        }
    }

    // Second implementation for PayPal payments
    public class PaypalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing PayPal payment.");
        }
    }

    // Checkout service which depends on IPaymentProcessor
    public class CheckoutService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        // Dependency is injected via constructor
        public CheckoutService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void Checkout()
        {
            _paymentProcessor.ProcessPayment();
        }
    }

    // Múltiples implementaciones
    public interface ILogger
    {
        void Log(string message);
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[File] {message}");
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[Console] {message}");
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[Database] {message}");
        }
    }

    // Clase de ejemplo
    public class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
    }

    // Factory Pattern para selección dinámica
    public class PaymentProcessorFactory
    {
        public IPaymentProcessor GetProcessor(string paymentMethod)
        {
            return paymentMethod switch
            {
                "CreditCard" => new CreditCardPaymentProcessor(),
                "PayPal" => new PaypalPaymentProcessor(),
                _ => throw new ArgumentException($"Invalid payment method: {paymentMethod}")
            };
        }
    }

    // Controller usando factory para selección dinámica
    public class OrderController
    {
        private readonly PaymentProcessorFactory _factory;

        public OrderController(PaymentProcessorFactory factory)
        {
            _factory = factory;
        }

        public void Checkout(string paymentMethod)
        {
            // Dynamically selecting payment processor based on user input
            var paymentProcessor = _factory.GetProcessor(paymentMethod);
            paymentProcessor.ProcessPayment();
        }
    }
}

