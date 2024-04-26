import { Component, OnInit } from '@angular/core';

import { Creator } from "../../../../shared/models/Creator";
import { ProfileService } from "../../services/profile.service";


@Component({
  selector: 'details-mine',
  templateUrl: './details-mine.component.html',
  styleUrls: ['./details-mine.component.scss']
})

export class DetailsMineComponent implements OnInit {
  creator!: Creator;
  id!:string;
  numberOfFollowers!: number;
  numberOfFollowing!: number;
  showModal = false;
  modalTitle = '';
  creatorsToShow: any[] = [];
  followers: any[] = [];
  following: any[] = [];
  isFollowed!: boolean;
  followersTitle = 'Followers';
  followingTitle = 'Following';
  constructor(
    private profileService: ProfileService
  ) { }

  ngOnInit(): void {
    this.fetchProfile();
  }

  fetchProfile(): void {
    this.profileService.getMineProfile().subscribe(res => {
      this.creator = res;
      this.followers = res.followers;
      this.following = res.following;
      this.numberOfFollowers = res.followers.length;
      this.numberOfFollowing = res.following.length;
    })
  }

  openModal(title: string, users: any[]): void  {
    this.modalTitle = title;
    this.creatorsToShow = users;
    this.showModal = true;
  }

  closeModal(): void  {
    this.showModal = false;
  }

  updateTitle(type: 'followers' | 'following'): void {
    if (type === 'followers') {
      this.followersTitle = 'Последователи';
    } else {
      this.followingTitle = 'Следващи';
    }
  }

  resetTitle(): void {
    this.followersTitle = 'Последователи';
    this.followingTitle = 'Следващи';
  }
}
