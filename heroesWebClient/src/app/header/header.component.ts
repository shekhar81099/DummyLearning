import { Component, inject } from '@angular/core';
import { SharedDataService } from '../services/shared-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: false,

  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
data = inject(SharedDataService);
route = inject(Router);

  logout() {
    this.data.setData('isLoginFlag', false);
    this.route.navigate(["login"])
    // logout logic here
  }
}
