# Mejores Prácticas: Optimización de Consultas SQL

## ✅ Reglas de Oro

### 1. Usar Índices Estratégicamente

```sql
-- ✅ BIEN: Índice en columna frecuentemente consultada
CREATE INDEX IX_Users_Email ON Users(Email);

-- ✅ BIEN: Índice compuesto para consultas complejas
CREATE INDEX IX_Orders_CustomerId_OrderDate_Status 
ON Orders(CustomerId, OrderDate, Status);

-- ❌ MAL: Demasiados índices en una tabla
-- Cada INSERT/UPDATE/DELETE debe actualizar todos los índices
```

**Cuándo Crear Índices:**
- ✅ Columnas usadas en WHERE frecuentemente
- ✅ Columnas usadas en JOINs
- ✅ Columnas usadas en ORDER BY
- ❌ Evitar en tablas pequeñas (< 1000 filas)
- ❌ Evitar en columnas con baja selectividad

### 2. SELECT Solo Columnas Necesarias

```sql
-- ❌ MAL: SELECT * trae todas las columnas
SELECT * FROM Users WHERE IsActive = 1;

-- ✅ BIEN: Solo columnas necesarias
SELECT Id, Name, Email FROM Users WHERE IsActive = 1;
```

**Beneficios:**
- ✅ Menos datos transferidos
- ✅ Menos uso de memoria
- ✅ Consultas más rápidas

### 3. Usar Paginación para Grandes Datasets

```sql
-- ❌ MAL: Sin paginación - carga todos los registros
SELECT * FROM Orders;

-- ✅ BIEN: Con paginación
SELECT * FROM Orders 
ORDER BY OrderDate DESC
OFFSET 0 ROWS FETCH NEXT 20 ROWS ONLY;
```

### 4. Optimizar JOINs

```sql
-- ✅ BIEN: Usar columnas indexadas en JOINs
SELECT u.Name, o.OrderDate, o.Total
FROM Users u
INNER JOIN Orders o ON u.Id = o.CustomerId  -- Ambos indexados
WHERE u.IsActive = 1;

-- ❌ MAL: JOIN sin índices
SELECT u.Name, o.OrderDate
FROM Users u
INNER JOIN Orders o ON u.Email = o.CustomerEmail;  -- Sin índices

-- ✅ BIEN: Reemplazar subconsulta con JOIN
-- Antes: Subconsulta correlacionada
SELECT Name FROM Users u 
WHERE EXISTS (SELECT 1 FROM Orders o WHERE o.CustomerId = u.Id);

-- Después: JOIN más eficiente
SELECT DISTINCT u.Name 
FROM Users u
INNER JOIN Orders o ON u.Id = o.CustomerId;
```

### 5. Usar WHERE en lugar de HAVING para Filtrar

```sql
-- ✅ BIEN: WHERE filtra antes de agrupar
SELECT CustomerId, SUM(Total) AS TotalOrders
FROM Orders
WHERE OrderDate >= '2024-01-01'  -- Filtra antes de GROUP BY
GROUP BY CustomerId;

-- ❌ MAL: HAVING filtra después de agrupar (menos eficiente)
SELECT CustomerId, SUM(Total) AS TotalOrders
FROM Orders
GROUP BY CustomerId
HAVING OrderDate >= '2024-01-01';  -- Filtra después de agrupar
```

### 6. Elegir Tipos de Datos Correctos

```sql
-- ❌ MAL: Tipos de datos incorrectos
CREATE TABLE Products (
    ProductId VARCHAR(50),           -- Debería ser INT
    Price VARCHAR(20),               -- Debería ser DECIMAL
    CreatedDate VARCHAR(50)          -- Debería ser DATETIME
);

-- ✅ BIEN: Tipos de datos apropiados
CREATE TABLE Products (
    ProductId INT PRIMARY KEY,
    Price DECIMAL(10, 2),
    CreatedDate DATETIME2 DEFAULT GETDATE()
);
```

## ⚠️ Errores Comunes a Evitar

### 1. SELECT * Sin Necesidad

```sql
-- ❌ MAL: SELECT * trae todas las columnas
SELECT * FROM Users WHERE Email = 'user@example.com';

-- ✅ BIEN: Solo columnas necesarias
SELECT Id, Name, Email FROM Users WHERE Email = 'user@example.com';
```

### 2. Demasiados Índices

```sql
-- ❌ MAL: Demasiados índices ralentizan escrituras
CREATE INDEX IX_Users_Email ON Users(Email);
CREATE INDEX IX_Users_Name ON Users(Name);
CREATE INDEX IX_Users_Phone ON Users(Phone);
CREATE INDEX IX_Users_Address ON Users(Address);
-- ... muchos más

-- ✅ BIEN: Índices estratégicos solo en columnas críticas
CREATE INDEX IX_Users_Email ON Users(Email);  -- Usado en WHERE frecuentemente
CREATE INDEX IX_Users_Name ON Users(Name);    -- Usado en búsquedas
```

