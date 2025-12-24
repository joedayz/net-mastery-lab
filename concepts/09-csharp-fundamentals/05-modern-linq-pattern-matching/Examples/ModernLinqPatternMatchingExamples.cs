using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace NetMasteryLab.Concepts.CSharpFundamentals.ModernLinqPatternMatching.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Modern LINQ con Pattern Matching en C#
    /// </summary>
    public class ModernLinqPatternMatchingExamples
    {
        /// <summary>
        /// Demuestra filtrado simplificado con pattern matching
        /// </summary>
        public static void DemonstrateSimplifiedFiltering()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Simplified Data Filtering with Pattern Matching");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", IsActive = true, Stock = 10, Category = "Electronics" },
                new Product { Id = 2, Name = "Mouse", IsActive = true, Stock = 0, Category = "Electronics" },
                new Product { Id = 3, Name = "Keyboard", IsActive = false, Stock = 5, Category = "Electronics" },
                new Product { Id = 4, Name = "Monitor", IsActive = true, Stock = 15, Category = "Electronics" }
            };

            Console.WriteLine("❌ TRADICIONAL: Múltiples verificaciones verbosas");
            Console.WriteLine("```csharp");
            Console.WriteLine("var activeProducts = products.Where(p =>");
            Console.WriteLine("{");
            Console.WriteLine("    if (p.IsActive && p.Stock > 0)");
            Console.WriteLine("        return true;");
            Console.WriteLine("    return false;");
            Console.WriteLine("});");
            Console.WriteLine("```\n");

            var traditionalActive = products.Where(p =>
            {
                if (p.IsActive && p.Stock > 0)
                    return true;
                return false;
            }).ToList();

            Console.WriteLine($"Resultado tradicional: {traditionalActive.Count} productos\n");

            Console.WriteLine("✅ MODERNO: Pattern matching limpio y directo");
            Console.WriteLine("```csharp");
            Console.WriteLine("var activeProducts = products.Where(p => p is { IsActive: true, Stock: > 0 });");
            Console.WriteLine("```\n");

            var modernActive = products.Where(p => p is { IsActive: true, Stock: > 0 }).ToList();

            Console.WriteLine($"Resultado moderno: {modernActive.Count} productos");
            Console.WriteLine($"Productos activos: {string.Join(", ", modernActive.Select(p => p.Name))}\n");
        }

        /// <summary>
        /// Demuestra legibilidad mejorada con pattern matching
        /// </summary>
        public static void DemonstrateImprovedReadability()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📖 Improved Readability");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var orders = new List<Order>
            {
                new Order 
                { 
                    Id = 1, 
                    Total = 100, 
                    Customer = new Customer { IsActive = true, CreditLimit = 5000 },
                    Items = new List<OrderItem> { new OrderItem(), new OrderItem() }
                },
                new Order 
                { 
                    Id = 2, 
                    Total = 200, 
                    Customer = new Customer { IsActive = false, CreditLimit = 3000 },
                    Items = new List<OrderItem>()
                },
                new Order 
                { 
                    Id = 3, 
                    Total = 150, 
                    Customer = new Customer { IsActive = true, CreditLimit = 2000 },
                    Items = new List<OrderItem> { new OrderItem() }
                }
            };

            Console.WriteLine("❌ TRADICIONAL: Condiciones anidadas complejas");
            Console.WriteLine("```csharp");
            Console.WriteLine("var validOrders = orders.Where(o =>");
            Console.WriteLine("{");
            Console.WriteLine("    if (o.Customer != null)");
            Console.WriteLine("    {");
            Console.WriteLine("        if (o.Customer.IsActive)");
            Console.WriteLine("        {");
            Console.WriteLine("            if (o.Total > 0 && o.Items.Count > 0)");
            Console.WriteLine("                return true;");
            Console.WriteLine("        }");
            Console.WriteLine("    }");
            Console.WriteLine("    return false;");
            Console.WriteLine("});");
            Console.WriteLine("```\n");

            var traditionalValid = orders.Where(o =>
            {
                if (o.Customer != null)
                {
                    if (o.Customer.IsActive)
                    {
                        if (o.Total > 0 && o.Items.Count > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }).ToList();

            Console.WriteLine($"Resultado tradicional: {traditionalValid.Count} órdenes válidas\n");

            Console.WriteLine("✅ MODERNO: Pattern matching expresivo");
            Console.WriteLine("```csharp");
            Console.WriteLine("var validOrders = orders.Where(o =>");
            Console.WriteLine("    o is {");
            Console.WriteLine("        Customer: { IsActive: true },");
            Console.WriteLine("        Total: > 0,");
            Console.WriteLine("        Items.Count: > 0");
            Console.WriteLine("    });");
            Console.WriteLine("```\n");

            var modernValid = orders.Where(o =>
                o is {
                    Customer: { IsActive: true },
                    Total: > 0,
                    Items.Count: > 0
                }).ToList();

            Console.WriteLine($"Resultado moderno: {modernValid.Count} órdenes válidas");
            Console.WriteLine($"IDs de órdenes válidas: {string.Join(", ", modernValid.Select(o => o.Id))}\n");
        }

        /// <summary>
        /// Demuestra extension methods con pattern matching
        /// </summary>
        public static void DemonstrateExtensionMethods()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🛠️ Extension Methods con Pattern Matching");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", IsActive = true, Stock = 10, Category = "Electronics", LastUpdated = DateTime.Now.AddDays(-1) },
                new Product { Id = 2, Name = "Mouse", IsActive = true, Stock = 5, Category = "Electronics", LastUpdated = DateTime.Now.AddDays(-2) },
                new Product { Id = 3, Name = "Book", IsActive = true, Stock = 20, Category = "Books", LastUpdated = DateTime.Now }
            };

            Console.WriteLine("Ejemplo: Extension method con pattern matching");
            Console.WriteLine("```csharp");
            Console.WriteLine("public static IEnumerable<Product> GetActiveProducts(");
            Console.WriteLine("    this IEnumerable<Product> products)");
            Console.WriteLine("{");
            Console.WriteLine("    return products.Where(p => p is { IsActive: true, Stock: > 0 });");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            var activeProducts = products.GetActiveProducts();
            Console.WriteLine($"Productos activos: {string.Join(", ", activeProducts.Select(p => p.Name))}\n");
        }

        /// <summary>
        /// Demuestra pattern matching con switch expressions
        /// </summary>
        public static void DemonstrateSwitchExpressions()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔀 Pattern Matching con Switch Expressions");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", IsActive = true, Stock = 10 },
                new Product { Id = 2, Name = "Mouse", IsActive = true, Stock = 0 },
                new Product { Id = 3, Name = "Keyboard", IsActive = false, Stock = 5 }
            };

            Console.WriteLine("Ejemplo: Switch expression con pattern matching");
            Console.WriteLine("```csharp");
            Console.WriteLine("var productsWithStatus = products.Select(p => new");
            Console.WriteLine("{");
            Console.WriteLine("    Product = p,");
            Console.WriteLine("    Status = p switch");
            Console.WriteLine("    {");
            Console.WriteLine("        { IsActive: true, Stock: > 0 } => \"Available\",");
            Console.WriteLine("        { IsActive: true, Stock: 0 } => \"Out of Stock\",");
            Console.WriteLine("        { IsActive: false } => \"Inactive\",");
            Console.WriteLine("        _ => \"Unknown\"");
            Console.WriteLine("    }");
            Console.WriteLine("});");
            Console.WriteLine("```\n");

            var productsWithStatus = products.Select(p => new
            {
                Product = p.Name,
                Status = p switch
                {
                    { IsActive: true, Stock: > 0 } => "Available",
                    { IsActive: true, Stock: 0 } => "Out of Stock",
                    { IsActive: false } => "Inactive",
                    _ => "Unknown"
                }
            });

            foreach (var item in productsWithStatus)
            {
                Console.WriteLine($"  {item.Product}: {item.Status}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra mejor mantenibilidad del código
        /// </summary>
        public static void DemonstrateBetterMaintainability()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔧 Better Code Maintainability");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ventajas del Pattern Matching:");
            Console.WriteLine("  ✅ Elimina múltiples condiciones if-else");
            Console.WriteLine("  ✅ Reduce líneas de código");
            Console.WriteLine("  ✅ Menos fuentes potenciales de error");
            Console.WriteLine("  ✅ Más fácil de depurar y mantener");
            Console.WriteLine("  ✅ Código más expresivo y autodocumentado\n");

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", IsActive = true, Stock = 10, Price = 999.99m },
                new Product { Id = 2, Name = "Mouse", IsActive = true, Stock = 5, Price = 29.99m },
                new Product { Id = 3, Name = "Keyboard", IsActive = false, Stock = 0, Price = 79.99m }
            };

            Console.WriteLine("Ejemplo: Filtrado complejo simplificado");
            var premiumActiveProducts = products.Where(p => 
                p is { 
                    IsActive: true, 
                    Stock: > 0, 
                    Price: > 50 
                }).ToList();

            Console.WriteLine($"Productos premium activos: {string.Join(", ", premiumActiveProducts.Select(p => p.Name))}\n");
        }

        /// <summary>
        /// Demuestra combinación de LINQ y async (simulado)
        /// </summary>
        public static void DemonstrateLinqAndAsync()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚡ Combining LINQ and Async for Performance");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo: LINQ con async para consultas no bloqueantes");
            Console.WriteLine("```csharp");
            Console.WriteLine("public static async Task<List<Product>> GetProductsByCategoryAsync(");
            Console.WriteLine("    this IQueryable<Product> products,");
            Console.WriteLine("    string category)");
            Console.WriteLine("{");
            Console.WriteLine("    return await products");
            Console.WriteLine("        .Where(p => p.Category == category)");
            Console.WriteLine("        .OrderByDescending(p => p.LastUpdated)");
            Console.WriteLine("        .ToListAsync();");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  ✅ Consultas no bloqueantes");
            Console.WriteLine("  ✅ Mejor performance en aplicaciones");
            Console.WriteLine("  ✅ UI responsiva");
            Console.WriteLine("  ✅ Ideal para consultas de base de datos\n");

            Console.WriteLine("Nota: Este ejemplo muestra la estructura.");
            Console.WriteLine("En producción, usarías Entity Framework con ToListAsync()\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║        Modern LINQ with Pattern Matching en C#                 ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateSimplifiedFiltering();
            Console.WriteLine("\n");
            DemonstrateImprovedReadability();
            Console.WriteLine("\n");
            DemonstrateExtensionMethods();
            Console.WriteLine("\n");
            DemonstrateSwitchExpressions();
            Console.WriteLine("\n");
            DemonstrateBetterMaintainability();
            Console.WriteLine("\n");
            DemonstrateLinqAndAsync();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Simplified Data Filtering:");
            Console.WriteLine("   • Pattern matching permite condiciones directas sobre propiedades");
            Console.WriteLine("   • Elimina verificaciones verbosas y múltiples if statements\n");
            
            Console.WriteLine("✅ Improved Readability:");
            Console.WriteLine("   • Reduce complejidad del código");
            Console.WriteLine("   • Expresa condiciones directamente en LINQ queries\n");
            
            Console.WriteLine("✅ Combining LINQ and Async:");
            Console.WriteLine("   • Consultas no bloqueantes con ToListAsync()");
            Console.WriteLine("   • Mejor performance y UI responsiva\n");
            
            Console.WriteLine("✅ Better Code Maintainability:");
            Console.WriteLine("   • Elimina múltiples condiciones if-else");
            Console.WriteLine("   • Menos código = menos errores potenciales");
            Console.WriteLine("   • Más fácil de depurar y mantener\n");
        }
    }

    // Extension methods para demostración
    public static class ProductExtensions
    {
        // Modern LINQ with pattern matching
        public static IEnumerable<Product> GetActiveProducts(
            this IEnumerable<Product> products)
        {
            return products.Where(p => p is { IsActive: true, Stock: > 0 });
        }

        public static IEnumerable<Product> GetProductsByCategory(
            this IEnumerable<Product> products,
            string category)
        {
            return products
                .Where(p => p.Category == category)
                .OrderByDescending(p => p.LastUpdated);
        }
    }

    // Clases de ejemplo
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }

    public class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public Customer? Customer { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }

    public class Customer
    {
        public bool IsActive { get; set; }
        public decimal CreditLimit { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}

