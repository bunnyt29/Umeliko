import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VgPlayerComponent } from './vg-player.component';

describe('VgPlayerComponent', () => {
  let component: VgPlayerComponent;
  let fixture: ComponentFixture<VgPlayerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VgPlayerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VgPlayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
