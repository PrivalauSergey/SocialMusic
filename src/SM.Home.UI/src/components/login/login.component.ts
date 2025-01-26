import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormControl, FormGroup } from '@angular/forms';
import { AuthService } from '../../services/authorization-service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'login',
  standalone: true,
  templateUrl: './login.component.html',
  imports: [ReactiveFormsModule, FormsModule ],
  styleUrl: './login.component.scss'
})

export class LoginComponent {
  constructor(private authService: AuthService, private router: Router) {}
    loginForm = new FormGroup({
      username: new FormControl(''),
      password: new FormControl('')
    })
  

    onLogin() : void {
      this.authService.login(this.loginForm.value.username, this.loginForm.value.password).subscribe({
        next: (response) => {
          this.authService.setToken(response.token);
          this.router.navigate(['/home']);
        },
        error: (err) => {
          console.error('Login failed', err);
        }
    });
  }
}
