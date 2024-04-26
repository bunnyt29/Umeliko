import { Component, Input } from '@angular/core';
import { AngularEditorConfig } from "@kolkov/angular-editor";

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss']
})

export class EditorComponent {
  name: string = 'Angular 6';
  @Input() htmlContent: string = '';

  config: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    width: '100%',
    height: 'auto',
    minHeight: '5rem',
    placeholder: 'Въведи текст тук...',
    translate: 'no',
    defaultParagraphSeparator: 'p',
    defaultFontName: 'Oswald',
    toolbarHiddenButtons: [
      [
        'fontSize',
        'fontName',
        'textColor',
        'backgroundColor',
        'justifyLeft',
        'justifyCenter',
        'justifyRight',
        'justifyFull',
        'toggleEditorMode',
        'insertImage',
        'insertVideo'
      ]
    ]
  };
}
