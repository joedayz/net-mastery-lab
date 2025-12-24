# Template-Driven vs. Reactive Forms en Angular 🔍

## Introducción

Elegir entre Template-Driven Forms y Reactive Forms en Angular puede ser una decisión importante. Esta guía te ayudará a decidir basándote en las necesidades de tu proyecto.

## 🌟 Template-Driven Forms

Los **Template-Driven Forms** son simples y fáciles de configurar, perfectos para formularios directos con necesidades mínimas de validación. Inspirados en Angular.js, estos formularios son excelentes para prototipado rápido.

### Características Clave

- **Relies on FormsModule**: Requiere `FormsModule` importado
- **Utiliza [(ngModel)]**: Para two-way data binding
- **Lógica en el Template**: La mayor parte de la lógica está escrita directamente en el template
- **Tracking Automático**: Seguimiento automático de estados de formulario e inputs
- **Validación Simple**: Validación simple con directivas de Angular

### Ventajas

✅ Fácil de configurar y entender  
✅ Ideal para formularios simples  
✅ Menos código en el componente  
✅ Perfecto para prototipado rápido  

### Desventajas

❌ Menos control sobre la validación  
❌ Difícil de escalar para formularios complejos  
❌ Lógica mezclada en el template  
❌ Más difícil de testear  

### Ejemplo: Template-Driven Form

```typescript
// app.module.ts
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [FormsModule],
  // ...
})
export class AppModule { }
```

```typescript
// user-form.component.ts
import { Component } from '@angular/core';

export class User {
  name: string = '';
  email: string = '';
}

@Component({
  selector: 'app-user-form',
  template: `
    <form #userForm="ngForm" (ngSubmit)="onSubmit(userForm)">
      <div>
        <label>Name:</label>
        <input 
          name="name" 
          [(ngModel)]="user.name" 
          required 
          minlength="3"
          #name="ngModel">
        <div *ngIf="name.invalid && name.touched">
          <small *ngIf="name.errors?.['required']">Name is required</small>
          <small *ngIf="name.errors?.['minlength']">Name must be at least 3 characters</small>
        </div>
      </div>

      <div>
        <label>Email:</label>
        <input 
          type="email" 
          name="email" 
          [(ngModel)]="user.email" 
          required 
          email
          #email="ngModel">
        <div *ngIf="email.invalid && email.touched">
          <small *ngIf="email.errors?.['required']">Email is required</small>
          <small *ngIf="email.errors?.['email']">Invalid email format</small>
        </div>
      </div>

      <button type="submit" [disabled]="userForm.invalid">Submit</button>
    </form>
  `
})
export class UserFormComponent {
  user: User = new User();

  onSubmit(form: NgForm) {
    if (form.valid) {
      console.log('Form submitted:', this.user);
      // Llamar al servicio para enviar al backend .NET
    }
  }
}
```

### Integración con .NET Backend

```typescript
// user.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://api.example.com/api/users';

  constructor(private http: HttpClient) { }

  createUser(user: User): Observable<User> {
    return this.http.post<User>(this.apiUrl, user);
  }
}
```

```csharp
// UserController.cs (Backend .NET)
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateUser([FromBody] UserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Procesar y guardar usuario
        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email
        };

        // Guardar en base de datos
        // ...

        return Ok(user);
    }
}

public class UserDto
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
```

## 🚀 Reactive Forms

Los **Reactive Forms** ofrecen una solución más robusta y escalable, ideal para formularios complejos y escenarios de validación avanzados. Con la lógica alojada en la clase del componente, Reactive Forms brindan más control y predictibilidad.

### Características Clave

- **Requires ReactiveFormsModule**: Requiere `ReactiveFormsModule` importado
- **Creación Explícita**: Creación explícita de controles de formulario en la clase del componente
- **Controles Dinámicos**: Permite controles de formulario dinámicos y validaciones complejas
- **Mejor para Testing**: Mejor para unit testing, ya que la lógica del formulario está separada del template
- **Type Safety**: Mejor type safety con TypeScript

### Ventajas

✅ Más control y predictibilidad  
✅ Escalable para formularios complejos  
✅ Lógica separada del template  
✅ Fácil de testear  
✅ Validación avanzada y personalizada  
✅ Controles dinámicos  

### Desventajas

❌ Más código inicial  
❌ Curva de aprendizaje más pronunciada  
❌ Puede ser excesivo para formularios simples  

### Ejemplo: Reactive Form

```typescript
// app.module.ts
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [ReactiveFormsModule],
  // ...
})
export class AppModule { }
```

