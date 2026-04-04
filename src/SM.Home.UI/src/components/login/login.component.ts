import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/authorization-service/auth.service';
import { OAuthService } from 'angular-oauth2-oidc';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';


@Component({
  standalone: true,
  selector: 'login',
  imports: [ReactiveFormsModule, FormsModule, RouterLink, RouterLinkActive],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})

export class LoginComponent {
  constructor(
    private authService: AuthService,
    private router: Router,
    private oauthService: OAuthService,
  ) {}
    
  loginForm = new FormGroup({
    username: new FormControl('', [
      Validators.required,
    ]),
    password: new FormControl('', [
      Validators.required,
    ])
  })

  onLogin() : void {
    // start OIDC PKCE flow via library
    this.oauthService.initCodeFlow();
  }

  onOidcLogin(): void {
    this.oauthService.initCodeFlow();
  }

  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }
}
