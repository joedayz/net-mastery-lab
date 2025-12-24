# Mejores Prácticas: String vs StringBuilder

## ✅ Reglas de Oro

### 1. Usar String para Pocas Concatenaciones

```csharp
// ✅ BIEN: String para 1-2 concatenaciones
string message = "Hello";
message += " World"; // Solo 2 objetos, String es suficiente

// ✅ BIEN: Interpolación de strings
string message = $"Hello {name}, you are {age} years old";
```

### 2. Usar StringBuilder para Múltiples Concatenaciones

```csharp
// ✅ BIEN: StringBuilder para loops o múltiples concatenaciones
StringBuilder sb = new StringBuilder();
for (int i = 0; i < 1000; i++)
{
    sb.Append($"Item {i}, ");
}
string result = sb.ToString();
```

### 3. Especificar Capacidad Inicial cuando Sea Posible

```csharp
// ✅ BIEN: Especificar capacidad inicial si la conoces
StringBuilder sb = new StringBuilder(estimatedLength);
// Evita reasignaciones del buffer interno

// Ejemplo: Si sabes que será ~1000 caracteres
StringBuilder sb = new StringBuilder(1000);
```

## ⚠️ Errores Comunes a Evitar

### 1. Usar String en Loops

```csharp
// ❌ MAL: String en loop - MUY INEFICIENTE
string result = "";
for (int i = 0; i < 1000; i++)
{
    result += $"Item {i}"; // O(n²) - crea nuevo objeto cada vez
}

// ✅ BIEN: StringBuilder en loop
StringBuilder sb = new StringBuilder();
for (int i = 0; i < 1000; i++)
{
    sb.Append($"Item {i}"); // O(n) - modifica el mismo objeto
}
string result = sb.ToString();
```

### 2. Usar StringBuilder para Operaciones Simples

```csharp
// ❌ MAL: StringBuilder innecesario
StringBuilder sb = new StringBuilder();
sb.Append("Hello");
sb.Append(" World");
string result = sb.ToString(); // Overhead innecesario

// ✅ BIEN: String es suficiente
string result = "Hello" + " World"; // Más simple y eficiente
```

### 3. No Especificar Capacidad Inicial

```csharp
// ⚠️ MEJORABLE: Sin capacidad inicial
StringBuilder sb = new StringBuilder(); // Capacidad por defecto: 16
// Puede requerir múltiples reasignaciones

// ✅ MEJOR: Especificar capacidad si la conoces
StringBuilder sb = new StringBuilder(1000); // Evita reasignaciones
```

### 4. Crear Nuevo StringBuilder en lugar de Reutilizar

```csharp
// ⚠️ MEJORABLE: Crear nuevo StringBuilder
StringBuilder sb = new StringBuilder();
// ... usar ...
sb = new StringBuilder(); // Nuevo objeto

// ✅ MEJOR: Reutilizar con Clear()
StringBuilder sb = new StringBuilder();
// ... usar ...
sb.Clear(); // Limpia el buffer, mantiene la capacidad
```

## 🎯 Casos de Uso Específicos

### 1. Construcción de Queries SQL

```csharp
// ✅ BIEN: StringBuilder para queries dinámicas
public string BuildQuery(bool includeActive, int? minAge)
{
    StringBuilder query = new StringBuilder("SELECT * FROM Users WHERE 1=1");
    
    if (includeActive)
    {
        query.Append(" AND IsActive = 1");
    }
    
    if (minAge.HasValue)
    {
        query.Append($" AND Age >= {minAge.Value}");
    }
    
    return query.ToString();
}
```

### 2. Construcción de HTML/XML

```csharp
// ✅ BIEN: StringBuilder para HTML dinámico
public string BuildHtmlList(List<string> items)
{
    StringBuilder html = new StringBuilder();
    html.Append("<ul>");
    
    foreach (var item in items)
    {
        html.Append($"<li>{item}</li>");
    }
    
    html.Append("</ul>");
    return html.ToString();
}
```

### 3. Logging y Mensajes

```csharp
// ✅ BIEN: StringBuilder para logs
public string BuildLogMessage(List<LogEntry> entries)
{
    StringBuilder log = new StringBuilder();
    
    foreach (var entry in entries)
    {
        log.AppendLine($"[{entry.Timestamp}] {entry.Level}: {entry.Message}");
    }
    
    return log.ToString();
}
```

