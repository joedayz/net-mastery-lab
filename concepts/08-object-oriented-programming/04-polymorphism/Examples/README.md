# Ejemplos Prácticos - Polymorphism (Polimorfismo)

Esta carpeta contiene ejemplos ejecutables que demuestran el concepto de polimorfismo en C# con Dependency Injection.

## Archivos

### `PolymorphismExamples.cs`
Demostraciones prácticas de polimorfismo:
- `DemonstrateBasicPolymorphism()` - Polimorfismo básico con herencia
- `DemonstrateInterfacePolymorphism()` - Polimorfismo con interfaces
- `DemonstratePolymorphismWithDI()` - Polimorfismo con Dependency Injection
- `DemonstrateDIContainerRegistration()` - Registro en DI container
- `DemonstrateMultipleImplementations()` - Múltiples implementaciones del mismo contrato
- `DemonstrateBenefits()` - Beneficios del polimorfismo
- `RunAllExamples()` - Ejecuta todos los ejemplos para una comparación completa

## Cómo Ejecutar

Desde la raíz del proyecto:

```bash
# Ejecutar el programa interactivo
dotnet run

# Seleccionar las opciones 42-43 para los ejemplos de Polymorphism:
#   42. Polymorphism - Comparación
#   43. Polymorphism - Ejemplos prácticos
```

## Conceptos Clave

- **One Interface, Many Implementations**: Una interfaz, múltiples implementaciones
- **Runtime Polymorphism**: Comportamiento polimórfico en tiempo de ejecución
- **Dependency Injection**: Inyectar diferentes implementaciones para diseño flexible
- **Flexibility and Scalability**: Permite código flexible y escalable

## Ejemplo Básico

```csharp
// Interface que define el contrato
public interface IPaymentProcessor
{
    void ProcessPayment(Order order);
}

// Implementación 1
public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine("Processing credit card payment ...");
    }
}

// Client class using DI to inject the payment processor
public class CheckoutService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public CheckoutService(IPaymentProcessor paymentProcessor) // Injected via DI
    {
        _paymentProcessor = paymentProcessor;
    }

    public void Checkout(Order order)
    {
        _paymentProcessor.ProcessPayment(order);
    }
}

// En el DI container (e.g., ASP.NET Core)
services.AddTransient<IPaymentProcessor, CreditCardPaymentProcessor>();
```

## Notas

- Los ejemplos muestran cómo el polimorfismo permite "One Interface, Many Implementations"
- Se demuestra cómo DI soporta naturalmente el polimorfismo
- Se incluyen ejemplos prácticos con PaymentProcessor y Logger
- Se explica cómo el mismo código puede trabajar con diferentes implementaciones

