import {ChangeDetectorRef, Component, Input, OnInit, ViewChild} from '@angular/core';
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";

import { Material } from '../../../../materials/models/Material';
import { MaterialService } from "../../../../materials/services/material.service";
import { CustomConfirmDialogComponent } from "../../../../../shared/components/custom-confirm-dialog/custom-confirm-dialog.component";
import {Creator} from "../../../../../shared/models/Creator";
import { ProfileService } from '../../../services/profile.service';

@Component({
  selector: 'approved-materials',
  templateUrl: './approved-materials.component.html',
  styleUrls: ['./approved-materials.component.scss']
})
export class ApprovedMaterialsComponent {
  @Input() creator!: Creator;
  @ViewChild(CustomConfirmDialogComponent) customConfirmDialog!: CustomConfirmDialogComponent;
  materials: Array<Material> = [];
  pendingDeleteMaterialId!: string;
  hover: string | null = null;
  showConfirmDialog: boolean = false;
  creatorId!: string;

  constructor(
    private materialService: MaterialService,
    private profileService: ProfileService,
    private router: Router,
    private toastr: ToastrService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.fetchMaterials();
  }

  fetchMaterials(){
    this.materialService.getMaterialsByCreator(this.creator.id).subscribe(data => {
      this.materials = data.materials;
    })
  }

  getDetails(contentType: string, materialId: string): void {
    let path: string = '/materials/' + contentType.toLowerCase();
    this.router.navigate([path, materialId]);
  }

  viewCreatorProfile(creatorId: string): void {
    this.creatorId = creatorId;
    this.profileService.getProfile(creatorId).subscribe( () => {
      this.router.navigate(['/profile'], { queryParams: { creatorId: creatorId } })
    })
  }
}
