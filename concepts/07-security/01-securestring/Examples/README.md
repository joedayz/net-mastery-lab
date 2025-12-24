# Ejemplos Prácticos - Keep Your Data Safe with SecureString

Esta carpeta contiene ejemplos ejecutables que demuestran cómo usar `SecureString` para proteger información sensible como contraseñas en memoria.

## Archivos

### `SecureStringExamples.cs`
Demostraciones prácticas de ambos enfoques:
- `DemonstrateStringProblem()` - Muestra el problema de usar strings normales
- `DemonstrateBasicSecureString()` - Muestra cómo crear un SecureString básico
- `DemonstrateSecureStringWithUsing()` - Uso con using statement para limpieza automática
- `DemonstrateSecureStringFromInput()` - Crear SecureString desde entrada del usuario
- `DemonstrateSecureStringToString()` - Conversión a String (cuando sea necesario)
- `DemonstrateBestPractices()` - Mejores prácticas
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 32-33 para los ejemplos de SecureString:
#   32. SecureString - Comparación
#   33. SecureString - Ejemplos prácticos
```

## Conceptos Clave

- **Encrypts Sensitive Data**: Encripta datos sensibles en memoria, reduciendo riesgo de exposición
- **Automatically Clears**: Limpia automáticamente el valor cuando ya no se necesita
- **Prevents Memory Dumps**: Previene que datos sensibles sean fácilmente recuperados mediante memory dumps

## Ejemplo Básico

```csharp
using System.Security;

var securePassword = new SecureString();
foreach (char c in "P@ssword!")
{
    securePassword.AppendChar(c);
}
securePassword.MakeReadOnly();
// SecureString está ahora inmutable y almacenado de forma segura en memoria
```

## Notas

- Los ejemplos muestran claramente la diferencia entre strings normales y SecureString
- Se incluyen mejores prácticas como usar `MakeReadOnly()` y `using` statement
- Se explica cómo convertir SecureString a String cuando sea necesario
- Se mencionan las limitaciones en .NET Core/.NET 5+

