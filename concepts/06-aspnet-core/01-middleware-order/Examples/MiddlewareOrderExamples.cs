namespace NetMasteryLab.Concepts.AspNetCore.MiddlewareOrder.Examples;

/// <summary>
/// Ejemplos que demuestran el orden correcto de middlewares en ASP.NET Core
/// </summary>
public class MiddlewareOrderExamples
{
    /// <summary>
    /// Demuestra el orden correcto de middlewares
    /// </summary>
    public static void DemonstrateCorrectOrder()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ✅ ORDEN CORRECTO DE MIDDLEWARES");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Código del método Configure():");
        Console.WriteLine("```csharp");
        Console.WriteLine("public void Configure(IApplicationBuilder app, IWebHostEnvironment env)");
        Console.WriteLine("{");
        Console.WriteLine("    // 1. Exception Handler");
        Console.WriteLine("    app.UseExceptionHandler(\"/Error\");");
        Console.WriteLine("    ");
        Console.WriteLine("    // 2. HSTS");
        Console.WriteLine("    app.UseHsts();");
        Console.WriteLine("    ");
        Console.WriteLine("    // 3. HTTPS Redirection");
        Console.WriteLine("    app.UseHttpsRedirection();");
        Console.WriteLine("    ");
        Console.WriteLine("    // 4. Static Files");
        Console.WriteLine("    app.UseStaticFiles();");
        Console.WriteLine("    ");
        Console.WriteLine("    // 5. Routing");
        Console.WriteLine("    app.UseRouting();");
        Console.WriteLine("    ");
        Console.WriteLine("    // 6. CORS");
        Console.WriteLine("    app.UseCors();");
        Console.WriteLine("    ");
        Console.WriteLine("    // 7. Authentication");
        Console.WriteLine("    app.UseAuthentication();");
        Console.WriteLine("    ");
        Console.WriteLine("    // 8. Authorization");
        Console.WriteLine("    app.UseAuthorization();");
        Console.WriteLine("    ");
        Console.WriteLine("    // 9. Response Compression");
        Console.WriteLine("    app.UseResponseCompression();");
        Console.WriteLine("    ");
        Console.WriteLine("    // 10. Endpoints");
        Console.WriteLine("    app.UseEndpoints(endpoints =>");
        Console.WriteLine("    {");
        Console.WriteLine("        endpoints.MapControllers();");
        Console.WriteLine("    });");
        Console.WriteLine("}");
        Console.WriteLine("```\n");
    }

    /// <summary>
    /// Demuestra el flujo del pipeline
    /// </summary>
    public static void DemonstratePipelineFlow()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🔄 FLUJO DEL PIPELINE");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Request Flow (Hacia abajo):");
        Console.WriteLine("  Request");
        Console.WriteLine("    ↓");
        Console.WriteLine("  ExceptionHandler");
        Console.WriteLine("    ↓");
        Console.WriteLine("  HSTS");
        Console.WriteLine("    ↓");
        Console.WriteLine("  HttpsRedirection");
        Console.WriteLine("    ↓");
        Console.WriteLine("  StaticFiles");
        Console.WriteLine("    ↓");
        Console.WriteLine("  Routing");
        Console.WriteLine("    ↓");
        Console.WriteLine("  CORS");
        Console.WriteLine("    ↓");
        Console.WriteLine("  Authentication");
        Console.WriteLine("    ↓");
        Console.WriteLine("  Authorization");
        Console.WriteLine("    ↓");
        Console.WriteLine("  ResponseCompression");
        Console.WriteLine("    ↓");
        Console.WriteLine("  Endpoints");
        Console.WriteLine("    ↓");
        Console.WriteLine("  [Tu lógica de aplicación]\n");

        Console.WriteLine("Response Flow (Hacia arriba):");
        Console.WriteLine("  [Tu lógica de aplicación]");
        Console.WriteLine("    ↑");
        Console.WriteLine("  Endpoints");
        Console.WriteLine("    ↑");
        Console.WriteLine("  ResponseCompression");
        Console.WriteLine("    ↑");
        Console.WriteLine("  Authorization");
        Console.WriteLine("    ↑");
        Console.WriteLine("  Authentication");
        Console.WriteLine("    ↑");
        Console.WriteLine("  CORS");
        Console.WriteLine("    ↑");
        Console.WriteLine("  Routing");
        Console.WriteLine("    ↑");
        Console.WriteLine("  StaticFiles");
        Console.WriteLine("    ↑");
        Console.WriteLine("  HttpsRedirection");
        Console.WriteLine("    ↑");
        Console.WriteLine("  HSTS");
        Console.WriteLine("    ↑");
        Console.WriteLine("  ExceptionHandler");
        Console.WriteLine("    ↑");
        Console.WriteLine("  Response\n");
    }

    /// <summary>
    /// Demuestra errores comunes de orden
    /// </summary>
    public static void DemonstrateCommonMistakes()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  ⚠️  ERRORES COMUNES DE ORDEN");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("❌ Error 1: Authorization antes de Authentication");
        Console.WriteLine("```csharp");
        Console.WriteLine("app.UseAuthorization(); // Error: usuario no autenticado");
        Console.WriteLine("app.UseAuthentication();");
        Console.WriteLine("```");
        Console.WriteLine("Problema: El sistema de autorización no puede verificar permisos");
        Console.WriteLine("         porque la identidad del usuario aún no está establecida.\n");

        Console.WriteLine("✅ Solución Correcta:");
        Console.WriteLine("```csharp");
        Console.WriteLine("app.UseAuthentication(); // Primero autentica");
        Console.WriteLine("app.UseAuthorization();  // Luego autoriza");
        Console.WriteLine("```\n");

        Console.WriteLine("❌ Error 2: Routing después de Static Files");
        Console.WriteLine("```csharp");
        Console.WriteLine("app.UseStaticFiles();");
        Console.WriteLine("app.UseRouting(); // Debería estar antes");
        Console.WriteLine("```");
        Console.WriteLine("Problema: Los archivos estáticos pueden no servirse correctamente.\n");

        Console.WriteLine("✅ Solución Correcta:");
        Console.WriteLine("```csharp");
        Console.WriteLine("app.UseRouting();");
        Console.WriteLine("app.UseStaticFiles();");
        Console.WriteLine("```\n");

        Console.WriteLine("❌ Error 3: ExceptionHandler no está primero");
        Console.WriteLine("```csharp");
        Console.WriteLine("app.UseHsts();");
        Console.WriteLine("app.UseExceptionHandler(\"/Error\"); // Debería estar primero");
        Console.WriteLine("```");
        Console.WriteLine("Problema: Las excepciones de middlewares anteriores no se capturan.\n");

        Console.WriteLine("✅ Solución Correcta:");
        Console.WriteLine("```csharp");
        Console.WriteLine("app.UseExceptionHandler(\"/Error\"); // Siempre primero");
        Console.WriteLine("app.UseHsts();");
        Console.WriteLine("```\n");
    }

    /// <summary>
    /// Demuestra dónde colocar middlewares personalizados
    /// </summary>
    public static void DemonstrateCustomMiddlewares()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  🔧 MIDDLEWARES PERSONALIZADOS");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Los middlewares personalizados generalmente se colocan");
        Console.WriteLine("después de UseRouting y antes de UseEndpoints:\n");

        Console.WriteLine("```csharp");
        Console.WriteLine("app.UseRouting();");
        Console.WriteLine("");
        Console.WriteLine("// Custom middlewares aquí");
        Console.WriteLine("app.UseCustomMiddleware1();");
        Console.WriteLine("app.UseCustomMiddleware2();");
        Console.WriteLine("");
        Console.WriteLine("app.UseCors();");
        Console.WriteLine("app.UseAuthentication();");
        Console.WriteLine("app.UseAuthorization();");
        Console.WriteLine("app.UseEndpoints(endpoints => { ... });");
        Console.WriteLine("```\n");

        Console.WriteLine("Regla General:");
        Console.WriteLine("  • Después de UseRouting (para tener información del endpoint)");
        Console.WriteLine("  • Antes de UseEndpoints (para procesar antes de ejecutar)");
        Console.WriteLine("  • Considera el orden según la funcionalidad del middleware\n");
    }

    /// <summary>
    /// Demuestra la importancia del orden con ejemplos prácticos
    /// </summary>
    public static void DemonstrateOrderImportance()
    {
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  💡 IMPORTANCIA DEL ORDEN");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("Ejemplo 1: ExceptionHandler primero");
        Console.WriteLine("  ✅ Si está primero, captura excepciones de TODOS los middlewares");
        Console.WriteLine("  ❌ Si está después, solo captura excepciones de middlewares siguientes\n");

        Console.WriteLine("Ejemplo 2: Authentication antes de Authorization");
        Console.WriteLine("  ✅ Authentication establece la identidad del usuario");
        Console.WriteLine("  ✅ Authorization verifica permisos basados en esa identidad");
        Console.WriteLine("  ❌ Si Authorization está primero, no hay identidad que verificar\n");

        Console.WriteLine("Ejemplo 3: Static Files antes de Routing");
        Console.WriteLine("  ✅ Los archivos estáticos se sirven directamente sin routing");
        Console.WriteLine("  ✅ Mejor rendimiento para archivos estáticos");
        Console.WriteLine("  ❌ Si Routing está primero, puede intentar enrutar archivos estáticos\n");

        Console.WriteLine("Ejemplo 4: CORS después de Routing");
        Console.WriteLine("  ✅ CORS necesita saber qué endpoint se está llamando");
        Console.WriteLine("  ✅ Puede aplicar políticas CORS específicas por endpoint");
        Console.WriteLine("  ❌ Si está antes, no tiene información del endpoint\n");
    }

    /// <summary>
    /// Ejecuta todos los ejemplos
    /// </summary>
    public static void RunAllExamples()
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║     Middleware Order in .NET Pipeline - ASP.NET Core         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

        DemonstrateCorrectOrder();
        Console.WriteLine("\n");
        DemonstratePipelineFlow();
        Console.WriteLine("\n");
        DemonstrateCommonMistakes();
        Console.WriteLine("\n");
        DemonstrateCustomMiddlewares();
        Console.WriteLine("\n");
        DemonstrateOrderImportance();

        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("  RESUMEN");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        Console.WriteLine("✅ Orden Recomendado:");
        Console.WriteLine("   1. UseExceptionHandler");
        Console.WriteLine("   2. UseHsts");
        Console.WriteLine("   3. UseHttpsRedirection");
        Console.WriteLine("   4. UseStaticFiles");
        Console.WriteLine("   5. UseRouting");
        Console.WriteLine("   6. UseCors");
        Console.WriteLine("   7. UseAuthentication");
        Console.WriteLine("   8. UseAuthorization");
        Console.WriteLine("   9. UseResponseCompression");
        Console.WriteLine("   10. UseEndpoints\n");
        
        Console.WriteLine("💡 Regla de Oro:");
        Console.WriteLine("   • El orden de los middlewares ES crítico");
        Console.WriteLine("   • Authentication SIEMPRE antes de Authorization");
        Console.WriteLine("   • ExceptionHandler SIEMPRE primero");
        Console.WriteLine("   • Endpoints SIEMPRE al final\n");
    }
}

