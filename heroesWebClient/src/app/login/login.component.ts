import { User } from './../interface/user';
import { UserResponse } from './../interface/user-response';
import { ApisService } from './../services/apis.service';
import { Component, inject } from '@angular/core';
import { SharedDataService } from '../services/shared-data.service';
import { Router } from '@angular/router';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: false,

  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  data = inject(SharedDataService);
  router = inject(Router);
  apis = inject(ApisService);
  userResponse: UserResponse | null = null;
  loginForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      username: ['admin', Validators.required],
      password: ['admin', Validators.required],
    });
  }
  async onSubmit() {
    if (this.loginForm.valid) {
      const { username, password } = this.loginForm.value;
      console.log('Login Successful', { username, password });

      this.apis
        .loginUser({
          username: username,
          password: password,
        })
        .subscribe((next) => {
          this.userResponse = next.body as UserResponse;
        });

      this.data.setData('isLoginFlag', true);
      sessionStorage.setItem('token', this.userResponse?.token ?? '');
      this.userResponse;
      const redirectUrl = localStorage.getItem('redirectUrl') || '';
      this.router.navigate([redirectUrl]);
    } else {
      console.log('Form is invalid');
    }
  }

  onRegister() {
    this.router.navigate(['register']);
  }
}
