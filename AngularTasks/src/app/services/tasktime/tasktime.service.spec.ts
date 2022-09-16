import { TestBed } from '@angular/core/testing';

import { TasktimeService } from './tasktime.service';

describe('TasktimeService', () => {
  let service: TasktimeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TasktimeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
