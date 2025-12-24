# Mejores Prácticas: Date & Time

## ✅ Reglas de Oro

### 1. Siempre Capturar el Valor de Retorno de Métodos DateTime

```csharp
// ❌ MAL: DateTime es inmutable, esto no funciona
DateTime current = DateTime.Now;
current.AddDays(1); // No modifica 'current'

// ✅ BIEN: Capturar el valor de retorno
DateTime current = DateTime.Now;
DateTime tomorrow = current.AddDays(1); // Nueva instancia

// ✅ BIEN: Reasignar si quieres modificar la variable
DateTime current = DateTime.Now;
current = current.AddDays(1); // Reasignar
```

### 2. Usar DateTime.UtcNow para Almacenar en Base de Datos

```csharp
// ⚠️ CUIDADO: DateTime.Now depende de la zona horaria del servidor
DateTime localTime = DateTime.Now; // Puede variar según servidor

// ✅ BIEN: Usar UTC para almacenar en base de datos
DateTime utcTime = DateTime.UtcNow; // Consistente

// Convertir a local cuando muestres al usuario
DateTime localForDisplay = utcTime.ToLocalTime();
```

### 3. Usar TryParse en lugar de Parse

```csharp
// ❌ MAL: Puede lanzar excepción
DateTime date = DateTime.Parse("invalid-date");

// ✅ BIEN: Usar TryParse para manejo seguro
if (DateTime.TryParse("2024-01-15", out DateTime date))
{
    Console.WriteLine($"Fecha válida: {date}");
}
else
{
    Console.WriteLine("Fecha inválida");
}
```

### 4. Comparar Solo Fechas cuando Sea Necesario

```csharp
// ⚠️ CUIDADO: Comparación incluye hora
DateTime date1 = new DateTime(2024, 1, 15, 10, 0, 0);
DateTime date2 = new DateTime(2024, 1, 15, 14, 0, 0);
bool areEqual = date1 == date2; // false (horas diferentes)

// ✅ BIEN: Comparar solo fechas
bool areSameDate = date1.Date == date2.Date; // true
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

### 2. Usar DateTime.Now en lugar de DateTime.UtcNow para BD

```csharp
// ❌ MAL: Depende de la zona horaria del servidor
public void SaveOrder(Order order)
{
    order.CreatedAt = DateTime.Now; // Puede variar según servidor
    _dbContext.Orders.Add(order);
}

// ✅ BIEN: Usar UTC para consistencia
public void SaveOrder(Order order)
{
    order.CreatedAt = DateTime.UtcNow; // Consistente
    _dbContext.Orders.Add(order);
}
```

### 3. No Manejar Errores en Parse

```csharp
// ❌ MAL: Puede lanzar excepción
public DateTime ParseDate(string dateString)
{
    return DateTime.Parse(dateString); // Puede fallar
}

// ✅ BIEN: Usar TryParse
public bool TryParseDate(string dateString, out DateTime date)
{
    return DateTime.TryParse(dateString, out date);
}
```

### 4. Comparar Fechas sin Considerar Hora

```csharp
// ❌ MAL: Comparación incluye hora
DateTime start = new DateTime(2024, 1, 15, 10, 0, 0);
DateTime end = new DateTime(2024, 1, 15, 14, 0, 0);
if (start == end) // false - horas diferentes
{
    // ...
}

// ✅ BIEN: Comparar solo fechas
if (start.Date == end.Date) // true - misma fecha
{
    // ...
}
```

## 🎯 Casos de Uso Específicos

### 1. Calcular Edad Correctamente

```csharp
// ✅ BIEN: Calcular edad considerando si el cumpleaños ya pasó
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
```

### 2. Trabajar con Zonas Horarias

```csharp
// ✅ BIEN: Usar DateTimeOffset para zonas horarias
DateTimeOffset utcNow = DateTimeOffset.UtcNow;
DateTimeOffset localTime = utcNow.ToLocalTime();

// Convertir entre zonas horarias
TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
DateTimeOffset easternTime = TimeZoneInfo.ConvertTime(utcNow, tz);
```

### 3. Formatear Fechas para Diferentes Culturas

```csharp
// ✅ BIEN: Usar CultureInfo para formateo específico
DateTime date = DateTime.Now;
CultureInfo enUS = new CultureInfo("en-US");
CultureInfo esES = new CultureInfo("es-ES");

