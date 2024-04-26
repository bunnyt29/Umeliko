import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

import { AuthService } from '../../services/auth.service';
import { Router } from "@angular/router";

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      'firstName': ['', [Validators.required, Validators.minLength(2), Validators.maxLength(20)]],
      'lastName': ['', [Validators.required, Validators.minLength(2), Validators.maxLength(20)]],
      'userName': ['', [Validators.required, Validators.minLength(2)]],
      'email': ['', [Validators.required, Validators.email, Validators.minLength(3), Validators.maxLength(50)]],
      'password': ['', [Validators.required, Validators.minLength(8)]],
      'confirmPassword': ['', Validators.required]
    });
  }

  get firstName() {
    return this.registerForm.get('firstName');
  }

  get lastName() {
    return this.registerForm.get('lastName');
  }

  get userName() {
    return this.registerForm.get('userName');
  }

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    return this.registerForm.get('password');
  }

  register(): void {
    if (this.registerForm.invalid) {
      this.toastrService.error('Въведи валидни данни.');

      return;
    }

    this.authService.register(this.registerForm.value).subscribe(() => {
      this.toastrService.warning('Провери имейла си!');
    });
  }
}
