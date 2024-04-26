import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ProfileService } from '../../services/profile.service';
import { Creator } from '../../../../shared/models/Creator';
import { ActivatedRoute, Router } from '@angular/router';
import { FileService } from "../../../../core/services/file.service";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit{
  profileForm!: FormGroup;
  creator!: Creator;
  imageUrl!: any;

  constructor(
    private fb: FormBuilder,
    private userProfileService: ProfileService,
    private toastrService: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    private fileService: FileService
  ){}

  ngOnInit(): void {
    this.fetchProfile();
  }

  fetchProfile(){
    this.userProfileService.getMineProfile().subscribe(res => {
      this.creator = res;
      this.profileForm = this.fb.group({
        'id': [this.creator.id],
        'firstName': [[this.creator.firstName], [Validators.required, Validators.minLength(2)]],
        'lastName': [[this.creator.lastName], [Validators.required, Validators.minLength(2)]],
        'userName': [this.creator.userName],
        'bio': [this.creator.bio],
        'imageUrl': [this.creator.imageUrl]
      })
    })
  }

  editProfile(){
    if (this.profileForm.invalid) {
      this.toastrService.error('Моля въведи валидни данни!');

      return;
    }

    this.userProfileService.editProfile(this.creator.id, this.profileForm.value).subscribe( () => {
      this.router.navigate(["/profile/mine"]);
    });
  }

  triggerInput(){
    const fileInput = document.getElementById('fileInput');
    if (fileInput) {
      fileInput.click();
    }
  }

  uploadImage(event: any): void {
    const inputElement = event.target as HTMLInputElement;
    if (inputElement.files && inputElement.files[0]) {
      const file = inputElement.files[0];
      if (event.target.files && event.target.files[0]) {
        const formData = this.fileService.readURL(event, file);
        this.fileService.uploadImage(formData).subscribe( res => {
          this.imageUrl = res.imageUrl;
          this.profileForm.patchValue({
            imageUrl: this.imageUrl
          });

          this.toastrService.success('Успешно качен файл!');
        })
      }
    }

    inputElement.value = "";
  }

  get firstName() {
    return this.profileForm.get('firstName');
  }

  get lastName() {
    return this.profileForm.get('lastName');
  }
}