```typescript
// user-form-reactive.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from './user.service';

@Component({
  selector: 'app-user-form-reactive',
  template: `
    <form [formGroup]="userForm" (ngSubmit)="onSubmit()">
      <div>
        <label>Name:</label>
        <input formControlName="name">
        <div *ngIf="userForm.get('name')?.invalid && userForm.get('name')?.touched">
          <small *ngIf="userForm.get('name')?.errors?.['required']">
            Name is required
          </small>
          <small *ngIf="userForm.get('name')?.errors?.['minlength']">
            Name must be at least 3 characters
          </small>
        </div>
      </div>

      <div>
        <label>Email:</label>
        <input type="email" formControlName="email">
        <div *ngIf="userForm.get('email')?.invalid && userForm.get('email')?.touched">
          <small *ngIf="userForm.get('email')?.errors?.['required']">
            Email is required
          </small>
          <small *ngIf="userForm.get('email')?.errors?.['email']">
            Invalid email format
          </small>
        </div>
      </div>

      <button type="submit" [disabled]="userForm.invalid">Submit</button>
    </form>
  `
})
export class UserFormReactiveComponent implements OnInit {
  userForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private userService: UserService
  ) {
    this.userForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  ngOnInit() {
    // Puedes suscribirte a cambios del formulario
    this.userForm.valueChanges.subscribe(value => {
      console.log('Form value changed:', value);
    });
  }

  onSubmit() {
    if (this.userForm.valid) {
      const user = this.userForm.value;
      this.userService.createUser(user).subscribe({
        next: (response) => {
          console.log('User created:', response);
          this.userForm.reset();
        },
        error: (error) => {
          console.error('Error creating user:', error);
        }
      });
    }
  }
}
```

### Validación Personalizada en Reactive Forms

```typescript
// custom-validators.ts
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function passwordStrengthValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;
    if (!value) {
      return null;
    }

    const hasUpperCase = /[A-Z]/.test(value);
    const hasLowerCase = /[a-z]/.test(value);
    const hasNumeric = /[0-9]/.test(value);
    const hasSpecialChar = /[!@#$%^&*]/.test(value);

    const passwordValid = hasUpperCase && hasLowerCase && hasNumeric && hasSpecialChar;

    return !passwordValid ? { passwordStrength: true } : null;
  };
}

// Uso en el componente
this.userForm = this.fb.group({
  name: ['', [Validators.required]],
  email: ['', [Validators.required, Validators.email]],
  password: ['', [Validators.required, passwordStrengthValidator()]]
});
```

### Integración con .NET Backend (Reactive Forms)

```csharp
// UserController.cs (Backend .NET)
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
    {
        // Validación automática con Data Annotations
        if (!ModelState.IsValid)
        {
            return BadRequest(new { 
                errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    )
            });
        }

        var result = await _userService.CreateUserAsync(dto);
        return Ok(result);
    }
}

public class CreateUserDto
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}$",
        ErrorMessage = "Password must contain uppercase, lowercase, number and special character")]
    public string Password { get; set; } = string.Empty;
}
```

## 📊 Comparación: Template-Driven vs Reactive Forms

| Característica | Template-Driven | Reactive Forms |
|----------------|-----------------|----------------|
| **Configuración** | Simple | Más código inicial |
| **Lógica** | En el template | En el componente |
| **Validación** | Básica | Avanzada y personalizada |
| **Testing** | Más difícil | Más fácil |
| **Escalabilidad** | Limitada | Excelente |
| **Controles Dinámicos** | No | Sí |
| **Type Safety** | Limitado | Mejor |
| **Ideal Para** | Formularios simples | Formularios complejos |

## 🎯 Cuándo Usar Cada Enfoque

### Usa Template-Driven Forms cuando:
- ✅ Formularios simples con validación básica
- ✅ Prototipado rápido
- ✅ Necesitas una solución rápida y directa
- ✅ El formulario no cambiará mucho
- ✅ Ejemplos: Login simple, formulario de contacto, búsqueda

### Usa Reactive Forms cuando:
- ✅ Formularios complejos con múltiples campos
- ✅ Necesitas validación avanzada o personalizada
- ✅ Controles dinámicos (agregar/eliminar campos)
- ✅ Necesitas mejor testabilidad
- ✅ El formulario crecerá en complejidad
- ✅ Ejemplos: Formularios multi-paso, formularios con arrays, formularios complejos de registro

## 💡 Mejores Prácticas

### Template-Driven Forms
- Mantén la lógica simple en el template
- Usa validadores personalizados cuando sea necesario
- Valida también en el backend .NET

### Reactive Forms
- Crea FormGroups y FormControls en el componente
- Usa FormBuilder para código más limpio
- Implementa validadores personalizados reutilizables
- Maneja errores del backend .NET apropiadamente

## 📚 Recursos Adicionales

- [Angular Docs - Template-Driven Forms](https://angular.io/guide/forms)
- [Angular Docs - Reactive Forms](https://angular.io/guide/reactive-forms)
- [Microsoft Docs - ASP.NET Core Web API](https://docs.microsoft.com/aspnet/core/web-api/)

