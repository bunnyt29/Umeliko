import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ToastrService } from "ngx-toastr";

import { AuthService } from "../../services/auth.service";

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit{
  changePasswordForm!: FormGroup
  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.changePasswordForm = this.fb.group({
      'currentPassword': ['', [Validators.required, Validators.minLength(8)]],
      'newPassword': ['', [Validators.required, Validators.minLength(8)]],
    })
  }

  get currentPassword() {
    return this.changePasswordForm.get('currentPassword');
  }

  get newPassword() {
    return this.changePasswordForm.get('newPassword');
  }

  changePassword(): void{
    this.authService.changePassword(this.changePasswordForm.value).subscribe( res => {
      this.toastr.success('Успешно променихте паролата си!');
    })
  }

}


