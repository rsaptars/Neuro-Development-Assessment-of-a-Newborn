import { Component } from '@angular/core';

import {Router} from '@angular/router';

import { AppServiceService } from './app-service.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  showNav: boolean;
  constructor(private router: Router,private myservice: AppServiceService) {
    //this.showNavService = myservice;
    this.router.events.subscribe((event) => {
      console.log(this.showNav)
      var evt: any = event;
      if(evt.url == "/dashboard" || evt.url == "/patient" || evt.url == "/mrdsearch" ){
    this.showNav = true;
      }
  });
  }
  title = 'TermProject';
  
}
