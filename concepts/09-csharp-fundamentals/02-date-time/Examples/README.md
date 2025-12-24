# Ejemplos Prácticos - Date & Time

Esta carpeta contiene ejemplos ejecutables que demuestran el manejo de fechas y horas en C#.

## Archivos

### `DateTimeExamples.cs`
Demostraciones prácticas de Date & Time:
- `DemonstrateImmutability()` - Demuestra que DateTime es inmutable
- `DemonstrateGettingCurrentDateTime()` - Obtener fecha y hora actual
- `DemonstrateCreatingDateTime()` - Crear DateTime específicos
- `DemonstrateDateTimeOperations()` - Operaciones comunes (AddDays, etc.)
- `DemonstrateDateDifference()` - Calcular diferencias entre fechas
- `DemonstrateDateComparison()` - Comparar fechas
- `DemonstrateDateFormatting()` - Formateo de fechas
- `DemonstrateTimeSpan()` - TimeSpan para duraciones
- `DemonstratePracticalExamples()` - Ejemplos prácticos (edad, días laborales, etc.)
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Date & Time
```

## Conceptos Clave

- **DateTime es Inmutable**: Los métodos devuelven nuevas instancias, no modifican el original
- **DateTime.Now vs DateTime.UtcNow**: Usar UTC para almacenar en base de datos
- **Operaciones Comunes**: AddDays(), AddMonths(), AddYears(), etc.
- **TimeSpan**: Para representar duraciones e intervalos de tiempo
- **Formateo**: Métodos predefinidos y formato personalizado

## Ejemplo Básico

```csharp
// ⚠️ ERROR COMÚN: DateTime es inmutable
DateTime current = DateTime.Now;
current.AddDays(1); // Esto NO modifica 'current'

// ✅ CORRECTO: Capturar el valor de retorno
DateTime current = DateTime.Now;
DateTime tomorrow = current.AddDays(1); // Nueva instancia

// ✅ CORRECTO: Reasignar si quieres modificar la variable
DateTime current = DateTime.Now;
current = current.AddDays(1); // Reasignar
```

## Ejemplos Incluidos

### 1. Inmutabilidad de DateTime
```csharp
DateTime now = DateTime.Now;
DateTime tomorrow = now.AddDays(1); // Nueva instancia
```

### 2. Obtener Fecha y Hora Actual
```csharp
DateTime localTime = DateTime.Now;      // Hora local
DateTime utcTime = DateTime.UtcNow;    // Hora UTC (recomendado)
DateTime today = DateTime.Today;        // Solo fecha
```

### 3. Operaciones con Fechas
```csharp
DateTime now = DateTime.Now;
DateTime tomorrow = now.AddDays(1);
DateTime nextWeek = now.AddDays(7);
DateTime yesterday = now.AddDays(-1);
```

### 4. Calcular Diferencias
```csharp
DateTime start = new DateTime(2024, 1, 1);
DateTime end = new DateTime(2024, 1, 15);
TimeSpan difference = end - start;
int days = difference.Days;
```

### 5. Formateo
```csharp
DateTime now = DateTime.Now;
string isoFormat = now.ToString("yyyy-MM-dd");
string customFormat = now.ToString("dd/MM/yyyy HH:mm:ss");
```

## Notas

- Los ejemplos muestran claramente la inmutabilidad de DateTime
- Se demuestra el uso correcto de DateTime.UtcNow vs DateTime.Now
- Se incluyen ejemplos prácticos como calcular edad y días laborales
- Se explica el uso de TimeSpan para duraciones

