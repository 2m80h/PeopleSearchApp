import { Component, Inject } from '@angular/core';
import {Injectable} from '@angular/core';

import { peopleService } from "../services/peopleservice.service";
import { Person} from "../models/person.model";

import { HttpClient } from '@angular/common/http';
import {HttpClientModule} from '@angular/common/http';
import {HttpModule} from '@angular/http';
import {Http, Response} from "@angular/http";
import { $ } from 'protractor';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css'],
  providers:[PeopleComponent]
})
export class PeopleComponent {

  people:Promise<Person[]>;
  toggleShowHide:string ="hidden";  
  runSlow: boolean = false;

  constructor(private _peopleService: peopleService){
  }

  doIfChecked(runSlow){
    if(this._peopleService.runSlow==false){
      this._peopleService.runSlow = true;
    }else{
      this._peopleService.runSlow = false;
    }
      
    console.log(this._peopleService.runSlow);
  }

  getPeople(term: string){
    this._peopleService.results.length = 0;
    this._peopleService.hasResults = false;

    if(term.length==0){
      return;
    }
    this._peopleService.searchPeople(this._peopleService.runSlow, term);
  }
  getAllPeople(){
    this._peopleService.results.length = 0;
    this._peopleService.searchPeople(this._peopleService.runSlow, "");
  }
}