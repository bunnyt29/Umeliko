import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";

import { MaterialService } from "../../../materials/services/material.service";
import { Material } from "../../../materials/models/Material";
import { AuthService } from "../../../auth/services/auth.service";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})
export class BoardComponent implements OnInit{
  materials: Array<Material> = [];
  showApproveDialog: boolean = false;
  showDispproveDialog: boolean = false;
  materialToApproveId!: string;
  materialToDispproveId!: string;
  disapproveForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private materialService: MaterialService,
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.fetchMaterials()
    this.disapproveForm = this.fb.group({
      'id': ['', Validators.required],
      'stateReason': ['', Validators.required]
    })
  }

  fetchMaterials(){
    this.materialService.getPendingMaterials().subscribe(data => {
      this.materials = data.materials;
    })
  }

  preview(contentType: string, materialId: string): void {
    let path = '/materials/' + contentType.toLowerCase() + '/' + materialId + '/preview';
    this.router.navigate([path])
  }

  openApproveDialog(materialId: string){
    this.showApproveDialog = true;
    this.cd.detectChanges();
    this.materialToApproveId = materialId;
  }

  openDispproveDialog(materialId: string){
    this.showDispproveDialog = true;
    this.cd.detectChanges();
    this.materialToDispproveId = materialId;
  }

  closeApproveDialog() : void {
    this.showApproveDialog = false;
  }

  closeDisapproveDialog() : void {
    this.showDispproveDialog = false;
  }

  approve(id: string){
    this.materialService.approve(id).subscribe( res => {
      this.toastr.success("Материалът е одобрен.")
    })
    this.cd.detectChanges();
  }

  disapprove(id: string){
    this.disapproveForm.patchValue({
      'id': id
    })
    this.materialService.disapprove(this.disapproveForm.value).subscribe( res => {
      this.toastr.success("Материалът е отхвърлен.")
    })
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/home']);
  }
}