### 4. Construcción de Paths de Archivos

```csharp
// ✅ BIEN: StringBuilder para paths complejos
public string BuildFilePath(string basePath, params string[] segments)
{
    StringBuilder path = new StringBuilder(basePath);
    
    foreach (var segment in segments)
    {
        path.Append(Path.DirectorySeparatorChar);
        path.Append(segment);
    }
    
    return path.ToString();
}
```

## 💡 Pro Tips

### 1. Usar AppendLine() para Líneas

```csharp
// ✅ BIEN: AppendLine agrega automáticamente \n
StringBuilder sb = new StringBuilder();
sb.AppendLine("Line 1");
sb.AppendLine("Line 2");
// Más legible que Append("Line 1\n")
```

### 2. Usar AppendFormat() para Formato Complejo

```csharp
// ✅ BIEN: AppendFormat para formateo complejo
StringBuilder sb = new StringBuilder();
sb.AppendFormat("User: {0}, Age: {1}, Active: {2}", name, age, isActive);
// Similar a string.Format pero más eficiente en loops
```

### 3. Reutilizar StringBuilder cuando Sea Posible

```csharp
// ✅ BIEN: Reutilizar StringBuilder en métodos que se llaman frecuentemente
private readonly StringBuilder _reusableBuilder = new StringBuilder(1000);

public string ProcessData(List<string> items)
{
    _reusableBuilder.Clear(); // Limpia pero mantiene capacidad
    foreach (var item in items)
    {
        _reusableBuilder.Append(item);
    }
    return _reusableBuilder.ToString();
}
```

### 4. Usar String Interpolation para Casos Simples

```csharp
// ✅ BIEN: Interpolación para casos simples
string message = $"Hello {name}, you are {age} years old";
// El compilador optimiza esto automáticamente

// ❌ MAL: StringBuilder innecesario
StringBuilder sb = new StringBuilder();
sb.Append("Hello ");
sb.Append(name);
sb.Append(", you are ");
sb.Append(age);
sb.Append(" years old");
string message = sb.ToString(); // Overhead innecesario
```

## 📊 Tabla de Decisión: Cuándo Usar Cada Uno

| Escenario | Recomendación | Razón |
|-----------|---------------|-------|
| 1-2 concatenaciones | `String` | Simple y rápido |
| 3+ concatenaciones | `StringBuilder` | Evita O(n²) |
| Concatenaciones en loop | `StringBuilder` | Múltiples operaciones |
| Strings literales | `String` | No cambian |
| Interpolación simple | `String` | Optimizado por compilador |
| Construcción dinámica | `StringBuilder` | Múltiples operaciones |
| Alto rendimiento | `StringBuilder` | Mejor eficiencia |

## 🚀 Optimizaciones Avanzadas

### 1. Capacidad Inicial Estimada

```csharp
// ✅ BIEN: Estimar capacidad inicial
int estimatedLength = items.Count * averageItemLength;
StringBuilder sb = new StringBuilder(estimatedLength);
// Reduce reasignaciones del buffer
```

### 2. Usar String.Join() para Arrays

```csharp
// ✅ BIEN: String.Join es más eficiente para arrays
string[] items = { "Item1", "Item2", "Item3" };
string result = string.Join(", ", items);
// Más eficiente que StringBuilder para arrays conocidos
```

### 3. Usar Span<char> para Operaciones de Alto Rendimiento (.NET Core 2.1+)

```csharp
// ✅ BIEN: Span<char> para operaciones críticas de rendimiento
ReadOnlySpan<char> span = "Hello World".AsSpan();
// Útil para operaciones sin asignaciones adicionales
```

## 📚 Recursos Adicionales

- [Microsoft Docs - String Class](https://docs.microsoft.com/dotnet/api/system.string)
- [Microsoft Docs - StringBuilder Class](https://docs.microsoft.com/dotnet/api/system.text.stringbuilder)
- [Microsoft Docs - String Interpolation](https://docs.microsoft.com/dotnet/csharp/language-reference/tokens/interpolated)
- [.NET Performance Tips](https://docs.microsoft.com/dotnet/fundamentals/performance/)

