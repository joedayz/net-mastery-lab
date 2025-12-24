# Ejemplos Prácticos - Optimización de Consultas SQL

Esta carpeta contiene ejemplos ejecutables que demuestran cómo optimizar consultas SQL para obtener el máximo rendimiento.

## Archivos

### `SqlQueryOptimizationExamples.cs`
Demostraciones prácticas de optimización SQL:
- `DemonstrateWhyOptimize()` - Por qué optimizar consultas SQL
- `DemonstrateKeyFactors()` - Factores clave que afectan el rendimiento
- `DemonstrateBestPractices()` - Mejores prácticas de optimización
- `DemonstrateOptimizedQueries()` - Ejemplos de consultas optimizadas
- `DemonstrateComparison()` - Comparación antes vs después
- `RunAllExamples()` - Ejecuta todos los ejemplos para una visión completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones correspondientes para los ejemplos de SQL Optimization
```

## Conceptos Clave

- **Índices**: Mejoran velocidad de búsqueda pero pueden ralentizar escrituras
- **JOINs vs Subqueries**: JOINs generalmente más eficientes
- **SELECT Específico**: Evitar SELECT * cuando sea posible
- **Paginación**: Esencial para grandes datasets
- **Tipos de Datos**: Elegir tipos correctos mejora rendimiento
- **Planes de Ejecución**: Analizar regularmente para detectar problemas

## Ejemplo Básico: Consulta Optimizada

```sql
-- ❌ MAL: No optimizada
SELECT * FROM Orders WHERE OrderDate > '2024-01-01';

-- ✅ BIEN: Optimizada
SELECT OrderId, OrderDate, Total 
FROM Orders 
WHERE OrderDate >= '2024-01-01'
ORDER BY OrderDate DESC
OFFSET 0 ROWS FETCH NEXT 20 ROWS ONLY;
```

## Notas

- Los ejemplos muestran claramente las diferencias entre consultas optimizadas y no optimizadas
- Se incluyen mejores prácticas y errores comunes a evitar
- Se explica el impacto de cada optimización

## Requisitos

- Conocimientos básicos de SQL
- Comprensión de índices y planes de ejecución

