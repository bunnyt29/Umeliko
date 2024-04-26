import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatorRoleComponent } from './creator-role.component';

describe('CreatorRoleComponent', () => {
  let component: CreatorRoleComponent;
  let fixture: ComponentFixture<CreatorRoleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatorRoleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatorRoleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
