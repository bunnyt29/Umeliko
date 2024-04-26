import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HelpingCenterLayoutComponent } from './helping-center-layout.component';

describe('HelpingCenterLayoutComponent', () => {
  let component: HelpingCenterLayoutComponent;
  let fixture: ComponentFixture<HelpingCenterLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HelpingCenterLayoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HelpingCenterLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
