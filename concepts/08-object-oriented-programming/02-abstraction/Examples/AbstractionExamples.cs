namespace NetMasteryLab.Concepts.ObjectOrientedProgramming.Abstraction.Examples
{
    /// <summary>
    /// Ejemplos que demuestran el concepto de Abstracción en C#
    /// </summary>
    public class AbstractionExamples
    {
        /// <summary>
        /// Demuestra el problema de no usar abstracción
        /// </summary>
        public static void DemonstrateWithoutAbstraction()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ❌ SIN ABSTRACCIÓN: Código Duplicado y Acoplado");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Código problemático:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Circle");
            Console.WriteLine("{");
            Console.WriteLine("    public double GetArea() { /* ... */ }");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("public class Rectangle");
            Console.WriteLine("{");
            Console.WriteLine("    public double GetArea() { /* ... */ }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Problemas:");
            Console.WriteLine("  • No hay contrato común");
            Console.WriteLine("  • Código duplicado");
            Console.WriteLine("  • Difícil de extender");
            Console.WriteLine("  • Detalles de implementación expuestos\n");
        }

        /// <summary>
        /// Demuestra abstracción básica con abstract class
        /// </summary>
        public static void DemonstrateBasicAbstraction()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ CON ABSTRACCIÓN: Abstract Class");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Código mejorado:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public abstract class Shape");
            Console.WriteLine("{");
            Console.WriteLine("    public abstract double GetArea();");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("public class Circle : Shape");
            Console.WriteLine("{");
            Console.WriteLine("    public override double GetArea() => Math.PI * Radius * Radius;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  ✅ Define contrato común");
            Console.WriteLine("  ✅ Oculta detalles de implementación");
            Console.WriteLine("  ✅ Facilita extensión");
            Console.WriteLine("  ✅ Código más mantenible\n");

            var circle = new Circle(5.0);
            var rectangle = new Rectangle(4.0, 6.0);

            Console.WriteLine($"✅ Circle (radius=5): Area={circle.GetArea():F2}");
            Console.WriteLine($"✅ Rectangle (4x6): Area={rectangle.GetArea():F2}\n");
        }

        /// <summary>
        /// Demuestra abstract record (C# 10+)
        /// </summary>
        public static void DemonstrateAbstractRecord()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Abstract Record (C# 10+)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Abstract record - forma moderna y concisa");
            Console.WriteLine("```csharp");
            Console.WriteLine("public abstract record Shape");
            Console.WriteLine("{");
            Console.WriteLine("    public abstract double GetArea();");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("public record Circle(double Radius) : Shape");
            Console.WriteLine("{");
            Console.WriteLine("    public override double GetArea() => Math.PI * Radius * Radius;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            var circleRecord = new CircleRecord(5.0);
            var rectangleRecord = new RectangleRecord(4.0, 6.0);

            Console.WriteLine($"✅ Circle Record (radius=5): Area={circleRecord.GetArea():F2}");
            Console.WriteLine($"✅ Rectangle Record (4x6): Area={rectangleRecord.GetArea():F2}\n");
        }

        /// <summary>
        /// Demuestra abstracción con métodos concretos y abstractos
        /// </summary>
        public static void DemonstrateMixedAbstraction()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔀 Abstracción Mixta (Métodos Concretos y Abstractos)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Abstract class con métodos concretos compartidos");
            Console.WriteLine("```csharp");
            Console.WriteLine("public abstract class Animal");
            Console.WriteLine("{");
            Console.WriteLine("    public string Name { get; set; }");
            Console.WriteLine("    public void Eat() { /* implementación compartida */ }");
            Console.WriteLine("    public abstract void MakeSound(); // Debe ser implementado");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            var dog = new Dog { Name = "Buddy" };
            var cat = new Cat { Name = "Whiskers" };

            Console.WriteLine($"✅ Dog: {dog.Name}");
            dog.Eat();
            dog.MakeSound();
            Console.WriteLine();

            Console.WriteLine($"✅ Cat: {cat.Name}");
            cat.Eat();
            cat.MakeSound();
            cat.Sleep();
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra abstracción con interfaces
        /// </summary>
        public static void DemonstrateInterfaceAbstraction()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔌 Abstracción con Interfaces");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Interface para definir contrato");
            Console.WriteLine("```csharp");
            Console.WriteLine("public interface IShape");
            Console.WriteLine("{");
            Console.WriteLine("    double GetArea();");
            Console.WriteLine("    double GetPerimeter();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            IShape circle = new CircleInterface(5.0);
            IShape rectangle = new RectangleInterface(4.0, 6.0);

            Console.WriteLine($"✅ Circle via interface: Area={circle.GetArea():F2}, Perimeter={circle.GetPerimeter():F2}");
            Console.WriteLine($"✅ Rectangle via interface: Area={rectangle.GetArea():F2}, Perimeter={rectangle.GetPerimeter():F2}\n");
        }

        /// <summary>
        /// Demuestra abstracción en sistemas reales
        /// </summary>
        public static void DemonstrateRealWorldAbstraction()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🌍 Abstracción en Sistemas Reales - PaymentProcessor");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Abstracción para diferentes procesadores de pago");
            Console.WriteLine("```csharp");
            Console.WriteLine("public abstract class PaymentProcessor");
            Console.WriteLine("{");
            Console.WriteLine("    public abstract bool ProcessPayment(decimal amount);");
            Console.WriteLine("    public abstract string GetPaymentMethod();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            PaymentProcessor creditCard = new CreditCardProcessor();
            PaymentProcessor paypal = new PayPalProcessor();

            Console.WriteLine($"✅ Credit Card Processor: {creditCard.GetPaymentMethod()}");
            creditCard.ProcessPayment(100m);
            Console.WriteLine();

            Console.WriteLine($"✅ PayPal Processor: {paypal.GetPaymentMethod()}");
            paypal.ProcessPayment(100m);
            Console.WriteLine();
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Abstraction (Abstracción) - OOP Fundamentals              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateWithoutAbstraction();
            Console.WriteLine("\n");
            DemonstrateBasicAbstraction();
            Console.WriteLine("\n");
            DemonstrateAbstractRecord();
            Console.WriteLine("\n");
            DemonstrateMixedAbstraction();
            Console.WriteLine("\n");
            DemonstrateInterfaceAbstraction();
            Console.WriteLine("\n");
            DemonstrateRealWorldAbstraction();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Abstracción:");
            Console.WriteLine("   • Oculta detalles complejos y muestra solo lo esencial");
            Console.WriteLine("   • Define QUÉ hacer, no CÓMO hacerlo");
            Console.WriteLine("   • Proporciona flexibilidad y extensibilidad");
            Console.WriteLine("   • Separa responsabilidades (qué vs cómo)\n");
            
            Console.WriteLine("💡 Características Clave:");
            Console.WriteLine("   • Essential Features Only - Solo características esenciales");
            Console.WriteLine("   • Interface Design - Diseño de interfaz claro");
            Console.WriteLine("   • Flexibility and Extensibility - Flexibilidad y extensibilidad");
            Console.WriteLine("   • Separation of Concerns - Separación de responsabilidades\n");
        }
    }

    // Clases de ejemplo para demostración

    // ✅ Abstract Class básico
    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    public class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override double GetArea() => Math.PI * _radius * _radius;
        public override double GetPerimeter() => 2 * Math.PI * _radius;
    }

    public class Rectangle : Shape
    {
        private double _width;
        private double _height;

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public override double GetArea() => _width * _height;
        public override double GetPerimeter() => 2 * (_width + _height);
    }

    // ✅ Abstract Record (C# 10+)
    public abstract record ShapeRecord
    {
        public abstract double GetArea();
    }

    public record CircleRecord(double Radius) : ShapeRecord
    {
        public override double GetArea() => Math.PI * Radius * Radius;
    }

    public record RectangleRecord(double Width, double Height) : ShapeRecord
    {
        public override double GetArea() => Width * Height;
    }

    // ✅ Abstract Class con métodos mixtos
    public abstract class Animal
    {
        public string Name { get; set; } = string.Empty;

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }

        public abstract void MakeSound();

        public virtual void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} barks: Woof! Woof!");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} meows: Meow!");
        }

        public override void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping peacefully.");
        }
    }

    // ✅ Interface para abstracción
    public interface IShape
    {
        double GetArea();
        double GetPerimeter();
    }

    public class CircleInterface : IShape
    {
        private double _radius;

        public CircleInterface(double radius)
        {
            _radius = radius;
        }

        public double GetArea() => Math.PI * _radius * _radius;
        public double GetPerimeter() => 2 * Math.PI * _radius;
    }

    public class RectangleInterface : IShape
    {
        private double _width;
        private double _height;

        public RectangleInterface(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public double GetArea() => _width * _height;
        public double GetPerimeter() => 2 * (_width + _height);
    }

    // ✅ Abstracción en sistemas reales
    public abstract class PaymentProcessor
    {
        public abstract bool ProcessPayment(decimal amount);
        public abstract string GetPaymentMethod();

        public void LogTransaction(decimal amount)
        {
            Console.WriteLine($"Processing {GetPaymentMethod()} payment of ${amount}");
        }
    }

    public class CreditCardProcessor : PaymentProcessor
    {
        public override bool ProcessPayment(decimal amount)
        {
            LogTransaction(amount);
            Console.WriteLine("  Validating credit card...");
            Console.WriteLine("  Charging credit card...");
            Console.WriteLine("  Payment processed successfully!");
            return true;
        }

        public override string GetPaymentMethod() => "Credit Card";
    }

    public class PayPalProcessor : PaymentProcessor
    {
        public override bool ProcessPayment(decimal amount)
        {
            LogTransaction(amount);
            Console.WriteLine("  Authenticating PayPal account...");
            Console.WriteLine("  Processing PayPal payment...");
            Console.WriteLine("  Payment processed successfully!");
            return true;
        }

        public override string GetPaymentMethod() => "PayPal";
    }
}

