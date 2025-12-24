namespace NetMasteryLab.Concepts.CSharpFundamentals.DateTimeExamples.Examples
{
    /// <summary>
    /// Ejemplos que demuestran el manejo de Date & Time en C#
    /// </summary>
    public class DateTimeExamples
    {
        /// <summary>
        /// Demuestra la inmutabilidad de DateTime
        /// </summary>
        public static void DemonstrateImmutability()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⚠️ Inmutabilidad de DateTime");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            Console.WriteLine("❌ MAL: Intentar modificar DateTime directamente");
            DateTime current = DateTime.Now;
            Console.WriteLine($"  Fecha original: {current:yyyy-MM-dd HH:mm:ss}");
            
            current.AddDays(1); // Esto NO modifica 'current'
            Console.WriteLine($"  Después de AddDays(1): {current:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("  ⚠️ La fecha NO cambió porque DateTime es inmutable\n");

            Console.WriteLine("✅ BIEN: Capturar el valor de retorno");
            DateTime now = DateTime.Now;
            Console.WriteLine($"  Fecha original: {now:yyyy-MM-dd HH:mm:ss}");
            
            DateTime tomorrow = now.AddDays(1); // Nueva instancia
            Console.WriteLine($"  Después de AddDays(1): {tomorrow:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("  ✅ Nueva instancia creada correctamente\n");

            Console.WriteLine("✅ BIEN: Reasignar el valor");
            DateTime date = DateTime.Now;
            Console.WriteLine($"  Fecha original: {date:yyyy-MM-dd HH:mm:ss}");
            
            date = date.AddDays(1); // Reasignar
            Console.WriteLine($"  Después de reasignar: {date:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("  ✅ Valor reasignado correctamente\n");
        }

        /// <summary>
        /// Demuestra cómo obtener fecha y hora actual
        /// </summary>
        public static void DemonstrateGettingCurrentDateTime()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📅 Obtener Fecha y Hora Actual");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // Fecha y hora local del sistema
            DateTime now = DateTime.Now;
            Console.WriteLine($"DateTime.Now: {now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"  (Hora local del sistema)\n");

            // Fecha y hora UTC
            DateTime utcNow = DateTime.UtcNow;
            Console.WriteLine($"DateTime.UtcNow: {utcNow:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"  (Hora UTC - Coordinated Universal Time)\n");

            // Solo la fecha (hora = 00:00:00)
            DateTime today = DateTime.Today;
            Console.WriteLine($"DateTime.Today: {today:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"  (Solo fecha, hora = 00:00:00)\n");

            Console.WriteLine("💡 Recomendación:");
            Console.WriteLine("  • Usa DateTime.UtcNow para almacenar en base de datos");
            Console.WriteLine("  • Usa DateTime.Now para mostrar al usuario");
            Console.WriteLine("  • Usa DateTime.Today cuando solo necesites la fecha\n");
        }

        /// <summary>
        /// Demuestra cómo crear DateTime específicos
        /// </summary>
        public static void DemonstrateCreatingDateTime()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🛠️ Crear DateTime Específicos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // Constructor con año, mes, día
            DateTime date1 = new DateTime(2024, 1, 15);
            Console.WriteLine($"new DateTime(2024, 1, 15): {date1:yyyy-MM-dd HH:mm:ss}\n");

            // Constructor con año, mes, día, hora, minuto, segundo
            DateTime date2 = new DateTime(2024, 1, 15, 14, 30, 0);
            Console.WriteLine($"new DateTime(2024, 1, 15, 14, 30, 0): {date2:yyyy-MM-dd HH:mm:ss}\n");

            // Usando Parse
            DateTime date3 = DateTime.Parse("2024-01-15");
            Console.WriteLine($"DateTime.Parse(\"2024-01-15\"): {date3:yyyy-MM-dd HH:mm:ss}\n");

            // Usando TryParse (más seguro)
            if (DateTime.TryParse("2024-01-15", out DateTime date4))
            {
                Console.WriteLine($"DateTime.TryParse válido: {date4:yyyy-MM-dd HH:mm:ss}\n");
            }

            if (!DateTime.TryParse("invalid-date", out DateTime date5))
            {
                Console.WriteLine("DateTime.TryParse inválido: No se pudo parsear\n");
            }
        }

        /// <summary>
        /// Demuestra operaciones comunes con DateTime
        /// </summary>
        public static void DemonstrateDateTimeOperations()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ➕ Operaciones Comunes con DateTime");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            DateTime now = DateTime.Now;
            Console.WriteLine($"Fecha base: {now:yyyy-MM-dd HH:mm:ss}\n");

            // Agregar tiempo
            Console.WriteLine("Agregar tiempo:");
            Console.WriteLine($"  AddDays(1): {now.AddDays(1):yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"  AddDays(7): {now.AddDays(7):yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"  AddMonths(1): {now.AddMonths(1):yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"  AddYears(1): {now.AddYears(1):yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"  AddHours(1): {now.AddHours(1):yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"  AddMinutes(30): {now.AddMinutes(30):yyyy-MM-dd HH:mm:ss}\n");

            // Quitar tiempo (valores negativos)
            Console.WriteLine("Quitar tiempo:");
            Console.WriteLine($"  AddDays(-1): {now.AddDays(-1):yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"  AddDays(-7): {now.AddDays(-7):yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"  AddHours(-1): {now.AddHours(-1):yyyy-MM-dd HH:mm:ss}\n");
        }

        /// <summary>
        /// Demuestra cálculo de diferencias entre fechas
        /// </summary>
        public static void DemonstrateDateDifference()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⏱️ Calcular Diferencia entre Fechas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            DateTime start = new DateTime(2024, 1, 1);
            DateTime end = new DateTime(2024, 1, 15);

            Console.WriteLine($"Fecha inicio: {start:yyyy-MM-dd}");
            Console.WriteLine($"Fecha fin: {end:yyyy-MM-dd}\n");

            // Usando TimeSpan
            TimeSpan difference = end - start;
            Console.WriteLine("Usando TimeSpan:");
            Console.WriteLine($"  Días: {difference.Days}");
            Console.WriteLine($"  Total Horas: {difference.TotalHours:F2}");
            Console.WriteLine($"  Total Minutos: {difference.TotalMinutes:F2}\n");

            // Usando métodos directos
            int daysDifference = (end - start).Days;
            Console.WriteLine($"Diferencia directa en días: {daysDifference}\n");
        }

        /// <summary>
        /// Demuestra comparación de fechas
        /// </summary>
        public static void DemonstrateDateComparison()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  🔍 Comparar Fechas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            DateTime date1 = new DateTime(2024, 1, 15);
            DateTime date2 = new DateTime(2024, 1, 20);

            Console.WriteLine($"date1: {date1:yyyy-MM-dd}");
            Console.WriteLine($"date2: {date2:yyyy-MM-dd}\n");

            // Comparación
            Console.WriteLine("Comparación:");
            Console.WriteLine($"  date1 < date2: {date1 < date2}");
            Console.WriteLine($"  date1 > date2: {date1 > date2}");
            Console.WriteLine($"  date1 == date2: {date1 == date2}\n");

            // Métodos de comparación
            int comparison = DateTime.Compare(date1, date2);
            Console.WriteLine($"DateTime.Compare(date1, date2): {comparison}");
            Console.WriteLine($"  (-1 si date1 < date2, 0 si iguales, 1 si date1 > date2)\n");

            // Comparar solo fechas (sin hora)
            DateTime date3 = new DateTime(2024, 1, 15, 10, 0, 0);
            DateTime date4 = new DateTime(2024, 1, 15, 14, 0, 0);
            Console.WriteLine($"date3: {date3:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"date4: {date4:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"  date3 == date4: {date3 == date4} (incluye hora)");
            Console.WriteLine($"  date3.Date == date4.Date: {date3.Date == date4.Date} (solo fecha)\n");
        }

        /// <summary>
        /// Demuestra formateo de fechas
        /// </summary>
        public static void DemonstrateDateFormatting()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  📝 Formateo de Fechas");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            DateTime now = DateTime.Now;

            Console.WriteLine("Métodos predefinidos:");
            Console.WriteLine($"  ToShortDateString(): {now.ToShortDateString()}");
            Console.WriteLine($"  ToLongDateString(): {now.ToLongDateString()}");
            Console.WriteLine($"  ToShortTimeString(): {now.ToShortTimeString()}");
            Console.WriteLine($"  ToLongTimeString(): {now.ToLongTimeString()}\n");

            Console.WriteLine("Formato personalizado:");
            Console.WriteLine($"  yyyy-MM-dd: {now:yyyy-MM-dd}");
            Console.WriteLine($"  dd/MM/yyyy: {now:dd/MM/yyyy}");
            Console.WriteLine($"  MMM dd, yyyy: {now:MMM dd, yyyy}");
            Console.WriteLine($"  dddd, MMMM dd, yyyy: {now:dddd, MMMM dd, yyyy}");
            Console.WriteLine($"  HH:mm:ss: {now:HH:mm:ss}");
            Console.WriteLine($"  hh:mm:ss tt: {now:hh:mm:ss tt}");
            Console.WriteLine($"  yyyy-MM-dd HH:mm:ss: {now:yyyy-MM-dd HH:mm:ss}\n");
        }

        /// <summary>
        /// Demuestra TimeSpan para duraciones
        /// </summary>
        public static void DemonstrateTimeSpan()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  ⏱️ TimeSpan para Duraciones");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // Crear TimeSpan
            TimeSpan duration1 = new TimeSpan(1, 2, 30, 45); // 1 día, 2 horas, 30 minutos, 45 segundos
            Console.WriteLine($"new TimeSpan(1, 2, 30, 45): {duration1}");
            Console.WriteLine($"  Días: {duration1.Days}, Horas: {duration1.Hours}, Minutos: {duration1.Minutes}\n");

            TimeSpan duration2 = TimeSpan.FromDays(1);
            Console.WriteLine($"TimeSpan.FromDays(1): {duration2}\n");

            TimeSpan duration3 = TimeSpan.FromHours(2.5);
            Console.WriteLine($"TimeSpan.FromHours(2.5): {duration3}");
            Console.WriteLine($"  Total Horas: {duration3.TotalHours}\n");

            TimeSpan duration4 = TimeSpan.FromMinutes(90);
            Console.WriteLine($"TimeSpan.FromMinutes(90): {duration4}");
            Console.WriteLine($"  Total Horas: {duration4.TotalHours}\n");
        }

        /// <summary>
        /// Demuestra ejemplos prácticos
        /// </summary>
        public static void DemonstratePracticalExamples()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  💡 Ejemplos Prácticos");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

            // Calcular edad
            DateTime birthDate = new DateTime(1990, 5, 15);
            int age = CalculateAge(birthDate);
            Console.WriteLine($"Calcular Edad:");
            Console.WriteLine($"  Fecha de nacimiento: {birthDate:yyyy-MM-dd}");
            Console.WriteLine($"  Edad: {age} años\n");

            // Verificar si es día laboral
            DateTime date = DateTime.Now;
            bool isWeekday = IsWeekday(date);
            Console.WriteLine($"Es Día Laboral:");
            Console.WriteLine($"  Fecha: {date:dddd, MMMM dd, yyyy}");
            Console.WriteLine($"  Es día laboral: {isWeekday}\n");

            // Primer y último día del mes
            DateTime now = DateTime.Now;
            DateTime firstDay = new DateTime(now.Year, now.Month, 1);
            DateTime lastDay = new DateTime(now.Year, now.Month, 
                DateTime.DaysInMonth(now.Year, now.Month));
            Console.WriteLine($"Primer y Último Día del Mes:");
            Console.WriteLine($"  Primer día: {firstDay:yyyy-MM-dd}");
            Console.WriteLine($"  Último día: {lastDay:yyyy-MM-dd}\n");

            // Días hasta próximo evento
            DateTime nextEvent = new DateTime(2024, 12, 25); // Navidad
            DateTime today = DateTime.Today;
            if (nextEvent < today)
            {
                nextEvent = nextEvent.AddYears(1);
            }
            TimeSpan timeUntilEvent = nextEvent - today;
            Console.WriteLine($"Días hasta Próximo Evento:");
            Console.WriteLine($"  Evento: {nextEvent:yyyy-MM-dd}");
            Console.WriteLine($"  Días restantes: {timeUntilEvent.Days}\n");
        }

        /// <summary>
        /// Calcula la edad basada en la fecha de nacimiento
        /// </summary>
        private static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            
            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            
            return age;
        }

        /// <summary>
        /// Verifica si una fecha es día laboral
        /// </summary>
        private static bool IsWeekday(DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && 
                   date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Ejecuta todos los ejemplos
        /// </summary>
        public static void RunAllExamples()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              Date & Time en C#                                ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

            DemonstrateImmutability();
            Console.WriteLine("\n");
            DemonstrateGettingCurrentDateTime();
            Console.WriteLine("\n");
            DemonstrateCreatingDateTime();
            Console.WriteLine("\n");
            DemonstrateDateTimeOperations();
            Console.WriteLine("\n");
            DemonstrateDateDifference();
            Console.WriteLine("\n");
            DemonstrateDateComparison();
            Console.WriteLine("\n");
            DemonstrateDateFormatting();
            Console.WriteLine("\n");
            DemonstrateTimeSpan();
            Console.WriteLine("\n");
            DemonstratePracticalExamples();

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("  RESUMEN");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            Console.WriteLine("✅ DateTime es Inmutable:");
            Console.WriteLine("   • Los métodos devuelven nuevas instancias");
            Console.WriteLine("   • Siempre captura el valor de retorno\n");
            
            Console.WriteLine("✅ Obtener Fecha y Hora:");
            Console.WriteLine("   • DateTime.Now - Hora local");
            Console.WriteLine("   • DateTime.UtcNow - Hora UTC (recomendado para BD)");
            Console.WriteLine("   • DateTime.Today - Solo fecha\n");
            
            Console.WriteLine("✅ Operaciones Comunes:");
            Console.WriteLine("   • AddDays(), AddMonths(), AddYears()");
            Console.WriteLine("   • Usar valores negativos para restar tiempo");
            Console.WriteLine("   • Restar fechas para obtener TimeSpan\n");
            
            Console.WriteLine("✅ Formateo:");
            Console.WriteLine("   • Métodos predefinidos: ToShortDateString(), etc.");
            Console.WriteLine("   • Formato personalizado: ToString(\"yyyy-MM-dd\")\n");
            
            Console.WriteLine("✅ TimeSpan:");
            Console.WriteLine("   • Representa duraciones");
            Console.WriteLine("   • TimeSpan.FromDays(), FromHours(), etc.\n");
        }
    }
}

