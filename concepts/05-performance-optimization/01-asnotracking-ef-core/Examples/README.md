# Ejemplos Prácticos - Use AsNoTracking() in Entity Framework Core

Esta carpeta contiene ejemplos ejecutables que demuestran cómo usar `AsNoTracking()` en Entity Framework Core para mejorar el rendimiento en consultas de solo lectura.

## Archivos

### `AsNoTrackingExamples.cs`
Demostraciones prácticas del uso de `AsNoTracking()`:
- `DemonstrateWithoutAsNoTracking()` - Muestra el problema de no usar `AsNoTracking()`
- `DemonstrateWithAsNoTracking()` - Muestra la solución usando `AsNoTracking()`
- `DemonstrateWithSelect()` - Demuestra cómo combinar con `Select()` para máximo rendimiento
- `DemonstrateUseCases()` - Casos de uso ideales (reportes, APIs, visualizaciones)
- `DemonstrateWhenNotToUse()` - Cuándo NO usar `AsNoTracking()`
- `DemonstrateGlobalConfiguration()` - Configuración global de `AsNoTracking()`
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 20-21 para los ejemplos de AsNoTracking():
#   20. AsNoTracking() EF Core - Comparación
#   21. AsNoTracking() EF Core - Ejemplos prácticos
```

## Conceptos Clave

- **Performance Boost**: Mejora el rendimiento eliminando el overhead del cambio tracker
- **Reduced Memory Usage**: Menor consumo de memoria al no rastrear entidades
- **Ideal for Reporting**: Perfecto para reportes y operaciones de solo lectura
- **Simple to Implement**: Fácil de implementar, solo agrega `.AsNoTracking()`

## Notas

- Los ejemplos muestran claramente la diferencia entre usar y no usar `AsNoTracking()`
- Se incluyen casos de uso específicos como reportes, APIs y visualizaciones
- Se explica cuándo NO usar `AsNoTracking()` (cuando necesitas modificar entidades)
- Se muestra cómo configurar `AsNoTracking()` globalmente en el DbContext

## Beneficios

1. **Performance Boost**: Elimina el overhead del cambio tracker
2. **Reduced Memory Usage**: Las entidades no rastreadas ocupan menos memoria
3. **Ideal for Reporting**: Perfecto para operaciones de solo lectura
4. **Simple to Implement**: Solo agrega `.AsNoTracking()` a tu consulta

