import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})

export class ModalComponent {
  @Input() show: boolean = false;
  @Input() title: string = '';
  @Input() creators: any[] = [];
  @Output() onClose = new EventEmitter<void>();

  constructor(
    private router: Router
  ) { }

  close(): void {
    this.onClose.emit();
  }

  viewCreatorProfile(creatorId: string): void {
      this.router.navigate(['/profile'], { queryParams: { creatorId: creatorId } }).then(() => {
        location.reload();
      })
  }

}
