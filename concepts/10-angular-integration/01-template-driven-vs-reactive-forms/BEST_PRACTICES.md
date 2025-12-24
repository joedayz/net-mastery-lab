# Mejores Prácticas: Template-Driven vs Reactive Forms

## ✅ Reglas de Oro

### 1. Elegir el Enfoque Correcto Según la Complejidad

```typescript
// ✅ BIEN: Template-Driven para formularios simples
// Login form simple
<form #loginForm="ngForm" (ngSubmit)="onSubmit(loginForm)">
  <input name="email" [(ngModel)]="email" required email>
  <input name="password" [(ngModel)]="password" required>
  <button type="submit">Login</button>
</form>

// ✅ BIEN: Reactive Forms para formularios complejos
// Formulario de registro con múltiples secciones
this.registerForm = this.fb.group({
  personalInfo: this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required]
  }),
  address: this.fb.group({
    street: ['', Validators.required],
    city: ['', Validators.required]
  }),
  preferences: this.fb.array([])
});
```

### 2. Validación Dual: Cliente y Servidor

```typescript
// ✅ BIEN: Validar en Angular y .NET
// Angular (Cliente)
this.userForm = this.fb.group({
  email: ['', [Validators.required, Validators.email]]
});

// .NET (Servidor)
public class CreateUserDto
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }
}
```

### 3. Manejar Errores del Backend Apropiadamente

```typescript
// ✅ BIEN: Manejar errores de validación del backend
onSubmit() {
  this.userService.createUser(this.userForm.value).subscribe({
    next: (response) => {
      // Éxito
      this.showSuccess('User created successfully');
    },
    error: (error) => {
      // Manejar errores de validación del backend
      if (error.status === 400 && error.error.errors) {
        Object.keys(error.error.errors).forEach(key => {
          const control = this.userForm.get(key);
          if (control) {
            control.setErrors({ serverError: error.error.errors[key][0] });
          }
        });
      }
    }
  });
}
```

## ⚠️ Errores Comunes a Evitar

### 1. Mezclar Template-Driven y Reactive Forms

```typescript
// ❌ MAL: Mezclar ambos enfoques
<form [formGroup]="userForm" (ngSubmit)="onSubmit()">
  <input [(ngModel)]="user.name" formControlName="name">
  <!-- No mezclar ngModel con formControlName -->
</form>

// ✅ BIEN: Usar solo un enfoque
// Opción 1: Solo Template-Driven
<form #form="ngForm" (ngSubmit)="onSubmit(form)">
  <input [(ngModel)]="user.name" name="name">
</form>

// Opción 2: Solo Reactive Forms
<form [formGroup]="userForm" (ngSubmit)="onSubmit()">
  <input formControlName="name">
</form>
```

### 2. No Validar en el Backend

```csharp
// ❌ MAL: Confiar solo en validación del cliente
[HttpPost]
public IActionResult CreateUser([FromBody] UserDto dto)
{
    // Sin validación - inseguro
    var user = new User { Name = dto.Name };
    return Ok(user);
}

// ✅ BIEN: Validar siempre en el backend
[HttpPost]
public IActionResult CreateUser([FromBody] CreateUserDto dto)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
    // Procesar usuario válido
}
```

### 3. No Manejar Estados de Carga

```typescript
// ❌ MAL: No mostrar feedback al usuario
onSubmit() {
  this.userService.createUser(this.userForm.value).subscribe();
}

// ✅ BIEN: Mostrar estados de carga y error
isSubmitting = false;
errorMessage = '';

onSubmit() {
  if (this.userForm.invalid) return;
  
  this.isSubmitting = true;
  this.errorMessage = '';
  
  this.userService.createUser(this.userForm.value).subscribe({
    next: () => {
      this.isSubmitting = false;
      this.showSuccess();
    },
    error: (error) => {
      this.isSubmitting = false;
      this.errorMessage = error.message;
    }
  });
}
```

## 🎯 Casos de Uso Específicos

### 1. Template-Driven: Formulario de Contacto Simple

```typescript
// ✅ BIEN: Template-Driven para formulario simple
@Component({
  template: `
    <form #contactForm="ngForm" (ngSubmit)="onSubmit(contactForm)">
      <input name="name" [(ngModel)]="contact.name" required>
      <input name="email" [(ngModel)]="contact.email" required email>
      <textarea name="message" [(ngModel)]="contact.message" required></textarea>
      <button type="submit" [disabled]="contactForm.invalid">Send</button>
    </form>
  `
})
export class ContactFormComponent {
  contact = { name: '', email: '', message: '' };
  
  onSubmit(form: NgForm) {
    if (form.valid) {
      this.contactService.send(this.contact).subscribe();
    }
  }
}
```

