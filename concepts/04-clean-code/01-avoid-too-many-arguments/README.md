# Avoid Too Many Arguments In Functions 💎

## Introducción

Es una buena práctica limitar el número de argumentos de función a dos. Si una función requiere más que eso, puede ser una señal de que la función está haciendo demasiado y debería ser refactorizada.

## 📖 El Problema: Demasiados Argumentos ❌

Cuando una función tiene muchos parámetros individuales, se vuelve difícil de leer, mantener y probar.

```csharp
// ❌ MAL: Demasiados argumentos individuales
public Result GraduateStudent(
    string name,
    DateOnly birthDate,
    string major,
    int score,
    int totalCourses)
{
    // graduates a student
}
```

**Problemas:**
- **Difícil de leer**: La firma de la función es muy larga
- **Difícil de mantener**: Agregar o modificar parámetros requiere cambios en múltiples lugares
- **Difícil de probar**: Necesitas pasar muchos argumentos en cada test
- **Propenso a errores**: Es fácil pasar argumentos en el orden incorrecto
- **Violación del principio de responsabilidad única**: La función puede estar haciendo demasiado

## ✅ La Solución: Encapsular en Objetos ✨

Podemos refactorizar la función para usar un **struct** o **clase** para encapsular parámetros relacionados en lugar de pasarlos como argumentos individuales.

```csharp
// ✅ BIEN: Usar un objeto para encapsular datos relacionados
public Result GraduateStudent(Student student)
{
    // graduates a student
}
```

**Ventajas:**
- **Mejor legibilidad**: La firma de la función es más clara y concisa
- **Más fácil de mantener**: Los cambios se hacen en un solo lugar (la clase/struct)
- **Más fácil de probar**: Solo necesitas crear un objeto
- **Menos propenso a errores**: No hay riesgo de pasar argumentos en orden incorrecto
- **Más flexible**: Puedes agregar nuevos campos sin cambiar la firma de la función

## 🔥 Ventajas de Evitar Demasiados Argumentos

### ◾ Mejor Legibilidad del Código

El código es más fácil de leer cuando los parámetros relacionados están agrupados en un objeto con un nombre significativo.

```csharp
// ❌ Difícil de leer
ProcessOrder("John", "Doe", "john@email.com", "123 Main St", "New York", "NY", "10001", DateTime.Now, "Credit Card", "1234-5678-9012-3456");

// ✅ Fácil de leer
ProcessOrder(new Order 
{ 
    Customer = new Customer { FirstName = "John", LastName = "Doe", Email = "john@email.com" },
    ShippingAddress = new Address { Street = "123 Main St", City = "New York", State = "NY", ZipCode = "10001" },
    PaymentMethod = new PaymentMethod { Type = "Credit Card", CardNumber = "1234-5678-9012-3456" }
});
```

### ◾ Más Fácil de Mantener

Cuando necesitas agregar un nuevo campo, solo modificas la clase/struct, no todas las llamadas a la función.

```csharp
// ❌ Si agregas un campo, debes cambiar todas las llamadas
public Result GraduateStudent(string name, DateOnly birthDate, string major, int score, int totalCourses, string advisor) // Nuevo parámetro

// ✅ Solo modificas la clase Student
public class Student
{
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Major { get; set; }
    public int Score { get; set; }
    public int TotalCourses { get; set; }
    public string Advisor { get; set; } // Nuevo campo, sin cambiar la firma
}
```

### ◾ Testing Simplificado

Los tests son más simples cuando solo necesitas crear un objeto en lugar de pasar múltiples argumentos.

```csharp
// ❌ Test con muchos argumentos
[Test]
public void GraduateStudent_ShouldReturnSuccess()
{
    var result = GraduateStudent("John", new DateOnly(2000, 1, 1), "CS", 85, 10);
    Assert.IsTrue(result.IsSuccess);
}

// ✅ Test con objeto
[Test]
public void GraduateStudent_ShouldReturnSuccess()
{
    var student = new Student 
    { 
        Name = "John", 
        BirthDate = new DateOnly(2000, 1, 1), 
        Major = "CS", 
        Score = 85, 
        TotalCourses = 10 
    };
    var result = GraduateStudent(student);
    Assert.IsTrue(result.IsSuccess);
}
```

### ◾ Mayor Flexibilidad del Código

Puedes agregar nuevos campos o propiedades sin cambiar la firma de la función, haciendo el código más flexible y extensible.

## 💡 Cuándo Usar Struct vs Class

### Usa Struct cuando:
- Los datos son pequeños (menos de 16 bytes idealmente)
- Los datos son inmutables
- No necesitas herencia
- Los datos representan un valor

```csharp
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}
```

### Usa Class cuando:
- Los datos son grandes
- Necesitas herencia o polimorfismo
- Los datos representan una entidad con comportamiento
- Necesitas referencias null

```csharp
public class Student
{
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Major { get; set; }
    // ... más propiedades
}
```

## 🎯 Regla General: Máximo 2-3 Argumentos

Como regla general:
- **0-2 argumentos**: Ideal ✅
- **3 argumentos**: Aceptable ⚠️
- **4+ argumentos**: Considera refactorizar ❌

## 📚 Recursos Adicionales

- [Clean Code by Robert C. Martin](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882)
- [Microsoft Docs - C# Coding Conventions](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)

