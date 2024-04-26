import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { FormBuilder, FormGroup } from "@angular/forms";

import { Vote } from "../../../../../shared/models/Vote";
import { VotesService } from "../../services/votes/votes.service";
import { ProfileService } from "../../../../profile/services/profile.service";
import { Creator } from "../../../../../shared/models/Creator";
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'interaction-toolbar',
  templateUrl: './interaction-toolbar.component.html',
  styleUrls: ['./interaction-toolbar.component.scss']
})

export class InteractionToolbarComponent implements OnInit {
  @Input() votes!: Array<Vote>;
  upvotes: number = 0;
  downvotes: number = 0;
  creator!: Creator;
  createVoteForm!: FormGroup;
  materialId!: string;
  vote!: Vote;

  constructor(
    private votesService: VotesService,
    private profileService: ProfileService,
    private route: ActivatedRoute,
    private changeDetector: ChangeDetectorRef,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {
    this.groupByType();

    this.route.params.subscribe(params => {
      this.materialId = params['id'];
    });

    this.createVoteForm = this.fb.group({
      'voteType': [],
      'materialId': [this.materialId]
    });
  }

  groupByType(): void {
    this.profileService.getMineProfile().subscribe(res => {
      this.creator = res;

      for (let vote of this.votes) {
        if (this.creator.id == vote.creatorId) {
          this.vote = vote;
        }

        switch (vote.voteType) {
          case 1:
            this.upvotes += 1;
            break;
          case 2:
            this.downvotes += 1;
            break;
        }
      }

      this.changeDetector.detectChanges();
    });
  }

  react(type: number) {
    if (this.vote && this.vote?.voteType == type) {
      let data = { 'id': this.vote?.id, 'materialId': this.materialId };
      this.votesService.delete(data).subscribe( res => {
        window.location.reload();
      });
    }
    else {
      this.createVoteForm.patchValue({
        'voteType': type
      });

      if (!this.vote) {
        this.votesService.create(this.createVoteForm.value).subscribe(() => {
          window.location.reload();
        });
      }
      else {
        let data = { 'id': this.vote?.id, 'materialId': this.materialId };
        this.votesService.delete(data).subscribe( res => {
          this.votesService.create(this.createVoteForm.value).subscribe(() => {
            window.location.reload();
          });
        });
      }
    }
  }

  isUpvoted(): boolean {
    return this.vote?.voteType === 1;
  }
  
  isDownvoted(): boolean {
    return this.vote?.voteType === 2;
  }
}

