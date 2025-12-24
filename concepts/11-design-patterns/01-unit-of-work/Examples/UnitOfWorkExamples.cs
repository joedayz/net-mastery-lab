namespace NetMasteryLab.Concepts.DesignPatterns.UnitOfWork.Examples
{
    /// <summary>
    /// Ejemplos que demuestran el patrón Unit of Work en .NET Core
    /// </summary>
    public class UnitOfWorkExamples
    {
        /// <summary>
        /// Demuestra la estructura básica del Unit of Work
        /// </summary>
        public static void DemonstrateBasicStructure()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Unit of Work Pattern - Estructura Básica");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Interface IUnitOfWork:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public interface IUnitOfWork : IDisposable");
            Console.WriteLine("{");
            Console.WriteLine("    IOrderRepository Orders { get; }");
            Console.WriteLine("    ICustomerRepository Customers { get; }");
            Console.WriteLine("    Task<int> CommitAsync();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios Clave:");
            Console.WriteLine("  ✅ Transaction Control: Gestiona múltiples cambios como una unidad");
            Console.WriteLine("  ✅ Code Organization: Centraliza gestión de transacciones");
            Console.WriteLine("  ✅ Data Consistency: Operaciones all-or-nothing");
            Console.WriteLine("  ✅ Performance: Reduce round-trips a la base de datos");
            Console.WriteLine("  ✅ Maintainability: Código más limpio y mantenible\n");
        }

        /// <summary>
        /// Demuestra la implementación del Unit of Work
        /// </summary>
        public static void DemonstrateImplementation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🛠️ Implementación del Unit of Work");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Implementación completa:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class UnitOfWork : IUnitOfWork");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly ApplicationDbContext _context;");
            Console.WriteLine("    private IOrderRepository? _orders;");
            Console.WriteLine("    ");
            Console.WriteLine("    public IOrderRepository Orders");
            Console.WriteLine("    {");
            Console.WriteLine("        get");
            Console.WriteLine("        {");
            Console.WriteLine("            _orders ??= new OrderRepository(_context);");
            Console.WriteLine("            return _orders;");
            Console.WriteLine("        }");
            Console.WriteLine("    }");
            Console.WriteLine("    ");
            Console.WriteLine("    public async Task<int> CommitAsync()");
            Console.WriteLine("    {");
            Console.WriteLine("        return await _context.SaveChangesAsync();");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra uso con Dependency Injection
        /// </summary>
        public static void DemonstrateDependencyInjection()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💉 Dependency Injection con Unit of Work");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Registro en Program.cs:");
            Console.WriteLine("```csharp");
            Console.WriteLine("builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();");
            Console.WriteLine("builder.Services.AddDbContext<ApplicationDbContext>(options =>");
            Console.WriteLine("    options.UseSqlServer(connectionString));");
            Console.WriteLine("```\n");

            Console.WriteLine("Uso en Servicio:");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class OrderService");
            Console.WriteLine("{");
            Console.WriteLine("    private readonly IUnitOfWork _unitOfWork;");
            Console.WriteLine("    ");
            Console.WriteLine("    public OrderService(IUnitOfWork unitOfWork)");
            Console.WriteLine("    {");
            Console.WriteLine("        _unitOfWork = unitOfWork;");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra operación transaccional compleja
        /// </summary>
        public static void DemonstrateTransactionalOperation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Operación Transaccional Compleja");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo: Crear orden con múltiples operaciones");
            Console.WriteLine("```csharp");
            Console.WriteLine("public async Task<Order> CreateOrderAsync(int customerId, List<int> productIds)");
            Console.WriteLine("{");
            Console.WriteLine("    // Obtener cliente");
            Console.WriteLine("    var customer = await _unitOfWork.Customers.GetByIdAsync(customerId);");
            Console.WriteLine("    ");
            Console.WriteLine("    // Crear orden");
            Console.WriteLine("    var order = new Order { CustomerId = customerId };");
            Console.WriteLine("    ");
            Console.WriteLine("    // Agregar productos");
            Console.WriteLine("    foreach (var productId in productIds)");
            Console.WriteLine("    {");
            Console.WriteLine("        var product = await _unitOfWork.Products.GetByIdAsync(productId);");
            Console.WriteLine("        order.OrderItems.Add(new OrderItem { ProductId = productId });");
            Console.WriteLine("    }");
            Console.WriteLine("    ");
            Console.WriteLine("    // Agregar orden");
            Console.WriteLine("    _unitOfWork.Orders.Add(order);");
            Console.WriteLine("    ");
            Console.WriteLine("    // Una sola transacción guarda todos los cambios");
            Console.WriteLine("    await _unitOfWork.CommitAsync();");
            Console.WriteLine("    ");
            Console.WriteLine("    return order;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  ✅ Todas las operaciones se ejecutan como una sola transacción");
            Console.WriteLine("  ✅ Si algo falla, todo se revierte automáticamente");
            Console.WriteLine("  ✅ Una sola llamada a SaveChanges() en lugar de múltiples\n");
        }

        /// <summary>
        /// Demuestra cuándo usar Unit of Work
        /// </summary>
        public static void DemonstrateWhenToUse()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Cuándo Usar Unit of Work");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Usa Unit of Work cuando:");
            Console.WriteLine("  • Transacciones de negocio complejas");
            Console.WriteLine("  • Múltiples actualizaciones de tablas");
            Console.WriteLine("  • La consistencia de datos es crucial");
            Console.WriteLine("  • Múltiples operaciones de repositorio");
            Console.WriteLine("  • Necesitas garantizar atomicidad\n");

            Console.WriteLine("Ejemplo: Procesar orden completo");
            Console.WriteLine("  • Actualizar estado de orden");
            Console.WriteLine("  • Actualizar contador de pedidos del cliente");
            Console.WriteLine("  • Reducir stock de productos");
            Console.WriteLine("  • Todo como una sola transacción\n");
        }

        /// <summary>
        /// Demuestra mejores prácticas
        /// </summary>
        public static void DemonstrateBestPractices()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Mejores Prácticas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Siempre usar Dependency Injection:");
            Console.WriteLine("   ✅ builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();\n");

            Console.WriteLine("2. Implementar patrón de disposal correcto:");
            Console.WriteLine("   ✅ Implementar IDisposable apropiadamente\n");

            Console.WriteLine("3. Considerar operaciones async:");
            Console.WriteLine("   ✅ Usar CommitAsync() en lugar de Commit()\n");

            Console.WriteLine("4. Mantener scope enfocado:");
            Console.WriteLine("   ✅ Usar Scoped lifetime (una instancia por request)\n");

            Console.WriteLine("5. Una sola llamada a Commit:");
            Console.WriteLine("   ✅ Agrupar todas las operaciones y llamar CommitAsync() una vez\n");
        }

        /// <summary>
        /// Demuestra errores comunes
        /// </summary>
        public static void DemonstrateCommonMistakes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Errores Comunes a Evitar");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ MAL: Múltiples llamadas a SaveChanges");
            Console.WriteLine("```csharp");
            Console.WriteLine("_unitOfWork.Orders.Add(order);");
            Console.WriteLine("await _unitOfWork.CommitAsync(); // Primera llamada");
            Console.WriteLine("");
            Console.WriteLine("_unitOfWork.Customers.Update(customer);");
            Console.WriteLine("await _unitOfWork.CommitAsync(); // Segunda llamada");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: Una sola llamada al final");
            Console.WriteLine("```csharp");
            Console.WriteLine("_unitOfWork.Orders.Add(order);");
            Console.WriteLine("_unitOfWork.Customers.Update(customer);");
            Console.WriteLine("await _unitOfWork.CommitAsync(); // Una sola transacción");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ MAL: Crear instancia directamente");
            Console.WriteLine("```csharp");
            Console.WriteLine("var unitOfWork = new UnitOfWork(context);");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: Inyectar a través de constructor");
            Console.WriteLine("```csharp");
            Console.WriteLine("public OrderService(IUnitOfWork unitOfWork)");
            Console.WriteLine("{");
            Console.WriteLine("    _unitOfWork = unitOfWork;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          Unit of Work Pattern en .NET Core                    ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateBasicStructure();
            Console.WriteLine("\n");
            DemonstrateImplementation();
            Console.WriteLine("\n");
            DemonstrateDependencyInjection();
            Console.WriteLine("\n");
            DemonstrateTransactionalOperation();
            Console.WriteLine("\n");
            DemonstrateWhenToUse();
            Console.WriteLine("\n");
            DemonstrateBestPractices();
            Console.WriteLine("\n");
            DemonstrateCommonMistakes();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Unit of Work Pattern:");
            Console.WriteLine("   • Gestiona transacciones de base de datos");
            Console.WriteLine("   • Coordina múltiples operaciones como una unidad");
            Console.WriteLine("   • Asegura consistencia de datos\n");
            
            Console.WriteLine("✅ Beneficios:");
            Console.WriteLine("   • Transaction Control: Control de transacciones");
            Console.WriteLine("   • Code Organization: Organización del código");
            Console.WriteLine("   • Data Consistency: Consistencia de datos");
            Console.WriteLine("   • Performance: Mejor rendimiento");
            Console.WriteLine("   • Maintainability: Mejor mantenibilidad\n");
            
            Console.WriteLine("✅ Componentes:");
            Console.WriteLine("   • IUnitOfWork Interface: Define el contrato");
            Console.WriteLine("   • Repositories: Operaciones específicas de entidades");
            Console.WriteLine("   • Database Context: Implementación en EF Core");
            Console.WriteLine("   • Transaction Scope: Límite de operaciones\n");
            
            Console.WriteLine("💡 Key Takeaway:");
            Console.WriteLine("   • Usa Unit of Work para operaciones complejas");
            Console.WriteLine("   • Una sola llamada a CommitAsync() al final");
            Console.WriteLine("   • Siempre usar Dependency Injection");
            Console.WriteLine("   • Implementar IDisposable correctamente\n");
        }
    }
}

