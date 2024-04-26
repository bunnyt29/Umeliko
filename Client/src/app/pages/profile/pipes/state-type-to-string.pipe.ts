import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'stateTypeToString'
})
export class StateTypeToStringPipe implements PipeTransform {

  transform(value: unknown): string {
    switch ( value ) {
      case 1: return "Чернова";
      case 2: return "Чакащ одобрение";
      case 3: return "Отхвърлен";
      case 4: return "Одобрeн";
      default: console.log(value);
    }
    return "";
  }

}
