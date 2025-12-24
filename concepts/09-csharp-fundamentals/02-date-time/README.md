# Date & Time en C# 📅

## Introducción

El manejo de fechas y horas es integral para muchas aplicaciones. C# ofrece capacidades ricas para la manipulación de fechas y horas a través de `DateTime`, `TimeSpan`, `DateTimeOffset` y otras estructuras.

## 📖 ¿Qué es DateTime?

`DateTime` es una estructura en C# que representa un punto específico en el tiempo, típicamente expresado como una fecha y hora del día. Es **inmutable**, lo que significa que una vez creada, no puede ser modificada. Los métodos que parecen modificar un `DateTime` en realidad devuelven una nueva instancia.

## 🔑 Conceptos Clave

### 1. DateTime es Inmutable

**⚠️ Error Común:** Intentar modificar un `DateTime` directamente.

```csharp
// ❌ MAL: DateTime es inmutable, esto no funciona
DateTime current = DateTime.Now;
current.AddDays(1); // Esto NO modifica 'current'
Console.WriteLine(current); // Sigue siendo la fecha original

// ✅ BIEN: Capturar el valor de retorno
DateTime current = DateTime.Now;
DateTime tomorrow = current.AddDays(1); // Nueva instancia
Console.WriteLine(tomorrow); // Fecha con un día agregado
```

### 2. Obtener Fecha y Hora Actual

```csharp
// Fecha y hora local del sistema
DateTime now = DateTime.Now;

// Fecha y hora UTC (Coordinated Universal Time)
DateTime utcNow = DateTime.UtcNow;

// Solo la fecha (hora = 00:00:00)
DateTime today = DateTime.Today;
```

### 3. Crear DateTime Específico

```csharp
// Constructor con año, mes, día
DateTime date1 = new DateTime(2024, 1, 15);

// Constructor con año, mes, día, hora, minuto, segundo
DateTime date2 = new DateTime(2024, 1, 15, 14, 30, 0);

// Usando Parse
DateTime date3 = DateTime.Parse("2024-01-15");

// Usando TryParse (más seguro)
if (DateTime.TryParse("2024-01-15", out DateTime date4))
{
    Console.WriteLine($"Fecha válida: {date4}");
}
```

## 🛠️ Operaciones Comunes con DateTime

### Agregar/Quitar Tiempo

```csharp
DateTime now = DateTime.Now;

// Agregar tiempo (devuelve nueva instancia)
DateTime tomorrow = now.AddDays(1);
DateTime nextWeek = now.AddDays(7);
DateTime nextMonth = now.AddMonths(1);
DateTime nextYear = now.AddYears(1);
DateTime inOneHour = now.AddHours(1);
DateTime in30Minutes = now.AddMinutes(30);
DateTime in45Seconds = now.AddSeconds(45);

// Quitar tiempo (usar valores negativos)
DateTime yesterday = now.AddDays(-1);
DateTime lastWeek = now.AddDays(-7);
DateTime oneHourAgo = now.AddHours(-1);
```

### Calcular Diferencia entre Fechas

```csharp
DateTime start = new DateTime(2024, 1, 1);
DateTime end = new DateTime(2024, 1, 15);

// Usando TimeSpan
TimeSpan difference = end - start;
Console.WriteLine($"Días: {difference.Days}");
Console.WriteLine($"Horas: {difference.TotalHours}");
Console.WriteLine($"Minutos: {difference.TotalMinutes}");

// Usando métodos directos
int daysDifference = (end - start).Days;
```

### Comparar Fechas

```csharp
DateTime date1 = new DateTime(2024, 1, 15);
DateTime date2 = new DateTime(2024, 1, 20);

// Comparación
bool isBefore = date1 < date2; // true
bool isAfter = date1 > date2; // false
bool isEqual = date1 == date2; // false

// Métodos de comparación
int comparison = DateTime.Compare(date1, date2);
// -1 si date1 < date2
// 0 si date1 == date2
// 1 si date1 > date2
```

## 📝 Formateo de Fechas

### Métodos de Formateo Predefinidos