string usFormat = date.ToString("d", enUS); // "1/15/2024"
string esFormat = date.ToString("d", esES); // "15/1/2024"
```

### 4. Calcular Días Laborables

```csharp
// ✅ BIEN: Calcular días laborables excluyendo fines de semana
public static int CalculateBusinessDays(DateTime start, DateTime end)
{
    int businessDays = 0;
    DateTime current = start.Date;
    
    while (current <= end.Date)
    {
        if (current.DayOfWeek != DayOfWeek.Saturday && 
            current.DayOfWeek != DayOfWeek.Sunday)
        {
            businessDays++;
        }
        current = current.AddDays(1);
    }
    
    return businessDays;
}
```

### 5. Validar Rango de Fechas

```csharp
// ✅ BIEN: Validar que una fecha esté en un rango válido
public static bool IsDateInRange(DateTime date, DateTime start, DateTime end)
{
    return date >= start && date <= end;
}

// Con validación de null
public static bool IsDateInRange(DateTime? date, DateTime start, DateTime end)
{
    return date.HasValue && date.Value >= start && date.Value <= end;
}
```

## 🚀 Tips Avanzados

### 1. Usar DateTimeOffset para Aplicaciones Multi-Zona Horaria

```csharp
// ✅ BIEN: DateTimeOffset incluye información de zona horaria
DateTimeOffset dto = DateTimeOffset.UtcNow;
Console.WriteLine($"UTC: {dto:yyyy-MM-dd HH:mm:ss zzz}");
Console.WriteLine($"Local: {dto.ToLocalTime():yyyy-MM-dd HH:mm:ss zzz}");
```

### 2. Usar TimeSpan para Operaciones de Duración

```csharp
// ✅ BIEN: TimeSpan para representar duraciones
TimeSpan duration = TimeSpan.FromHours(2.5);
DateTime start = DateTime.Now;
DateTime end = start + duration;

// Calcular diferencia
TimeSpan difference = end - start;
Console.WriteLine($"Duración: {difference.TotalHours} horas");
```

### 3. Usar DateOnly y TimeOnly (.NET 6+)

```csharp
// ✅ BIEN: DateOnly y TimeOnly para mayor claridad (.NET 6+)
DateOnly date = DateOnly.FromDateTime(DateTime.Now);
TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);

Console.WriteLine($"Fecha: {date:yyyy-MM-dd}");
Console.WriteLine($"Hora: {time:HH:mm:ss}");
```

### 4. Cachear DateTime.Now en Llamadas Múltiples

```csharp
// ⚠️ CUIDADO: DateTime.Now puede variar entre llamadas
DateTime time1 = DateTime.Now;
// ... código que toma tiempo ...
DateTime time2 = DateTime.Now; // Puede ser diferente

// ✅ BIEN: Cachear si necesitas la misma fecha/hora
DateTime now = DateTime.Now;
DateTime time1 = now;
// ... código que toma tiempo ...
DateTime time2 = now; // Misma fecha/hora
```

### 5. Usar Formato ISO 8601 para Intercambio de Datos

```csharp
// ✅ BIEN: ISO 8601 para APIs y serialización
DateTime date = DateTime.UtcNow;
string isoFormat = date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
Console.WriteLine(isoFormat); // "2024-01-15T14:30:45.123Z"

// Parsear desde ISO 8601
DateTime parsed = DateTime.Parse(isoFormat, null, System.Globalization.DateTimeStyles.RoundtripKind);
```

## 📊 Comparación: DateTime vs DateTimeOffset

| Característica | DateTime | DateTimeOffset |
|----------------|----------|----------------|
| **Zona Horaria** | No incluye | Incluye offset |
| **Uso Recomendado** | Aplicaciones locales | Aplicaciones multi-zona |
| **Almacenamiento BD** | UTC (DateTime.UtcNow) | UTC (DateTimeOffset.UtcNow) |
| **Precisión** | Menor | Mayor |

## 📚 Recursos Adicionales

- [Microsoft Docs - DateTime](https://docs.microsoft.com/dotnet/api/system.datetime)
- [Microsoft Docs - TimeSpan](https://docs.microsoft.com/dotnet/api/system.timespan)
- [Microsoft Docs - DateTimeOffset](https://docs.microsoft.com/dotnet/api/system.datetimeoffset)
- [Microsoft Docs - Custom Date and Time Format Strings](https://docs.microsoft.com/dotnet/standard/base-types/custom-date-and-time-format-strings)
- [Microsoft Docs - DateOnly and TimeOnly](https://docs.microsoft.com/dotnet/api/system.dateonly)

