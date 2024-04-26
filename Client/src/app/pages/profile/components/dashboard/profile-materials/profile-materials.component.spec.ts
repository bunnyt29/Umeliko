import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileMaterialsComponent } from './profile-materials.component';

describe('ProfileMaterialsComponent', () => {
  let component: ProfileMaterialsComponent;
  let fixture: ComponentFixture<ProfileMaterialsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileMaterialsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfileMaterialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
