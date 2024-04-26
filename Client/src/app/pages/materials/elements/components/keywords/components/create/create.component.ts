import { Component, Input } from '@angular/core';

import { Banner } from "../../../../../banner/models/Banner";

@Component({
  selector: 'create-keywords',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})

export class CreateComponent {
  @Input() banner!: Banner;
  keywords: Array<string> = [];
  private indexOfKeyword!: number;
  private keywordState: string = '';

  constructor() {}

  addKeyword(): void  {
    let keyword: string  = '';
    this.keywords.push(keyword);
  }

  deleteKeyword(keywordIndex: number): void {
    this.keywords.splice(keywordIndex, 1);
  }

  onClick(event: any): void {
    this.indexOfKeyword = event.target.name;
  }

  onInput(event: Event): void {
    this.keywordState = (event.target as HTMLInputElement).value;
  }

  onBlur(): void {
    this.keywords[this.indexOfKeyword] = this.keywordState;
    this.keywordState = '';
  }

}
