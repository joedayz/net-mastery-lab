# Ejemplos Prácticos - Middleware Order in .NET Pipeline

Esta carpeta contiene ejemplos ejecutables que demuestran el orden correcto de middlewares en el pipeline de ASP.NET Core.

## Archivos

### `MiddlewareOrderExamples.cs`
Demostraciones prácticas del orden de middlewares:
- `DemonstrateCorrectOrder()` - Muestra el orden correcto de middlewares
- `DemonstratePipelineFlow()` - Explica el flujo del pipeline (request/response)
- `DemonstrateCommonMistakes()` - Errores comunes de orden y cómo evitarlos
- `DemonstrateCustomMiddlewares()` - Dónde colocar middlewares personalizados
- `DemonstrateOrderImportance()` - Por qué el orden es crítico
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 24-25 para los ejemplos de Middleware Order:
#   24. Middleware Order - Orden correcto
#   25. Middleware Order - Ejemplos prácticos
```

## Conceptos Clave

- **Orden Crítico**: El orden de los middlewares afecta el comportamiento de la aplicación
- **Request Flow**: Los requests pasan a través de los middlewares en orden
- **Response Flow**: Las respuestas regresan a través de los mismos middlewares en orden inverso
- **Authentication antes de Authorization**: La identidad debe establecerse primero

## Orden Recomendado

1. UseExceptionHandler
2. UseHsts
3. UseHttpsRedirection
4. UseStaticFiles
5. UseRouting
6. UseCors
7. UseAuthentication
8. UseAuthorization
9. UseResponseCompression
10. UseEndpoints

## Notas

- Los ejemplos muestran claramente por qué el orden es importante
- Se incluyen errores comunes y cómo evitarlos
- Se explica el flujo completo del pipeline
- Se muestra dónde colocar middlewares personalizados

