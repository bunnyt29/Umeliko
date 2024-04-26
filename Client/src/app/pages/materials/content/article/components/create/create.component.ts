import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

import { ArticleService } from '../../services/article.service';
import { EditorComponent } from "../../../../elements/components/editor/editor.component";
import { CreateComponent as CreateResourcesComponent } from "../../../../elements/components/resources/components/create/create.component";
import { ResourcesService } from "../../../../elements/services/resources/resources.service";

@Component({
  selector: 'create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})

export class CreateComponent implements OnInit {
  @ViewChild(EditorComponent) child: any;
  @ViewChild(CreateResourcesComponent) child1: any;
  articleForm!: FormGroup;
  keywords: string[] = [];
  materialId!: string;
  materialData!: {};
  articleId!: string;

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private articleService: ArticleService,
    private resourcesService: ResourcesService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.materialId = params['materialId'];
    })

    this.articleForm = this.fb.group({
      content: ['', Validators.required]
    });
  }


  create(): void {
    this.articleForm.patchValue({
      content: this.child.htmlContent
    });

    let materialId = this.materialId;
    this.materialData = {...this.articleForm.value, materialId};

    this.articleService.create(this.materialData).subscribe(res => {
      this.articleId = res.articleId;

      for (let resource of this.child1.resourcesArray) {
          resource.containerId = this.articleId;
          resource.containerType = "Article";
          this.resourcesService.create(resource).subscribe( () => {})
      }

      this.toastr.success("Статията е успешно създадена!");

      this.router.navigate(["/profile/dashboard"]);
    })
  }
}
