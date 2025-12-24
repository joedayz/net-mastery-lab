namespace NetMasteryLab.Concepts.ObjectOrientedProgramming.KeyClassConcepts.Examples
{
    /// <summary>
    /// Ejemplos que demuestran los conceptos clave de clases en OOP
    /// </summary>
    public class KeyClassConceptsExamples
    {
        /// <summary>
        /// Demuestra instancias de una clase
        /// </summary>
        public static void DemonstrateInstanceOfClass()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📦 Instance of a Class (Instancia de una Clase)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Definición:");
            Console.WriteLine("  Una instancia de una clase es un objeto creado a partir de esa clase.");
            Console.WriteLine("  Se inicializa usando la palabra clave 'new' y tiene su propia memoria.\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  • Creación: Se crea usando la palabra clave 'new'");
            Console.WriteLine("  • Memoria: Cada instancia tiene su propia asignación de memoria");
            Console.WriteLine("  • Variables: Cada instancia tiene su propio conjunto de variables");
            Console.WriteLine("  • Independencia: Las instancias son independientes entre sí\n");

            // Crear instancias de la clase Person
            Person person1 = new Person { Name = "Alice", Age = 30 };
            Person person2 = new Person { Name = "Bob", Age = 25 };

            Console.WriteLine("Ejemplo:");
            Console.WriteLine($"  person1.Name = \"{person1.Name}\", Age = {person1.Age}");
            Console.WriteLine($"  person2.Name = \"{person2.Name}\", Age = {person2.Age}\n");

            // Cambiar person1 no afecta a person2
            person1.Age = 31;
            Console.WriteLine("Después de cambiar person1.Age = 31:");
            Console.WriteLine($"  person1.Age = {person1.Age}");
            Console.WriteLine($"  person2.Age = {person2.Age} (no cambió - instancias independientes)\n");
        }

        /// <summary>
        /// Demuestra referencias de una clase
        /// </summary>
        public static void DemonstrateReferenceOfClass()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔗 Reference of a Class (Referencia de una Clase)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Definición:");
            Console.WriteLine("  Una referencia a una instancia de clase NO es una 'copia' de la clase.");
            Console.WriteLine("  Es una variable que contiene la dirección de memoria de una instancia existente.\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  • No es una copia: Una referencia apunta a la misma instancia");
            Console.WriteLine("  • Misma memoria: Todas las referencias apuntan al mismo objeto");
            Console.WriteLine("  • Cambios compartidos: Los cambios se reflejan en todas las referencias");
            Console.WriteLine("  • No crea nueva instancia: Solo crea una nueva variable\n");

            // Crear una instancia
            Person person1 = new Person { Name = "Alice", Age = 30 };
            
            // Crear una referencia (no una copia)
            Person person2 = person1;

            Console.WriteLine("Ejemplo:");
            Console.WriteLine($"  person1.Name = \"{person1.Name}\", Age = {person1.Age}");
            Console.WriteLine($"  person2.Name = \"{person2.Name}\", Age = {person2.Age}");
            Console.WriteLine($"  ¿Son la misma instancia? {ReferenceEquals(person1, person2)}\n");

            // Cambiar a través de una referencia afecta a todas las referencias
            person2.Name = "Bob";
            person2.Age = 35;
            
            Console.WriteLine("Después de cambiar person2.Name = 'Bob' y person2.Age = 35:");
            Console.WriteLine($"  person1.Name = \"{person1.Name}\" (¡cambió!)");
            Console.WriteLine($"  person1.Age = {person1.Age} (¡cambió!)");
            Console.WriteLine($"  person2.Name = \"{person2.Name}\"");
            Console.WriteLine($"  person2.Age = {person2.Age}\n");
        }

        /// <summary>
        /// Demuestra instance variables
        /// </summary>
        public static void DemonstrateInstanceVariables()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Instance Variables (Variables de Instancia)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Definición:");
            Console.WriteLine("  Variables declaradas dentro de la clase que pertenecen a cada instancia.");
            Console.WriteLine("  Cada objeto tiene su propia copia de las variables de instancia.\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  • Pertenecen a la instancia: Cada objeto tiene su propia copia");
            Console.WriteLine("  • No compartidas: Los cambios en una instancia no afectan a otras");
            Console.WriteLine("  • Acceso: Se accede a través de una instancia del objeto\n");

            // Cada instancia tiene sus propias variables
            BankAccount account1 = new BankAccount("ACC-001", 1000m);
            BankAccount account2 = new BankAccount("ACC-002", 2000m);

            Console.WriteLine("Ejemplo:");
            Console.WriteLine($"  account1.Balance = ${account1.Balance}");
            Console.WriteLine($"  account2.Balance = ${account2.Balance}\n");

            // Cambiar account1 no afecta a account2
            account1.Deposit(500m);
            Console.WriteLine("Después de account1.Deposit(500):");
            Console.WriteLine($"  account1.Balance = ${account1.Balance}");
            Console.WriteLine($"  account2.Balance = ${account2.Balance} (no cambió - variables independientes)\n");
        }

        /// <summary>
        /// Demuestra static variables (class variables)
        /// </summary>
        public static void DemonstrateStaticVariables()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Static Variables / Class Variables");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Definición:");
            Console.WriteLine("  Variables que pertenecen a la clase misma, no a ninguna instancia.");
            Console.WriteLine("  Se comparten entre todas las instancias de la clase.\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  • Pertenecen a la clase: No a instancias individuales");
            Console.WriteLine("  • Compartidas: Todas las instancias comparten la misma variable");
            Console.WriteLine("  • Acceso: Se accede a través del nombre de la clase");
            Console.WriteLine("  • Palabra clave: Se declaran con 'static'\n");

            // Acceder a variable estática sin crear instancia
            Console.WriteLine($"Counter.TotalCount (sin instancias) = {Counter.TotalCount}\n");

            // Crear instancias
            Counter counter1 = new Counter();
            Counter counter2 = new Counter();
            Counter counter3 = new Counter();

            Console.WriteLine("Después de crear 3 instancias:");
            Console.WriteLine($"  Counter.TotalCount = {Counter.TotalCount} (compartida)");
            Console.WriteLine($"  counter1.InstanceCount = {counter1.InstanceCount} (propia)");
            Console.WriteLine($"  counter2.InstanceCount = {counter2.InstanceCount} (propia)");
            Console.WriteLine($"  counter3.InstanceCount = {counter3.InstanceCount} (propia)\n");

            // Incrementar una instancia
            counter1.Increment();
            Console.WriteLine("Después de counter1.Increment():");
            Console.WriteLine($"  Counter.TotalCount = {Counter.TotalCount} (compartida - incrementó)");
            Console.WriteLine($"  counter1.InstanceCount = {counter1.InstanceCount} (propia - incrementó)");
            Console.WriteLine($"  counter2.InstanceCount = {counter2.InstanceCount} (propia - no cambió)\n");
        }

        /// <summary>
        /// Demuestra comparación entre instancia y referencia
        /// </summary>
        public static void DemonstrateInstanceVsReference()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Comparación: Instancia vs Referencia");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("INSTANCIA: Crea un nuevo objeto en memoria");
            Person person1 = new Person { Name = "Alice", Age = 30 };
            Person person2 = new Person { Name = "Bob", Age = 25 };
            Console.WriteLine($"  person1 y person2 son objetos diferentes: {!ReferenceEquals(person1, person2)}\n");

            Console.WriteLine("REFERENCIA: Apunta al mismo objeto");
            Person person3 = person1;
            Console.WriteLine($"  person3 y person1 apuntan al mismo objeto: {ReferenceEquals(person1, person3)}\n");

            Console.WriteLine("Demostración:");
            person3.Name = "Charlie";
            Console.WriteLine($"  person1.Name = \"{person1.Name}\" (cambió porque es referencia)");
            Console.WriteLine($"  person2.Name = \"{person2.Name}\" (no cambió porque es instancia diferente)\n");
        }

        /// <summary>
        /// Demuestra comparación entre instance variables y static variables
        /// </summary>
        public static void DemonstrateInstanceVsStaticVariables()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Comparación: Instance Variables vs Static Variables");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Instance Variables:");
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Console.WriteLine($"  emp1.EmployeeId = {emp1.EmployeeId} (propia)");
            Console.WriteLine($"  emp2.EmployeeId = {emp2.EmployeeId} (propia)");
            Console.WriteLine("  Cada empleado tiene su propio ID\n");

            Console.WriteLine("Static Variables:");
            Console.WriteLine($"  Employee.TotalEmployees = {Employee.TotalEmployees} (compartida)");
            Console.WriteLine("  Todas las instancias comparten el mismo contador\n");

            Employee emp3 = new Employee(3);
            Console.WriteLine("Después de crear emp3:");
            Console.WriteLine($"  Employee.TotalEmployees = {Employee.TotalEmployees} (compartida - incrementó)");
            Console.WriteLine($"  emp1.EmployeeId = {emp1.EmployeeId} (propia - no cambió)");
            Console.WriteLine($"  emp2.EmployeeId = {emp2.EmployeeId} (propia - no cambió)");
            Console.WriteLine($"  emp3.EmployeeId = {emp3.EmployeeId} (propia)\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Object-Oriented Programming: Key Class Concepts            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateInstanceOfClass();
            Console.WriteLine("\n");
            DemonstrateReferenceOfClass();
            Console.WriteLine("\n");
            DemonstrateInstanceVariables();
            Console.WriteLine("\n");
            DemonstrateStaticVariables();
            Console.WriteLine("\n");
            DemonstrateInstanceVsReference();
            Console.WriteLine("\n");
            DemonstrateInstanceVsStaticVariables();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Instance of a Class:");
            Console.WriteLine("   • Objeto creado con 'new'");
            Console.WriteLine("   • Tiene su propia memoria");
            Console.WriteLine("   • Variables independientes de otras instancias\n");
            
            Console.WriteLine("✅ Reference of a Class:");
            Console.WriteLine("   • Variable que apunta a instancia existente");
            Console.WriteLine("   • No es una copia, es la misma instancia");
            Console.WriteLine("   • Cambios se reflejan en todas las referencias\n");
            
            Console.WriteLine("✅ Variables of a Class:");
            Console.WriteLine("   • Instance Variables: Pertenecen a cada instancia (no compartidas)");
            Console.WriteLine("   • Static Variables: Pertenecen a la clase (compartidas por todas)\n");
        }
    }

    // Clases de ejemplo para demostración

    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public class BankAccount
    {
        // Instance variables - cada instancia tiene su propia copia
        private decimal _balance;
        private string _accountNumber;

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            _accountNumber = accountNumber;
            _balance = initialBalance;
        }

        public decimal Balance => _balance;
        public string AccountNumber => _accountNumber;

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }
    }

    public class Counter
    {
        // Instance variable - cada instancia tiene su propia copia
        private int _instanceCount;

        // Static variable - compartida por todas las instancias
        public static int TotalCount = 0;

        public Counter()
        {
            _instanceCount = 0;
            TotalCount++; // Incrementa la variable compartida
        }

        public int InstanceCount => _instanceCount;

        public void Increment()
        {
            _instanceCount++;
            TotalCount++; // Incrementa la variable compartida
        }
    }

    public class Employee
    {
        // Instance variable - cada empleado tiene su propio ID
        public int EmployeeId { get; set; }

        // Static variable - compartida por todos los empleados
        public static int TotalEmployees = 0;

        public Employee(int id)
        {
            EmployeeId = id;
            TotalEmployees++; // Incrementa el contador compartido
        }
    }
}

