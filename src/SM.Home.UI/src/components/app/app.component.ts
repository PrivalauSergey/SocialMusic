import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { AuthService } from '../../services/authorization-service/auth.service';
import { OAuthService } from 'angular-oauth2-oidc';
import { environment } from '../../environments/environment';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterOutlet, RouterLink, RouterLinkActive ],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
})

export class AppComponent {
  constructor(private authService: AuthService, private oauthService: OAuthService) {
    if(environment.env === 'development') {
      console.log("dev env");
    };
    // Try to load discovery and login state
    this.oauthService.loadDiscoveryDocumentAndTryLogin();
  }

  title = 'Social Music';

  isLoggedIn(): boolean {
    return this.authService.isAuthenticated();
  }

  logout(): void {
    this.authService.logout();
  }
}
