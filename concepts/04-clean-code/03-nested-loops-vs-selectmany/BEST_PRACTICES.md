# Mejores Prácticas: Flattening Nested Collections Using SelectMany

## ✅ Reglas de Oro

### 1. Usa SelectMany para aplanar colecciones anidadas

```csharp
// ❌ MAL: Bucles anidados
var departments = GetDepartments();
var employees = new List<Employee>();
foreach (var dept in departments)
{
    foreach (var employee in dept.Employees)
    {
        employees.Add(employee);
    }
}

// ✅ BIEN: SelectMany
var employees = GetDepartments()
    .SelectMany(dept => dept.Employees)
    .ToList();
```

### 2. Combina SelectMany con otros operadores LINQ

```csharp
// ✅ Combinar con Where, Select, OrderBy, etc.
var activeEmployeeNames = GetDepartments()
    .SelectMany(dept => dept.Employees)
    .Where(emp => emp.IsActive)
    .Select(emp => emp.Name)
    .OrderBy(name => name)
    .ToList();
```

### 3. Usa SelectMany para múltiples niveles de anidación

```csharp
// ✅ Aplanar múltiples niveles
var allItems = GetCompanies()
    .SelectMany(company => company.Orders)
    .SelectMany(order => order.OrderItems)
    .ToList();
```

## ⚠️ Errores Comunes a Evitar

### 1. Confundir Select con SelectMany

```csharp
// ❌ MAL: Select devuelve IEnumerable<IEnumerable<T>>
var employeeLists = departments.Select(dept => dept.Employees);
// Esto NO es lo que quieres si necesitas una lista plana

// ✅ BIEN: SelectMany aplana la colección
var employees = departments.SelectMany(dept => dept.Employees);
```

### 2. Usar bucles anidados cuando SelectMany es más claro

```csharp
// ❌ MAL: Bucles anidados innecesarios
var result = new List<Item>();
foreach (var parent in parents)
{
    foreach (var child in parent.Children)
    {
        result.Add(child);
    }
}

// ✅ BIEN: SelectMany es más claro
var result = parents
    .SelectMany(parent => parent.Children)
    .ToList();
```

### 3. Olvidar ToList() cuando necesitas una lista materializada

```csharp
// ⚠️ Si necesitas una List<T>, no olvides ToList()
var employees = GetDepartments()
    .SelectMany(dept => dept.Employees)
    .ToList(); // Importante si necesitas List<T>
```

## 🎯 Casos de Uso Específicos

### 1. Aplanar Departamentos y Empleados

```csharp
public class DepartmentService
{
    public IEnumerable<Employee> GetAllEmployees()
    {
        return _departments
            .SelectMany(dept => dept.Employees);
    }
}
```

### 2. Aplanar con Filtrado

```csharp
public IEnumerable<Employee> GetActiveEmployees()
{
    return GetDepartments()
        .SelectMany(dept => dept.Employees)
        .Where(emp => emp.IsActive);
}
```

### 3. Aplanar Múltiples Niveles

```csharp
public IEnumerable<OrderItem> GetAllOrderItems()
{
    return GetCompanies()
        .SelectMany(company => company.Orders)
        .SelectMany(order => order.OrderItems);
}
```

### 4. SelectMany con Transformación

```csharp
public IEnumerable<string> GetAllEmployeeNames()
{
    return GetDepartments()
        .SelectMany(dept => dept.Employees)
        .Select(emp => emp.Name);
}
```

### 5. SelectMany con Índice

```csharp
public IEnumerable<EmployeeWithDepartment> GetEmployeesWithDepartmentInfo()
{
    return GetDepartments()
        .SelectMany((dept, index) => dept.Employees.Select(emp => new EmployeeWithDepartment
        {
            Employee = emp,
            DepartmentIndex = index,
            DepartmentName = dept.Name
        }));
}
```

## 📊 Comparación de Enfoques

| Aspecto | Bucles Anidados | SelectMany |
|---------|----------------|------------|
| **Legibilidad** | ❌ Menos legible | ✅ Más legible |
| **Concisión** | ❌ Verboso | ✅ Conciso |
| **Funcional** | ❌ Imperativo | ✅ Declarativo |
| **Composable** | ❌ Difícil | ✅ Fácil |
| **Propenso a errores** | ❌ Más propenso | ✅ Menos propenso |

## 🚀 Tips Avanzados

### 1. SelectMany con Colecciones Vacías

```csharp
// ✅ SelectMany maneja automáticamente colecciones vacías
var employees = GetDepartments()
    .SelectMany(dept => dept.Employees ?? Enumerable.Empty<Employee>())
    .ToList();
```

### 2. SelectMany con Proyección

```csharp
// ✅ Puedes proyectar mientras aplanas
var employeeInfo = GetDepartments()
    .SelectMany(dept => dept.Employees, (dept, emp) => new
    {
        EmployeeName = emp.Name,
        DepartmentName = dept.Name
    })
    .ToList();
```

### 3. SelectMany con Agrupación

```csharp
// ✅ Combinar SelectMany con GroupBy
var employeesByDepartment = GetDepartments()
    .SelectMany(dept => dept.Employees.Select(emp => new
    {
        Employee = emp,
        Department = dept.Name
    }))
    .GroupBy(x => x.Department)
    .ToList();
```

## 📚 Recursos Adicionales

- [Microsoft Docs - SelectMany](https://docs.microsoft.com/dotnet/api/system.linq.enumerable.selectmany)
- [LINQ Query Syntax](https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/linq/)
- [Clean Code by Robert C. Martin](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)

