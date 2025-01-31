import { Component, inject } from '@angular/core';
import { SharedDataService } from '../services/shared-data.service';

@Component({
  selector: 'app-header',
  standalone: false,

  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
data = inject(SharedDataService);

  logout() {
    this.data.setData('isLoginFlag', false);
    // logout logic here
  }
}
