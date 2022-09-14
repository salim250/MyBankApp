import { TestBed } from '@angular/core/testing';

import { TransfertService } from './transfert.service';

describe('TransfertService', () => {
  let service: TransfertService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransfertService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
