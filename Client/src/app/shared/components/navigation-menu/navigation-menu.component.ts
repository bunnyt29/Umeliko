import { ChangeDetectorRef, Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup } from "@angular/forms";
import { Router} from "@angular/router";
import { HttpParams } from '@angular/common/http';

import { Creator } from "../../models/Creator";
import { ProfileService } from "../../../pages/profile/services/profile.service";
import { AuthService } from "../../../pages/auth/services/auth.service";
import { MaterialService } from "../../../pages/materials/services/material.service";

@Component({
  selector: 'navigation-menu',
  templateUrl: './navigation-menu.component.html',
  styleUrls: ['./navigation-menu.component.scss']
})

export class NavigationMenuComponent implements OnInit {
  searchForm!: FormGroup;
  searchResult: any[] = [];
  creator!: Creator;
  isLogged: boolean = false;
  imageSrc?: string;
  optionsVisible: boolean = false;
  searchOptionsVisible: boolean = false;
  @Input() canRenderSearchBar: boolean = false;

  constructor(
    private profileService: ProfileService,
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private materialService: MaterialService,
    private router: Router,
    private cd: ChangeDetectorRef,
  ) { }

  ngOnInit(): void {
    this.searchForm = this.formBuilder.group({
      searchType: ['title'], // Default the dropdown to 'title'
      query: ['']
    });

    this.checkAuthentication();
  }

  search(): void {
    const { searchType, query } = this.searchForm.value;
    let params = new HttpParams();

    if (query) {
      params = params.append(searchType, query);
    }

    const queryString = params.toString();
    
    this.materialService.search(queryString).subscribe(res => {
      this.searchResult = res.materials;
    });
  }

  viewMaterial(materialId: string, contentType: string){
    let path = '/materials/' + contentType.toLowerCase() + '/' + materialId;
    this.router.navigate([path])
  }

  toggleSearchOptions(): void {
    this.searchOptionsVisible = !this.searchOptionsVisible;
    this.cd.detectChanges();
  }

  getSearchTypeDisplay(searchType: string): string {
    switch(searchType) {
      case 'title': return 'По заглавие';
      case 'keyword': return 'По ключова дума';
      case 'author': return 'По автор';
      default: return '';
    }
  }

  toggleOptions(): void {
    this.optionsVisible = !this.optionsVisible;
    this.cd.detectChanges();
  }

  checkAuthentication() : void {
    this.isLogged = this.authService.isAuthenticated();
    if (this.isLogged) {
      this.profileService.getMineProfile().subscribe(res => {
        this.creator = res;
        this.imageSrc = this.creator.imageUrl;
        this.cd.detectChanges();
      });
    }
  }

  logout(): void {
    this.authService.logout();
    this.isLogged = this.authService.isAuthenticated();
    this.router.navigate(['/home']);
  }
}
