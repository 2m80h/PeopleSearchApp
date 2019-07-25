import { Component } from '@angular/core';
import { peopleService } from "./services/peopleservice.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private peoples:peopleService){
  }
  title = 'Heros And Vilians';

}
