# Ejemplos Prácticos - Switch Expressions en C# 8

Esta carpeta contiene ejemplos ejecutables que demuestran Switch Expressions en C# 8.

## Archivos

### `SwitchExpressionsExamples.cs`
Demostraciones prácticas de Switch Expressions:
- `DemonstrateComparison()` - Comparación Switch Statement vs Switch Expression
- `DemonstratePerfectUseCases()` - Casos de uso perfectos (Plans, Status Codes, Roles, Enums, API Responses)
- `DemonstrateWithPatternMatching()` - Switch Expressions con Pattern Matching
- `DemonstrateAdvancedUseCases()` - Casos de uso avanzados (Tuples, When Clauses, Records)
- `DemonstrateExpressionBodiedMembers()` - Expression-bodied members con Switch Expressions
- `DemonstrateBestPractices()` - Mejores prácticas
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Switch Expressions
```

## Conceptos Clave

- **Switch Expression**: Sintaxis más concisa que switch statements
- **Expression-bodied Members**: Compatible con sintaxis `=>`
- **Pattern Matching**: Se combina perfectamente con patterns
- **Discard Pattern**: `_` reemplaza `default`
- **No Side Effects**: Expressions deben ser puras
- **Perfect Use Cases**: Plans, Status Codes, Roles, Enums, API Responses

## Ejemplo Básico: Comparación

```csharp
// ❌ ANTES: Switch Statement
string GetSubscriptionFeatures(string plan)
{
    switch (plan)
    {
        case "Free":
            return "Basic Access";
        case "Pro":
            return "Premium Access";
        default:
            return "Unknown Plan";
    }
}

// ✅ DESPUÉS: Switch Expression
string GetSubscriptionFeatures(string plan) => plan switch
{
    "Free" => "Basic Access",
    "Pro" => "Premium Access",
    _ => "Unknown Plan"
};
```

## Ejemplo: Perfect Use Cases

### Subscription Plans
```csharp
string GetPlanFeatures(string planCode) => planCode switch
{
    "Free" => "Basic Access",
    "Pro" => "Premium Access + Analytics",
    "Enterprise" => "All Features + Priority Support",
    _ => "Unknown Plan"
};
```

### Status Codes
```csharp
string GetStatusMessage(int statusCode) => statusCode switch
{
    200 => "OK",
    404 => "Not Found",
    500 => "Internal Server Error",
    _ => "Unknown Status"
};
```

## Ejemplo: Con Pattern Matching

```csharp
string GetGrade(int score) => score switch
{
    >= 90 => "A",
    >= 80 => "B",
    >= 70 => "C",
    >= 60 => "D",
    _ => "F"
};
```

## Notas

- Los ejemplos muestran claramente la diferencia entre switch statements y switch expressions
- Se incluyen todos los casos de uso perfectos mencionados
- Se demuestra la combinación con Pattern Matching
- Se explican las mejores prácticas y cuándo usar cada uno

## Requisitos

- Conocimientos básicos de C#
- Comprensión de switch statements tradicionales
- Conocimientos básicos de Pattern Matching (opcional pero recomendado)

