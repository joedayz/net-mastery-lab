using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NetMasteryLab.Concepts.AspNetCore.Logging.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Logging en .NET Core
    /// </summary>
    public class LoggingExamples
    {
        /// <summary>
        /// Demuestra Built-in ILogger
        /// </summary>
        public static void DemonstrateBuiltInLogger()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1️⃣ Built-in ILogger — Tu Punto de Partida");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  ✅ Ligero y Flexible: Incluido en ASP.NET Core");
            Console.WriteLine("  ✅ Múltiples Niveles: Information, Warning, Error, Critical");
            Console.WriteLine("  ✅ Funciona Out-of-the-Box: No necesita configuración adicional");
            Console.WriteLine("  ✅ Integrado con DI: Funciona perfectamente con Dependency Injection\n");

            Console.WriteLine("Niveles de Log:");
            Console.WriteLine("```csharp");
            Console.WriteLine("_logger.LogTrace(\"Trace - Información muy detallada\");");
            Console.WriteLine("_logger.LogDebug(\"Debug - Información de depuración\");");
            Console.WriteLine("_logger.LogInformation(\"Information - Flujo general\");");
            Console.WriteLine("_logger.LogWarning(\"Warning - Eventos inesperados\");");
            Console.WriteLine("_logger.LogError(\"Error - Errores y excepciones\");");
            Console.WriteLine("_logger.LogCritical(\"Critical - Fallos críticos\");");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo Básico:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class UserController : ControllerBase");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly ILogger<UserController> _logger;");
            Console.WriteLine("    ");
            Console.WriteLine("    public UserController(ILogger<UserController> logger)");
            Console.WriteLine("    {");
            Console.WriteLine("        _logger = logger;");
            Console.WriteLine("    }");
            Console.WriteLine("    ");
            Console.WriteLine("    public IActionResult GetUser(int id)");
            Console.WriteLine("    {");
            Console.WriteLine("        _logger.LogInformation(\"Getting user with ID: {UserId}\", id);");
            Console.WriteLine("        ");
            Console.WriteLine("        try");
            Console.WriteLine("        {");
            Console.WriteLine("            var user = _userService.GetUser(id);");
            Console.WriteLine("            _logger.LogInformation(\"User retrieved successfully: {UserId}\", id);");
            Console.WriteLine("            return Ok(user);");
            Console.WriteLine("        }");
            Console.WriteLine("        catch (Exception ex)");
            Console.WriteLine("        {");
            Console.WriteLine("            _logger.LogError(ex, \"Error retrieving user {UserId}\", id);");
            Console.WriteLine("            return StatusCode(500, \"Internal server error\");");
            Console.WriteLine("        }");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("💡 Perfecto para: Aplicaciones pequeñas o herramientas internas");
            Console.WriteLine("👉 Ejemplo: Cuando un controlador falla, ILogger registra dónde y por qué\n");
        }

        /// <summary>
        /// Demuestra Serilog
        /// </summary>
        public static void DemonstrateSerilog()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  2️⃣ Serilog — Structured & Powerful Logging");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  ✅ Structured Logging: Logs como pares clave-valor");
            Console.WriteLine("  ✅ Búsqueda Fácil: \"Encuentra todas las peticiones donde response time > 2s\"");
            Console.WriteLine("  ✅ Múltiples Sinks: Console, File, Seq, Elasticsearch, Application Insights");
            Console.WriteLine("  ✅ Rich Querying: Consultas complejas sobre logs estructurados\n");

            Console.WriteLine("Ejemplo de Log Estructurado:");
            Console.WriteLine("```csharp");
            Console.WriteLine("// ❌ ANTES: Logging plano (difícil de buscar)");
            Console.WriteLine("_logger.LogInformation($\"User {userId} performed {action} in {duration}ms\");");
            Console.WriteLine("");
            Console.WriteLine("// ✅ DESPUÉS: Logging estructurado (fácil de buscar)");
            Console.WriteLine("_logger.LogInformation(");
            Console.WriteLine("    \"User {UserId} performed {Action} in {Duration}ms\",");
            Console.WriteLine("    userId, action, duration);");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo de Output:");
            Console.WriteLine("```json");
            Console.WriteLine("{");
            Console.WriteLine("  \"Timestamp\": \"2024-01-15T10:30:00Z\",");
            Console.WriteLine("  \"Level\": \"Information\",");
            Console.WriteLine("  \"Message\": \"User 101 performed Checkout in 1800ms\",");
            Console.WriteLine("  \"UserId\": 101,");
            Console.WriteLine("  \"Action\": \"Checkout\",");
            Console.WriteLine("  \"Duration\": 1800");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Configuración:");
            Console.WriteLine("```csharp");
            Console.WriteLine("Log.Logger = new LoggerConfiguration()");
            Console.WriteLine("    .WriteTo.Console()");
            Console.WriteLine("    .WriteTo.File(\"logs/app.log\", rollingInterval: RollingInterval.Day)");
            Console.WriteLine("    .WriteTo.Seq(\"http://localhost:5341\")");
            Console.WriteLine("    .CreateLogger();");
            Console.WriteLine("");
            Console.WriteLine("builder.Host.UseSerilog();");
            Console.WriteLine("```\n");

            Console.WriteLine("💡 Ideal para: Sistemas de producción que requieren insights ricos y consultables\n");
        }

        /// <summary>
        /// Demuestra NLog
        /// </summary>
        public static void DemonstrateNLog()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  3️⃣ NLog — Simple, Fast & Flexible");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  ✅ Ligero: Configuración mínima requerida");
            Console.WriteLine("  ✅ Rápido: Conocido por su velocidad");
            Console.WriteLine("  ✅ Flexible: Soporta múltiples destinos");
            Console.WriteLine("  ✅ Múltiples Targets: Archivos, bases de datos, email, event logs\n");

            Console.WriteLine("Configuración (nlog.config):");
            Console.WriteLine("```xml");
            Console.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            Console.WriteLine("<nlog xmlns=\"http://www.nlog-project.org/schemas/NLog.xsd\">");
            Console.WriteLine("  <targets>");
            Console.WriteLine("    <target xsi:type=\"File\" name=\"fileTarget\"");
            Console.WriteLine("            fileName=\"logs/app.log\"");
            Console.WriteLine("            layout=\"${longdate} ${level} ${message} ${exception}\" />");
            Console.WriteLine("    <target xsi:type=\"Console\" name=\"consoleTarget\"");
            Console.WriteLine("            layout=\"${longdate} ${level} ${message} ${exception}\" />");
            Console.WriteLine("  </targets>");
            Console.WriteLine("  <rules>");
            Console.WriteLine("    <logger name=\"*\" minlevel=\"Info\" writeTo=\"fileTarget,consoleTarget\" />");
            Console.WriteLine("  </rules>");
            Console.WriteLine("</nlog>");
            Console.WriteLine("```\n");

            Console.WriteLine("Uso:");
            Console.WriteLine("```csharp");
            Console.WriteLine("private static readonly Logger Logger = LogManager.GetCurrentClassLogger();");
            Console.WriteLine("");
            Console.WriteLine("Logger.Info(\"Processing payment {PaymentId} for amount {Amount}\",");
            Console.WriteLine("    payment.Id, payment.Amount);");
            Console.WriteLine("```\n");

            Console.WriteLine("💡 Si el rendimiento y la simplicidad son prioridades principales, NLog es una excelente opción\n");
        }

        /// <summary>
        /// Demuestra mejores prácticas
        /// </summary>
        public static void DemonstrateBestPractices()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ Mejores Prácticas para Logging Como un Pro");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Preferir Logs Estructurados sobre Texto Plano");
            Console.WriteLine("```csharp");
            Console.WriteLine("// ❌ MAL: Logging plano (difícil de buscar)");
            Console.WriteLine("_logger.LogInformation($\"User {userId} performed {action}\");");
            Console.WriteLine("");
            Console.WriteLine("// ✅ BIEN: Logging estructurado (fácil de buscar)");
            Console.WriteLine("_logger.LogInformation(\"User {UserId} performed {Action}\", userId, action);");
            Console.WriteLine("```\n");

            Console.WriteLine("2. Mantener Formatos de Log Consistentes");
            Console.WriteLine("```csharp");
            Console.WriteLine("// ✅ BIEN: Formato consistente");
            Console.WriteLine("_logger.LogInformation(\"Order {OrderId} created by user {UserId}\",");
            Console.WriteLine("    orderId, userId);");
            Console.WriteLine("```\n");

            Console.WriteLine("3. Nunca Registrar Información Sensible");
            Console.WriteLine("```csharp");
            Console.WriteLine("// ❌ MAL: Registrar información sensible");
            Console.WriteLine("_logger.LogInformation(\"User {UserId} logged in with password {Password}\",");
            Console.WriteLine("    userId, password);");
            Console.WriteLine("");
            Console.WriteLine("// ✅ BIEN: No registrar información sensible");
            Console.WriteLine("_logger.LogInformation(\"User {UserId} logged in successfully\", userId);");
            Console.WriteLine("```\n");

            Console.WriteLine("4. Centralizar Logs");
            Console.WriteLine("```csharp");
            Console.WriteLine("Log.Logger = new LoggerConfiguration()");
            Console.WriteLine("    .WriteTo.Console()");
            Console.WriteLine("    .WriteTo.Seq(\"http://seq-server:5341\")  // Centralizado");
            Console.WriteLine("    .WriteTo.AzureAnalytics(workspaceId, authenticationId)");
            Console.WriteLine("    .CreateLogger();");
            Console.WriteLine("```\n");

            Console.WriteLine("5. Usar Niveles de Log Sabiamente");
            Console.WriteLine("  • Trace: Información muy detallada (solo desarrollo)");
            Console.WriteLine("  • Debug: Información de depuración (solo desarrollo)");
            Console.WriteLine("  • Information: Flujo general de la aplicación");
            Console.WriteLine("  • Warning: Eventos inesperados pero manejables");
            Console.WriteLine("  • Error: Errores y excepciones");
            Console.WriteLine("  • Critical: Fallos críticos que requieren atención inmediata\n");
        }

        /// <summary>
        /// Demuestra cuándo usar cada opción
        /// </summary>
        public static void DemonstrateWhenToUse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Cuándo Usar Cada Opción");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Usa Built-in ILogger cuando:");
            Console.WriteLine("  • Tienes una aplicación pequeña o interna");
            Console.WriteLine("  • No necesitas logging estructurado avanzado");
            Console.WriteLine("  • Quieres algo que funcione sin configuración");
            Console.WriteLine("  • Estás empezando con .NET Core\n");

            Console.WriteLine("✅ Usa Serilog cuando:");
            Console.WriteLine("  • Necesitas logging estructurado completo");
            Console.WriteLine("  • Quieres múltiples sinks (Seq, Elasticsearch, etc.)");
            Console.WriteLine("  • Necesitas búsqueda avanzada de logs");
            Console.WriteLine("  • Estás construyendo sistemas de producción complejos\n");

            Console.WriteLine("✅ Usa NLog cuando:");
            Console.WriteLine("  • Priorizas rendimiento y simplicidad");
            Console.WriteLine("  • Trabajas con background services");
            Console.WriteLine("  • Migras aplicaciones legacy");
            Console.WriteLine("  • Necesitas configuración flexible\n");
        }

        /// <summary>
        /// Demuestra ejemplos prácticos
        /// </summary>
        public static void DemonstratePracticalExamples()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📚 Ejemplos Prácticos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo 1: Logging en Controladores");
            Console.WriteLine("```csharp");
            Console.WriteLine("[ApiController]");
            Console.WriteLine("[Route(\"api/[controller]\")]");
            Console.WriteLine("public class UsersController : ControllerBase");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly ILogger<UsersController> _logger;");
            Console.WriteLine("    ");
            Console.WriteLine("    [HttpGet(\"{id}\")]");
            Console.WriteLine("    public async Task<IActionResult> GetUser(int id)");
            Console.WriteLine("    {");
            Console.WriteLine("        _logger.LogInformation(\"Getting user {UserId}\", id);");
            Console.WriteLine("        ");
            Console.WriteLine("        try");
            Console.WriteLine("        {");
            Console.WriteLine("            var user = await _userService.GetUserAsync(id);");
            Console.WriteLine("            _logger.LogInformation(\"User {UserId} retrieved successfully\", id);");
            Console.WriteLine("            return Ok(user);");
            Console.WriteLine("        }");
            Console.WriteLine("        catch (Exception ex)");
            Console.WriteLine("        {");
            Console.WriteLine("            _logger.LogError(ex, \"Error retrieving user {UserId}\", id);");
            Console.WriteLine("            return StatusCode(500, \"Internal server error\");");
            Console.WriteLine("        }");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 2: Logging con Scopes");
            Console.WriteLine("```csharp");
            Console.WriteLine("using (_logger.BeginScope(\"OrderId: {OrderId}\", orderId))");
            Console.WriteLine("{");
            Console.WriteLine("    _logger.LogInformation(\"Starting order processing\");");
            Console.WriteLine("    // Todos los logs dentro de este scope incluirán OrderId");
            Console.WriteLine("    _logger.LogInformation(\"Validating order items\");");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Logging in .NET Core — The Backbone of Every Reliable    ║");
            Console.WriteLine("║                      Application                              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateBuiltInLogger();
            Console.WriteLine("\n");
            DemonstrateSerilog();
            Console.WriteLine("\n");
            DemonstrateNLog();
            Console.WriteLine("\n");
            DemonstrateBestPractices();
            Console.WriteLine("\n");
            DemonstrateWhenToUse();
            Console.WriteLine("\n");
            DemonstratePracticalExamples();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Logging en .NET Core:");
            Console.WriteLine("   • Built-in ILogger: Ligero, flexible, out-of-the-box");
            Console.WriteLine("   • Serilog: Structured logging completo con múltiples sinks");
            Console.WriteLine("   • NLog: Simple, rápido y flexible\n");
            
            Console.WriteLine("🚀 Mejores Prácticas:");
            Console.WriteLine("   • Preferir logs estructurados sobre texto plano");
            Console.WriteLine("   • Mantener formatos consistentes");
            Console.WriteLine("   • Nunca registrar información sensible");
            Console.WriteLine("   • Centralizar logs");
            Console.WriteLine("   • Usar niveles de log sabiamente\n");
            
            Console.WriteLine("📦 Instalación:");
            Console.WriteLine("   Serilog: dotnet add package Serilog.AspNetCore");
            Console.WriteLine("   NLog: dotnet add package NLog.Web.AspNetCore\n");
        }
    }
}

