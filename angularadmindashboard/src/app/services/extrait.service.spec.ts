import { TestBed } from '@angular/core/testing';

import { ExtraitService } from './extrait.service';

describe('ExtraitService', () => {
  let service: ExtraitService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExtraitService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
