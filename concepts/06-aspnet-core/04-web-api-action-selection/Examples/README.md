# Ejemplos Prácticos - Web API Action Selection

Esta carpeta contiene ejemplos ejecutables que demuestran el proceso de selección de acciones en ASP.NET Core Web API y cómo evitar errores 404.

## Archivos

### `WebApiActionSelectionExamples.cs`
Demostraciones prácticas del proceso de selección:
- `DemonstrateSelectionProcess()` - Visión general del proceso completo
- `DemonstrateRouteMatching()` - Paso 1: Coincidencia de rutas
- `DemonstrateHttpMethodFiltering()` - Paso 2: Filtrado por método HTTP
- `DemonstrateParameterValidation()` - Paso 3: Validación de parámetros
- `DemonstrateHttpVerbValidation()` - Paso 4: Validación de verbo HTTP
- `DemonstrateNonActionCheck()` - Paso 5: Verificación de [NonAction]
- `DemonstrateCommon404Issues()` - Problemas comunes que causan 404
- `DemonstrateBestPractices()` - Mejores prácticas para evitar 404
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de Web API Action Selection
```

## Conceptos Clave

- **Route Matching**: Verificar acción en route data
- **HTTP Method Filtering**: Filtrar por método HTTP
- **Parameter Validation**: Validar parámetros de la solicitud
- **HTTP Verb Validation**: Validar que el verbo HTTP coincida
- **NonAction Check**: Excluir métodos marcados con [NonAction]

## Ejemplo Básico: Proceso Completo

```
Start
  ↓
1. ¿"action" en route data?
  ├─ Sí → Filtrar por nombre → Verificar verbo HTTP
  └─ No → Filtrar por método HTTP
  ↓
2. ¿Satisface parámetros?
  ├─ Sí → Continuar
  └─ No → 404
  ↓
3. ¿Atributo [NonAction]?
  ├─ Sí → 404
  └─ No → ✅ Acción Encontrada
```

## Problemas Comunes

- ❌ Ruta incorrecta: `/users?id=1` vs `/users/1`
- ❌ Método HTTP incorrecto: GET vs POST
- ❌ Parámetros faltantes o incorrectos
- ❌ [NonAction] en método de API

## Notas

- Los ejemplos muestran claramente cada paso del proceso
- Se incluyen problemas comunes y cómo evitarlos
- Se explica el flujo completo de selección de acciones

## Requisitos

- Conocimientos básicos de ASP.NET Core
- Comprensión de routing y HTTP methods

