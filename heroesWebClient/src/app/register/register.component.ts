import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { CanComponentDeactivate } from '../guards/deactive.guard';

@Component({
  selector: 'app-register',
  standalone: false,

  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent implements CanComponentDeactivate {
  isSaved = true;
  userDetailsForm: FormGroup;
  constructor() {
    this.userDetailsForm = new FormGroup({
      name: new FormControl(''),
      email: new FormControl(''),
    });
  }
  canDeactivate(): boolean {
    if (!this.isSaved) {
      return confirm('You have unsaved changes. Do you really want to leave?');
    }
    return true;
  }
  onSubmit() {
    this.isSaved = true;
  }
}
