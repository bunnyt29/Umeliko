import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsMineComponent } from './details-mine.component';

describe('DetailsMineComponent', () => {
  let component: DetailsMineComponent;
  let fixture: ComponentFixture<DetailsMineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsMineComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailsMineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
