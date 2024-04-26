import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ProfileService } from '../../services/profile.service';
import { Creator } from '../../../../shared/models/Creator';
import { FollowService } from "../../../../shared/services/follow-activity/follow.service";

@Component({
  selector: 'detail',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})

export class DetailsComponent implements OnInit {
  creator!: Creator;
  creatorId!:string;
  numberOfFollowers!: number;
  numberOfFollowing!: number;
  isFollowing: boolean = false;
  showModal = false;
  modalTitle = '';
  creatorsToShow: any[] = [];
  followers: any[] = [];
  following: any[] = [];
  isFollowed!: boolean;
  followersTitle = 'Followers';
  followingTitle = 'Following';

  constructor(
    private profileService: ProfileService,
    private route: ActivatedRoute,
    private followService: FollowService
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.creatorId = params['creatorId'];
    })

    this.fetchProfile();

    this.checkIsFollowed();
  }

  fetchProfile(): void {
    this.profileService.getProfile(this.creatorId).subscribe( res => {
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

  follow(): void {
    this.followService.create(this.creatorId).subscribe(() => {
      window.location.reload()
    });
  }

  checkIsFollowed(): void {
    this.profileService.getMineProfile().subscribe(res => {
      let id = res.id;

      this.isFollowed = this.followers.some(follower => follower.id === id);
    })
  }

  unfollow(): void {
    this.followService.delete(this.creatorId).subscribe(() => {
      window.location.reload()
    });
  }
}
