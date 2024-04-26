import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'contentTypeToString'
})
export class ContentTypeToStringPipe implements PipeTransform {

  transform(value: unknown): string {
    switch ( value ) {
      case 'Article': return "статия";
      case 'Lesson': return "урок";
      case 'Course': return "курс";
      default: console.log(value);
    }
    return "";
  }

}
