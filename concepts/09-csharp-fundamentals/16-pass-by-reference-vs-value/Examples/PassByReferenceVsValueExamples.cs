using System;

namespace NetMasteryLab.Concepts.CSharpFundamentals.PassByReferenceVsValue.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Pass By Reference vs Pass By Value
    /// </summary>
    public class PassByReferenceVsValueExamples
    {
        // Clase de ejemplo
        public class Cup
        {
            public string Contents { get; set; } = string.Empty;
        }

        // Clase de ejemplo
        public class Person
        {
            public string Name { get; set; } = string.Empty;
        }

        /// <summary>
        /// Demuestra Pass By Reference con ref
        /// </summary>
        public static void DemonstratePassByReference()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🏆 Pass By Reference (con ref)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Usando 'ref' para pasar por referencia explícita:");
            Console.WriteLine("```csharp");
            Console.WriteLine("void FillCup(ref Cup myCup)");
            Console.WriteLine("{");
            Console.WriteLine("    myCup.Contents = \"coffee\";  // ¡La taza original se modifica!");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("Cup myOriginalCup = new Cup();");
            Console.WriteLine("FillCup(ref myOriginalCup);");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            Cup originalCup = new Cup();
            FillCup(ref originalCup);
            Console.WriteLine($"Resultado: originalCup.Contents = \"{originalCup.Contents}\"\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  ✅ El método recibe una referencia directa al objeto original");
            Console.WriteLine("  ✅ Cualquier modificación afecta al objeto original");
            Console.WriteLine("  ✅ Puedes reasignar la variable dentro del método\n");
        }

        /// <summary>
        /// Demuestra Pass By Value (comportamiento por defecto)
        /// </summary>
        public static void DemonstratePassByValue()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📦 Pass By Value (Comportamiento por Defecto)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ Pasar por valor (comportamiento por defecto):");
            Console.WriteLine("```csharp");
            Console.WriteLine("void FillCup(Cup myCup)");
            Console.WriteLine("{");
            Console.WriteLine("    myCup.Contents = \"coffee\";  // Modifica el objeto");
            Console.WriteLine("    myCup = new Cup();            // Solo afecta la copia local");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("Cup myOriginalCup = new Cup();");
            Console.WriteLine("FillCup(myOriginalCup);");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            Cup originalCup = new Cup();
            FillCup(originalCup);
            Console.WriteLine($"Resultado: originalCup.Contents = \"{originalCup.Contents}\"\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  ✅ Se pasa una copia de la referencia (para reference types)");
            Console.WriteLine("  ✅ Puedes modificar propiedades del objeto");
            Console.WriteLine("  ✅ Reasignar el parámetro no afecta al original\n");
        }

        /// <summary>
        /// Demuestra la diferencia entre ref y value
        /// </summary>
        public static void DemonstrateDifference()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Diferencia Clave: Reasignación");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Pass By Value:");
            Person p1 = new Person { Name = "Original" };
            Console.WriteLine($"  Antes: p1.Name = \"{p1.Name}\"");
            TryReassign(p1);
            Console.WriteLine($"  Después: p1.Name = \"{p1.Name}\" (no cambió)\n");

            Console.WriteLine("Pass By Reference (ref):");
            Person p2 = new Person { Name = "Original" };
            Console.WriteLine($"  Antes: p2.Name = \"{p2.Name}\"");
            TryReassignRef(ref p2);
            Console.WriteLine($"  Después: p2.Name = \"{p2.Name}\" (cambió)\n");
        }

        /// <summary>
        /// Demuestra out parameters
        /// </summary>
        public static void DemonstrateOutParameters()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📤 out Parameters");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ out no requiere inicialización:");
            Console.WriteLine("```csharp");
            Console.WriteLine("bool TryParse(string input, out int result)");
            Console.WriteLine("{");
            Console.WriteLine("    return int.TryParse(input, out result);");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("int value;");
            Console.WriteLine("if (TryParse(\"123\", out value))");
            Console.WriteLine("    Console.WriteLine(value);  // Output: 123");
            Console.WriteLine("```\n");

            // Ejemplo práctico
            if (TryDivide(10, 3, out int quotient, out int remainder))
            {
                Console.WriteLine($"División exitosa: Quotient = {quotient}, Remainder = {remainder}\n");
            }

            Console.WriteLine("Diferencias entre ref y out:");
            Console.WriteLine("  • ref: Variable debe estar inicializada antes");
            Console.WriteLine("  • out: Variable NO necesita inicialización");
            Console.WriteLine("  • out: DEBE asignarse dentro del método\n");
        }

        /// <summary>
        /// Demuestra in parameters
        /// </summary>
        public static void DemonstrateInParameters()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📥 in Parameters (C# 7.0+)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("✅ in permite pasar por referencia pero solo lectura:");
            Console.WriteLine("```csharp");
            Console.WriteLine("void ProcessLargeStruct(in LargeStruct data)");
            Console.WriteLine("{");
            Console.WriteLine("    var value = data.Field1;  // ✅ OK - leer");
            Console.WriteLine("    // data.Field1 = 10;      // ❌ Error - no se puede modificar");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("Ventajas:");
            Console.WriteLine("  ✅ Evita copiar structs grandes (mejor rendimiento)");
            Console.WriteLine("  ✅ Garantiza que el parámetro no se modifique");
            Console.WriteLine("  ✅ Útil para structs grandes en métodos de solo lectura\n");
        }

        /// <summary>
        /// Demuestra value types vs reference types
        /// </summary>
        public static void DemonstrateValueTypesVsReferenceTypes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔢 Value Types vs Reference Types");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Value Types (int, float, struct):");
            Console.WriteLine("  • Se pasan por copia de su valor");
            int num = 10;
            Console.WriteLine($"  Antes: num = {num}");
            Increment(num);
            Console.WriteLine($"  Después: num = {num} (no cambió sin ref)\n");

            Console.WriteLine("Value Types con ref:");
            int num2 = 10;
            Console.WriteLine($"  Antes: num2 = {num2}");
            Increment(ref num2);
            Console.WriteLine($"  Después: num2 = {num2} (cambió con ref)\n");

            Console.WriteLine("Reference Types (objects, arrays):");
            Console.WriteLine("  • Pasan una copia de la referencia");
            Person p = new Person { Name = "Original" };
            Console.WriteLine($"  Antes: p.Name = \"{p.Name}\"");
            ModifyPerson(p);
            Console.WriteLine($"  Después: p.Name = \"{p.Name}\" (propiedad modificada)\n");
        }

        /// <summary>
        /// Demuestra errores comunes
        /// </summary>
        public static void DemonstrateCommonMistakes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Errores Comunes");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ Error 1: Asumir que Reference Types se Pasan por Referencia");
            Console.WriteLine("```csharp");
            Console.WriteLine("void Reassign(Person person)");
            Console.WriteLine("{");
            Console.WriteLine("    person = new Person { Name = \"New\" };  // Solo afecta copia local");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Solución: Usar ref si necesitas reasignar");
            Console.WriteLine("```csharp");
            Console.WriteLine("void Reassign(ref Person person)");
            Console.WriteLine("{");
            Console.WriteLine("    person = new Person { Name = \"New\" };  // Afecta al original");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("❌ Error 2: Intentar Modificar Value Types sin ref");
            Console.WriteLine("```csharp");
            Console.WriteLine("void Swap(int a, int b)");
            Console.WriteLine("{");
            Console.WriteLine("    int temp = a;");
            Console.WriteLine("    a = b;  // No funciona - solo afecta copias locales");
            Console.WriteLine("    b = temp;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");

            Console.WriteLine("✅ Solución: Usar ref para modificar");
            Console.WriteLine("```csharp");
            Console.WriteLine("void Swap(ref int a, ref int b)");
            Console.WriteLine("{");
            Console.WriteLine("    int temp = a;");
            Console.WriteLine("    a = b;  // Funciona - afecta a los originales");
            Console.WriteLine("    b = temp;");
            Console.WriteLine("}");
            Console.WriteLine("```\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     Pass By Reference vs Pass By Value en C#                ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstratePassByReference();
            Console.WriteLine("\n");
            DemonstratePassByValue();
            Console.WriteLine("\n");
            DemonstrateDifference();
            Console.WriteLine("\n");
            DemonstrateOutParameters();
            Console.WriteLine("\n");
            DemonstrateInParameters();
            Console.WriteLine("\n");
            DemonstrateValueTypesVsReferenceTypes();
            Console.WriteLine("\n");
            DemonstrateCommonMistakes();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Pass By Value (Por Defecto):");
            Console.WriteLine("   • Se pasa una copia de la referencia o del valor");
            Console.WriteLine("   • Puedes modificar propiedades del objeto");
            Console.WriteLine("   • Reasignar el parámetro no afecta al original\n");
            
            Console.WriteLine("✅ Pass By Reference (ref):");
            Console.WriteLine("   • Se pasa una referencia directa al original");
            Console.WriteLine("   • Cualquier modificación afecta al original");
            Console.WriteLine("   • Puedes reasignar la variable\n");
            
            Console.WriteLine("✅ out Parameters:");
            Console.WriteLine("   • Similar a ref pero sin requerir inicialización");
            Console.WriteLine("   • Debe asignarse dentro del método");
            Console.WriteLine("   • Ideal para múltiples valores de retorno\n");
            
            Console.WriteLine("✅ in Parameters:");
            Console.WriteLine("   • Referencia de solo lectura");
            Console.WriteLine("   • Evita copiar structs grandes");
            Console.WriteLine("   • Garantiza inmutabilidad\n");
        }

        // Métodos auxiliares para demostración
        private static void FillCup(ref Cup myCup)
        {
            myCup.Contents = "coffee";
        }

        private static void FillCup(Cup myCup)
        {
            myCup.Contents = "coffee";
            myCup = new Cup();  // Solo afecta la copia local
        }

        private static void TryReassign(Person person)
        {
            person = new Person { Name = "New" };  // Solo afecta la copia local
        }

        private static void TryReassignRef(ref Person person)
        {
            person = new Person { Name = "New" };  // Afecta al original
        }

        private static void Increment(int number)
        {
            number++;  // Solo afecta la copia local
        }

        private static void Increment(ref int number)
        {
            number++;  // Afecta al original
        }

        private static void ModifyPerson(Person person)
        {
            person.Name = "Modified";  // Modifica el objeto original
        }

        private static bool TryDivide(int dividend, int divisor, out int quotient, out int remainder)
        {
            if (divisor == 0)
            {
                quotient = 0;
                remainder = 0;
                return false;
            }
            
            quotient = dividend / divisor;
            remainder = dividend % divisor;
            return true;
        }
    }
}

