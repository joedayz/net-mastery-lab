namespace NetMasteryLab.Concepts.CSharpFundamentals.DataTypes.Examples
{
    /// <summary>
    /// Ejemplos que demuestran Value Types vs Reference Types en C#
    /// </summary>
    public class DataTypesExamples
    {
        /// <summary>
        /// Demuestra Value Types predefinidos
        /// </summary>
        public static void DemonstratePreDefinedValueTypes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💎 Pre-Defined Value Types");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Tipos Numéricos Enteros:");
            byte b = 255;
            sbyte sb = -128;
            short s = -32768;
            ushort us = 65535;
            int i = -2147483648;
            uint ui = 4294967295;
            long l = -9223372036854775808;
            ulong ul = 18446744073709551615;
            
            Console.WriteLine($"  byte: {b}");
            Console.WriteLine($"  int: {i}");
            Console.WriteLine($"  long: {l}\n");

            Console.WriteLine("Tipos Numéricos de Punto Flotante:");
            float f = 3.14f;
            double d = 3.141592653589793;
            decimal dec = 123.456m;
            
            Console.WriteLine($"  float: {f}");
            Console.WriteLine($"  double: {d}");
            Console.WriteLine($"  decimal: {dec}\n");

            Console.WriteLine("Otros Tipos:");
            bool flag = true;
            char c = 'A';
            
            Console.WriteLine($"  bool: {flag}");
            Console.WriteLine($"  char: {c}\n");

            Console.WriteLine("Características:");
            Console.WriteLine("  • Se almacenan en la stack");
            Console.WriteLine("  • Se copian por valor");
            Console.WriteLine("  • No pueden ser null (excepto nullable types)");
            Console.WriteLine("  • Más rápidos de acceder\n");
        }

        /// <summary>
        /// Demuestra User-Defined Value Types
        /// </summary>
        public static void DemonstrateUserDefinedValueTypes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📦 User-Defined Value Types");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Enumeration (Enum):");
            Status currentStatus = Status.Pending;
            Console.WriteLine($"  Status: {currentStatus}\n");

            Console.WriteLine("Structure (Struct):");
            Point p1 = new Point(10, 20);
            Point p2 = p1; // Copia por valor
            
            Console.WriteLine($"  p1: ({p1.X}, {p1.Y})");
            Console.WriteLine($"  p2: ({p2.X}, {p2.Y})");
            
            p2.X = 30; // Modificar p2 no afecta a p1
            Console.WriteLine($"  Después de p2.X = 30:");
            Console.WriteLine($"  p1: ({p1.X}, {p1.Y}) - No cambió");
            Console.WriteLine($"  p2: ({p2.X}, {p2.Y}) - Cambió\n");
        }

        /// <summary>
        /// Demuestra Pre-Defined Reference Types
        /// </summary>
        public static void DemonstratePreDefinedReferenceTypes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔗 Pre-Defined Reference Types");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Object:");
            object obj = new object();
            object str = "Hello";
            object num = 42; // Boxing: int se convierte a object
            Console.WriteLine($"  obj: {obj}");
            Console.WriteLine($"  str: {str}");
            Console.WriteLine($"  num: {num}\n");

            Console.WriteLine("String:");
            string str1 = "Hello";
            string str2 = str1; // str2 apunta a la misma cadena
            Console.WriteLine($"  str1: {str1}");
            Console.WriteLine($"  str2: {str2}");
            Console.WriteLine($"  ¿Son la misma referencia? {ReferenceEquals(str1, str2)}\n");
            Console.WriteLine("  Nota: string es inmutable, así que modificar crea nueva instancia\n");
        }

        /// <summary>
        /// Demuestra User-Defined Reference Types
        /// </summary>
        public static void DemonstrateUserDefinedReferenceTypes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🏗️ User-Defined Reference Types");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Class:");
            Person p1 = new Person { Name = "Alice", Age = 30 };
            Person p2 = p1; // p2 apunta al mismo objeto
            
            Console.WriteLine($"  p1.Name: {p1.Name}, p1.Age: {p1.Age}");
            Console.WriteLine($"  p2.Name: {p2.Name}, p2.Age: {p2.Age}");
            Console.WriteLine($"  ¿Son la misma referencia? {ReferenceEquals(p1, p2)}\n");
            
            p2.Name = "Bob"; // Modificar p2 afecta a p1
            Console.WriteLine($"  Después de p2.Name = 'Bob':");
            Console.WriteLine($"  p1.Name: {p1.Name} - Cambió (misma referencia)");
            Console.WriteLine($"  p2.Name: {p2.Name}\n");

            Console.WriteLine("Array:");
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int[] copy = numbers; // copy apunta al mismo array
            
            Console.WriteLine($"  numbers[0]: {numbers[0]}");
            Console.WriteLine($"  copy[0]: {copy[0]}");
            
            copy[0] = 10; // Modificar copy afecta a numbers
            Console.WriteLine($"  Después de copy[0] = 10:");
            Console.WriteLine($"  numbers[0]: {numbers[0]} - Cambió (misma referencia)");
            Console.WriteLine($"  copy[0]: {copy[0]}\n");
        }

        /// <summary>
        /// Demuestra comparación entre Value Types y Reference Types
        /// </summary>
        public static void DemonstrateValueVsReferenceComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔄 Comparación: Value Types vs Reference Types");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("VALUE TYPE: Copia por valor");
            int a = 10;
            int b = a; // b es una copia independiente
            Console.WriteLine($"  a = {a}, b = {b}");
            
            b = 20; // Modificar b no afecta a a
            Console.WriteLine($"  Después de b = 20:");
            Console.WriteLine($"  a = {a} (no cambió), b = {b}\n");

            Console.WriteLine("REFERENCE TYPE: Copia por referencia");
            Person p1 = new Person { Name = "Alice" };
            Person p2 = p1; // p2 apunta al mismo objeto
            Console.WriteLine($"  p1.Name = {p1.Name}, p2.Name = {p2.Name}");
            
            p2.Name = "Bob"; // Modificar p2 afecta a p1
            Console.WriteLine($"  Después de p2.Name = 'Bob':");
            Console.WriteLine($"  p1.Name = {p1.Name} (cambió - misma referencia)");
            Console.WriteLine($"  p2.Name = {p2.Name}\n");
        }

        /// <summary>
        /// Demuestra pasar tipos como parámetros
        /// </summary>
        public static void DemonstratePassingAsParameters()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📤 Pasar Tipos como Parámetros");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("VALUE TYPE: Se pasa por valor (copia)");
            int num = 10;
            Console.WriteLine($"  Antes: num = {num}");
            ModifyInt(num);
            Console.WriteLine($"  Después: num = {num} (no cambió)\n");

            Console.WriteLine("REFERENCE TYPE: Se pasa por referencia (puntero)");
            Person p = new Person { Name = "Original" };
            Console.WriteLine($"  Antes: p.Name = {p.Name}");
            ModifyPerson(p);
            Console.WriteLine($"  Después: p.Name = {p.Name} (cambió)\n");

            Console.WriteLine("VALUE TYPE con ref: Se pasa por referencia");
            int num2 = 10;
            Console.WriteLine($"  Antes: num2 = {num2}");
            ModifyIntRef(ref num2);
            Console.WriteLine($"  Después: num2 = {num2} (cambió)\n");
        }

        /// <summary>
        /// Demuestra comparación de tipos
        /// </summary>
        public static void DemonstrateTypeComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔍 Comparación de Tipos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("VALUE TYPE: Comparación por valor");
            int a = 10;
            int b = 10;
            bool areEqual = (a == b);
            Console.WriteLine($"  a = {a}, b = {b}");
            Console.WriteLine($"  a == b: {areEqual} (comparan valores)\n");

            Console.WriteLine("REFERENCE TYPE: Comparación por referencia");
            Person p1 = new Person { Name = "Alice" };
            Person p2 = new Person { Name = "Alice" };
            bool areEqualRef = (p1 == p2);
            Console.WriteLine($"  p1.Name = {p1.Name}, p2.Name = {p2.Name}");
            Console.WriteLine($"  p1 == p2: {areEqualRef} (comparan referencias, no valores)\n");

            Console.WriteLine("REFERENCE TYPE: Comparación por valor con Equals()");
            bool areEqualValues = p1.Equals(p2);
            Console.WriteLine($"  p1.Equals(p2): {areEqualValues} (comparan valores si está implementado)\n");
        }

        /// <summary>
        /// Demuestra Nullable Value Types
        /// </summary>
        public static void DemonstrateNullableValueTypes()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ❓ Nullable Value Types");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Value types pueden ser null usando nullable:");
            int? nullableInt = null;
            bool? nullableBool = null;
            
            Console.WriteLine($"  nullableInt: {nullableInt?.ToString() ?? "null"}");
            Console.WriteLine($"  nullableBool: {nullableBool?.ToString() ?? "null"}\n");

            Console.WriteLine("Verificar si tiene valor:");
            if (nullableInt.HasValue)
            {
                Console.WriteLine($"  Value: {nullableInt.Value}");
            }
            else
            {
                Console.WriteLine("  No value\n");
            }

            nullableInt = 42;
            Console.WriteLine($"  Después de nullableInt = 42:");
            Console.WriteLine($"  HasValue: {nullableInt.HasValue}");
            Console.WriteLine($"  Value: {nullableInt.Value}\n");

            Console.WriteLine("Null-coalescing operator:");
            int result = nullableInt ?? 0;
            Console.WriteLine($"  nullableInt ?? 0: {result}\n");
        }

        /// <summary>
        /// Demuestra ejemplos prácticos
        /// </summary>
        public static void DemonstratePracticalExamples()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Ejemplos Prácticos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("Ejemplo 1: Value Type - Struct");
            Coordinate c1 = new Coordinate { X = 10, Y = 20 };
            Coordinate c2 = c1; // Copia por valor
            c2.X = 30; // c1.X sigue siendo 10
            
            Console.WriteLine($"  c1: ({c1.X}, {c1.Y})");
            Console.WriteLine($"  c2: ({c2.X}, {c2.Y})\n");

            Console.WriteLine("Ejemplo 2: Reference Type - Class");
            Address addr1 = new Address { Street = "Main St", City = "NYC" };
            Address addr2 = addr1; // Referencia al mismo objeto
            addr2.City = "LA"; // addr1.City también es "LA"
            
            Console.WriteLine($"  addr1.City: {addr1.City}");
            Console.WriteLine($"  addr2.City: {addr2.City}\n");
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              Data Types en C#                                 ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstratePreDefinedValueTypes();
            Console.WriteLine("\n");
            DemonstrateUserDefinedValueTypes();
            Console.WriteLine("\n");
            DemonstratePreDefinedReferenceTypes();
            Console.WriteLine("\n");
            DemonstrateUserDefinedReferenceTypes();
            Console.WriteLine("\n");
            DemonstrateValueVsReferenceComparison();
            Console.WriteLine("\n");
            DemonstratePassingAsParameters();
            Console.WriteLine("\n");
            DemonstrateTypeComparison();
            Console.WriteLine("\n");
            DemonstrateNullableValueTypes();
            Console.WriteLine("\n");
            DemonstratePracticalExamples();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ Value Types:");
            Console.WriteLine("   • Almacenan datos directamente");
            Console.WriteLine("   • Se almacenan en la stack");
            Console.WriteLine("   • Se copian por valor");
            Console.WriteLine("   • Ejemplos: int, char, bool, struct\n");
            
            Console.WriteLine("✅ Reference Types:");
            Console.WriteLine("   • Almacenan dirección de memoria");
            Console.WriteLine("   • Se almacenan en la heap");
            Console.WriteLine("   • Se copian por referencia");
            Console.WriteLine("   • Ejemplos: string, class, array, interface\n");
            
            Console.WriteLine("💡 Key Takeaway:");
            Console.WriteLine("   • Conocer la diferencia ayuda a gestionar memoria eficientemente");
            Console.WriteLine("   • Value types: copias independientes");
            Console.WriteLine("   • Reference types: múltiples referencias al mismo objeto\n");
        }

        // Métodos auxiliares para demostración
        private static void ModifyInt(int value)
        {
            value = 100; // No afecta al original
        }

        private static void ModifyIntRef(ref int value)
        {
            value = 100; // Afecta al original
        }

        private static void ModifyPerson(Person person)
        {
            person.Name = "Modified"; // Afecta al original
        }
    }

    // Tipos de ejemplo para demostración

    public enum Status
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}

