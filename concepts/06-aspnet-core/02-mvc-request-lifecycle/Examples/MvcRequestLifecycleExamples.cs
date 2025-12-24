namespace NetMasteryLab.Concepts.AspNetCore.MvcRequestLifecycle.Examples
{
    /// <summary>
    /// Ejemplos que demuestran el ASP.NET Core MVC Request Life Cycle
    /// </summary>
    public class MvcRequestLifecycleExamples
    {
        /// <summary>
        /// Demuestra el ciclo de vida completo de una petición
        /// </summary>
        public static void DemonstrateRequestLifecycle()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 ASP.NET Core MVC Request Life Cycle");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("El ciclo de vida completo de una petición:");
            Console.WriteLine("  HTTP Request → Middleware → Routing → Controller Initialization →");
            Console.WriteLine("  Action Method Execution → Result Execution → View Rendering → Response\n");
        }

        /// <summary>
        /// Demuestra Middleware Pipeline
        /// </summary>
        public static void DemonstrateMiddlewarePipeline()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  1. Middleware Pipeline 🔐");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("El primer punto de parada, donde las peticiones se procesan");
            Console.WriteLine("a través de varias capas de middleware.\n");

            Console.WriteLine("Ejemplo de configuración:");
            Console.WriteLine("```csharp");
            Console.WriteLine("app.UseMiddleware<CustomLoggingMiddleware>();");
            Console.WriteLine("app.UseAuthentication();");
            Console.WriteLine("app.UseAuthorization();");
            Console.WriteLine("app.UseRouting();");
            Console.WriteLine("```\n");

            Console.WriteLine("Middlewares comunes:");
            Console.WriteLine("  • Exception Handling: Manejo global de excepciones");
            Console.WriteLine("  • HTTPS Redirection: Redirección a HTTPS");
            Console.WriteLine("  • Static Files: Servir archivos estáticos");
            Console.WriteLine("  • Authentication: Autenticación de usuarios");
            Console.WriteLine("  • Authorization: Autorización de recursos");
            Console.WriteLine("  • CORS: Cross-Origin Resource Sharing\n");
        }

        /// <summary>
        /// Demuestra Routing
        /// </summary>
        public static void DemonstrateRouting()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  2. Routing 🛣️");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("La petición es dirigida al controlador y acción correctos");
            Console.WriteLine("a través del sistema de routing.\n");

            Console.WriteLine("Ejemplo: Routing basado en convenciones");
            Console.WriteLine("```csharp");
            Console.WriteLine("app.MapControllerRoute(");
            Console.WriteLine("    name: \"default\",");
            Console.WriteLine("    pattern: \"{controller=Home}/{action=Index}/{id?}\");");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo: Routing basado en atributos");
            Console.WriteLine("```csharp");
            Console.WriteLine("[Route(\"api/[controller]\")]");
            Console.WriteLine("public class OrdersController : ControllerBase");
            Console.WriteLine("{");
            Console.WriteLine("    [HttpGet(\"{id}\")]");
            Console.WriteLine("    public IActionResult GetOrder(int id) { }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra Controller Initialization
        /// </summary>
        public static void DemonstrateControllerInitialization()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  3. Controller Initialization ⚙️");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Después del routing, el controlador apropiado se instancia,");
            Console.WriteLine("junto con cualquier dependencia que requiera.\n");

            Console.WriteLine("Ejemplo:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class OrdersController : ControllerBase");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly IOrderService _orderService;");
            Console.WriteLine("    private readonly ILogger<OrdersController> _logger;");
            Console.WriteLine("    ");
            Console.WriteLine("    // Dependency Injection en constructor");
            Console.WriteLine("    public OrdersController(");
            Console.WriteLine("        IOrderService orderService,");
            Console.WriteLine("        ILogger<OrdersController> logger)");
            Console.WriteLine("    {");
            Console.WriteLine("        _orderService = orderService;");
            Console.WriteLine("        _logger = logger;");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Proceso:");
            Console.WriteLine("  1. Service Resolution: Resolver servicios del contenedor DI");
            Console.WriteLine("  2. Constructor Injection: Inyectar dependencias");
            Console.WriteLine("  3. Controller Creation: Crear instancia del controlador");
            Console.WriteLine("  4. Action Selection: Seleccionar el método de acción\n");
        }

        /// <summary>
        /// Demuestra Action Method Execution
        /// </summary>
        public static void DemonstrateActionExecution()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  4. Action Method Execution 🎯");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("El núcleo del procesamiento de la petición.");
            Console.WriteLine("Tu acción ejecuta la lógica de negocio y prepara el resultado.\n");

            Console.WriteLine("Ejemplo:");
            Console.WriteLine("```csharp");
            Console.WriteLine("[HttpPost]");
            Console.WriteLine("public async Task<IActionResult> CreateOrder(CreateOrderDto dto)");
            Console.WriteLine("{");
            Console.WriteLine("    // Model Binding: dto se llena automáticamente");
            Console.WriteLine("    // Validation: Se valida automáticamente");
            Console.WriteLine("    ");
            Console.WriteLine("    if (!ModelState.IsValid)");
            Console.WriteLine("        return BadRequest(ModelState);");
            Console.WriteLine("    ");
            Console.WriteLine("    // Business Logic");
            Console.WriteLine("    var order = await _orderService.CreateOrderAsync(dto);");
            Console.WriteLine("    ");
            Console.WriteLine("    // Result Preparation");
            Console.WriteLine("    return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Fases:");
            Console.WriteLine("  1. Model Binding: Binding de parámetros y modelos");
            Console.WriteLine("  2. Model Validation: Validación de modelos");
            Console.WriteLine("  3. Authorization: Verificación de permisos");
            Console.WriteLine("  4. Action Execution: Ejecución de la lógica de negocio");
            Console.WriteLine("  5. Result Creation: Creación del resultado\n");
        }

        /// <summary>
        /// Demuestra Result Execution
        /// </summary>
        public static void DemonstrateResultExecution()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  5. Result Execution 📝");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("El resultado de la acción se procesa—ya sea datos para una");
            Console.WriteLine("respuesta API o un view model para una página web.\n");

            Console.WriteLine("Data Results (API):");
            Console.WriteLine("```csharp");
            Console.WriteLine("return Ok(new { message = \"Success\" });");
            Console.WriteLine("return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);");
            Console.WriteLine("return NoContent();");
            Console.WriteLine("```\n");

            Console.WriteLine("View Results (MVC):");
            Console.WriteLine("```csharp");
            Console.WriteLine("return View(model);");
            Console.WriteLine("return View(\"CustomView\", model);");
            Console.WriteLine("return RedirectToAction(\"Index\");");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra View Rendering
        /// </summary>
        public static void DemonstrateViewRendering()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  6. View Rendering 🌐");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("En el flujo MVC, este paso final convierte tus datos en HTML,");
            Console.WriteLine("entregando la interfaz de usuario que tu audiencia ve.\n");

            Console.WriteLine("Ejemplo:");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Controller");
            Console.WriteLine("public IActionResult Index()");
            Console.WriteLine("{");
            Console.WriteLine("    var model = new HomeViewModel");
            Console.WriteLine("    {");
            Console.WriteLine("        Title = \"Welcome\",");
            Console.WriteLine("        Items = GetItems()");
            Console.WriteLine("    };");
            Console.WriteLine("    return View(model);");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("```razor");
            Console.WriteLine("@* View: Index.cshtml *@");
            Console.WriteLine("@model HomeViewModel");
            Console.WriteLine("");
            Console.WriteLine("<h1>@Model.Title</h1>");
            Console.WriteLine("<ul>");
            Console.WriteLine("    @foreach (var item in Model.Items)");
            Console.WriteLine("    {");
            Console.WriteLine("        <li>@item.Name</li>");
            Console.WriteLine("    }");
            Console.WriteLine("</ul>");
            Console.WriteLine("```\n");

            Console.WriteLine("Proceso:");
            Console.WriteLine("  1. View Location: Localizar la vista apropiada");
            Console.WriteLine("  2. Model Binding: Pasar el modelo a la vista");
            Console.WriteLine("  3. Layout Application: Aplicar el layout");
            Console.WriteLine("  4. Razor Compilation: Compilar Razor a HTML");
            Console.WriteLine("  5. HTML Generation: Generar HTML final\n");
        }

        /// <summary>
        /// Demuestra por qué importa entender el ciclo de vida
        /// </summary>
        public static void DemonstrateWhyItMatters()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔑 Why It Matters");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Debugging Made Easier 🐞:");
            Console.WriteLine("  • Trace Requests: Seguir peticiones a través del pipeline");
            Console.WriteLine("  • Identify Bottlenecks: Identificar cuellos de botella");
            Console.WriteLine("  • Error Location: Localizar dónde ocurren los errores");
            Console.WriteLine("  • Logging Points: Saber dónde agregar logging\n");

            Console.WriteLine("Optimized Performance ⚡:");
            Console.WriteLine("  • Middleware Order: Ordenar middleware eficientemente");
            Console.WriteLine("  • Route Optimization: Optimizar rutas para mejor rendimiento");
            Console.WriteLine("  • Caching Strategy: Implementar estrategias de caché");
            Console.WriteLine("  • Resource Management: Gestionar recursos eficientemente\n");

            Console.WriteLine("Cleaner Code ✍️:");
            Console.WriteLine("  • Separation of Concerns: Separación clara de responsabilidades");
            Console.WriteLine("  • Proper Abstractions: Abstracciones apropiadas");
            Console.WriteLine("  • Testability: Código más testeable");
            Console.WriteLine("  • Maintainability: Código más mantenible\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║         ASP.NET Core MVC Request Life Cycle                  ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateRequestLifecycle();
            Console.WriteLine("\n");
            DemonstrateMiddlewarePipeline();
            Console.WriteLine("\n");
            DemonstrateRouting();
            Console.WriteLine("\n");
            DemonstrateControllerInitialization();
            Console.WriteLine("\n");
            DemonstrateActionExecution();
            Console.WriteLine("\n");
            DemonstrateResultExecution();
            Console.WriteLine("\n");
            DemonstrateViewRendering();
            Console.WriteLine("\n");
            DemonstrateWhyItMatters();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Ciclo de Vida Completo:");
            Console.WriteLine("   1. Middleware Pipeline: Primera parada, filtrado y procesamiento");
            Console.WriteLine("   2. Routing: Dirección al controlador y acción correctos");
            Console.WriteLine("   3. Controller Initialization: Instanciación con dependencias");
            Console.WriteLine("   4. Action Method Execution: Ejecución de lógica de negocio");
            Console.WriteLine("   5. Result Execution: Procesamiento del resultado");
            Console.WriteLine("   6. View Rendering: Conversión de datos a HTML (MVC)");
            Console.WriteLine("   7. Response: Respuesta final al cliente\n");
            
            Console.WriteLine("🔑 Por Qué Importa:");
            Console.WriteLine("   • Debugging Made Easier: Rastrear y solucionar problemas");
            Console.WriteLine("   • Optimized Performance: Afinar middleware y routing");
            Console.WriteLine("   • Cleaner Code: Código más limpio y mantenible\n");
        }
    }
}

