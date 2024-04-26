import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovedMaterialsComponent } from './approved-materials.component';

describe('ApprovedMaterialsComponent', () => {
  let component: ApprovedMaterialsComponent;
  let fixture: ComponentFixture<ApprovedMaterialsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApprovedMaterialsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApprovedMaterialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
