import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatedForComponent } from './created-for.component';

describe('CreatedForComponent', () => {
  let component: CreatedForComponent;
  let fixture: ComponentFixture<CreatedForComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatedForComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatedForComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
