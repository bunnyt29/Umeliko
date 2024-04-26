import { TestBed } from '@angular/core/testing';

import { KeywordsService } from './keywords.service';

describe('KeywordsService', () => {
  let service: KeywordsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KeywordsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
