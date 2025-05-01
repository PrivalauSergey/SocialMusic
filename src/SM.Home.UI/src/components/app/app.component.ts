import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { AuthService } from '../../services/authorization-service/auth.service';
import { environment } from '../../environments/environment';

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterOutlet, RouterLink, RouterLinkActive ],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
})

export class AppComponent {
  constructor(private authService: AuthService) {
    if(environment.env === 'development') {
      console.log("dev env");
    };
  }

  title = 'Social Music';

  isLoggedIn(): boolean {
    return this.authService.isAuthenticated();
  }

  logout(): void {
    this.authService.logout();
  }
}
