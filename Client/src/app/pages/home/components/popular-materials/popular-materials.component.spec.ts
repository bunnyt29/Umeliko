import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopularMaterialsComponent } from './popular-materials.component';

describe('PopularMaterialsComponent', () => {
  let component: PopularMaterialsComponent;
  let fixture: ComponentFixture<PopularMaterialsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PopularMaterialsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PopularMaterialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
