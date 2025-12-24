using System.Reflection;

namespace NetMasteryLab.Concepts.CSharpFundamentals.AttributesReflection.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Attributes & Reflection en .NET
    /// </summary>
    public class AttributesReflectionExamples
    {
        /// <summary>
        /// Demuestra attributes predefinidos en .NET
        /// </summary>
        public static void DemonstratePredefinedAttributes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📋 Attributes Predefinidos en .NET");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("1. Serializable:");
            Console.WriteLine("   [Serializable]");
            Console.WriteLine("   public class Person { ... }\n");

            Console.WriteLine("2. Obsolete:");
            Console.WriteLine("   [Obsolete(\"Use NewMethod() instead\")]");
            Console.WriteLine("   public void OldMethod() { ... }\n");

            Console.WriteLine("3. Required (Data Annotations):");
            Console.WriteLine("   [Required(ErrorMessage = \"Name is required\")]");
            Console.WriteLine("   public string Name { get; set; }\n");

            // Ejemplo práctico
            var person = new SerializablePerson { Name = "Alice", Age = 30 };
            Console.WriteLine($"Ejemplo SerializablePerson: {person.Name}, {person.Age}\n");
        }

        /// <summary>
        /// Demuestra cómo crear attributes personalizados
        /// </summary>
        public static void DemonstrateCustomAttributes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🛠️ Crear Attributes Personalizados");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo: Author Attribute");
            Console.WriteLine("```csharp");
            Console.WriteLine("[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]");
            Console.WriteLine("public class AuthorAttribute : Attribute");
            Console.WriteLine("{");
            Console.WriteLine("    public string Name { get; set; }");
            Console.WriteLine("    public string Version { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            var service = new MyService();
            Console.WriteLine($"Servicio creado: {service.GetType().Name}\n");
        }

        /// <summary>
        /// Demuestra cómo obtener attributes usando Reflection
        /// </summary>
        public static void DemonstrateGettingAttributes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔍 Obtener Attributes usando Reflection");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo básico:");
            Console.WriteLine("```csharp");
            Console.WriteLine("Attribute[] attrs = Attribute.GetCustomAttributes(typeof(MyClass));");
            Console.WriteLine("```\n");

            // Ejemplo práctico con AuthorAttribute
            var type = typeof(MyService);
            var attributes = Attribute.GetCustomAttributes(type);
            
            Console.WriteLine($"Atributos en {type.Name}:");
            foreach (var attr in attributes)
            {
                if (attr is AuthorAttribute author)
                {
                    Console.WriteLine($"  Author: {author.Name}, Version: {author.Version}");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra inspección de propiedades con attributes
        /// </summary>
        public static void DemonstrateInspectingProperties()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔎 Inspeccionar Propiedades con Attributes");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var userType = typeof(User);
            var properties = userType.GetProperties();

            Console.WriteLine($"Propiedades en {userType.Name}:");
            foreach (var prop in properties)
            {
                Console.WriteLine($"  Property: {prop.Name}");
                
                var attributes = prop.GetCustomAttributes();
                foreach (var attr in attributes)
                {
                    Console.WriteLine($"    Attribute: {attr.GetType().Name}");
                    
                    if (attr is RequiredAttribute required)
                    {
                        Console.WriteLine($"      ErrorMessage: {required.ErrorMessage}");
                    }
                    
                    if (attr is DisplayAttribute display)
                    {
                        Console.WriteLine($"      Name: {display.Name}");
                    }
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra invocación dinámica de métodos
        /// </summary>
        public static void DemonstrateDynamicMethodInvocation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚡ Invocación Dinámica de Métodos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var service = new MyService();
            var type = service.GetType();
            var method = type.GetMethod("ProcessData");
            
            if (method != null)
            {
                var result = method.Invoke(service, new object[] { "test input" });
                Console.WriteLine($"Resultado de invocación dinámica: {result}\n");
            }
        }

        /// <summary>
        /// Demuestra validación usando attributes y reflection
        /// </summary>
        public static void DemonstrateValidation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ✅ Validación usando Attributes & Reflection");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var user = new User
            {
                UserName = "john_doe",
                Email = "john@example.com"
            };

            var validator = new ValidationService();
            bool isValid = validator.Validate(user);
            
            Console.WriteLine($"Usuario válido: {isValid}\n");

            // Ejemplo con usuario inválido
            var invalidUser = new User
            {
                UserName = "", // Required pero vacío
                Email = "invalid-email" // Email inválido
            };
            
            bool isInvalid = validator.Validate(invalidUser);
            Console.WriteLine($"Usuario inválido: {!isInvalid}\n");
        }

        /// <summary>
        /// Demuestra creación dinámica de instancias
        /// </summary>
        public static void DemonstrateDynamicInstanceCreation()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🏭 Creación Dinámica de Instancias");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            var typeName = typeof(MyService).FullName;
            var type = Type.GetType(typeName);
            
            if (type != null)
            {
                var instance = Activator.CreateInstance(type);
                Console.WriteLine($"Instancia creada dinámicamente: {instance?.GetType().Name}\n");
            }
        }

        /// <summary>
        /// Demuestra uso en Dependency Injection
        /// </summary>
        public static void DemonstrateDependencyInjection()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💉 Dependency Injection con Attributes");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo: Registrar servicios automáticamente");
            Console.WriteLine("```csharp");
            Console.WriteLine("var types = Assembly.GetExecutingAssembly()");
            Console.WriteLine("    .GetTypes()");
            Console.WriteLine("    .Where(t => t.GetCustomAttribute<InjectableAttribute>() != null);");
            Console.WriteLine("```\n");

            // Simulación
            var injectableTypes = typeof(InjectableService).Assembly
                .GetTypes()
                .Where(t => t.GetCustomAttribute<InjectableAttribute>() != null);
            
            Console.WriteLine("Servicios encontrados con [Injectable]:");
            foreach (var type in injectableTypes)
            {
                var attr = type.GetCustomAttribute<InjectableAttribute>();
                Console.WriteLine($"  {type.Name} - Lifetime: {attr?.Lifetime}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Demuestra consideraciones de rendimiento
        /// </summary>
        public static void DemonstratePerformanceConsiderations()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Consideraciones de Rendimiento");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ MAL: Usar Reflection en código crítico de rendimiento");
            Console.WriteLine("   Reflection es costoso y debe usarse con cuidado\n");

            Console.WriteLine("✅ BIEN: Cachear información de Reflection");
            Console.WriteLine("   Guardar resultados de GetMethod(), GetProperty(), etc.\n");

            Console.WriteLine("💡 Tip:");
            Console.WriteLine("   • Usar Reflection solo cuando sea necesario");
            Console.WriteLine("   • Cachear información de tipos y métodos");
            Console.WriteLine("   • Considerar alternativas como expresiones o delegates\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          Attributes & Reflection en .NET                    ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstratePredefinedAttributes();
            Console.WriteLine("\n");
            DemonstrateCustomAttributes();
            Console.WriteLine("\n");
            DemonstrateGettingAttributes();
            Console.WriteLine("\n");
            DemonstrateInspectingProperties();
            Console.WriteLine("\n");
            DemonstrateDynamicMethodInvocation();
            Console.WriteLine("\n");
            DemonstrateValidation();
            Console.WriteLine("\n");
            DemonstrateDynamicInstanceCreation();
            Console.WriteLine("\n");
            DemonstrateDependencyInjection();
            Console.WriteLine("\n");
            DemonstratePerformanceConsiderations();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Attributes:");
            Console.WriteLine("   • Agregan metadatos a elementos de código");
            Console.WriteLine("   • No afectan la ejecución directa");
            Console.WriteLine("   • Accesibles vía Reflection\n");
            
            Console.WriteLine("✅ Reflection:");
            Console.WriteLine("   • Inspecciona metadatos en tiempo de ejecución");
            Console.WriteLine("   • Permite invocación dinámica de métodos");
            Console.WriteLine("   • Habilita creación dinámica de instancias\n");
            
            Console.WriteLine("💡 Key Takeaway:");
            Console.WriteLine("   • Attributes y Reflection son esenciales para código flexible");
            Console.WriteLine("   • Usados por ASP.NET Core y Entity Framework");
            Console.WriteLine("   • Reducen código boilerplate y mejoran mantenibilidad");
            Console.WriteLine("   • ⚠️ Reflection es costoso - usar con cuidado\n");
        }
    }

    // Clases de ejemplo para demostración

    [Serializable]
    public class SerializablePerson
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    [Author("John Doe", Version = "1.0")]
    public class MyService
    {
        public string ProcessData(string input)
        {
            return $"Processed: {input}";
        }
    }

    public class User
    {
        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = string.Empty;
        
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
    }

    [Injectable(ServiceLifetime.Scoped)]
    public class InjectableService
    {
        public void DoWork()
        {
            Console.WriteLine("Working...");
        }
    }

    // Attributes personalizados

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorAttribute : Attribute
    {
        public string Name { get; set; }
        public string Version { get; set; }
        
        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class InjectableAttribute : Attribute
    {
        public ServiceLifetime Lifetime { get; set; }
        
        public InjectableAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            Lifetime = lifetime;
        }
    }

    public enum ServiceLifetime
    {
        Singleton,
        Scoped,
        Transient
    }

    // Servicios de ejemplo

    public class ValidationService
    {
        public bool Validate(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();
            
            foreach (var prop in properties)
            {
                var requiredAttr = prop.GetCustomAttribute<RequiredAttribute>();
                if (requiredAttr != null)
                {
                    var value = prop.GetValue(obj);
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
    }

    // Data Annotations (simuladas para el ejemplo)
    public class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class DisplayAttribute : Attribute
    {
        public string Name { get; set; } = string.Empty;
    }

    public class EmailAddressAttribute : Attribute
    {
    }
}

