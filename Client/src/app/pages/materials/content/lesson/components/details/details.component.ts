import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import { switchMap, tap } from "rxjs/operators";

import { Lesson } from '../../models/lesson';
import { MaterialService } from "../../../../services/material.service";
import { Material } from "../../../../models/Material";
import { Vote } from "../../../../../../shared/models/Vote";
import { ProfileService } from 'src/app/pages/profile/services/profile.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommentsService } from 'src/app/pages/materials/elements/services/comments/comments.service';
import { Comment } from 'src/app/shared/models/Comment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'detail',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})

export class DetailsComponent implements OnInit {
  id!: string;
  myId!: string;
  lesson!: Lesson;
  material!: Material;
  materialsByCreator!: Array<Material>;
  otherMaterialsByCreator!: Array<Material>;
  videoUrl!: string;
  votes: Array<Vote> = [];
  creatorId!: string;
  commentForm!: FormGroup;
  comments: Comment[] = [];
  optionsVisible: boolean = false;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private materialService: MaterialService,
    private profileService: ProfileService,
    private commentsService: CommentsService,
    private toastr: ToastrService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.fetchData();
    this.commentForm = this.fb.group({
      'content': ['', [Validators.required, Validators.minLength(2)]],
      'materialId': this.id
    });
  }

  // fetchData(): void {
  //   this.route.params.pipe(
  //     tap(params => this.id = params['id']),
  //     switchMap(params => this.materialService.getMaterial(this.id)),
  //     tap(material => {
  //       this.material = material;
  //       this.videoUrl = material.lesson.fileUrl;
  //       this.votes = material.votes;
  //     }),
  //     switchMap(material => this.materialService.getMaterialsByCreator(material.creator.id)),
  //   ).subscribe(res => {
  //     // this.materialsByCreator = res.materials.filter((m: Material) => m.id !== this.id);
  //   });
  // }

  fetchData(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = params['id'];
    })

    this.materialService.getMaterial(this.id).subscribe(res => {
      this.material = res;
      this.votes = res.votes;

      this.videoUrl = res.lesson.fileUrl;

      let creatorId = res.creator.id;

      this.materialService.getMaterialsByCreator(creatorId).subscribe(res => {
        this.materialsByCreator = res.materials;
        this.otherMaterialsByCreator = this.materialsByCreator.filter(m => m.id != this.id);
      });
    });
  }

  getDetails(contentType: string, materialId: string): void {
    let path = '/materials/' + contentType.toLowerCase();
    this.router.navigate([path, materialId]).then(() => {
      window.scrollTo(0, 0);
    });
  }

  viewCreatorProfile(creatorId: string): void {
    this.creatorId = creatorId;
    this.profileService.getProfile(creatorId).subscribe( () => {
      this.router.navigate(['/profile'], { queryParams: { creatorId: creatorId } })
    })
  }
  
  create(): void {
    this.commentsService.create(this.commentForm.value).subscribe(res => {
      this.toastr.success("Коментарът е изпратен!");
      location.reload();
    })
  }

  extractCurrentUserId() {
    this.profileService.getMineProfile().subscribe( res => {
      this.myId = res.id;
    })
  }

  checkIfCommentIsMine(commenterId: string) : boolean{
    if(this.myId == commenterId){
      return true;
    }
    else {
      return false;
    }
  }

  toggleOptions(): void {
    this.optionsVisible = !this.optionsVisible;
    this.cd.detectChanges();
  }

  deleteComment(materialId: string, commentId: string){
    this.commentsService.delete(materialId, commentId).subscribe(res => {
      this.toastr.success("Вашият коментар е изтрит!")
    })
  }
}
