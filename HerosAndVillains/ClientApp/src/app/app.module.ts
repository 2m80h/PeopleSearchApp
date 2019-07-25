import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import {HttpModule} from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PeopleComponent } from './people/people.component';
import { CommonModule } from '@angular/common';
import { peopleService } from "./services/peopleservice.service";



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PeopleComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    CommonModule,
    RouterModule.forRoot([
      { path: '', component: PeopleComponent, pathMatch: 'full' }
    ])
  ],
  providers: [peopleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
