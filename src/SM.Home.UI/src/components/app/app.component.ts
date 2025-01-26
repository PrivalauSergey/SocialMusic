import { Component, Injectable } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { AuthService } from '../../services/authorization-service/auth.service';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterOutlet, RouterLink, RouterLinkActive ],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
})

export class AppComponent {
  constructor(private authService: AuthService) {}

  title = 'Social Music';

  isLoggedIn(): boolean {
    return this.authService.isAuthenticated();
  }

  logout(): void {
    this.authService.logout();
  }
}