### 2. Reactive Forms: Formulario Multi-Paso

```typescript
// ✅ BIEN: Reactive Forms para formulario complejo
@Component({
  template: `
    <form [formGroup]="multiStepForm">
      <div *ngIf="currentStep === 1">
        <input formControlName="firstName">
        <input formControlName="lastName">
      </div>
      <div *ngIf="currentStep === 2">
        <input formControlName="email">
        <input formControlName="phone">
      </div>
      <button (click)="nextStep()" [disabled]="!isStepValid()">Next</button>
    </form>
  `
})
export class MultiStepFormComponent {
  multiStepForm: FormGroup;
  currentStep = 1;
  
  constructor(private fb: FormBuilder) {
    this.multiStepForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required]
    });
  }
  
  isStepValid(): boolean {
    if (this.currentStep === 1) {
      return this.multiStepForm.get('firstName')?.valid && 
             this.multiStepForm.get('lastName')?.valid;
    }
    return this.multiStepForm.get('email')?.valid && 
           this.multiStepForm.get('phone')?.valid;
  }
}
```

### 3. Reactive Forms: FormArray Dinámico

```typescript
// ✅ BIEN: Reactive Forms para arrays dinámicos
@Component({
  template: `
    <form [formGroup]="form">
      <div formArrayName="items">
        <div *ngFor="let item of items.controls; let i = index" [formGroupName]="i">
          <input formControlName="name">
          <input formControlName="quantity">
          <button (click)="removeItem(i)">Remove</button>
        </div>
      </div>
      <button (click)="addItem()">Add Item</button>
    </form>
  `
})
export class DynamicFormComponent {
  form: FormGroup;
  
  get items() {
    return this.form.get('items') as FormArray;
  }
  
  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      items: this.fb.array([])
    });
  }
  
  addItem() {
    const item = this.fb.group({
      name: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]]
    });
    this.items.push(item);
  }
  
  removeItem(index: number) {
    this.items.removeAt(index);
  }
}
```

## 🚀 Tips Avanzados

### 1. Validadores Personalizados Reutilizables

```typescript
// ✅ BIEN: Crear validadores reutilizables
export function passwordMatchValidator(controlName: string, matchingControlName: string): ValidatorFn {
  return (formGroup: AbstractControl): ValidationErrors | null => {
    const control = formGroup.get(controlName);
    const matchingControl = formGroup.get(matchingControlName);
    
    if (!control || !matchingControl) {
      return null;
    }
    
    if (matchingControl.errors && !matchingControl.errors['passwordMismatch']) {
      return null;
    }
    
    if (control.value !== matchingControl.value) {
      matchingControl.setErrors({ passwordMismatch: true });
      return { passwordMismatch: true };
    } else {
      matchingControl.setErrors(null);
      return null;
    }
  };
}

// Uso
this.form = this.fb.group({
  password: ['', Validators.required],
  confirmPassword: ['', Validators.required]
}, { validators: passwordMatchValidator('password', 'confirmPassword') });
```

### 2. Integración con Backend .NET usando DTOs

```typescript
// ✅ BIEN: Usar interfaces TypeScript que coincidan con DTOs de .NET
export interface CreateUserDto {
  name: string;
  email: string;
  password: string;
}

export interface User {
  id: number;
  name: string;
  email: string;
  createdAt: Date;
}

// Servicio
@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) {}
  
  createUser(dto: CreateUserDto): Observable<User> {
    return this.http.post<User>('/api/users', dto);
  }
}
```

```csharp
// Backend .NET - DTOs correspondientes
public class CreateUserDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

### 3. Manejo de CORS en .NET para Angular

```csharp
// ✅ BIEN: Configurar CORS en .NET para Angular
// Program.cs o Startup.cs
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

app.UseCors("AllowAngularApp");
```

## 📊 Comparación Final

| Aspecto | Template-Driven | Reactive Forms |
|---------|----------------|----------------|
| **Complejidad** | Baja | Media-Alta |
| **Código Inicial** | Menos | Más |
| **Validación** | Básica | Avanzada |
| **Testing** | Difícil | Fácil |
| **Escalabilidad** | Limitada | Excelente |
| **Controles Dinámicos** | No | Sí |
| **Type Safety** | Limitado | Mejor |

## 📚 Recursos Adicionales

- [Angular Docs - Forms](https://angular.io/guide/forms)
- [Angular Docs - Reactive Forms](https://angular.io/guide/reactive-forms)
- [Microsoft Docs - ASP.NET Core Web API](https://docs.microsoft.com/aspnet/core/web-api/)
- [Angular Material - Form Controls](https://material.angular.io/components/form-field)

