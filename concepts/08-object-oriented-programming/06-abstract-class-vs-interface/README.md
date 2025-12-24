# Difference Between Abstract Class and Interface ✨

## Introducción

Comprender las diferencias entre **Abstract Class** e **Interface** es fundamental en programación orientada a objetos. Ambos son herramientas poderosas para definir contratos y comportamientos, pero tienen propósitos y características distintas.

## 📊 Comparación Visual

| Aspecto | Abstract Class | Interface |
|---------|----------------|-----------|
| **Methods** | Puede tener métodos abstractos (sin cuerpo) y concretos (con cuerpo) | Principalmente declaraciones de métodos. Desde C# 8.0, también puede tener definiciones |
| **Keyword** | `abstract` | `interface` |
| **Inheritance** | No soporta herencia múltiple (solo una clase abstracta) | Soporta herencia múltiple (múltiples interfaces) |
| **Constructors** | Puede tener constructores | No tiene constructores |
| **Access Modifiers** | Puede definir métodos con varios modificadores de acceso | Métodos son implícitamente públicos y abstractos |
| **Fields** | Puede tener campos (variables de instancia) | No puede tener campos (solo propiedades) |
| **Purpose** | Compartir comportamiento común con implementaciones únicas | Definir un contrato que múltiples clases deben seguir |

## 📌 1. Implementation (Implementación)

### Abstract Class 🟢

Una clase abstracta puede tener tanto métodos abstractos (sin cuerpo) como métodos concretos (con cuerpo).

```csharp
// ✅ BIEN: Abstract Class con métodos abstractos y concretos
public abstract class Animal
{
    // Campo (variable de instancia)
    protected string Name { get; set; }
    
    // Constructor
    public Animal(string name)
    {
        Name = name;
    }
    
    // Método abstracto (sin implementación)
    public abstract void MakeSound();
    
    // Método concreto (con implementación)
    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping");
    }
    
    // Método virtual (puede ser sobrescrito)
    public virtual void Eat()
    {
        Console.WriteLine($"{Name} is eating");
    }
}

// Implementación
public class Dog : Animal
{
    public Dog(string name) : base(name) { }
    
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}
```

### Interface 🔵

Una interfaz puede tener principalmente declaraciones de métodos. Desde C# 8.0, también puede tener implementaciones por defecto.

```csharp
// ✅ BIEN: Interface con declaraciones
public interface IAnimal
{
    // Declaración de método (implícitamente público y abstracto)
    void MakeSound();
    
    // Propiedad (no campos)
    string Name { get; set; }
}

// Desde C# 8.0: Implementación por defecto
public interface IAnimal
{
    void MakeSound();
    
    // Implementación por defecto
    void Sleep()
    {
        Console.WriteLine("Animal is sleeping");
    }
    
    // Método estático (C# 8.0+)
    static void DisplayInfo()
    {
        Console.WriteLine("This is an animal interface");
    }
}

// Implementación
public class Dog : IAnimal
{
    public string Name { get; set; }
    
    public void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}
```

## 📌 2. Inheritance (Herencia)

### Abstract Class 🟢

Una clase puede heredar de **solo una** clase abstracta (herencia simple).

```csharp
// ✅ BIEN: Herencia simple con Abstract Class
public abstract class Vehicle
{
    public int Speed { get; set; }
    public abstract void Start();
}

public class Car : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Car engine started");
    }
}

// ❌ MAL: No puedes heredar de múltiples clases abstractas
// public class HybridCar : Vehicle, ElectricVehicle // Error
```

### Interface 🔵

Una clase puede implementar **múltiples** interfaces (herencia múltiple).

```csharp
// ✅ BIEN: Implementar múltiples interfaces
public interface IVehicleFeatures
{
    void ApplyBrakes();
    void TurnOnLights();
}

public interface IMaintenance
{
    void PerformMaintenance();
}

public class Car : IVehicleFeatures, IMaintenance
{
    public void ApplyBrakes()
    {
        Console.WriteLine("Brakes applied");
    }
    
    public void TurnOnLights()
    {
        Console.WriteLine("Lights turned on");
    }
    
    public void PerformMaintenance()
    {
        Console.WriteLine("Maintenance performed");
    }
}
```

