namespace NetMasteryLab.Concepts.CleanCode.NamingConventions.Examples
{
    /// <summary>
    /// Ejemplos que demuestran las convenciones de nomenclatura correctas en C#
    /// </summary>
    public class NamingConventionsExamples
    {
        // ✅ BIEN: Campo privado con prefijo _
        #pragma warning disable CS0169 // Campo usado para demostrar convenciones de nomenclatura
        private int _userId;
        private string? _userName;
        private List<ExampleOrder>? _orders;
        #pragma warning restore CS0169

        // ✅ BIEN: Constante en PascalCase
        public const int MaxRetries = 3;
        public const string DefaultConnectionString = "Server=localhost";

    /// <summary>
    /// Demuestra convenciones para clases y namespaces
    /// </summary>
    public static void DemonstrateClassAndNamespaceConventions()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  📦 Clases y Namespaces");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("✅ BIEN:");
        Console.WriteLine("  namespace MyCompany.MyProject.Services;");
        Console.WriteLine("  public class UserService { }");
        Console.WriteLine("  public class OrderRepository { }\n");

        Console.WriteLine("❌ MAL:");
        Console.WriteLine("  namespace myCompany.myProject; // camelCase");
        Console.WriteLine("  public class userService { } // camelCase");
        Console.WriteLine("  public class Users { } // Plural (a menos que sea una colección)\n");

        Console.WriteLine("Reglas:");
        Console.WriteLine("  • Namespace: PascalCase, puede ser plural");
        Console.WriteLine("  • Class: PascalCase, NO puede ser plural\n");
    }

    /// <summary>
    /// Demuestra convenciones para métodos y argumentos
    /// </summary>
    public static void DemonstrateMethodConventions()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🔧 Métodos y Argumentos");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("✅ BIEN:");
        Console.WriteLine("  public void ProcessOrder(int orderId, List<OrderItem> orderItems)");
        Console.WriteLine("  public User GetUserById(int userId)");
        Console.WriteLine("  public void CalculateTotal(decimal amount, decimal tax)\n");

        Console.WriteLine("❌ MAL:");
        Console.WriteLine("  public void processOrder(int OrderId) // método en camelCase");
        Console.WriteLine("  public void ProcessOrder(int ORDER_ID) // argumento en UPPERCASE\n");

