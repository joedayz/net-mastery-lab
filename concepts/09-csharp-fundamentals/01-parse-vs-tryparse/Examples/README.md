# Ejemplos Prácticos - Understanding int.Parse() vs int.TryParse()

Esta carpeta contiene ejemplos ejecutables que demuestran las diferencias entre `int.Parse()` e `int.TryParse()` en C#.

## Archivos

### `ParseVsTryParseExamples.cs`
Demostraciones prácticas de ambos métodos:
- `DemonstrateIntParse()` - Comportamiento de int.Parse() con diferentes casos
- `DemonstrateIntTryParse()` - Comportamiento de int.TryParse() con diferentes casos
- `DemonstratePerformanceComparison()` - Comparación de rendimiento
- `DemonstrateUserInput()` - Manejo de entrada del usuario
- `DemonstrateDefaultValues()` - Uso con valores por defecto
- `DemonstrateOtherTypes()` - Otros tipos con TryParse
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 40-41 para los ejemplos de Parse vs TryParse:
#   40. int.Parse() vs int.TryParse() - Comparación
#   41. int.Parse() vs int.TryParse() - Ejemplos prácticos
```

## Conceptos Clave

- **int.Parse()**: Lanza excepciones (ArgumentNullException, FormatException, OverflowException)
- **int.TryParse()**: Retorna boolean, no lanza excepciones, más rápido
- **Uso Recomendado**: TryParse para entrada del usuario, Parse para datos confiables

## Ejemplo Básico

```csharp
// ❌ int.Parse() - Lanza excepciones
string val = null;
int value = int.Parse(val); // ArgumentNullException

// ✅ int.TryParse() - Sin excepciones
string val = null;
bool ifSuccess = int.TryParse(val, out result);
// ifSuccess = false | result = 0
```

## Notas

- Los ejemplos muestran claramente las diferencias entre ambos métodos
- Se incluyen casos de null, formato inválido y overflow
- Se demuestra la diferencia de rendimiento
- Se explican mejores prácticas para cada escenario

