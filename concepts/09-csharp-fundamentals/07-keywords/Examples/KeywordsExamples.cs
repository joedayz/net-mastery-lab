namespace NetMasteryLab.Concepts.CSharpFundamentals.Keywords.Examples
{
    /// <summary>
    /// Ejemplos que demuestran los Keywords esenciales de C#
    /// </summary>
    public class KeywordsExamples
    {
        /// <summary>
        /// Demuestra Access Modifiers
        /// </summary>
        public static void DemonstrateAccessModifiers()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔑 Access Modifiers (Modificadores de Acceso)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("public 🔓: Accesible desde cualquier código");
            Console.WriteLine("private 🔒: Solo accesible dentro de la misma clase/struct");
            Console.WriteLine("protected 🛡️: Accesible en la misma clase y clases derivadas");
            Console.WriteLine("internal 🏠: Accesible dentro del mismo assembly");
            Console.WriteLine("protected internal 🛡️🏠: Combinación de protected e internal\n");

            var example = new AccessModifiersExample();
            example.DemonstratePublic();
            example.DemonstratePrivate();
        }

        /// <summary>
        /// Demuestra Declaration Keywords
        /// </summary>
        public static void DemonstrateDeclarationKeywords()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🏗️ Declaration Keywords (Keywords de Declaración)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("class 🏫: Define una clase");
            Console.WriteLine("interface 🔗: Declara una interfaz");
            Console.WriteLine("struct 📦: Crea un tipo de valor");
            Console.WriteLine("enum 📜: Define una enumeración");
            Console.WriteLine("record 📖: Define una clase de datos inmutable (C# 9.0+)\n");

            var status = OrderStatus.Pending;
            Console.WriteLine($"Ejemplo enum: {status}");
            
            var point = new Point(10, 20);
            Console.WriteLine($"Ejemplo struct: Point({point.X}, {point.Y})");
            
            var person = new PersonRecord("John", 30);
            Console.WriteLine($"Ejemplo record: {person.Name}, {person.Age}");
        }

        /// <summary>
        /// Demuestra Type Keywords
        /// </summary>
        public static void DemonstrateTypeKeywords()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🧱 Type Keywords (Keywords de Tipo)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("string 📝: Tipo de datos de texto");
            Console.WriteLine("int 🔢: Entero de 32 bits");
            Console.WriteLine("bool ✅❌: Valor booleano");
            Console.WriteLine("double ⚖️: Número de punto flotante de doble precisión");
            Console.WriteLine("decimal 💰: Números decimales de alta precisión");
            Console.WriteLine("var 🌀: Declaración de tipo implícito\n");

            string name = "John Doe";
            int age = 30;
            bool isActive = true;
            double price = 99.99;
            decimal salary = 50000.50m;
            var inferred = "Type inferred";

            Console.WriteLine($"string: {name}");
            Console.WriteLine($"int: {age}");
            Console.WriteLine($"bool: {isActive}");
            Console.WriteLine($"double: {price}");
            Console.WriteLine($"decimal: {salary}");
            Console.WriteLine($"var: {inferred}");
        }

        /// <summary>
        /// Demuestra Method and Property Modifiers
        /// </summary>
        public static void DemonstrateMethodModifiers()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🛠️ Method and Property Modifiers");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("static 🗿: Pertenece al tipo mismo, no a la instancia");
            Console.WriteLine("virtual 🔄: Método puede ser sobrescrito");
            Console.WriteLine("override 📝: Implementa método virtual");
            Console.WriteLine("abstract 📂: Debe ser implementado por clase derivada");
            Console.WriteLine("async ⚡: Método contiene operaciones asíncronas");
            Console.WriteLine("await ⏳: Espera la finalización de operación asíncrona\n");

            var result = MathHelper.Add(5, 3);
            Console.WriteLine($"static method: MathHelper.Add(5, 3) = {result}");

            var dog = new Dog();
            dog.Speak(); // override example
        }

        /// <summary>
        /// Demuestra Control Flow Keywords
        /// </summary>
        public static void DemonstrateControlFlow()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Control Flow (Flujo de Control)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("if, else ❓: Ejecución condicional");
            Console.WriteLine("switch 🔀: Decisión de múltiples ramas");
            Console.WriteLine("for, foreach 🔁: Sentencias de iteración");
            Console.WriteLine("while, do 🔄: Constructos de bucle");
            Console.WriteLine("break 🚪: Sale del bucle o switch");
            Console.WriteLine("continue ⏩: Salta a la siguiente iteración");
            Console.WriteLine("return 🔙: Sale del método con valor");
            Console.WriteLine("throw 🚨: Lanza una excepción");
            Console.WriteLine("try, catch, finally 🛠️: Manejo de excepciones\n");

            // if/else example
            int age = 25;
            if (age >= 18)
                Console.WriteLine("if/else: Adult");
            else
                Console.WriteLine("if/else: Minor");

            // switch example
            var status = OrderStatus.Processing;
            switch (status)
            {
                case OrderStatus.Pending:
                    Console.WriteLine("switch: Order is pending");
                    break;
                case OrderStatus.Processing:
                    Console.WriteLine("switch: Order is processing");
                    break;
                default:
                    Console.WriteLine("switch: Unknown status");
                    break;
            }

            // for/foreach example
            Console.Write("for loop: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Console.Write("foreach loop: ");
            var numbers = new[] { 1, 2, 3, 4, 5 };
            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();

            // try/catch example
            try
            {
                int result = 10 / 2;
                Console.WriteLine($"try/catch: Result = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"try/catch: Error - {ex.Message}");
            }
            finally
            {
                Console.WriteLine("try/catch: Finally block executed");
            }
        }

        /// <summary>
        /// Demuestra Modern C# Features
        /// </summary>
        public static void DemonstrateModernFeatures()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🚀 Modern C# Features (Características Modernas)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("null 🚫: Ausencia de valor");
            Console.WriteLine("default 🛡️: Valor por defecto del tipo");
            Console.WriteLine("using 🧹: Disposición de recursos");
            Console.WriteLine("is ❔: Verificación de tipo");
            Console.WriteLine("as 🔄: Conversión segura de tipo");
            Console.WriteLine("new() 🆕: Instanciación de objeto");
            Console.WriteLine("nameof 🏷️: Obtiene el nombre de variable/tipo");
            Console.WriteLine("when 🧩: Condición de pattern matching\n");

            // null example
            string? nullableString = null;
            Console.WriteLine($"null: nullableString is null = {nullableString == null}");

            // default example
            int defaultInt = default;
            string? defaultString = default;
            Console.WriteLine($"default: int = {defaultInt}, string = {defaultString ?? "null"}");

            // nameof example
            string name = "John";
            Console.WriteLine($"nameof: {nameof(name)} = \"name\"");

            // is example
            object obj = "Hello";
            if (obj is string str)
            {
                Console.WriteLine($"is: obj is string = {str}");
            }
        }

        /// <summary>
        /// Demuestra Contextual Keywords
        /// </summary>
        public static void DemonstrateContextualKeywords()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📌 Contextual Keywords (Keywords Contextuales)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("value 📤: Parámetro del setter de propiedad");
            Console.WriteLine("get 🧾: Accessor de propiedad");
            Console.WriteLine("set 🛠️: Mutator de propiedad");
            Console.WriteLine("yield 🔄: Elemento de método iterador");
            Console.WriteLine("partial 🧩: Definición de tipo dividida");
            Console.WriteLine("where 📚: Restricciones de tipo genérico\n");

            var person = new PersonWithProperty();
            person.Name = "John";
            Console.WriteLine($"get/set/value: Name = {person.Name}");

            Console.Write("yield: ");
            foreach (var number in GetNumbers())
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    Keywords en C#                            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateAccessModifiers();
            Console.WriteLine("\n");
            DemonstrateDeclarationKeywords();
            Console.WriteLine("\n");
            DemonstrateTypeKeywords();
            Console.WriteLine("\n");
            DemonstrateMethodModifiers();
            Console.WriteLine("\n");
            DemonstrateControlFlow();
            Console.WriteLine("\n");
            DemonstrateModernFeatures();
            Console.WriteLine("\n");
            DemonstrateContextualKeywords();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Keywords son los bloques fundamentales de la sintaxis de C#");
            Console.WriteLine("✅ No pueden usarse como identificadores (excepto con @)");
            Console.WriteLine("✅ Cada keyword tiene un propósito específico");
            Console.WriteLine("✅ Comprenderlos a fondo te hace un mejor desarrollador C#\n");
            
            Console.WriteLine("📚 Categorías Principales:");
            Console.WriteLine("   • Access Modifiers: public, private, protected, internal");
            Console.WriteLine("   • Declaration: class, interface, struct, enum, record");
            Console.WriteLine("   • Types: string, int, bool, double, decimal, var");
            Console.WriteLine("   • Method Modifiers: static, virtual, override, abstract");
            Console.WriteLine("   • Control Flow: if, switch, for, while, try, catch");
            Console.WriteLine("   • Modern Features: null, default, using, is, as, nameof");
            Console.WriteLine("   • Contextual: value, get, set, yield, partial, where\n");
        }

        // Helper methods
        private static IEnumerable<int> GetNumbers()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return i;
            }
        }
    }

    // Clases de ejemplo para demostración

    public class AccessModifiersExample
    {
        public int PublicProperty { get; set; }
        private int _privateField;

        public void DemonstratePublic()
        {
            PublicProperty = 10;
            Console.WriteLine($"public: PublicProperty = {PublicProperty}");
        }

        public void DemonstratePrivate()
        {
            _privateField = 20;
            Console.WriteLine($"private: _privateField = {_privateField} (solo accesible dentro de la clase)");
        }
    }

    public enum OrderStatus
    {
        Pending,
        Processing,
        Completed,
        Cancelled
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public record PersonRecord(string Name, int Age);

    public static class MathHelper
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }

    public class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("Animal sound");
        }
    }

    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("override: Woof!");
        }
    }

    public class PersonWithProperty
    {
        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set => _name = value; // 'value' es el parámetro implícito
        }
    }
}

