import { Component, OnInit } from '@angular/core';

import { ProfileService } from 'src/app/pages/profile/services/profile.service';
import { Creator } from 'src/app/shared/models/Creator';

@Component({
  selector: 'material-title',
  templateUrl: './material-title.component.html',
  styleUrls: ['./material-title.component.scss']
})

export class MaterialTitleComponent implements OnInit {
  creator!: Creator;

  constructor(private profileService: ProfileService) { }

  ngOnInit(): void {
    this.fetchProfile();
  }

  fetchProfile(): void {
    this.profileService.getMineProfile().subscribe(res => {
      this.creator = res;
    })
  }
}
