import {
  Person,
} from "./../models/person.model";

import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/toPromise';
import {HttpClientModule} from '@angular/common/http';
import {HttpModule, Http, Response} from '@angular/http';
import { Component, OnInit } from '@angular/core';



@Injectable()
export class peopleService {

  apiRoot: string = "api/People";
  results: object[];
  loading: boolean;
  hasResults: boolean;
  peoples: Person[] = [];
  runSlow: boolean = false;


  constructor(private http:Http){
    this.results = [];
    this.loading = false;
    this.hasResults = true;
  }

  searchPeople(runSlow: boolean, term: string){
    this.loading = true;
    let promise = new Promise((resolve, reject) => {
        let apiURL = `${this.apiRoot}?runSlow=${runSlow}&searchVal=${term}`;
        this.http.get(apiURL)
          .toPromise()
          .then(
            res => {
              this.results = res.json();
              if(this.results.length>0){
                this.hasResults = true;
              }else{
                this.hasResults = false;
              }
                
              this.loading = false;
              resolve();
            },
            msg => {
              reject();
            }
          )
    });
    return promise;
  }

}
