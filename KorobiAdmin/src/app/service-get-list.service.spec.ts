import { TestBed } from '@angular/core/testing';

import { ServiceGetListService } from './service-get-list.service';

describe('ServiceGetListService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ServiceGetListService = TestBed.get(ServiceGetListService);
    expect(service).toBeTruthy();
  });
});