### 3. Subconsultas Correlacionadas Innecesarias

```sql
-- ❌ MAL: Subconsulta correlacionada (lenta)
SELECT u.Name, 
       (SELECT COUNT(*) FROM Orders o WHERE o.CustomerId = u.Id) AS OrderCount
FROM Users u;

-- ✅ BIEN: JOIN con GROUP BY (más eficiente)
SELECT u.Name, COUNT(o.OrderId) AS OrderCount
FROM Users u
LEFT JOIN Orders o ON u.Id = o.CustomerId
GROUP BY u.Id, u.Name;
```

### 4. No Analizar Planes de Ejecución

```sql
-- ❌ MAL: No analizar plan de ejecución
SELECT * FROM Users WHERE Email = 'user@example.com';

-- ✅ BIEN: Analizar plan de ejecución
SET STATISTICS IO ON;
SET STATISTICS TIME ON;
SELECT * FROM Users WHERE Email = 'user@example.com';
SET STATISTICS IO OFF;
SET STATISTICS TIME OFF;
```

## 🎯 Casos de Uso Específicos

### 1. Consulta con Múltiples Filtros

```sql
-- ✅ BIEN: Índice compuesto para múltiples filtros
CREATE INDEX IX_Orders_CustomerId_Status_OrderDate 
ON Orders(CustomerId, Status, OrderDate);

SELECT OrderId, OrderDate, Total
FROM Orders
WHERE CustomerId = 123
    AND Status = 'Completed'
    AND OrderDate >= '2024-01-01';
```

### 2. Búsqueda de Texto

```sql
-- ✅ BIEN: Índice de texto completo para búsquedas
CREATE FULLTEXT INDEX ON Products(ProductName, Description);

SELECT * FROM Products
WHERE CONTAINS(ProductName, 'laptop');
```

### 3. Consultas con Agregaciones

```sql
-- ✅ BIEN: Índice en columnas de agrupación
CREATE INDEX IX_Orders_CustomerId_OrderDate 
ON Orders(CustomerId, OrderDate);

SELECT CustomerId, COUNT(*) AS OrderCount, SUM(Total) AS TotalSpent
FROM Orders
WHERE OrderDate >= '2024-01-01'
GROUP BY CustomerId;
```

## 💡 Pro Tips

### 1. Monitorear Consultas Lentas

```sql
-- SQL Server: Ver consultas más lentas
SELECT TOP 10
    qs.execution_count,
    qs.total_elapsed_time / qs.execution_count AS avg_elapsed_time,
    SUBSTRING(qt.text, (qs.statement_start_offset/2)+1,
        ((CASE qs.statement_end_offset
            WHEN -1 THEN DATALENGTH(qt.text)
            ELSE qs.statement_end_offset
        END - qs.statement_start_offset)/2)+1) AS query_text
FROM sys.dm_exec_query_stats qs
CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) qt
ORDER BY avg_elapsed_time DESC;
```

### 2. Mantener Estadísticas Actualizadas

```sql
-- ✅ BIEN: Actualizar estadísticas regularmente
UPDATE STATISTICS Orders;
UPDATE STATISTICS Users;
```

### 3. Reconstruir Índices Periódicamente

```sql
-- ✅ BIEN: Reconstruir índices fragmentados
ALTER INDEX ALL ON Orders REBUILD;

-- ✅ BIEN: Reorganizar (menos intensivo)
ALTER INDEX ALL ON Orders REORGANIZE;
```

## 📊 Tabla de Decisión: Qué Hacer

| Escenario | Acción Recomendada | Razón |
|-----------|-------------------|-------|
| Consulta lenta en WHERE | Crear índice | Mejora búsqueda |
| SELECT * frecuente | Especificar columnas | Reduce transferencia |
| Grandes datasets | Usar paginación | Limita resultados |
| Subconsulta correlacionada | Convertir a JOIN | Más eficiente |
| HAVING para filtrar | Usar WHERE | Filtra antes de agrupar |
| VARCHAR para números | Cambiar a INT/DECIMAL | Comparaciones más rápidas |
| Table Scan en plan | Crear índice | Evita escaneo completo |
| Índices fragmentados | Reconstruir | Mejora rendimiento |

## 📚 Recursos Adicionales

- [Microsoft Docs - Query Tuning](https://docs.microsoft.com/sql/relational-databases/performance/query-tuning)
- [PostgreSQL - EXPLAIN](https://www.postgresql.org/docs/current/sql-explain.html)
- [MySQL - EXPLAIN](https://dev.mysql.com/doc/refman/8.0/en/explain.html)

