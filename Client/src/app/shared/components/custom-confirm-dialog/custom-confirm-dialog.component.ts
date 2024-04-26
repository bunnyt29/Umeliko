import {Component, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'custom-confirm-dialog',
  templateUrl: './custom-confirm-dialog.component.html',
  styleUrls: ['./custom-confirm-dialog.component.scss']
})
export class CustomConfirmDialogComponent {
  @Output() confirm = new EventEmitter<boolean>();
  isVisible = false;

  showDialog(): void  {
    this.isVisible = true;
  }

  closeDialog(confirmed: boolean): void  {
    this.isVisible = false;
    this.confirm.emit(confirmed);
  }

}
