namespace NetMasteryLab.Concepts.ObjectOrientedProgramming.Encapsulation.Examples
{
    /// <summary>
    /// Ejemplos que demuestran el concepto de Encapsulación en C#
    /// </summary>
    public class EncapsulationExamples
    {
        /// <summary>
        /// Demuestra el problema de no usar encapsulación
        /// </summary>
        public static void DemonstrateWithoutEncapsulation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ❌ SIN ENCAPSULACIÓN: Campos Públicos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Código problemático:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Person");
            Console.WriteLine("{");
            Console.WriteLine("    public string Name; // Acceso directo sin control");
            Console.WriteLine("    public int Age; // Puede ser modificado sin validación");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Problemas:");
            Console.WriteLine("  • No hay validación de datos");
            Console.WriteLine("  • Acceso directo sin control");
            Console.WriteLine("  • Estado interno puede ser corrompido");
            Console.WriteLine("  • Difícil de mantener y cambiar\n");

            // Ejemplo de clase sin encapsulación (solo para demostración)
            var person = new PersonWithoutEncapsulation
            {
                Name = "", // Puede ser vacío sin validación
                Age = -10 // Puede ser negativo sin validación
            };
            Console.WriteLine($"⚠️  Person sin validación: Name='{person.Name}', Age={person.Age}\n");
        }

