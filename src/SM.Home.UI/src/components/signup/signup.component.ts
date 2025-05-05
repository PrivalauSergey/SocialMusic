import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { AccountService } from '../../services/account-service/account.service';
import { AuthService } from '../../services/authorization-service/auth.service';
import { passwordRegex } from '../../directives/password-regex-validator-directive';

@Component({
  standalone: true,
  selector: 'account',
  imports: [ReactiveFormsModule, FormsModule, RouterLink, RouterLinkActive, NgIf],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss'
})
export class SignupComponent {
  constructor(
    private accountService: AccountService,
    private authService: AuthService,
    private router: Router,
  ) {}
    
  signupForm = new FormGroup({
    username: new FormControl('', [
      Validators.required,
      Validators.minLength(2),
      Validators.maxLength(15),
    ]),
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
      passwordRegex()
    ])
  })

  onSignup() : void {
    this.accountService.create(
      this.signupForm.value.username,
      this.signupForm.value.email,
      this.signupForm.value.password)
    .subscribe({
      next: (response) => {
        this.authService.setToken(response.token);
        this.router.navigate(['/home']);
      },
      error: (err) => {
        console.error('signup failed', err);
      }
  });
  }

  get username() {
    return this.signupForm.get('username');
  }

  get email() {
    return this.signupForm.get('email');
  }

  get password() {
    return this.signupForm.get('password');
  }


}
