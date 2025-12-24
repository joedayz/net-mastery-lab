# Ejemplos Prácticos - Template-Driven vs Reactive Forms

Esta carpeta contiene ejemplos de código que demuestran Template-Driven Forms vs Reactive Forms en Angular y su integración con APIs .NET.

## Archivos de Ejemplo

### Template-Driven Form Example
- `template-driven-form.component.ts` - Componente Angular con Template-Driven Form
- `template-driven-form.component.html` - Template HTML
- `user.service.ts` - Servicio Angular para comunicación con API .NET

### Reactive Form Example
- `reactive-form.component.ts` - Componente Angular con Reactive Form
- `reactive-form.component.html` - Template HTML
- `custom-validators.ts` - Validadores personalizados

### Backend .NET Examples
- `UsersController.cs` - Controlador ASP.NET Core Web API
- `CreateUserDto.cs` - DTO con validación
- `User.cs` - Modelo de dominio

## Conceptos Clave

- **Template-Driven Forms**: Simple, fácil de configurar, ideal para formularios básicos
- **Reactive Forms**: Robusto, escalable, ideal para formularios complejos
- **Integración .NET**: Validación dual (cliente y servidor)
- **Type Safety**: Interfaces TypeScript que coinciden con DTOs de .NET

## Ejemplo Básico: Template-Driven

```typescript
// Componente
export class UserFormComponent {
  user = { name: '', email: '' };
  
  onSubmit(form: NgForm) {
    if (form.valid) {
      this.userService.createUser(this.user).subscribe();
    }
  }
}
```

```html
<!-- Template -->
<form #userForm="ngForm" (ngSubmit)="onSubmit(userForm)">
  <input name="name" [(ngModel)]="user.name" required>
  <input name="email" [(ngModel)]="user.email" required email>
  <button type="submit" [disabled]="userForm.invalid">Submit</button>
</form>
```

## Ejemplo Básico: Reactive Forms

```typescript
// Componente
export class UserFormReactiveComponent {
  userForm: FormGroup;
  
  constructor(private fb: FormBuilder) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }
  
  onSubmit() {
    if (this.userForm.valid) {
      this.userService.createUser(this.userForm.value).subscribe();
    }
  }
}
```

```html
<!-- Template -->
<form [formGroup]="userForm" (ngSubmit)="onSubmit()">
  <input formControlName="name">
  <input formControlName="email">
  <button type="submit" [disabled]="userForm.invalid">Submit</button>
</form>
```

## Integración con .NET

```csharp
// Backend .NET
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // Procesar usuario
        return Ok();
    }
}
```

## Notas

- Los ejemplos muestran ambos enfoques lado a lado
- Se incluye código completo de Angular y .NET
- Se demuestra validación dual (cliente y servidor)
- Se muestran mejores prácticas para cada enfoque

