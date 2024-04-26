import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InteractionToolbarComponent } from './interaction-toolbar.component';

describe('InteractionToolbarComponent', () => {
  let component: InteractionToolbarComponent;
  let fixture: ComponentFixture<InteractionToolbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InteractionToolbarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InteractionToolbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
