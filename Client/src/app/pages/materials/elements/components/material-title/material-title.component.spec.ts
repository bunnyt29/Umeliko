import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialTitleComponent } from './material-title.component';

describe('MaterialTitleComponent', () => {
  let component: MaterialTitleComponent;
  let fixture: ComponentFixture<MaterialTitleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaterialTitleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MaterialTitleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
