import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../authorization-service/auth.service';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router, private oauthService: OAuthService) {}
  canActivate(): boolean {
    if (this.authService.isAuthenticated()) {
      return true;
    } else {
      // trigger OIDC login flow instead of navigating to legacy login page
      this.oauthService.initCodeFlow();
      return false;
    }
  }
}