## 📌 3. Access Modifiers (Modificadores de Acceso)

### Abstract Class 🟢

Puede definir métodos con varios modificadores de acceso (public, protected, private, internal).

```csharp
public abstract class Animal
{
    // Método público
    public abstract void MakeSound();
    
    // Método protegido (solo accesible en clase y derivadas)
    protected virtual void InternalMethod()
    {
        Console.WriteLine("Internal method");
    }
    
    // Método privado (solo accesible en esta clase)
    private void PrivateMethod()
    {
        Console.WriteLine("Private method");
    }
}
```

### Interface 🔵

Los métodos son implícitamente públicos y abstractos (a menos que se especifique lo contrario).

```csharp
public interface IAnimal
{
    // Implícitamente público y abstracto
    void MakeSound();
    
    // Desde C# 8.0: Puede tener implementación por defecto
    void Sleep()
    {
        Console.WriteLine("Sleeping");
    }
    
    // Desde C# 8.0: Puede ser privado
    private void PrivateMethod()
    {
        Console.WriteLine("Private");
    }
}
```

## 📌 4. Purpose (Propósito)

### Abstract Class 🟢

Se usa cuando las clases comparten comportamiento común pero necesitan implementaciones únicas.

```csharp
// ✅ BIEN: Abstract Class para comportamiento común
public abstract class Vehicle
{
    // Comportamiento común
    public int Speed { get; set; }
    
    public void StartEngine()
    {
        Console.WriteLine("Engine started");
        Speed = 0;
    }
    
    // Implementación única requerida
    public abstract void Accelerate();
}

public class Car : Vehicle
{
    public override void Accelerate()
    {
        Speed += 10;
        Console.WriteLine($"Car speed: {Speed} km/h");
    }
}

public class Bike : Vehicle
{
    public override void Accelerate()
    {
        Speed += 5;
        Console.WriteLine($"Bike speed: {Speed} km/h");
    }
}
```

### Interface 🔵

Se usa para definir un contrato que múltiples clases deben seguir sin especificar cómo se implementa la funcionalidad.

```csharp
// ✅ BIEN: Interface para definir contrato
public interface IVehicleFeatures
{
    void ApplyBrakes();
    void TurnOnLights();
}

// Múltiples clases pueden implementar el mismo contrato
public class Car : IVehicleFeatures
{
    public void ApplyBrakes()
    {
        Console.WriteLine("Car brakes applied");
    }
    
    public void TurnOnLights()
    {
        Console.WriteLine("Car lights turned on");
    }
}

public class Bike : IVehicleFeatures
{
    public void ApplyBrakes()
    {
        Console.WriteLine("Bike brakes applied");
    }
    
    public void TurnOnLights()
    {
        Console.WriteLine("Bike lights turned on");
    }
}
```

## 🚗 Ejemplo de Caso de Uso Completo

### Escenario: Diferentes Tipos de Vehículos

Si tienes diferentes tipos de vehículos como carros y bicicletas:

**Usa Abstract Class "Vehicle"** para definir propiedades comunes (ej: velocidad) y métodos (ej: startEngine()).

```csharp
public abstract class Vehicle
{
    public int Speed { get; protected set; }
    public string Brand { get; set; }
    
    public Vehicle(string brand)
    {
        Brand = brand;
        Speed = 0;
    }
    
    // Método común con implementación
    public void StartEngine()
    {
        Console.WriteLine($"{Brand} engine started");
        Speed = 0;
    }
    
    // Método abstracto (implementación única requerida)
    public abstract void Accelerate();
    
    // Método virtual (puede ser sobrescrito)
    public virtual void Stop()
    {
        Speed = 0;
        Console.WriteLine("Vehicle stopped");
    }
}
```

**Usa Interface "IVehicleFeatures"** para definir capacidades adicionales (ej: applyBrakes(), turnOnLights()).

```csharp
public interface IVehicleFeatures
{
    void ApplyBrakes();
    void TurnOnLights();
}

public interface IMaintenance
{
    void PerformMaintenance();
    DateTime GetLastMaintenanceDate();
}
```

**Implementación Completa:**

