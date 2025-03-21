import { TestBed } from '@angular/core/testing';

import { MobileNavService } from './mobile-nav.service';

describe('MobileNavService', () => {
  let service: MobileNavService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MobileNavService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
