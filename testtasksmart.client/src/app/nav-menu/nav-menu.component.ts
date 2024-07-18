import { Component } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  constructor(public authService: AuthService) { }

  logout(): void {
    this.authService.logout();
  }

  isNotEmployee(): boolean {
    return this.authService.getPosition() !== 'Employee';
  }
}
