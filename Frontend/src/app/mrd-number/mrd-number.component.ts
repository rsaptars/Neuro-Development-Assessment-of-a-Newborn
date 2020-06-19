import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-mrd-number',
  templateUrl: './mrd-number.component.html',
  styleUrls: ['./mrd-number.component.css']
})
export class MrdNumberComponent implements OnInit {
  data:any;
  MRDno: string;
  result: any;
  found: false;
  constructor(private http: HttpClient) { 
    this.http.get("http://localhost:60732/api/Patients").subscribe(response => {
    this.data = response;
    console.log(this.data);
    
  });
 
  
  }
  display = function() {
    for(var i = 0; i < this.data.length; i++) {
      if(this.data[i].MRDno === this.MRDno) {
        console.log(this.data[i])
        this.found = true
        this.result = this.data[i];
      }
    }
  }
  ngOnInit() {
  }

}
