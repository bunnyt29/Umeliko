import {Component, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from "ngx-toastr";

import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{
  loginForm!: FormGroup;
  isSubmitted!: boolean;
  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      'email': ['', Validators.required],
      'password': ['', Validators.required]
    })
  }

  login(): void {
    this.isSubmitted = true;

    if (this.loginForm.invalid) {
      this.toastrService.error('Невалидни данни!');
      return;
    }

    this.authService.login(this.loginForm.value).subscribe(data => {
      this.authService.saveToken(data['token']);

      this.toastrService.success('Успешно влезе в своя профил.');

      if (this.authService.isAdmin()) {
        this.router.navigate(['/admin/panel']);
      }
      else {
        this.router.navigate(['/materials/all']);
      }
    })
  }

  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }
}
