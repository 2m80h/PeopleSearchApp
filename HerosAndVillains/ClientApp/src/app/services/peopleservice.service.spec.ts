import { TestBed, inject } from '@angular/core/testing';
import { peopleService } from './peopleservice.service';
import {HttpModule} from '@angular/http';


describe('peopleService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpModule
    ],
      providers: [peopleService]
    });
  });

  it('should be created', inject([peopleService], (service: peopleService) => {
    expect(service).toBeTruthy();
  }));
});