        Console.WriteLine("Reglas:");
        Console.WriteLine("  • Method: PascalCase, puede ser plural");
        Console.WriteLine("  • Arguments: camelCase, puede ser plural\n");
    }

    /// <summary>
    /// Demuestra convenciones para variables locales
    /// </summary>
    public static void DemonstrateLocalVariableConventions()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  📝 Variables Locales");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("✅ BIEN:");
        Console.WriteLine("  var userCount = 10;");
        Console.WriteLine("  var totalAmount = 100.50m;");
        Console.WriteLine("  var orderItems = new List<OrderItem>();");
        Console.WriteLine("  string customerName = \"John\";\n");

        Console.WriteLine("❌ MAL:");
        Console.WriteLine("  var UserCount = 10; // PascalCase");
        Console.WriteLine("  var TOTAL_AMOUNT = 100.50m; // UPPERCASE");
        Console.WriteLine("  var uCount = 10; // Abreviación poco clara\n");

        Console.WriteLine("Reglas:");
        Console.WriteLine("  • Local variables: camelCase, puede ser plural");
        Console.WriteLine("  • Usa nombres descriptivos, evita abreviaciones\n");
    }

    /// <summary>
    /// Demuestra convenciones para campos y propiedades
    /// </summary>
    public static void DemonstrateFieldAndPropertyConventions()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🏷️  Campos y Propiedades");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("✅ BIEN:");
        Console.WriteLine("  // Campo público");
        Console.WriteLine("  public int UserId;");
        Console.WriteLine("  ");
        Console.WriteLine("  // Campo privado");
        Console.WriteLine("  private int _userId;");
        Console.WriteLine("  ");
        Console.WriteLine("  // Propiedad");
        Console.WriteLine("  public int UserId { get; set; }");
        Console.WriteLine("  public List<Order> Orders { get; set; }\n");

        Console.WriteLine("❌ MAL:");
        Console.WriteLine("  public int userId; // camelCase en campo público");
        Console.WriteLine("  private int userId; // Sin prefijo _ en campo privado");
        Console.WriteLine("  public int userId { get; set; } // camelCase en propiedad\n");

        Console.WriteLine("Reglas:");
        Console.WriteLine("  • Public field: PascalCase");
        Console.WriteLine("  • Private field: _camelCase (prefijo con _)");
        Console.WriteLine("  • Property: PascalCase\n");
    }

    /// <summary>
    /// Demuestra convenciones para interfaces
    /// </summary>
    public static void DemonstrateInterfaceConventions()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🔌 Interfaces");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("✅ BIEN:");
        Console.WriteLine("  public interface IUserService { }");
        Console.WriteLine("  public interface IRepository<T> { }");
        Console.WriteLine("  public interface IOrderProcessor { }\n");

        Console.WriteLine("❌ MAL:");
        Console.WriteLine("  public interface UserService { } // Sin prefijo 'I'");
        Console.WriteLine("  public interface IUserServices { } // Plural");
        Console.WriteLine("  public interface iUserService { } // 'i' minúscula\n");

        Console.WriteLine("Reglas:");
        Console.WriteLine("  • Interface: IPascalCase (prefijo con 'I' mayúscula)");
        Console.WriteLine("  • NO puede ser plural\n");
    }

    /// <summary>
    /// Demuestra convenciones para constantes y enums
    /// </summary>
    public static void DemonstrateConstantsAndEnumsConventions()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  📌 Constantes y Enums");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("✅ BIEN:");
        Console.WriteLine("  public const int MaxRetries = 3;");
        Console.WriteLine("  public const string DefaultConnectionString = \"...\";");
        Console.WriteLine("  ");
        Console.WriteLine("  public enum OrderStatus { Pending, Completed, Cancelled }");
        Console.WriteLine("  public enum UserRoles { Admin, User, Guest }\n");

        Console.WriteLine("❌ MAL:");
        Console.WriteLine("  public const int MAX_RETRIES = 3; // UPPERCASE (aunque algunos lo usan)");
        Console.WriteLine("  public const int maxRetries = 3; // camelCase");
        Console.WriteLine("  public enum orderStatus { } // camelCase\n");

        Console.WriteLine("Reglas:");
        Console.WriteLine("  • Constants: PascalCase, NO puede ser plural");
        Console.WriteLine("  • Enum: PascalCase, puede ser plural\n");
    }

    /// <summary>
    /// Demuestra mejores prácticas adicionales
    /// </summary>
    public static void DemonstrateBestPractices()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  💡 Mejores Prácticas Adicionales");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("1. Nombres Descriptivos:");
        Console.WriteLine("  ✅ var userAccountBalance = 1000m;");
        Console.WriteLine("  ❌ var uab = 1000m;\n");

        Console.WriteLine("2. Evitar Abreviaciones:");
        Console.WriteLine("  ✅ var customerAccount = GetAccount();");
        Console.WriteLine("  ❌ var custAcct = GetAccount();\n");

        Console.WriteLine("3. Nombres de Booleanos:");
        Console.WriteLine("  ✅ public bool IsActive { get; set; }");
        Console.WriteLine("  ✅ public bool HasPermission { get; set; }");
        Console.WriteLine("  ✅ public bool CanEdit { get; set; }");
        Console.WriteLine("  ❌ public bool Active { get; set; } // Menos claro\n");

        Console.WriteLine("4. Nombres de Métodos (Verbos):");
        Console.WriteLine("  ✅ public void ProcessOrder() { }");
        Console.WriteLine("  ✅ public User GetUserById(int id) { }");
        Console.WriteLine("  ✅ public bool ValidateEmail(string email) { }");
        Console.WriteLine("  ❌ public void Order() { } // ¿Qué hace?\n");
    }

    /// <summary>
    /// Ejecuta todos los ejemplos
    /// </summary>
    public static void RunAllExamples()
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     Use the Proper Naming Convention - C# Clean Code         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

        DemonstrateClassAndNamespaceConventions();
        Console.WriteLine("\n");
        DemonstrateMethodConventions();
        Console.WriteLine("\n");
        DemonstrateLocalVariableConventions();
        Console.WriteLine("\n");
        DemonstrateFieldAndPropertyConventions();
        Console.WriteLine("\n");
        DemonstrateInterfaceConventions();
        Console.WriteLine("\n");
        DemonstrateConstantsAndEnumsConventions();
        Console.WriteLine("\n");
        DemonstrateBestPractices();

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  RESUMEN - TABLA DE CONVENCIONES");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        Console.WriteLine("┌─────────────────────┬──────────────┬─────────────────┐");
        Console.WriteLine("│ Tipo de Objeto      │ Notación     │ ¿Puede Plural?  │");
        Console.WriteLine("├─────────────────────┼──────────────┼─────────────────┤");
        Console.WriteLine("│ Namespace name      │ PascalCase   │ ✅ Sí           │");
        Console.WriteLine("│ Class name          │ PascalCase   │ ❌ No           │");
        Console.WriteLine("│ Constructor name    │ PascalCase   │ ❌ No           │");
        Console.WriteLine("│ Method name         │ PascalCase   │ ✅ Sí           │");
        Console.WriteLine("│ Method arguments    │ camelCase    │ ✅ Sí           │");
        Console.WriteLine("│ Local variables     │ camelCase    │ ✅ Sí           │");
        Console.WriteLine("│ Constants name      │ PascalCase   │ ❌ No           │");
        Console.WriteLine("│ Field name Public   │ PascalCase   │ ✅ Sí           │");
        Console.WriteLine("│ Field name Private  │ _camelCase   │ ✅ Sí           │");
        Console.WriteLine("│ Properties name     │ PascalCase   │ ✅ Sí           │");
        Console.WriteLine("│ Interface           │ IPascalCase  │ ❌ No           │");
        Console.WriteLine("│ Enum type name      │ PascalCase   │ ✅ Sí           │");
        Console.WriteLine("└─────────────────────┴──────────────┴─────────────────┘\n");
    }
    }
}

// Clases de ejemplo para demostrar las convenciones
public class ExampleUser 
{ 
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class ExampleOrder 
{ 
    public int Id { get; set; }
    public decimal Total { get; set; }
}

// Ejemplos de clases que demuestran las convenciones
namespace MyCompany.MyProject.Services
{
    public interface IUserService
    {
        ExampleUser GetUserById(int userId);
        List<ExampleUser> GetUsers();
    }

    public class UserService : IUserService
    {
        #pragma warning disable CS0169 // Campo usado para demostrar convenciones de nomenclatura
        private int _userId;
        private List<ExampleOrder>? _orders;
        #pragma warning restore CS0169

        public const int MaxRetries = 3;

        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ExampleOrder> Orders { get; set; } = new();

        public ExampleUser GetUserById(int userId)
        {
            var user = new ExampleUser();
            return user;
        }

        public List<ExampleUser> GetUsers()
        {
            return new List<ExampleUser>();
        }
    }

    public enum OrderStatus
    {
        Pending,
        Completed,
        Cancelled
    }
}

