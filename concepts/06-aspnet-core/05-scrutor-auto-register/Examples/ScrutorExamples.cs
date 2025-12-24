using System;
using System.Linq;

namespace NetMasteryLab.Concepts.AspNetCore.ScrutorAutoRegister.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Scrutor en ASP.NET Core para auto-registro de dependencias
    /// </summary>
    public class ScrutorExamples
    {
        /// <summary>
        /// Demuestra la comparación entre registro manual y Scrutor
        /// </summary>
        public static void DemonstrateComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Registro Manual vs Scrutor");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ ANTES: Registro Manual - verboso y propenso a errores");
            Console.WriteLine("```csharp");
            Console.WriteLine("builder.Services.AddScoped<IOrderService, OrderService>();");
            Console.WriteLine("builder.Services.AddScoped<ICustomerService, CustomerService>();");
            Console.WriteLine("builder.Services.AddScoped<IInvoiceService, InvoiceService>();");
            Console.WriteLine("builder.Services.AddScoped<IProductService, ProductService>();");
            Console.WriteLine("builder.Services.AddScoped<IPaymentService, PaymentService>();");
            Console.WriteLine("builder.Services.AddScoped<IShippingService, ShippingService>();");
            Console.WriteLine("builder.Services.AddScoped<IEmailService, EmailService>();");
            Console.WriteLine("builder.Services.AddScoped<INotificationService, NotificationService>();");
            Console.WriteLine("// ... y muchos más");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ DESPUÉS: Auto-registro con Scrutor - limpio y escalable");
            Console.WriteLine("```csharp");
            Console.WriteLine("builder.Services.Scan(scan => scan");
            Console.WriteLine("    .FromAssemblyOf<OrderService>()");
            Console.WriteLine("    .AddClasses()");
            Console.WriteLine("    .AsMatchingInterface()");
            Console.WriteLine("    .WithScopedLifetime());");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas de Scrutor:");
            Console.WriteLine("  ✅ Conciso: Una sola línea registra múltiples servicios");
            Console.WriteLine("  ✅ Automático: Nuevos servicios se registran automáticamente");
            Console.WriteLine("  ✅ Menos Errores: No hay riesgo de olvidar registrar un servicio");
            Console.WriteLine("  ✅ Escalable: Funciona igual con 10 o 100 servicios");
            Console.WriteLine("  ✅ Mantenible: Agregar nuevos servicios no requiere cambios\n");
        }

        /// <summary>
        /// Demuestra cómo funciona Scrutor
        /// </summary>
        public static void DemonstrateHowItWorks()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔧 Cómo Funciona Scrutor");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Escaneo de Assembly");
            Console.WriteLine("   Scrutor escanea un assembly completo en busca de clases\n");

            Console.WriteLine("2. Matching de Interfaces");
            Console.WriteLine("   Scrutor busca interfaces que coincidan con el nombre de la clase:");
            Console.WriteLine("   • OrderService → IOrderService");
            Console.WriteLine("   • CustomerService → ICustomerService");
            Console.WriteLine("   • InvoiceService → IInvoiceService\n");

            Console.WriteLine("3. Registro Automático");
            Console.WriteLine("   Cada clase encontrada se registra automáticamente con su");
            Console.WriteLine("   interfaz correspondiente y el lifetime especificado\n");

            Console.WriteLine("Ejemplo de código:");
            Console.WriteLine("```csharp");
            Console.WriteLine("builder.Services.Scan(scan => scan");
            Console.WriteLine("    .FromAssemblyOf<OrderService>()  // Escanea el assembly");
            Console.WriteLine("    .AddClasses()                    // Agrega todas las clases públicas");
            Console.WriteLine("    .AsMatchingInterface()           // Las registra con su interfaz");
            Console.WriteLine("    .WithScopedLifetime());          // Con lifetime Scoped");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra ejemplos prácticos
        /// </summary>
        public static void DemonstratePracticalExamples()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Ejemplos Prácticos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo 1: Registro Básico");
            Console.WriteLine("```csharp");
            Console.WriteLine("builder.Services.Scan(scan => scan");
            Console.WriteLine("    .FromAssemblyOf<OrderService>()");
            Console.WriteLine("    .AddClasses()");
            Console.WriteLine("    .AsMatchingInterface()");
            Console.WriteLine("    .WithScopedLifetime());");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 2: Múltiples Assemblies");
            Console.WriteLine("```csharp");
            Console.WriteLine("builder.Services.Scan(scan => scan");
            Console.WriteLine("    .FromAssemblyOf<OrderService>()");
            Console.WriteLine("    .FromAssemblyOf<CustomerService>()");
            Console.WriteLine("    .AddClasses()");
            Console.WriteLine("    .AsMatchingInterface()");
            Console.WriteLine("    .WithScopedLifetime());");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 3: Filtrado por Namespace");
            Console.WriteLine("```csharp");
            Console.WriteLine("builder.Services.Scan(scan => scan");
            Console.WriteLine("    .FromAssemblyOf<OrderService>()");
            Console.WriteLine("    .AddClasses(classes => classes.InNamespaces(\"MyApp.Services\"))");
            Console.WriteLine("    .AsMatchingInterface()");
            Console.WriteLine("    .WithScopedLifetime());");
            Console.WriteLine("```\n");

            Console.WriteLine("Ejemplo 4: Diferentes Lifetimes");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Servicios Scoped");
            Console.WriteLine("builder.Services.Scan(scan => scan");
            Console.WriteLine("    .FromAssemblyOf<OrderService>()");
            Console.WriteLine("    .AddClasses(classes => classes.Where(c => c.Name.EndsWith(\"Service\")))");
            Console.WriteLine("    .AsMatchingInterface()");
            Console.WriteLine("    .WithScopedLifetime());");
            Console.WriteLine("");
            Console.WriteLine("// Repositorios Transient");
            Console.WriteLine("builder.Services.Scan(scan => scan");
            Console.WriteLine("    .FromAssemblyOf<OrderRepository>()");
            Console.WriteLine("    .AddClasses(classes => classes.Where(c => c.Name.EndsWith(\"Repository\")))");
            Console.WriteLine("    .AsMatchingInterface()");
            Console.WriteLine("    .WithTransientLifetime());");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra métodos principales de Scrutor
        /// </summary>
        public static void DemonstrateMainMethods()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔍 Métodos Principales de Scrutor");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("FromAssemblyOf<T>()");
            Console.WriteLine("  Especifica el assembly a escanear usando un tipo de referencia");
            Console.WriteLine("  .FromAssemblyOf<OrderService>()\n");

            Console.WriteLine("AddClasses()");
            Console.WriteLine("  Agrega todas las clases públicas del assembly");
            Console.WriteLine("  .AddClasses()\n");

            Console.WriteLine("AddClasses(Action<IImplementationTypeFilter>)");
            Console.WriteLine("  Agrega clases con filtrado personalizado");
            Console.WriteLine("  .AddClasses(classes => classes.Where(c => c.Name.EndsWith(\"Service\")))\n");

            Console.WriteLine("AsMatchingInterface()");
            Console.WriteLine("  Registra cada clase con su interfaz correspondiente (por nombre)");
            Console.WriteLine("  .AsMatchingInterface()");
            Console.WriteLine("  // OrderService → IOrderService\n");

            Console.WriteLine("AsImplementedInterfaces()");
            Console.WriteLine("  Registra cada clase con todas las interfaces que implementa");
            Console.WriteLine("  .AsImplementedInterfaces()\n");

            Console.WriteLine("WithScopedLifetime()");
            Console.WriteLine("  Registra servicios con lifetime Scoped");
            Console.WriteLine("  .WithScopedLifetime()\n");

            Console.WriteLine("WithTransientLifetime()");
            Console.WriteLine("  Registra servicios con lifetime Transient");
            Console.WriteLine("  .WithTransientLifetime()\n");

            Console.WriteLine("WithSingletonLifetime()");
            Console.WriteLine("  Registra servicios con lifetime Singleton");
            Console.WriteLine("  .WithSingletonLifetime()\n");
        }

        /// <summary>
        /// Demuestra mejores prácticas
        /// </summary>
        public static void DemonstrateBestPractices()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Mejores Prácticas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Agrupar por Responsabilidad");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Servicios de dominio");
            Console.WriteLine("builder.Services.Scan(scan => scan");
            Console.WriteLine("    .FromAssemblyOf<OrderService>()");
            Console.WriteLine("    .AddClasses(classes => classes.InNamespaces(\"MyApp.Services\"))");
            Console.WriteLine("    .AsMatchingInterface()");
            Console.WriteLine("    .WithScopedLifetime());");
            Console.WriteLine("");
            Console.WriteLine("// Repositorios");
            Console.WriteLine("builder.Services.Scan(scan => scan");
            Console.WriteLine("    .FromAssemblyOf<OrderRepository>()");
            Console.WriteLine("    .AddClasses(classes => classes.InNamespaces(\"MyApp.Repositories\"))");
            Console.WriteLine("    .AsMatchingInterface()");
            Console.WriteLine("    .WithScopedLifetime());");
            Console.WriteLine("```\n");

            Console.WriteLine("2. Usar Filtros Específicos");
            Console.WriteLine("```csharp");
            Console.WriteLine("builder.Services.Scan(scan => scan");
            Console.WriteLine("    .FromAssemblyOf<OrderService>()");
            Console.WriteLine("    .AddClasses(classes => classes");
            Console.WriteLine("        .Where(c => c.Name.EndsWith(\"Service\") &&");
            Console.WriteLine("                    !c.IsAbstract &&");
            Console.WriteLine("                    c.IsPublic &&");
            Console.WriteLine("                    c.GetInterfaces().Any()))");
            Console.WriteLine("    .AsMatchingInterface()");
            Console.WriteLine("    .WithScopedLifetime());");
            Console.WriteLine("```\n");

            Console.WriteLine("3. Combinar con Registro Manual");
            Console.WriteLine("```csharp");
            Console.WriteLine("// Auto-registro para servicios estándar");
            Console.WriteLine("builder.Services.Scan(scan => scan");
            Console.WriteLine("    .FromAssemblyOf<OrderService>()");
            Console.WriteLine("    .AddClasses()");
            Console.WriteLine("    .AsMatchingInterface()");
            Console.WriteLine("    .WithScopedLifetime());");
            Console.WriteLine("");
            Console.WriteLine("// Registro manual para casos especiales");
            Console.WriteLine("builder.Services.AddSingleton<IConfigurationService>(sp =>");
            Console.WriteLine("    new ConfigurationService(configuration));");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra consideraciones importantes
        /// </summary>
        public static void DemonstrateConsiderations()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Consideraciones Importantes");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Convenciones de Nombres");
            Console.WriteLine("   Scrutor funciona mejor cuando sigues convenciones consistentes:");
            Console.WriteLine("   ✅ BIEN: OrderService → IOrderService");
            Console.WriteLine("   ❌ MAL: OrderServiceImpl → IOrderService (no funcionará)\n");

            Console.WriteLine("2. Múltiples Implementaciones");
            Console.WriteLine("   Si una interfaz tiene múltiples implementaciones,");
            Console.WriteLine("   necesitas especificar cuál usar o filtrar\n");

            Console.WriteLine("3. Rendimiento");
            Console.WriteLine("   El escaneo de assemblies ocurre al inicio de la aplicación,");
            Console.WriteLine("   por lo que el impacto en el rendimiento es mínimo\n");
        }

        /// <summary>
        /// Demuestra cuándo usar Scrutor
        /// </summary>
        public static void DemonstrateWhenToUse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Cuándo Usar Scrutor");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Usa Scrutor cuando:");
            Console.WriteLine("  • Tienes muchos servicios para registrar");
            Console.WriteLine("  • Sigues convenciones de nombres consistentes");
            Console.WriteLine("  • Quieres reducir código boilerplate");
            Console.WriteLine("  • Necesitas mantener el código de registro limpio");
            Console.WriteLine("  • Agregas nuevos servicios frecuentemente\n");

            Console.WriteLine("⚠️ Considera Registro Manual cuando:");
            Console.WriteLine("  • Tienes pocos servicios (menos de 5-10)");
            Console.WriteLine("  • Necesitas configuración específica por servicio");
            Console.WriteLine("  • Los servicios no siguen convenciones consistentes");
            Console.WriteLine("  • Necesitas registrar servicios con diferentes constructores");
            Console.WriteLine("  • Requieres control granular sobre el registro\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Scrutor in ASP.NET Core: Auto-Register Dependencies         ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateComparison();
            Console.WriteLine("\n");
            DemonstrateHowItWorks();
            Console.WriteLine("\n");
            DemonstratePracticalExamples();
            Console.WriteLine("\n");
            DemonstrateMainMethods();
            Console.WriteLine("\n");
            DemonstrateBestPractices();
            Console.WriteLine("\n");
            DemonstrateConsiderations();
            Console.WriteLine("\n");
            DemonstrateWhenToUse();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Scrutor en ASP.NET Core:");
            Console.WriteLine("   • Auto-registro de dependencias basado en convenciones");
            Console.WriteLine("   • Escaneo automático de assemblies");
            Console.WriteLine("   • Matching de interfaces por nombre");
            Console.WriteLine("   • Soporte para múltiples lifetimes");
            Console.WriteLine("   • Filtrado avanzado de clases\n");
            
            Console.WriteLine("🚀 Ventajas:");
            Console.WriteLine("   • Reduce código boilerplate significativamente");
            Console.WriteLine("   • Escalable y mantenible");
            Console.WriteLine("   • Menos propenso a errores");
            Console.WriteLine("   • Automático para nuevos servicios\n");
            
            Console.WriteLine("📦 Instalación:");
            Console.WriteLine("   dotnet add package Scrutor\n");
            
            Console.WriteLine("💡 Uso Básico:");
            Console.WriteLine("   builder.Services.Scan(scan => scan");
            Console.WriteLine("       .FromAssemblyOf<OrderService>()");
            Console.WriteLine("       .AddClasses()");
            Console.WriteLine("       .AsMatchingInterface()");
            Console.WriteLine("       .WithScopedLifetime());\n");
        }
    }
}

