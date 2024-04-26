import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router} from "@angular/router";

import { Article } from '../../models/Article';
import { Material } from "../../../../models/Material";
import { ArticleService } from "../../services/article.service";
import { EditorComponent } from "../../../../elements/components/editor/editor.component";
import { Resource } from 'src/app/shared/models/Resource';
import { EditComponent as ЕditResourcesComponent } from 'src/app/pages/materials/elements/components/resources/components/edit/edit.component';
import { ResourcesService } from 'src/app/pages/materials/elements/services/resources/resources.service';
import {
  CreateComponent as CreateResourcesComponent
} from "../../../../elements/components/resources/components/create/create.component";

@Component({
  selector: 'edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})

export class EditComponent implements OnInit{
  @ViewChild(EditorComponent) child: any;
  @ViewChild(CreateResourcesComponent) child1: any;

  id!: string;
  material!: Material;
  article!: Article;
  articleForm!: FormGroup;
  materialId!: string;
  uploadedResources!: Array<Resource>;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private articleService: ArticleService,
    private resourcesService: ResourcesService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.materialId = params['materialId'];
    });

    this.fetchArticle();
  }

  fetchArticle(): void {
    this.articleService.get(this.materialId).subscribe(res => {
      this.article = res;
      this.uploadedResources = res.resources;

      this.articleForm = this.fb.group({
        "id": [this.article.id],
        "content": [this.article.content, Validators.required],
        "materialId": [this.article.materialId],
      });
    });
  }

  editArticle(): void {
    this.articleForm.patchValue({
      content: this.child.htmlContent
    });

    this.articleService.edit(this.articleForm.value).subscribe( res => {
      for (let resource of this.child1.resourcesArray) {
        resource.containerId = this.article.id;
        resource.containerType = "Article";
        this.resourcesService.create(resource).subscribe( () => {})
      }
    });

    this.router.navigate(['/profile/dashboard']);
  }
}
