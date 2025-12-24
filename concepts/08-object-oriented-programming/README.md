# Object-Oriented Programming (OOP) 🎯

## Introducción

La Programación Orientada a Objetos (OOP) es un paradigma de programación fundamental en C# y .NET. Este apartado contiene conceptos y principios esenciales de OOP para escribir código bien estructurado y mantenible.

## 📚 Temas Disponibles

### 1. Encapsulation (Encapsulación)
**Ubicación:** `concepts/08-object-oriented-programming/01-encapsulation/`

Guía sobre el concepto de encapsulación: agrupar datos y métodos dentro de una clase, restringiendo el acceso directo y protegiendo el estado interno.

### 2. Abstraction (Abstracción)
**Ubicación:** `concepts/08-object-oriented-programming/02-abstraction/`

Guía sobre el concepto de abstracción: ocultar detalles complejos y mostrar solo las características esenciales mediante clases abstractas y records.

### 3. Inheritance with Virtual/Override and Dependency Injection
**Ubicación:** `concepts/08-object-oriented-programming/03-inheritance-virtual-override-di/`

Guía sobre cómo combinar herencia con métodos virtual/override y Dependency Injection en ASP.NET Core para construir aplicaciones escalables y mantenibles.

### 4. Polymorphism (Polimorfismo)
**Ubicación:** `concepts/08-object-oriented-programming/04-polymorphism/`

Guía sobre el concepto de polimorfismo: "One Interface, Many Implementations". Cómo usar polimorfismo con Dependency Injection para lograr diseño flexible y desacoplado.

### 5. Key Class Concepts
**Ubicación:** `concepts/08-object-oriented-programming/05-key-class-concepts/`

Guía sobre los conceptos clave de clases en OOP: instancias, referencias y variables (instance variables y static variables).

### 6. Abstract Class vs Interface
**Ubicación:** `concepts/08-object-oriented-programming/06-abstract-class-vs-interface/`

Guía completa sobre las diferencias entre Abstract Class e Interface, cuándo usar cada uno y cómo combinarlos estratégicamente.

**Diferencias Clave:**
- **Implementation**: Abstract Class tiene métodos abstractos y concretos, Interface principalmente declaraciones
- **Inheritance**: Abstract Class = herencia simple, Interface = herencia múltiple
- **Access Modifiers**: Abstract Class = todos los modificadores, Interface = principalmente public
- **Purpose**: Abstract Class = comportamiento común, Interface = contrato

**Cuándo Usar:**
- **Abstract Class**: Relación "is-a", código común, campos, constructores
- **Interface**: Contrato, herencia múltiple, relación "can-do"

### 7. Types of Inheritance in .NET Core
**Ubicación:** `concepts/08-object-oriented-programming/07-types-of-inheritance/`

Guía completa sobre los diferentes tipos de herencia en .NET Core: Single, Multiple (via Interfaces), Multilevel, Hierarchical y Hybrid Inheritance.

**Tipos de Herencia:**
- **Single Inheritance**: Una clase hereda de una clase base única
- **Multiple Inheritance**: Una clase implementa múltiples interfaces
- **Multilevel Inheritance**: Cadena de herencia (A → B → C)
- **Hierarchical Inheritance**: Múltiples clases de una base común
- **Hybrid Inheritance**: Combinación de clase base + interfaces

**Beneficios:**
- ✅ **Code Reusability**: Reutilización de código sin duplicación
- ✅ **Maintainability**: Cambios centralizados se propagan automáticamente
- ✅ **Scalability**: Fácil agregar nuevas funcionalidades
- ✅ **Polymorphism**: Tratamiento uniforme de objetos diferentes

---

## 🎯 Objetivo

Este apartado está diseñado para ayudarte a:
- Comprender los principios fundamentales de OOP
- Aplicar encapsulación correctamente en tus clases
- Proteger el estado interno de los objetos
- Diseñar interfaces bien definidas

## 📖 Principios Fundamentales

- **Encapsulation**: Agrupar datos y métodos dentro de una clase
- **Abstraction**: Ocultar detalles de implementación complejos
- **Inheritance**: Reutilizar código mediante herencia
- **Polymorphism**: Usar una interfaz común para diferentes tipos

