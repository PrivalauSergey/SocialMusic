import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';
import { AuthService } from '../../services/authorization-service/auth.service';

@Component({
  standalone: true,
  selector: 'auth-callback',
  template: `<p>Signing you in...</p>`,
  imports: []
})
export class AuthCallbackComponent implements OnInit {
  constructor(private oauthService: OAuthService, private auth: AuthService, private router: Router) {}

  async ngOnInit(): Promise<void> {
    try {
      await this.oauthService.loadDiscoveryDocumentAndTryLogin();
      if (this.oauthService.hasValidAccessToken()) {
        const token = this.oauthService.getAccessToken();
        this.auth.setToken(token);
        this.router.navigate(['/home']);
      } else {
        console.error('No valid token after login');
        this.router.navigate(['/login']);
      }
    } catch (err) {
      console.error('Callback handling failed', err);
      this.router.navigate(['/login']);
    }
  }
}
