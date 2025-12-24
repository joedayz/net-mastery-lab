using System;

namespace NetMasteryLab.Concepts.CleanCode.ClearDescriptivePropertyNames.Examples
{
    /// <summary>
    /// Ejemplos que demuestran nombres claros y descriptivos para propiedades
    /// </summary>
    public class ClearDescriptivePropertyNamesExamples
    {
        // ✅ BIEN: Clase con nombres claros y descriptivos
        public class Order
        {
            // Clear and descriptive property names
            public int OrderId { get; set; } // Unique identifier for the order
            public DateTime OrderDate { get; set; } // Date the order was placed
            public string CustomerName { get; set; } = string.Empty; // Name of the customer placing the order
            public decimal OrderAmount { get; set; } // Total amount for the order
            public string OrderStatus { get; set; } = string.Empty; // Status of the order (e.g., Pending, Shipped, Delivered)
        }

        // ❌ MAL: Clase con nombres genéricos y ambiguos
        public class BadOrder
        {
            public int Id { get; set; } // ¿Qué tipo de ID?
            public DateTime Date { get; set; } // ¿Qué fecha?
            public string Name { get; set; } = string.Empty; // ¿Nombre de qué?
            public decimal Amount { get; set; } // ¿Qué cantidad?
            public string Status { get; set; } = string.Empty; // ¿Estado de qué?
        }

