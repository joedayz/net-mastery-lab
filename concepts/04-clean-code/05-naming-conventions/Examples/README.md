# Ejemplos Prácticos - Use the Proper Naming Convention

Esta carpeta contiene ejemplos ejecutables que demuestran las convenciones de nomenclatura correctas en C#.

## Archivos

### `NamingConventionsExamples.cs`
Demostraciones prácticas de las convenciones de nomenclatura:
- `DemonstrateClassAndNamespaceConventions()` - Convenciones para clases y namespaces
- `DemonstrateMethodConventions()` - Convenciones para métodos y argumentos
- `DemonstrateLocalVariableConventions()` - Convenciones para variables locales
- `DemonstrateFieldAndPropertyConventions()` - Convenciones para campos y propiedades
- `DemonstrateInterfaceConventions()` - Convenciones para interfaces
- `DemonstrateConstantsAndEnumsConventions()` - Convenciones para constantes y enums
- `DemonstrateBestPractices()` - Mejores prácticas adicionales
- `RunAllExamples()` - Ejecuta todos los ejemplos y muestra la tabla de referencia completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 28-29 para los ejemplos de Naming Conventions:
#   28. Naming Conventions - Tabla de referencia
#   29. Naming Conventions - Ejemplos prácticos
```

## Tabla de Referencia Rápida

| Tipo de Objeto | Notación | ¿Puede ser Plural? |
|----------------|----------|-------------------|
| Namespace name | `PascalCase` | ✅ Sí |
| Class name | `PascalCase` | ❌ No |
| Constructor name | `PascalCase` | ❌ No |
| Method name | `PascalCase` | ✅ Sí |
| Method arguments | `camelCase` | ✅ Sí |
| Local variables | `camelCase` | ✅ Sí |
| Constants name | `PascalCase` | ❌ No |
| Field name Public | `PascalCase` | ✅ Sí |
| Field name Private | `_camelCase` | ✅ Sí |
| Properties name | `PascalCase` | ✅ Sí |
| Interface | `IPascalCase` | ❌ No |
| Enum type name | `PascalCase` | ✅ Sí |

## Conceptos Clave

- **Consistencia**: Crea una apariencia consistente en el código
- **Comprensión Rápida**: Permite entender el código más rápidamente
- **Mantenibilidad**: Facilita copiar, cambiar y mantener el código
- **Mejores Prácticas**: Demuestra las mejores prácticas de C#

## Notas

- Los ejemplos muestran claramente las convenciones correctas e incorrectas
- Se incluye una tabla completa de referencia para todos los tipos de objetos
- Se explican las mejores prácticas adicionales como nombres descriptivos y evitar abreviaciones
- Se muestran ejemplos de código real que siguen las convenciones

