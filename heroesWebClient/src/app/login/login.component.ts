import { Component, inject } from '@angular/core';
import { SharedDataService } from '../services/shared-data.service';

@Component({
  selector: 'app-login',
  standalone: false,

  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  data = inject(SharedDataService);

  login() {
    // login logic here
    this.data.setData('isLoginFlag', true);
  }
}
