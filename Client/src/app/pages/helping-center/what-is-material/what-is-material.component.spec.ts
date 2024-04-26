import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WhatIsMaterialComponent } from './what-is-material.component';

describe('WhatIsMaterialComponent', () => {
  let component: WhatIsMaterialComponent;
  let fixture: ComponentFixture<WhatIsMaterialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WhatIsMaterialComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WhatIsMaterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