```csharp
DateTime now = DateTime.Now;

// Formato corto de fecha
string shortDate = now.ToShortDateString(); // "1/15/2024"

// Formato largo de fecha
string longDate = now.ToLongDateString(); // "Monday, January 15, 2024"

// Formato corto de hora
string shortTime = now.ToShortTimeString(); // "2:30 PM"

// Formato largo de hora
string longTime = now.ToLongTimeString(); // "2:30:45 PM"

// Formato completo
string fullDateTime = now.ToString(); // "1/15/2024 2:30:45 PM"
```

### Formateo Personalizado

```csharp
DateTime now = DateTime.Now;

// Formato personalizado con ToString()
string formatted1 = now.ToString("yyyy-MM-dd"); // "2024-01-15"
string formatted2 = now.ToString("dd/MM/yyyy"); // "15/01/2024"
string formatted3 = now.ToString("MMM dd, yyyy"); // "Jan 15, 2024"
string formatted4 = now.ToString("dddd, MMMM dd, yyyy"); // "Monday, January 15, 2024"
string formatted5 = now.ToString("HH:mm:ss"); // "14:30:45" (24 horas)
string formatted6 = now.ToString("hh:mm:ss tt"); // "02:30:45 PM" (12 horas)
```

### Formatos Comunes

| Formato | Descripción | Ejemplo |
|---------|-------------|---------|
| `yyyy-MM-dd` | ISO 8601 | 2024-01-15 |
| `dd/MM/yyyy` | Formato europeo | 15/01/2024 |
| `MM/dd/yyyy` | Formato americano | 01/15/2024 |
| `dddd, MMMM dd, yyyy` | Fecha larga | Monday, January 15, 2024 |
| `HH:mm:ss` | Hora 24 horas | 14:30:45 |
| `hh:mm:ss tt` | Hora 12 horas | 02:30:45 PM |
| `yyyy-MM-dd HH:mm:ss` | Fecha y hora completa | 2024-01-15 14:30:45 |

## ⏱️ TimeSpan para Duraciones

`TimeSpan` representa un intervalo de tiempo (duración).

```csharp
// Crear TimeSpan
TimeSpan duration1 = new TimeSpan(1, 2, 30, 45); // 1 día, 2 horas, 30 minutos, 45 segundos
TimeSpan duration2 = TimeSpan.FromDays(1);
TimeSpan duration3 = TimeSpan.FromHours(2.5);
TimeSpan duration4 = TimeSpan.FromMinutes(90);
TimeSpan duration5 = TimeSpan.FromSeconds(3600);

// Propiedades de TimeSpan
TimeSpan ts = new TimeSpan(1, 2, 30, 45, 500);
Console.WriteLine($"Días: {ts.Days}");
Console.WriteLine($"Horas: {ts.Hours}");
Console.WriteLine($"Minutos: {ts.Minutes}");
Console.WriteLine($"Segundos: {ts.Seconds}");
Console.WriteLine($"Milisegundos: {ts.Milliseconds}");
Console.WriteLine($"Total Horas: {ts.TotalHours}");
Console.WriteLine($"Total Minutos: {ts.TotalMinutes}");
```

## 🌍 DateTimeOffset para Zonas Horarias

`DateTimeOffset` incluye información de zona horaria, útil para aplicaciones que manejan múltiples zonas horarias.

```csharp
// DateTimeOffset con zona horaria
DateTimeOffset dto1 = DateTimeOffset.Now; // Hora local con offset
DateTimeOffset dto2 = DateTimeOffset.UtcNow; // UTC

// Crear con zona horaria específica
TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
DateTimeOffset dto3 = TimeZoneInfo.ConvertTime(DateTimeOffset.Now, tz);

// Convertir entre zonas horarias
DateTimeOffset utc = DateTimeOffset.UtcNow;
DateTimeOffset local = utc.ToLocalTime();
```

## 💡 Ejemplos Prácticos

### Ejemplo 1: Calcular Edad