        /// <summary>
        /// Demuestra nombres claros y descriptivos
        /// </summary>
        public static void DemonstrateClearDescriptiveNames()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ Nombres Claros y Descriptivos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Nombres claros y descriptivos");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public int OrderId { get; set; } // Unique identifier for the order");
            Console.WriteLine("    public DateTime OrderDate { get; set; } // Date the order was placed");
            Console.WriteLine("    public string CustomerName { get; set; } // Name of the customer");
            Console.WriteLine("    public decimal OrderAmount { get; set; } // Total amount for the order");
            Console.WriteLine("    public string OrderStatus { get; set; } // Status of the order");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  ✅ El código se lee como un libro");
            Console.WriteLine("  ✅ No necesitas comentarios extensos");
            Console.WriteLine("  ✅ Otros desarrolladores entienden inmediatamente\n");
        }

        /// <summary>
        /// Demuestra evitar ambigüedad
        /// </summary>
        public static void DemonstrateAvoidAmbiguity()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🧐 Evitar Ambigüedad");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ MAL: Nombres genéricos y ambiguos");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Product");
            Console.WriteLine("{");
            Console.WriteLine("    public object Data { get; set; } // ¿Qué tipo de datos?");
            Console.WriteLine("    public string Info { get; set; } // ¿Qué información?");
            Console.WriteLine("    public decimal Value { get; set; } // ¿Qué valor?");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: Nombres específicos y claros");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Product");
            Console.WriteLine("{");
            Console.WriteLine("    public ProductDetails ProductDetails { get; set; }");
            Console.WriteLine("    public string ProductDescription { get; set; }");
            Console.WriteLine("    public decimal ProductPrice { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra consistencia
        /// </summary>
        public static void DemonstrateConsistency()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📏 Consistencia");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Consistente en toda la clase");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public int OrderId { get; set; }");
            Console.WriteLine("    public DateTime OrderDate { get; set; }");
            Console.WriteLine("    public string CustomerName { get; set; }");
            Console.WriteLine("    public decimal OrderAmount { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ MAL: Inconsistente");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public int OrderId { get; set; }");
            Console.WriteLine("    public DateTime orderDate { get; set; } // camelCase inconsistente");
            Console.WriteLine("    public string Customer_Name { get; set; } // snake_case inconsistente");
            Console.WriteLine("    public decimal STATUS { get; set; } // UPPERCASE inconsistente");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra evitar redundancia
        /// </summary>
        public static void DemonstrateAvoidRedundancy()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🧠 Evitar Redundancia");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ MAL: Redundancia innecesaria");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public int OrderOrderId { get; set; } // Redundante: 'Order' dos veces");
            Console.WriteLine("    public DateTime OrderOrderDate { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: Sin redundancia cuando el contexto es claro");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public int Id { get; set; } // Contexto claro: Order.Id");
            Console.WriteLine("    public DateTime Date { get; set; } // Contexto claro: Order.Date");
            Console.WriteLine("    public string CustomerName { get; set; } // Necesario: no es Order.CustomerName");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra términos del dominio
        /// </summary>
        public static void DemonstrateDomainTerms()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🌐 Términos del Dominio");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ BIEN: Términos del dominio del negocio");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public OrderStatus OrderStatus { get; set; } // Término del dominio");
            Console.WriteLine("    public ShippingMethod ShippingMethod { get; set; } // Término del dominio");
            Console.WriteLine("    public PaymentStatus PaymentStatus { get; set; } // Término del dominio");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ MAL: Términos técnicos genéricos");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public string Status { get; set; } // Genérico, no específico");
            Console.WriteLine("    public string Method { get; set; } // Genérico, no específico");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra equilibrio en nombres
        /// </summary>
        public static void DemonstrateBalance()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🛠️ Equilibrio en Nombres");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ MAL: Demasiado corto y ambiguo");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public int Id { get; set; }");
            Console.WriteLine("    public DateTime Dt { get; set; } // Abreviación confusa");
            Console.WriteLine("    public string Nm { get; set; } // Abreviación confusa");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ MAL: Demasiado largo y verboso");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public int OrderIdentifierUniqueId { get; set; } // Demasiado largo");
            Console.WriteLine("    public DateTime OrderPlacedDateAndTime { get; set; } // Demasiado verboso");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ BIEN: Equilibrio perfecto");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public int OrderId { get; set; } // Claro y conciso");
            Console.WriteLine("    public DateTime OrderDate { get; set; } // Claro y conciso");
            Console.WriteLine("    public string CustomerName { get; set; } // Claro y conciso");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Demuestra comparación antes vs después
        /// </summary>
        public static void DemonstrateBeforeAfter()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📊 Comparación: Antes vs Después");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ ANTES: Nombres genéricos y ambiguos");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public int Id { get; set; }");
            Console.WriteLine("    public DateTime Date { get; set; }");
            Console.WriteLine("    public string Name { get; set; }");
            Console.WriteLine("    public decimal Amount { get; set; }");
            Console.WriteLine("    public string Status { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Problemas:");
            Console.WriteLine("  ❌ No está claro qué representa cada propiedad");
            Console.WriteLine("  ❌ Requiere investigación adicional");
            Console.WriteLine("  ❌ Propenso a errores y malentendidos\n");

            Console.WriteLine("✅ DESPUÉS: Nombres claros y descriptivos");
            Console.WriteLine("```csharp");
            Console.WriteLine("public class Order");
            Console.WriteLine("{");
            Console.WriteLine("    public int OrderId { get; set; } // Unique identifier for the order");
            Console.WriteLine("    public DateTime OrderDate { get; set; } // Date the order was placed");
            Console.WriteLine("    public string CustomerName { get; set; } // Name of the customer");
            Console.WriteLine("    public decimal OrderAmount { get; set; } // Total amount for the order");
            Console.WriteLine("    public string OrderStatus { get; set; } // Status of the order");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Beneficios:");
            Console.WriteLine("  ✅ Código autoexplicativo");
            Console.WriteLine("  ✅ Fácil de entender sin comentarios");
            Console.WriteLine("  ✅ Menos propenso a errores\n");
        }

        /// <summary>
        /// Demuestra checklist para nombres
        /// </summary>
        public static void DemonstrateChecklist()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ Checklist para Nombres de Propiedades");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. ¿Este nombre describe claramente los datos?");
            Console.WriteLine("   ✅ BIEN: public string CustomerEmailAddress { get; set; }");
            Console.WriteLine("   ❌ MAL: public string Email { get; set; } // ¿Email de qué?\n");

            Console.WriteLine("2. ¿Es conciso pero específico?");
            Console.WriteLine("   ✅ BIEN: public DateTime OrderDate { get; set; }");
            Console.WriteLine("   ❌ MAL: public DateTime Dt { get; set; } // Demasiado corto");
            Console.WriteLine("   ❌ MAL: public DateTime OrderPlacedDateAndTime { get; set; } // Demasiado largo\n");

            Console.WriteLine("3. ¿Soy consistente en todo el código?");
            Console.WriteLine("   ✅ BIEN: Consistente en toda la clase");
            Console.WriteLine("   ❌ MAL: Mezcla PascalCase, camelCase, snake_case\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║        Clear & Descriptive Property Names                     ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateClearDescriptiveNames();
            Console.WriteLine("\n");
            DemonstrateAvoidAmbiguity();
            Console.WriteLine("\n");
            DemonstrateConsistency();
            Console.WriteLine("\n");
            DemonstrateAvoidRedundancy();
            Console.WriteLine("\n");
            DemonstrateDomainTerms();
            Console.WriteLine("\n");
            DemonstrateBalance();
            Console.WriteLine("\n");
            DemonstrateBeforeAfter();
            Console.WriteLine("\n");
            DemonstrateChecklist();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Principios Clave:");
            Console.WriteLine("   • Readability: Nombres que se explican por sí mismos");
            Console.WriteLine("   • Maintenance: Código autoexplicativo para el futuro");
            Console.WriteLine("   • Context: Evitar ambigüedad con nombres específicos");
            Console.WriteLine("   • Consistency: Mantener convenciones consistentes");
            Console.WriteLine("   • Simplicity: Evitar redundancia innecesaria");
            Console.WriteLine("   • Domain Terms: Usar lenguaje del negocio");
            Console.WriteLine("   • Balance: Descriptivo pero no abrumador\n");
            
            Console.WriteLine("✅ Checklist Final:");
            Console.WriteLine("   • ¿Este nombre describe claramente los datos?");
            Console.WriteLine("   • ¿Es conciso pero específico?");
            Console.WriteLine("   • ¿Soy consistente en todo el código?\n");
            
            Console.WriteLine("💡 Escribe código por el que tu yo futuro y tu equipo te agradecerán! 🙌\n");
        }
    }
}

