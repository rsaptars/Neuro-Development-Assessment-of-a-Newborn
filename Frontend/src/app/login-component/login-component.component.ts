import { Component, OnInit ,Output, EventEmitter} from '@angular/core';
import {Router} from '@angular/router';
import { AppServiceService } from '../app-service.service';
@Component({
  selector: 'app-login-component',
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.css']
})
export class LoginComponentComponent implements OnInit {

  email = 'Admin';
  password = 'admin';
  showNav:boolean = false;
  
  constructor(private router: Router,private myservice: AppServiceService) {
    //this.showNavService = myservice;
  }
  tryLogin() {
    if(
      this.email === 'Admin' &&
      this.password === 'admin')
    {
      //this.showNavService.showNav = true;
      //console.log(this.showNavService.showNav)
      this.router.navigateByUrl('/dashboard');
    }
    else  {
          alert("Invalid Credentials");
          this.router.navigateByUrl('/app');
      
  }
  }
  
  ngOnInit() {
    
  }

  }
