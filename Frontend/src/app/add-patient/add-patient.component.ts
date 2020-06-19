import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css']
})
export class AddPatientComponent implements OnInit {

  states: any;
  gestational_age: any;
  risks_1: any;
  risks_treatments: any;
  medication: any;
  anticonvulsant: any;
  immunization: any;
  investigation: any;
  risks_mild: any;
  risks_moderate: any;
  risks_high: any;
  generalDetails: any;
  diagnosis: any;
  risk_type: any;
  risks : any;
  calcDate: any;
  constructor(private http: HttpClient) {
    // this.http.get("http://localhost:60732/api/Patients").
    // map((response) => response.json()).
    // subscribe((response) => console.log(response));
    this.states = [
      {
          "name": "Alabama",
          "abbreviation": "AL"
      },
      {
          "name": "Alaska",
          "abbreviation": "AK"
      },
      {
          "name": "American Samoa",
          "abbreviation": "AS"
      },
      {
          "name": "Arizona",
          "abbreviation": "AZ"
      },
      {
          "name": "Arkansas",
          "abbreviation": "AR"
      },
      {
          "name": "California",
          "abbreviation": "CA"
      },
      {
          "name": "Colorado",
          "abbreviation": "CO"
      },
      {
          "name": "Connecticut",
          "abbreviation": "CT"
      },
      {
          "name": "Delaware",
          "abbreviation": "DE"
      },
      {
          "name": "District Of Columbia",
          "abbreviation": "DC"
      },
      {
          "name": "Federated States Of Micronesia",
          "abbreviation": "FM"
      },
      {
          "name": "Florida",
          "abbreviation": "FL"
      },
      {
          "name": "Georgia",
          "abbreviation": "GA"
      },
      {
          "name": "Guam",
          "abbreviation": "GU"
      },
      {
          "name": "Hawaii",
          "abbreviation": "HI"
      },
      {
          "name": "Idaho",
          "abbreviation": "ID"
      },
      {
          "name": "Illinois",
          "abbreviation": "IL"
      },
      {
          "name": "Indiana",
          "abbreviation": "IN"
      },
      {
          "name": "Iowa",
          "abbreviation": "IA"
      },
      {
          "name": "Kansas",
          "abbreviation": "KS"
      },
      {
          "name": "Kentucky",
          "abbreviation": "KY"
      },
      {
          "name": "Louisiana",
          "abbreviation": "LA"
      },
      {
          "name": "Maine",
          "abbreviation": "ME"
      },
      {
          "name": "Marshall Islands",
          "abbreviation": "MH"
      },
      {
          "name": "Maryland",
          "abbreviation": "MD"
      },
      {
          "name": "Massachusetts",
          "abbreviation": "MA"
      },
      {
          "name": "Michigan",
          "abbreviation": "MI"
      },
      {
          "name": "Minnesota",
          "abbreviation": "MN"
      },
      {
          "name": "Mississippi",
          "abbreviation": "MS"
      },
      {
          "name": "Missouri",
          "abbreviation": "MO"
      },
      {
          "name": "Montana",
          "abbreviation": "MT"
      },
      {
          "name": "Nebraska",
          "abbreviation": "NE"
      },
      {
          "name": "Nevada",
          "abbreviation": "NV"
      },
      {
          "name": "New Hampshire",
          "abbreviation": "NH"
      },
      {
          "name": "New Jersey",
          "abbreviation": "NJ"
      },
      {
          "name": "New Mexico",
          "abbreviation": "NM"
      },
      {
          "name": "New York",
          "abbreviation": "NY"
      },
      {
          "name": "North Carolina",
          "abbreviation": "NC"
      },
      {
          "name": "North Dakota",
          "abbreviation": "ND"
      },
      {
          "name": "Northern Mariana Islands",
          "abbreviation": "MP"
      },
      {
          "name": "Ohio",
          "abbreviation": "OH"
      },
      {
          "name": "Oklahoma",
          "abbreviation": "OK"
      },
      {
          "name": "Oregon",
          "abbreviation": "OR"
      },
      {
          "name": "Palau",
          "abbreviation": "PW"
      },
      {
          "name": "Pennsylvania",
          "abbreviation": "PA"
      },
      {
          "name": "Puerto Rico",
          "abbreviation": "PR"
      },
      {
          "name": "Rhode Island",
          "abbreviation": "RI"
      },
      {
          "name": "South Carolina",
          "abbreviation": "SC"
      },
      {
          "name": "South Dakota",
          "abbreviation": "SD"
      },
      {
          "name": "Tennessee",
          "abbreviation": "TN"
      },
      {
          "name": "Texas",
          "abbreviation": "TX"
      },
      {
          "name": "Utah",
          "abbreviation": "UT"
      },
      {
          "name": "Vermont",
          "abbreviation": "VT"
      },
      {
          "name": "Virgin Islands",
          "abbreviation": "VI"
      },
      {
          "name": "Virginia",
          "abbreviation": "VA"
      },
      {
          "name": "Washington",
          "abbreviation": "WA"
      },
      {
          "name": "West Virginia",
          "abbreviation": "WV"
      },
      {
          "name": "Wisconsin",
          "abbreviation": "WI"
      },
      {
          "name": "Wyoming",
         "abbreviation": "WY"
      }
    ];
    this.gestational_age = [
        {id: 0, value: 'Less than 24 weeks'},
        {id: 1, value: '24-26 weeks'},
        {id: 2, value: '26-28 weeks'},
        {id: 3, value: '28-30 weeks'},
        {id: 4, value: '30-32 weeks'},
        {id: 5, value: '32-34 weeks'},
        {id: 6, value: '34-36 weeks & 6 days'},
        {id: 7, value: '37-39 weeks'},
        {id: 8, value: '39-40 weeks & 6 days'},
        {id: 9, value: '41-42 weeks'},
        {id: 10, value: 'More than 42 weeks'}
    ];
    this.risks_1 = [
      {id: 0, value: 'None'},
      {id: 1, value: 'Apnea'},
      {id: 2, value: 'Aspiration Pneumonia'},
      {id: 3, value: 'At risk of Sepsis'},
      {id: 4, value: 'ABO incompatibility'}
    ];
    this.risks_treatments = [
      {id: 0, value: 'None'},
      {id: 1, value: 'Oxygen'},
      {id: 2, value: 'CPAP'},
      {id: 3, value: 'Phototherapy'},
      {id: 4, value: 'Mechanical Ventilation'}
    ];
    this.medication = [
      {id: 0, value: 'Syp Calcium P', checked:true},
      {id: 1, value: 'MultiVitamin Drops', checked:true},
      {id: 2, value: 'Vitamin D3 Drops', checked:true},
      {id: 3, value: 'Iron Drops', checked:true},
      {id: 4, value: 'HMF Sachets', checked:true}
    ];
    this.anticonvulsant = [
      {id: 0, value: 'Phenobarbitone', checked:true},
      {id: 1, value: 'Levetiracetam', checked:true},
      {id: 2, value: 'Clobazam', checked:true},
      {id: 3, value: 'Phenytoin', checked:true}
    ];
    this.immunization = [
      {id: 0, value: 'BCG', checked:true},
      {id: 1, value: 'PENTA 1', checked:true},
      {id: 2, value: 'PENTA 2', checked:true},
      {id: 3, value: 'PENTA 3', checked:true},
      {id: 4, value: 'MEASLES(1st)/MR/MMR', checked:true},
      {id: 5, value: 'MEASLES(2nd)/MR/MMR', checked:true},
      {id: 6, value: 'PENTA(1st Booster)', checked:true}
    ];
    this.investigation = [
      {id: 0, value: 'USG Skull', checked:false, result:''},
      {id: 1, value: 'CT Scan/MRI', checked:false, result:''},
      {id: 2, value: 'EEG', checked:false, result:''},
      {id: 3, value: 'OAE/BERA/ENT', checked:false,result:''}
    ];
    this.risks_mild = [];
    this.risks_moderate = [];
    this.risks_high = [];
    this.http.get("http://localhost:60732/api/Risks").
    //map((response) => response.json()).
    subscribe(response => {
        this.risks = response;
        console.log(this.risks);
        for(var i = 0; i < this.risks.length; i++) {
            switch(this.risks[i].Severity) {
                case 1: this.risks_mild.push(this.risks[i])
                        break;
                case 2: this.risks_moderate.push(this.risks[i])
                        break;
                case 3: this.risks_high.push(this.risks[i])
                        break;
            }
        }
        //console.log(this.risks_mild);
      });
    
    

    this.http.get("http://localhost:60732/api/Morbidities").
    subscribe((response) => this.risks_1=response)

    // this.http.get("http://localhost:60732/api/MedicationTypes").
    // subscribe((response) => this.medication=response)
    // console.log(this.medication)

    var today = new Date();
    var dd = String(today.getDate()).padStart(2,'0');
    var mm = String(today.getMonth()+1).padStart(2,'0');
    var yyyy = today.getFullYear();
    var date = mm + '/' + dd + '/' + yyyy;
    var nd = 0;

    this.calcDate = function(date1,date2) {
        var diff = Math.floor(date2.getTime() - date1.getTime());
        var day = 1000 * 60 * 60 * 24;
    
        var days = Math.floor(diff/day);
        var months = Math.floor(days/31);
        var years = Math.floor(months/12);
    
        //var message = date2.toDateString();
        var message = days + " days " 
        message += months + " months "
    
        return message
        }
        
    this.generalDetails = {
        MRDno: '',
        NDno: '',
        Date: date,
        Name: '',
        Sex: '',
        PhoneNo: '',
        GestationalAge:'',
        BirthWeight:'',
        WeightOnDischarge:'',
        HCOnDischarge: '',
        LengthOnDischarge:'',
        DateOfBirth: '',
        CurrentAge: '',
        DateOfAdmission:'',
        Edd:'',
        CurrentGestationalAge:'',
        DateOfDischarge:'',
        Adress:'',
        State: '',
        District:'',
        Medication:'',
	    Anticonvulsant1:'',
        Term: '',   
        AgaSgaLga: '',
        LbwVlbwElbw:'',
        Morbidities: '',
        MorbiditiesTreatment: '',
	    InvestigationType:'',
	    Severity:'',
	    Reason:'',
	    ImmunnizationType:'',
	    Risks:''
    }
    this.diagnosis = {
        MRDno: this.generalDetails.MRDno,
        Term: 'Preterm',
        GestationalAge: '2 months',
        AgaSgaLga: 'SGA',
        LbwVlbwElbw:'LBW',
        Morbidities: [],
        MorbiditiesTreatment: [] 
    }

}
addInvestigationResult = function(id,result) {
    this.investigation[id].result = result;
}
calcCA = function(){
    this.generalDetails.CurrentAge= this.calcDate(new Date(this.generalDetails.DateOfBirth),new Date(this.generalDetails.Date));
}
calcCGA = function(){
    this.generalDetails.CurrentGestationalAge= this.calcDate(new Date(this.generalDetails.Edd),new Date(this.generalDetails.Date));
}
calcWeightType = function() {
    var bw = parseInt(this.generalDetails.BirthWeight)
    if(bw < 1500){
    this.generalDetails.LbwVlbwElbw = 'VLBW';
    }
    else if(bw < 1000){
        this.generalDetails.LbwVlbwElbw = 'ELBW';
        }
        else {
            this.generalDetails.LbwVlbwElbw = 'LBW';
        }
   //console.log(typeof(this.generalDetails.BirthWeight))
}
changeRisk= function(risk,$event) {
    this.diagnosis.Morbidities.push(risk.MorbidityName);
} 
addRiskTreatment = function(rt,$event) {
    this.diagnosis.MorbiditiesTreatment.push(rt.value);
}
   changeStatus = function(id,risk,type){
    var self = this;
    //type[id].checked = !type[id].checked;
    switch(risk) {
        case 1: //type.forEach(function (r) {
                //if(r.checked) {
                    self.risk_type = "Mild";
                //}
                //});
                break;
        case 2: type.forEach(function (r) {
                if(r.checked) {
                    self.risk_type = "Moderate";
                }
                });
                break;

        case 3: type.forEach(function (r) {
                if(r.checked) {
                self.risk_type = "High";
                }
                });
                break;

    }
   }
   changeOption = function(value){
    this.generalDetails.State = value.name;
    }
    changeGa = function(ga) {
        this.generalDetails.GestationalAge = ga.value;
        console.log(ga.id)
        //for(var i = 0; i < this.gestational_age.length;i++) {
            switch(ga.id) {
                case 0: this.generalDetails.Term = 'PreTerm'; 
                        this.generalDetails.AgaSgaLga = 'AGA';
                        break;
                case 1: this.generalDetails.Term = 'PreTerm'; 
                        this.generalDetails.AgaSgaLga = 'AGA';
                        break;
                case 2: this.generalDetails.Term = 'PreTerm'; 
                        this.generalDetails.AgaSgaLga = 'AGA';
                        break;
                case 3: this.generalDetails.Term = 'PreTerm'; 
                        this.generalDetails.AgaSgaLga = 'AGA';
                        break;
                case 4: this.generalDetails.Term = 'PreTerm'; 
                        this.generalDetails.AgaSgaLga = 'AGA';
                        break;
                case 5: this.generalDetails.Term = 'Term'; 
                        this.generalDetails.AgaSgaLga = 'SGA';
                        break;
                case 6: this.generalDetails.Term = 'Term'; 
                        this.generalDetails.AgaSgaLga = 'SGA';
                        break;
                case 7: this.generalDetails.Term = 'Term'; 
                        this.generalDetails.AgaSgaLga = 'SGA';
                        break;
                case 8: this.generalDetails.Term = 'Term'; 
                        this.generalDetails.AgaSgaLga = 'SGA';
                        break;
                case 9: this.generalDetails.Term = 'PostTerm'; 
                        this.generalDetails.AgaSgaLga = 'LGA';
                        break;
                case 10: this.generalDetails.Term = 'PostTerm'; 
                        this.generalDetails.AgaSgaLga = 'LGA';
                        break;
            }
            this.generalDetails.GA = ga.value;
        //}
    }
   changeSex = function(evt) {
    this.generalDetails.sex = evt;
    }
   
               
    submit = function(obj) {
       
        
        var arrImmu = [];
        const headers = {
           'Access-Control-Allow-Credentials':true,
           'Access-Control-Allow-Origin': "*",
           'Content-Type': 'application/json; charset=utf-8',
           "X-Requested-With": "XMLHttpRequest"
             }
        
        var response,data;

        //Medication
            var arr = [];
               for(var i = 0; i < this.medication.length; i++) {
                   if(this.medication[i].checked === true) {
                    arr.push(this.medication[i].value);
                   }
               }
            var arr2 = arr.toString();
            this.generalDetails.Medication = arr2;
         //Anticonvulsant       
            var arrAC = [];
                for(var i = 0; i < this.anticonvulsant.length; i++) {
                    if(this.anticonvulsant[i].checked === true) {
                     arrAC.push(this.anticonvulsant[i].value);
                    }
                }
                var arrAC2 = arrAC.toString();
                this.generalDetails.Anticonvulsant1 = arrAC2;
            

                this.generalDetails.Morbidities = this.generalDetails.Morbidities.toString();
                this.generalDetails.MorbiditiesTreatment = this.generalDetails.MorbiditiesTreatment.toString();  
                
                //Investigations

               var arrInv = [];
               for(var i = 0; i < this.investigation.length; i++) {
                if(this.investigation[i].checked === true) {
                    arrInv.push(this.investigation[i].value);
                }
                }
                var arrInv2 = arrInv.toString();
                this.generalDetails.InvestigationType = arrInv2;

                 for(var i = 0; i < this.immunization.length; i++) {
                    if(this.immunization[i].checked === true) {
                     arrImmu.push(this.immunization[i].value);
                     
                    }
                }
                var arrImmu2 = arrImmu.toString();
                this.generalDetails.ImmunnizationType = arrImmu2;
            //          //console.log(this.generalDetails);
            //      var immunization = {
            //          MRDno : this.generalDetails.MRDno,
            //          Immunization : arrImmu2
            //      }
            //      this.http.post(`http://localhost:60732/api/Immunizations`,immunization, headers).
            //       subscribe(data  => {
            //          console.log("POST Request is successful ", data);
            //          },error  => {
            //      console.log("Error", error);                
            //      });

            //      for(var i = 0; i < this.investigation.length; i++) {
            //         if(this.investigation[i].checked === true) {
            //             var investigation = {
            //                 MRDno : this.generalDetails.MRDno,
            //                 Investigation : this.investigation[i].value,
            //                 Severity: this.investigation[i].result,
            //                 Reason: null
            //             }
            //             this.http.post(`http://localhost:60732/api/Investigations`,investigation, headers).
            //             subscribe(data  => {
            //                console.log("POST Request is successful ", data);
            //                },error  => {
            //            console.log("Error", error);                
            //            });
                       
            //         }
            //     }

            //     var morbidity = this.diagnosis.Morbidities.toString();
            //     var morbidityTreatment = this.diagnosis.MorbiditiesTreatment.toString();

            //     var diagnosis = {
            //         MRDno: this.generalDetails.MRDno,
            //         Term: 'Preterm',
            //         GestationalAge: '2 months',
            //         AgaSgaLga: 'SGA',
            //         LbwVlbwElbw:'LBW',
            //         Morbidities: morbidity,
            //         MorbiditiesTreatment: morbidityTreatment
            //     }

            //     this.http.post(`http://localhost:60732/api/Diagnosis`,diagnosis, headers).
            //       subscribe(data  => {
            //          console.log("POST Request is successful ", data);
            //          },error  => {
            //      console.log("Error", error);                
            //      });
            console.log(this.generalDetails)
            this.http.post(`http://localhost:60732/api/Patients`,this.generalDetails, headers).
            subscribe(data  => {
                console.log("POST Request is successful ", data);
                },error  => {
                    console.log("Error", error);                
                    }); 
                
    }
  ngOnInit() {
  }

}
