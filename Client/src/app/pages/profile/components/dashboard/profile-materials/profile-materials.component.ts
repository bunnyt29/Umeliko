import {ChangeDetectorRef, Component, OnInit, ViewChild} from '@angular/core';
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";

import { Material } from '../../../../materials/models/Material';
import { MaterialService } from "../../../../materials/services/material.service";
import { CustomConfirmDialogComponent } from "../../../../../shared/components/custom-confirm-dialog/custom-confirm-dialog.component";

@Component({
  selector: 'profile-materials',
  templateUrl: './profile-materials.component.html',
  styleUrls: ['./profile-materials.component.scss']
})

export class ProfileMaterialsComponent implements OnInit {
  @ViewChild(CustomConfirmDialogComponent) customConfirmDialog!: CustomConfirmDialogComponent;
  materials: Array<Material> = [];
  pendingDeleteMaterialId!: string;
  materialToPublishId!: string;
  hover: string | null = null;
  showConfirmDialog: boolean = false;

  constructor(
    private materialService: MaterialService,
    private router: Router,
    private toastr: ToastrService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.fetchMaterials();
  }

  fetchMaterials(){
    this.materialService.getMineMaterials().subscribe(data => {
      this.materials = data.materials;
      console.log(this.materials);
    })
  }

  preview(contentType: string, materialId: string): void {
    let path = '/materials/' + contentType.toLowerCase() + '/' + materialId + '/preview';
    this.router.navigate([path])
  }

  showPublicDialog(id: string) : void {
    this.showConfirmDialog = true;
    this.cd.detectChanges();
    this.materialToPublishId = id;
  }

  closePublicDialog() : void {
    this.showConfirmDialog = false;
  }

  publish(id: string) : void {
    this.showConfirmDialog = false;
    this.materialService.changeVisibility(id).subscribe( res => {
      this.toastr.info("Твоят материал е изпратен за одобрение.")
    })
  }

  edit(contentType: string, materialId: string): void  {
    this.router.navigate(["/materials/banner/edit"], { queryParams: { contentType: contentType, materialId: materialId } })
  }

  delete(materialId: string): void  {
    this.pendingDeleteMaterialId = materialId;
    this.customConfirmDialog.showDialog();
  }

  handleConfirmation(confirmed: boolean): void {
    if (confirmed) {
      this.materialService.delete(this.pendingDeleteMaterialId).subscribe(res => {
        this.toastr.success('Успешно изтри своя материал.')
      })
    }
  }

  getStateColor(stateType: any): string {
      switch (stateType) {
        case 1: return '#999DA3'; // Draft
        case 2: return '#FFCC70'; // Pending Approval
        case 3: return '#EB455F'; // Approved
        case 4: return '#A7D397'; // Disapproved
        default: return '#999DA3';
    }
  }
}