```csharp
public static int CalculateAge(DateTime birthDate)
{
    DateTime today = DateTime.Today;
    int age = today.Year - birthDate.Year;
    
    // Ajustar si el cumpleaños aún no ha llegado este año
    if (birthDate.Date > today.AddYears(-age))
    {
        age--;
    }
    
    return age;
}

DateTime birthDate = new DateTime(1990, 5, 15);
int age = CalculateAge(birthDate);
Console.WriteLine($"Edad: {age} años");
```

### Ejemplo 2: Verificar si es Día Laboral

```csharp
public static bool IsWeekday(DateTime date)
{
    return date.DayOfWeek != DayOfWeek.Saturday && 
           date.DayOfWeek != DayOfWeek.Sunday;
}

DateTime date = DateTime.Now;
if (IsWeekday(date))
{
    Console.WriteLine("Es día laboral");
}
```

### Ejemplo 3: Obtener Primer y Último Día del Mes

```csharp
DateTime now = DateTime.Now;

// Primer día del mes
DateTime firstDay = new DateTime(now.Year, now.Month, 1);

// Último día del mes
DateTime lastDay = new DateTime(now.Year, now.Month, 
    DateTime.DaysInMonth(now.Year, now.Month));

Console.WriteLine($"Primer día: {firstDay:yyyy-MM-dd}");
Console.WriteLine($"Último día: {lastDay:yyyy-MM-dd}");
```

### Ejemplo 4: Calcular Días hasta Próximo Evento

```csharp
DateTime nextEvent = new DateTime(2024, 12, 25); // Navidad
DateTime today = DateTime.Today;

if (nextEvent < today)
{
    // Si el evento ya pasó este año, calcular para el próximo año
    nextEvent = nextEvent.AddYears(1);
}

TimeSpan timeUntilEvent = nextEvent - today;
Console.WriteLine($"Días hasta el evento: {timeUntilEvent.Days}");
```

## ⚠️ Errores Comunes a Evitar

### 1. Olvidar que DateTime es Inmutable

```csharp
// ❌ MAL: No capturar el valor de retorno
DateTime date = DateTime.Now;
date.AddDays(1); // No hace nada
Console.WriteLine(date); // Sigue siendo la fecha original

// ✅ BIEN: Capturar el valor de retorno
DateTime date = DateTime.Now;
date = date.AddDays(1); // Asignar el nuevo valor
Console.WriteLine(date); // Fecha con un día agregado
```

### 2. Usar DateTime.Now en lugar de DateTime.UtcNow

```csharp
// ⚠️ CUIDADO: DateTime.Now depende de la zona horaria del servidor
DateTime localTime = DateTime.Now; // Puede variar según servidor

// ✅ BIEN: Usar UTC para almacenar en base de datos
DateTime utcTime = DateTime.UtcNow; // Consistente
```

### 3. No Manejar Errores en Parse

```csharp
// ❌ MAL: Puede lanzar excepción
DateTime date = DateTime.Parse("invalid-date");

// ✅ BIEN: Usar TryParse
if (DateTime.TryParse("2024-01-15", out DateTime date))
{
    Console.WriteLine($"Fecha válida: {date}");
}
else
{
    Console.WriteLine("Fecha inválida");
}
```

### 4. Comparar Solo Fechas sin Considerar Hora

```csharp
// ⚠️ CUIDADO: Comparación incluye hora
DateTime date1 = new DateTime(2024, 1, 15, 10, 0, 0);
DateTime date2 = new DateTime(2024, 1, 15, 14, 0, 0);
bool areEqual = date1 == date2; // false (horas diferentes)

// ✅ BIEN: Comparar solo fechas
bool areSameDate = date1.Date == date2.Date; // true
```

## 📚 Recursos Adicionales

- [Microsoft Docs - DateTime](https://docs.microsoft.com/dotnet/api/system.datetime)
- [Microsoft Docs - TimeSpan](https://docs.microsoft.com/dotnet/api/system.timespan)
- [Microsoft Docs - DateTimeOffset](https://docs.microsoft.com/dotnet/api/system.datetimeoffset)
- [Microsoft Docs - Custom Date and Time Format Strings](https://docs.microsoft.com/dotnet/standard/base-types/custom-date-and-time-format-strings)

