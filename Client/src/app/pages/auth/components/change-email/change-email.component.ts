import {Component, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ToastrService } from "ngx-toastr";

import { AuthService } from "../../services/auth.service";

@Component({
  selector: 'change-email',
  templateUrl: './change-email.component.html',
  styleUrls: ['./change-email.component.scss']
})
export class ChangeEmailComponent implements OnInit{
  changeEmailForm!: FormGroup
  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private toastr: ToastrService
  )
  {}

  ngOnInit(): void {
    this.changeEmailForm = this.fb.group({
      'email': ['', [Validators.required, Validators.email]],
    })
  }

  get email() {
    return this.changeEmailForm.get('email');
  }

  changeEmail(): void {
    this.authService.changeEmail(this.changeEmailForm.value).subscribe( res => {
      this.toastr.warning('Провери стария си имейл за потвърждение!')
    })
  }

}
