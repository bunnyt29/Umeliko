import { Component, Input } from '@angular/core';

@Component({
  selector: 'video-player',
  templateUrl: './vg-player.component.html',
  styleUrls: ['./vg-player.component.scss']
})

export class VgPlayerComponent {
  @Input() videoUrl!: string;
}
