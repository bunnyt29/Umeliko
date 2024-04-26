import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialMetadataComponent } from './material-metadata.component';

describe('MaterialMetadataComponent', () => {
  let component: MaterialMetadataComponent;
  let fixture: ComponentFixture<MaterialMetadataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaterialMetadataComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MaterialMetadataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