        /// <summary>
        /// Demuestra encapsulación básica con auto-properties
        /// </summary>
        public static void DemonstrateBasicEncapsulation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ CON ENCAPSULACIÓN: Auto-Property con Valor por Defecto");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Código mejorado:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Person");
            Console.WriteLine("{");
            Console.WriteLine("    public string Name { get; set; } = \"Default Name\";");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  ✅ Código conciso y legible");
            Console.WriteLine("  ✅ Valor por defecto establecido");
            Console.WriteLine("  ✅ Acceso controlado a través de propiedades\n");

            var person = new Person
            {
                Name = "Alice"
            };
            Console.WriteLine($"✅ Person con encapsulación: Name='{person.Name}'\n");
        }

        /// <summary>
        /// Demuestra encapsulación con validación
        /// </summary>
        public static void DemonstrateEncapsulationWithValidation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔒 Encapsulación con Validación");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Propiedades con validación");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Person");
            Console.WriteLine("{");
            Console.WriteLine("    private string _name;");
            Console.WriteLine("    ");
            Console.WriteLine("    public string Name");
            Console.WriteLine("    {");
            Console.WriteLine("        get => _name;");
            Console.WriteLine("        set");
            Console.WriteLine("        {");
            Console.WriteLine("            if (string.IsNullOrWhiteSpace(value))");
            Console.WriteLine("                throw new ArgumentException(\"Name cannot be null or empty\");");
            Console.WriteLine("            _name = value;");
            Console.WriteLine("        }");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            var person = new PersonWithValidation();
            try
            {
                person.Name = "Alice";
                person.Age = 30;
                Console.WriteLine($"✅ Person válido: Name='{person.Name}', Age={person.Age}");

                // Intentar asignar valor inválido
                person.Age = -10; // Esto lanzará una excepción
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✅ Validación funcionando: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Demuestra propiedades de solo lectura
        /// </summary>
        public static void DemonstrateReadOnlyProperties()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📖 Propiedades de Solo Lectura");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Propiedades de solo lectura");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly int _orderId;");
            Console.WriteLine("    ");
            Console.WriteLine("    public Order(int orderId)");
            Console.WriteLine("    {");
            Console.WriteLine("        _orderId = orderId;");
            Console.WriteLine("    }");
            Console.WriteLine("    ");
            Console.WriteLine("    public int OrderId => _orderId; // Solo lectura");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            var order = new Order(12345);
            Console.WriteLine($"✅ Order creado: OrderId={order.OrderId}");
            Console.WriteLine("   OrderId es de solo lectura y no puede ser modificado\n");
        }

        /// <summary>
        /// Demuestra propiedades calculadas
        /// </summary>
        public static void DemonstrateCalculatedProperties()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🧮 Propiedades Calculadas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Propiedades calculadas sin campo de respaldo");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Rectangle");
            Console.WriteLine("{");
            Console.WriteLine("    public double Width { get; set; }");
            Console.WriteLine("    public double Height { get; set; }");
            Console.WriteLine("    ");
            Console.WriteLine("    public double Area => Width * Height; // Calculada");
            Console.WriteLine("    public double Perimeter => 2 * (Width + Height);");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            var rectangle = new Rectangle { Width = 5, Height = 10 };
            Console.WriteLine($"✅ Rectangle: Width={rectangle.Width}, Height={rectangle.Height}");
            Console.WriteLine($"   Area={rectangle.Area}, Perimeter={rectangle.Perimeter}\n");
        }

        /// <summary>
        /// Demuestra encapsulación completa
        /// </summary>
        public static void DemonstrateFullEncapsulation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🏦 Encapsulación Completa - BankAccount");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Encapsulación completa con métodos controlados");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class BankAccount");
            Console.WriteLine("{");
            Console.WriteLine("    private decimal _balance;");
            Console.WriteLine("    ");
            Console.WriteLine("    public decimal Balance => _balance; // Solo lectura");
            Console.WriteLine("    ");
            Console.WriteLine("    public void Deposit(decimal amount) { /* validación */ }");
            Console.WriteLine("    public bool Withdraw(decimal amount) { /* validación */ }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            var account = new BankAccount("ACC-001", 1000m);
            Console.WriteLine($"✅ Account creado: Balance=${account.Balance}");

            account.Deposit(500m);
            Console.WriteLine($"   Después de depositar $500: Balance=${account.Balance}");

            bool success = account.Withdraw(200m);
            Console.WriteLine($"   Después de retirar $200: Balance=${account.Balance}, Success={success}");

            bool failed = account.Withdraw(2000m); // Más de lo disponible
            Console.WriteLine($"   Intento de retirar $2000: Success={failed} (insuficiente)\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Encapsulation (Encapsulación) - OOP Fundamentals           ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateWithoutEncapsulation();
            Console.WriteLine("\n");
            DemonstrateBasicEncapsulation();
            Console.WriteLine("\n");
            DemonstrateEncapsulationWithValidation();
            Console.WriteLine("\n");
            DemonstrateReadOnlyProperties();
            Console.WriteLine("\n");
            DemonstrateCalculatedProperties();
            Console.WriteLine("\n");
            DemonstrateFullEncapsulation();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Encapsulación:");
            Console.WriteLine("   • Agrupa datos y métodos dentro de una clase");
            Console.WriteLine("   • Restringe acceso directo a componentes internos");
            Console.WriteLine("   • Protege el estado interno del objeto");
            Console.WriteLine("   • Expone solo funcionalidad necesaria\n");
            
            Console.WriteLine("💡 Beneficios:");
            Console.WriteLine("   • Seguridad - Protege datos sensibles");
            Console.WriteLine("   • Mantenibilidad - Facilita cambios internos");
            Console.WriteLine("   • Flexibilidad - Permite cambiar implementación");
            Console.WriteLine("   • Testabilidad - Facilita pruebas unitarias\n");
        }
    }

    // Clases de ejemplo para demostración

    // ❌ Sin encapsulación
    public class PersonWithoutEncapsulation
    {
        public string Name = string.Empty;
        public int Age;
    }

    // ✅ Con encapsulación básica
    public class Person
    {
        public string Name { get; set; } = "Default Name";
    }

    // ✅ Con encapsulación y validación
    public class PersonWithValidation
    {
        private string _name = string.Empty;
        private int _age;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or empty");
                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentException("Age must be between 0 and 150");
                _age = value;
            }
        }
    }

    // ✅ Propiedades de solo lectura
    public class Order
    {
        private readonly int _orderId;
        private readonly DateTime _orderDate;

        public Order(int orderId)
        {
            _orderId = orderId;
            _orderDate = DateTime.Now;
        }

        public int OrderId => _orderId;
        public DateTime OrderDate => _orderDate;
    }

    // ✅ Propiedades calculadas
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double Area => Width * Height;
        public double Perimeter => 2 * (Width + Height);
    }

    // ✅ Encapsulación completa
    public class BankAccount
    {
        private decimal _balance;
        private readonly string _accountNumber;

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            _accountNumber = accountNumber;
            _balance = initialBalance;
        }

        public string AccountNumber => _accountNumber;
        public decimal Balance => _balance;

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be positive");
            _balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be positive");
            
            if (_balance < amount)
                return false;
            
            _balance -= amount;
            return true;
        }
    }
}

