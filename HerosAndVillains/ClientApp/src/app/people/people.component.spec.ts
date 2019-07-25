import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PeopleComponent } from './people.component';
import { peopleService } from '../services/peopleservice.service';
import {HttpModule} from '@angular/http';

describe('PeopleComponent', () => {
  let component: PeopleComponent;
  let fixture: ComponentFixture<PeopleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpModule
    ],
      declarations: [ PeopleComponent ],
      providers: [PeopleComponent,peopleService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PeopleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
