using System;

namespace NetMasteryLab.Concepts.CSharpFundamentals.SwitchExpressions.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Switch Expressions en C# 8
    /// </summary>
    public class SwitchExpressionsExamples
    {
        /// <summary>
        /// Demuestra la comparación entre Switch Statement y Switch Expression
        /// </summary>
        public static void DemonstrateComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Switch Statement vs Switch Expression");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ ANTES: Switch Statement tradicional (verboso)");
            Console.WriteLine("```csharp");
            Console.WriteLine("string GetSubscriptionFeatures(string plan)");
            Console.WriteLine("{");
            Console.WriteLine("    switch (plan)");
            Console.WriteLine("    {");
            Console.WriteLine("        case \"Free\":");
            Console.WriteLine("            return \"Basic Access\";");
            Console.WriteLine("        case \"Pro\":");
            Console.WriteLine("            return \"Premium Access\";");
            Console.WriteLine("        case \"Enterprise\":");
            Console.WriteLine("            return \"All Features + Priority Support\";");
            Console.WriteLine("        default:");
            Console.WriteLine("            return \"Unknown Plan\";");
            Console.WriteLine("    }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ DESPUÉS: Switch Expression (limpio y conciso)");
            Console.WriteLine("```csharp");
            Console.WriteLine("string GetSubscriptionFeatures(string plan) => plan switch");
            Console.WriteLine("{");
            Console.WriteLine("    \"Free\" => \"Basic Access\",");
            Console.WriteLine("    \"Pro\" => \"Premium Access\",");
            Console.WriteLine("    \"Enterprise\" => \"All Features + Priority Support\",");
            Console.WriteLine("    _ => \"Unknown Plan\"");
            Console.WriteLine("};");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            Console.WriteLine("Ejemplo práctico:");
            Console.WriteLine($"  GetSubscriptionFeatures(\"Free\") = \"{GetSubscriptionFeatures("Free")}\"");
            Console.WriteLine($"  GetSubscriptionFeatures(\"Pro\") = \"{GetSubscriptionFeatures("Pro")}\"");
            Console.WriteLine($"  GetSubscriptionFeatures(\"Enterprise\") = \"{GetSubscriptionFeatures("Enterprise")}\"\n");
        }

        /// <summary>
        /// Demuestra casos de uso perfectos
        /// </summary>
        public static void DemonstratePerfectUseCases()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ Perfect Use Cases");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Subscription Plans 🔁");
            Console.WriteLine($"   GetPlanFeatures(\"Pro\") = \"{GetPlanFeatures("Pro")}\"\n");

            Console.WriteLine("2. Status Codes 🔁");
            Console.WriteLine($"   GetStatusMessage(404) = \"{GetStatusMessage(404)}\"\n");

            Console.WriteLine("3. User Roles 🔁");
            Console.WriteLine($"   GetRolePermissions(\"Editor\") = \"{GetRolePermissions("Editor")}\"\n");

            Console.WriteLine("4. Enum Mapping 🔁");
            Console.WriteLine($"   GetStatusDescription(OrderStatus.Shipped) = \"{GetStatusDescription(OrderStatus.Shipped)}\"\n");

            Console.WriteLine("5. API Responses 🔁");
            Console.WriteLine($"   FormatApiResponse(\"/users\", true) = \"{FormatApiResponse("/users", true)}\"\n");
        }

        /// <summary>
        /// Demuestra combinación con Pattern Matching
        /// </summary>
        public static void DemonstrateWithPatternMatching()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🧠 Switch Expression con Pattern Matching");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Con Property Patterns");
            Console.WriteLine("```csharp");
            Console.WriteLine("string GetPersonCategory(Person person) => person switch");
            Console.WriteLine("{");
            Console.WriteLine("    { Age: >= 18, IsActive: true } => \"Active Adult\",");
            Console.WriteLine("    { Age: >= 18, IsActive: false } => \"Inactive Adult\",");
            Console.WriteLine("    { Age: < 18, IsActive: true } => \"Active Minor\",");
            Console.WriteLine("    null => \"Unknown Person\",");
            Console.WriteLine("    _ => \"Invalid\"");
            Console.WriteLine("};");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: Con Relational Patterns");
            Console.WriteLine("```csharp");
            Console.WriteLine("string GetGrade(int score) => score switch");
            Console.WriteLine("{");
            Console.WriteLine("    >= 90 => \"A\",");
            Console.WriteLine("    >= 80 => \"B\",");
            Console.WriteLine("    >= 70 => \"C\",");
            Console.WriteLine("    >= 60 => \"D\",");
            Console.WriteLine("    _ => \"F\"");
            Console.WriteLine("};");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            Console.WriteLine("Ejemplo práctico:");
            Console.WriteLine($"  GetGrade(85) = \"{GetGrade(85)}\"");
            Console.WriteLine($"  GetGrade(75) = \"{GetGrade(75)}\"");
            Console.WriteLine($"  GetGrade(55) = \"{GetGrade(55)}\"\n");
        }

        /// <summary>
        /// Demuestra casos de uso avanzados
        /// </summary>
        public static void DemonstrateAdvancedUseCases()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🎯 Casos de Uso Avanzados");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Múltiples Valores (Tuples)");
            Console.WriteLine($"   GetAccessLevel(\"Editor\", true) = \"{GetAccessLevel("Editor", true)}\"\n");

            Console.WriteLine("2. Con When Clauses");
            Console.WriteLine($"   GetDiscount(100, 500m) = \"{GetDiscount(100, 500m)}\"\n");

            Console.WriteLine("3. Con Records y Positional Patterns");
            var point = new Point(10, 20);
            Console.WriteLine($"   GetQuadrant(new Point(10, 20)) = \"{GetQuadrant(point)}\"\n");
        }

        /// <summary>
        /// Demuestra expression-bodied members
        /// </summary>
        public static void DemonstrateExpressionBodiedMembers()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Expression-Bodied Members");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Expression-bodied method con switch expression");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class SubscriptionService");
            Console.WriteLine("{");
            Console.WriteLine("    public string GetFeatures(string plan) => plan switch");
            Console.WriteLine("    {");
            Console.WriteLine("        \"Free\" => \"Basic Access\",");
            Console.WriteLine("        \"Pro\" => \"Premium Access\",");
            Console.WriteLine("        \"Enterprise\" => \"All Features\",");
            Console.WriteLine("        _ => \"Unknown\"");
            Console.WriteLine("    };");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            var service = new SubscriptionService();
            Console.WriteLine("Ejemplo práctico:");
            Console.WriteLine($"  service.GetFeatures(\"Pro\") = \"{service.GetFeatures("Pro")}\"");
            Console.WriteLine($"  service.GetPrice(\"Enterprise\") = ${service.GetPrice("Enterprise")}\n");
        }

        /// <summary>
        /// Demuestra mejores prácticas
        /// </summary>
        public static void DemonstrateBestPractices()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Mejores Prácticas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Usa Switch Expressions para:");
            Console.WriteLine("  • Mapeo simple de valores");
            Console.WriteLine("  • Lógica que retorna un valor");
            Console.WriteLine("  • Código más conciso y legible");
            Console.WriteLine("  • Enums, strings, o tipos simples\n");

            Console.WriteLine("❌ Evita Switch Expressions para:");
            Console.WriteLine("  • Side effects (logging, mutación de estado)");
            Console.WriteLine("  • Lógica compleja con múltiples statements");
            Console.WriteLine("  • Múltiples operaciones por caso\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Switch Expression in C# 8: Clean, Fast, Elegant            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateComparison();
            Console.WriteLine("\n");
            DemonstratePerfectUseCases();
            Console.WriteLine("\n");
            DemonstrateWithPatternMatching();
            Console.WriteLine("\n");
            DemonstrateAdvancedUseCases();
            Console.WriteLine("\n");
            DemonstrateExpressionBodiedMembers();
            Console.WriteLine("\n");
            DemonstrateBestPractices();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Switch Expressions en C# 8:");
            Console.WriteLine("   • Sintaxis más concisa que switch statements");
            Console.WriteLine("   • Compatible con expression-bodied members");
            Console.WriteLine("   • Se combina perfectamente con Pattern Matching");
            Console.WriteLine("   • Elimina boilerplate (break, case)");
            Console.WriteLine("   • Usa discard pattern (_) para default\n");
            
            Console.WriteLine("🚀 Perfect Use Cases:");
            Console.WriteLine("   • 🔁 Subscription Plans");
            Console.WriteLine("   • 🔁 Status Codes");
            Console.WriteLine("   • 🔁 User Roles");
            Console.WriteLine("   • 🔁 Enum Mapping");
            Console.WriteLine("   • 🔁 API Responses\n");
            
            Console.WriteLine("🧠 Developer Tip:");
            Console.WriteLine("   • Combina Switch Expressions con Pattern Matching");
            Console.WriteLine("   • Usa Expression-bodied members para código ultra-conciso\n");
            
            Console.WriteLine("💡 Small syntax change, big impact on your code quality.");
            Console.WriteLine("   Write less. Do more. Stay modern. ✨\n");
        }

        // Métodos de ejemplo

        // Ejemplo de comparación
        private static string GetSubscriptionFeatures(string plan) => plan switch
        {
            "Free" => "Basic Access",
            "Pro" => "Premium Access",
            "Enterprise" => "All Features + Priority Support",
            _ => "Unknown Plan"
        };

        // Perfect Use Cases
        private static string GetPlanFeatures(string planCode) => planCode switch
        {
            "Free" => "Basic Access",
            "Pro" => "Premium Access + Analytics",
            "Enterprise" => "All Features + Priority Support + Custom Integration",
            _ => "Unknown Plan"
        };

        private static string GetStatusMessage(int statusCode) => statusCode switch
        {
            200 => "OK",
            201 => "Created",
            400 => "Bad Request",
            401 => "Unauthorized",
            404 => "Not Found",
            500 => "Internal Server Error",
            _ => "Unknown Status"
        };

        private static string GetRolePermissions(string role) => role switch
        {
            "Admin" => "Full Access",
            "Editor" => "Create, Edit, Delete",
            "Viewer" => "Read Only",
            "Guest" => "Limited Access",
            _ => "No Access"
        };

        public enum OrderStatus
        {
            Pending,
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }

        private static string GetStatusDescription(OrderStatus status) => status switch
        {
            OrderStatus.Pending => "Order is pending review",
            OrderStatus.Processing => "Order is being processed",
            OrderStatus.Shipped => "Order has been shipped",
            OrderStatus.Delivered => "Order has been delivered",
            OrderStatus.Cancelled => "Order has been cancelled",
            _ => "Unknown status"
        };

        private static string FormatApiResponse(string endpoint, bool success) => (endpoint, success) switch
        {
            ("/users", true) => "Users retrieved successfully",
            ("/users", false) => "Failed to retrieve users",
            ("/orders", true) => "Orders retrieved successfully",
            ("/orders", false) => "Failed to retrieve orders",
            (_, true) => "Request successful",
            (_, false) => "Request failed"
        };

        // Pattern Matching
        private static string GetGrade(int score) => score switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };

        // Advanced Use Cases
        private static string GetAccessLevel(string role, bool isPremium) => (role, isPremium) switch
        {
            ("Admin", _) => "Full Access",
            ("Editor", true) => "Premium Editor Access",
            ("Editor", false) => "Standard Editor Access",
            ("Viewer", true) => "Premium Viewer Access",
            ("Viewer", false) => "Standard Viewer Access",
            _ => "No Access"
        };

        private static string GetDiscount(int quantity, decimal price) => (quantity, price) switch
        {
            (>= 100, _) => "Bulk Discount: 20%",
            (>= 50, >= 1000m) => "Volume Discount: 15%",
            (>= 50, _) => "Volume Discount: 10%",
            (_, >= 5000m) => "High Value Discount: 5%",
            _ => "No Discount"
        };

        public record Point(int X, int Y);

        private static string GetQuadrant(Point point) => point switch
        {
            (0, 0) => "Origin",
            (>= 0, >= 0) => "Quadrant I",
            (< 0, >= 0) => "Quadrant II",
            (< 0, < 0) => "Quadrant III",
            (>= 0, < 0) => "Quadrant IV"
        };

        // Expression-Bodied Members
        public class SubscriptionService
        {
            public string GetFeatures(string plan) => plan switch
            {
                "Free" => "Basic Access",
                "Pro" => "Premium Access",
                "Enterprise" => "All Features",
                _ => "Unknown"
            };

            public decimal GetPrice(string plan) => plan switch
            {
                "Free" => 0m,
                "Pro" => 9.99m,
                "Enterprise" => 49.99m,
                _ => 0m
            };
        }
    }
}

