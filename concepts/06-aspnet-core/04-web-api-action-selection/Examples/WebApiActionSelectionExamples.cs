using System;

namespace NetMasteryLab.Concepts.AspNetCore.WebApiActionSelection.Examples
{
    /// <summary>
    /// Ejemplos que demuestran el proceso de selección de acciones en Web API
    /// </summary>
    public class WebApiActionSelectionExamples
    {
        /// <summary>
        /// Demuestra el proceso de selección paso a paso
        /// </summary>
        public static void DemonstrateSelectionProcess()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔍 Proceso de Selección de Acciones en Web API");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Flujo del Proceso:");
            Console.WriteLine("  Start");
            Console.WriteLine("    ↓");
            Console.WriteLine("  1. ¿\"action\" en route data?");
            Console.WriteLine("    ├─ Sí → a) Seleccionar acciones basadas en nombre");
            Console.WriteLine("    │         ↓");
            Console.WriteLine("    │         b) ¿Satisface verbo HTTP?");
            Console.WriteLine("    │         ├─ Sí → Continuar");
            Console.WriteLine("    │         └─ No → 404");
            Console.WriteLine("    │");
            Console.WriteLine("    └─ No → 2. Seleccionar acciones basadas en método HTTP");
            Console.WriteLine("              ↓");
            Console.WriteLine("  3. ¿Satisface parámetros?");
            Console.WriteLine("    ├─ Sí → Continuar");
            Console.WriteLine("    └─ No → 404");
            Console.WriteLine("              ↓");
            Console.WriteLine("  4. ¿Atributo [NonAction]?");
            Console.WriteLine("    ├─ Sí → 404");
            Console.WriteLine("    └─ No → ✅ Acción Encontrada\n");
        }

        /// <summary>
        /// Demuestra paso 1: Route Matching
        /// </summary>
        public static void DemonstrateRouteMatching()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  Paso 1️⃣: Route Matching (Coincidencia de Rutas)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Ruta con acción explícita");
            Console.WriteLine("```csharp");
            Console.WriteLine("[Route(\"api/[controller]\")]");
            Console.WriteLine("public class UsersController : ControllerBase");
            Console.WriteLine("{");
            Console.WriteLine("    [HttpGet(\"{id}\")]  // Ruta: /api/users/1");
            Console.WriteLine("    public IActionResult GetUser(int id) { }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Comportamiento:");
            Console.WriteLine("  • Si se proporciona una acción en la ruta, filtra métodos que coincidan");
            Console.WriteLine("  • Si no, pasa al siguiente paso\n");
        }

        /// <summary>
        /// Demuestra paso 2: HTTP Method Filtering
        /// </summary>
        public static void DemonstrateHttpMethodFiltering()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  Paso 2️⃣: HTTP Method Filtering (Filtrado por Método HTTP)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Método HTTP correcto");
            Console.WriteLine("```csharp");
            Console.WriteLine("[HttpGet(\"{id}\")]");
            Console.WriteLine("public IActionResult GetUser(int id) { }");
            Console.WriteLine("// Solicitud: GET /api/users/1 ✅");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ MAL: Método HTTP incorrecto");
            Console.WriteLine("```csharp");
            Console.WriteLine("[HttpPost(\"{id}\")]");
            Console.WriteLine("public IActionResult GetUser(int id) { }");
            Console.WriteLine("// Solicitud: GET /api/users/1 ❌ No coincide con POST");
            Console.WriteLine("```\n");

            Console.WriteLine("Comportamiento:");
            Console.WriteLine("  • Selecciona acciones que coincidan con el método HTTP");
            Console.WriteLine("  • Si ninguna acción coincide, ocurre un error 404\n");
        }

        /// <summary>
        /// Demuestra paso 3: Parameter Validation
        /// </summary>
        public static void DemonstrateParameterValidation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  Paso 3️⃣: Parameter Validation (Validación de Parámetros)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Parámetros coinciden");
            Console.WriteLine("```csharp");
            Console.WriteLine("[HttpGet(\"{id}\")]");
            Console.WriteLine("public IActionResult GetUser(int id) { }");
            Console.WriteLine("// Solicitud: GET /api/users/1 ✅");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ MAL: Parámetros no coinciden");
            Console.WriteLine("```csharp");
            Console.WriteLine("[HttpGet(\"{id}\")]");
            Console.WriteLine("public IActionResult GetUser(int id, string name) { }");
            Console.WriteLine("// Solicitud: GET /api/users/1 ❌ Falta parámetro 'name'");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: Parámetros opcionales");
            Console.WriteLine("```csharp");
            Console.WriteLine("[HttpGet(\"{id}\")]");
            Console.WriteLine("public IActionResult GetUser(int id, string? name = null) { }");
            Console.WriteLine("// Solicitud: GET /api/users/1 ✅ name es opcional");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra paso 4: HTTP Verb Validation
        /// </summary>
        public static void DemonstrateHttpVerbValidation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  Paso 4️⃣: HTTP Verb Validation (Validación de Verbo HTTP)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Verbo HTTP correcto");
            Console.WriteLine("```csharp");
            Console.WriteLine("[HttpGet]");
            Console.WriteLine("public IActionResult GetAllUsers() { }");
            Console.WriteLine("// Solicitud: GET /api/users ✅");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ MAL: Verbo HTTP incorrecto");
            Console.WriteLine("```csharp");
            Console.WriteLine("[HttpGet]");
            Console.WriteLine("public IActionResult GetAllUsers() { }");
            Console.WriteLine("// Solicitud: POST /api/users ❌ No coincide con GET");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra paso 5: NonAction Attribute Check
        /// </summary>
        public static void DemonstrateNonActionCheck()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  Paso 5️⃣: [NonAction] Attribute Check");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Método público sin [NonAction]");
            Console.WriteLine("```csharp");
            Console.WriteLine("[HttpGet(\"{id}\")]");
            Console.WriteLine("public IActionResult GetUser(int id) { }");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ MAL: Método marcado con [NonAction]");
            Console.WriteLine("```csharp");
            Console.WriteLine("[HttpGet(\"{id}\")]");
            Console.WriteLine("[NonAction]  // Error: Método excluido de selección");
            Console.WriteLine("public IActionResult GetUser(int id) { }");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: Método privado (automáticamente excluido)");
            Console.WriteLine("```csharp");
            Console.WriteLine("private IActionResult HelperMethod() { }");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra problemas comunes que causan 404
        /// </summary>
        public static void DemonstrateCommon404Issues()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Problemas Comunes que Causan 404");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ Problema 1: Ruta Incorrecta");
            Console.WriteLine("  Controlador: [HttpGet(\"{id}\")]");
            Console.WriteLine("  ❌ Solicitud incorrecta: GET /api/users?id=1");
            Console.WriteLine("  ✅ Solicitud correcta: GET /api/users/1\n");

            Console.WriteLine("❌ Problema 2: Método HTTP Incorrecto");
            Console.WriteLine("  Controlador: [HttpPost]");
            Console.WriteLine("  ❌ Solicitud incorrecta: GET /api/users");
            Console.WriteLine("  ✅ Solicitud correcta: POST /api/users\n");

            Console.WriteLine("❌ Problema 3: Parámetro No Pasado Correctamente");
            Console.WriteLine("  Controlador: [HttpGet(\"{id}\")]");
            Console.WriteLine("  ❌ Solicitud incorrecta: GET /api/users");
            Console.WriteLine("  ✅ Solicitud correcta: GET /api/users/1\n");

            Console.WriteLine("❌ Problema 4: [NonAction] en Método de API");
            Console.WriteLine("  Controlador: [HttpGet(\"{id}\")] [NonAction]");
            Console.WriteLine("  ❌ Cualquier solicitud → 404");
            Console.WriteLine("  ✅ Solución: Remover [NonAction]\n");
        }

        /// <summary>
        /// Demuestra mejores prácticas
        /// </summary>
        public static void DemonstrateBestPractices()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Mejores Prácticas para Evitar 404");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ 1. Usar Attribute Routing");
            Console.WriteLine("  • Define rutas explícitamente usando [HttpGet], [HttpPost], etc.");
            Console.WriteLine("  • Más claro y mantenible\n");

            Console.WriteLine("✅ 2. Hacer Coincidir Métodos HTTP Correctamente");
            Console.WriteLine("  • Asegúrate de que el método de solicitud coincida");
            Console.WriteLine("  • GET para lectura, POST para creación, etc.\n");

            Console.WriteLine("✅ 3. Asegurar Binding Correcto de Parámetros");
            Console.WriteLine("  • [FromRoute] para parámetros en la URL");
            Console.WriteLine("  • [FromQuery] para query parameters");
            Console.WriteLine("  • [FromBody] para datos en el body\n");

            Console.WriteLine("✅ 4. Evitar Errores con [NonAction]");
            Console.WriteLine("  • Marca solo métodos no-API con este atributo");
            Console.WriteLine("  • Métodos privados se excluyen automáticamente\n");

            Console.WriteLine("✅ 5. Depurar con Logging");
            Console.WriteLine("  • Usa ILogger para registrar detalles de solicitud");
            Console.WriteLine("  • Facilita identificar problemas de enrutamiento\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Web API Action Selection en ASP.NET Core                 ║");
            Console.WriteLine("║              Evitando la Trampa del 404                     ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateSelectionProcess();
            Console.WriteLine("\n");
            DemonstrateRouteMatching();
            Console.WriteLine("\n");
            DemonstrateHttpMethodFiltering();
            Console.WriteLine("\n");
            DemonstrateParameterValidation();
            Console.WriteLine("\n");
            DemonstrateHttpVerbValidation();
            Console.WriteLine("\n");
            DemonstrateNonActionCheck();
            Console.WriteLine("\n");
            DemonstrateCommon404Issues();
            Console.WriteLine("\n");
            DemonstrateBestPractices();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Proceso de Selección de Acciones:");
            Console.WriteLine("   1. Route Matching - Verificar acción en route data");
            Console.WriteLine("   2. HTTP Method Filtering - Filtrar por método HTTP");
            Console.WriteLine("   3. Parameter Validation - Validar parámetros");
            Console.WriteLine("   4. HTTP Verb Validation - Validar verbo HTTP");
            Console.WriteLine("   5. [NonAction] Check - Excluir métodos marcados");
            Console.WriteLine("   6. ✅ Acción Encontrada - Ejecutar acción\n");
            
            Console.WriteLine("✅ Problemas Comunes que Causan 404:");
            Console.WriteLine("   • Ruta incorrecta (/users?id=1 vs /users/1)");
            Console.WriteLine("   • Método HTTP incorrecto (GET vs POST)");
            Console.WriteLine("   • Parámetros faltantes o incorrectos");
            Console.WriteLine("   • [NonAction] en método de API\n");
            
            Console.WriteLine("✅ Mejores Prácticas:");
            Console.WriteLine("   • Usar Attribute Routing explícito");
            Console.WriteLine("   • Hacer coincidir métodos HTTP correctamente");
            Console.WriteLine("   • Asegurar binding correcto de parámetros");
            Console.WriteLine("   • Evitar [NonAction] en métodos de API");
            Console.WriteLine("   • Depurar con logging\n");
        }
    }
}