```csharp
public class Car : Vehicle, IVehicleFeatures, IMaintenance
{
    public Car(string brand) : base(brand) { }
    
    // Implementación de método abstracto
    public override void Accelerate()
    {
        Speed += 15;
        Console.WriteLine($"Car speed: {Speed} km/h");
    }
    
    // Implementación de interface IVehicleFeatures
    public void ApplyBrakes()
    {
        Speed = Math.Max(0, Speed - 20);
        Console.WriteLine("Car brakes applied");
    }
    
    public void TurnOnLights()
    {
        Console.WriteLine("Car lights turned on");
    }
    
    // Implementación de interface IMaintenance
    public void PerformMaintenance()
    {
        Console.WriteLine("Car maintenance performed");
    }
    
    public DateTime GetLastMaintenanceDate()
    {
        return DateTime.Now.AddMonths(-1);
    }
}

public class Bike : Vehicle, IVehicleFeatures
{
    public Bike(string brand) : base(brand) { }
    
    public override void Accelerate()
    {
        Speed += 8;
        Console.WriteLine($"Bike speed: {Speed} km/h");
    }
    
    public void ApplyBrakes()
    {
        Speed = Math.Max(0, Speed - 10);
        Console.WriteLine("Bike brakes applied");
    }
    
    public void TurnOnLights()
    {
        Console.WriteLine("Bike lights turned on");
    }
}
```

## 📊 Tabla Comparativa Detallada

| Característica | Abstract Class | Interface |
|----------------|----------------|-----------|
| **Métodos Abstractos** | ✅ Sí | ✅ Sí (implícito) |
| **Métodos Concretos** | ✅ Sí | ✅ Sí (C# 8.0+) |
| **Constructors** | ✅ Sí | ❌ No |
| **Fields** | ✅ Sí | ❌ No (solo propiedades) |
| **Herencia Múltiple** | ❌ No | ✅ Sí |
| **Access Modifiers** | ✅ Todos (public, protected, private) | ⚠️ Principalmente public |
| **Default Implementation** | ✅ Sí | ✅ Sí (C# 8.0+) |
| **Static Members** | ✅ Sí | ✅ Sí (C# 8.0+) |
| **Instance Creation** | ❌ No (no se puede instanciar) | ❌ No (no se puede instanciar) |

## 💡 Cuándo Usar Cada Uno

### Usa Abstract Class Cuando:

- ✅ Necesitas compartir código común entre clases relacionadas
- ✅ Necesitas campos (variables de instancia)
- ✅ Necesitas constructores
- ✅ Necesitas métodos con diferentes modificadores de acceso
- ✅ Las clases tienen una relación "is-a" clara

**Ejemplo:**
```csharp
// "Car is a Vehicle" - relación clara
public abstract class Vehicle { }
public class Car : Vehicle { }
```

### Usa Interface Cuando:

- ✅ Necesitas definir un contrato que múltiples clases no relacionadas deben seguir
- ✅ Necesitas herencia múltiple
- ✅ Solo necesitas definir qué hacer, no cómo hacerlo
- ✅ Las clases tienen una relación "can-do" o "has-a"

**Ejemplo:**
```csharp
// "Car can apply brakes" - capacidad
public interface IVehicleFeatures { }
public class Car : IVehicleFeatures { }
public class Bike : IVehicleFeatures { }
```

## 🔄 Combinando Abstract Class e Interface

Puedes combinar ambos para obtener lo mejor de ambos mundos:

```csharp
// Abstract Class para comportamiento común
public abstract class Vehicle
{
    public int Speed { get; set; }
    public abstract void Accelerate();
}

// Interface para capacidades adicionales
public interface IVehicleFeatures
{
    void ApplyBrakes();
    void TurnOnLights();
}

// Implementación combinada
public class Car : Vehicle, IVehicleFeatures
{
    public override void Accelerate()
    {
        Speed += 15;
    }
    
    public void ApplyBrakes()
    {
        Speed = Math.Max(0, Speed - 20);
    }
    
    public void TurnOnLights()
    {
        Console.WriteLine("Lights on");
    }
}
```

## 📚 Recursos Adicionales

- [Microsoft Docs - Abstract Classes](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/abstract)
- [Microsoft Docs - Interfaces](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/interface)
- [Microsoft Docs - Default Interface Methods](https://docs.microsoft.com/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods)

