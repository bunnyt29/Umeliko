import { Component, Input } from '@angular/core';

import { Material } from "../../../models/Material";
import { ProfileService } from 'src/app/pages/profile/services/profile.service';
import { Router } from '@angular/router';

@Component({
  selector: 'material-metadata',
  templateUrl: './material-metadata.component.html',
  styleUrls: ['./material-metadata.component.scss']
})

export class MaterialMetadataComponent {
  @Input() material!: Material;
  creatorId!: string;

  constructor(
    private profileService: ProfileService,
    private router: Router
  ) { }

  viewCreatorProfile(creatorId: string): void {
    this.creatorId = creatorId;
    this.profileService.getProfile(creatorId).subscribe( () => {
      this.router.navigate(['/profile'], { queryParams: { creatorId: creatorId } })
    })
  }

}
