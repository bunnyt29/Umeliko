import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WhatIsBannerComponent } from './what-is-banner.component';

describe('WhatIsBannerComponent', () => {
  let component: WhatIsBannerComponent;
  let fixture: ComponentFixture<WhatIsBannerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WhatIsBannerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WhatIsBannerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
