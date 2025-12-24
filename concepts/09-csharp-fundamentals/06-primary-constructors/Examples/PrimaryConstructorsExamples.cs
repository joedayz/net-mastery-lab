namespace NetMasteryLab.Concepts.CSharpFundamentals.PrimaryConstructors.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Primary Constructors en C#
    /// </summary>
    public class PrimaryConstructorsExamples
    {
        /// <summary>
        /// Demuestra la reducción de código con Primary Constructors
        /// </summary>
        public static void DemonstrateCodeReduction()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✨ Reducción de Código con Primary Constructors");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ ANTES: Código verboso con constructor tradicional");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Customer");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly string _name;");
            Console.WriteLine("    private readonly string _email;");
            Console.WriteLine("    ");
            Console.WriteLine("    public Customer(string name, string email)");
            Console.WriteLine("    {");
            Console.WriteLine("        _name = name;");
            Console.WriteLine("        _email = email;");
            Console.WriteLine("    }");
            Console.WriteLine("    ");
            Console.WriteLine("    public string Greeting() => $\"Hello {_name}!\";");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ DESPUÉS: Primary Constructor - mucho más conciso");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Customer(string name, string email)");
            Console.WriteLine("{");
            Console.WriteLine("    public string Greeting() => $\"Hello {name}!\";");
            Console.WriteLine("    public void SendEmail() => Console.WriteLine($\"Sending to {email}\");");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  ✅ Reduce código en ~50%");
            Console.WriteLine("  ✅ Parámetros automáticamente disponibles");
            Console.WriteLine("  ✅ Menos boilerplate\n");
        }

        /// <summary>
        /// Demuestra Primary Constructors para Service Classes
        /// </summary>
        public static void DemonstrateServiceClasses()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔥 Primary Constructors para Service Classes");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ TRADICIONAL: Mucho boilerplate");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class OrderService");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly IOrderRepository _orderRepository;");
            Console.WriteLine("    private readonly IEmailService _emailService;");
            Console.WriteLine("    private readonly ILogger<OrderService> _logger;");
            Console.WriteLine("    ");
            Console.WriteLine("    public OrderService(");
            Console.WriteLine("        IOrderRepository orderRepository,");
            Console.WriteLine("        IEmailService emailService,");
            Console.WriteLine("        ILogger<OrderService> logger)");
            Console.WriteLine("    {");
            Console.WriteLine("        _orderRepository = orderRepository;");
            Console.WriteLine("        _emailService = emailService;");
            Console.WriteLine("        _logger = logger;");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ PRIMARY CONSTRUCTOR: Código limpio y conciso");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class OrderService(");
            Console.WriteLine("    IOrderRepository orderRepository,");
            Console.WriteLine("    IEmailService emailService,");
            Console.WriteLine("    ILogger<OrderService> logger)");
            Console.WriteLine("{");
            Console.WriteLine("    public async Task<Order> CreateOrderAsync(CreateOrderDto dto)");
            Console.WriteLine("    {");
            Console.WriteLine("        logger.LogInformation(\"Creating order...\");");
            Console.WriteLine("        // ...");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  ✅ Perfecto para Dependency Injection");
            Console.WriteLine("  ✅ Ideal para clases con dependencias claras");
            Console.WriteLine("  ✅ Sigue principios SOLID\n");
        }

        /// <summary>
        /// Demuestra Primary Constructors con Records
        /// </summary>
        public static void DemonstrateWithRecords()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Primary Constructors con Record Types");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Primary Constructor con record para máxima inmutabilidad");
            Console.WriteLine("```csharp");
            Console.WriteLine("public record Customer(string Name, string Email)");
            Console.WriteLine("{");
            Console.WriteLine("    public string Greeting() => $\"Hello {Name}!\";");
            Console.WriteLine("    public void SendEmail() => Console.WriteLine($\"Sending to {Email}\");");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Uso:");
            Console.WriteLine("  var customer = new Customer(\"John Doe\", \"john@example.com\");");
            Console.WriteLine("  var updated = customer with { Email = \"newemail@example.com\" };");
            Console.WriteLine("  // Inmutabilidad + Primary Constructor = Poder combinado\n");
        }

        /// <summary>
        /// Demuestra Primary Constructors para DDD Entities
        /// </summary>
        public static void DemonstrateDDDEntities()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🏗️ Primary Constructors para DDD Entities");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Entidad DDD con Primary Constructor");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order(int orderId, int customerId, decimal total)");
            Console.WriteLine("{");
            Console.WriteLine("    public int OrderId => orderId;");
            Console.WriteLine("    public int CustomerId => customerId;");
            Console.WriteLine("    public decimal Total => total;");
            Console.WriteLine("    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;");
            Console.WriteLine("    ");
            Console.WriteLine("    public bool CanBeCancelled() => Total > 0;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Perfecto para:");
            Console.WriteLine("  ✅ Domain-Driven Design");
            Console.WriteLine("  ✅ Entidades inmutables");
            Console.WriteLine("  ✅ Value Objects\n");
        }

        /// <summary>
        /// Demuestra Primary Constructors con Init-Only Properties
        /// </summary>
        public static void DemonstrateWithInitProperties()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔒 Primary Constructors con Init-Only Properties");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Combinar Primary Constructor con init-only properties");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Product(string name, decimal price)");
            Console.WriteLine("{");
            Console.WriteLine("    public string Name => name;");
            Console.WriteLine("    public decimal Price => price;");
            Console.WriteLine("    public int Stock { get; init; }");
            Console.WriteLine("    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Uso:");
            Console.WriteLine("  var product = new Product(\"Laptop\", 999.99m)");
            Console.WriteLine("  {");
            Console.WriteLine("      Stock = 10");
            Console.WriteLine("  };");
            Console.WriteLine("  // Inmutabilidad después de la inicialización\n");
        }

        /// <summary>
        /// Demuestra mejores prácticas
        /// </summary>
        public static void DemonstrateBestPractices()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Mejores Prácticas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Usar para clases con dependencias claras:");
            Console.WriteLine("   ✅ Service classes con DI");
            Console.WriteLine("   ✅ Repository classes");
            Console.WriteLine("   ✅ Validator classes\n");

            Console.WriteLine("2. Perfecto para Dependency Injection Pattern:");
            Console.WriteLine("   ✅ Dependencias en Primary Constructor");
            Console.WriteLine("   ✅ Automáticamente compatible con DI containers\n");

            Console.WriteLine("3. Combinar con init-only properties:");
            Console.WriteLine("   ✅ Para objetos inmutables");
            Console.WriteLine("   ✅ Propiedades opcionales\n");

            Console.WriteLine("4. Ideal para clases pequeñas y enfocadas:");
            Console.WriteLine("   ✅ Sigue principios SOLID");
            Console.WriteLine("   ✅ Single Responsibility Principle\n");
        }

        /// <summary>
        /// Demuestra casos de uso específicos
        /// </summary>
        public static void DemonstrateUseCases()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Casos de Uso Específicos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Service Classes:");
            Console.WriteLine("   ✅ OrderService, UserService, PaymentService");
            Console.WriteLine("   ✅ Múltiples dependencias inyectadas\n");

            Console.WriteLine("2. Value Objects (DDD):");
            Console.WriteLine("   ✅ Money, Address, Email");
            Console.WriteLine("   ✅ Objetos inmutables\n");

            Console.WriteLine("3. Configuration Classes:");
            Console.WriteLine("   ✅ DatabaseOptions, ApiOptions");
            Console.WriteLine("   ✅ Settings y configuración\n");

            Console.WriteLine("4. Factory Classes:");
            Console.WriteLine("   ✅ OrderFactory, UserFactory");
            Console.WriteLine("   ✅ Creación de objetos\n");
        }

        /// <summary>
        /// Demuestra consideraciones y limitaciones
        /// </summary>
        public static void DemonstrateConsiderations()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Consideraciones y Limitaciones");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. No puedes modificar parámetros:");
            Console.WriteLine("   ❌ name = newName; // Error");
            Console.WriteLine("   ✅ Usar propiedades si necesitas mutabilidad\n");

            Console.WriteLine("2. Parámetros son capturados, no campos:");
            Console.WriteLine("   ⚠️ No son campos reales de la clase");
            Console.WriteLine("   ⚠️ No puedes hacer: private string _name = name;\n");

            Console.WriteLine("3. Usar con cuidado en clases complejas:");
            Console.WriteLine("   ⚠️ Demasiados parámetros pueden reducir legibilidad");
            Console.WriteLine("   ✅ Considerar agrupar dependencias relacionadas\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              Primary Constructors en C#                       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateCodeReduction();
            Console.WriteLine("\n");
            DemonstrateServiceClasses();
            Console.WriteLine("\n");
            DemonstrateWithRecords();
            Console.WriteLine("\n");
            DemonstrateDDDEntities();
            Console.WriteLine("\n");
            DemonstrateWithInitProperties();
            Console.WriteLine("\n");
            DemonstrateBestPractices();
            Console.WriteLine("\n");
            DemonstrateUseCases();
            Console.WriteLine("\n");
            DemonstrateConsiderations();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Primary Constructors:");
            Console.WriteLine("   • Reduce código en ~50%");
            Console.WriteLine("   • Parámetros automáticamente disponibles");
            Console.WriteLine("   • Elimina boilerplate de constructores\n");
            
            Console.WriteLine("✅ Ideal Para:");
            Console.WriteLine("   • Service classes con DI");
            Console.WriteLine("   • DDD entities y value objects");
            Console.WriteLine("   • Clases centradas en datos");
            Console.WriteLine("   • Objetos inmutables\n");
            
            Console.WriteLine("✅ Mejores Prácticas:");
            Console.WriteLine("   • Usar para clases con dependencias claras");
            Console.WriteLine("   • Perfecto para Dependency Injection");
            Console.WriteLine("   • Combinar con init-only properties");
            Console.WriteLine("   • Ideal para clases pequeñas y enfocadas (SOLID)\n");
            
            Console.WriteLine("💡 Pro Tip:");
            Console.WriteLine("   • Primary Constructors brillan en service classes");
            Console.WriteLine("   • Se combinan perfectamente con record types");
            Console.WriteLine("   • Reducen significativamente el boilerplate\n");
        }
    }

    // Clases de ejemplo para demostración

    // ANTES: Constructor tradicional
    public class CustomerTraditional
    {
        private readonly string _name;
        private readonly string _email;
        
        public CustomerTraditional(string name, string email)
        {
            _name = name;
            _email = email;
        }
        
        public string Greeting() => $"Hello {_name}!";
        public void SendEmail() => Console.WriteLine($"Sending to {_email}");
    }

    // DESPUÉS: Primary Constructor
    public class Customer(string name, string email)
    {
        public string Greeting() => $"Hello {name}!";
        public void SendEmail() => Console.WriteLine($"Sending to {email}");
    }

    // Service class con Primary Constructor
    public class OrderService(
        IOrderRepository orderRepository,
        IEmailService emailService,
        ILogger logger)
    {
        public async Task<Order> CreateOrderAsync(CreateOrderDto dto)
        {
            logger.LogInformation("Creating order for customer {CustomerId}", dto.CustomerId);
            var order = new Order(0, dto.CustomerId, dto.Total);
            await orderRepository.AddAsync(order);
            await emailService.SendOrderConfirmationAsync(order);
            return order;
        }
    }

    // Record con Primary Constructor
    public record CustomerRecord(string Name, string Email)
    {
        public string Greeting() => $"Hello {Name}!";
    }

    // DDD Entity con Primary Constructor
    public class Order(int orderId, int customerId, decimal total)
    {
        public int OrderId => orderId;
        public int CustomerId => customerId;
        public decimal Total => total;
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        
        public bool CanBeCancelled() => Total > 0;
    }

    // Product con Primary Constructor + Init-only properties
    public class Product(string name, decimal price)
    {
        public string Name => name;
        public decimal Price => price;
        public int Stock { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }

    // Interfaces y clases de ejemplo
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
    }

    public interface IEmailService
    {
        Task SendOrderConfirmationAsync(Order order);
    }

    public interface ILogger
    {
        void LogInformation(string message, params object[] args);
    }

    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
    }
}

