import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Material } from '../../../models/Material';
import { CommentsService } from '../../services/comments/comments.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { Comment } from 'src/app/shared/models/Comment';

@Component({
  selector: 'comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss']
})
export class CommentsComponent implements OnInit {
  @Input() comments: Comment[] = [];
  commentForm!: FormGroup;
  materialId!: string;

  constructor(
    private fb: FormBuilder,
    private commentsService: CommentsService,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.materialId = params['id'];
    });

    this.commentForm = this.fb.group({
      'id': [''],
      'content': ['', Validators.required],
      'materialId': this.materialId
    });
  }

  create(): void {
    this.commentsService.create(this.commentForm.value).subscribe(res => {
      this.toastr.success("Коментарът е изпратен!");
    })
  }
}
